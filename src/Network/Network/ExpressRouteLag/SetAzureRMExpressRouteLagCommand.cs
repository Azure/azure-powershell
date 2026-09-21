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

using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using System.Net;
using System.Reflection;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Management.Automation;
using MNM = Microsoft.Azure.Management.Network.Models;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Set, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ExpressRouteLag", SupportsShouldProcess = true), OutputType(typeof(PSExpressRouteLag))]
    public class SetAzureExpressRouteLagCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = true,
            ValueFromPipeline = true,
            HelpMessage = "The express route LAG object")]
        [Alias("InputObject")]
        public PSExpressRouteLag ExpressRouteLag { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        public override void Execute()
        {
            base.Execute();

            var present = true;
            try
            {
                this.NetworkClient.NetworkManagementClient.ExpressRouteLags.Get(this.ExpressRouteLag.ResourceGroupName, this.ExpressRouteLag.Name);
            }
            catch (Microsoft.Rest.Azure.CloudException exception)
            {
                if (exception.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    // Resource is not present
                    present = false;
                }
                else
                {
                    throw;
                }
            }

            if (!present)
            {
                throw new ArgumentException(Microsoft.Azure.Commands.Network.Properties.Resources.ResourceNotFound);
            }

            // Map to the sdk object
            var vExpressRouteLagModel = NetworkResourceManagerProfile.Mapper.Map<MNM.ExpressRouteLag>(this.ExpressRouteLag);
            vExpressRouteLagModel.Tags = TagsConversionHelper.CreateTagDictionary(this.ExpressRouteLag.Tag, validate: true);

            // The service requires each link/member child resource to carry its "name" in the PUT body
            // (so updates such as link/member AdminState are honored). However, the generated SDK models
            // expose ExpressRouteLagLink.Name/Type and ExpressRouteLagMember.Name/Type with private
            // setters, and the client's default ReadOnlyJsonContractResolver omits those from the request
            // body -- so NRP rejects the PUT with "item.Name is null". Swap in a resolver that re-includes
            // name/type for just these two child types for the duration of this call, then restore the
            // original resolver.
            ConfirmAction(
                true,
                string.Format(Properties.Resources.OverwritingResource, this.ExpressRouteLag.Name),
                Properties.Resources.SettingResourceMessage,
                this.ExpressRouteLag.Name,
                () =>
                {
                    var client = this.NetworkClient.NetworkManagementClient;
                    var originalResolver = client.SerializationSettings.ContractResolver;
                    try
                    {
                        client.SerializationSettings.ContractResolver = new ExpressRouteLagChildNameContractResolver();

                        // Execute the PUT ExpressRouteLag call
                        client.ExpressRouteLags.CreateOrUpdate(this.ExpressRouteLag.ResourceGroupName, this.ExpressRouteLag.Name, vExpressRouteLagModel);
                    }
                    finally
                    {
                        client.SerializationSettings.ContractResolver = originalResolver;
                    }

                    var getExpressRouteLag = this.NetworkClient.NetworkManagementClient.ExpressRouteLags.Get(this.ExpressRouteLag.ResourceGroupName, this.ExpressRouteLag.Name);
                    var psExpressRouteLag = NetworkResourceManagerProfile.Mapper.Map<PSExpressRouteLag>(getExpressRouteLag);
                    psExpressRouteLag.ResourceGroupName = this.ExpressRouteLag.ResourceGroupName;
                    psExpressRouteLag.Tag = TagsConversionHelper.CreateTagHashtable(getExpressRouteLag.Tags);
                    WriteObject(psExpressRouteLag, true);
                });
        }

        /// <summary>
        /// Behaves like the SDK client's default <see cref="ReadOnlyJsonContractResolver"/>, except it also
        /// serializes the (read-only) name and type of ExpressRouteLag links and members. The service requires
        /// these on child resources in the PUT body; the generated SDK models expose them with private setters,
        /// so the default resolver would otherwise drop them.
        /// </summary>
        private class ExpressRouteLagChildNameContractResolver : ReadOnlyJsonContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                if ((member.DeclaringType == typeof(MNM.ExpressRouteLagLink) || member.DeclaringType == typeof(MNM.ExpressRouteLagMember))
                    && (property.PropertyName == "name" || property.PropertyName == "type"))
                {
                    property.Ignored = false;
                    property.Readable = true;
                    property.ShouldSerialize = _ => true;
                }

                return property;
            }
        }
    }
}
