﻿// ----------------------------------------------------------------------------------
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

using Azure.Analytics.Synapse.Artifacts.Models;
using System;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSLinkTableStatus
    {
        public PSLinkTableStatus(LinkTableStatus linkTableStatus)
        {
            this.Id = linkTableStatus?.Id;
            this.Status = linkTableStatus?.Status;
            this.ErrorMessage = linkTableStatus?.ErrorMessage;
            this.StartTime = linkTableStatus?.StartTime;
            this.StopTime = linkTableStatus?.StopTime;
            this.LinkTableId = linkTableStatus?.LinkTableId;
            this.ErrorCode = linkTableStatus?.ErrorCode;
            this.LastProcessedData = linkTableStatus?.LastProcessedData;
            this.LastTransactionCommitTime = linkTableStatus?.LastTransactionCommitTime;
        }

        public string Id { get; }

        public string Status { get; }

        public string ErrorMessage { get; }

        public object StartTime { get; }

        public object StopTime { get; }

        public string LinkTableId { get; }

        public string ErrorCode { get; }

        public DateTimeOffset? LastProcessedData { get; }

        public DateTimeOffset? LastTransactionCommitTime { get; }
    }
}
