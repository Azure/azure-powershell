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


#################################
## WorkspaceCollection Cmdlets ##
#################################

<#
.SYNOPSIS
Test Get-AzureRmPowerBIWorkspaceCollection with (List)
#>
function Test-GetWorkspaceCollection_ListAll
{
    try {
		$resourceGroup = Create-ResourceGroup
		$workspaceCollectionNames = 1..2 |% { Get-WorkspaceCollectionName }
		$newWorkspaceCollections = $workspaceCollectionNames |% { New-AzureRmPowerBIWorkspaceCollection `
			-WorkspaceCollectionName $_ `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-Location $resourceGroup.Location }

		$allWorkspaceCollections = Get-AzureRmPowerBIWorkspaceCollection

		Assert-True { $allWorkspaceCollections[$allWorkspaceCollections.Count - 2].Name -eq $workspaceCollectionNames[0] }
		Assert-True { $allWorkspaceCollections[$allWorkspaceCollections.Count - 1].Name -eq $workspaceCollectionNames[1] }
	}
	finally {
		Clean-ResourceGroup $resourceGroup.ResourceGroupName
	}
}

<#
.SYNOPSIS
Test Get-AzureRmPowerBIWorkspaceCollection with (List by RG)
#>
function Test-GetWorkspaceCollection_ListByResourceGroup
{
    try {
		$resourceGroup = Create-ResourceGroup
		$workspaceCollectionNames = 1..2 |% { Get-WorkspaceCollectionName }
		$newWorkspaceCollections = $workspaceCollectionNames |% { New-AzureRmPowerBIWorkspaceCollection `
			-WorkspaceCollectionName $_ `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-Location $resourceGroup.Location }

		$filteredWorkspaceCollections = Get-AzureRmPowerBIWorkspaceCollection -ResourceGroupName $resourceGroup.ResourceGroupName

		Assert-AreEqual $filteredWorkspaceCollections.Count $newWorkspaceCollections.Count
	}
	finally {
		Clean-ResourceGroup $resourceGroup.ResourceGroupName
	}
}

<#
.SYNOPSIS
Test Get-AzureRmPowerBIWorkspaceCollection (by RegionName and WorkspaceCollectionName)
#>
function Test-GetWorkspaceCollection_ByName
{
    try {
		$resourceGroup = Create-ResourceGroup
		$newWorkspaceCollection = New-AzureRmPowerBIWorkspaceCollection `
			-WorkspaceCollectionName $(Get-WorkspaceCollectionName) `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-Location $resourceGroup.Location

		$foundWorkspaceCollection = Get-AzureRmPowerBIWorkspaceCollection `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-WorkspaceCollectionName $newWorkspaceCollection.Name

		Assert-AreEqual $newWorkspaceCollection.Name $foundWorkspaceCollection.Name
	}
	finally {
		Clean-ResourceGroup $resourceGroup.ResourceGroupName
	}
}


#######################
## Workspace Cmdlets ##
#######################

<#
.SYNOPSIS
Test Get-AzureRmPowerBIWorkspace (Empty)
#>
function Test-GetWorkspace_EmptyCollection
{
    try {
		$resourceGroup = Create-ResourceGroup
		$newWorkspaceCollection = New-AzureRmPowerBIWorkspaceCollection `
			-WorkspaceCollectionName $(Get-WorkspaceCollectionName) `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-Location $resourceGroup.Location

		$workspaces = Get-AzureRmPowerBIWorkspace `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-WorkspaceCollectionName $newWorkspaceCollection.Name

        Assert-AreEqual 0 $workspaces.Count
	}
	finally {
		Clean-ResourceGroup $resourceGroup.ResourceGroupName
	}
}


###########################################
## WorkspaceCollectionAccessKeys Cmdlets ##
###########################################

