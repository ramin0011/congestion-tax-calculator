using congestion.calculator;
using System;
using System.Linq;
using congestion.calculator.Models.Vehicles;

namespace congestion_tax_calculator_net_core_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //***** this is my own project to just test the app


            Console.WriteLine("Testing Calculator!");

            var calculator = new CongestionTaxCalculator();

            string times = """
            "2013-01-14 21:00:00"
            ,
            "2013-01-15 21:00:00"
            ,
            "2013-02-07 06:23:27"
            ,
            "2013-02-07 15:27:00"
            ,
            "2013-02-08 06:27:00"
            ,
            "2013-02-08 06:20:27"
            ,
            "2013-02-08 14:35:00"
            ,
            "2013-02-08 15:29:00"
            ,
            "2013-02-08 15:47:00"
            ,
            "2013-02-08 16:01:00"
            ,
            "2013-02-08 16:48:00"
            ,
            "2013-02-08 17:49:00"
            ,
            "2013-02-08 18:29:00"
            ,
            "2013-02-08 18:35:00"
            ,
            "2013-03-26 14:25:00"
            ,
            "2013-03-28 14:07:27"
            
            """;


            var service=new CongestionTimeService();
            service.Create("gothenberg",new TimeSpan(21,0,0), new TimeSpan(21,29,0),10);
            service.Create("gothenberg",new TimeSpan(15,0,0), new TimeSpan(15,29,0),10);
            var dates = times.Split(',').Select(a => a.Replace("\"", "")).Select(a => DateTime.Parse(a)).ToList();
           
            var result= calculator.GetTax(new Car(), dates.ToArray(), "gothenberg");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Calculated tax:{result}SEK");
        }
    }
}
