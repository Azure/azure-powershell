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
using System.Linq;

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the AutoscaleProfile, but in the old namespace
    /// </summary>
    public class AutoscaleProfile : Monitor.Models.AutoscaleProfile
    {
        /// <summary>
        /// Gets or sets the Recurrence of the profile
        /// </summary>
        public new Recurrence Recurrence {get; set;}

        /// <summary>
        /// Gets or sets the Capacity of the profile
        /// </summary>
        public new ScaleCapacity Capacity { get; set; }

        /// <summary>
        /// Gets or sets the FixedDate of the profile
        /// </summary>
        public new TimeWindow FixedDate { get; set; }

        /// <summary>
        /// Gets or sets the Rules of the profile
        /// </summary>
        public new IList<ScaleRule> Rules { get; set; }

        /// <summary>
        /// Initializes a new instance of the AutoscaleProfile class.
        /// </summary>
        public AutoscaleProfile() : base()
        { }

        /// <summary>
        /// Initializes a new instance of the AutoscaleProfile class.
        /// </summary>
        /// <param name="autoscaleProfile">The autoscale profile</param>
        public AutoscaleProfile(Monitor.Models.AutoscaleProfile autoscaleProfile)
            : base(name: autoscaleProfile?.Name, capacity: autoscaleProfile?.Capacity, rules: autoscaleProfile?.Rules, fixedDate: autoscaleProfile?.FixedDate, recurrence: autoscaleProfile?.Recurrence)
        {
            if (autoscaleProfile != null)
            {
                this.Recurrence = autoscaleProfile.Recurrence != null ? new Recurrence(autoscaleProfile.Recurrence) : null;
                this.Capacity = autoscaleProfile.Capacity != null ? new ScaleCapacity(autoscaleProfile.Capacity) : null;
                this.FixedDate = autoscaleProfile.FixedDate != null ? new TimeWindow(autoscaleProfile.FixedDate) : null;
                this.Rules = autoscaleProfile.Rules?.Select(e => new ScaleRule(e)).ToList();
            }
        }
    }
}
