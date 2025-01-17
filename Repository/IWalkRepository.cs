﻿using WebC_CRUD.Model.DTO.Request;
using WebC_CRUD.Model.Entity;

namespace WebC_CRUD.Repository
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, 
            string? sortBy = null, bool isAccending = true, int pageNumber = 1, int pageSize = 10);
        Task<Walk?> GetWalkByIdAsync(Guid id);
        Task<Walk?> UpdateWalkAsync( Walk walk, Guid id);
        Task<Walk?> DeleteWalkByIdAsync( Guid id);
    }
}
