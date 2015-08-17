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

using Microsoft.WindowsAzure.Commands.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppCollection"), OutputType(typeof(LocalModels.Collection))]
    public class GetAzureRemoteAppCollection : RdsCmdlet
    {
        [Parameter(Mandatory = false,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name. Wildcards are permitted.")]
        [ValidatePattern(NameValidatorStringWithWildCards)]
        [Alias("Name")]
        public string CollectionName { get; set; }

        private bool showAllCollections = false;

        private bool found = false;

        private bool GetAllCollections()
        {
            CollectionListResult response = null;
            IEnumerable<Collection> spList = null;
            LocalModels.Collection collection = null;

            response = CallClient(() => Client.Collections.List(), Client.Collections);

            if (response != null)
            {
                if (UseWildcard)
                {
                    spList = response.Collections.Where(col => Wildcard.IsMatch(col.Name));
                }
                else
                {
                    spList = response.Collections;
                }

                if (spList != null && spList.Count() > 0)
                {
                    foreach( Collection c in spList)
                    {
                        collection = new LocalModels.Collection(c);
                        WriteObject(collection);
                    }
                    found = true;
                }
            }

            return found;
        }

        private bool GetCollection(string collectionName)
        {
            CollectionResult response = null;
            LocalModels.Collection collection = null;

            response = CallClient(() => Client.Collections.Get(collectionName), Client.Collections);

            if (response != null)
            {
                collection = new LocalModels.Collection(response.Collection);
                WriteObject(collection);
                found = true;
            }

            return found;
        }

        public override void ExecuteCmdlet()
        {
            showAllCollections = String.IsNullOrWhiteSpace(CollectionName);

            if (showAllCollections == false)
            {
                CreateWildcardPattern(CollectionName);
            }

            if (ExactMatch)
            {
                found = GetCollection(CollectionName);
            }
            else
            {
                found = GetAllCollections();
            }

            if (!found)
            {
                WriteVerboseWithTimestamp(String.Format(Commands_RemoteApp.CollectionNotFoundByNameFormat, CollectionName));
            }
        }
    }
}
