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

using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{

    [Cmdlet(VerbsCommon.Rename, "AzureRemoteAppTemplateImage"), OutputType(typeof(TemplateImage))]

    public class RenameAzureRemoteAppTemplateImage : GoldImage
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "Template image name")]
        public string ImageName { get; set; }

        [Parameter(Mandatory = true,
            Position = 1,
            ValueFromPipeline = false,
            HelpMessage = "New template image name")]
        public string NewName { get; set; }

        public override void ExecuteCmdlet()
        {
            TemplateImageResult response = null;
            TemplateImageDetails details = null;
            TemplateImage matchingTemplate = null;

            matchingTemplate = FilterTemplateImage(ImageName, Operation.Update);

            details = new TemplateImageDetails()
            {
                Id = matchingTemplate.Id,
                Region = matchingTemplate.RegionList[0],
                Name = NewName
            };

            response = CallClient(() => Client.TemplateImages.Set(details), Client.TemplateImages);

            if (response != null)
            {
                WriteObject(response.TemplateImage);
            }
        }
    }
}
