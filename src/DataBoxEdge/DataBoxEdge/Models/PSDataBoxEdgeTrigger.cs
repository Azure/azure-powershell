using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common;
using Microsoft.WindowsAzure.Commands.Common.Attributes;
using System;
using Trigger = Microsoft.Azure.Management.DataBoxEdge.Models.Trigger;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models
{
    public class PSDataBoxEdgeTrigger
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

        public PSDataBoxEdgeTrigger()
        {
            Trigger = new Trigger();
        }

        public PSDataBoxEdgeTrigger(Trigger trigger, string kind)
        {
            this.Trigger = trigger ?? throw new ArgumentNullException("trigger");
            this.Id = trigger.Id;
            var resourceIdentifier = new DataBoxEdgeResourceIdentifier(trigger.Id);
            this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            this.DeviceName = resourceIdentifier.DeviceName;
            this.Name = resourceIdentifier.ResourceName;
            this.Kind = kind;
        }

        public static PSDataBoxEdgeTrigger PSDataBoxEdgeTriggerObject(Trigger trigger)
        {
            switch (trigger)
            {
                case FileEventTrigger fileEventTrigger:
                    return new PSDataBoxEdgeTrigger(fileEventTrigger, "FileEventTrigger");

                case PeriodicTimerEventTrigger periodicTimerEventTrigger:
                    return new PSDataBoxEdgeTrigger(periodicTimerEventTrigger, "PeriodicTimerEventTrigger");
            }

            return null;
        }
    }
}