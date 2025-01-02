using System;
using System.IO;

namespace AzDev.Models {
    internal static class Constants
    {
        public const string DevContextFileName = "DevContext.json";
        public static string DevContextFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AzPSDev", DevContextFileName);
    }
}