<#
.SYNOPSIS
Test Reset-AzureRmPowerBIWorkspaceCollectionAccessKeys (Key1)
#>
function Test-ResetWorkspaceCollectionAccessKeys_Key1
{
    try {
		$resourceGroup = Create-ResourceGroup
		$newWorkspaceCollection = New-AzureRmPowerBIWorkspaceCollection `
			-WorkspaceCollectionName $(Get-WorkspaceCollectionName) `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-Location $resourceGroup.Location

		$k1 = Get-AzureRmPowerBIWorkspaceCollectionAccessKeys `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-WorkspaceCollectionName $newWorkspaceCollection.Name

		$kr = Reset-AzureRmPowerBIWorkspaceCollectionAccessKeys `
			-Key1 `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-WorkspaceCollectionName $newWorkspaceCollection.Name

		$k2 = Get-AzureRmPowerBIWorkspaceCollectionAccessKeys `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-WorkspaceCollectionName $newWorkspaceCollection.Name

        Assert-AreEqual $k1[1].Value $kr[1].Value
        Assert-AreNotEqual $k1[0].Value $kr[0].Value

        Assert-AreEqual $kr[0].Value $k2[0].Value
        Assert-AreEqual $kr[1].Value $k2[1].Value
	}
	finally {
		Clean-ResourceGroup $resourceGroup.ResourceGroupName
	}
}

<#
.SYNOPSIS
Test Reset-AzureRmPowerBIWorkspaceCollectionAccessKeys (Key2)
#>
function Test-ResetWorkspaceCollectionAccessKeys_Key2
{
    try {
		$resourceGroup = Create-ResourceGroup
		$newWorkspaceCollection = New-AzureRmPowerBIWorkspaceCollection `
			-WorkspaceCollectionName $(Get-WorkspaceCollectionName) `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-Location $resourceGroup.Location

		$k1 = Get-AzureRmPowerBIWorkspaceCollectionAccessKeys `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-WorkspaceCollectionName $newWorkspaceCollection.Name

		$kr = Reset-AzureRmPowerBIWorkspaceCollectionAccessKeys `
			-Key2 `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-WorkspaceCollectionName $newWorkspaceCollection.Name

		$k2 = Get-AzureRmPowerBIWorkspaceCollectionAccessKeys `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-WorkspaceCollectionName $newWorkspaceCollection.Name

        Assert-AreEqual $k1[0].Value $kr[0].Value
        Assert-AreNotEqual $k1[1].Value $kr[1].Value

        Assert-AreEqual $kr[0].Value $k2[0].Value
        Assert-AreEqual $kr[1].Value $k2[1].Value
	}
	finally {
		Clean-ResourceGroup $resourceGroup.ResourceGroupName
	}
}

<#
.SYNOPSIS
Test Get-AzureRmPowerBIWorkspaceCollectionAccessKeys
#>
function Test-GetWorkspaceCollectionAccessKeys
{
    try {
		$resourceGroup = Create-ResourceGroup
		$newWorkspaceCollection = New-AzureRmPowerBIWorkspaceCollection `
			-WorkspaceCollectionName $(Get-WorkspaceCollectionName) `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-Location $resourceGroup.Location

		$keys = Get-AzureRmPowerBIWorkspaceCollectionAccessKeys `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-WorkspaceCollectionName $newWorkspaceCollection.Name

        Assert-AreNotEqual $null $keys
	}
	finally {
		Clean-ResourceGroup $resourceGroup.ResourceGroupName
	}
}

<#
.SYNOPSIS
Test Remove-AzureRmPowerBIWorkspaceCollection
#>
function Test-RemoveWorkspaceCollection
{
	try {
		$resourceGroup = Create-ResourceGroup
		$newWorkspaceCollection = New-AzureRmPowerBIWorkspaceCollection `
			-WorkspaceCollectionName $(Get-WorkspaceCollectionName) `
			-ResourceGroupName $resourceGroup.ResourceGroupName `
			-Location $resourceGroup.Location

		try {
			Remove-AzureRmPowerBIWorkspaceCollection `
				-WorkspaceCollectionName $newWorkspaceCollection.Name `
				-ResourceGroupName $resourceGroup.ResourceGroupName
		}
		catch {}

		Assert-ThrowsContains { Get-AzureRmPowerBIWorkspaceCollection `
			-WorkspaceCollectionName $newWorkspaceCollection.Name `
			-ResourceGroupName $resourceGroup.ResourceGroupName } `
			"NotFound"
	}
	finally {
		Clean-ResourceGroup $resourceGroup.ResourceGroupName
	}
}