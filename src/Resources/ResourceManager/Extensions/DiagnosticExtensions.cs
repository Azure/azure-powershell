using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
using System.Text;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    public static class DiagnosticExtensions
    {
        private static readonly IReadOnlyDictionary<string, Color> ColorsByDiagnosticLevel =
            new Dictionary<string, Color>
            {
                ["Error"] = Color.Red,
                ["Warning"] = Color.DarkYellow,
                ["Info"] = Color.Reset,
            };

        public static Color ToColor(this string level)
        {
            bool success = ColorsByDiagnosticLevel.TryGetValue(level, out Color colorCode);

            if (!success)
            {
                return Color.Gray;
            }

            return colorCode;
        }
    }
}
