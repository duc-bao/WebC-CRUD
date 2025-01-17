﻿namespace WebC_CRUD.Model.DTO.Response
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthKm { get; set; }

        public string? WalkImageUrl { get; set; }
        public DifficultyDTO Difficulty { get; set; }
        public RegionDTO Region { get; set; }
    }
}
