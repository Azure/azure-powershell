using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
using System.Text;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions
{
    public static class DiagnosticExtensions
    {
        private static readonly IReadOnlyDictionary<string, Color> ColorsByDiagnosticLevel =
            new Dictionary<string, Color>
            {
                [Level.Error] = Color.Red,
                [Level.Warning] = Color.DarkYellow,
                [Level.Info] = Color.Reset,
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
