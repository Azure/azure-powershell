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

#undef DEBUG

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Common.CustomAttributes
{
    public class BreakingChangeAttributeHelper
    {
        public const String SUPPRESS_ERROR_OR_WARNING_MESSAGE_ENV_VARIABLE_NAME = "SuppressDepricationMarkerWarning";

        public const String BREAKING_CHANGE_DOCUMENTATION_HEADER = @"<!--
    Please leave this section at the top of the breaking change documentation.

    New breaking changes should go under the section titled 'Current Breaking Changes', and should adhere to the following format:
    ## Current Breaking Changes

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell
    # Old
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    ## Release X.0.0

    The following cmdlets were affected this release:

    **Cmdlet 1**
    - Description of what has changed

    ```powershell

    # Old\
    # Sample of how the cmdlet was previously called

    # New
    # Sample of how the cmdlet should now be called
    ```

    Note: the above sections follow the template found in the link below:

    https://github.com/Azure/azure-powershell/blob/dev/documentation/breaking-changes/breaking-change-template.md
    -->";

        public static void processCustomAttributesAtRuntime(Type type)
        {
            bool emitWarningOrError = true;

            try
            {
                emitWarningOrError = Boolean.Parse(System.Environment.GetEnvironmentVariable(SUPPRESS_ERROR_OR_WARNING_MESSAGE_ENV_VARIABLE_NAME));
            }
            catch (Exception)
            {
                //no action
            }

            if (!emitWarningOrError)
            {
                //Do not process the attributes at runtime... The env variable to override the warning messages is set
                return;
            }

            foreach (BreakingChangeBaseAttribute attribute in getAllBreakingChangeAttributesInType(type))
            {
                printCustomAttributeInfo(attribute);
            }
        }

        public static List<String> getBreakingChangeMessagesForType(Type type)
        {
            List<String> messages = new List<string>();

            foreach (BreakingChangeBaseAttribute attribute in getAllBreakingChangeAttributesInType(type))
            {
                messages.Add(getBreakingChangeTextFromAttribute(attribute));
            }

            return messages;
        }

        public static List<BreakingChangeBaseAttribute> getAllBreakingChangeAttributesInType(Type type)
        {
            List<BreakingChangeBaseAttribute> attributeList = new List<BreakingChangeBaseAttribute>();

            attributeList.AddRange(type.GetCustomAttributes(typeof(BreakingChangeBaseAttribute), false).Cast<BreakingChangeBaseAttribute>());

            foreach (MethodInfo m in type.GetRuntimeMethods())
            {
                attributeList.AddRange(m.GetCustomAttributes(typeof(BreakingChangeBaseAttribute), false).Cast<BreakingChangeBaseAttribute>());
            }

            foreach (FieldInfo f in type.GetRuntimeFields())
            {
                attributeList.AddRange(f.GetCustomAttributes(typeof(BreakingChangeBaseAttribute), false).Cast<BreakingChangeBaseAttribute>());
            }

            foreach (PropertyInfo p in type.GetRuntimeProperties())
            {
                attributeList.AddRange(p.GetCustomAttributes(typeof(BreakingChangeBaseAttribute), false).Cast<BreakingChangeBaseAttribute>());
            }

            return attributeList;
        }

        private static String getBreakingChangeTextFromAttribute(BreakingChangeBaseAttribute attribute)
        {
            String breakinChangeMessage = " - " + attribute.Message + "\n\n";

            if (attribute.DeprecateByVersionSet)
            {
                breakinChangeMessage += "The change is expected to take effect from the version : " + attribute.DeprecateByVersion + "\n\n";
            }

            if (!String.IsNullOrWhiteSpace(attribute.OldWay) && !String.IsNullOrWhiteSpace(attribute.NewWay))
            {
                breakinChangeMessage += "```powershell\n# Old\n" + attribute.OldWay + "\n\n# New\n" + attribute.NewWay + "\n```\n\n";
            }

            return breakinChangeMessage;
        }

        private static void printCustomAttributeInfo(BreakingChangeBaseAttribute attribute)
        {
            Console.WriteLine("Deprecation message : \n" + attribute.Message);
            if (attribute.DeprecateByVersionSet)
            {
                Console.WriteLine("The change will take effect in version : " + attribute.DeprecateByVersion);
            }

            if (attribute.OldWay != null && attribute.NewWay != null)
            {
                Console.WriteLine("Original command : " + attribute.OldWay);
                Console.WriteLine("Workaround : " + attribute.NewWay);
            }
        }
    }
}
