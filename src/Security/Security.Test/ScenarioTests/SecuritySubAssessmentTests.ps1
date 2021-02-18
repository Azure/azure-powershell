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
Get security contacts on a subscription
#>
function Get-AllSecuritySubAssessments
{
    $subassessments = Get-AzSecuritySubAssessment
	Validate-SubAssessments $subassessments
}

<#
.SYNOPSIS
Get security contacts on a subscription
#>
function Get-SingleSecuritySubAssessment
{
	$subassessments = Get-AzSecuritySubAssessment

	Get-AzSecuritySubAssessment -ResourceId $subassessments[0].Id
}

<#
.SYNOPSIS
Validates a list of security contacts
#>
function Validate-SubAssessments
{
	param($assessments)

    Assert-True { $assessments.Count -gt 0 }

	Foreach($assessment in $assessments)
	{
		Validate-SubAssessment $assessment
	}
}

<#
.SYNOPSIS
Validates a single contact
#>
function Validate-SubAssessment
{
	param($assessment)

	Assert-NotNull $assessment
}