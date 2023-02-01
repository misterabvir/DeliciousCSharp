using System;
using System.Text.Json;
using System.Text.Encodings.Web;
namespace JSON_Working;
public class Program
{
    static void Main()
    {
        string path = "ImagineDragonsDiscography.json";

        var imagineDragons = GetInfo();
        SerializeInJsonThis(imagineDragons, path);

        var imagineDragonsDeserialize = DeserializeThat(path);
        //PrintDiscography(imagineDragonsDeserialize); 

        FormatJsonOptions(imagineDragons);
    }

    static void FormatJsonOptions(Discography data)
    {
        string result = JsonSerializer.Serialize(data, typeof(Discography));
        //Console.WriteLine(result); 
        /* OUTPUT
        {"Name":"Imagine Dragons","Albums":[{"Title":"Night Visions","Released":"2012-09-04T00:00:00","Sales":2400000},{"Title":"Smoke \u002B Mirrors","Released":"2015-02-17T00:00:00","Sales":500000},{"Title":"Evolve","Released":"2017-06-23T00:00:00","Sales":703000},{"Title":"Origins","Released":"2018-11-09T00:00:00","Sales":61000},{"Title":"Mercury","Released":"2021-09-03T00:00:00","Sales":17000}]}
        */
       
        JsonSerializerOptions options = new JsonSerializerOptions(){
            WriteIndented = true,   // spaces            
        };
        result = JsonSerializer.Serialize(data, typeof(Discography), options);
        //Console.WriteLine(result);
        /*OUTPUT    
        {
        "Name": "Imagine Dragons",
        "Albums": [
            {
            "Title": "Night Visions",
            "Released": "2012-09-04T00:00:00",
            "Sales": 2400000
            },
            {
            "Title": "Smoke \u002B Mirrors",
            "Released": "2015-02-17T00:00:00",
            "Sales": 500000
            },
            {
            "Title": "Evolve",
            "Released": "2017-06-23T00:00:00",
            "Sales": 703000
            },
            {
            "Title": "Origins",
            "Released": "2018-11-09T00:00:00",
            "Sales": 61000
            },
            {
            "Title": "Mercury",
            "Released": "2021-09-03T00:00:00",
            "Sales": 17000
            }
        ]
        }
        */           
    
        options = new JsonSerializerOptions(){
            WriteIndented = true,   // spaces            
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping, // encoding
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase //style CamelCase
        };
        result = JsonSerializer.Serialize(data, typeof(Discography), options);
        //Console.WriteLine(result);
        /*OUTPUT
        {
        "Name": "Imagine Dragons",
        "Albums": [
            {
            "Title": "Night Visions",
            "Released": "2012-09-04T00:00:00",
            "Sales": 2400000
            },
            {
            "Title": "Smoke \u002B Mirrors",
            "Released": "2015-02-17T00:00:00",
            "Sales": 500000
            },
            {
            "Title": "Evolve",
            "Released": "2017-06-23T00:00:00",
            "Sales": 703000
            },
            {
            "Title": "Origins",
            "Released": "2018-11-09T00:00:00",
            "sales": 500000
            },
            {
            "title": "Evolve",
            "released": "2017-06-23T00:00:00",
            "sales": 703000
            },
            {
            "title": "Origins",
            "released": "2018-11-09T00:00:00",
            "sales": 61000
            },
            {
            "title": "Mercury",
            "released": "2021-09-03T00:00:00",
            "sales": 17000
            }
        ]
        }
        */
    }


    static void PrintDiscography(Discography data)
    {
        if (data != null)
        {
            Console.WriteLine($"Name: {data.Name}");
            foreach (var album in data.Albums)
            {
                Console.WriteLine($"Title: {album.Title}\nDate Released: {album.Released.ToShortDateString()}\nSales in US: {album.Sales}");
            }
        /*    OUTPUT====================================
        **    Name: Imagine Dragons
        **    Title: Night Visions
        **    Date Released: 9/4/2012
        **    Sales in US: 2400000
        **    Title: Smoke + Mirrors
        **    Date Released: 2/17/2015
        **    Sales in US: 500000
        **    Title: Evolve
        **    Date Released: 6/23/2017
        **    Sales in US: 703000
        **    Title: Origins
        **    Date Released: 11/9/2018
        **    Sales in US: 61000
        **    Title: Mercury
        **    Date Released: 9/3/2021
        **    Sales in US: 17000
        **    ============================================        
        */
        }
    }

    static Discography? DeserializeThat(string path)
    {
        Discography? discography = null;
        if (File.Exists(path))
        {
            discography = JsonSerializer.Deserialize<Discography>(File.ReadAllText(path));
        }
        return discography;
    }

    static void SerializeInJsonThis(Discography data, string path)
    {
        string dataJson = JsonSerializer.Serialize(data, typeof(Discography));
        StreamWriter file = File.CreateText(path);
        file.WriteLine(dataJson);
        file.Close();
    }

    static Discography GetInfo()
    {
        return new Discography()
        {
            Name = "Imagine Dragons",
            Albums = new List<Album>(){
                new Album(){
                    Title = "Night Visions",
                    Released = new DateTime(2012, 09, 04),
                    Sales = 2_400_000
                },
                new Album(){
                    Title = "Smoke + Mirrors",
                    Released = new DateTime(2015, 02, 17),
                    Sales = 500_000
                },
                new Album(){
                    Title = "Evolve",
                    Released = new DateTime(2017, 06, 23),
                    Sales = 703_000
                },
                new Album(){
                    Title = "Origins",
                    Released = new DateTime(2018, 11, 09),
                    Sales = 61_000
                },
                new Album(){
                    Title = "Mercury",
                    Released = new DateTime(2021, 09, 03),
                    Sales = 17_000
                },
            }
        };
    }
}



public class Discography
{
    public string Name { get; set; } = "";
    public List<Album> Albums { get; set; } = new List<Album>();
}
public class Album
{
    public string Title { get; set; } = "";
    public DateTime Released { get; set; }
    public int Sales { get; set; }
}
