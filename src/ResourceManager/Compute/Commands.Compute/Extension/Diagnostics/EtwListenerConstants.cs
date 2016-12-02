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

using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Extension.Diagnostics
{
    public static class EtwListenerConstants
    {
        /// <summary>
        /// Extension version that matches this client tool
        /// </summary>
        public const string CurrentVersion = "1.0";

        /// <summary>
        /// Default etw listener port number
        /// </summary>
        public const int EtwListenerPortNumber = 810;

        /// <summary>
        /// Default etw listener port map
        /// </summary>
        public static readonly Dictionary<string, int> EtwListenerPortMap = new Dictionary<string, int> { { "etw", EtwListenerPortNumber } };

        /// <summary>
        /// Default etw listener extension info
        /// </summary>
        public static readonly ComputeExtension EtwListenerExtension = new ComputeExtension
        {
            Name = "VSETWTraceListenerService",
            Publisher = "Microsoft.VisualStudio.Azure.ETWTraceListenerService",
            Type = "VSETWTraceListenerService"
        };
    }
}
