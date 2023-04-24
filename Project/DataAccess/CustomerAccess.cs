/*
This C# code defines a static class CustomerAccess, 
which provides methods for loading and writing customer data from/to a JSON file.
The code uses the System.Text.Json namespace, which is a built-in library in .NET for working with JSON.

The CustomerAccess class has a static variable named path, 
which is the full path to the JSON file that contains the customer data. The path is obtained using 
the System.IO.Path and Environment classes. The System.IO.Path.Combine method is used to combine the current 
working directory (Environment.CurrentDirectory) with a subdirectory named DataSources and a file named customers.json.

The LoadAll method reads the entire contents of the customers.json file into a 
string variable using the File.ReadAllText method. It then deserializes the JSON data into 
a list of CustomerModel objects using the JsonSerializer.Deserialize method. The method returns the list of customer objects.

The WriteAll method serializes the list of customer objects into JSON format 
using the JsonSerializer.Serialize method. The method also sets the WriteIndented property of a JsonSerializerOptions 
object to true, which formats the output JSON with indentation. The serialized JSON is written to the customers.json file 
using the File.WriteAllText method.

Overall, this code provides a simple and reusable solution for loading and writing customer data in JSON format.
*/
using System.Text.Json;

static class CustomerAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/customers.json"));

    public static List<CustomerModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<CustomerModel>>(json)!;
    }

    public static void WriteAll(List<CustomerModel> customers)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(customers, options);
        File.WriteAllText(path, json);
    }
}