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

using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01;
using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01.Models;

namespace Microsoft.Azure.Commands.GuestConfiguration.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json.Linq;

    using Microsoft.Azure.Commands.Common.Authentication;
    using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
    using Microsoft.Azure.Commands.ResourceManager.Common;
    using Microsoft.Azure.Commands.GuestConfiguration.Helpers;
    using Microsoft.Azure.Commands.GuestConfiguration.Models;
    using Microsoft.Azure.Management.GuestConfiguration;
    using Microsoft.Azure.Management.GuestConfiguration.Models;
    using GuestConfigurationErrorResponseException = Management.GuestConfiguration.Models.ErrorResponseException;
    using StringResources = Microsoft.Azure.Commands.GuestConfiguration.Properties.Resources;
    using ResourceManagerErrorResponseException = Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01.Models.ErrorResponseException;

    /// <summary>
    /// Base class for Azure Guest configuration cmdlets
    /// </summary>
    public abstract class GuestConfigurationCmdletBase : AzureRMCmdlet
    {
        /// <summary>
        /// Guest configuration client
        /// </summary>
        private IGuestConfigurationClient _guestConfigurationClient;

        /// <summary>
        /// Azure policy client
        /// </summary>
        private IPolicyClient _policyClient;

        private string _initiativeId = null;

        /// <summary>
        /// Gets or sets the guest configuration client
        /// </summary>
        public IGuestConfigurationClient GuestConfigurationClient
        {
            get
            {
                return _guestConfigurationClient ??
                    (_guestConfigurationClient = AzureSession.Instance.ClientFactory.CreateArmClient<GuestConfigurationClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager));
            }
        }

        /// <summary>
        /// Gets or sets the Policy client
        /// </summary>
        public IPolicyClient PolicyClient
        {
            get
            {
                return _policyClient ??
                    (_policyClient = AzureSession.Instance.ClientFactory.CreateArmClient<PolicyClient>(DefaultContext, AzureEnvironment.Endpoint.ResourceManager));
            }
        }

        // Get all guest configuration policy assignment reports for a VM
        protected IEnumerable<PolicyStatusDetailed> GetPolicyStatusesDetailed(string resourceGroupName, 
            string vmName,
            IEnumerable<GuestConfigurationAssignment> gcrpAssignments, 
            bool isStatusHistoryCmdlet)
        {
            var gcPolicyAssignmentReportList = new List<PolicyStatusDetailed>();
            var gcPolicySetDefinitions = GetAllGuestConfigPolicySetDefinitions();

            if (gcPolicySetDefinitions == null || gcPolicySetDefinitions.Count() == 0)
            {
                return null;
            }

            foreach (var gcPolicySetDefinition in gcPolicySetDefinitions)
            {
                var gcAssignmentReports = GetPolicyStatusesDetailedByInitiativeId(resourceGroupName, vmName, gcPolicySetDefinition.Id, isStatusHistoryCmdlet, gcrpAssignments);
                if (gcAssignmentReports != null || gcAssignmentReports.Count() > 0)
                {
                    gcPolicyAssignmentReportList.AddRange(gcAssignmentReports);
                }
            }
            return gcPolicyAssignmentReportList;
        }

        // Get guest configuration policy assignments by initiative definition name
        protected IEnumerable<PolicyData> GetPolicyStatuses(string resourceGroupName,
            string vmName,
            IEnumerable<GuestConfigurationAssignment> gcrpAssignments,
            string initiativeName = null)
        {

            PolicySetDefinition[] policySetDefinitionsArray;

            if (!string.IsNullOrEmpty(initiativeName))
            {
                // Get policy set definition (initiative)
                try
                {
                    policySetDefinitionsArray = new PolicySetDefinition[] { PolicyClient.PolicySetDefinitions.GetBuiltIn(initiativeName) };
                }
                catch (ResourceManagerErrorResponseException exception) when (HttpStatusCode.NotFound.Equals(exception.Response.StatusCode))
                {
                    try
                    {
                        policySetDefinitionsArray = new PolicySetDefinition[] { PolicyClient.PolicySetDefinitions.Get(initiativeName) };
                    }
                    catch (ResourceManagerErrorResponseException exception_custom) when (HttpStatusCode.NotFound.Equals(exception_custom.Response.StatusCode))
                    {
                        var message = string.IsNullOrEmpty(this._initiativeId) ?
                            string.Format(StringResources.InitiativeWithThisNameNotFound, initiativeName) :
                            string.Format(StringResources.InitiativeWithThisIdNotFound, this._initiativeId);
                        throw new GuestConfigurationErrorResponseException(message);
                    }
                }

                if (policySetDefinitionsArray != null && policySetDefinitionsArray.Length == 1)
                {
                    var category = GetPolicySetCategory(policySetDefinitionsArray[0]);
                    if (Constants.GuestConfigurationCategory.ToLower() != category.ToLower())
                    {
                        var message = string.IsNullOrEmpty(this._initiativeId) ?
                            string.Format(StringResources.InitiativeWithThisNameNotOfCategoryGuestConfiguration, initiativeName) :
                            string.Format(StringResources.InitiativeWithThisIdNotOfCategoryGuestConfiguration, this._initiativeId);
                        throw new GuestConfigurationErrorResponseException(message);
                    }
                }
            }
            else
            {
                var policySetDefinitions = GetAllGuestConfigPolicySetDefinitions();
                policySetDefinitionsArray = policySetDefinitions != null ? policySetDefinitions.ToArray() : null;
            }
            var policyStatuses = GetPolicyStatusesHelper(policySetDefinitionsArray, gcrpAssignments);
            return policyStatuses;
        }

        // Get guest configuration policy statuses by initiative definition name
        protected IEnumerable<PolicyStatusDetailed> GetPolicyStatusesDetailedByInitiativeName(string resourceGroupName,
            string vmName,
            string initiativeName,
            IEnumerable<GuestConfigurationAssignment> gcrpAssignments)
        {
            var gcPolicyAssignments = GetPolicyStatuses(resourceGroupName, vmName, gcrpAssignments, initiativeName);
            var gcPolicyAssignmentReportList = new List<PolicyStatusDetailed>();

            var gcPolicyAssignmentsArray = gcPolicyAssignments.ToArray();

            // Sort assignments by policy display name
            Array.Sort(gcPolicyAssignmentsArray, (first, second) =>
            {
                return string.Compare(first.PolicyDisplayName, second.PolicyDisplayName, true);
            });

            foreach (var gcPolicyAssignment in gcPolicyAssignmentsArray)
            {
                var reportGuid = CommonHelpers.GetReportGUIDFromID(gcPolicyAssignment.LatestReportId);
                GuestConfigurationAssignmentReport gcrpReport = null;
                if (gcPolicyAssignment.LatestReportId != null)
                {
                    gcrpReport = GuestConfigurationClient.GuestConfigurationAssignmentReports.Get(resourceGroupName, gcPolicyAssignment.Configuration.Name, reportGuid, vmName);
                }
                gcPolicyAssignmentReportList.Add(new PolicyStatusDetailed(gcrpReport, gcPolicyAssignment));
            }

            return gcPolicyAssignmentReportList;
        }

        // Get guest configuration policy status history by initiative definition name
        protected IEnumerable<PolicyStatusDetailed> GetPolicyStatusesDetailedByInitiativeId(string resourceGroupName,
            string vmName,
            string initiativeId,
            bool isStatusHistoryCmdlet,
            IEnumerable<GuestConfigurationAssignment> gcrpAssignments)
        {
            var initiativeName = GetInitiativeNameFromId(initiativeId);
            var gcPolicyAssignmentReportList = GetPolicyStatusesDetailedByInitiativeName(resourceGroupName, vmName, initiativeName, gcrpAssignments);
            return gcPolicyAssignmentReportList;
        }

        // Get guest configuration policy status history by initiative definition name
        protected IEnumerable<PolicyStatus> GetPolicyStatusHistoryByInitiativeId(string resourceGroupName,
            string vmName,
            string initiativeId,
            IEnumerable<GuestConfigurationAssignment> gcrpAssignments,
            bool isShowStatusChangeOnlyPresent = false)
        {
            var initiativeName = GetInitiativeNameFromId(initiativeId);
            var gcPolicyAssignmentReportList = GetPolicyStatusHistory(resourceGroupName, vmName, gcrpAssignments, initiativeName, isShowStatusChangeOnlyPresent);
            return gcPolicyAssignmentReportList;
        }

        // Get guest configuration policy status history
        protected IEnumerable<PolicyStatus> GetPolicyStatusHistory(string resourceGroupName,
            string vmName,
            IEnumerable<GuestConfigurationAssignment> gcrpAssignments,
            string initiativeName = null,
            bool isShowStatusChangeOnlyPresent = false)
        {
            var gcPolicyAssignments = GetPolicyStatuses(resourceGroupName, vmName, gcrpAssignments, initiativeName);
            var gcPolicyAssignmentReportList = GetPolicyStatusHistoryForAssignments(resourceGroupName, vmName, initiativeName, gcPolicyAssignments, isShowStatusChangeOnlyPresent);
            return gcPolicyAssignmentReportList;
        }

        // Get guest configuration policy assignment report by reportId
        protected PolicyStatusDetailed GetPolicyStatusDetailedByReportId(string reportId)
        {
            var urlParameters = CommonHelpers.GetGCURLParameters(reportId);
            var reportGuid = CommonHelpers.GetReportGUIDFromID(reportId);

            if (urlParameters == null || reportGuid == null)
            {
                throw new ErrorResponseException(string.Format(StringResources.InvalidReportId, reportId));
            }

            PolicyStatusDetailed policyReport = null;
            if (urlParameters != null && urlParameters.AreParametersNotNullOrEmpty() && !string.IsNullOrEmpty(reportId))
            {
                GuestConfigurationAssignmentReport report = null;
                try
                {
                    report = GuestConfigurationClient.GuestConfigurationAssignmentReports.Get(urlParameters.ResourceGroupName, urlParameters.AssignmentName, reportGuid, urlParameters.VMName);
                }
                catch (GuestConfigurationErrorResponseException exception) when (HttpStatusCode.NotFound.Equals(exception.Response.StatusCode))
                {
                    this.WriteVerbose(string.Format(StringResources.NotFoundByReportId, reportId));
                    throw exception;
                }
                policyReport = new PolicyStatusDetailed(report, null);
            }
            return policyReport;
        }

        protected IEnumerable<GuestConfigurationAssignment> GetAllGCRPAssignments(string resourceGroupName, string vmName)
        {
            IEnumerable<GuestConfigurationAssignment> gcrpAssignments = null;
            try
            {
                gcrpAssignments = GuestConfigurationClient.GuestConfigurationAssignments.List(resourceGroupName, vmName);
            }
            catch (GuestConfigurationErrorResponseException exception) when (HttpStatusCode.NotFound.Equals(exception.Response.StatusCode))
            {
                this.WriteVerbose(string.Format(StringResources.InvalidRGOrVMName, resourceGroupName, vmName));
                throw exception;
            }
            return gcrpAssignments;
        }

        private string GetInitiativeNameFromId(string initiativeId)
        {
            var indexOfInitiativeName = initiativeId.LastIndexOf("/");
            if (indexOfInitiativeName < 0 || indexOfInitiativeName == initiativeId.Length - 1)
            {
                throw new ErrorResponseException(string.Format(StringResources.NoInitiativeNameFound, initiativeId));
            }
            var initiativeName = initiativeId.Substring(indexOfInitiativeName + 1);
            return initiativeName;
        }

        private string GetPolicySetCategory(PolicySetDefinition initiativeDefinition)
        {
            if (initiativeDefinition != null && initiativeDefinition.Metadata != null)
            {
                var categoryMetadata = JObject.Parse(initiativeDefinition.Metadata.ToString());
                var categoryMetadataDictionary = categoryMetadata.ToObject<Dictionary<string, object>>();
                if (categoryMetadataDictionary.ContainsKey("category"))
                {
                    return categoryMetadataDictionary["category"].ToString();
                }
            }

            return string.Empty;
        }

        private IEnumerable<PolicySetDefinition> GetAllGuestConfigPolicySetDefinitions()
        {
            var policySetDefinitions = PolicyClient.PolicySetDefinitions.List();
            if (policySetDefinitions == null || policySetDefinitions.Count() == 0)
            {
                return null;
            }

            var gcPolicySetDefinitions = policySetDefinitions.Where(policySetDef =>
            {
                var category = GetPolicySetCategory(policySetDef);
                return Constants.GuestConfigurationCategory.ToLower() == category.ToLower();
            });
            return gcPolicySetDefinitions;
        }

        private IEnumerable<PolicyData> GetPolicyStatusesHelper(PolicySetDefinition[] policySetDefinitions, IEnumerable<GuestConfigurationAssignment> gcrpAssignments)
        {
            var gcPolicyAssignmentsList = new List<PolicyData>();
            foreach (var policySetDefinition in policySetDefinitions)
            {
                // Get policy definitions in initiative
                var policyDefinitionIdsInInitiative = policySetDefinition.PolicyDefinitions.Select(
                    policyDef =>
                    {
                        return policyDef.PolicyDefinitionId;
                    }
                ).ToList();

                // Get all policy definitions in subscription
                var policyDefinitionsForTheInitiative = new List<PolicyDefinition>();

                foreach (var policyDefinitionIdInInitiative in policyDefinitionIdsInInitiative)
                {
                    var _initiativeName = GetInitiativeNameFromId(policyDefinitionIdInInitiative);
                    PolicyDefinition policyDef = null;
                    try
                    {
                        policyDef = PolicyClient.PolicyDefinitions.GetBuiltIn(_initiativeName);
                    }
                    catch(Microsoft.Rest.Azure.CloudException ex) when (HttpStatusCode.NotFound.Equals(ex.Response.StatusCode))
                    {
                        policyDef = PolicyClient.PolicyDefinitions.Get(_initiativeName);
                    }
                    
                    if (policyDef != null)
                    {
                        policyDefinitionsForTheInitiative.Add(policyDef);
                    }
                }

                var gcrp_AssignmentName_Assignment_Map = new Dictionary<string, GuestConfigurationAssignment>();
                foreach (var gcrpAssignment in gcrpAssignments)
                {
                    gcrp_AssignmentName_Assignment_Map.Add(gcrpAssignment.Name, gcrpAssignment);
                }

                // Get all gcrp assignments for the initiative - for policy definitions  of category "Guest Configuration", effectType "AuditIfNotExists" or "Audit"
                foreach (var policyDef in policyDefinitionsForTheInitiative)
                {
                    var policyRule = JObject.Parse(policyDef.PolicyRule.ToString());
                    var policyRuleDictionary = policyRule.ToObject<Dictionary<string, object>>();

                    var policyRuleThen = JObject.Parse(policyRuleDictionary["then"].ToString());
                    var policyRuleThenDictionary = policyRuleThen.ToObject<Dictionary<string, object>>();

                    var effectType = policyRuleThenDictionary["effect"].ToString();
                    var effectTypeLower = effectType.ToLower();

                    if (Constants.AuditIfNotExists != effectTypeLower && Constants.Audit != effectTypeLower)
                    {
                        continue;
                    }

                    var policyMetadata = JObject.Parse(policyDef.Metadata.ToString());
                    var policyMetadataDictionary = policyMetadata.ToObject<Dictionary<string, object>>();
                    var policyCategory = policyMetadataDictionary["category"].ToString().ToLower();
                    if (Constants.GuestConfigurationCategory != policyCategory)
                    {
                        continue;
                    }

                    string guestConfigurationAssignmentNameInPolicy = null;

                    if (Constants.AuditIfNotExists == effectTypeLower)
                    {
                        var policyRuleThenDetails = JObject.Parse(policyRuleThenDictionary["details"].ToString());
                        var policyRuleDetailsDictionary = policyRuleThenDetails.ToObject<Dictionary<string, object>>();
                        guestConfigurationAssignmentNameInPolicy = policyRuleDetailsDictionary["name"].ToString();
                    }
                    else if (Constants.Audit == effectTypeLower)
                    {
                        var policyRuleIf = JObject.Parse(policyRuleDictionary["if"].ToString());
                        var policyRuleIfDictionary = policyRuleIf.ToObject<Dictionary<string, object>>();
                        var policyRuleIfAllOf = policyRuleIfDictionary["allOf"];
                        var policyRuleIfAllOfJArray = JArray.FromObject(policyRuleIfAllOf);
                        var guestConfigurationAssignmentNameInPolicyArray = policyRuleIfAllOfJArray.Single(
                             x => x.Value<string>("field") == "name"
                        );
                        guestConfigurationAssignmentNameInPolicy = guestConfigurationAssignmentNameInPolicyArray.Value<string>("equals");
                    }

                    if (!string.IsNullOrEmpty(guestConfigurationAssignmentNameInPolicy) && gcrp_AssignmentName_Assignment_Map.ContainsKey(guestConfigurationAssignmentNameInPolicy))
                    {
                        var gcrpAsgnment = gcrp_AssignmentName_Assignment_Map[guestConfigurationAssignmentNameInPolicy];
                        if (gcrpAsgnment != null)
                        {
                            gcPolicyAssignmentsList.Add(new PolicyData(gcrpAsgnment, policyDef.DisplayName));
                        }
                    }
                }
            }
            return gcPolicyAssignmentsList;
        }

        private IEnumerable<PolicyStatus> GetPolicyStatusHistoryForAssignments(string resourceGroupName,
            string vmName,
            string initiativeName,
            IEnumerable<PolicyData> policyStatuses,
            bool isShowStatusChangeOnlyPresent = false)
        {
            var gcPolicyAssignmentReportList = new List<PolicyStatus>();

            var policyStatusesArray = policyStatuses.ToArray();

            // Sort assignments by policy display name
            Array.Sort(policyStatusesArray, (first, second) =>
            {
                return string.Compare(first.PolicyDisplayName, second.PolicyDisplayName, true);
            });

            foreach (var gcPolicyAssignment in policyStatusesArray)
            {
                var gcrpReportss = GuestConfigurationClient.GuestConfigurationAssignmentReports.List(resourceGroupName, gcPolicyAssignment.Configuration.Name, vmName);
                var gcrpReportsList = gcrpReportss.Value;

                if (isShowStatusChangeOnlyPresent)
                {
                    gcrpReportsList = GetReportsWithOnlyStatusChanges(gcrpReportsList);
                }

                if (gcrpReportsList != null)
                {
                    var statusHistoryList = new List<PolicyStatus>();
                    foreach (var gcrpReport in gcrpReportsList)
                    {
                        statusHistoryList.Add(new PolicyStatus(gcrpReport, gcPolicyAssignment));
                    }
                    gcPolicyAssignmentReportList.AddRange(statusHistoryList);
                }
            }
            return gcPolicyAssignmentReportList;
        }

        // Get those reports with adjacent compliance status changes
        private List<GuestConfigurationAssignmentReport> GetReportsWithOnlyStatusChanges(IList<GuestConfigurationAssignmentReport> reports)
        {
            var resultList = new List<GuestConfigurationAssignmentReport>();
            if(reports == null || reports.Count == 0)
            {
                return resultList;
            }

            var index = 0;
            string mostRecentComplianceStatus = null;
            foreach (var report in reports)
            {
                if (index == 0)
                {
                    resultList.Add(report);
                    mostRecentComplianceStatus = report.Properties.ComplianceStatus;
                }
                else if (!string.Equals(mostRecentComplianceStatus, report.Properties.ComplianceStatus, StringComparison.InvariantCultureIgnoreCase))
                {
                    resultList.Add(report);
                    mostRecentComplianceStatus = report.Properties.ComplianceStatus;
                }
                index++;
            }
            return resultList;
        }
    }
}