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
    public class CmdletMetadataChangeMarkerAttribute : BreakingChangeBaseAttribute
    {
        public String CmdletName { get; }
        public String MetadataChanging { get; }
        public String ChangeDescription { get; }

        public CmdletMetadataChangeMarkerAttribute(String cmdlet, String metadataChanging, String changeDescription) :
            base(getMessage(cmdlet, metadataChanging, changeDescription))
        {
            this.CmdletName = cmdlet;
            this.MetadataChanging = metadataChanging;
            this.ChangeDescription = changeDescription;
        }

        public CmdletMetadataChangeMarkerAttribute(String cmdlet, String metadataChanging, String changeDescription, String deprecateByVersion) :
             base(getMessage(cmdlet, metadataChanging, changeDescription), deprecateByVersion)
        {
            this.CmdletName = cmdlet;
            this.MetadataChanging = metadataChanging;
            this.ChangeDescription = changeDescription;
        }

        public CmdletMetadataChangeMarkerAttribute(String cmdlet,String metadataChanging, String changeDescription, String deprecateByVersion, String changeInEfectByDate) :
             base(getMessage(cmdlet, metadataChanging, changeDescription), deprecateByVersion, changeInEfectByDate)
        {
            this.CmdletName = cmdlet;
            this.MetadataChanging = metadataChanging;
            this.ChangeDescription = changeDescription;
        }

        private static String getMessage(String cmdlet, String metadataChanging, String changeDescription)
        {
            return "The cmdlet '" + cmdlet + "' has the following change to the metadata '" + metadataChanging + "' :\n \t" + changeDescription;
        }
    }
}
