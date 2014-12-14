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

using System;
using System.Collections;
using System.Linq;
using System.Text;
using Microsoft.WindowsAzure.Commands.Common.Models;

namespace Microsoft.WindowsAzure.Commands.Utilities.Common
{
    public static class ResourcesExtensions
    {
        public const string ExecludedTagPrefix = "hidden-related:/";

        public static string ConstructTagsTable(Hashtable[] tags)
        {
            if (tags == null)
            {
                return null;
            }

            Hashtable emptyHashtable = new Hashtable
                {
                    {"Name", string.Empty},
                    {"Value", string.Empty}
                };
            StringBuilder resourcesTable = new StringBuilder();

            if (tags.Length > 0)
            {
                int maxNameLength = Math.Max("Name".Length, tags.Where(ht => ht.ContainsKey("Name")).DefaultIfEmpty(emptyHashtable).Max(ht => ht["Name"].ToString().Length));
                int maxValueLength = Math.Max("Value".Length, tags.Where(ht => ht.ContainsKey("Value")).DefaultIfEmpty(emptyHashtable).Max(ht => ht["Value"].ToString().Length));

                string rowFormat = "{0, -" + maxNameLength + "}  {1, -" + maxValueLength + "}\r\n";
                resourcesTable.AppendLine();
                resourcesTable.AppendFormat(rowFormat, "Name", "Value");
                resourcesTable.AppendFormat(rowFormat,
                    GeneralUtilities.GenerateSeparator(maxNameLength, "="),
                    GeneralUtilities.GenerateSeparator(maxValueLength, "="));

                foreach (Hashtable tag in tags)
                {
                    PSTagValuePair tagValuePair = TagsConversionHelper.Create(tag);
                    if (tagValuePair != null)
                    {
                        if (tagValuePair.Name.StartsWith(ExecludedTagPrefix))
                        {
                            continue;
                        }

                        if (tagValuePair.Value == null)
                        {
                            tagValuePair.Value = string.Empty;
                        }
                        resourcesTable.AppendFormat(rowFormat, tagValuePair.Name, tagValuePair.Value);
                    }
                }
            }

            return resourcesTable.ToString();
        }
    }
}