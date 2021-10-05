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

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    public class PSDenyAssignment
    {
        public string Id { get; set; }

        public string DenyAssignmentName { get; set; }

        public string Description { get; set; }

        public List<string> Actions { get; set; }

        public List<string> NotActions { get; set; }

        public List<string> DataActions { get; set; }

        public List<string> NotDataActions { get; set; }

        public string Scope { get; set; }

        public bool DoNotApplyToChildScopes { get; set; }

        public List<PSPrincipal> Principals { get; set; }

        public List<PSPrincipal> ExcludePrincipals { get; set; }

        public bool IsSystemProtected { get; set; }
    }
}
