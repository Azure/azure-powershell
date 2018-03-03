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
   AttributeTargets.Class |
   AttributeTargets.Constructor |
   AttributeTargets.Field |
   AttributeTargets.Method |
   AttributeTargets.Property,
   AllowMultiple = true)]

    /**
     * This class acts as the base
     */ 
    public class BreakingChangeBaseAttribute : System.Attribute
    {
        public String Message { get; }

        public String DeprecateByVersion { get; }
        public bool DeprecateByVersionSet { get; } = false;

        public DateTime ChangeInEfectByDate { get; }
        public bool ChangeInEfectByDateSet { get; } = false;

        public String OldWay { get; set; }

        public String NewWay { get; set; }

        public BreakingChangeBaseAttribute(String message)
        {
            this.Message = message;
        }

        public BreakingChangeBaseAttribute(String message, String deprecateByVersion)
        {
            this.Message = message;
            this.DeprecateByVersion = deprecateByVersion;
            this.DeprecateByVersionSet = true;
        }

        public BreakingChangeBaseAttribute(String message, String deprecateByVersion, String changeInEfectByDate)
        {
            this.DeprecateByVersion = deprecateByVersion;
            this.DeprecateByVersionSet = true;

            this.ChangeInEfectByDate = DateTime.Parse(changeInEfectByDate);
            this.ChangeInEfectByDateSet = true;

            this.Message = message + "\nNOTE : This change will take effect on '" + this.ChangeInEfectByDate.Date + "'";
        }

        public DateTime getInEffectByDate()
        {
            return this.ChangeInEfectByDate.Date;
        }

        public String getBreakingChangeTextFromAttribute()
        {
            String breakinChangeMessage = " - " + Message + "\n\n";

            if (DeprecateByVersionSet)
            {
                breakinChangeMessage += "The change is expected to take effect from the version : " + DeprecateByVersion + "\n\n";
            }

            if (!String.IsNullOrWhiteSpace(OldWay) && !String.IsNullOrWhiteSpace(NewWay))
            {
                breakinChangeMessage += "```powershell\n# Old\n" + OldWay + "\n\n# New\n" + NewWay + "\n```\n\n";
            }

            return breakinChangeMessage;
        }

        public void printCustomAttributeInfo()
        {
            Console.WriteLine("Deprecation message : \n" + Message);
            if (DeprecateByVersionSet)
            {
                Console.WriteLine("The change is expected to take effect from the version : " + DeprecateByVersion);
            }

            if (OldWay != null && NewWay != null)
            {
                Console.WriteLine("Original command : " + OldWay);
                Console.WriteLine("Workaround : " + NewWay);
            }
        }
    }
}
