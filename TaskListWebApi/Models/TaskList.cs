using System.ComponentModel.DataAnnotations;

namespace TaskListWebApi.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25, MinimumLength =3)]
        public string Description { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
