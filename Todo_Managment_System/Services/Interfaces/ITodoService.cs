using Todo_Managment_System.DTOs;

namespace Todo_Managment_System.Services.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoResponseDto>> GetAllAsync();
        Task<TodoResponseDto> GetByIdAsync(Guid id);
        Task CreateAsync(TodoItemCreateDto createDto);
        Task UpdateAsync(Guid id, TodoItemUpdateDto updateDto);
        Task DeleteAsync(Guid id);
    }
}
