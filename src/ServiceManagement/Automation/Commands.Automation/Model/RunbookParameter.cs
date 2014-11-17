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

namespace Microsoft.Azure.Commands.Automation.Model
{
    using AutomationManagement = Management.Automation;

    /// <summary>
    /// The runbook parameter.
    /// </summary>
    public class RunbookParameter
    {
        public RunbookParameter(AutomationManagement.Models.RunbookParameter runbookParameter)
        {
            this.RunbookVersionId = new Guid(runbookParameter.RunbookVersionId);
            this.Name = runbookParameter.Name;
            this.Type = runbookParameter.Type;
            this.IsMandatory = runbookParameter.IsMandatory;
            this.Position = runbookParameter.Position;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RunbookParameter"/> class.
        /// </summary>
        public RunbookParameter()
        {
        }

        /// <summary>
        /// Gets or sets the runbook version id.
        /// </summary>
        public Guid RunbookVersionId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is mandatory.
        /// </summary>
        public bool IsMandatory { get; set; }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        public int Position { get; set; }
    }
}