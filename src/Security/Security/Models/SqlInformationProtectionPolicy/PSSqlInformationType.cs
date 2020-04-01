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

namespace Microsoft.Azure.Commands.SecurityCenter.Models.SqlInformationProtectionPolicy
{
    public class PSSqlInformationType
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public double? Order { get; set; }

        public PSSqlSensitivityObjectState State { get; set; }

        public string AssociatedLabel { get; set; }

        public PSSqlSensitivityObjectType Type { get; set; }

        public List<PSSqlInformationProtectionKeyword> Keywords { get; set; }
    }
}
