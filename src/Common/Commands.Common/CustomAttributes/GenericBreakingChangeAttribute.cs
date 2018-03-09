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
     */ 
    public class GenericBreakingChangeAttribute : System.Attribute
    {
        private String _message;
        //A dexcription of what the change is about, non mandatory
        public String ChangeDescription { get; set; } = null;

        //The version the change is effective from, non mandatory
        public String DeprecateByVersion { get; }
        public bool DeprecateByVersionSet { get; } = false;

        //The date on which the change comes in effect
        public DateTime ChangeInEfectByDate { get; }
        public bool ChangeInEfectByDateSet { get; } = false;

        //Old way of calling the cmdlet
        public String OldWay { get; set; }
        //New way fo calling the cmdlet
        public String NewWay { get; set; }

        public GenericBreakingChangeAttribute(String message)
        {
            _message = message;
        }

        public GenericBreakingChangeAttribute(String message, String deprecateByVersion)
        {
            _message = message;
            this.DeprecateByVersion = deprecateByVersion;
            this.DeprecateByVersionSet = true;
        }

        public GenericBreakingChangeAttribute(String message, String deprecateByVersion, String changeInEfectByDate)
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

        public String getBreakingChangeTextFromAttribute(Type type, bool withCmdletName)
        {
            String breakingChangeMessage = null;
            String attributeMessage = getAttributeSpecificMessage();

            if (!withCmdletName)
            {
                breakingChangeMessage = " - " + getAttributeSpecificMessage() + "\n\n";
            } else
            {
                breakingChangeMessage = " - Cmdlet : " + Utilities.getNameFromCmdletType(type) + " \n - " + getAttributeSpecificMessage() + "\n\n";
            }

            if (!String.IsNullOrWhiteSpace(ChangeDescription))
            {
                breakingChangeMessage += "\tChange description : " + ChangeDescription + "\n";
            }

            if (ChangeInEfectByDateSet)
            {
                breakingChangeMessage += "\tNOTE : This change will take effect on '" + this.ChangeInEfectByDate.Date + "'\n";
            }

            if (DeprecateByVersionSet)
            {
                breakingChangeMessage += "\tThe change is expected to take effect from the version : " + DeprecateByVersion + "\n\n";
            }

            if (!String.IsNullOrWhiteSpace(OldWay) && !String.IsNullOrWhiteSpace(NewWay))
            {
                breakingChangeMessage += "```powershell\n# Old\n" + OldWay + "\n\n# New\n" + NewWay + "\n```\n\n";
            }

            return breakingChangeMessage;
        }

        public void printCustomAttributeInfo(Type type, Boolean withCmdletName)
        {
            String attributeMessage = getAttributeSpecificMessage();

            if (withCmdletName) {
                Console.WriteLine(String.Format(" - Cmdlet {0} :", Utilities.getNameFromCmdletType(type)));
            }

            if (!String.IsNullOrWhiteSpace(attributeMessage))
            {
                Console.WriteLine("\t" + attributeMessage);
            }

            if (!String.IsNullOrWhiteSpace(ChangeDescription))
            {
                Console.WriteLine("\tChange description : " + ChangeDescription);
            }

            if (ChangeInEfectByDateSet)
            {
                Console.WriteLine("\tNOTE : This change will take effect on '" + this.ChangeInEfectByDate.Date);
            }

            if (DeprecateByVersionSet)
            {
                Console.WriteLine("\tThe change is expected to take effect from the version : " + DeprecateByVersion);
            }

            if (OldWay != null && NewWay != null)
            {
                Console.WriteLine("Cmdlet invocation changes :");
                Console.WriteLine("\tOld : " + OldWay);
                Console.WriteLine("\tNew : " + NewWay);
            }
        }

        protected virtual String getAttributeSpecificMessage()
        {
            return _message;
        }
    }
}
