﻿using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;

namespace MockLibrary
{
    public static class ServiceProviderExtensions
    {
        public static Mock<T> GetMock<T>(this IServiceProvider serviceProvider)
            where T : class
        {
            return Moq.Mock.Get<T>(serviceProvider.GetRequiredService<T>());
        }
    }
}
