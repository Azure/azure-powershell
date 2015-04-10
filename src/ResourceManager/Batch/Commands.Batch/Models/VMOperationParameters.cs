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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Properties;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public class VMOperationParameters : BatchClientParametersBase
    {
        public VMOperationParameters(BatchAccountContext context, string poolName, string vmName, PSVM vm,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null) : base(context, additionalBehaviors)
        {
            if ((string.IsNullOrWhiteSpace(poolName) || string.IsNullOrWhiteSpace(vmName)) && vm == null)
            {
                throw new ArgumentNullException(Resources.NoVM);
            }

            this.PoolName = poolName;
            this.VMName = vmName;
            this.VM = vm;
        }

        /// <summary>
        /// The name of the pool containing the vm
        /// </summary>
        public string PoolName { get; private set; }

        /// <summary>
        /// The name of the vm
        /// </summary>
        public string VMName { get; private set; }

        /// <summary>
        /// The PSVM object representing the target vm
        /// </summary>
        public PSVM VM { get; private set; }
    }
}
