﻿using examen_final.Domain.Ports;
using examen_final.Infrastructure.PostgreSql.Adapters;
using examen_final.Infrastructure.PostgreSql.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace examen_final.Infrastructure.PostgreSql.Extensions;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructurePostgreSql( this IServiceCollection services, IConfiguration configuration ) {

        string connectionString = configuration.GetConnectionString( "ConnectionString" )
            ?? throw new ArgumentNullException( nameof( configuration ) );

        services.AddDbContext<ApplicationDbContext>( options => {
            options
                .UseNpgsql( connectionString );
            //.UseSnakeCaseNamingConvention();
            options.EnableSensitiveDataLogging();
        } );
        services.AddScoped<IJsonConfiguration, JsonConfiguration>();
        services.AddTransient<IDbConnection>( privider => new NpgsqlConnection( connectionString ) );
        services.AddScoped<IUnitOfWork, UnitOfWorkService>();
        services.AddScoped<IQueryWrapper, DapperWrapper>();
        services.AddScoped<IAuditContex, AuditContexService>();
        services.AddScoped( typeof( IAsyncRepository<> ), typeof( RepositoryBaseService<> ) );
        return services;
    }
}