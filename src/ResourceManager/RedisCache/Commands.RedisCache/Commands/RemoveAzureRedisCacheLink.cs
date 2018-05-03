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

namespace Microsoft.Azure.Commands.RedisCache
{
    using ResourceManager.Common.ArgumentCompleters;
    using System.Management.Automation;
    using Properties;

    [Cmdlet(VerbsCommon.Remove, "AzureRmRedisCacheLink", SupportsShouldProcess = true), OutputType(typeof(bool))]
    public class RemoveAzureRedisCacheLink : RedisCacheCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of primary redis cache in link.")]
        [ValidateNotNullOrEmpty]
        public string PrimaryServerName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Name of secondary redis cache in link.")]
        [ValidateNotNullOrEmpty]
        public string SecondaryServerName { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            Utility.ValidateResourceGroupAndResourceName(null, PrimaryServerName);
            Utility.ValidateResourceGroupAndResourceName(null, SecondaryServerName);
            string resourceGroupName = CacheClient.GetResourceGroupNameIfNotProvided(null, PrimaryServerName);

            ConfirmAction(
                string.Format(Resources.RemoveLinkedServer, SecondaryServerName, PrimaryServerName),
                PrimaryServerName,
                () =>
                {
                    CacheClient.RemoveLinkedServer(resourceGroupName, PrimaryServerName, SecondaryServerName);
                    if (PassThru)
                    {
                        WriteObject(true);
                    }
                });
        }
    }
}