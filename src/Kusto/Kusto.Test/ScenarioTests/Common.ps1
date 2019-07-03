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
function Get-Cluster-Location
{
	return Get-Location "Microsoft.Kusto" "operations" "Central US"
}

function Get-RG-Location
{
	Get-Location "Microsoft.Resources" "resourceGroups" "Central US"
}

<#
.SYNOPSIS
Gets a name of the resource group testing.
#>
function Get-RG-Name
{
	return getAssetname
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
Gets an instance number of a machines in a cluster.
#>
function Get-Cluster-Capacity
{
	return 5
}

<#
.SYNOPSIS
Gets an instance number of a machines in a cluster.
#>
function Get-Cluster-Updated-Capacity
{
	return 10
}

<#
.SYNOPSIS
Gets a name of the cluster testing.
#>
function Get-Cluster-Name
{
	return getAssetName
	#return "kustopsclienttest"
}

<#
.SYNOPSIS
Gets a sku name
#>
function Get-Sku
{
	return "D13_v2"
}

<#
.SYNOPSIS
Gets a sku diferent sku name.
#>
function Get-Updated-Sku
{
	return "D14_v2"
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
	return getAssetName
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
	return 4
}

<#
.SYNOPSIS
Gets a database hot cache period in days
#>
function Get-Hot-Cache-Period-In-Days
{
	return 2
}

<#
.SYNOPSIS
Gets a different  database soft delet perios in days parameter ( for testing update)
#>
function Get-Updated-Soft-Delete-Period-In-Days
{
	return 6
}

<#
.SYNOPSIS
Gets a different database hot cache period in days (for testring update)
#>
function Get-Updated-Hot-Cache-Period-In-Days
{
	return 3
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
Gets a the cluster does not exist message
#>
function Get-Cluster-Not-Exist-Message
{
	Param([string]$ResourceGroupName,
		[string]$ClusterName)
	return "'Microsoft.Kusto/clusters/$ClusterName' under resource group '$ResourceGroupName' was not found"
}


<#
.SYNOPSIS
Gets a the cluster does not exist message
#>
function Get-Cluster-Name-Exists-Message
{
	Param([string]$ClusterName)
	return "Name '$ClusterName' with type Engine is already taken. Please specify a different name"
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