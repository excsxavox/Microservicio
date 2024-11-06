using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UserService.Interface;

namespace UserService.App.Queries.UserQueries
{
    public class GetUserItemsCompleted: IRequest<List<user>>
    {
       private readonly DbContext _context;

        public GetUserItemsCompleted(DbContext context)
        {
            _context = context;
        }

         public async Task<List<user>> Handle(GetUserItemsCompleted request, CancellationToken cancellationToken)
        {

            return await _context.user.Where(x => x.CompletedItemsCount > 0)();
        }
    }
}