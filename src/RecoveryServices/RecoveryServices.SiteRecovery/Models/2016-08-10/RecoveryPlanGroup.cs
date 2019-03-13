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
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    /// <summary>
    ///     Azure Site Recovery Recovery Plan.
    /// </summary>
    public class ASRRecoveryPlan_2016_08_10
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRRecoveryPlan" /> class.
        /// </summary>
        public ASRRecoveryPlan_2016_08_10()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ASRRecoveryPlan" /> class with required
        ///     parameters.
        /// </summary>
        /// <param name="recoveryPlan">Recovery plan object</param>
        public ASRRecoveryPlan_2016_08_10(
            RecoveryPlan recoveryPlan,
            IList<ReplicationProtectedItem> replicationProtectedItems)
        {
            this.Id = recoveryPlan.Id;
            this.Name = recoveryPlan.Name;
            this.FriendlyName = recoveryPlan.Properties.FriendlyName;
            this.ServerId = recoveryPlan.Properties.PrimaryFabricId;
            this.TargetServerId = recoveryPlan.Properties.RecoveryFabricId;
            this.FailoverDeploymentModel = recoveryPlan.Properties.FailoverDeploymentModel;
            this.Groups = new List<ASRRecoveryPlanGroup_2016_08_10>();
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
                    new ASRRecoveryPlanGroup_2016_08_10(
                        groupName,
                        recoveryPlanGroup,
                        replicationProtectedItems));
            }

            this.ReplicationProvider = recoveryPlan.Properties.ReplicationProviders;
        }

        public ASRRecoveryPlan_2016_08_10(ASRRecoveryPlan recoveryPlan)
        {
            this.Id = recoveryPlan.Id;
            this.Name = recoveryPlan.Name;
            this.FriendlyName = recoveryPlan.FriendlyName;
            this.ServerId = recoveryPlan.ServerId;
            this.TargetServerId = recoveryPlan.TargetServerId;
            this.FailoverDeploymentModel = recoveryPlan.FailoverDeploymentModel;
            this.Groups = new List<ASRRecoveryPlanGroup_2016_08_10>();
            var groupCount = 0;
            string groupName = null;

            foreach (var recoveryPlanGroup in recoveryPlan.Groups)
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
                    new ASRRecoveryPlanGroup_2016_08_10(recoveryPlanGroup));
            }

            this.ReplicationProvider = recoveryPlan.ReplicationProvider;
        }

        /// <summary>
        ///     Refreshes group names for the RP
        /// </summary>
        /// <returns></returns>
        public ASRRecoveryPlan_2016_08_10 RefreshASRRecoveryPlanGroupNames()
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
        public IList<ASRRecoveryPlanGroup_2016_08_10> Groups { get; set; }

        /// <summary>
        ///     Gets or sets Replication provider.
        /// </summary>
        public IList<string> ReplicationProvider { get; set; }

        /// <summary>
        ///     Gets or sets ID.
        /// </summary>
        public string Id { get; set; }

        #endregion
    }

    public class ASRRecoveryPlanGroup_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the RecoveryPlanGroup class.
        public ASRRecoveryPlanGroup_2016_08_10()
        {
        }

        //
        // Summary:
        //     Initializes a new instance of the RecoveryPlanGroup class.
        public ASRRecoveryPlanGroup_2016_08_10(ASRRecoveryPlanGroup asrRecoveryPlanGroup)
        {
            this.Name = asrRecoveryPlanGroup.Name;
            this.StartGroupActions = asrRecoveryPlanGroup.StartGroupActions;

            this.EndGroupActions = asrRecoveryPlanGroup.EndGroupActions;

        }

        public ASRRecoveryPlanGroup_2016_08_10(
            string groupName,
            RecoveryPlanGroup recoveryPlanGroup,
            IList<ReplicationProtectedItem> replicationProtectedItems = null) : this(
            recoveryPlanGroup,
            replicationProtectedItems)
        {
            this.Name = groupName;
        }

        public ASRRecoveryPlanGroup_2016_08_10(
            RecoveryPlanGroup recoveryPlanGroup,
            IList<ReplicationProtectedItem> replicationProtectedItems = null)
        {
            if (recoveryPlanGroup != null)
            {
                this.GroupType = recoveryPlanGroup.GroupType.ToString();
                this.StartGroupActions = recoveryPlanGroup.StartGroupActions.ToList().ConvertAll(
                    (recoveryPlanAction) => { return new RecoveryPlanAction_2016_08_10(recoveryPlanAction); });
                this.EndGroupActions = recoveryPlanGroup.EndGroupActions.ToList().ConvertAll(
                    (recoveryPlanAction) => { return new RecoveryPlanAction_2016_08_10(recoveryPlanAction); });

                if (replicationProtectedItems != null)
                {
                    var replicationProtectedItemList =
                        recoveryPlanGroup.ReplicationProtectedItems.Select(
                            item => item.Id.ToLower());
                    this.ReplicationProtectedItems = replicationProtectedItems.ToList().ConvertAll(
                            (rpi) => { return new ReplicationProtectedItem_2016_08_10(rpi); });
                }
                else
                {
                    this.ReplicationProtectedItems = new List<ReplicationProtectedItem_2016_08_10>();
                }
            }
        }

        /// <summary>
        ///     Gets or sets Recovery plan group Name.
        /// </summary>
        public string Name { get; set; }

        //
        // Summary:
        //     Gets or sets the group type. Possible values include: 'Shutdown', 'Boot', 'Failover'
        public string GroupType { get; set; }
        //
        // Summary:
        //     Gets or sets the list of protected items.
        public IList<ReplicationProtectedItem_2016_08_10> ReplicationProtectedItems { get; set; }
        //
        // Summary:
        //     Gets or sets the start group actions.
        public IList<RecoveryPlanAction_2016_08_10> StartGroupActions { get; set; }
        //
        // Summary:
        //     Gets or sets the end group actions.
        public IList<RecoveryPlanAction_2016_08_10> EndGroupActions { get; set; }
    }

    //
    // Summary:
    //     Defines values for RecoveryPlanGroupType.
    public enum ASRRecoveryPlanGroupType
    {
        Shutdown = 0,
        Boot = 1,
        Failover = 2
    }

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
            this.FabricLocation = "Primary" == automationRunbookActionDetails.FabricLocation ?
                ASRRecoveryPlanActionLocation.Primary : ASRRecoveryPlanActionLocation.Recovery;

        }

        public static RecoveryPlanAutomationRunbookActionDetails
            getSrsRecoveryPlanAutomationRunbookActionDetails(ASRRecoveryPlanAutomationRunbookActionDetails automationRunbookActionDetails)
        {
            var action = new RecoveryPlanAutomationRunbookActionDetails();
            action.RunbookId = automationRunbookActionDetails.RunbookId;
            action.Timeout = automationRunbookActionDetails.Timeout;
            action.FabricLocation = automationRunbookActionDetails.FabricLocation == ASRRecoveryPlanActionLocation.Primary ?
                "Primary" : "Recovery";

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
        public ASRRecoveryPlanActionLocation FabricLocation { get; set; }
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
            this.FabricLocation = "Primary" == recoveryPlanScriptActionDetails.FabricLocation ?
                ASRRecoveryPlanActionLocation.Primary : ASRRecoveryPlanActionLocation.Recovery;
        }

        public static RecoveryPlanScriptActionDetails getRecoveryPlanScriptActionDetails(ASRRecoveryPlanScriptActionDetails recoveryPlanScriptActionDetails)
        {
            var actionDetails = new RecoveryPlanScriptActionDetails();
            actionDetails.Path = recoveryPlanScriptActionDetails.Path;
            actionDetails.Timeout = recoveryPlanScriptActionDetails.Timeout;
            actionDetails.FabricLocation = recoveryPlanScriptActionDetails.FabricLocation ==
                ASRRecoveryPlanActionLocation.Primary ? "Primary" : "Recovery";

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
        public ASRRecoveryPlanActionLocation FabricLocation { get; set; }
    }

    //
    // Summary:
    //     Recovery plan action details.
    public class RecoveryPlanAction_2016_08_10
    {
        //
        // Summary:
        //     Initializes a new instance of the RecoveryPlanAction class.
        public RecoveryPlanAction_2016_08_10(RecoveryPlanAction srsRecoveryPlanAction)
        {
            this.ActionName = srsRecoveryPlanAction.ActionName;
            if (srsRecoveryPlanAction.FailoverTypes != null)
            {
                this.FailoverTypes = new List<ASRReplicationProtectedItemOperation?>();
                foreach (var startGroupAction in srsRecoveryPlanAction.FailoverTypes)
                {
                    this.FailoverTypes.Add(ASRRecoveryPlanUtil.getASRReplicationProtectedItemOperation(startGroupAction));
                }
            }

            if (srsRecoveryPlanAction.FailoverDirections != null)
            {
                this.FailoverDirections = new List<ASRPossibleOperationsDirections?>();
                foreach (var failoverDirection in srsRecoveryPlanAction.FailoverDirections)
                {
                    var direction = failoverDirection == "PrimaryToRecovery" ?
                        ASRPossibleOperationsDirections.PrimaryToRecovery :
                        ASRPossibleOperationsDirections.RecoveryToPrimary;
                    this.FailoverDirections.Add(direction);
                }
            }

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
        //     Initializes a new instance of the RecoveryPlanAction class.
        public static RecoveryPlanAction GetSrsRecoveryPlanAction(RecoveryPlanAction_2016_08_10 asrRecoveryPlanAction)
        {
            var recoveryPlanAction = new RecoveryPlanAction();

            recoveryPlanAction.ActionName = asrRecoveryPlanAction.ActionName;
            if (asrRecoveryPlanAction.FailoverTypes != null)
            {
                recoveryPlanAction.FailoverTypes = new List<string>();
                foreach (var startGroupAction in asrRecoveryPlanAction.FailoverTypes)
                {
                    recoveryPlanAction.FailoverTypes.Add(ASRRecoveryPlanUtil.getSRSReplicationProtectedItemOperation(startGroupAction.Value));
                }
            }

            if (asrRecoveryPlanAction.FailoverDirections != null)
            {
                recoveryPlanAction.FailoverDirections = new List<String>();
                foreach (var failoverDirection in asrRecoveryPlanAction.FailoverDirections)
                {
                    var direction = failoverDirection ==
                        ASRPossibleOperationsDirections.PrimaryToRecovery ? "PrimaryToRecovery" : "RecoveryToPrimary";
                    recoveryPlanAction.FailoverDirections.Add(direction);
                }
            }

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

        //
        // Summary:
        //     Gets or sets the action name.
        public string ActionName { get; set; }
        //
        // Summary:
        //     Gets or sets the list of failover types.
        public IList<ASRReplicationProtectedItemOperation?> FailoverTypes { get; set; }
        //
        // Summary:
        //     Gets or sets the list of failover directions.
        public IList<ASRPossibleOperationsDirections?> FailoverDirections { get; set; }
        //
        // Summary:
        //     Gets or sets the custom details.
        public ASRRecoveryPlanActionDetails CustomDetails { get; set; }
    }

    //
    // Summary:
    //     Defines values for RecoveryPlanActionLocation.
    public enum ASRRecoveryPlanActionLocation
    {
        Primary = 0,
        Recovery = 1
    }

    //
    // Summary:
    //     Defines values for PossibleOperationsDirections.
    public enum ASRPossibleOperationsDirections
    {
        PrimaryToRecovery = 0,
        RecoveryToPrimary = 1
    }

    //
    // Summary:
    //     Defines values for ReplicationProtectedItemOperation.
    public enum ASRReplicationProtectedItemOperation
    {
        ReverseReplicate = 0,
        Commit = 1,
        PlannedFailover = 2,
        UnplannedFailover = 3,
        DisableProtection = 4,
        TestFailover = 5,
        TestFailoverCleanup = 6,
        Failback = 7,
        FinalizeFailback = 8,
        ChangePit = 9,
        RepairReplication = 10,
        SwitchProtection = 11,
        CompleteMigration = 12
    }

    //
    // Summary:
    //     Recovery plan protected item.
    public class ASRRecoveryPlanProtectedItem
    {
        //
        // Summary:
        //     Initializes a new instance of the RecoveryPlanProtectedItem class.
        public ASRRecoveryPlanProtectedItem()
        {

        }

        //
        // Summary:
        //     Gets or sets the ARM Id of the recovery plan protected item.
        public string Id { get; set; }
        //
        // Summary:
        //     Gets or sets the virtual machine Id.
        public string VirtualMachineId { get; set; }
    }

    public static class ASRRecoveryPlanUtil
    {

        public static ASRReplicationProtectedItemOperation? getASRReplicationProtectedItemOperation(string startGroupAction)
        {

            switch (startGroupAction)
            {
                case "ReverseReplicate": return ASRReplicationProtectedItemOperation.ReverseReplicate;
                case "Commit":
                    return ASRReplicationProtectedItemOperation.Commit;
                case "PlannedFailover":
                    return ASRReplicationProtectedItemOperation.PlannedFailover;
                case "UnplannedFailover":
                    return ASRReplicationProtectedItemOperation.UnplannedFailover;
                case "DisableProtection":
                    return ASRReplicationProtectedItemOperation.DisableProtection;
                case "TestFailover":
                    return ASRReplicationProtectedItemOperation.TestFailover;
                case "TestFailoverCleanup":
                    return ASRReplicationProtectedItemOperation.TestFailoverCleanup;
                case "Failback":
                    return ASRReplicationProtectedItemOperation.Failback;
                case "FinalizeFailback":
                    return ASRReplicationProtectedItemOperation.FinalizeFailback;
                case "ChangePit":
                    return ASRReplicationProtectedItemOperation.ChangePit;
                case "RepairReplication":
                    return ASRReplicationProtectedItemOperation.RepairReplication;
                case "SwitchProtection":
                    return ASRReplicationProtectedItemOperation.SwitchProtection;
                case "CompleteMigration":
                    return ASRReplicationProtectedItemOperation.CompleteMigration;
                default:
                    return null;
            }
        }

        public static string getSRSReplicationProtectedItemOperation(ASRReplicationProtectedItemOperation? startGroupAction)
        {
            if (startGroupAction == null) { return null; }
            else
            {
                return Enum.GetName(typeof(ASRReplicationProtectedItemOperation), startGroupAction);
            }
        }

        public static RecoveryPlanAction getRecoveryPlanAction(RecoveryPlanAction_2016_08_10 asrRecoveryPlanAction)
        {
            var recoveryPlanAction = new RecoveryPlanAction();
            recoveryPlanAction.ActionName = asrRecoveryPlanAction.ActionName;
            if (asrRecoveryPlanAction.FailoverDirections != null)
            {
                recoveryPlanAction.FailoverDirections =
                    asrRecoveryPlanAction.FailoverDirections.ToList().ConvertAll((asrFODirection) => { return asrFODirection.ToString(); });
            }

            if (asrRecoveryPlanAction.FailoverTypes != null)
            {
                recoveryPlanAction.FailoverTypes =
                asrRecoveryPlanAction.FailoverTypes.ToList().ConvertAll((asrFailoverTypes) => { return asrFailoverTypes.ToString(); });
            }

            if (asrRecoveryPlanAction.CustomDetails is ASRRecoveryPlanAutomationRunbookActionDetails)
            {
                var actionDetails = asrRecoveryPlanAction.CustomDetails as ASRRecoveryPlanAutomationRunbookActionDetails;
                recoveryPlanAction.CustomDetails = new RecoveryPlanAutomationRunbookActionDetails
                {
                    FabricLocation = actionDetails.FabricLocation.ToString(),
                    RunbookId = actionDetails.RunbookId,
                    Timeout = actionDetails.Timeout
                };
            }
            else if (asrRecoveryPlanAction.CustomDetails is ASRRecoveryPlanManualActionDetails)
            {
                var actionDetails = asrRecoveryPlanAction.CustomDetails as ASRRecoveryPlanManualActionDetails;
                recoveryPlanAction.CustomDetails = new RecoveryPlanManualActionDetails
                {
                    Description = actionDetails.Description
                };
            }
            else if (asrRecoveryPlanAction.CustomDetails is ASRRecoveryPlanScriptActionDetails)
            {
                var actionDetails = asrRecoveryPlanAction.CustomDetails as ASRRecoveryPlanScriptActionDetails;
                recoveryPlanAction.CustomDetails = new RecoveryPlanScriptActionDetails
                {
                    FabricLocation = actionDetails.FabricLocation.ToString(),
                    Path = actionDetails.Path,
                    Timeout = actionDetails.Timeout
                };
            }


            return recoveryPlanAction;
        }
    }
}
