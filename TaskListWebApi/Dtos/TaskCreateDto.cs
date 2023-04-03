namespace TaskListWebApi.Dtos
{
    public class TaskCreateDto
    {
        public string Description { get; set; }
        public bool Status { get; set; }

        public TaskCreateDto()
        {
            Status = true;
        }
    }
}
