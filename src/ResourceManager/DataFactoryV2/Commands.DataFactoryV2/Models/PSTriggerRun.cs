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
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSTriggerRun
    {
        private TriggerRun triggerRun;

        public PSTriggerRun()
        {
            this.triggerRun = new TriggerRun();
        }

        public PSTriggerRun(TriggerRun triggerRun, string resourceGroupName, string factoryName)
        {
            if (triggerRun == null)
            {
                throw new ArgumentNullException("triggerRun");
            }

            this.triggerRun = triggerRun;
            this.ResourceGroupName = resourceGroupName;
            this.DataFactoryName = factoryName;
        }

        public string ResourceGroupName { get; private set; }

        public string DataFactoryName { get; private set; }

        public string TriggerName
        {
            get
            {
                return this.triggerRun.TriggerName;
            }
        }

        public string TriggerRunId
        {
            get
            {
                return this.triggerRun.TriggerRunId;
            }
        }

        public string TriggerType
        {
            get
            {
                return this.triggerRun.TriggerType;
            }
        }

        public DateTime? TriggerRunTimestamp
        {
            get
            {
                return this.triggerRun.TriggerRunTimestamp;
            }
        }

        public string Status
        {
            get
            {
                return this.triggerRun.Status;
            }
        }
    }
}
