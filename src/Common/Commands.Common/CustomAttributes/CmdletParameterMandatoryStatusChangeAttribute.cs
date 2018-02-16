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
    public class CmdletParameterMandatoryStatusChangeAttribute : BreakingChangeBaseAttribute
    {
        public String CmdletName { get; }
        public String CmdLetParameterName { get; }

        public CmdletParameterMandatoryStatusChangeAttribute(String cmdlet, String parameterName) :
            base("The parameter '" + parameterName + "' in cmdlet '" + cmdlet + "' became mandatory now")
        {
            this.CmdletName = cmdlet;
            this.CmdLetParameterName = parameterName;
        }

        public CmdletParameterMandatoryStatusChangeAttribute(String cmdlet, String parameterName, String deprecateByVersion) :
             base("The parameter '" + parameterName + "' in cmdlet '" + cmdlet + "' became mandatory now", deprecateByVersion)
        {
            this.CmdletName = cmdlet;
            this.CmdLetParameterName = parameterName;
        }

        public CmdletParameterMandatoryStatusChangeAttribute(String cmdlet, String parameterName, String deprecateByVersion, String changeInEfectByDate) :
             base("The parameter '" + parameterName + "' in cmdlet '" + cmdlet + "' became mandatory now", deprecateByVersion, changeInEfectByDate)
        {
            this.CmdletName = cmdlet;
            this.CmdLetParameterName = parameterName;
        }
    }

}
