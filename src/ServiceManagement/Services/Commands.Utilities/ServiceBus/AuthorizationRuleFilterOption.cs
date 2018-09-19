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
using Microsoft.ServiceBus.Messaging;

namespace Microsoft.WindowsAzure.Commands.Utilities.ServiceBus
{
    public class AuthorizationRuleFilterOption
    {
        #region Filtering Level

        /// <summary>
        /// Must be specified. This option restricts the search on namespace level.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Must specified along with EntityType. This option restricts the search on this entity level.
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Must specified along with EntityName. This option restricts the search on this entity level.
        /// </summary>
        public ServiceBusEntityType EntityType { get; set; }

        #endregion

        #region Filtering options

        /// <summary>
        /// If specified gets the rule that matches this name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// If specified the filter will get all authorization rules with the provided permission
        /// </summary>
        public List<AccessRights> Permission { get; set; }

        /// <summary>
        /// If specified the filter will get all authorization rules for the specified entity types.
        /// </summary>
        public List<ServiceBusEntityType> EntityTypes { get; set; }

        /// <summary>
        /// If specified the filter will get all authorization rules for the specified authorization types.
        /// </summary>
        public List<AuthorizationType> AuthorizationType { get; set; }

        #endregion
    }
}
