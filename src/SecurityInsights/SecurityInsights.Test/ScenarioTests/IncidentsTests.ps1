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
	#Create Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Title "PoshModuleTest" -Severity Low -Status New
	#Create Incident
	$Incident2 = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Title "PoshModuleTest2" -Severity Low -Status New
	
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
	#Create $Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Title "PoshModuleTest" -Severity Low -Status New
		
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
    #Create $Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Title "PoshModuleTest" -Severity Low -Status New
		
	# Validate
	Validate-Incident $Incident

	#Cleanup
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
}

<#
.SYNOPSIS
Update Incident
#>
function Set-AzSentinelIncident-Update
{
	#Create $Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Title "PoshModuleTest" -Severity Low -Status New
		
	#update $Incident
	$Incident = Set-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name) -Etag ($Incident.Etag) -Status Closed -Severity ($Incident.Severity) -Title ($Incident.Title) -Classification FalsePositive -ClassificationReason InaccurateData
	
	# Validate
	Validate-Incident $Incident

	#Cleanup
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
	
	
	}

<#
.SYNOPSIS
Delete Incident
#>
function Remove-AzSentinelIncident-Delete
{
	#Create $Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Title "PoshModuleTest" -Severity Low -Status New
	
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