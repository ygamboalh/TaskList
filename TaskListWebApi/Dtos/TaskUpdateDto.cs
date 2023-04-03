namespace TaskListWebApi.Dtos
{
    public class TaskUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
