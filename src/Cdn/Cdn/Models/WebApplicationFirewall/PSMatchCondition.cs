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

using Microsoft.Azure.Management.Cdn.Models;
using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Cdn.Models.WebApplicationFirewall
{
    /// <summary>
    /// A custom rule applied to a WAF profile.
    /// </summary>
    public class PSMatchCondition
    {
        /// <summary>
        /// Match variable to compare against.
        /// </summary>
        public PSMatchVariable MatchVariable { get; set; }

        /// <summary>
        /// Selector that can be used to match a specific key for QueryString, RequestUri, RequestHeaders or RequestBody.
        /// </summary>
        public string Selector { get; set; }
        
        /// <summary>
        /// The operator to be matched.
        /// </summary>
        public PSOperator Operator { get; set; }

        /// <summary>
        /// Whether the result of this condition should be negated.
        /// </summary>
        public bool NegateCondition { get; set; }

        /// <summary>
        /// List of possible values to match.
        /// </summary>
        public ICollection<string> MatchValues { get; set; }

        /// <summary>
        /// List of transforms to apply before matching.
        /// </summary>
        public ICollection<PSTransform> Transforms { get; set; }
    }
}
