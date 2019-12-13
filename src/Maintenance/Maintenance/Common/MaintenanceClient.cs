﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.Azure.Management.Maintenance;
using System;

namespace Microsoft.Azure.Commands.Maintenance
{
    public class MaintenanceClient
    {
        public IMaintenanceManagementClient MaintenanceManagementClient { get; private set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public MaintenanceClient(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<MaintenanceManagementClient>(
                context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public MaintenanceClient(IMaintenanceManagementClient maintenancManagementClient)
        {
            MaintenanceManagementClient = maintenancManagementClient;
        }
    }
}