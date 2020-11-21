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
List IncidentComment Comments by Incident
#>
function Get-AzSentinelIncidentComment-ListbyIncident
{
	#Create Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Title "PoshModuleTest" -Severity Low -Status New
	#Create IncidentComment Comment
	$IncidentCommentComment = New-AzSentinelIncidentCommentComment -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name) -Message "PoshModuleTest"
	$IncidentCommentComment2 = New-AzSentinelIncidentCommentComment -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name) -Message "PoshModuleTest2"
	
	#Get Incident Commments
    $IncidentComments = Get-AzSentinelIncidentComment -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName)
	# Validate
	Validate-IncidentComments $IncidentComments

	#Cleanup
	Remove-Incident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
	
}

<#
.SYNOPSIS
Get Incident Comment
#>
function Get-AzSentinelIncidentComment-Get
{
	#Create Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Title "PoshModuleTest" -Severity Low -Status New
	
	#Create IncidentComment
	$IncidentComment = New-AzSentinelIncidentComment -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name) -Message "PoshModuleTest"
		
	#Get IncidentComment
    $IncidentComment = Get-AzSentinelIncidentComment -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name) -IncidentCommentId ($IncidentComment.Name)
	# Validate
	Validate-IncidentComment $IncidentComment

	#Cleanup
	Remove-Incident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
}

<#
.SYNOPSIS
Create Incident Comment
#>
function New-AzSentinelIncidentComment-Create
{
    #Create Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -Title "PoshModuleTest" -Severity Low -Status New
	
	#Create IncidentComment
	$IncidentComment = New-AzSentinelIncidentComment -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name) -Message "PoshModuleTest"
		
	# Validate
	Validate-IncidentComment $IncidentComment

	#Cleanup
	Remove-Incident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
}

<#
.SYNOPSIS
Validates a list of IncidentComments
#>
function Validate-IncidentComments
{
	param($IncidentComments)

    Assert-True { $IncidentComments.Count -gt 0 }

	Foreach($IncidentComment in $IncidentComments)
	{
		Validate-IncidentComment $IncidentComment
	}
}

<#
.SYNOPSIS
Validates a single IncidentComment
#>
function Validate-$IncidentComment
{
	param($IncidentComment)

	Assert-NotNull $IncidentComment
}