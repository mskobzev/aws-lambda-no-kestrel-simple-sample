using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.SystemTextJson;
using no_kestrel_lambda_spike.Repositories.Abstract;
[assembly: LambdaSerializer(typeof(DefaultLambdaJsonSerializer))]

namespace no_kestrel_lambda_spike;

public class AnimalsFunctions
{
    private readonly IAnimalsRepository _repository;

    public AnimalsFunctions(IAnimalsRepository repository)
    {
        _repository = repository;
    }
    
    [LambdaFunction]
    [HttpApi(LambdaHttpMethod.Post, "/add")]
    public async Task<string> Add([FromBody] Animal animal)
    {
        var id = await _repository.AddAsync(animal);
        
        return id;
    }    
    
    [LambdaFunction]
    [HttpApi(LambdaHttpMethod.Post, "/get/{id}")]
    public async Task<IHttpResult> Get(string id, [FromServices] IAnimalsRepository repository)
    {
        var animal = await repository.GetAsync(id);

        if (animal == null)
            return HttpResults.NotFound(id);
        
        return HttpResults.Ok(animal);
    }
}