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
    public class CmdletParameterBreakingChangeMarkerAttribute : GenericBreakingChangeAttribute
    {
        public String NameOfParameterChanging { get; }

        public String ReplaceMentCmdletParameterName { get; set; } = null;

        public bool IsBecomingMandatory { get; set; } = false;

        public CmdletParameterBreakingChangeMarkerAttribute(String nameOfParameterChanging) :
            base("")
        {
            this.NameOfParameterChanging = nameOfParameterChanging;
        }

        public CmdletParameterBreakingChangeMarkerAttribute(String nameOfParameterChanging, String deprecateByVersion) :
             base("", deprecateByVersion)
        {
            this.NameOfParameterChanging = nameOfParameterChanging;
        }

        public CmdletParameterBreakingChangeMarkerAttribute(String nameOfParameterChanging, String deprecateByVersion, String changeInEfectByDate) :
             base("", deprecateByVersion, changeInEfectByDate)
        {
            this.NameOfParameterChanging = nameOfParameterChanging;
        }

        protected override String getAttributeSpecificMessage()
        {
            string message = "The parameter : '" + NameOfParameterChanging + "' is";

            if (!String.IsNullOrWhiteSpace(ReplaceMentCmdletParameterName))
            {
                message += " being replaced by";
                if (IsBecomingMandatory)
                {
                    message += " mandatory";
                }

                message += " parameter : '" + ReplaceMentCmdletParameterName + "'";
            } else
            {
                if (IsBecomingMandatory)
                {
                    message += " becoming mandatory";
                } else
                {
                    message += " changing";
                }
            }

            return message;
        }
    }
}
