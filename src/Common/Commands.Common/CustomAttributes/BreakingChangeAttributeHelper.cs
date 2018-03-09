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
using System.Management.Automation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Common.CustomAttributes
{
    public class BreakingChangeAttributeHelper
    {
        public const String SUPPRESS_ERROR_OR_WARNING_MESSAGE_ENV_VARIABLE_NAME = "SuppressAzurePowerShellBreakingChangeWarnings";

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

        public static void processCustomAttributesAtRuntime(Type type, List<String> boundParameterNames)
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

            List<GenericBreakingChangeAttribute> attributes = getAllBreakingChangeAttributesInType(type, boundParameterNames);

            if (attributes != null && attributes.Count > 0)
            {
                Console.WriteLine("Breaking changes in the cmdlet : " + Utilities.getNameFromCmdletType(type) + "\n");
            }

            foreach (GenericBreakingChangeAttribute attribute in attributes)
            {
                attribute.printCustomAttributeInfo(type, false);
            }
        }

        public static List<String> getBreakingChangeMessagesForType(Type type)
        {
            List<String> messages = new List<string>();

            //This is used as a migration guide, we need to process all properties/fields, moreover at this point of time we do not have a list of all the
            //bound params anyways
            foreach (GenericBreakingChangeAttribute attribute in getAllBreakingChangeAttributesInType(type, null))
            {
                messages.Add(attribute.getBreakingChangeTextFromAttribute(type, true));
            }

            return messages;
        }

        public static List<GenericBreakingChangeAttribute> getAllBreakingChangeAttributesInType(Type type, List<String> boundParameterNames)
        {
            List<GenericBreakingChangeAttribute> attributeList = new List<GenericBreakingChangeAttribute>();

            attributeList.AddRange(type.GetCustomAttributes(typeof(GenericBreakingChangeAttribute), false).Cast<GenericBreakingChangeAttribute>());

            foreach (MethodInfo m in type.GetRuntimeMethods())
            {
                attributeList.AddRange(m.GetCustomAttributes(typeof(GenericBreakingChangeAttribute), false).Cast<GenericBreakingChangeAttribute>());
            }

            //Only process the fields if the bound params have the field Name in them. If the bound params is null then
            //we do no filtering
            foreach (FieldInfo f in type.GetRuntimeFields())
            {
                if ((boundParameterNames != null && boundParameterNames.Contains(f.Name)) || (boundParameterNames == null))
                {
                    attributeList.AddRange(f.GetCustomAttributes(typeof(GenericBreakingChangeAttribute), false).Cast<GenericBreakingChangeAttribute>());
                }
            }

            //Only process the property if the bound params have the prop Name in them. If the bound params is null then
            //we do no filtering
            foreach (PropertyInfo p in type.GetRuntimeProperties())
            {
                if ((boundParameterNames != null && boundParameterNames.Contains(p.Name)) || (boundParameterNames == null))
                {
                    attributeList.AddRange(p.GetCustomAttributes(typeof(GenericBreakingChangeAttribute), false).Cast<GenericBreakingChangeAttribute>());
                }
            }

            return attributeList;
        }
    }
}
