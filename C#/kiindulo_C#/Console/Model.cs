using ;
using System.Text.Json;

public class Model
{
    // props

    public static List<>? LoadFromJSON(string _fileName) => JsonSerializer.Deserialize<List<Model>>(File.ReadAllText(_fileName));
}
