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
    public class PSDataFlow : AdfSubResource
    {
        private DataFlowResource _dataFlow;

        public PSDataFlow()
        {
            this._dataFlow = new DataFlowResource() { Properties = new DataFlow() };
        }

        public PSDataFlow(DataFlowResource dataFlow, string resourceGroupName, string factoryName)
        {
            if (dataFlow == null)
            {
                throw new ArgumentNullException("dataFlow");
            }

            if (dataFlow.Properties == null)
            {
                dataFlow.Properties = new DataFlow();
            }

            this._dataFlow = dataFlow;
            this.ResourceGroupName = resourceGroupName;
            this.DataFactoryName = factoryName;
        }

        public override string Name
        {
            get
            {
                return this._dataFlow.Name;
            }
        }

        public DataFlow Properties
        {
            get
            {
                return this._dataFlow.Properties;
            }
            set
            {
                this._dataFlow.Properties = value;
            }
        }

        public override string Id
        {
            get
            {
                return this._dataFlow.Id;
            }
        }

        public override string ETag
        {
            get
            {
                return this._dataFlow.Etag;
            }
        }
    }
}
