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

namespace Microsoft.WindowsAzure.Commands.Storage.Common
{
    using System.Threading.Tasks;

    /// <summary>
    /// Async prompt confirm task completion source
    /// </summary>
    internal class ConfirmTaskCompletionSource : TaskCompletionSource<bool>
    {
        public string Message { get; private set; }

        /// <summary>
        /// Construct a ConfirmTaskCompletionSource object
        /// </summary>
        /// <param name="message">Confirmation message</param>
        public ConfirmTaskCompletionSource(string message) : base()
        {
            Message = message;
        }
    }
}
