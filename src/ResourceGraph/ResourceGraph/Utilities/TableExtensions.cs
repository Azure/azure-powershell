// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.ResourceGraph.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;

    using Microsoft.Azure.Management.ResourceGraph.Models;
    using Microsoft.WindowsAzure.Commands.Utilities.Common;
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
        /// Converts object to the PS Objects.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static IList<PSObject> ToPsObjects(this object data)
        {
            try
            {
                if (data is JArray array)
                {
                    return ToPsObjects(array.ToList());
                }

                throw new ArgumentOutOfRangeException("Result format is not supported");
            }
            catch (Exception ex)
            {
                throw new ArgumentOutOfRangeException(ex.Message);
            }
        }

        #region Helpers

        /// <summary>
        /// Converts List to the PS Objects.
        /// </summary>
        /// <param name="rows">The table.</param>
        /// <returns></returns>
        private static IList<PSObject> ToPsObjects(this IList<JToken> rows)
        {
            var result = new List<PSObject>(rows.Count);
            foreach (var jtoken in rows)
            {
                var rowObject = new PSObject();
                rowObject.TypeNames.Add(PsCustomObjectType);

                var row = jtoken.ToObject<Dictionary<string, object>>();
                row.Keys
                    .ForEach(key => rowObject.Properties.Add(
                        new PSNoteProperty(name: key, value: (row[key] as JObject)?.ToPsObject() ?? row[key])));

               var idColumnKey = row.Keys
                    .FirstOrDefault(key => string.Equals(key, IdColumnName, StringComparison.OrdinalIgnoreCase));

                if (idColumnKey != null)
                {
                    // Best effort on resource id piping
                    rowObject.Properties.Add(new PSNoteProperty(
                        name: ResourceIdColumnName,
                        value: row[idColumnKey]));
                }

                result.Add(rowObject);
            }

            return result;
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

        #endregion
    }
}