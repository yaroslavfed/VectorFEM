﻿using VectorFEM.Data;

namespace VectorFEM.Core.Models;

public interface IBasicFunction<out TData>
{
    TData GetBasicFunctions(FiniteElement element, int? number = null, Sensor? sensor = null);
}