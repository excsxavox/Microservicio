using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UserService.Interface;

namespace UserService.App.Commands.ItemCommads
{
    public class ItemsCommand : IRequest
    {
        public List<Item> Items { get; set; }
        public List<user> Users { get; set; }
    }


    public class ItemCommandHandler : IRequestHandler<ItemsCommand>
    {
        Task IRequestHandler<ItemsCommand>.Handle(ItemsCommand request, CancellationToken cancellationToken)
        {

            var urgentItems = request.Items
                .Where(item => (item.DueDate - DateTime.Now).TotalDays < 3 && !item.IsCompleted)
                .ToList();


            var relevantItems = request.Items
                .Where(item => item.Relevance == "Alta" && !item.IsCompleted)
                .OrderBy(item => item.DueDate)
                .ToList();

            var lowRelevanceItems = request.Items
            .Where(item => item.Relevance == "Baja" && !item.IsCompleted)
            .OrderBy(item => item.DueDate)
            .ToList();


            AssignUrgentItems(urgentItems, request.Users);


            AssignRelevantItems(relevantItems, request.Users);

            AssignLowRelevanceItems(lowRelevanceItems, request.Users);

            return Task.FromResult(Unit.Value);
        }

        // Asignar ítems urgentes
        private void AssignUrgentItems(List<Item> urgentItems, List<user> users)
        {
            foreach (var item in urgentItems)
            {
                // Usuario con menos de 3 ítems y ordenar por items pendientes
                var user = users
                    .Where(u => u.PendingItemsCount < 3)
                    .OrderBy(u => u.PendingItemsCount)
                    .FirstOrDefault();

                if (user != null)
                {
                    if (user.Items != item)
                    item.AssignedUser = user.Username;
                    user.PendingItemsCount++;
                }
            }
        }


        // Asignar ítems relevantes Alta
        private void AssignRelevantItems(List<Item> relevantItems, List<user> users)
        {
            foreach (var item in relevantItems)
            {
                //Usuario Saturado
                var user = users
                    .Where(u => u.PendingItemsCount < 3 && u.PriorityItemsCount < 3)
                    .FirstOrDefault();

                // Aumentar el conteo de ítems relevantes
                if (user != null)
                {

                    if (user.Items != item)
                        item.AssignedUser = user.Username;
                        user.PriorityItemsCount++;
                        user.Items.Add(item);
                        db.SaveChanges();
                }
            }
        }

        // Asignar ítems de baja relevancia
        private void AssignLowRelevanceItems(List<Item> lowRelevanceItems, List<user> users)
        {
            foreach (var item in lowRelevanceItems)
            {
                // Usuario con menos de 3 ítems pendientes
                var user = users
                    .Where(u => u.PendingItemsCount < 3)
                    .OrderBy(u => u.PendingItemsCount)
                    .FirstOrDefault();

                if (user != null)
                {
                    if (user.Items != item)
                    item.AssignedUser = user.Username;
                    user.PendingItemsCount++;
                }
            }
        }
    }


}