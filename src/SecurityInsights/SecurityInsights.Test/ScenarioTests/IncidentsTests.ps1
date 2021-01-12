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
List Incidents
#>
function Get-AzSentinelIncident-List
{
	$IncidentId = "9948fe0a-433c-4230-ab18-41ba430d68bc"
	$IncidentId2 = "93a8577f-b4e6-4225-9240-57bd52238502"
	#Create Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId $IncidentId -Title "PoshModuleTest" -Severity Low -Status New
	#Create Incident
	$Incident2 = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId $IncidentId2 -Title "PoshModuleTest2" -Severity Low -Status New
	
	#Get Incidents
    $Incidents = Get-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName)
	# Validate
	Validate-Incidents $Incidents

	#Cleanup
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident2.Name)
}

<#
.SYNOPSIS
Get Incident
#>
function Get-AzSentinelIncident-Get
{
	$IncidentId = "a45dd647-301b-427b-ac4c-6455f65d3081"
	#Create $Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId $IncidentId -Title "PoshModuleTest" -Severity Low -Status New
		
	#Get Incident
    $Incident = Get-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
	# Validate
	Validate-Incident $Incident

	#Cleanup
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
}

<#
.SYNOPSIS
Create Incident
#>
function New-AzSentinelIncident-Create
{
    $IncidentId = "1877f91c-570c-46aa-8a2e-b2c6c3fd4a37"
	#Create $Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId $IncidentId -Title "PoshModuleTest" -Severity Low -Status New
		
	# Validate
	Validate-Incident $Incident

	#Cleanup
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
}

<#
.SYNOPSIS
Update Incident
#>
function Update-AzSentinelIncident-Update
{
	$IncidentId = "4c3f56e0-c40c-4c03-af08-a40f6be36715"
	#Create $Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId $IncidentId -Title "PoshModuleTest" -Severity Low -Status New
		
	#update $Incident
	$Incident = Update-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name) -Status Closed -Classification FalsePositive -ClassificationReason InaccurateData
	
	# Validate
	Validate-Incident $Incident

	#Cleanup
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
	
	
	}

	function Update-AzSentinelIncident-InputObject
{
	$IncidentId = "1624cb38-732b-4775-9aef-6206344b3b92"
	#Create $Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId $IncidentId -Title "PoshModuleTest" -Severity Low -Status New
	#update $Incident
	$Incident2 =  Update-AzSentinelIncident -Severity Medium -InputObject $Incident
	
	# Validate
	Validate-Incident $Incident2

	#Cleanup
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
	
	
	}

<#
.SYNOPSIS
Delete Incident
#>
function Remove-AzSentinelIncident-Delete
{
	$IncidentId = "a91c3054-ced5-4e5b-90ba-ef3d031a34e2"
	#Create $Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId $IncidentId -Title "PoshModuleTest" -Severity Low -Status New
	
	#delete
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
	# Validate
	Validate-Incident $Incident

	#Cleanup
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
}

<#
.SYNOPSIS
Validates a list of Incidents
#>
function Validate-Incidents
{
	param($Incidents)

    Assert-True { $Incidents.Count -gt 0 }

	Foreach($Incident in $Incidents)
	{
		Validate-Incident $Incident
	}
}

<#
.SYNOPSIS
Validates a single Incident
#>
function Validate-Incident
{
	param($Incident)

	Assert-NotNull $Incident
}