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
using System.Reflection;
using System.Text;
using System.Xml;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    public static class CustomPrinter
    {
        /// <summary>
        /// Customized printing for the result of the powershell commands. It opens all the nested properties and collection elements.
        /// </summary>
        /// <param name="obj">The object</param>
        public static string Print(object obj)
        {
            StringBuilder sb = new StringBuilder();
            Print(obj, "", "", sb);

            return sb.ToString();
        }

        private static void Print(object obj, string name, string currentIndent, StringBuilder sb)
        {
            string propName;
            //Builds the property name
            if (!string.IsNullOrWhiteSpace(name))
            {
                propName = currentIndent + name;
            }
            else
            {
                propName = "";
            }

            //Check for null
            if (obj == null)
            {
                sb.Append(propName);
                sb.AppendLine(" :");
                return;
            }

            //Handles the basic types
            if (obj is TimeSpan)
            {
                TimeSpan objAsTimeSpan = (TimeSpan)obj;
                sb.Append(currentIndent);
                sb.Append(name);
                sb.Append(" : ");
                sb.AppendLine(XmlConvert.ToString(objAsTimeSpan));
                return;
            }
            else if (obj is System.String || obj is System.ValueType)
            {
                sb.Append(currentIndent);
                sb.Append(name);
                sb.Append(" : ");
                sb.AppendLine(obj.ToString());
                return;
            }

            string nextIndent = currentIndent + "    ";

            ICollection objAsCollection = obj as ICollection;

            propName = propName.Replace(':', ' ');
            if (!string.IsNullOrWhiteSpace(propName))
            {
                sb.AppendLine(propName);
            }

            if (objAsCollection != null)
            {
                foreach (object item in objAsCollection)
                {
                    Print(item, "", nextIndent, sb);
                }

                return;
            }

            Type type = obj.GetType();
            PropertyInfo[] properties = type.GetProperties();

            int size = properties.Max(x => x.Name.Length);

            foreach (PropertyInfo property in properties)
            {
                StringBuilder normalizedName = new StringBuilder(property.Name);
                normalizedName.AppendRepeated(' ', size - property.Name.Length);
                Print(property.GetValue(obj), normalizedName.ToString(), currentIndent, sb);
            }

            sb.AppendLine();
        }

        public static void AppendRepeated(this StringBuilder sb, char c, int count)
        {
            for (int i = 0; i < count; i++)
            {
                sb.Append(c);
            }
        }
    }
}
