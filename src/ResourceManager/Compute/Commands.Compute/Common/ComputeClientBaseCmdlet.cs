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

using Hyak.Common;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;

namespace Microsoft.Azure.Commands.Compute
{
    public abstract class ComputeClientBaseCmdlet : AzurePSCmdlet
    {
        protected const string VirtualMachineExtensionType = "Microsoft.Compute/virtualMachines/extensions";

        protected override bool IsMetricEnabled
        {
            get { return true; }
        }

        private ComputeClient computeClient;

        public ComputeClient ComputeClient
        {
            get
            {
                if (computeClient == null)
                {
                    computeClient = new ComputeClient(Profile.Context)
                    {
                        VerboseLogger = WriteVerboseWithTimestamp,
                        ErrorLogger = WriteErrorWithTimestamp
                    };
                }

                return computeClient;
            }

            set { computeClient = value; }
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            ComputeAutoMapperProfile.Initialize();
        }

        protected void ExecuteClientAction(Action action)
        {
            try
            {
                action();
            }
            catch (CloudException ex)
            {
                throw new ComputeCloudException(ex);
            }
        }
    }
}
