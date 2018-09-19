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
    internal class StaticIPAddressPoolOperations : OperationsBase<StaticIPAddressPool>
    {
        public StaticIPAddressPoolOperations(WebClientFactory webClientFactory)
            : base(webClientFactory, "/StaticIPAddressPools")
        {
        }

        public override StaticIPAddressPool Create(StaticIPAddressPool staticIPAddressPool, out Guid? jobId)
        {
            var client = this.webClientFactory.CreateClient(this.uriSuffix);

            WebHeaderCollection outHeaders;
            var resultList = client.Create<StaticIPAddressPool>(staticIPAddressPool, out outHeaders);

            if (resultList.Count <= 0)
                throw new WAPackOperationException(Resources.ErrorCreatingStaticIPAddressPool);

            jobId = TryGetJobIdFromHeaders(outHeaders);

            return resultList[0];
        }

        public List<StaticIPAddressPool> Read(VMSubnet vmSubnet)
        {
            var filter = new Dictionary<string, string>
            {
                {"StampId", vmSubnet.StampId.ToString()},
                {"VMSubnetId ", vmSubnet.ID.ToString()}
            };

            var resultList = Read(filter);
            return resultList;
        }

        public override void Delete(Guid id, out Guid? jobId)
        {
            var cloud = CloudOperations.ReadFirstCloud(this.webClientFactory);
            Guid stampId = cloud.StampId;

            var client = this.webClientFactory.CreateClient(this.uriSuffix + String.Format("(ID=guid'{0}',StampId=guid'{1}')", id, stampId));

            WebHeaderCollection outHeaders;
            client.Delete<StaticIPAddressPool>(out outHeaders);

            jobId = TryGetJobIdFromHeaders(outHeaders);
        }
    }
}
