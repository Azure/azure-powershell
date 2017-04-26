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

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// An Azure subscription
    /// </summary>
    public interface IAzureSubscription : IExtensibleModel
    {
        /// <summary>
        /// The subscription identifier (a GUID)
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// The firendly name for the subscription
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The subscription state. For example, whether the subscription is active or disabled
        /// </summary>
        string State { get; set; }
    }
}
