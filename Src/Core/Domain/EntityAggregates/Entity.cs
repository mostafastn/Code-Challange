﻿namespace Domain.EntityAggregates
{
    public class Entity
    {
        public int Id { get; set; }
        public required string TableName { get; set; }
    }
}
