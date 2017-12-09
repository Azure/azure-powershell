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

namespace Microsoft.Azure.Commands.ManagementGroups.Common
{
    class Constants
    {
        public class ParameterSetNames
        {
            public const string GroupOperationsParameterSet = "GroupOperations";
            public const string SubscriptionOperationsParameterSet = "SubscriptionOperations";
        }

        public class HelpMessages
        {
            public const string SubscriptionId = "Subscription Id";
            public const string GroupId = "Group Id";
            public const string Recurse = "Recurse";
            public const string ParentId = "Parent Id";
            public const string GroupName = "Group Name";
            public const string DisplayName = "Display Name";
            public const string Expand = "Expand";
        }
    }
}
