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

namespace Microsoft.Azure.Commands.Insights.OutputClasses
{
    /// <summary>
    /// Wrapps around the RuleCondition and exposes all the localized strings as invariant/localized properties
    /// <para>It is an empty interface to allow for different types of outputs for the cmdlets, i.e. all the specific output types will implement this interface and the base cmdlet always returns lists of this type.</para>
    /// </summary>
    public interface IPSRuleCondition
    {
    }
}
