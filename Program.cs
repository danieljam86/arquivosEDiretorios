
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json; 


var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, $"mslearn-dotnet-files{Path.DirectorySeparatorChar}stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);

var salesTotal = CalculateSalesTotal(salesFiles);

File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

IEnumerable<string> FindFiles(string folderName)
{
    List<string> salesFiles = new List<string>();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var file in foundFiles)
    {
        var extension = Path.GetExtension(file);
        if (extension == ".json")
        {
            salesFiles.Add(file);
        }
    }

    return salesFiles;
}

double CalculateSalesTotal(IEnumerable<string> salesFiles)
{
    double salesTotal = 0;
    
    // Loop over each file path in salesFiles
    foreach (var file in salesFiles)
    {      
        // Read the contents of the file
        string salesJson = File.ReadAllText(file);
    
        // Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);
    
        // Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }
    
    return salesTotal;
}

record SalesData (double Total);

// File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

// var salesJson = File.ReadAllText($"mslearn-dotnet-files{Path.DirectorySeparatorChar}stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales.json");
// var salesData = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
// Console.WriteLine($"Total sales: {salesData}");

// var data = JsonConvert.DeserializeObject<SalesTotal>(salesJson);
// // File.WriteAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", data.Total.ToString());

// File.AppendAllText($"salesTotalDir{Path.DirectorySeparatorChar}totals.txt", $"{data.Total}{Environment.NewLine}");

// class SalesTotal
// {
//   public double Total { get; set; }
// }



// var currentDirectory1 = Directory.GetCurrentDirectory();
// var storesDirectory1 = Path.Combine(currentDirectory1, "stores");

// var salesTotalDir = Path.Combine(currentDirectory1, "salesTotalDir");
// Directory.CreateDirectory(salesTotalDir); 
// var salesFiles1 = FindFiles(storesDirectory1);
// File.WriteAllText(Path.Combine(salesTotalDir, "totals.txt"), String.Empty);

// string filePath = Path.Combine(Directory.GetCurrentDirectory(), "mslearn-dotnet-files", "stores","201","newDir23");
// bool doesDirectoryExist = Directory.Exists(filePath);
// if(doesDirectoryExist)
// {
//     Console.WriteLine("Directory exists");
// }
// else
// {
//     Console.WriteLine("Directory does not exist");
//     Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "mslearn-dotnet-files", "stores","201","newDir"));
//     Console.WriteLine("Diretorio {0} {1} criado", filePath, doesDirectoryExist);
// }


// var currentDirectory = Directory.GetCurrentDirectory();
// var storesDirectory = Path.Combine(currentDirectory, "stores");
// var salesFiles = FindFiles(storesDirectory);

// foreach (var file in salesFiles)
// {
//     Console.WriteLine(file);
// }
// char separador = Path.DirectorySeparatorChar;
// Console.WriteLine(Directory.GetCurrentDirectory());
// Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
// Console.WriteLine($"stores" + separador + "201");
// Console.WriteLine($"stores{Path.DirectorySeparatorChar}201");
// Console.WriteLine(Path.Combine("stores","201"));
// Console.WriteLine(Path.GetExtension("sales.json"));

// string fileName = $"stores{Path.DirectorySeparatorChar}201{Path.DirectorySeparatorChar}sales{Path.DirectorySeparatorChar}sales.json";

// FileInfo info = new FileInfo(fileName);

// Console.WriteLine($"Full Name: {info.FullName}{Environment.NewLine}Directory: {info.Directory}{Environment.NewLine}Extension: {info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}"); // And many more

// IEnumerable<string> FindFiles(string folderName)
// {
//     List<string> salesFiles = new List<string>();

//     var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

//     foreach (var file in foundFiles)
//     {
//         // The file name will contain the full path, so only check the end of it
//         if (file.EndsWith("sales.json"))
//         {
//             salesFiles.Add(file);
//         }
//     }

//     return salesFiles;
// }
