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
    using AutomationManagement = WindowsAzure.Management.Automation;

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
        public JobStream(AutomationManagement.Models.JobStream jobStream, string automationAccountName, Guid jobId )
        {
            Requires.Argument("jobStream", jobStream).NotNull();

            this.JobStreamId = jobStream.Properties.JobStreamId;
            this.Type = jobStream.Properties.StreamType;
            this.Text = jobStream.Properties.Summary;
            this.Time = jobStream.Properties.Time;
            this.AutomationAccountName = automationAccountName;
            this.Id = jobId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobStream"/> class.
        /// </summary>
        public JobStream()
        {
        }

        /// <summary>
        /// Gets or sets the automation account name.
        /// </summary>
        public string AutomationAccountName { get; set; }

        /// <summary>
        /// Gets or sets the Job Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the stream id
        /// </summary>
        public string JobStreamId { get; set; }

        /// <summary>
        /// Gets or sets the stream time.
        /// </summary>
        public DateTimeOffset Time { get; set; }

        /// <summary>
        /// Gets or sets the stream text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the stream Type.
        /// </summary>
        public string Type { get; set; }
    }
}
