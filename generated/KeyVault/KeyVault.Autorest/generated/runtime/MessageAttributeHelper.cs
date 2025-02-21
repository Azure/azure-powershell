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
namespace Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Runtime
{
    using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.generated.runtime.Properties;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    public class MessageAttributeHelper
    {
        private static readonly bool IsAzure = Convert.ToBoolean(@"true");
        public const string BREAKING_CHANGE_ATTRIBUTE_INFORMATION_LINK = "https://aka.ms/azps-changewarnings";
        public const string SUPPRESS_ERROR_OR_WARNING_MESSAGE_ENV_VARIABLE_NAME = "SuppressAzurePowerShellBreakingChangeWarnings";

        /**
         * This function takes in a CommandInfo (CmdletInfo or FunctionInfo)
         * And reads all the deprecation attributes attached to it
         * Prints a message on the cmdline For each of the attribute found
         * 
         * the boundParameterNames is a list of parameters bound to the cmdlet at runtime, 
         * We only process the Parameter beaking change attributes attached only params listed in this list (if present)
         * */
        public static void ProcessCustomAttributesAtRuntime(CommandInfo commandInfo, InvocationInfo invocationInfo, String parameterSet, System.Management.Automation.PSCmdlet psCmdlet, bool showPreviewMessage = true)
        {
            bool supressWarningOrError = false;

            try
            {
                supressWarningOrError = bool.Parse(System.Environment.GetEnvironmentVariable(SUPPRESS_ERROR_OR_WARNING_MESSAGE_ENV_VARIABLE_NAME));
            }
            catch (Exception)
            {
                //no action
            }

            if (supressWarningOrError)
            {
                //Do not process the attributes at runtime... The env variable to override the warning messages is set
                return;
            }
            if (IsAzure && invocationInfo.BoundParameters.ContainsKey("DefaultProfile"))
            {
                psCmdlet.WriteWarning("The DefaultProfile parameter is not functional. Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.");
            }

            ProcessBreakingChangeAttributesAtRuntime(commandInfo, invocationInfo, parameterSet, psCmdlet);

        }

        private static void ProcessBreakingChangeAttributesAtRuntime(CommandInfo commandInfo, InvocationInfo invocationInfo, String parameterSet, System.Management.Automation.PSCmdlet psCmdlet)
        {
            List<GenericBreakingChangeAttribute> attributes = new List<GenericBreakingChangeAttribute>(GetAllBreakingChangeAttributesInType(commandInfo, invocationInfo, parameterSet));
            StringBuilder sb = new StringBuilder();
            Action<string> appendAttributeMessage = (string s) => sb.Append(s);

            if (attributes != null && attributes.Count > 0)
            {
                appendAttributeMessage(string.Format(Resources.BreakingChangesAttributesHeaderMessage, commandInfo.Name.Split('_')[0]));

                foreach (GenericBreakingChangeAttribute attribute in attributes)
                {
                    attribute.PrintCustomAttributeInfo(appendAttributeMessage);
                }

                appendAttributeMessage(string.Format(Resources.BreakingChangesAttributesFooterMessage, BREAKING_CHANGE_ATTRIBUTE_INFORMATION_LINK));

                psCmdlet.WriteWarning(sb.ToString());
            }
        }


        public static void ProcessPreviewMessageAttributesAtRuntime(CommandInfo commandInfo, InvocationInfo invocationInfo, String parameterSet, System.Management.Automation.PSCmdlet psCmdlet)
        {
            List<PreviewMessageAttribute> previewAttributes = new List<PreviewMessageAttribute>(GetAllPreviewAttributesInType(commandInfo, invocationInfo));
            StringBuilder sb = new StringBuilder();
            Action<string> appendAttributeMessage = (string s) => sb.Append(s);

            if (previewAttributes != null && previewAttributes.Count > 0)
            {
                foreach (PreviewMessageAttribute attribute in previewAttributes)
                {
                    attribute.PrintCustomAttributeInfo(appendAttributeMessage);
                }
                psCmdlet.WriteWarning(sb.ToString());
            }
        }

        /**
         * This function takes in a CommandInfo (CmdletInfo or FunctionInfo)
         * And returns all the deprecation attributes attached to it
         * 
         * the boundParameterNames is a list of parameters bound to the cmdlet at runtime, 
         * We only process the Parameter beaking change attributes attached only params listed in this list (if present)
         **/
        private static IEnumerable<GenericBreakingChangeAttribute> GetAllBreakingChangeAttributesInType(CommandInfo commandInfo, InvocationInfo invocationInfo, String parameterSet)
        {
            List<GenericBreakingChangeAttribute> attributeList = new List<GenericBreakingChangeAttribute>();

            if (commandInfo.GetType() == typeof(CmdletInfo))
            {
                var type = ((CmdletInfo)commandInfo).ImplementingType;
                attributeList.AddRange(type.GetCustomAttributes(typeof(GenericBreakingChangeAttribute), false).Cast<GenericBreakingChangeAttribute>());

                foreach (MethodInfo m in type.GetRuntimeMethods())
                {
                    attributeList.AddRange((m.GetCustomAttributes(typeof(GenericBreakingChangeAttribute), false).Cast<GenericBreakingChangeAttribute>()));
                }

                foreach (FieldInfo f in type.GetRuntimeFields())
                {
                    attributeList.AddRange(f.GetCustomAttributes(typeof(GenericBreakingChangeAttribute), false).Cast<GenericBreakingChangeAttribute>());
                }

                foreach (PropertyInfo p in type.GetRuntimeProperties())
                {
                    attributeList.AddRange(p.GetCustomAttributes(typeof(GenericBreakingChangeAttribute), false).Cast<GenericBreakingChangeAttribute>());
                }
            }
            else if (commandInfo.GetType() == typeof(FunctionInfo))
            {
                attributeList.AddRange(((FunctionInfo)commandInfo).ScriptBlock.Attributes.Where(e => typeof(GenericBreakingChangeAttribute).IsAssignableFrom(e.GetType())).Cast<GenericBreakingChangeAttribute>());
                foreach (var parameter in ((FunctionInfo)commandInfo).Parameters)
                {
                    attributeList.AddRange(parameter.Value.Attributes.Where(e => typeof(GenericBreakingChangeAttribute).IsAssignableFrom(e.GetType())).Cast<GenericBreakingChangeAttribute>());
                }
            }
            return invocationInfo == null ? attributeList : attributeList.Where(e => e.GetType() == typeof(ParameterSetBreakingChangeAttribute) ? ((ParameterSetBreakingChangeAttribute)e).IsApplicableToInvocation(invocationInfo, parameterSet) : e.IsApplicableToInvocation(invocationInfo));
        }

        public static bool ContainsPreviewAttribute(CommandInfo commandInfo, InvocationInfo invocationInfo)
        {
            return GetAllPreviewAttributesInType(commandInfo, invocationInfo)?.Count() > 0;
        }

        private static IEnumerable<PreviewMessageAttribute> GetAllPreviewAttributesInType(CommandInfo commandInfo, InvocationInfo invocationInfo)
        {
            List<PreviewMessageAttribute> attributeList = new List<PreviewMessageAttribute>();
            if (commandInfo.GetType() == typeof(CmdletInfo))
            {
                var type = ((CmdletInfo)commandInfo).ImplementingType;
                attributeList.AddRange(type.GetCustomAttributes(typeof(PreviewMessageAttribute), false).Cast<PreviewMessageAttribute>());

                foreach (MethodInfo m in type.GetRuntimeMethods())
                {
                    attributeList.AddRange((m.GetCustomAttributes(typeof(PreviewMessageAttribute), false).Cast<PreviewMessageAttribute>()));
                }

                foreach (FieldInfo f in type.GetRuntimeFields())
                {
                    attributeList.AddRange(f.GetCustomAttributes(typeof(PreviewMessageAttribute), false).Cast<PreviewMessageAttribute>());
                }

                foreach (PropertyInfo p in type.GetRuntimeProperties())
                {
                    attributeList.AddRange(p.GetCustomAttributes(typeof(PreviewMessageAttribute), false).Cast<PreviewMessageAttribute>());
                }
            }
            else if (commandInfo.GetType() == typeof(FunctionInfo))
            {
                attributeList.AddRange(((FunctionInfo)commandInfo).ScriptBlock.Attributes.Where(e => typeof(PreviewMessageAttribute).IsAssignableFrom(e.GetType())).Cast<PreviewMessageAttribute>());
                foreach (var parameter in ((FunctionInfo)commandInfo).Parameters)
                {
                    attributeList.AddRange(parameter.Value.Attributes.Where(e => typeof(PreviewMessageAttribute).IsAssignableFrom(e.GetType())).Cast<PreviewMessageAttribute>());
                }
            }
            return invocationInfo == null ? attributeList : attributeList.Where(e => e.IsApplicableToInvocation(invocationInfo));
        }
    }
}
