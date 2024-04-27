using Microsoft.AspNetCore.Mvc;
using NEXT.Api.Models;
using NEXT.Service.DTOs.Posts;
using NEXT.Service.IServices;

namespace NEXT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _service;

        public PostController(IPostService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
            => Ok( new Response
            {
                Code = 200,
                Message = "success",
                Data =  await _service.GetAllAsync()
            });

        [HttpPost("add")]
        public async Task<IActionResult> Create(PostForCreationDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "success",
                Data = await _service.CreateAsync(dto)
            });

        [HttpGet("id")]
        public async Task<IActionResult> GetById(long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "success",
                Data = await _service.GetByIdAsync(id)
            });

        [HttpPut("update")]
        public async Task<IActionResult> Update(PostForUpdateDto dto)
            => Ok(new Response
            {
                Code = 200,
                Message = "success",
                Data = await _service.UpdateAsync(dto)
            });

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(long id)
            => Ok(new Response
            {
                Code = 200,
                Message = "success",
                Data = await _service.RemoveAsync(id)
            });
    }
}
