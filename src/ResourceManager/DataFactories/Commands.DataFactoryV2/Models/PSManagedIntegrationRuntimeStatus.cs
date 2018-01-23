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
using Microsoft.Azure.Management.DataFactory.Models;

namespace Microsoft.Azure.Commands.DataFactoryV2.Models
{
    public class PSManagedIntegrationRuntimeStatus : PSManagedIntegrationRuntime
    {
        private readonly ManagedIntegrationRuntimeStatus _status;

        public PSManagedIntegrationRuntimeStatus(
            IntegrationRuntimeResource integrationRuntime,
            ManagedIntegrationRuntimeStatus status,
            string resourceGroupName,
            string factoryName)
            : base(integrationRuntime, resourceGroupName, factoryName)
        {
            _status = status;
        }

        public DateTime? CreateTime => _status.CreateTime;

        public IList<ManagedIntegrationRuntimeNode> Nodes => _status.Nodes;

        public IList<ManagedIntegrationRuntimeError> OtherErrors => _status.OtherErrors;

        public ManagedIntegrationRuntimeOperationResult LastOperation => _status.LastOperation;

        public new string State => _status.State;
    }
}
