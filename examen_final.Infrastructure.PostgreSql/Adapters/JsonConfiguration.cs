using examen_final.Domain.Ports;
using examen_final.Infrastructure.PostgreSql.Extensions;
using Newtonsoft.Json;

namespace examen_final.Infrastructure.PostgreSql.Adapters;
internal sealed class JsonConfiguration : IJsonConfiguration {
    private readonly JsonSerializerSettings _settings;
    public JsonConfiguration() {
        _settings = new JsonSerializerSettings {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            , ContractResolver = new PrivateResolver()
        };
    }
    public TEntity DeserializeObject<TEntity>( string source ) => 
        JsonConvert.DeserializeObject<TEntity>( source, _settings )!;
    public string SerializeObject<TEntity>( TEntity source ) => 
        JsonConvert.SerializeObject( source, _settings );
}
