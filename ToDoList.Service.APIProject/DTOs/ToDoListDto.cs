namespace ToDoList.Service.APIProject.DTOs
{
    public class ToDoListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCompelete { get; set; }
        public DateTime Date { get; set; }
    }
}
