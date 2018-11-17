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

using Microsoft.Azure.Commands.Insights.TransitionalClasses;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the AlertRuleResource, but in the old namespace
    /// </summary>
    public class AlertRuleResource : Monitor.Models.AlertRuleResource
    {
        private RuleCondition thisCondition;
        private IList<RuleAction> thisActions;

        /// <summary>
        /// Gets or sets the Condition of the AlertRuleResource
        /// </summary>
        public new RuleCondition Condition
        {
            get
            {
                return this.thisCondition;
            }
            set
            {
                base.Condition = TransitionHelpers.ToMirrorNamespace(value);
                this.thisCondition = value;
            }
        }

        /// <summary>
        /// Gets or sets the Actions list of the AlertResource
        /// </summary>
        public new IList<RuleAction> Actions
        {
            get
            {
                return this.thisActions;
            }
            set
            {
                base.Actions = value?.Select(TransitionHelpers.ToMirrorNamespace).ToList();
                this.thisActions = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the AlertRuleResource class.
        /// </summary>
        public AlertRuleResource()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the AlertRuleResource class.
        /// </summary>
        /// <param name="alertRuleResource">The AlertRuleResource object</param>
        public AlertRuleResource(Monitor.Models.AlertRuleResource alertRuleResource)
            : base(
                  location: alertRuleResource?.Location,
                  id: alertRuleResource?.Id,
                  name: alertRuleResource?.Name,
                  type: alertRuleResource?.Type,
                  tags: alertRuleResource?.Tags,
                  alertRuleResourceName: alertRuleResource?.AlertRuleResourceName,
                  description: alertRuleResource?.Description,
                  actions: alertRuleResource?.Actions,
                  isEnabled: alertRuleResource == null ? false : alertRuleResource.IsEnabled,
                  lastUpdatedTime: alertRuleResource?.LastUpdatedTime,
                  condition: alertRuleResource?.Condition)
        {
            if (alertRuleResource != null)
            {
                this.Condition = alertRuleResource.Condition != null ? TransitionHelpers.ToMirrorNamespace(alertRuleResource.Condition) : null;
                this.Actions = alertRuleResource.Actions?.Select(TransitionHelpers.ToMirrorNamespace).ToList();
            }
        }
    }
}
