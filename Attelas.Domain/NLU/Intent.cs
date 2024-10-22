namespace Attelas.Domain.NLU;

public class Intent
{
    private readonly string _name;

    private Intent(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Intent name cannot be null or empty", nameof(name));
        _name = name;
    }

    public string Name => _name;

    private static Intent Create(string name) => new Intent(name);

    public static implicit operator string(Intent intent) => intent._name;

    public static implicit operator Intent(string name) => new Intent(name);

    public override string ToString() => _name;

    public override bool Equals(object? obj) => obj is Intent intent && intent._name == _name;

    public override int GetHashCode() => _name.GetHashCode();
    
    public static Intent From(string name) => Create(name);
}