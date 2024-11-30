using examen_final.Api.Middlewares;
using examen_final.Application.Extensions;
using examen_final.Application.Messaging;
using examen_final.Infrastructure.Extensions;
using examen_final.Infrastructure.PostgreSql.Extensions;

WebApplicationBuilder builder = WebApplication
    .CreateBuilder( args );

builder.Services
    .AddOptions( builder.Configuration )
    .AddApplication( builder.Configuration )
    .AddDomainService()
    .AddInfrastructurePostgreSql( builder.Configuration )
    .AddInfrastructure();

builder.Services.AddTransient<IDispatch, Dispatch>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger( options => {
        options.SerializeAsV2 = true;
    } );
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
