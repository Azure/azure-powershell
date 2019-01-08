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

namespace Microsoft.Azure.Commands.Resources.ManagementGroups.Common
{
    class Constants
    {
        public class ParameterSetNames
        {
            public const string GetParameterSet = "GetOperation";
            public const string ListParameterSet = "ListOperation";
            public const string GroupOperationsParameterSet = "GroupOperations";
            public const string SubscriptionOperationsParameterSet = "SubscriptionOperations";
            public const string ManagementGroupParameterSet = "ManagementGroupObject";
            public const string ParentGroupParameterSet = "ParentGroupObject";
            public const string ParentGroupAndManagementGroupParameterSet = "ParentAndManagementGroupObject";
        }

        public class HelpMessages
        {
            public const string SubscriptionId = "Subscription Id of the subscription associated witht the management";
            public const string GroupId = "Management Group Id";
            public const string Recurse = "Recursively list the children of the management group";
            public const string ParentId = "Parent Id of the management group";
            public const string GroupName = "Management Group Id";
            public const string DisplayName = "Display Name of the management group";
            public const string Expand = "Expand the output to list the children of the management group";
            public const string Force = "Force the action and skip confirmations";
            public const string InputObject = "Input Object from the Get call";
            public const string ParentObject = "Parent Object";
        }

        public static string GroupUrlPrefix = "/providers/Microsoft.Management/managementGroups/";
        public static string GroupType = "/providers/Microsoft.Management/managementGroups";
    }
}
