using no_kestrel_lambda_spike.Repositories.Abstract;

namespace no_kestrel_lambda_spike;

public class AnimalsInMemoryRepository: IAnimalsRepository
{
    private readonly Dictionary<string, Animal> _db = new();

    public Task<string> AddAsync(Animal animal)
    {
        var id = new Guid().ToString();
        _db.Add(id, animal);
        return Task.FromResult(id);
    }

    public Task<Animal> GetAsync(string id)
    {
        if (_db.TryGetValue(id, out var value))
            return Task.FromResult(value);
        
        return null;
    }
}