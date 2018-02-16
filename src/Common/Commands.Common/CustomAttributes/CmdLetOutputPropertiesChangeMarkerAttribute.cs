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
    public class CmdLetOutputPropertiesChangeMarkerAttribute : BreakingChangeBaseAttribute
    {
        public String CmdletName { get; }
        public String CmdletOutputTypeName { get; }
        public String[] DeprecatedOutputProperties { get; }
        public String[] NewOutputProperties { get; }

        public CmdLetOutputPropertiesChangeMarkerAttribute(String cmdletName, String outputTypeName, String[] deprecatedPropertyNames, String[] newPropertyNames) :
            base(getMessage(cmdletName, outputTypeName, deprecatedPropertyNames, newPropertyNames))
        {
            this.CmdletName = cmdletName;
            this.CmdletOutputTypeName = outputTypeName;
            this.DeprecatedOutputProperties = deprecatedPropertyNames;
            this.NewOutputProperties = newPropertyNames;
        }

        public CmdLetOutputPropertiesChangeMarkerAttribute(String cmdletName, String outputTypeName, String[] deprecatedPropertyNames, String[] newPropertyNames, String deprecateByVersion) :
             base(getMessage(cmdletName, outputTypeName, deprecatedPropertyNames, newPropertyNames), deprecateByVersion)
        {
            this.CmdletName = cmdletName;
            this.CmdletOutputTypeName = outputTypeName;
            this.DeprecatedOutputProperties = deprecatedPropertyNames;
            this.NewOutputProperties = newPropertyNames;
        }

        public CmdLetOutputPropertiesChangeMarkerAttribute(String cmdletName, String outputTypeName, String[] deprecatedPropertyNames, String[] newPropertyNames, String deprecateByVersion, String changeInEfectByDate) :
             base(getMessage(cmdletName, outputTypeName, deprecatedPropertyNames, newPropertyNames), deprecateByVersion, changeInEfectByDate)
        {
            this.CmdletName = cmdletName;
            this.CmdletOutputTypeName = outputTypeName;
            this.DeprecatedOutputProperties = deprecatedPropertyNames;
            this.NewOutputProperties = newPropertyNames;
        }

        private static String getMessage(String cmdletName, String outputTypeName, String[] deprecatedProperties, String[] newProperties)
        {
            String message = "The following properties in the output type '" + outputTypeName + "' in the cmdlet '" + cmdletName + "' are changing :\n";

            foreach(String name in deprecatedProperties)
            {
                message += "'" + name + "' "; 
            }

            if (newProperties.Length > 0)
            {
                message += "\nRespectivelly to :";
                foreach(String name in newProperties)
                {
                    message += "'" + name + "' ";
                }
            }

            return message;
        }
    }
}
