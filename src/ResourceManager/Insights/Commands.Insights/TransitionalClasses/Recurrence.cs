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

using Microsoft.Azure.Commands.Insights.TransitionalClasses;

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the Recurrence, but in the old namespace
    /// </summary>
    public class Recurrence : Monitor.Models.Recurrence
    {
        private RecurrenceFrequency thisFrequency;
        private RecurrentSchedule thisSchedule;

        /// <summary>
        /// Gets or sets the Frequency of the recurrence
        /// </summary>
        public new RecurrenceFrequency Frequency
        {
            get
            {
                return this.thisFrequency;
            }
            set
            {
                base.Frequency = TransitionHelpers.ConvertNamespace(value);
                this.thisFrequency = value;
            }
        }

        /// <summary>
        /// Gtes or sets the Schedule of the recurrence
        /// </summary>
        public new RecurrentSchedule Schedule
        {
            get
            {
                return this.thisSchedule;
            }
            set
            {
                base.Schedule = TransitionHelpers.ConvertNamespace(value);
                this.thisSchedule = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Recurrence class.
        /// </summary>
        public Recurrence()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Recurrence class.
        /// </summary>
        /// <param name="recurrence">The recurrence object</param>
        public Recurrence(Monitor.Models.Recurrence recurrence)
            : base()
        {
            if (recurrence != null)
            {
                this.Frequency = TransitionHelpers.ConvertNamespace(recurrence.Frequency);
                this.Schedule = recurrence.Schedule != null ? new RecurrentSchedule(recurrence.Schedule) : null;
            }
        }
    }
}
