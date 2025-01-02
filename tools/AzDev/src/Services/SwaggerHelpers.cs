using System.Diagnostics;
using AzDev.Models.Inventory;

namespace AzDev.Services
{
    internal static class SwaggerHelpers
    {
        public static void OpenOnline(this SwaggerReference swagger)
        {
            Process.Start(new ProcessStartInfo(swagger.Uri) { UseShellExecute = true });
        }
    }
}
