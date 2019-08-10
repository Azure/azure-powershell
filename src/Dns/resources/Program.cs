using System;
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
            Console.WriteLine(thing.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault()?.Name);
        }
    }
}
