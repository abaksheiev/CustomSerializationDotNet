using System;
using System.Text.Json;

class Program
{
    static void Main()
    {
        var money = new Money(100, "USD");

        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        options.Converters.Add(new MoneyJsonConverter());

        // Serialization
        var json = JsonSerializer.Serialize(money, options);
        Console.WriteLine("Serialized JSON:");
        Console.WriteLine(json);

        // Deserialization
        var input = "\"250 EUR\"";
        var deserialized = JsonSerializer.Deserialize<Money>(input, options);
        Console.WriteLine("Deserialized object:");
        Console.WriteLine(deserialized);
    }
}
