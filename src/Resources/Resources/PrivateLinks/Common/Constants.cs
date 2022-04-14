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

namespace Microsoft.Azure.Commands.Resources.PrivateLinks.Common
{
    class Constants
    {
        public class ParameterSetNames
        {
            public const string GetParameterSet = "GetOperation";
            public const string ListParameterSet = "ListOperation";
            public const string PutParameterSet = "PutOperation";
            public const string DeleteParameterSet = "DeleteOperation";
            public const string ObjectParameterSet = "PrivateLinkObject";
            public const string PutPLAssociationParameterSet = "PutPLAOperation";
            public const string GetPLAssociationParameterSet = "GetPLAOperation";
            public const string DeletePLAssociationParameterSet = "DeletePLAOperation";
            public const string PLAObjectParameterSet = "PrivateLinkAssociationObject";
        }

        public class HelpMessages
        {
            public const string SubscriptionId = "Subscription Id of the subscription";
            public const string ResourceGroupName = "The name of the resource group.";
            public const string PrivateLinkName = "The name of the private link.";
            public const string PrivateLinkObject = "The private link object.";
            public const string PrivateLinkLocation = "The private link location.";
            public const string ManagementGroupId = "The management group Id.";
            public const string PrivateLinkAssociationId = "The private link association Id.";
            public const string PrivateLinkResourceId = "The resource management private link resource Id.";
            public const string PublicNetworkAccess = "The public network access is enabled/disabled.";
            public const string PrivateLinkAssociationObject = "The private link association object.";
            public const string HelpMessage = "Do not ask for confirmation.";
        }
    }
}
