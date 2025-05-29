using System.Text.Json;

//public class Rootobject
//{
//    public Class1[] Property1 { get; set; }
//}

public class Pilot
{
    public int id { get; set; }
    public string name { get; set; }
    public string gender { get; set; }
    public string birthdate { get; set; }
    public string nation { get; set; }
    public string first_name
    {
        get
        {
            return this.name.Split(' ')[0];
        }
    }

    public string last_name
    {
        get
        {
            return this.name.Split(' ')[1];
        }
    }
    public static List<Pilot>? LoadFromJSON(string _fileName) => JsonSerializer.Deserialize<List<Pilot>>(File.ReadAllText(_fileName));
}