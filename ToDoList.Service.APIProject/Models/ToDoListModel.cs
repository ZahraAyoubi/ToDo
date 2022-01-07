using System.ComponentModel.DataAnnotations;

namespace ToDoList.Service.APIProject.Models
{
    public class ToDoListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompelete { get; set; }        
        public DateTime Date { get; set; }
    }
}
