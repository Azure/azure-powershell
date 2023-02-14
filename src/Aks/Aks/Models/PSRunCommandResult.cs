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

namespace Microsoft.Azure.Commands.Aks.Models
{
    public class PSRunCommandResult
    {
        //
        // Summary:
        //     Gets the command id.
        public string Id { get; set; }
        //
        // Summary:
        //     Gets provisioning State
        public string ProvisioningState { get; set; }
        //
        // Summary:
        //     Gets the exit code of the command
        public int? ExitCode { get; set; }
        //
        // Summary:
        //     Gets the time when the command started.
        public DateTime? StartedAt { get; set; }
        //
        // Summary:
        //     Gets the time when the command finished.
        public DateTime? FinishedAt { get; set; }
        //
        // Summary:
        //     Gets the command output.
        public string Logs { get; set; }
        //
        // Summary:
        //     Gets an explanation of why provisioningState is set to failed (if so).
        public string Reason { get; set; }
    }
}
