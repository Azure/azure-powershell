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

using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    internal class FaultResponse : ResponseBase
    {
        public FaultResponse(FaultModel resource) : base(resource)
        {
        }

        public DateTime ActivatedTime { get; set; }
        public AssociatedDataType AssociatedDataType { get; set; }
        public EventQuery AssociatedEventQuery { get; set; }
        public string AssociatedMetricsName { get; set; }
        public string Description { get; set; }
        public string FaultId { get; set; }
        public string FaultRuleName { get; set; }
        public string ResolutionText { get; set; }
        public DateTime? ResolvedTime { get; set; }
        public string ResourceUri { get; set; }
        public Severity Severity { get; set; }
    }
}
