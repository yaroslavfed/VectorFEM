﻿using VectorFEM.Core.Enums;
using VectorFEM.Shared.Domain;
using VectorFEM.Shared.Domain.MathModels;

namespace VectorFEM.Core.Services;

public interface IGlobalMatrixServices
{
    Matrix GetGlobalMatrix(double mu, double gamma, FiniteElement element, EFemType femType);
}