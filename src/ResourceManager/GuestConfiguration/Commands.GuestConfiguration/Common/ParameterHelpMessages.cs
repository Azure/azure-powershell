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

namespace Microsoft.Azure.Commands.GuestConfiguration.Common
{
    /// <summary>
    /// Parameter help messages
    /// </summary>
    public static class ParameterHelpMessages
    {
        public const string ResourceGroupName = "Resource group name.";
        public const string VMName = "VM name.";
        public const string InitiativeName = "Name of a policy where definition type is Initiative and category is Guest Configuration";
        public const string InitiativeId = "Definition Id of a policy where definition type is Initiative and category is Guest Configuration";
        public const string ReportId = "Report Id of a Guest Configuration policy report. A policy where definition type is Initiative and category is Guest Configuration must be assigned to a scope to get reports.";
        public const string DetailedSwitch = "Retrieves detailed Guest Configuration policy report. It includes compliance status and reasons for the resources for which the policy checks compliance, and more.";
        public const string LatestSwitch = "Limits the detailed reports to the latest one, one latest report for each policy in an initiative(policy set).";
    }
}