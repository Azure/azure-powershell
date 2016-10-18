﻿// ----------------------------------------------------------------------------------
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

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the AlertRuleResource or RuleGetResponse
    /// <para>Allows for different types of outputs for the cmdlets, i.e. all the specific output types will implement this interface and the base cmdlet always returns lists of this type.</para>
    /// </summary>
    public abstract class PSManagementItemDescriptor
    {
        /// <summary>
        /// Gets or sets the Id of the rule
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the Location of the rule
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the Name of the rule
        /// </summary>
        public string Name { get; set; }
    }
}
