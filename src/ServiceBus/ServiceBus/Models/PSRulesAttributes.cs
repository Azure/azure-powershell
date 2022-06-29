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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ServiceBus.Models;

namespace Microsoft.Azure.Commands.ServiceBus.Models
{
    public class PSRulesAttributes
    {
        /// <summary>
        /// Initializes a new instance of the Rule class.
        /// </summary>
        public PSRulesAttributes()
        {
            Name = string.Empty;
            Id = string.Empty;
            Type = string.Empty;
            Action = new PSActionAttributes();
            FilterType = Management.ServiceBus.Models.FilterType.SqlFilter;
            SqlFilter = new PSSQLFilterAttributes();
            CorrelationFilter = new PSCorrelationFilterAttributes();
        }

        /// <summary>
        /// Initializes a new instance of the Rule class.
        /// </summary>
        /// <param name="rule"></param>
        public PSRulesAttributes(Rule rule)
        {
            Name = rule.Name;
            Id = rule.Id;
            Type = rule.Type;
            Action = new ServiceBus.Models.PSActionAttributes(rule.Action);
            FilterType = rule.FilterType;
            SqlFilter = new PSSQLFilterAttributes(rule.SqlFilter);
            CorrelationFilter = new PSCorrelationFilterAttributes(rule.CorrelationFilter);
        }


        /// <summary>
        /// Gets or sets the name of the rule is in
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Id of the rule
        /// </summary>
        public string Id { get; set; }


        public string Type { get; set; }

        /// <summary>
        /// Gets or sets represents the filter actions which are allowed for
        /// the transformation of a message that have been matched by a filter
        /// expression.
        /// </summary>
        public PSActionAttributes Action { get; set; }

        /// <summary>
        /// Gets or sets filter type that is evaluated against a
        /// BrokeredMessage. Possible values include: 'SqlFilter',
        /// 'CorrelationFilter'
        /// </summary>
        public FilterType? FilterType { get; set; }

        /// <summary>
        /// Gets or sets properties of sqlFilter
        /// </summary>
        public PSSQLFilterAttributes SqlFilter { get; set; }

        /// <summary>
        /// Gets or sets properties of correlationFilter
        /// </summary>
        public PSCorrelationFilterAttributes CorrelationFilter { get; set; }

    }
}
