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
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppTemplateImage"), OutputType(typeof(TemplateImage))]
    public class GetAzureRemoteAppTemplateImage : GoldImage
    {
        [Parameter(Mandatory = false,
            Position = 0,
            ValueFromPipeline = true,
            HelpMessage = "Template image name. Wildcards are permitted.")]
        public string ImageName { get; set; }

        private bool showAllImages = false;

        private bool found = false;

        public void WriteImage(List<TemplateImage> templateImages)
        {
            IComparer<TemplateImage> comparer = new TemplateImageComparer();
            templateImages.Sort(comparer);

            WriteObject(templateImages, true);
            found = true;
        }

        private bool GetAllTemplates()
        {
            TemplateImageListResult response = null;

            response = CallClient(() => Client.TemplateImages.List(), Client.TemplateImages);

            if (response != null)
            {
                List<TemplateImage> customerImages = new List<TemplateImage>();
                List<TemplateImage> platformImages = new List<TemplateImage>();
                List<TemplateImage> unknownImages = new List<TemplateImage>();

                foreach (TemplateImage image in response.RemoteAppTemplateImageList)
                {
                    if (UseWildcard && !Wildcard.IsMatch(image.Name))
                    {
                        continue;
                    }

                    switch (image.Type)
                    {
                        case TemplateImageType.CustomerImage:
                        {
                            customerImages.Add(image);
                            break;
                        }
                        case TemplateImageType.PlatformImage:
                        {
                            platformImages.Add(image);
                            break;
                        }
                        default:
                        {
                            unknownImages.Add(image);
                            break;
                        }
                    }
                }

                WriteImage(unknownImages);
                WriteImage(customerImages);
                WriteImage(platformImages);
            }
                return found;
        }

        private bool GetTemplate(string imageName)
        {
            TemplateImageResult response = null;
            response = CallClient(() => Client.TemplateImages.Get(imageName), Client.TemplateImages);
            if (response != null)
            {
                WriteObject(response.TemplateImage);
            }
            return found;
        }

        public override void ExecuteCmdlet()
        {
            showAllImages = String.IsNullOrWhiteSpace(ImageName);

            if (showAllImages == false)
            {
                CreateWildcardPattern(ImageName);
            }

            if (ExactMatch)
            {
                found = GetTemplate(ImageName);
            }
            else
            {
                found = GetAllTemplates();
            }

            if (!found)
            {
                WriteVerboseWithTimestamp(String.Format("RemoteApp image: {0} not found", ImageName));
            }
        }
    }
}
