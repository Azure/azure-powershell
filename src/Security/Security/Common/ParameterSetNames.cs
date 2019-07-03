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

namespace Microsoft.Azure.Commands.Security.Common
{
    public static class ParameterSetNames
    {
        public const string GeneralScope = "GeneralScope";
        public const string SubscriptionScope = "SubscriptionScope";
        public const string ResourceGroupScope = "ResourceGroupScope";
        public const string ScopeLevelResource = "ScopeLevelResource";
        public const string SubscriptionLevelResource = "SubscriptionLevelResource";
        public const string ResourceGroupLevelResource = "ResourceGroupLevelResource";
        public const string ResourceId = "ResourceId";
        public const string InputObject = "InputObject";
        public const string PolicyOn = "PolicyOn";
        public const string PolicyOff = "PolicyOff";
    }
}
