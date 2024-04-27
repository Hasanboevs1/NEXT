using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NEXT.Data.IRepositories;
using NEXT.Domain.Entities;
using NEXT.Service.DTOs.Posts;
using NEXT.Service.Exceptions;
using NEXT.Service.IServices;

namespace NEXT.Service.Services;

public class PostService : IPostService
{
    private readonly IPostRepository<Post> _repository;
    private readonly IMapper mapper;
    public PostService(IPostRepository<Post> repository, IMapper _mapper)
    {
        _repository = repository;
        mapper = _mapper;
    }

    public async Task<PostForResultDto> CreateAsync(PostForCreationDto dto)
    {
        var post = await _repository.GetAllAsync()
            .FirstOrDefaultAsync(x => x.Title.ToLower() == dto.Title.ToLower());
        if (post is not null)
            throw new CustomException(409, "Post is aldear created");
        
        var mappedPost = mapper.Map<Post>(dto);
        mappedPost.CreatedAt = DateTime.UtcNow;

        var result = await _repository.AddAsync(mappedPost);
        return mapper.Map<PostForResultDto>(result);
    }

    public async Task<IEnumerable<PostForResultDto>> GetAllAsync()
    {
        var posts = await _repository.GetAllAsync().ToListAsync();

        return mapper.Map<IEnumerable<PostForResultDto>>(posts);
    }

    public async Task<PostForResultDto> GetByIdAsync(long id)
    {
        var post = await _repository.GetByIdAsync(id);
        if (post is null)
            throw new CustomException(404, "Post has not been created");

        return mapper.Map<PostForResultDto>(post);
    }

    public async Task<bool> RemoveAsync(long id)
    {
        var post = await _repository.GetByIdAsync(id);
        if (post is null)
            throw new CustomException(404, "Post has not been created");

        await _repository.DeleteAsync(id);
        return true;
    }

    public async Task<PostForResultDto> UpdateAsync(PostForUpdateDto dto)
    {
        var post = await _repository.GetByIdAsync(dto.Id);
        if (post is null)
            throw new CustomException(404, "Post not found");

        var mappedPost = mapper.Map<Post>(post);
        mappedPost.UpdatedAt = DateTime.UtcNow;

        var result = await _repository.UpdateAsync(mappedPost);
        return mapper.Map<PostForResultDto>(result);

    }
}
