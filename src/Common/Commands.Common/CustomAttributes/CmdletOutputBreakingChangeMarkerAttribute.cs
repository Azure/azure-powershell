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
AttributeTargets.Class,
AllowMultiple = true)]
    public class CmdletOutputBreakingChangeMarkerAttribute : GenericBreakingChangeAttribute
    {
        public String DeprecatedCmdLetOutputTypeName { get; }

        public String ReplacementCmdletOutputTypeName { get; set; }

        public String[] DeprecatedOutputProperties { get; set; }

        public String[] NewOutputProperties { get; set; }

        public CmdletOutputBreakingChangeMarkerAttribute(String deprecatedCmdletOutputTypeName) :
            base("")
        {
            this.DeprecatedCmdLetOutputTypeName = deprecatedCmdletOutputTypeName;
        }

        public CmdletOutputBreakingChangeMarkerAttribute(String deprecatedCmdletOutputTypeName, String deprecateByVersion) :
             base("", deprecateByVersion)
        {
            this.DeprecatedCmdLetOutputTypeName = deprecatedCmdletOutputTypeName;
        }

        public CmdletOutputBreakingChangeMarkerAttribute(String deprecatedCmdletOutputTypeName, String deprecateByVersion, String changeInEfectByDate) :
             base("", deprecateByVersion, changeInEfectByDate)
        {
            this.DeprecatedCmdLetOutputTypeName = deprecatedCmdletOutputTypeName;
        }

        protected override String getAttributeSpecificMessage()
        {
            string message = null;

            if (!String.IsNullOrWhiteSpace(ReplacementCmdletOutputTypeName))
            {
                message = String.Format("The output type is changing from the existing type :'{0}' to the new type :'{1}'", DeprecatedCmdLetOutputTypeName, ReplacementCmdletOutputTypeName);
            } else
            {
                message = String.Format("The output type '{0}' is changing", DeprecatedCmdLetOutputTypeName);
            }

            if (DeprecatedOutputProperties != null && DeprecatedOutputProperties.Length > 0)
            {
                message += "\n - The following properties in the output type are being deprecated :\n\t";
                foreach (String propety in DeprecatedOutputProperties)
                {
                    message += "'" + propety + "' ";
                }
            }

            if (NewOutputProperties != null && NewOutputProperties.Length > 0)
            {
                message += "\n - The following properties are being added to the output type :\n\t";
                foreach (String propety in NewOutputProperties)
                {
                    message += "'" + propety + "' ";
                }
            }
            return message;
        }
    }
}
