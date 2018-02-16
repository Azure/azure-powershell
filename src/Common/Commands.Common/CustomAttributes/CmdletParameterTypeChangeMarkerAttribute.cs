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
    public class CmdletParameterTypeChangeMarkerAttribute : BreakingChangeBaseAttribute
    {
        public String CmdletName { get; }
        public String ParameterName { get; }
        public String DeprecatedCmdletParameterTypeName { get; }
        public String ReplacementCmdletParameterTypeName { get; }

        public CmdletParameterTypeChangeMarkerAttribute(String cmdlet, String parameterName, String deprecatedCmdletParameterTypeName, String replacementCmdletParameterTypeName) :
            base("The parameter " + parameterName + "'s type is changing from '" + deprecatedCmdletParameterTypeName + "' to '" + replacementCmdletParameterTypeName + "' in cmdlet '" + cmdlet + "'")
        {
            this.CmdletName = cmdlet;
            this.ParameterName = parameterName;
            this.DeprecatedCmdletParameterTypeName = deprecatedCmdletParameterTypeName;
            this.ReplacementCmdletParameterTypeName = replacementCmdletParameterTypeName;
        }

        public CmdletParameterTypeChangeMarkerAttribute(String cmdlet, String parameterName, String deprecatedCmdletParameterTypeName, String replacementCmdletParameterTypeName, String deprecateByVersion) :
             base("The parameter " + parameterName + "'s type is changing from '" + deprecatedCmdletParameterTypeName + "' to '" + replacementCmdletParameterTypeName + "' in cmdlet '" + cmdlet + "'", deprecateByVersion)
        {
            this.CmdletName = cmdlet;
            this.ParameterName = parameterName;
            this.DeprecatedCmdletParameterTypeName = deprecatedCmdletParameterTypeName;
            this.ReplacementCmdletParameterTypeName = replacementCmdletParameterTypeName;
        }

        public CmdletParameterTypeChangeMarkerAttribute(String cmdlet, String parameterName, String deprecatedCmdletParameterTypeName, String replacementCmdletParameterTypeName, String deprecateByVersion, String changeInEfectByDate) :
             base("The parameter " + parameterName + "'s type is changing from '" + deprecatedCmdletParameterTypeName + "' to '" + replacementCmdletParameterTypeName + "' in cmdlet '" + cmdlet + "'", deprecateByVersion, changeInEfectByDate)
        {
            this.CmdletName = cmdlet;
            this.ParameterName = parameterName;
            this.DeprecatedCmdletParameterTypeName = deprecatedCmdletParameterTypeName;
            this.ReplacementCmdletParameterTypeName = replacementCmdletParameterTypeName;
        }
    }
}
