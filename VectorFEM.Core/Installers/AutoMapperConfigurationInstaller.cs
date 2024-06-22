﻿using System.Reflection;
using Autofac;
using AutoMapper;
using VectorFEM.Core.Profiles;

namespace VectorFEM.Core.Installers;

public static class AutoMapperConfigurationInstaller
{
    public static void RegisterAutoMapperConfiguration(this ContainerBuilder builder)
    {
        builder.Register(_ => new MapperConfiguration(ConfigureMapper)).AsSelf().SingleInstance();
    }

    private static void ConfigureMapper(IMapperConfigurationExpression configuration)
    {
        configuration.AddMaps(Assembly.GetAssembly(typeof(CommonProfile)));
    }
}