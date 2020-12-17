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
	$IncidentId = "9d9782b4-8896-414b-b22a-68618548ba5b"
	$IncidentCommentId = "9d639724-938d-4551-b7d6-ab89c9d8b7df"
	$IncidentCommentId2 = "1dc74bd0-7b2b-4ff6-b4b8-d809193c36c1"
	#Create Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId $IncidentId -Title "PoshModuleTest" -Severity Low -Status New
	#Create IncidentComment Comment
	$IncidentCommentComment = New-AzSentinelIncidentComment -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name) -IncidentCommentId $IncidentCommentId -Message "PoshModuleTest"
	$IncidentCommentComment2 = New-AzSentinelIncidentComment -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name) -IncidentCommentId $IncidentCommentId2 -Message "PoshModuleTest2"
	
	#Get Incident Commments
    $IncidentComments = Get-AzSentinelIncidentComment -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
	# Validate
	Validate-IncidentComments $IncidentComments

	#Cleanup
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
	
}

<#
.SYNOPSIS
Get Incident Comment
#>
function Get-AzSentinelIncidentComment-Get
{
	$IncidentId = "85f5ceeb-e5ae-47e5-991f-cbcbb080644c"
	$IncidentCommentId = "5fb3ef3e-cdf9-4699-ae87-4da1af12a9a7"
	#Create Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId $IncidentId -Title "PoshModuleTest" -Severity Low -Status New
	
	#Create IncidentComment
	$IncidentComment = New-AzSentinelIncidentComment -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name) -IncidentCommentId $IncidentCommentId -Message "PoshModuleTest"
		
	#Get IncidentComment
    $IncidentComment = Get-AzSentinelIncidentComment -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name) -IncidentCommentId ($IncidentComment.Name)
	# Validate
	Validate-IncidentComment $IncidentComment

	#Cleanup
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
}

<#
.SYNOPSIS
Create Incident Comment
#>
function New-AzSentinelIncidentComment-Create
{
   $IncidentId = "055ddb69-f086-4765-89f2-dafe0b9c8e74"
	$IncidentCommentId = "3d67df3d-2b58-430b-9eb4-da652bf59c4a"
	#Create Incident
	$Incident = New-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId $IncidentId -Title "PoshModuleTest" -Severity Low -Status New
	
	#Create IncidentComment
	$IncidentComment = New-AzSentinelIncidentComment -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name) -IncidentCommentId $IncidentCommentId -Message "PoshModuleTest"
		
	# Validate
	Validate-IncidentComment $IncidentComment

	#Cleanup
	Remove-AzSentinelIncident -ResourceGroupName (Get-TestResourceGroupName) -WorkspaceName (Get-TestWorkspaceName) -IncidentId ($Incident.Name)
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
function Validate-IncidentComment
{
	param($IncidentComment)

	Assert-NotNull $IncidentComment
}