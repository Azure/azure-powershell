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

using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Exceptions;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations
{
    internal class VMRoleOperations : OperationsBase<VMRole>
    {
        private const string genericBaseUri = "/CloudServices/{0}/Resources/MicrosoftCompute/VMRoles?api-version=2013-03";
        private const string specificBaseUri = "/CloudServices/{0}/Resources/MicrosoftCompute/VMRoles/{1}?api-version=2013-03";
        private const string vmsUri = "/CloudServices/{0}/Resources/MicrosoftCompute/VMRoles/{1}/VMs?api-version=2013-03";
        private const string scaleUri = "/CloudServices/{0}/Resources/MicrosoftCompute/VMRoles/{1}/Scale?api-version=2013-03";

        public VMRoleOperations(WebClientFactory webClientFactory)
            : base(webClientFactory, genericBaseUri)
        {
        }

        public VMRole Create(string cloudServiceName, VMRole vmRoleToCreate, out Guid? jobId)
        {
            var client = this.webClientFactory.CreateClient(String.Format(genericBaseUri, cloudServiceName));

            WebHeaderCollection outHeaders;
            var resultList = client.Create<VMRole>(vmRoleToCreate, out outHeaders);

            if (resultList.Count <= 0)
                throw new WAPackOperationException(Resources.ErrorCreatingVMRole);

            jobId = TryGetJobIdFromHeaders(outHeaders);

            return resultList[0];
        }

        public List<VMRole> Read(string cloudServiceName)
        {
            var client = this.webClientFactory.CreateClient(String.Format(genericBaseUri, cloudServiceName));

            WebHeaderCollection outHeaders;
            var results = client.Get<VMRole>(out outHeaders);

            foreach (var vmRole in results)
            {
                var vmList = this.GetVMs(cloudServiceName, vmRole);
                vmRole.VMs.Load(vmList);
            }

            return results;
        }

        public VMRole Read(string cloudServiceName, string vmRoleName)
        {
            var client = this.webClientFactory.CreateClient(String.Format(specificBaseUri, cloudServiceName, vmRoleName));

            WebHeaderCollection outHeaders;
            var result = client.Get<VMRole>(out outHeaders)[0];

            var vmList = this.GetVMs(cloudServiceName, result);
            result.VMs.Load(vmList);

            return result;
        }

        public void Delete(string cloudServiceName, string vmRoleName, out Guid? jobId)
        {
            WebHeaderCollection outHeaders;
            var client = this.webClientFactory.CreateClient(String.Format(specificBaseUri, cloudServiceName, vmRoleName));

            client.Delete<VMRole>(out outHeaders);
            jobId = TryGetJobIdFromHeaders(outHeaders);
        }

        public List<VM> GetVMs(string cloudServiceName, VMRole vmRole)
        {
            WebHeaderCollection outHeaders;
            var client = this.webClientFactory.CreateClient(String.Format(vmsUri, cloudServiceName, vmRole.Name));
            
            var resultList = client.Get<VM>(out outHeaders);
            return resultList;
        }

        public void SetInstanceCount(string cloudServiceName, VMRole vmRole, int count, out Guid? jobId)
        {
            var client = this.webClientFactory.CreateClient(String.Format(scaleUri, cloudServiceName, vmRole.Name));

            var properties = new Dictionary<string, object>()
			{
			    {"InstanceCount", count}
			};

            WebHeaderCollection outHeaders;
            client.Create<VMRole>(properties, out outHeaders);
            jobId = TryGetJobIdFromHeaders(outHeaders);
        }
    }
}
