using System;
using System.IO;
using System.Reflection;

namespace Microsoft.Azure.Commands.Profile.Utilities
{
    //public static class CustomAssemblyResolver
    //{
    //    public static void Initialize()
    //    {
    //        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
    //    }

    //    /// <summary>
    //    /// When the resolution of an assembly fails, if it's Newtonsoft.Json 9, redirect to 10
    //    /// </summary>
    //    public static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    //    {
    //        try
    //        {
    //            AssemblyName name = new AssemblyName(args.Name);
    //            if(string.Equals(name.Name, "Newtonsoft.Json", StringComparison.OrdinalIgnoreCase)
    //                && name.Version?.Major == 9)
    //            {
    //                string accountFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    //                string newtonsoftJsonPath = Path.Combine(accountFolder, @"PreloadAssemblies\Newtonsoft.Json.10.dll");
    //                return Assembly.LoadFrom(newtonsoftJsonPath);
    //            }
    //        }
    //        catch
    //        {
    //        }
    //        return null;
    //    }
    //}
}
