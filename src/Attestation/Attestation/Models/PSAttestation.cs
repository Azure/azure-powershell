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

using System.Collections;
using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;
using Microsoft.Azure.Management.Attestation.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Internal.Resources.Utilities;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    public class PSAttestation
    {
        public  PSAttestation(AttestationProvider attestation)
        {
            Id = attestation.Id;
            Location = attestation.Location;
            ResourceGroupName = new ResourceIdentifier(attestation.Id).ResourceGroupName;
            Name = attestation.Name;
            Status = attestation.Status;
            TrustModel = attestation.TrustModel;
            AttestUri = attestation.AttestUri;
            Tags = TagsConversionHelper.CreateTagHashtable(attestation.Tags);
        }
   
        public string Id { get; protected set; }

        public string Location { get; protected set; }

        public string ResourceGroupName { get; protected set; }

        public string Name { get; protected set; }

        public string Status { get; protected set; }

        public string TrustModel { get; protected set; }

        public string AttestUri { get; protected set; }

        public Hashtable Tags { get; protected set; }

        public string TagsTable => ResourcesExtensions.ConstructTagsTable(Tags);
    }
}