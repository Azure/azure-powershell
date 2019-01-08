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

using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Strategies.ComputeRp
{
    static class ComputeStrategy
    {
        public const string Namespace = "Microsoft.Compute";

        public static ResourceStrategy<TModel> Create<TModel, TOperations>(
            string provider,
            Func<ComputeManagementClient, TOperations> getOperations,
            Func<TOperations, GetAsyncParams, Task<TModel>> getAsync,
            Func<TOperations, CreateOrUpdateAsyncParams<TModel>, Task<TModel>> createOrUpdateAsync,
            Func<TModel, int> createTime)
            where TModel : Resource
            => ResourceStrategy.Create(
                type: new ResourceType(Namespace, provider),
                getOperations: getOperations,
                getAsync: getAsync,
                createOrUpdateAsync: createOrUpdateAsync,
                getLocation: config => config.Location,
                setLocation: (config, location) => config.Location = location,
                createTime: createTime,
                compulsoryLocation: true);

        public static string GetConnectionString(
            this ImageAndOsType imageAndOsType, string fqdn, string user, string port = null)
            => imageAndOsType.OsType == OperatingSystemTypes.Windows
                ? "mstsc /v:" 
                    + fqdn 
                    + (port == null ? string.Empty : ":" + port)
                : "ssh " 
                    + (user == null ? string.Empty : user + "@") 
                    + fqdn 
                    + (port == null ? string.Empty : " -p " + port);
    }
}
