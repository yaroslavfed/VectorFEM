﻿using VectorFEM.Core.Enums;
using VectorFEM.Shared.Domain.MathModels;

namespace VectorFEM.Core.Extensions;

public static class MathExtensions
{
    public static Matrix Transpose(this Matrix matrix) =>
        new()
        {
            Data = matrix.Data.Select(inner => inner.Select((s, i) => new { s, i }))
                .SelectMany(a => a.ToList())
                .GroupBy(a => a.i, a => a.s)
                .Select(a => a.ToList()).ToList()
        };

    public static IReadOnlyList<IReadOnlyList<TData>> ArrayToList<TData>(this TData[,] array)
    {
        var result = new List<List<TData>>();
        for (var i = 0; i < Math.Sqrt(array.Length); i++)
        {
            var line = new List<TData>();
            for (var j = 0; j < Math.Sqrt(array.Length); j++)
            {
                line.Add(array[i, j]);
            }

            result.Add(line);
        }

        return result;
    }

    public static TResult GetBoundsPoint<TSource, TResult>(
        this IEnumerable<TSource> elements,
        Func<TSource, TResult> selector,
        EPosition position
    )
    {
        var coordinates = elements.Select(selector).ToList();
        coordinates.Sort();

        return position switch
        {
            EPosition.First => coordinates.First(),
            EPosition.Last => coordinates.Last(),
            _ => throw new ArgumentOutOfRangeException(nameof(position), position, null)
        };
    }
}