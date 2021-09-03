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
    using System;
    using Microsoft.Azure.Management.ApiManagement.Models;

    public class PsApiManagementDeletedService
    {
        public PsApiManagementDeletedService()
        {
        }

        public PsApiManagementDeletedService(DeletedServiceContract apiServiceResource)
            : this()
        {
            if (apiServiceResource == null)
            {
                throw new ArgumentNullException("apiServiceResource");
            }

            Id = apiServiceResource.Id;
            Name = apiServiceResource.Name;
            Location = apiServiceResource.Location;
            Type = apiServiceResource.Type;
            ServiceId = apiServiceResource.ServiceId;
            ScheduledPurgeDate = apiServiceResource.ScheduledPurgeDate;
            DeletionDate = apiServiceResource.DeletionDate;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string Location { get; private set; }

        public string Type { get; set; }

        public DateTime? ScheduledPurgeDate { get; set; }

        public DateTime? DeletionDate { get; set; }

        public string ServiceId { get; private set; }
    }
}