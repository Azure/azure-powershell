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

        public CmdletParameterBreakingChangeAttribute(string nameOfParameterChanging) :
            base("")
        {
            this.NameOfParameterChanging = nameOfParameterChanging;
        }

        public CmdletParameterBreakingChangeAttribute(string nameOfParameterChanging, string deprecateByVersion) :
             base("", deprecateByVersion)
        {
            this.NameOfParameterChanging = nameOfParameterChanging;
        }

        public CmdletParameterBreakingChangeAttribute(string nameOfParameterChanging, string deprecateByVersion, string changeInEfectByDate) :
             base("", deprecateByVersion, changeInEfectByDate)
        {
            this.NameOfParameterChanging = nameOfParameterChanging;
        }

        protected override string GetAttributeSpecificMessage()
        {
           if (!string.IsNullOrWhiteSpace(ReplaceMentCmdletParameterName))
            {
                if (IsBecomingMandatory)
                {
                    return string.Format(Resources.BreakingChangeAttributeParameterReplacedMandatory, NameOfParameterChanging, ReplaceMentCmdletParameterName);
                }
                else
                {
                    return string.Format(Resources.BreakingChangeAttributeParameterReplaced, NameOfParameterChanging, ReplaceMentCmdletParameterName);
                }
            } else
            {
                if (IsBecomingMandatory)
                {
                    return string.Format(Resources.BreakingChangeAttributeParameterMandatoryNow, NameOfParameterChanging);
                } else
                {
                    return string.Format(Resources.BreakingChangeAttributeParameterDeprecation, NameOfParameterChanging);
                }
            }

        }
    }
}
