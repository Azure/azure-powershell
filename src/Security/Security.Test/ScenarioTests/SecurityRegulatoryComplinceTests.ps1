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

$standardName = "SOC TSP"
<#
.SYNOPSIS
Get security regulatory compliance standards on a subscription
#>
function Get-AzureRmRegulatoryComplianceStandard-SubscriptionScope
{
    $regulatoryComplianceStandards = Get-AzRegulatoryComplianceStandard 
	Validate-RegulatoryComplianceObjects $regulatoryComplianceStandards
}

<#
.SYNOPSIS
Get security regulatory compliance standard
#>
function Get-AzureRmRegulatoryComplianceStandard-SubscriptionLevelResource
{
    $regulatoryComplianceStandard = Get-AzRegulatoryComplianceStandard -Name $standardName
	Validate-RegulatoryComplianceObject $regulatoryComplianceStandard
}

<#
.SYNOPSIS
Get security regulatory compliance standard by a resource ID
#>
function Get-AzureRmRegulatoryComplianceStandard-ResourceId
{
	$regulatoryComplianceStandard = Get-AzRegulatoryComplianceStandard | Select -First 1

    $regulatoryComplianceStandard = Get-AzRegulatoryComplianceStandard -ResourceId $regulatoryComplianceStandard.Id
	Validate-RegulatoryComplianceObject $regulatoryComplianceStandard
}

<#
.SYNOPSIS
Get security regulatory compliance controls on a subscription
#>
function Get-AzureRmRegulatoryComplianceControl-SubscriptionScope
{
    $regulatoryComplianceControls = Get-AzRegulatoryComplianceControl -StandardName "SOC TSP"
	Validate-RegulatoryComplianceObjects $regulatoryComplianceControls
}

<#
.SYNOPSIS
Get security regulatory compliance control
#>
function Get-AzureRmRegulatoryComplianceControl-SubscriptionLevelResource
{
    $regulatoryComplianceControl = Get-AzRegulatoryComplianceControl -StandardName "SOC TSP" -Name "C1.2"
	Validate-RegulatoryComplianceObject $regulatoryComplianceControl
}

<#
.SYNOPSIS
Get security regulatory compliance control by a resource ID
#>
function Get-AzureRmRegulatoryComplianceControl-ResourceId
{
	$regulatoryComplianceControl = Get-AzRegulatoryComplianceControl -StandardName "SOC TSP" | Select -First 1

    $regulatoryComplianceControl = Get-AzRegulatoryComplianceControl -ResourceId $regulatoryComplianceControl.Id
	Validate-RegulatoryComplianceObject $regulatoryComplianceControl
}

<#
.SYNOPSIS
Get security regulatory compliance assessments on a subscription
#>
function Get-AzureRmRegulatoryComplianceAssessment-SubscriptionScope
{
    $regulatoryComplianceAssessments = Get-AzRegulatoryComplianceAssessment -StandardName "SOC TSP" -ControlName "CC5.8"
	Validate-RegulatoryComplianceObjects $regulatoryComplianceAssessments
}

<#
.SYNOPSIS
Get security regulatory compliance assessment
#>
function Get-AzureRmRegulatoryComplianceAssessment-SubscriptionLevelResource
{
    $regulatoryComplianceAssessment = Get-AzRegulatoryComplianceAssessment -StandardName "SOC TSP" -ControlName "CC5.8" -Name "fe48038b-f73a-4264-b499-0ff9dfaab05c"
	Validate-RegulatoryComplianceObject $regulatoryComplianceAssessment
}

<#
.SYNOPSIS
Get security regulatory compliance assessment by a resource ID
#>
function Get-AzureRmRegulatoryComplianceAssessment-ResourceId
{
	$regulatoryComplianceAssessment = Get-AzRegulatoryComplianceAssessment -StandardName "SOC TSP" -ControlName "CC5.8" | Select -First 1

    $regulatoryComplianceAssessment = Get-AzRegulatoryComplianceAssessment -ResourceId $regulatoryComplianceAssessment.Id
	Validate-RegulatoryComplianceObject $regulatoryComplianceAssessment
}


<#
.SYNOPSIS
Validates a list of regulatoryComplianceObject (can be standard, control or assessment)
#>
function Validate-RegulatoryComplianceObjects
{
	param($regulatoryComplianceObjects)

    Assert-True { $regulatoryComplianceObjects.Count -gt 0 }

	Foreach($regulatoryComplianceObject in $regulatoryComplianceObjects)
	{
		Validate-RegulatoryComplianceObject $regulatoryComplianceObject
	}
}

<#
.SYNOPSIS
Validates a single regulatoryComplianceObject (can be standard, control or assessment)
#>
function Validate-RegulatoryComplianceObject
{
	param($regulatoryComplianceObject)

	Assert-NotNull $regulatoryComplianceObject
}