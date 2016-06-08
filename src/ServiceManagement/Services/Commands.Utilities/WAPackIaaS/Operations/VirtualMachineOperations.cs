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
    internal class VirtualMachineOperations : OperationsBase<VirtualMachine>
    {
        public VirtualMachineOperations(WebClientFactory webClientFactory)
            : base(webClientFactory, "/VirtualMachines")
        {
        }

        public override VirtualMachine Create(VirtualMachine vmToCreate, out Guid? jobId)
        {
            // CloudId and StampId are required parameters. Since we are assumed to be working with a WAP subscription,
            // we can just take the first cloud and its StampId. WAP subscriptions are associated with only ONE cloud and only ONE stamp.
            var cloud = CloudOperations.ReadFirstCloud(this.webClientFactory);

            vmToCreate.CloudId = cloud.ID;
            vmToCreate.StampId = cloud.StampId;

            var client = this.webClientFactory.CreateClient(this.uriSuffix);

            WebHeaderCollection outHeaders;
            var resultList = client.Create<VirtualMachine>(vmToCreate, out outHeaders);

            if (resultList.Count <= 0)
                throw new WAPackOperationException(Resources.ErrorCreatingVirtualMachine);

            jobId = TryGetJobIdFromHeaders(outHeaders);

            return resultList[0];
        }

        public List<VirtualMachine> Read(string vmName)
        {
            var filterDict = new Dictionary<string, string>
                {
                    {"Name", vmName}
                };

            var resultList = this.Read(filterDict);
            return resultList;
        }

        public override VirtualMachine Update(VirtualMachine toUpdate, out Guid? jobId)
        {
            var client = this.webClientFactory.CreateClient(this.uriSuffix + String.Format("(ID=guid'{0}',StampId=guid'{1}')", toUpdate.ID, toUpdate.StampId));

            WebHeaderCollection outHeaders;
            var resultList = client.Update<VirtualMachine>(toUpdate, out outHeaders);

            if (resultList.Count <= 0)
                throw new WAPackOperationException(Resources.ErrorUpdatingVirtualMachine);

            jobId = TryGetJobIdFromHeaders(outHeaders);

            return resultList[0];
        }

        public override void Delete(Guid id, out Guid? jobId)
        {
            var cloud = CloudOperations.ReadFirstCloud(this.webClientFactory);
            Guid stampId = cloud.StampId;

            var client = this.webClientFactory.CreateClient(this.uriSuffix + String.Format("(ID=guid'{0}',StampId=guid'{1}')", id, stampId));

            WebHeaderCollection outHeaders;
            client.Delete<VirtualMachine>(out outHeaders);

            jobId = TryGetJobIdFromHeaders(outHeaders);
        }

        private VirtualMachine DoOperation(string operation, Guid id, out Guid? jobId)
        {
            var cloud = CloudOperations.ReadFirstCloud(this.webClientFactory);
            var stampId = cloud.StampId;

            var vm = new VirtualMachine {ID = id, StampId = stampId, Operation = operation};

            return this.Update(vm, out jobId);
        }

        public VirtualMachine Start(Guid id, out Guid? jobId)
        {
            return this.DoOperation("Start", id, out jobId);
        }

        public VirtualMachine Stop(Guid id, out Guid? jobId)
        {
            return this.DoOperation("Stop", id, out jobId);
        }

        public VirtualMachine Shutdown(Guid id, out Guid? jobId)
        {
            return this.DoOperation("Shutdown", id, out jobId);
        }

        public VirtualMachine Restart(Guid id, out Guid? jobId)
        {
            return this.DoOperation("Reset", id, out jobId);
        }

        public VirtualMachine Suspend(Guid id, out Guid? jobId)
        {
            return this.DoOperation("Suspend", id, out jobId);
        }

        public VirtualMachine Resume(Guid id, out Guid? jobId)
        {
            return this.DoOperation("Resume", id, out jobId);
        }
    }
}
