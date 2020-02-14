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
using System.Management.Automation;
using System.Net;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBoxEdge;
using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;


namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common.Cmdlets.Triggers
{
    [Cmdlet(VerbsCommon.New, Constants.Trigger,
         DefaultParameterSetName = FileEventTriggerParameterSet,
         SupportsShouldProcess = true
     ),
     OutputType(typeof(PSStackEdgeTrigger))]
    public class StackEdgeTriggerNewCmdlet : AzureStackEdgeCmdletBase
    {
        private const string FileEventTriggerParameterSet = "FileEventTriggerParameterSet";
        private const string FileEventTriggerResourceIdParameterSet = "FileEventTriggerResourceIdParameterSet";

        private const string PeriodicTimerTriggerParameterSet = "PeriodicTimerTriggerParameterSet";
        private const string PeriodicTimerTriggerResourceIdParameterSet = "PeriodicTimerTriggerResourceIdParameterSet";

        [Parameter(Mandatory = true, ParameterSetName = PeriodicTimerTriggerParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [Parameter(Mandatory = true, ParameterSetName = FileEventTriggerParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.ResourceGroupNameHelpMessage,
            Position = 0)]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FileEventTriggerParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [Parameter(Mandatory = true, ParameterSetName = PeriodicTimerTriggerParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.DeviceNameHelpMessage,
            Position = 1)]
        [ResourceNameCompleter("Microsoft.DataBoxEdge/dataBoxEdgeDevices", nameof(ResourceGroupName))]
        [ValidateNotNullOrEmpty]
        public string DeviceName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = FileEventTriggerParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [Parameter(Mandatory = true, ParameterSetName = PeriodicTimerTriggerParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = Constants.NameHelpMessage,
            Position = 2)]
        [ValidateNotNullOrEmpty]
        [Alias(HelpMessageTrigger.NameAlias)]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = PeriodicTimerTriggerParameterSet,
            HelpMessage = HelpMessageTrigger.SinkInfoHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = FileEventTriggerParameterSet,
            HelpMessage = HelpMessageTrigger.SinkInfoHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string RoleName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = PeriodicTimerTriggerResourceIdParameterSet,
            HelpMessage = HelpMessageTrigger.SinkInfoHelpMessage)]
        [Parameter(Mandatory = true, ParameterSetName = FileEventTriggerResourceIdParameterSet,
            HelpMessage = HelpMessageTrigger.SinkInfoHelpMessage)]
        [ValidateNotNullOrEmpty]
        private string RoleId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = FileEventTriggerParameterSet,
            HelpMessage = HelpMessageTrigger.FileEventSwitchParameter)]
        [Parameter(Mandatory = true,
            ParameterSetName = FileEventTriggerResourceIdParameterSet,
            HelpMessage = HelpMessageTrigger.FileEventSwitchParameter)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter FileEvent { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = FileEventTriggerParameterSet,
            HelpMessage = HelpMessageTrigger.FileEventShareParameter)]
        [ValidateNotNullOrEmpty]
        public string ShareName { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = FileEventTriggerResourceIdParameterSet,
            HelpMessage = HelpMessageTrigger.FileEventShareParameter)]
        [ValidateNotNullOrEmpty]
        public string ShareId { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = PeriodicTimerTriggerParameterSet,
            HelpMessage = HelpMessageTrigger.PeriodicTimerEventSwitchParameter)]
        [Parameter(Mandatory = true,
            ParameterSetName = PeriodicTimerTriggerResourceIdParameterSet,
            HelpMessage = HelpMessageTrigger.PeriodicTimerEventSwitchParameter)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter PeriodicTimerEvent { get; set; }

        [Parameter(Mandatory = true,
            ParameterSetName = PeriodicTimerTriggerParameterSet,
            HelpMessage = HelpMessageTrigger.PeriodicTimerEventScheduleHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = PeriodicTimerTriggerResourceIdParameterSet,
            HelpMessage = HelpMessageTrigger.PeriodicTimerEventScheduleHelpMessage)]
        [ValidateNotNullOrEmpty]
        public string Schedule;

        [Parameter(Mandatory = true,
            ParameterSetName = PeriodicTimerTriggerParameterSet,
            HelpMessage = HelpMessageTrigger.PeriodicTimerEventStartTimeHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = PeriodicTimerTriggerResourceIdParameterSet,
            HelpMessage = HelpMessageTrigger.PeriodicTimerEventStartTimeHelpMessage)]
        public DateTime StartTime;

        [Parameter(Mandatory = true,
            ParameterSetName = PeriodicTimerTriggerParameterSet,
            HelpMessage = HelpMessageTrigger.PeriodicTimerEventTopicHelpMessage)]
        [Parameter(Mandatory = true,
            ParameterSetName = PeriodicTimerTriggerResourceIdParameterSet,
            HelpMessage = HelpMessageTrigger.PeriodicTimerEventTopicHelpMessage)]
        public string Topic;

        [Parameter(Mandatory = false, HelpMessage = Constants.AsJobHelpMessage)]
        public SwitchParameter AsJob { get; set; }

        private Trigger GetResourceModel()
        {
            return this.StackEdgeManagementClient.Triggers.Get(
                this.DeviceName,
                this.Name,
                this.ResourceGroupName);
        }

        private string GetRoleId()
        {
            return this.StackEdgeManagementClient.Roles.Get(
                this.DeviceName,
                this.RoleName,
                this.ResourceGroupName).Id;
        }

        private string GetShareId()
        {
            return this.StackEdgeManagementClient.Shares.Get(
                this.DeviceName,
                this.ShareName,
                this.ResourceGroupName).Id;
        }

        private string GetResourceFoundMessage()
        {
            return string.Format("'{0}'{1}{2}'.",
                HelpMessageTrigger.ObjectName, Constants.ResourceAlreadyExists, this.Name);
        }

        private bool DoesResourceExists()
        {
            try
            {
                var resource = GetResourceModel();
                if (resource == null) return false;
                var msg = GetResourceFoundMessage();
                throw new Exception(msg);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                throw;
            }
        }

        private PSStackEdgeTrigger CreateResourceModel()
        {
            Trigger trigger;
            var roleSinkInfo = new RoleSinkInfo(this.RoleId);
            if (this.FileEvent.IsPresent)
            {
                var fileSourceInfo = new FileSourceInfo(this.ShareId);
                trigger = new FileEventTrigger(fileSourceInfo, roleSinkInfo, name: this.Name);
            }
            else
            {
                var periodicSourceInfo = new PeriodicTimerSourceInfo(this.StartTime, this.Schedule, this.Topic);
                trigger = new PeriodicTimerEventTrigger(periodicSourceInfo, roleSinkInfo, name: this.Name);
            }


            return PSStackEdgeTrigger.PSStackEdgeTriggerObject(
                this.StackEdgeManagementClient.Triggers.CreateOrUpdate(
                    this.DeviceName,
                    this.Name,
                    trigger,
                    this.ResourceGroupName));
        }

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.RoleName))
            {
                this.RoleId = GetRoleId();
            }

            if (this.IsParameterBound(c => c.ShareName))
            {
                this.ShareId = GetShareId();
            }

            if (this.ShouldProcess(this.Name,
                string.Format("Creating '{0}' in device '{1}' with name '{2}'.",
                    HelpMessageTrigger.ObjectName, this.DeviceName, this.Name)))
            {
                DoesResourceExists();
                var results = new List<PSStackEdgeTrigger>()
                {
                    CreateResourceModel()
                };

                WriteObject(results, true);
            }
        }
    }
}