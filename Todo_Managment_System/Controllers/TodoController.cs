using Microsoft.AspNetCore.Mvc;
using Todo_Managment_System.DTOs;
using Todo_Managment_System.Services.Interfaces;

namespace Todo_Managment_System.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var todos = await _todoService.GetAllAsync();
                if (todos == null || !todos.Any()) return NotFound();
                return Ok(todos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            try
            {
                var todo = await _todoService.GetByIdAsync(id);
                if (todo == null) return NotFound();
                return Ok(todo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TodoItemCreateDto createDto)
        {
            if (createDto == null || !ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                await _todoService.CreateAsync(createDto);
                return CreatedAtAction("Create", createDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] TodoItemUpdateDto updateDto)
        {
            if (id == Guid.Empty || updateDto == null) return BadRequest();
            try
            {
                var todo = await _todoService.GetByIdAsync(id);
                if (todo == null) return NotFound();
                await _todoService.UpdateAsync(id, updateDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            try
            {
                var todo = await _todoService.GetByIdAsync(id);
                if (todo == null) return NotFound();
                await _todoService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
