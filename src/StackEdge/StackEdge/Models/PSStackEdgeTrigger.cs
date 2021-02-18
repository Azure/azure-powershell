using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using Trigger = Microsoft.Azure.Management.DataBoxEdge.Models.Trigger;

namespace Microsoft.Azure.PowerShell.Cmdlets.StackEdge.Models
{
    public class PSStackEdgeTrigger
    {
        public Trigger Trigger;

        [Ps1Xml(Label = "ResourceGroupName", Target = ViewControl.Table)]
        public string ResourceGroupName;

        [Ps1Xml(Label = "DeviceName", Target = ViewControl.Table, Position = 1)]
        public string DeviceName;

        public string Id;

        [Ps1Xml(Label = "Name", Target = ViewControl.Table, Position = 2)]
        public string Name;

        [Ps1Xml(Label = "Kind", Target = ViewControl.Table, Position = 3)]
        public string Kind;

        public PSStackEdgeTrigger()
        {
            Trigger = new Trigger();
        }

        public PSStackEdgeTrigger(Trigger trigger, string kind)
        {
            this.Trigger = trigger ?? throw new ArgumentNullException("trigger");
            this.Id = trigger.Id;
            var resourceIdentifier = new StackEdgeResourceIdentifier(trigger.Id);
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            this.DeviceName = resourceIdentifier.DeviceName;
            this.Name = resourceIdentifier.ResourceName;
            this.Kind = kind;
        }

        public static PSStackEdgeTrigger PSStackEdgeTriggerObject(Trigger trigger)
        {
            switch (trigger)
            {
                case FileEventTrigger fileEventTrigger:
                    return new PSStackEdgeTrigger(fileEventTrigger, "FileEventTrigger");

                case PeriodicTimerEventTrigger periodicTimerEventTrigger:
                    return new PSStackEdgeTrigger(periodicTimerEventTrigger, "PeriodicTimerEventTrigger");
            }

            return null;
        }
    }
}