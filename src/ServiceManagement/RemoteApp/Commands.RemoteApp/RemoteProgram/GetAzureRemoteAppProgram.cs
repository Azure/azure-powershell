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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{

    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppProgram", DefaultParameterSetName = FilterByName), OutputType(typeof(PublishedApplicationDetails))]
    public class GetAzureRemoteAppProgram : RdsCmdlet
    {
        private const string FilterByName = "FilterByName";
        private const string FilterByAlias = "FilterByAlias";

        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = false,
            Position = 1,
            HelpMessage = "Name of the program. Wildcards are permitted.",
            ParameterSetName = FilterByName)]
        [ValidateNotNullOrEmpty()]
        public string RemoteAppProgram { get; set; }

        [Parameter(Mandatory = false,
            Position = 1,
            HelpMessage = "Published program alias",
            ParameterSetName = FilterByAlias)]
        [ValidateNotNullOrEmpty()]
        public string Alias { get; set; }

        private bool found = false;

        private bool GetAllPublishedApps()
        {
            GetPublishedApplicationListResult response = null;
            IEnumerable<PublishedApplicationDetails> spList = null;

            response = CallClient(() => Client.Publishing.List(CollectionName), Client.Publishing);

            if (response != null)
            {
                if (UseWildcard)
                {
                    spList = response.ResultList.Where(app => Wildcard.IsMatch(app.Name));
                }
                else
                {
                    spList = response.ResultList;
                }

                if (spList != null && spList.Count() > 0)
                {
                    WriteObject(spList, true);
                    found = true;
                }
            }

            return found;
        }

        private bool GetPublishedApp()
        {
            GetPublishedApplicationResult response = null;

            response = CallClient(() => Client.Publishing.Get(CollectionName, Alias), Client.Publishing);

            if (response != null)
            {
                WriteObject(response.Result);
                found = true;
            }

            return found;
        }

        public override void ExecuteCmdlet()
        {
            if (!String.IsNullOrWhiteSpace(Alias))
            {
                found = GetPublishedApp();
                if (!found)
                {
                    WriteErrorWithTimestamp(
                        String.Format("Collection {0} does not have a published program matching alias {1}.",
                            CollectionName,
                            Alias)
                        );
                }
            }
            else
            {
                CreateWildcardPattern(RemoteAppProgram);

                found = GetAllPublishedApps();

                if (!found)
                {
                    WriteVerboseWithTimestamp(
                        String.Format("Collection {0} has no published program matching: {1}.",
                            CollectionName,
                            RemoteAppProgram)
                        );
                }
            }
        }
    }
}
