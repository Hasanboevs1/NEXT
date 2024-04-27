using NEXT.Service.DTOs.Posts;

namespace NEXT.Service.IServices;

public interface IPostService
{
    public Task<bool> RemoveAsync(long id);
    public Task<PostForResultDto> GetByIdAsync(long id);
    public Task<IEnumerable<PostForResultDto>> GetAllAsync();
    public Task<PostForResultDto> CreateAsync(PostForCreationDto dto);
    public Task<PostForResultDto> UpdateAsync(PostForUpdateDto dto);
}
