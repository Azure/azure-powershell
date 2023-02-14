//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

namespace Microsoft.Azure.Commands.ApiManagement.Models
{
    using Microsoft.Azure.Management.ApiManagement.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    public class PsApiManagementServiceIdentityTypes
    {
        public const string None = "none";

        public const string SystemAssigned = "SystemAssigned";

        public const string UserAssigned = "UserAssigned";

        public const string SystemAndUserAssigned = "SystemAssigned, UserAssigned";
    }
   
    public class PsApiManagementServiceIdentity
    {
        public PsApiManagementServiceIdentity()
        {
        }

        internal PsApiManagementServiceIdentity(ApiManagementServiceIdentity serviceIdentity)
            : this()
        {
            if (serviceIdentity == null)
            {
                throw new ArgumentNullException("serviceIdentity");
            }

            Type = serviceIdentity.Type;
            PrincipalId = serviceIdentity.PrincipalId.HasValue ? serviceIdentity.PrincipalId.Value.ToString() : null;
            TenantId = serviceIdentity.TenantId.HasValue ? serviceIdentity.TenantId.Value.ToString() : null;

            if(serviceIdentity.UserAssignedIdentities != null)
            {
                UserAssignedIdentity = serviceIdentity.UserAssignedIdentities.ToDictionary(i => i.Key, i => new PsApiManagementUserAssignedInformation(i.Value));
            }
        }

        public string PrincipalId { get; set; }

        public string TenantId { get; set; }

        public string Type { get; set; }

        public IDictionary<string, PsApiManagementUserAssignedInformation> UserAssignedIdentity { get; set; }
    }

    public class PsApiManagementUserAssignedInformation
    {
        public string PrincipalId;

        public string ClientId;

        public PsApiManagementUserAssignedInformation()
        {
        }

        internal PsApiManagementUserAssignedInformation(UserIdentityProperties props) : this()
        {
            if (props == null)
            {
                throw new ArgumentNullException("UserIdentityProperties");
            }

            PrincipalId = props.PrincipalId;
            ClientId = props.ClientId;
        }
    }
}