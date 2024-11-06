using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using UserService.Interface;

namespace UserService.App.Queries.ItemQueries
{
    public class ItemsQuery : IRequest<List<Item>>
    {
        
    }

    public class GetItemsQueryHandler : IRequestHandler<ItemsQuery, List<Item>>
{
    private readonly DbContext _context;

    public GetItemsQueryHandler(DbContext context)
    {
        _context = context;
    }

     public async Task<List<Item>> Handle(ItemsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Item.ToListAsync();
    }

    }
}