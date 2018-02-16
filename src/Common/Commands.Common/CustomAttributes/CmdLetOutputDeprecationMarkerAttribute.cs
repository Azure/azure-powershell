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
    public class CmdLetOutputDeprecationMarkerAttribute : BreakingChangeBaseAttribute
    {
        public String CmdletName { get; }
        public String DeprecatedCmdLetOutputTypeName { get; }

        public String ReplacementCmdletOutputTypeName { get; }

        public CmdLetOutputDeprecationMarkerAttribute(String cmdletName, String deprecatedCmdletOutputTypeName, String replacementCmdletOutputTypeName) :
            base("The cmdlet '" + cmdletName + "'s output type is changing from : '" + deprecatedCmdletOutputTypeName + "' to '" + deprecatedCmdletOutputTypeName + "'")
        {
            this.CmdletName = cmdletName;
            this.DeprecatedCmdLetOutputTypeName = deprecatedCmdletOutputTypeName;
            this.ReplacementCmdletOutputTypeName = replacementCmdletOutputTypeName;
        }

        public CmdLetOutputDeprecationMarkerAttribute(String cmdletName, String deprecatedCmdletOutputTypeName, String replacementCmdletOutputTypeName, String deprecateByVersion) :
             base("The cmdlet '" + cmdletName + "'s output type is changing from : '" + deprecatedCmdletOutputTypeName + "' to '" + deprecatedCmdletOutputTypeName + "'", deprecateByVersion)
        {
            this.CmdletName = cmdletName;
            this.DeprecatedCmdLetOutputTypeName = deprecatedCmdletOutputTypeName;
            this.ReplacementCmdletOutputTypeName = replacementCmdletOutputTypeName;
        }

        public CmdLetOutputDeprecationMarkerAttribute(String cmdletName, String deprecatedCmdletOutputTypeName, String replacementCmdletOutputTypeName, String deprecateByVersion, String changeInEfectByDate) :
             base("The cmdlet '" + cmdletName + "'s output type is changing from : '" + deprecatedCmdletOutputTypeName + "' to '" + deprecatedCmdletOutputTypeName + "'", deprecateByVersion, changeInEfectByDate)
        {
            this.CmdletName = cmdletName;
            this.DeprecatedCmdLetOutputTypeName = deprecatedCmdletOutputTypeName;
            this.ReplacementCmdletOutputTypeName = replacementCmdletOutputTypeName;
        }
    }
}
