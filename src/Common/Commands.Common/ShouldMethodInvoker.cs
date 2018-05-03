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
using System.Management.Automation;
using System.Threading;

namespace Microsoft.WindowsAzure.Commands.Common
{
    /// <summary>
    /// Tracks the type of should method being executed
    /// </summary>
    internal enum ShouldMethodType
    {
        ShouldProcess= 0,
        ShouldContinue = 1,
        HasTransaction = 2
    }

    /// <summary>
    /// Representation of a deferred powershell method execution for SHouldProcess or SHouldContinue which must execute on the cmdlet thread
    /// </summary>
    internal class ShouldMethodInvoker
    {
        public object SyncObject { get; set; }

        public ManualResetEventSlim Finished { get; set; }

        public Func<Cmdlet, bool> ShouldMethod { get; set; }

        public bool MethodResult { get; set; }

        public Exception ThrownException { get; set; }

        public ShouldMethodType MethodType { get; set; }
    }
}
