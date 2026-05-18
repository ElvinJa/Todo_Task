using Microsoft.EntityFrameworkCore;
using Todo_Managment_System.Data;
using Todo_Managment_System.DTOs;
using Todo_Managment_System.Entities;
using Todo_Managment_System.Services.Interfaces;

namespace Todo_Managment_System.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _context;
        public TodoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(TodoItemCreateDto createDto)
        {
            await _context.AddAsync(new TodoItem
            {
                Title = createDto.Title
            });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var todoItem = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
            if (todoItem == null) throw new NullReferenceException("Todo item not found");
            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoResponseDto>> GetAllAsync()
        {
            return await _context.TodoItems.AsNoTracking().Select(x => new TodoResponseDto
            {
                Id = x.Id,
                Title = x.Title,
                IsCompleted = x.IsCompleted,
                CreatedAt = x.CreatedAt
            }).ToListAsync();
        }

        public async Task<TodoResponseDto> GetByIdAsync(Guid id)
        {
            var todoItem = await _context.TodoItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (todoItem == null) return null;
            return new TodoResponseDto
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                IsCompleted = todoItem.IsCompleted,
                CreatedAt = todoItem.CreatedAt
            };
        }

        public async Task UpdateAsync(Guid id, TodoItemUpdateDto updateDto)
        {
            var todoItem = await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
            if (todoItem == null) return;
            todoItem.Title = updateDto.Title;
            todoItem.IsCompleted = updateDto.IsCompleted;
            await _context.SaveChangesAsync();
        }
    }
}
