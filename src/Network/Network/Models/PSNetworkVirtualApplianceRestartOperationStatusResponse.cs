//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSNetworkVirtualApplianceRestartOperationStatusResponse
    {
        public string Name { get; set; }
        public IList<string> InstancesRestarted { get; set; }
        public string Status { get; set; }
        public string OperationId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ApiError Error { get; set; }

        public PSNetworkVirtualApplianceRestartOperationStatusResponse()
        {
            this.Status = "Succeeded";
        }
    }

    public class ApiError
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public string Target { get; set; }

    }
}
