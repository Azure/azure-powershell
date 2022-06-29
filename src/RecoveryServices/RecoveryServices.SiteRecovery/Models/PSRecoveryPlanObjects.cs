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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    //
    // Summary:
    //     Recovery plan action custom details.
    public class ASRRecoveryPlanActionDetails
    {
        //
        // Summary:
        //     Initializes a new instance of the RecoveryPlanActionDetails class.
        public ASRRecoveryPlanActionDetails() { }
    }

    //
    // Summary:
    //     Recovery plan Automation runbook action details.
    public class ASRRecoveryPlanAutomationRunbookActionDetails : ASRRecoveryPlanActionDetails
    {
        //
        // Summary:
        //     Initializes a new instance of the RecoveryPlanAutomationRunbookActionDetails
        //     class.
        public ASRRecoveryPlanAutomationRunbookActionDetails(RecoveryPlanAutomationRunbookActionDetails automationRunbookActionDetails)
        {
            this.RunbookId = automationRunbookActionDetails.RunbookId;
            this.Timeout = automationRunbookActionDetails.Timeout;
            this.FabricLocation = automationRunbookActionDetails.FabricLocation;

        }

        public static RecoveryPlanAutomationRunbookActionDetails
            getSrsRecoveryPlanAutomationRunbookActionDetails(ASRRecoveryPlanAutomationRunbookActionDetails automationRunbookActionDetails)
        {
            var action = new RecoveryPlanAutomationRunbookActionDetails();
            action.RunbookId = automationRunbookActionDetails.RunbookId;
            action.Timeout = automationRunbookActionDetails.Timeout;
            action.FabricLocation = automationRunbookActionDetails.FabricLocation;

            return action;
        }
        //
        // Summary:
        //     Gets or sets the runbook ARM Id.
        public string RunbookId { get; set; }
        //
        // Summary:
        //     Gets or sets the runbook timeout.
        public string Timeout { get; set; }
        //
        // Summary:
        //     Gets or sets the fabric location. Possible values include: 'Primary', 'Recovery'
        public string FabricLocation { get; set; }
    }

    //
    // Summary:
    //     Recovery plan manual action details.
    public class ASRRecoveryPlanManualActionDetails : ASRRecoveryPlanActionDetails
    {
        //
        // Summary:
        //     Initializes a new instance of the RecoveryPlanManualActionDetails class.
        public ASRRecoveryPlanManualActionDetails(RecoveryPlanManualActionDetails manualActionDetails)
        {
            this.Description = manualActionDetails.Description;
        }

        public static RecoveryPlanManualActionDetails
            getSrsRecoveryPlanAutomationRunbookActionDetails(ASRRecoveryPlanManualActionDetails automationRunbookActionDetails)
        {
            var action = new RecoveryPlanManualActionDetails();
            action.Description = automationRunbookActionDetails.Description;

            return action;
        }

        //
        // Summary:
        //     Gets or sets the manual action description.
        public string Description { get; set; }
    }

    //
    // Summary:
    //     Recovery plan script action details.
    public class ASRRecoveryPlanScriptActionDetails : ASRRecoveryPlanActionDetails
    {
        //
        // Summary:
        //     Initializes a new instance of the RecoveryPlanScriptActionDetails class.
        public ASRRecoveryPlanScriptActionDetails(RecoveryPlanScriptActionDetails recoveryPlanScriptActionDetails)
        {
            this.Path = recoveryPlanScriptActionDetails.Path;
            this.Timeout = recoveryPlanScriptActionDetails.Timeout;
            this.FabricLocation = recoveryPlanScriptActionDetails.FabricLocation;
        }

        public static RecoveryPlanScriptActionDetails getRecoveryPlanScriptActionDetails(ASRRecoveryPlanScriptActionDetails recoveryPlanScriptActionDetails)
        {
            var actionDetails = new RecoveryPlanScriptActionDetails();
            actionDetails.Path = recoveryPlanScriptActionDetails.Path;
            actionDetails.Timeout = recoveryPlanScriptActionDetails.Timeout;
            actionDetails.FabricLocation = recoveryPlanScriptActionDetails.FabricLocation;

            return actionDetails;
        }
        //
        // Summary:
        //     Gets or sets the script path.
        public string Path { get; set; }
        //
        // Summary:
        //     Gets or sets the script timeout.
        public string Timeout { get; set; }
        //
        // Summary:
        //     Gets or sets the fabric location. Possible values include: 'Primary', 'Recovery'
        public string FabricLocation { get; set; }

    }

    //
    // Summary:
    //     Recovery plan action details.
    public class ASRRecoveryPlanAction
    {
        //
        // Summary:
        //     Initializes a new instance of the RecoveryPlanAction class.
        public ASRRecoveryPlanAction(RecoveryPlanAction srsRecoveryPlanAction)
        {
            this.ActionName = srsRecoveryPlanAction.ActionName;
            this.FailoverTypes = srsRecoveryPlanAction.FailoverTypes;
            this.FailoverDirections = srsRecoveryPlanAction.FailoverDirections;

            if (srsRecoveryPlanAction.CustomDetails is RecoveryPlanAutomationRunbookActionDetails)
            {
                this.CustomDetails = new ASRRecoveryPlanAutomationRunbookActionDetails(
                    srsRecoveryPlanAction.CustomDetails as RecoveryPlanAutomationRunbookActionDetails);
            }
            else if (srsRecoveryPlanAction.CustomDetails is RecoveryPlanManualActionDetails)
            {
                this.CustomDetails = new ASRRecoveryPlanManualActionDetails(
                        srsRecoveryPlanAction.CustomDetails as RecoveryPlanManualActionDetails);
            }
            else if (srsRecoveryPlanAction.CustomDetails is RecoveryPlanScriptActionDetails)
            {
                this.CustomDetails = new ASRRecoveryPlanScriptActionDetails(
                        srsRecoveryPlanAction.CustomDetails as RecoveryPlanScriptActionDetails);
            }
        }
        //
        // Summary:
        //     Gets or sets the action name.
        public string ActionName { get; set; }
        //
        // Summary:
        //     Gets or sets the list of failover types.
        public IList<string> FailoverTypes { get; set; }
        //
        // Summary:
        //     Gets or sets the list of failover directions.
        public IList<string> FailoverDirections { get; set; }
        //
        // Summary:
        //     Gets or sets the custom details.
        public ASRRecoveryPlanActionDetails CustomDetails { get; set; }

        //
        // Summary:
        //     Initializes a new instance of the RecoveryPlanAction class.
        public static RecoveryPlanAction GetSrsRecoveryPlanAction(ASRRecoveryPlanAction asrRecoveryPlanAction)
        {
            var recoveryPlanAction = new RecoveryPlanAction();

            recoveryPlanAction.ActionName = asrRecoveryPlanAction.ActionName;
            recoveryPlanAction.FailoverTypes = asrRecoveryPlanAction.FailoverTypes;
            recoveryPlanAction.FailoverDirections = asrRecoveryPlanAction.FailoverDirections;

            if (asrRecoveryPlanAction.CustomDetails is ASRRecoveryPlanAutomationRunbookActionDetails)
            {
                recoveryPlanAction.CustomDetails = ASRRecoveryPlanAutomationRunbookActionDetails.getSrsRecoveryPlanAutomationRunbookActionDetails(
                    (ASRRecoveryPlanAutomationRunbookActionDetails)asrRecoveryPlanAction.CustomDetails);
            }
            else if (asrRecoveryPlanAction.CustomDetails is ASRRecoveryPlanManualActionDetails)
            {
                recoveryPlanAction.CustomDetails = ASRRecoveryPlanManualActionDetails.getSrsRecoveryPlanAutomationRunbookActionDetails(
                        (ASRRecoveryPlanManualActionDetails)asrRecoveryPlanAction.CustomDetails);
            }
            else if (asrRecoveryPlanAction.CustomDetails is ASRRecoveryPlanScriptActionDetails)
            {
                recoveryPlanAction.CustomDetails = ASRRecoveryPlanScriptActionDetails.getRecoveryPlanScriptActionDetails(
                        (ASRRecoveryPlanScriptActionDetails)asrRecoveryPlanAction.CustomDetails);
            }

            return recoveryPlanAction;
        }

    }

    public class ASRRecoveryPlanGroup
    {
        public ASRRecoveryPlanGroup()
        {
        }

        public ASRRecoveryPlanGroup(
            RecoveryPlanGroup recoveryPlanGroup,
            IList<ReplicationProtectedItem> replicationProtectedItems = null)
        {
            if (recoveryPlanGroup != null)
            {
                this.GroupType = recoveryPlanGroup.GroupType.ToString();
                if (recoveryPlanGroup.StartGroupActions != null)
                {
                    this.StartGroupActions = recoveryPlanGroup.StartGroupActions.ToList().
                        ConvertAll(startGroupAction => new ASRRecoveryPlanAction(startGroupAction));
                }

                if (recoveryPlanGroup.EndGroupActions != null)
                {
                    this.EndGroupActions = recoveryPlanGroup.EndGroupActions.ToList().
                        ConvertAll(endGroupActions => new ASRRecoveryPlanAction(endGroupActions));
                }

                if (replicationProtectedItems != null)
                {
                    var replicationProtectedItemList =
                        recoveryPlanGroup.ReplicationProtectedItems.Select(
                            item => item.Id.ToLower());
                    var replicationProtectedItemsTemp = replicationProtectedItems.Where(
                            rpi => replicationProtectedItemList.Contains(rpi.Id.ToLower()))
                        .ToList();
                    if (replicationProtectedItemsTemp != null)
                    {
                        this.ReplicationProtectedItems = replicationProtectedItemsTemp.ConvertAll(
                            temp => new ASRReplicationProtectedItem(temp));
                    }

                }
                else
                {
                    this.ReplicationProtectedItems = new List<ASRReplicationProtectedItem>();
                }
            }
        }

        public ASRRecoveryPlanGroup(
            string groupName,
            RecoveryPlanGroup recoveryPlanGroup,
            IList<ReplicationProtectedItem> replicationProtectedItems = null) : this(
            recoveryPlanGroup,
            replicationProtectedItems)
        {
            this.Name = groupName;
        }

        /// <summary>
        ///     Gets or sets Recovery plan group Name.
        /// </summary>
        public string Name { get; set; }

        // Summary:
        //     Optional. Recovery plan end group actions.
        public IList<ASRRecoveryPlanAction> EndGroupActions { get; set; }

        //
        // Summary:
        //     Required. Group type.
        public string GroupType { get; set; }

        //
        // Summary:
        //     Optional. List of protected items.
        public IList<ASRReplicationProtectedItem> ReplicationProtectedItems { get; set; }

        //
        // Summary:
        //     Optional. Recovery plan start group actions.
        public IList<ASRRecoveryPlanAction> StartGroupActions { get; set; }
    }

    //
    // Summary:
    //     Recovery plan A2A specific details.
    public class ASRRecoveryPlanA2ADetails
    {      
        //
        // Summary:
        //     Initializes a new instance of the RecoveryPlanA2ADetails class.
        //
        // Parameters:
        //   primaryZone:
        //     The primary zone.
        //
        //   recoveryZone:
        //     The recovery zone.
        public ASRRecoveryPlanA2ADetails(string primaryZone, string recoveryZone)
        {
            this.PrimaryZone = primaryZone;
            this.RecoveryZone = recoveryZone;
        }

        //
        // Summary:
        //     Gets or sets the primary zone.
        public string PrimaryZone { get; set; }
        
        //
        // Summary:
        //     Gets or sets the recovery zone.
        public string RecoveryZone { get; set; }
    }

    /// <summary>
    ///     Azure Site Recovery Recovery Plan.
    /// </summary>
    [SuppressMessage(
        "Microsoft.StyleCop.CSharp.MaintainabilityRules",
        "SA1402:FileMayOnlyContainASingleClass",
        Justification = "Keeping all related objects together.")]
    public class ASRRecoveryPlan
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRRecoveryPlan" /> class.
        /// </summary>
        public ASRRecoveryPlan()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRRecoveryPlan" /> class with required
        ///     parameters.
        /// </summary>
        /// <param name="recoveryPlan">Recovery plan object</param>
        /// <param name="replicationProtectedItems"></param>
        public ASRRecoveryPlan(
            RecoveryPlan recoveryPlan,
            IList<ReplicationProtectedItem> replicationProtectedItems)
        {
            this.Id = recoveryPlan.Id;
            this.Name = recoveryPlan.Name;
            this.FriendlyName = recoveryPlan.Properties.FriendlyName;
            this.ServerId = recoveryPlan.Properties.PrimaryFabricId;
            this.TargetServerId = recoveryPlan.Properties.RecoveryFabricId;
            this.FailoverDeploymentModel = recoveryPlan.Properties.FailoverDeploymentModel;
            this.Groups = new List<ASRRecoveryPlanGroup>();
            var groupCount = 0;
            string groupName = null;

            foreach (var recoveryPlanGroup in recoveryPlan.Properties.Groups)
            {
                switch (recoveryPlanGroup.GroupType)
                {
                    case RecoveryPlanGroupType.Boot:
                        groupCount++;
                        groupName = "Group " + groupCount;
                        break;
                    case RecoveryPlanGroupType.Failover:
                        groupName = Constants.Failover;
                        break;
                    case RecoveryPlanGroupType.Shutdown:
                        groupName = Constants.Shutdown;
                        break;
                }

                this.Groups.Add(
                    new ASRRecoveryPlanGroup(
                        groupName,
                        recoveryPlanGroup,
                        replicationProtectedItems));
            }

            if (recoveryPlan.Properties.ProviderSpecificDetails != null &&
                recoveryPlan.Properties.ProviderSpecificDetails.Count > 0)
            {
                this.ProviderSpecificDetails = new List<ASRRecoveryPlanA2ADetails>();
                foreach (var providerSpecificDetails in recoveryPlan.Properties.ProviderSpecificDetails)
                {
                    if (providerSpecificDetails is RecoveryPlanA2ADetails)
                    {
                        var a2aProviderDetails = (RecoveryPlanA2ADetails)providerSpecificDetails;
                        var psd = new ASRRecoveryPlanA2ADetails(
                            a2aProviderDetails.PrimaryZone,
                            a2aProviderDetails.RecoveryZone);

                        this.ProviderSpecificDetails.Add(psd);
                    }
                }
            }

            this.ReplicationProvider = recoveryPlan.Properties.ReplicationProviders;
        }

        /// <summary>
        ///     Refreshes group names for the RP
        /// </summary>
        /// <returns></returns>
        public ASRRecoveryPlan RefreshASRRecoveryPlanGroupNames()
        {
            var bootGroupCount = 0;
            for (var groupCount = 0; groupCount < this.Groups.Count; groupCount++)
            {
                switch (this.Groups[groupCount]
                    .GroupType)
                {
                    case Constants.Boot:
                        bootGroupCount++;
                        this.Groups[groupCount]
                            .Name = "Group " + bootGroupCount;
                        break;
                    case Constants.Failover:
                        this.Groups[groupCount]
                            .Name = Constants.Failover;
                        break;
                    case Constants.Shutdown:
                        this.Groups[groupCount]
                            .Name = Constants.Shutdown;
                        break;
                }
            }

            return this;
        }

        #region Properties

        /// <summary>
        ///     Gets or sets Recovery plan Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets FriendlyName of the Recovery Plan.
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        ///     Gets or sets to Server ID.
        /// </summary>
        public string ServerId { get; set; }

        /// <summary>
        ///     Gets or sets target Server ID.
        /// </summary>
        public string TargetServerId { get; set; }

        /// <summary>
        ///     Gets or sets Failover Deployment Model
        /// </summary>
        public string FailoverDeploymentModel { get; set; }

        /// <summary>
        ///     Gets or sets ASRGroups
        /// </summary>
        public IList<ASRRecoveryPlanGroup> Groups { get; set; }

        /// <summary>
        ///     Gets or sets Replication provider.
        /// </summary>
        public IList<string> ReplicationProvider { get; set; }

        /// <summary>
        ///     Gets or sets ID.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Gets or sets Provider Specific Details
        /// </summary>
        public List<ASRRecoveryPlanA2ADetails> ProviderSpecificDetails { get; set; }

        #endregion
    }
}
