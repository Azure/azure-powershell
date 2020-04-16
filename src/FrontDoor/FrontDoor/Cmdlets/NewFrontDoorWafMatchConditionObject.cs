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

using Microsoft.Azure.Commands.FrontDoor.Common;
using Microsoft.Azure.Commands.FrontDoor.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.FrontDoor.Cmdlets
{
    /// <summary>
    /// Defines the New-AzFrontDoorWafMatchConditionObject cmdlet.
    /// </summary>
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "FrontDoorWafMatchConditionObject"), OutputType(typeof(PSMatchCondition))]
    public class NewFrontDoorWafMatchConditionObject : AzureFrontDoorCmdletBase
    {

        /// <summary>
        /// Match Variable. 
        /// Possible values include: 'RemoteAddr', 'RequestMethod', 'QueryString', 'PostArgs',
        /// 'RequestUri', 'RequestHeader', 'RequestBody', 'SocketAddr'
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Match Variable. Possible values include: 'RemoteAddr', 'RequestMethod', 'QueryString', 'PostArgs','RequestUri', 'RequestHeader', 'RequestBody', 'SocketAddr'")]
        [PSArgumentCompleter("RemoteAddr", "RequestMethod", "QueryString", "PostArgs", "RequestUri", "RequestHeader", "RequestBody", "SocketAddr")]
        public string MatchVariable { get; set; }

        /// <summary>
        /// Describes operator to be matched.
        /// Possible values include: 'Any', 'IPMatch', 'GeoMatch', 'Equal',
        /// 'Contains', 'LessThan', 'GreaterThan', 'LessThanOrEqual',
        /// 'GreaterThanOrEqual', 'BeginsWith', 'EndsWith'
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "Describes operator to be matched. Possible values include: 'Any', 'IPMatch', 'GeoMatch', 'Equal', 'Contains', 'LessThan', 'GreaterThan', 'LessThanOrEqual', 'GreaterThanOrEqual', 'BeginsWith', 'EndsWith', 'RegEx'")]
        [PSArgumentCompleter("Any", "IPMatch", "GeoMatch", "Equal", "Contains", "LessThan", "GreaterThan", "LessThanOrEqual", "GreaterThanOrEqual", "BeginsWith", "EndsWith", "RegEx")]
        public string OperatorProperty { get; set; }

        /// <summary>
        /// Match value.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Match value.")]
        public string[] MatchValue { get; set; }

        /// <summary>
        /// Name of selector in RequestHeader or RequestBody to be matched
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Name of selector in RequestHeader or RequestBody to be matched")]
        public string Selector { get; set; }

        /// <summary>
        /// Describes if this is negate condition or not
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Describes if this is negate condition or not. Default value is false")]
        public bool NegateCondition { get; set; }

        /// <summary>
        /// Transforms value.
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Transforms to apply. Possible values include: 'Lowercase', 'Uppercase', 'Trim', 'UrlDecode', 'UrlEncode', 'RemoveNulls'.")]
        [PSArgumentCompleter("Lowercase", "Uppercase", "Trim", "UrlDecode", "UrlEncode", "RemoveNulls")]
        public string[] Transform { get; set; }

        public override void ExecuteCmdlet()
        {
            ValidateArguments();

            var matchCondition = new PSMatchCondition
            {
                MatchVariable = MatchVariable,
                MatchValue = MatchValue?.ToList(),
                NegateCondition = !this.IsParameterBound(c => c.NegateCondition) ? false : NegateCondition,
                OperatorProperty = OperatorProperty,
                Selector = Selector,
                Transform = Transform?.ToList()
            };
            WriteObject(matchCondition);
        }

        private void ValidateArguments()
        {
            if (OperatorProperty == PSOperatorProperty.Any.ToString() && MatchValue != null)
            {
                throw new PSArgumentException(nameof(MatchValue));
            }

            if (OperatorProperty != PSOperatorProperty.Any.ToString() && (MatchValue == null || MatchValue.Length == 0))
            {
                throw new PSArgumentNullException(nameof(MatchValue));
            }
        }
    }
}
