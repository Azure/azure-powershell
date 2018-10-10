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

using System.Collections.Generic;
using System;

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;

namespace Microsoft.Azure.Commands.Resources.Models
{
    public static class ResourceExtensions
    {
        public static IEnumerable<Location> Locations(this IEnumerable<Location> locations)
        {
            return locations;
        }

        public static DeploymentExtended Deployment(this DeploymentExtended deployment)
        {
            return deployment;
        }

        public static DeploymentMode Mode(this DeploymentPropertiesExtended deploymentProperties)
        {
            return deploymentProperties.Mode.Value;
        }

        public static DateTime Timestamp(this DeploymentPropertiesExtended deploymentProperties)
        {
            return deploymentProperties.Timestamp.Value;
        }

        public static DebugSetting DebugSetting(this DeploymentPropertiesExtended deploymentProperties)
        {
            return deploymentProperties.DebugSetting;
        }

        public static string DetailLevel(this DebugSetting settings)
        {
            return settings.DetailLevel;
        }

        public static IEnumerable<DeploymentOperation> Operations(this Rest.Azure.IPage<DeploymentOperation> operations)
        {
            return operations;
        }

        public static string NextLink(this Rest.Azure.IPage<DeploymentOperation> operations)
        {
            return operations.NextPageLink;
        }

        public static Rest.Azure.IPage<DeploymentOperation> List(this IDeploymentOperations operations,
            string resourceGroupName, string deploymentName, string parameters)
        {
            return operations.List(resourceGroupName, deploymentName);
        }

        public static bool Exists(this bool value)
        {
            return value;
        }
    }

    public static class ProvisioningState
    {
        public const string Accepted = "Accepted";
        public const string Canceled = "Canceled";
        public const string Created = "Created";
        public const string Creating = "Creating";
        public const string Deleted = "Deleted";
        public const string Deleting = "Deleting";
        public const string Failed = "Failed";
        public const string NotSpecified = "NotSpecified";
        public const string Registering = "Registering";
        public const string Running = "Running";
        public const string Succeeded = "Succeeded";
    }
}
