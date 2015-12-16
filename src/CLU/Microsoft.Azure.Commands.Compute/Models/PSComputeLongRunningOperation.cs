// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using Microsoft.Azure.Management.Compute.Models;
using Newtonsoft.Json;
using System;
using System.Net;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSComputeLongRunningOperation
    {
        public string TrackingOperationId { get; set; }
        
        public string RequestId { get; set; }

        public ComputeOperationStatus Status { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Output { get; set; }

        public DateTimeOffset StartTime { get; set; }
        
        public DateTimeOffset? EndTime { get; set; }

        public ApiError Error { get; set; }

        [JsonIgnore]
        public string ErrorText
        {
            get
            {
                var errorStr = JsonConvert.SerializeObject(Error, Formatting.Indented);
                return String.IsNullOrEmpty(errorStr) || "null".Equals(errorStr) ? "" : errorStr;
            }
        }
    }
}
