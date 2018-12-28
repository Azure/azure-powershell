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

namespace Microsoft.Azure.Commands.PolicyInsights.Models.Remediation
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.PolicyInsights.Models;

    /// <summary>
    /// General error definition.
    /// </summary>
    public class PSErrorDefinition
    {
        /// <summary>
        /// Gets the error code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the error target.
        /// </summary>
        public string Target { get; }

        /// <summary>
        /// Gets the inner error details.
        /// </summary>
        public IEnumerable<PSErrorDefinition> Details { get; }

        /// <summary>
        /// Gets the additional error information.
        /// </summary>
        public IEnumerable<PSTypedErrorInfo> AdditionalInfo { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PSErrorDefinition" /> class.
        /// </summary>
        /// <param name="error">The raw error definition.</param>
        public PSErrorDefinition(ErrorDefinition error)
        {
            if (error == null)
            {
                return;
            }

            this.Code = error.Code;
            this.Message = error.Message;
            this.Target = error.Target;
            if (error.Details != null)
            {
                this.Details = error.Details.Select(d => new PSErrorDefinition(d));
            }

            if (error.AdditionalInfo != null)
            {
                this.AdditionalInfo = error.AdditionalInfo.Select(a => new PSTypedErrorInfo(a));
            }
        }
    }
}
