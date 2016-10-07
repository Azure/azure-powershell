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

namespace Microsoft.Azure.Commands.Management.IotHub.Models
{
    using System;
    using System.Collections.Generic;

    public class PSSharedAccessAuthorizationRule
    {
        public string KeyName { get; set; }

        public string PrimaryKey { get; set; }

        public string IssuerName { get; set; }

        public string SecondaryKey { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        public IList<PSSBAccessRights> Rights { get; set; }

        public DateTime? CreatedTime { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public long? Revision { get; set; }
    }
}
