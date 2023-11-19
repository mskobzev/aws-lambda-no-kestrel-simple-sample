namespace no_kestrel_lambda_spike.Repositories.Abstract;

public interface IAnimalsRepository
{
    Task<string> AddAsync(Animal animal);
    Task<Animal> GetAsync(string id);
}