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
    public class PSTrigger : AdfSubResource
    {
        private TriggerResource trigger;

        public PSTrigger()
        {
            this.trigger = new TriggerResource();
        }

        public PSTrigger(TriggerResource trigger, string resourceGroupName, string factoryName)
        {
            if (trigger == null)
            {
                throw new ArgumentNullException("trigger");
            }

            this.trigger = trigger;
            this.ResourceGroupName = resourceGroupName;
            this.DataFactoryName = factoryName;
        }

        public override string Name
        {
            get
            {
                return this.trigger.Name;
            }
        }

        public string RuntimeState
        {
            get
            {
                return this.trigger.Properties.RuntimeState;
            }
        }

        public Trigger Properties
        {
            get
            {
                return this.trigger.Properties;
            }
        }

        public override string Id
        {
            get
            {
                return this.trigger.Id;
            }
        }

        public override string ETag
        {
            get
            {
                return this.trigger.Etag;
            }
        }
    }
}
