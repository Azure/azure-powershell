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
    public class CmdletDeprecationMarkerAttribute : BreakingChangeBaseAttribute
    {
        public String DeprecatedCmdLetName { get; }

        public String ReplacementCmdletName { get; }

        public CmdletDeprecationMarkerAttribute(String deprecatedCmdletName) :
            base(getMessage(deprecatedCmdletName, null))
        {
            this.DeprecatedCmdLetName = deprecatedCmdletName;
            this.ReplacementCmdletName = null;
        }

        public CmdletDeprecationMarkerAttribute(String deprecatedCmdletName, String replacementCmdletName) :
            base(getMessage(deprecatedCmdletName, replacementCmdletName))
        {
            this.DeprecatedCmdLetName = deprecatedCmdletName;
            this.ReplacementCmdletName = replacementCmdletName;
        }

        public CmdletDeprecationMarkerAttribute(String deprecatedCmdletName, String replacementCmdletName, String deprecateByVersione) :
             base(getMessage(deprecatedCmdletName, replacementCmdletName), deprecateByVersione)
        {
            this.DeprecatedCmdLetName = deprecatedCmdletName;
            this.ReplacementCmdletName = replacementCmdletName;
        }

        public CmdletDeprecationMarkerAttribute(String deprecatedCmdletName, String replacementCmdletName, String deprecateByVersion, String changeInEfectByDate) :
             base(getMessage(deprecatedCmdletName, replacementCmdletName), deprecateByVersion, changeInEfectByDate)
        {
            this.DeprecatedCmdLetName = deprecatedCmdletName;
            this.ReplacementCmdletName = replacementCmdletName;
        }

        private static String getMessage(String deprecatedCmdletName, String replacementCmdletName)
        {
            if (String.IsNullOrWhiteSpace(replacementCmdletName))
            {
                return "The cmdlet '" + deprecatedCmdletName + "' is being deprecated. There will be no replacement for it.";
            }
            else
            {
                return "The cmdlet '" + replacementCmdletName + "' is replacing the cmdlet '" + deprecatedCmdletName + "'";
            }
        }
    }
}
