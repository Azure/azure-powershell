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

using System.Text;

namespace Microsoft.Azure.Management.Monitor.Management.Models
{
    /// <summary>
    /// This class is intended to help in the transition between namespaces, since it will be a breaking change that needs to be announced and delayed 6 months.
    /// It is identical to the RetentionPolicy, but in the old namespace
    /// </summary>
    public class RetentionPolicy : Monitor.Models.RetentionPolicy
    {
        /// <summary>
        /// Initializes a new instance of the PSRetentionPolicy class.
        /// </summary>
        /// <param name="retentionPolicy">The input retention policy</param>
        public RetentionPolicy(Monitor.Models.RetentionPolicy retentionPolicy)
            : base()
        {
            if (retentionPolicy != null)
            {
                this.Enabled = retentionPolicy.Enabled;
                this.Days = retentionPolicy.Days;
            }
        }

        public RetentionPolicy()
        {
        }

        /// <summary>
        /// A string representation of the PSRetentionPolicy
        /// </summary>
        /// <returns>A string representation of the PSRetentionPolicy</returns>
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine();
            output.AppendLine("Enabled : " + this.Enabled);
            output.Append("Days    : " + this.Days);
            return output.ToString();
        }
    }
}
