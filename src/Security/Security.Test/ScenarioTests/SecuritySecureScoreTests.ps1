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
Get security secure scores on a subscription
#>
function Get-AllSecuritySecureScores
{
    $secureScores = Get-AzSecuritySecureScore
	Validate-SecureScores $secureScores
}


<#
.SYNOPSIS
Get ascScore security secure score on a subscription
#>
function Get-SecuritySecureScore
{
    $ascSecureScore = Get-AzSecuritySecureScore -Name "ascScore"
	Validate-SecureScore $ascSecureScore
}

<#
.SYNOPSIS
Validates a list of security secure scores
#>
function Validate-SecureScores
{
	param($secureScores)

    Assert-True { $secureScores.Count -gt 0 }

	Foreach($secureScore in $secureScores)
	{
		Validate-SecureScore $secureScore
	}
}

<#
.SYNOPSIS
Validates a single secure score
#>
function Validate-SecureScore
{
	param($secureScore)

	Assert-NotNull $secureScore
}