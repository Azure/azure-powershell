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

namespace Microsoft.AzureStack.Commands.Admin.Test
{
    using System;
    using Microsoft.Azure.Test.HttpRecorder;

    public class AzStackAdminTestBase
    {
        public string ResourceGroupName { get; set; }
        public string PlanName { get; set; }
        public string OfferName { get; set; }

        public AzStackAdminTestBase()
        {
            this.Initialize();
        }

        private void Initialize()
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                this.ResourceGroupName = "TestRg" + Guid.NewGuid();
                this.PlanName = "TestPlan" + Guid.NewGuid();
                this.ResourceGroupName = "TestOffer" + Guid.NewGuid();

                HttpMockServer.Variables["ResourceGroupName"] = ResourceGroupName;
                HttpMockServer.Variables["PlanName"] = PlanName;
                HttpMockServer.Variables["OfferName"] = OfferName;
            }
            else
            {
                this.ResourceGroupName = HttpMockServer.Variables["ResourceGroupName"];
                this.PlanName = HttpMockServer.Variables["PlanName"];
                this.OfferName = HttpMockServer.Variables["OfferName"];
            }
        }
    }
}
