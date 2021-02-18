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
function Get-AllSecurityAssessments
{
    $assessments = Get-AzSecurityAssessment
	Validate-Assessments $assessments
}

<#
.SYNOPSIS
Get security contacts on a subscription
#>
function CreateAndDelete-AzSecurityAssessment
{
	$assessmentGuid = "0338728b-bc5c-41d6-ab83-29cf28652680"

	$metadata = Get-AzSecurityAssessmentMetadata | where { $_.Name -eq $assessmentGuid }
	Assert-True { $metadata.Count -eq 0 }
	$assessments = Get-AzSecurityAssessment | where { $_.Name -eq $assessmentGuid }
	Assert-True { $assessments.Count -eq 0 }

	Set-AzSecurityAssessmentMetadata -Name $assessmentGuid -DisplayName "Testing the cmdlet" -Severity "High" -Description "Testing that creating a new metadata is working"
	$metadata = Get-AzSecurityAssessmentMetadata | where { $_.Name -eq $assessmentGuid }
	Assert-True { $metadata.Count -eq 1 }
	Set-AzSecurityAssessment -Name $assessmentGuid -StatusCode "Unhealthy"
	$assessments = Get-AzSecurityAssessment | where { $_.Name -eq $assessmentGuid }
	Assert-True { $assessments.Count -eq 1 }

	Remove-AzSecurityAssessmentMetadata -Name $assessmentGuid
	Remove-AzSecurityAssessment -Name $assessmentGuid

	$metadata = Get-AzSecurityAssessmentMetadata | where { $_.Name -eq $assessmentGuid }
	Assert-True { $metadata.Count -eq 0 }
	$assessments = Get-AzSecurityAssessment | where { $_.Name -eq $assessmentGuid }
	Assert-True { $assessments.Count -eq 0 }
}

<#
.SYNOPSIS
Validates a list of security contacts
#>
function Validate-Assessments
{
	param($assessments)

    Assert-True { $assessments.Count -gt 0 }

	Foreach($assessment in $assessments)
	{
		Validate-Assessment $assessment
	}
}

<#
.SYNOPSIS
Validates a single contact
#>
function Validate-Assessment
{
	param($assessment)

	Assert-NotNull $assessment
}