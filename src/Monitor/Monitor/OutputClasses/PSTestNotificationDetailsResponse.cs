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

using Microsoft.Azure.Management.Monitor.Models;

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.Azure.Management.Internal.Resources.Utilities.Models;

    /// <summary>
    /// Wraps around an Action Group.
    /// </summary>
    public class PSTestNotificationDetailsResponse
    {
        /// <summary>Gets or sets the context</summary>
        public Context Context { get; set; }

        /// <summary>Gets or sets the state</summary>
        public string State { get; set; }

        /// <summary>Gets or sets the completedTime</summary>
        public DateTimeOffset CompletedTime { get; set; }

        /// <summary>Gets or sets the createdTime</summary>
        public DateTimeOffset CreatedTime { get; set; }

        /// <summary>Gets or sets the actionDetails</summary>
        public ICollection<ActionDetail> ActionDetails { get; set; }

        /// <summary>Initializes a new instance of the PSActionGroup class.</summary>
        /// <param name="actionGroupResource">the action group resource</param>
        public PSTestNotificationDetailsResponse(TestNotificationDetailsResponse actionGroupResource)
        {
            this.Context = actionGroupResource.Context;
            this.State = actionGroupResource.State;
            this.CreatedTime = DateTime.Parse(actionGroupResource.CreatedTime);
            this.CompletedTime = DateTime.Parse(actionGroupResource.CompletedTime);
            this.ActionDetails = this.ActionDetails;
        }
    }
}
