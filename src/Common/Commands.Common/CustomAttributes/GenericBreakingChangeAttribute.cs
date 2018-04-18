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
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Common.CustomAttributes
{
    [AttributeUsage(
     AttributeTargets.Class |
     AttributeTargets.Field |
     AttributeTargets.Property,
     AllowMultiple = true)]

    /**
     * This class acts as the base
     **/ 
    public class GenericBreakingChangeAttribute : System.Attribute
    {
        private string _message;
        //A dexcription of what the change is about, non mandatory
        public string ChangeDescription { get; set; } = null;

        //The version the change is effective from, non mandatory
        public string DeprecateByVersion { get; }
        public bool DeprecateByVersionSet { get; } = false;

        //The date on which the change comes in effect
        public DateTime ChangeInEfectByDate { get; }
        public bool ChangeInEfectByDateSet { get; } = false;

        //Old way of calling the cmdlet
        public string OldWay { get; set; }
        //New way fo calling the cmdlet
        public string NewWay { get; set; }

        public GenericBreakingChangeAttribute(string message)
        {
            _message = message;
        }

        public GenericBreakingChangeAttribute(string message, string deprecateByVersion)
        {
            _message = message;
            this.DeprecateByVersion = deprecateByVersion;
            this.DeprecateByVersionSet = true;
        }

        public GenericBreakingChangeAttribute(string message, string deprecateByVersion, string changeInEfectByDate)
        {
            _message = message;
            this.DeprecateByVersion = deprecateByVersion;
            this.DeprecateByVersionSet = true;

            this.ChangeInEfectByDate = DateTime.Parse(changeInEfectByDate);
            this.ChangeInEfectByDateSet = true;
        }

        public DateTime getInEffectByDate()
        {
            return this.ChangeInEfectByDate.Date;
        }

        /**
         * This function returns the breaking change text for the attribute
         * If the withCmdletName is true we return the message with the cmdlet name in it otherwse not
         *
         * We get the cmdlet name from the passed in Type (it is expected to have the CMdlet attribute decorated on the class)
         */
        public string GetBreakingChangeTextFromAttribute(Type type, bool withCmdletName)
        {
            StringBuilder breakingChangeMessage = new StringBuilder();

            if (!withCmdletName)
            {
                breakingChangeMessage.Append(string.Format(Resources.BreakingChangesAttributesDeclarationMessage, GetAttributeSpecificMessage()));
            } else
            {

                breakingChangeMessage.Append(string.Format(Resources.BreakingChangesAttributesDeclarationMessageWithCmdletName, Utilities.GetNameFromCmdletType(type), GetAttributeSpecificMessage()));
            }

            if (!string.IsNullOrWhiteSpace(ChangeDescription))
            {
                breakingChangeMessage.Append(string.Format(Resources.BreakingChangesAttributesChangeDescriptionMessage, this.ChangeDescription));
            }

            if (ChangeInEfectByDateSet)
            {
                breakingChangeMessage.Append(string.Format(Resources.BreakingChangesAttributesInEffectByDateMessage, this.ChangeInEfectByDate));
            }

            if (DeprecateByVersionSet)
            {
                breakingChangeMessage.Append(string.Format(Resources.BreakingChangesAttributesInEffectByVersion, this.DeprecateByVersion));
            }

            if (!string.IsNullOrWhiteSpace(OldWay) && !string.IsNullOrWhiteSpace(NewWay))
            {
                breakingChangeMessage.Append(string.Format(Resources.BreakingChangesAttributesUsageChangeMessage, OldWay, NewWay));
            }

            return breakingChangeMessage.ToString();
        }

         /**
         * This function prints out the breaking change message for the attribute on the cmdline
         * If the "withCmdletName" is specified, the message is printed out with the cmdlet name in it
         * otherwise not
         * 
         * We get the cmdlet name from the passed in Type (it is expected to have the CMdlet attribute decorated on the class)
         * */
        public void PrintCustomAttributeInfo(Type type, bool withCmdletName, Action<string> writeOutput)
        {
            if (!withCmdletName) {
                writeOutput(string.Format(Resources.BreakingChangesAttributesDeclarationMessage, GetAttributeSpecificMessage()));
            } else
            {
                writeOutput(string.Format(Resources.BreakingChangesAttributesDeclarationMessageWithCmdletName, Utilities.GetNameFromCmdletType(type), GetAttributeSpecificMessage()));
            }

            if (!string.IsNullOrWhiteSpace(ChangeDescription))
            {
                writeOutput(string.Format(Resources.BreakingChangesAttributesChangeDescriptionMessage, this.ChangeDescription));
            }

            if (ChangeInEfectByDateSet)
            {
                writeOutput(string.Format(Resources.BreakingChangesAttributesInEffectByDateMessage, this.ChangeInEfectByDate));
            }

            if (DeprecateByVersionSet)
            {
                writeOutput(string.Format(Resources.BreakingChangesAttributesInEffectByVersion, this.DeprecateByVersion));
            }

            if (OldWay != null && NewWay != null)
            {
                writeOutput(string.Format(Resources.BreakingChangesAttributesUsageChangeMessageConsole, OldWay, NewWay));
            }
        }

        public virtual bool IsApplicableToInvocation(InvocationInfo invocation)
        {
            return true;
        }

        protected virtual string GetAttributeSpecificMessage()
        {
            return _message;
        }
    }
}
