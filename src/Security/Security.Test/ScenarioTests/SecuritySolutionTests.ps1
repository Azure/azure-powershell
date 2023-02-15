# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Get discovered security solutions on a subscription scope
#>
function Get-AzSecuritySolution-SubscriptionScope
{
    $SecuritySolution = Get-AzSecuritySolution
	Validate-SecuritySolution $SecuritySolution
}

<#
.SYNOPSIS
Validates a list of security discoveredSecuritySolutions
#>
function Validate-SecuritySolution
{
	param($SecuritySolution)

    Assert-True { $SecuritySolution.Count -gt 0 }

	Foreach($SecuritySolution in $SecuritySolution)
	{
		Validate-SecuritySolution $SecuritySolution
	}
}

<#
.SYNOPSIS
Validates a single SecuritySolution
#>
function Validate-SecuritySolution
{
	param($SecuritySolution)

	Assert-NotNull $SecuritySolution
}