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
     AttributeTargets.Class,
     AllowMultiple = true)]
    public class CmdletOutputBreakingChangeAttribute : GenericBreakingChangeAttribute
    {
        public Type DeprecatedCmdLetOutputType { get; }

        //This is still a String instead of a Type as this 
        //might be undefined at the time of adding the attribute
        public string ReplacementCmdletOutputTypeName { get; set; }

        public string[] DeprecatedOutputProperties { get; set; }

        public string[] NewOutputProperties { get; set; }

        public CmdletOutputBreakingChangeAttribute(Type deprecatedCmdletOutputTypeName) :
            base(string.Empty)
        {
            this.DeprecatedCmdLetOutputType = deprecatedCmdletOutputTypeName;
        }

        public CmdletOutputBreakingChangeAttribute(Type deprecatedCmdletOutputTypeName, string deprecateByVersion) :
             base(string.Empty, deprecateByVersion)
        {
            this.DeprecatedCmdLetOutputType = deprecatedCmdletOutputTypeName;
        }

        public CmdletOutputBreakingChangeAttribute(Type deprecatedCmdletOutputTypeName, string deprecateByVersion, string changeInEfectByDate) :
             base(string.Empty, deprecateByVersion, changeInEfectByDate)
        {
            this.DeprecatedCmdLetOutputType = deprecatedCmdletOutputTypeName;
        }

        protected override string GetAttributeSpecificMessage()
        {
            StringBuilder message = new StringBuilder();

            //check for the deprecation scenario
            if (string.IsNullOrWhiteSpace(ReplacementCmdletOutputTypeName) && NewOutputProperties == null && DeprecatedOutputProperties == null && string.IsNullOrWhiteSpace(ChangeDescription))
            {
                message.Append(string.Format(Resources.BreakingChangesAttributesCmdLetOutputTypeDeprecated, DeprecatedCmdLetOutputType.FullName));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(ReplacementCmdletOutputTypeName))
                {
                    message.Append(string.Format(Resources.BreakingChangesAttributesCmdLetOutputChange1, DeprecatedCmdLetOutputType.FullName, ReplacementCmdletOutputTypeName));
                }
                else
                {
                    message.Append(string.Format(Resources.BreakingChangesAttributesCmdLetOutputChange2, DeprecatedCmdLetOutputType.FullName));
                }

                if (DeprecatedOutputProperties != null && DeprecatedOutputProperties.Length > 0)
                {
                    message.Append(Resources.BreakingChangesAttributesCmdLetOutputPropertiesRemoved);
                    foreach (string property in DeprecatedOutputProperties)
                    {
                        message.Append(" '{property}'");
                    }
                }

                if (NewOutputProperties != null && NewOutputProperties.Length > 0)
                {
                    message.Append(Resources.BreakingChangesAttributesCmdLetOutputPropertiesAdded);
                    foreach (string property in NewOutputProperties)
                    {
                        message.Append(" '{property}'");
                    }
                }
            }
            return message.ToString();
        }
    }
}
