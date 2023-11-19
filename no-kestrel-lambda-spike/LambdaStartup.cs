using Amazon.Lambda.Annotations;
using no_kestrel_lambda_spike.Repositories.Abstract;

namespace no_kestrel_lambda_spike;

[LambdaStartup]
public class LambdaStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IAnimalsRepository, AnimalsInMemoryRepository>();
    }
}