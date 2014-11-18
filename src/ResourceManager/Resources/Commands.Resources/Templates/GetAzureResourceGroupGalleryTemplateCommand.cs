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

using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Resources.Models;

namespace Microsoft.Azure.Commands.Resources.Templates
{
    /// <summary>
    /// Get one template or a list of templates from the gallery.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureResourceGroupGalleryTemplate", DefaultParameterSetName = BaseParameterSetName), OutputType(typeof(List<PSGalleryItem>))]
    public class GetAzureResourceGroupGalleryTemplateCommand : ResourcesBaseCmdlet
    {
        internal const string BaseParameterSetName = "List gallery templates";
        internal const string ParameterSetNameWithIdentity = "Get a single gallery template";

        [Parameter(Position = 0, ParameterSetName = ParameterSetNameWithIdentity, Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Optional. Name of the template.")]
        [ValidateNotNullOrEmpty]
        public string Identity { get; set; }

        [Parameter(Position = 1, ParameterSetName = BaseParameterSetName, Mandatory = false, HelpMessage = "Optional. Publisher of the template.")]
        [ValidateNotNullOrEmpty]
        public string Publisher { get; set; }

        [Parameter(Position = 2, ParameterSetName = BaseParameterSetName, Mandatory = false, HelpMessage = "Optional. Category of the template.")]
        [ValidateNotNullOrEmpty]
        public string Category { get; set; }

        [Parameter(Position = 3, ParameterSetName = BaseParameterSetName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Optional. Name of the application.")]
        [ValidateNotNullOrEmpty]
        public string ApplicationName { get; set; }

        [Parameter(Position = 4, ParameterSetName = BaseParameterSetName, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "Optional. Include all versions.")]
        public SwitchParameter AllVersions { get; set; }

        public override void ExecuteCmdlet()
        {
            FilterGalleryTemplatesOptions options = new FilterGalleryTemplatesOptions()
            {
                Category = Category,
                Identity = Identity,
                Publisher = Publisher,
                ApplicationName = ApplicationName,
                AllVersions = AllVersions
            };

            if (Category == null && Identity == null && Publisher == null && ApplicationName == null)
            {
                // if there are no filter parameters, return everything
                options.AllVersions = true;
            }

            List<PSGalleryItem> galleryItems = GalleryTemplatesClient.FilterGalleryTemplates(options);

            if (galleryItems != null)
            {
                if (galleryItems.Count == 1 && !string.IsNullOrEmpty(Identity))
                {
                    WriteObject(galleryItems[0]);
                }
                else
                {
                    List<PSObject> output = new List<PSObject>();
                    galleryItems.Where(gi => !gi.Identity.EndsWith("-placeholder"))
                    .OrderBy(gi => gi.Identity)
                    .ToList()
                    .ForEach(gi => output.Add(base.ConstructPSObject(
                        null,
                        "Publisher", gi.Publisher,
                        "Identity", gi.Identity)));
                    WriteObject(output, true);
                }
            }
        }
    }
}
