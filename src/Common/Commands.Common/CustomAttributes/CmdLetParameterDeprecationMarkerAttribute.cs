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
    public class CmdLetParameterDeprecationMarkerAttribute : BreakingChangeBaseAttribute
    {
        public String CmdletName { get; }
        public String DeprecatedCmdLetParameterName { get; }

        public String ReplaceMentCmdletParameterName { get; }

        public CmdLetParameterDeprecationMarkerAttribute(String cmdlet, String deprecatedCmdletParameterName, String replacementCmdletParameterName) :
            base("The parameter '" + replacementCmdletParameterName + "' is replacing '" + deprecatedCmdletParameterName + "' in cmdlet '" + cmdlet + "'")
        {
            this.DeprecatedCmdLetParameterName = deprecatedCmdletParameterName;
            this.ReplaceMentCmdletParameterName = replacementCmdletParameterName;
        }

        public CmdLetParameterDeprecationMarkerAttribute(String cmdlet, String deprecatedCmdletParameterName, String replacementCmdletParameterName, String deprecateByVersion) :
             base("The parameter '" + replacementCmdletParameterName + "' is replacing '" + deprecatedCmdletParameterName + "' in cmdlet '" + cmdlet + "'", deprecateByVersion)
        {
            this.DeprecatedCmdLetParameterName = deprecatedCmdletParameterName;
            this.ReplaceMentCmdletParameterName = replacementCmdletParameterName;
        }

        public CmdLetParameterDeprecationMarkerAttribute(String cmdlet, String deprecatedCmdletParameterName, String replacementCmdletParameterName, String deprecateByVersion, String changeInEfectByDate) :
             base("The parameter '" + replacementCmdletParameterName + "' is replacing '" + deprecatedCmdletParameterName + "' in cmdlet '" + cmdlet + "'", deprecateByVersion, changeInEfectByDate)
        {
            this.DeprecatedCmdLetParameterName = deprecatedCmdletParameterName;
            this.ReplaceMentCmdletParameterName = replacementCmdletParameterName;
        }
    }
}
