using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Azure.PowerShell.Cmdlets.Dns.Models.Api20160401;

namespace DnsTester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var thing = new RecordSetPropertiesMetadata();
            var iExist = thing.GetType().GetProperty("Item");
            //var guy = iExist?.GetValue(thing, new object[]{ "Test"});
            var item = thing.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).First();
            //Console.WriteLine(item.GetValue(thing));

            var item2 = thing.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => !p.GetIndexParameters().Any());
            Console.WriteLine(item2.Count());
        }
    }

    public class TestType
    {
        private readonly Dictionary<string, string> _internal = new Dictionary<string, string>();
        //public string this[string index] { get => _internal[index]; set => _internal[index] = value; }
        //public string Item { get; set; }
    }
}
