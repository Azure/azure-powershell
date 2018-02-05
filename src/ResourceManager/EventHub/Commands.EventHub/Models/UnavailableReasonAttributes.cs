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
// ----------------------------------------------------------------------------------.

namespace Microsoft.Azure.Commands.EventHub.Models
{

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for UnavailableReason.
    /// </summary>
    public enum UnavailableReasonAttributes
    {
        [EnumMember(Value = "None")]
        None,
        [EnumMember(Value = "InvalidName")]
        InvalidName,
        [EnumMember(Value = "SubscriptionIsDisabled")]
        SubscriptionIsDisabled,
        [EnumMember(Value = "NameInUse")]
        NameInUse,
        [EnumMember(Value = "NameInLockdown")]
        NameInLockdown,
        [EnumMember(Value = "TooManyNamespaceInCurrentSubscription")]
        TooManyNamespaceInCurrentSubscription
    }
}