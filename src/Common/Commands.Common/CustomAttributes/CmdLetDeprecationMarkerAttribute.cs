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
    public class CmdLetDeprecationMarkerAttribute : BreakingChangeBaseAttribute
    {
        public String DeprecatedCmdLetName { get; }

        public String ReplacementCmdletName { get; }

        public CmdLetDeprecationMarkerAttribute(String deprecatedCmdletName, String replacementCmdletName) :
            base("The cmdlet '" + replacementCmdletName + "' is replacing the cmdlet '" + deprecatedCmdletName + "'")
        {
            this.DeprecatedCmdLetName = deprecatedCmdletName;
            this.ReplacementCmdletName = replacementCmdletName;
        }

        public CmdLetDeprecationMarkerAttribute(String deprecatedCmdletName, String replacementCmdletName, String deprecateByVersione) :
             base("The cmdlet '" + replacementCmdletName + "' is replacing the cmdlet '" + deprecatedCmdletName + "'", deprecateByVersione)
        {
            this.DeprecatedCmdLetName = deprecatedCmdletName;
            this.ReplacementCmdletName = replacementCmdletName;
        }

        public CmdLetDeprecationMarkerAttribute(String deprecatedCmdletName, String replacementCmdletName, String deprecateByVersion, String changeInEfectByDate) :
             base("The cmdlet '" + replacementCmdletName + "' is replacing the cmdlet '" + deprecatedCmdletName + "'", deprecateByVersion, changeInEfectByDate)
        {
            this.DeprecatedCmdLetName = deprecatedCmdletName;
            this.ReplacementCmdletName = replacementCmdletName;
        }
    }
}
