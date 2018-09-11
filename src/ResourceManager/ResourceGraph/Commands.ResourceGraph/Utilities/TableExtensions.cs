namespace Microsoft.Azure.Commands.ResourceGraph.Utilities
{
    using System;
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
        /// The identifier column name
        /// </summary>
        private const string IdColumnName = "Id";

        /// <summary>
        /// The identifier column type
        /// </summary>
        private const ColumnDataType IdColumnType = ColumnDataType.String;

        /// <summary>
        /// The resource identifier column name
        /// </summary>
        private const string ResourceIdColumnName = "ResourceId";

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
            var idColumnIndex = IndexOf(table.Columns, column =>
                string.Equals(column.Name, IdColumnName, StringComparison.OrdinalIgnoreCase) &&
                column.Type == IdColumnType);

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

                if (idColumnIndex != -1)
                {
                    // Best effort on resource id piping
                    rowObject.Properties.Add(new PSNoteProperty(
                        name: ResourceIdColumnName,
                        value: row[idColumnIndex]));
                }

                yield return rowObject;
            }
        }

        /// <summary>
        /// Finds the first index of a list item satsifying the predicate.
        /// IList doesn't have a native implementation, unfortunately
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        private static int IndexOf<T>(IList<T> list, Func<T, bool> predicate)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];
                if (predicate(item))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
