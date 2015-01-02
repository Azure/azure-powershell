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
using Microsoft.Azure.Commands.Automation.Common;

namespace Microsoft.Azure.Commands.Automation.Model
{
    using AutomationManagement = Management.Automation;

    /// <summary>
    /// The Job Stream.
    /// </summary>
    public class JobStream
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JobStream"/> class.
        /// </summary>
        /// <param name="jobStream">
        /// The job stream.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        public JobStream(AutomationManagement.Models.JobStream jobStream)
        {
            Requires.Argument("jobStream", jobStream).NotNull();

            this.StreamId = jobStream.Properties.StreamId;
            this.StreamType = jobStream.Properties.StreamType;
            this.Summary = jobStream.Properties.Summary;
            this.Time = jobStream.Properties.Time.ToLocalTime();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobStream"/> class.
        /// </summary>
        public JobStream()
        {
        }

        /// <summary>
        /// Gets or sets the stream id
        /// </summary>
        public string StreamId { get; set; }

        /// <summary>
        /// Gets or sets the stream time.
        /// </summary>
        public DateTimeOffset Time { get; set; }

        /// <summary>
        /// Gets or sets the stream summary.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the stream Type.
        /// </summary>
        public string StreamType { get; set; }
    }
}
