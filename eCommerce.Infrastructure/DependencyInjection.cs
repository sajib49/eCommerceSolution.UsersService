﻿using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Infrastructure
{

    public static  class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection 
            services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
    }
}
