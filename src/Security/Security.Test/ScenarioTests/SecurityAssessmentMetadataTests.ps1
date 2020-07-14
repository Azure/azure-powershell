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
function Get-AllSecurityAssessmentMetadata
{
    $metadata = Get-AzSecurityAssessmentMetadata
	Validate-MetadataList $metadata
}

<#
.SYNOPSIS
Get security contacts on a subscription
#>
function CreateAndDelete-AzSecurityAssessmentMetadata
{
	$assessmentGuid = "45fb078b-a96e-4d0b-90cb-f3ed8a5530c0"

	$metadata = Get-AzSecurityAssessmentMetadata | where { $_.Name -eq $assessmentGuid }
	Assert-True { $metadata.Count -eq 0 }

	Set-AzSecurityAssessmentMetadata -Name $assessmentGuid -DisplayName "Testing the cmdlet" -Severity "High" -Description "Testing that creating a new metadata is working"
	$metadata = Get-AzSecurityAssessmentMetadata | where { $_.Name -eq $assessmentGuid }
	Assert-True { $metadata.Count -eq 1 }

	Remove-AzSecurityAssessmentMetadata -Name $assessmentGuid

	$metadata = Get-AzSecurityAssessmentMetadata | where { $_.Name -eq $assessmentGuid }
	Assert-True { $metadata.Count -eq 0 }
}

<#
.SYNOPSIS
Validates a list of security contacts
#>
function Validate-MetadataList
{
	param($metadataList)

    Assert-True { $metadataList.Count -gt 0 }

	Foreach($metadata in $metadataList)
	{
		Validate-Metadata $metadata
	}
}

<#
.SYNOPSIS
Validates a single contact
#>
function Validate-Metadata
{
	param($metadata)

	Assert-NotNull $metadata
}