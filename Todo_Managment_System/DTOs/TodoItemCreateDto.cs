using System.ComponentModel.DataAnnotations;

namespace Todo_Managment_System.DTOs
{
    public class TodoItemCreateDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string? Title { get; set; }
    }
}
