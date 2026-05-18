using System.ComponentModel.DataAnnotations;

namespace Todo_Managment_System.DTOs
{
    public class TodoItemUpdateDto
    {
        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string? Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
