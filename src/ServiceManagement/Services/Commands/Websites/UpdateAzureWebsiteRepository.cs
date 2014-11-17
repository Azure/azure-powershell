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
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services;
using Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.WebEntities;

namespace Microsoft.WindowsAzure.Commands.Websites
{
    /// <summary>
    /// Updates a website git remote config to include slots
    /// </summary>
    [Cmdlet(VerbsData.Update, "AzureWebsiteRepository", SupportsShouldProcess = true)]
    public class UpdateAzureWebsiteRepositoryCommand : WebsiteBaseCmdlet
    {
        private string name;
        private string publishingUsername;

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The web site name.")]
        [ValidateNotNullOrEmpty]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                // Convert to Unicode if necessary.
                name = IdnHelper.GetUnicode(value);
            }
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The publishing user name.")]
        [ValidateNotNullOrEmpty]
        public string PublishingUsername
        {
            get
            {
                return publishingUsername;
            }
            set
            {
                // Convert to Unicode if necessary.
                publishingUsername = IdnHelper.GetUnicodeForUserName(value);
            }
        }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                // If the website name was not specified as a parameter try to infer it
                Name = GitWebsite.ReadConfiguration().Name;
            }

            List<Site> sites = WebsitesClient.GetWebsiteSlots(Name);
            IList<string> remoteRepositories = Git.GetRemoteRepositories();

            // Clear all existing remotes that are created by us
            foreach (string remoteName in remoteRepositories)
            {
                if (remoteName.StartsWith("azure"))
                {
                    Git.RemoveRemoteRepository(remoteName);
                }
            }

            foreach (Site website in sites)
            {
                string repositoryUri = website.GetProperty("RepositoryUri");
                string publishingUsername = PublishingUsername;
                string uri = Git.GetUri(repositoryUri, website.RepositorySiteName, publishingUsername);
                string slot = WebsitesClient.GetSlotName(website.Name);
                string remoteName = string.Empty;

                if (!string.IsNullOrEmpty(slot) && !slot.Equals(WebsiteSlotName.Production.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    remoteName = "-" + slot;
                }

                Git.AddRemoteRepository(string.Format("azure{0}", remoteName), uri);
            }
        }
    }
}
