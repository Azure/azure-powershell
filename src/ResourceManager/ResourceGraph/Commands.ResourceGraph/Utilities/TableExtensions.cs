namespace Microsoft.Azure.Commands.ResourceGraph.Utilities
{
    using System.Collections.Generic;
    using System.Management.Automation;

    using Microsoft.Azure.Management.ResourceGraph.Models;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// TableExtensions
    /// </summary>
    public static class TableExtensions
    {
        /// <summary>
        /// The PS Object type
        /// </summary>
        private static readonly string PsCustomObjectType =
            typeof(PSCustomObject).FullName + "#QueryResponse";

        /// <summary>
        /// Converts table to the PS Objects.
        /// </summary>
        /// <param name="table">The table.</param>
        /// <returns></returns>
        public static IEnumerable<PSObject> ToPsObjects(this Table table)
        {
            foreach (var row in table.Rows)
            {
                var rowObject = new PSObject();
                rowObject.TypeNames.Add(PsCustomObjectType);
                for (var columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
                {
                    var value = row[columnIndex];
                    var normalizedValue =
                        (value as JObject)?.ToPsObject() ?? value;
                    
                    rowObject.Properties.Add(new PSNoteProperty(
                        name: table.Columns[columnIndex].Name,
                        value: normalizedValue));
                }

                yield return rowObject;
            }
        }
    }
}
