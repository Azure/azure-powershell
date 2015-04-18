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

using Microsoft.Azure.Management.Compute.Models;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public static class SourceImageReferenceExtension
    {
        const string pattern = @"^/([A-Za-z0-9\-]+)/services/images/.*$";
        const string format = "/{0}/services/images/{1}";

        public static SourceImageReference Normalize(this SourceImageReference value, string subscriptionId = null)
        {
            if (value != null && !string.IsNullOrEmpty(value.ReferenceUri))
            {
                var match = Regex.Match(value.ReferenceUri, pattern, RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    value.ReferenceUri = string.Format(format, subscriptionId, value.ReferenceUri);
                }
            }

            return value;
        }
    }
}