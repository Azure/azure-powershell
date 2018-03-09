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
    public class CmdletDeprecationMarkerAttribute : GenericBreakingChangeAttribute
    {
        public String ReplacementCmdletName { get; set; }

        public CmdletDeprecationMarkerAttribute() :
            base("")
        {
            this.ReplacementCmdletName = null;
        }

        public CmdletDeprecationMarkerAttribute(String deprecateByVersione) :
             base("", deprecateByVersione)
        {
        }

        public CmdletDeprecationMarkerAttribute(String deprecateByVersion, String changeInEfectByDate) :
             base("", deprecateByVersion, changeInEfectByDate)
        {
        }

        protected override String getAttributeSpecificMessage()
        {
            if (String.IsNullOrWhiteSpace(ReplacementCmdletName))
            {
                return "The cmdlet is being deprecated. There will be no replacement for it.";
            }
            else
            {
                return "The cmdlet '" + ReplacementCmdletName + "' is replacing this cmdlet";
            }
        }
    }
}
