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

using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.DataContract;
using Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Exceptions;

namespace Microsoft.WindowsAzure.Commands.Utilities.WAPackIaaS.Operations
{
    internal class CloudOperations : OperationsBase<Cloud>
    {
        public CloudOperations(WebClientFactory webClientFactory)
            : base(webClientFactory, "/Clouds")
        {
        }

        /// <summary>
        /// Reads the list of clouds and returns the first one.
        /// This is a helper function for other operations classes which sometimes need cloudId and/or stampId to do their jos.
        /// It is okay to blindly take the first cloud because WAP subscriptions are currently limited to one cloud and one stamp.
        /// i.e., there should only be one cloud available anyway.
        /// </summary>
        /// <returns></returns>
        public static Cloud ReadFirstCloud(WebClientFactory webClientFactory)
        {
            var ops = new CloudOperations(webClientFactory);
            var cloudList = ops.Read();

            if (cloudList.Count <= 0)
                throw new WAPackOperationException(Resources.NoCloudsAvailable);

            return cloudList[0];
        }
    }
}
