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

using Microsoft.WindowsAzure.Commands.Common.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.Common.CustomAttributes
{
    [AttributeUsage(
     AttributeTargets.Property |
     AttributeTargets.Field,
     AllowMultiple = true)]
    public class CmdletParameterBreakingChangeAttribute : GenericBreakingChangeAttribute
    {
        public string NameOfParameterChanging { get; }

        public string ReplaceMentCmdletParameterName { get; set; } = null;

        public bool IsBecomingMandatory { get; set; } = false;

        public Type OldParamaterType { get; set; }

        public String NewParameterTypeName { get; set; }

        public CmdletParameterBreakingChangeAttribute(string nameOfParameterChanging) :
            base(string.Empty)
        {
            this.NameOfParameterChanging = nameOfParameterChanging;
        }

        public CmdletParameterBreakingChangeAttribute(string nameOfParameterChanging, string deprecateByVersion) :
             base(string.Empty, deprecateByVersion)
        {
            this.NameOfParameterChanging = nameOfParameterChanging;
        }

        public CmdletParameterBreakingChangeAttribute(string nameOfParameterChanging, string deprecateByVersion, string changeInEfectByDate) :
             base(string.Empty, deprecateByVersion, changeInEfectByDate)
        {
            this.NameOfParameterChanging = nameOfParameterChanging;
        }

        protected override string GetAttributeSpecificMessage()
        {
            StringBuilder message = new StringBuilder();
           if (!string.IsNullOrWhiteSpace(ReplaceMentCmdletParameterName))
            {
                if (IsBecomingMandatory)
                {
                    message.Append(string.Format(Resources.BreakingChangeAttributeParameterReplacedMandatory, NameOfParameterChanging, ReplaceMentCmdletParameterName));
                }
                else
                {
                    message.Append(string.Format(Resources.BreakingChangeAttributeParameterReplaced, NameOfParameterChanging, ReplaceMentCmdletParameterName));
                }
            } else
            {
                if (IsBecomingMandatory)
                {
                    message.Append(string.Format(Resources.BreakingChangeAttributeParameterMandatoryNow, NameOfParameterChanging));
                } else
                {
                    message.Append(string.Format(Resources.BreakingChangeAttributeParameterChanging, NameOfParameterChanging));
                }
            }

           //See if the type of the param is changing
            if (OldParamaterType != null && !string.IsNullOrWhiteSpace(NewParameterTypeName))
            {
                message.Append("\n" + string.Format(Resources.BreakingChangeAttributeParameterTypeChange, OldParamaterType.FullName, NewParameterTypeName));
            }
            return message.ToString();
        }

        /// <summary>
        /// See if the bound parameters contain the current parameter, if they do
        /// then the attribbute is applicable
        /// If the invocationInfo is null we return true
        /// </summary>
        /// <param name="invocation"></param>
        /// <returns>bool</returns>
        public override bool IsApplicableToInvocation(InvocationInfo invocationInfo)
        {
            bool? applicable = invocationInfo == null ? true : invocationInfo.BoundParameters?.Keys?.Contains(this.NameOfParameterChanging);
            return applicable.HasValue ? applicable.Value : false;
        }
    }
}
