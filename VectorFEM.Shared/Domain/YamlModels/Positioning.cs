﻿using VectorFEM.Shared.Domain.MathModels;
using YamlDotNet.Serialization;

namespace VectorFEM.Shared.Domain.YamlModels;

public record Positioning
{
    public Point3D Coordinate { get; init; }
    
    [YamlMember(Alias = "bounds_distance", ApplyNamingConventions = false)]
    public Step BoundsDistance { get; init; }
}