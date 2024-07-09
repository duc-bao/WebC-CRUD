﻿namespace WebC_CRUD.Model.DTO.Request
{
    public class UpdateWalkRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
