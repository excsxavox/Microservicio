using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Interface
{
    public interface Item
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime DueDate { get; set; }
    public string Relevance { get; set; } // "Alta" o "Baja"
    public string AssignedUser  { get; set; }
    public bool IsCompleted { get; set; }
}
}