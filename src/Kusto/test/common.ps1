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
Gets resource location for testing.
#>
function Get-Location
{
	return "East US"
}

<#
.SYNOPSIS
Gets a name of the resource group testing.
#>
function Get-RG-Name
{
	return "sdkpowershellrg"
}

<#
.SYNOPSIS
Gets an instance number of a machines in a cluster.
#>
function Get-Cluster-Default-Capacity
{
	return 2
}

<#
.SYNOPSIS
Gets a name of the cluster testing.
#>
function Get-Cluster-Name
{
	return "sdkpsclustereu"
}

<#
.SYNOPSIS
Gets a sku name
#>
function Get-SkuName
{
	return "Standard_D11_v2"
}

<#
.SYNOPSIS
Gets sku tier
#>
function Get-SkuTier
{
	return "Standard"
}

<#
.SYNOPSIS
Gets a sku diferent sku name.
#>
function Get-Updated-SkuName
{
	return "Standard_D12_v2"
}

<#
.SYNOPSIS
Gets a name of a not existing resource group for testing.
#>
function Get-Cluster-Resource-Type
{
	return "Microsoft.Kusto/Clusters"
}

<#
.SYNOPSIS
Gets a name of the cluster principalassignment testing.
#>
function Get-PrincipalAssignment-Name
{
	return "principalassignment1"
}

<#
.SYNOPSIS
Gets a name of the cluster principalassignment principalId.
#>
function Get-PrincipalAssignment-PrincipalId
{
	return "e60fe5c8-d6a5-4dee-b382-fb4502588dd0"
}

<#
.SYNOPSIS
Gets a name of the cluster principalassignment principalType.
#>
function Get-PrincipalAssignment-PrincipalType
{
	return "App"
}

<#
.SYNOPSIS
Gets a name of the cluster principalassignment Role.
#>
function Get-Cluster-PrincipalAssignment-Role
{
	return "AllDatabasesViewer"
}

<#
.SYNOPSIS
Gets a name of the cluster principalassignment Role.
#>
function Get-Database-PrincipalAssignment-Role
{
	return "Viewer"
}

<#
.SYNOPSIS
Gets a cluster resource id
#>
function Get-Cluster-Resource-Id
{
	Param([string]$Subscription,
		[string]$ResourceGroupName,
		[string]$ClusterName)
	return "/subscriptions/$Subscription/resourceGroups/$ResourceGroupName/providers/Microsoft.Kusto/clusters/$ClusterName"
}

<#
.SYNOPSIS
Gets a database resource id
#>
function Get-Database-Resource-Id
{
	Param([string]$Subscription,
		[string]$ResourceGroupName,
		[string]$ClusterName,
		[string]$DatabaseName)
	$clusterResourceId = Get-Cluster-Resource-Id -Subscription $Subscription -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName
	return "$clusterResourceId/databases/$DatabaseName"
}


<#
.SYNOPSIS
Gets a database name
#>
function Get-Database-Name
{
	return "sdkpowershelldb"
}

<#
.SYNOPSIS
Gets a database type
#>
function Get-Database-Type
{
	return "Microsoft.Kusto/Clusters/Databases"
}

<#
.SYNOPSIS
Gets a database soft delet perios in days parameter
#>
function Get-Soft-Delete-Period-In-Days
{
	return New-TimeSpan -Days 4
}

<#
.SYNOPSIS
Gets a database hot cache period in days
#>
function Get-Hot-Cache-Period-In-Days
{
	return New-TimeSpan -Days 2
}

<#
.SYNOPSIS
Gets a different  database soft delet perios in days parameter ( for testing update)
#>
function Get-Updated-Soft-Delete-Period-In-Days
{
	return New-TimeSpan -Days 6
}

<#
.SYNOPSIS
Gets a different database hot cache period in days (for testring update)
#>
function Get-Updated-Hot-Cache-Period-In-Days
{
	return New-TimeSpan -Days 3
}

<#
.SYNOPSIS
Gets a the database does not exist message
#>
function Get-Database-Not-Exist-Message
{
	Param([string]$DatabaseName)
	return "$DatabaseName' is not found"
}


<#
.SYNOPSIS
Executes a cmdlet and enables ignoring of errors if desired
NOTE: this only catches errors that are thrown. If the command calls to Write-Error
the user must specify the errorAction to be silent or store the record in an error variable.
#>
function Invoke-HandledCmdlet
{
	param
	(
		[ScriptBlock] $Command,
		[switch] $IgnoreFailures
	)
	
	try
	{
		&$Command
	}
	catch
	{
		if(!$IgnoreFailures)
		{
			throw;
		}
	}
}

<#
.SYNOPSIS
Validate if cluster is valid
#>
function Validate_Cluster{
	Param ([Object]$Cluster,
		[string]$ClusterName,
		[string]$Location,
		[string]$State,
		[string]$ProvisioningState,
		[string]$ResourceType,
        [string]$SkuName,
        [string]$SkuTier,
		[int]$Capacity)
	$Cluster.Name | Should Be $ClusterName
	$Cluster.Location | Should Be $Location
	$Cluster.State | Should Be $State
	$Cluster.ProvisioningState | Should Be  $ProvisioningState
	$Cluster.Type | Should Be $ResourceType
    $Cluster.SkuName | Should Be $SkuName
    $Cluster.SkuTier | Should Be $SkuTier 
	$Cluster.SkuCapacity | Should Be $Capacity
}

<#
.SYNOPSIS
Validate if database is valid
#>
function Validate_Database {
	Param ([Object]$Database,
		[string]$DatabaseFullName,
		[string]$Location,
		[string]$ResourceType,
		[Nullable[timespan]]$SoftDeletePeriodInDays,
		[Nullable[timespan]]$HotCachePeriodInDays)
		$Database.Name | Should Be $DatabaseFullName
		$Database.Location | Should Be $Location
		$Database.Type | Should Be $ResourceType
		$Database.SoftDeletePeriod | Should Be $SoftDeletePeriodInDays 
		$Database.HotCachePeriod | Should Be $HotCachePeriodInDays
}

<#
.SYNOPSIS
Validate if database is valid
#>
function Validate_PrincipalAssignment {
	Param ([Object]$PrincipalAssignment,
		[string]$PrincipalAssignmentFullName,
		[string]$PrincipalId,
		[string]$PrincipalType,
		[string]$Role)
		$PrincipalAssignment.Name | Should Be $PrincipalAssignmentFullName
		$PrincipalAssignment.PrincipalId | Should Be $PrincipalId
		$PrincipalAssignment.PrincipalType | Should Be $PrincipalType
		$PrincipalAssignment.Role | Should Be $Role 
}
