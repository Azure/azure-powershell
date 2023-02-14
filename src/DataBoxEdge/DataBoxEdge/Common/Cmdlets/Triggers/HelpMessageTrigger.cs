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


namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common.Cmdlets.Triggers
{
    internal class HelpMessageTrigger
    {
        internal const string NameHelpMessage = "Name of the trigger";
        internal const string ObjectName = "Trigger";

        // Sinkinfo is currently a VM ROLE in the system
        internal const string SinkInfoHelpMessage = "Compute role against which events will be raised.";

        //Help messages for file event trigger
        internal const string FileEventSwitchParameter = "Pass this switch parameter to configure FileEvent Trigger";
        internal const string FileEventShareParameter = "File share ID to be passed in FileEvent Trigger";

        //Help message for periodic timer event trigger
        internal const string PeriodicTimerEventSwitchParameter =
            "Pass this switch parameter to configure PeriodicTimerEvent Trigger";

        internal const string PeriodicTimerEventScheduleHelpMessage =
            "Periodic frequency at which timer event needs to be raised. Specify a schedule in either days (between 1 and 365) , hours (between 1 and 23), or minutes (between 1 and 59).";

        internal const string PeriodicTimerEventStartTimeHelpMessage =
            "The time of the day that results in a valid trigger. " +
            "Schedule is computed with reference to the time specified up to seconds. " +
            "If timezone is not specified the time will considered to be in device timezone. " +
            "The value will always be returned as UTC time.";

        internal const string PeriodicTimerEventTopicHelpMessage =
            "Topic where periodic events are published to IoT device.";
    }
}