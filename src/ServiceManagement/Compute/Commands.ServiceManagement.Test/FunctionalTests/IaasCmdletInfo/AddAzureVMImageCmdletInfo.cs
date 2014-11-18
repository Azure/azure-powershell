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
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.IaasCmdletInfo
{
    public class AddAzureVMImageCmdletInfo : CmdletsInfo
    {
        public AddAzureVMImageCmdletInfo(string imageName, string mediaLocation, OS os, string label)
        {
            cmdletName = Utilities.AddAzureVMImageCmdletName;

            cmdletParams.Add(new CmdletParam("ImageName", imageName));
            cmdletParams.Add(new CmdletParam("MediaLocation", mediaLocation));
            cmdletParams.Add(new CmdletParam("OS", os.ToString()));
                
            if (!string.IsNullOrEmpty(label))
            {
                cmdletParams.Add(new CmdletParam("Label", label));
            }
        }

        public AddAzureVMImageCmdletInfo(string imageName, string mediaLocation, OS os, string label, string recommendedSize)
            : this(imageName, mediaLocation, os, label)
        {
            if (!string.IsNullOrEmpty(recommendedSize))
            {
                cmdletParams.Add(new CmdletParam("RecommendedVMSize", recommendedSize));
            }
        }

        public AddAzureVMImageCmdletInfo(
            string imageName,
            string mediaLocation,
            OS os,
            string label,
            string recommendedSize,
            string description,
            string eula,
            string imageFamily,
            Uri privacyUri,
            DateTime publishedDate)
            : this(imageName, mediaLocation, os, label, recommendedSize)
        {
            if(!string.IsNullOrEmpty(description))
            {
                cmdletParams.Add(new CmdletParam("Description", description));
            }
            if(!string.IsNullOrEmpty(eula))
            {
                cmdletParams.Add(new CmdletParam("Eula", eula));
            }
            if(!string.IsNullOrEmpty(imageFamily))
            {
                cmdletParams.Add(new CmdletParam("ImageFamily", imageFamily));
            }
            if(privacyUri != null)
            {
                cmdletParams.Add(new CmdletParam("PrivacyUri", privacyUri.ToString()));
            }
            if(publishedDate != null)
            {
                cmdletParams.Add(new CmdletParam("PublishedDate", publishedDate.ToString()));
            }
        }
    }
}
