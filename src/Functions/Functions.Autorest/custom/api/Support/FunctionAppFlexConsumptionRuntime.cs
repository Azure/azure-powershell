using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Functions.Models
{
    /// <summary>
    /// Represents a Flex Consumption Function App runtime entry (language/runtime version metadata).
    /// </summary>
    public class FunctionAppFlexConsumptionRuntime
    {
        /// <summary>Runtime name (e.g. DotNet-Isolated, Node, Python).</summary>
        public string Name { get; set; }

        /// <summary>Normalized runtime version (e.g. 8, 4, 3.11, etc.).</summary>
        public string Version { get; set; }

        /// <summary>True if this version is the platform’s designated default.</summary>
        public bool IsDefault { get; set; }

        /// <summary>End-of-life date if published; null if none.</summary>
        public DateTime? EndOfLifeDate { get; set; }

        /// <summary>
        /// Raw SKU payload from the Flex Consumption stack API (shape may vary).
        /// Left as object to avoid churn; cast at call site if a stable contract emerges.
        /// </summary>
        public object Sku { get; set; }

        public override string ToString()
        {
            var namePart = string.IsNullOrEmpty(Name) ? "<runtime>" : Name;
            var versionPart = string.IsNullOrEmpty(Version) ? "<version>" : Version;
            return $"{namePart} ({versionPart})";
        }
    }
}
