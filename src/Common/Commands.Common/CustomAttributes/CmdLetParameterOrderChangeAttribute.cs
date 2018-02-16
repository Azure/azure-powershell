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
    public class CmdLetParameterOrderChangeAttribute : BreakingChangeBaseAttribute
    {
        public String CmdletName { get; }
        public String ParameterSetName { get; }
        public String[] OldParameterOrder { get; }
        public String[] NewParameterOrder { get; }

        public CmdLetParameterOrderChangeAttribute(String cmdletName, String parameterSetName, String[] oldParameterOrder, String[] newParameterOrder) :
            base(getMessage(cmdletName, parameterSetName, oldParameterOrder, newParameterOrder))
        {
            this.CmdletName = cmdletName;
            this.ParameterSetName = parameterSetName;
            this.OldParameterOrder = oldParameterOrder;
            this.NewParameterOrder = newParameterOrder;
        }

        public CmdLetParameterOrderChangeAttribute(String cmdletName, String parameterSetName, String[] oldParameterOrder, String[] newParameterOrder, String deprecateByVersion) :
             base(getMessage(cmdletName, parameterSetName, oldParameterOrder, newParameterOrder), deprecateByVersion)
        {
            this.CmdletName = cmdletName;
            this.ParameterSetName = parameterSetName;
            this.OldParameterOrder = oldParameterOrder;
            this.NewParameterOrder = newParameterOrder;
        }

        public CmdLetParameterOrderChangeAttribute(String cmdletName, String parameterSetName, String[] oldParameterOrder, String[] newParameterOrder, String deprecateByVersion, String changeInEfectByDate) :
             base(getMessage(cmdletName, parameterSetName, oldParameterOrder, newParameterOrder), deprecateByVersion, changeInEfectByDate)
        {
            this.CmdletName = cmdletName;
            this.ParameterSetName = parameterSetName;
            this.OldParameterOrder = oldParameterOrder;
            this.NewParameterOrder = newParameterOrder;
        }

        private static String getMessage(String cmdletName, String parameterSetName, String[] oldParameterOrder, String[] newParameterOrder)
        {
            String message = "The position of the following positional parameters has changed in the cmdlet '" + cmdletName ;

            if (!String.IsNullOrWhiteSpace(parameterSetName))
            {
                message += "' for the parameter set '" + parameterSetName;
            }

            message += "' From :\n";

            foreach (String paramName in oldParameterOrder)
            {
                message += "'" + paramName + "' ";
            }

            message += "\nTo :\n";

            foreach (String paramName in newParameterOrder)
            {
                message += "'" + paramName + "' ";
            }

            return message;
        }
    }
}
