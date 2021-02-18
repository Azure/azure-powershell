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

using Microsoft.Azure.Commands.HealthcareApis.Properties;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Common
{
    public static class HealthcareApisArgumentValidator
    {
        public static bool ValidateObjectId(string accessPolicyObjectId)
        {
            if (!Guid.TryParse(accessPolicyObjectId, out _))
            {
                throw new PSArgumentException(Resources.invalidAccessPolicyObjectIdMessage);
            }

            return true;
        }
    }
}
