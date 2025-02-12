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
Gets a database soft delet perios in days parameter
#>
function Get-Soft-Delete-Period-In-Days
{
	return New-TimeSpan -Days 365
}

<#
.SYNOPSIS
Gets a database hot cache period in days
#>
function Get-Hot-Cache-Period-In-Days
{
	return New-TimeSpan -Days 31
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
the user must specify the errorAction to -Be silent or store the record in an error variable.
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
	$Cluster.Name | Should -Be $ClusterName
	$Cluster.Location | Should -Be $Location
	$Cluster.State | Should -Be $State
	$Cluster.ProvisioningState | Should -Be  $ProvisioningState
	$Cluster.Type | Should -Be $ResourceType
    $Cluster.SkuName | Should -Be $SkuName
    $Cluster.SkuTier | Should -Be $SkuTier
	$Cluster.SkuCapacity | Should -Be $Capacity
	$Cluster.ZoneStatus | Should -Be "NonZonal"
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
		$Database.Name | Should -Be $DatabaseFullName
		$Database.Location | Should -Be $Location
		$Database.Type | Should -Be $ResourceType
		$Database.SoftDeletePeriod | Should -Be $SoftDeletePeriodInDays
		$Database.HotCachePeriod | Should -Be $HotCachePeriodInDays
}

<#
.SYNOPSIS
Validate if CMK database is valid
#>
function Validate_CMKDatabase {
	Param ([Object]$Database,
		[string]$DatabaseFullName,
		[string]$Location,
		[string]$ResourceType,
		[string]$KeyVaultPropertyKeyName,
		[string]$KeyVaultPropertyKeyVaultUri,
		[string]$KeyVaultPropertyKeyVersion,
		[string]$KeyVaultPropertyUserIdentity,
		[Nullable[timespan]]$SoftDeletePeriodInDays,
		[Nullable[timespan]]$HotCachePeriodInDays)
	$Database.Name | Should -Be $DatabaseFullName
	$Database.Location | Should -Be $Location
	$Database.Type | Should -Be $ResourceType
	$Database.SoftDeletePeriod | Should -Be $SoftDeletePeriodInDays
	$Database.HotCachePeriod | Should -Be $HotCachePeriodInDays
	$Database.KeyVaultPropertyKeyName | Should -Be $KeyVaultPropertyKeyName
	$Database.KeyVaultPropertyKeyVaultUri | Should -Be $KeyVaultPropertyKeyVaultUri
	$Database.KeyVaultPropertyKeyVersion | Should -Be $KeyVaultPropertyKeyVersion
	$Database.KeyVaultPropertyUserIdentity | Should -Be $KeyVaultPropertyUserIdentity
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
		[string]$Role, 
		[string]$AadObjectId)
		$PrincipalAssignment.Name | Should -Be $PrincipalAssignmentFullName
		$PrincipalAssignment.PrincipalId | Should -Be $PrincipalId
		$PrincipalAssignment.PrincipalType | Should -Be $PrincipalType
		$PrincipalAssignment.Role | Should -Be $Role
		$PrincipalAssignment.AadObjectId -match("^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$") | Should -Be $true
}

<#
.SYNOPSIS
Validate if script is valid
#>
function Validate_Script {
	Param ([Object]$Script,
		[string]$forceUpdateTag,
		[bool]$continueOnErros,
		[string]$clusterName,
		[string]$databaseName,
		[string]$scriptName,
		[string]$principalPermissionsAction,
		[string]$scriptLevel)
		$ScriptFullName = "$clusterName/$databaseName/$scriptName"
		$Script.Name | Should -Be $ScriptFullName
		$Script.ForceUpdateTag | Should -Be $forceUpdateTag
		$Script.PrincipalPermissionsAction | Should -Be $principalPermissionsAction
		$Script.Level | Should -Be $scriptLevel
		
}

function Validate_Inline_Script {
	Param ([Object]$Script,
		[string]$forceUpdateTag,
		[bool]$continueOnErros,
		[string]$clusterName,
		[string]$databaseName,
		[string]$scriptName,
		[string]$principalPermissionsAction,
		[string]$scriptLevel)
		$ScriptFullName = "$clusterName/$databaseName/$scriptName"
		$Script.Name | Should -Be $ScriptFullName
		$Script.ForceUpdateTag | Should -Be $forceUpdateTag
		$Script.PrincipalPermissionsAction | Should -Be $principalPermissionsAction
		$Script.Level | Should -Be $scriptLevel
}

<#
.SYNOPSIS
Validate if managed private endpoint is valid
#>
function Validate_ManagedPrivateEndpoint {
	Param ([Object]$ManagedPrivateEndpoint,
		[string]$Name)
		$ManagedPrivateEndpoint.Name -Match $Name | Should -Be $true
}

<#
.SYNOPSIS
Validate if private endpoint connection is valid
#>
function Validate_PrivateEndpointConnection {
	Param ([Object]$PrivateEndpointConnection,
		[string]$Name)
		$PrivateEndpointConnection.ResourceName | Should -Be $Name
}

<#
.SYNOPSIS
Validate if private link is valid
#>
function Validate_PrivateLink {
	Param ([Object]$PrivateLink,
		[string]$resourceId,
		[string]$Name)
		$PrivateLink.Id | Should -Be $resourceId
		$PrivateLink.Type | Should -Be "Microsoft.Kusto/Clusters/PrivateLinkResources"		
		$PrivateLink.Name | Should -Be $Name
}

<#
.SYNOPSIS
Validate if private link list is valid
#>
function Validate_PrivateLinkList {
	Param ([Object]$PrivateLinkList,
		[string]$resourceId,
		[string]$Name)
		$PrivateLinkList.Id | Should -Be $resourceId
		$PrivateLinkList.Type | Should -Be "Microsoft.Kusto/Clusters/PrivateLinkResources"		
		$PrivateLinkList.Name | Should -Be $Name
}

<#
.SYNOPSIS
Validate if data connection is valid for EventHub
#>
function Validate_EventHubDataConnection {
	Param ([Object]$DataConnection,
		[string]$dataConnectionFullName,
		[string]$location,
		[string]$eventHubResourceId,
		[string]$kind,
		[string]$databaseRouting)
		$DataConnection.Name | Should -Be $dataConnectionFullName
		$DataConnection.Location | Should -Be $location
		$DataConnection.EventHubResourceId | Should -Be $eventHubResourceId
		$DataConnection.Kind | Should -Be $kind
		$DataConnection.DatabaseRouting | Should -Be $databaseRouting
}

<#
.SYNOPSIS
Validate if data connection is valid for EventGrid
#>
function Validate_EventGridDataConnection {
	Param ([Object]$DataConnection,
		[string]$dataConnectionFullName,
		[string]$location,
		[string]$eventHubResourceId,
		[string]$storageAccountResourceId,
		[string]$kind,
		[string]$databaseRouting)
		$DataConnection.Name | Should -Be $dataConnectionFullName
		$DataConnection.Location | Should -Be $location
		$DataConnection.EventHubResourceId | Should -Be $eventHubResourceId
		$DataConnection.StorageAccountResourceId | Should -Be $storageAccountResourceId
		$DataConnection.Kind | Should -Be $kind
		$DataConnection.DatabaseRouting | Should -Be $databaseRouting
}

<#
.SYNOPSIS
Validate if data connection is valid for IotHub
#>
function Validate_IotHubDataConnection {
	Param ([Object]$DataConnection,
		[string]$dataConnectionFullName,
		[string]$location,
		[string]$iotHubResourceId,
		[string]$sharedAccessPolicyName,
		[string]$kind,
		[string]$databaseRouting)
		$DataConnection.Name | Should -Be $dataConnectionFullName
		$DataConnection.Location | Should -Be $location
		$DataConnection.IotHubResourceId | Should -Be $iotHubResourceId
		$DataConnection.SharedAccessPolicyName | Should -Be $sharedAccessPolicyName
		$DataConnection.Kind | Should -Be $kind
		$DataConnection.DatabaseRouting | Should -Be $databaseRouting
}

function Validate_AttachedDatabaseConfiguration {
	Param ([Object]$AttachedDatabaseConfigurationCreated,
		[string]$AttachedDatabaseConfigurationFullName,
		[string]$Location,
		[string]$ClusterResourceId,
		[string]$DatabaseName,
		[string]$DefaultPrincipalsModificationKind)
		$AttachedDatabaseConfigurationCreated.Name | Should -Be $AttachedDatabaseConfigurationFullName
		$AttachedDatabaseConfigurationCreated.Location | Should -Be $Location
		$AttachedDatabaseConfigurationCreated.ClusterResourceId | Should -Be $ClusterResourceId
		$AttachedDatabaseConfigurationCreated.DatabaseName | Should -Be $DatabaseName
		$AttachedDatabaseConfigurationCreated.DefaultPrincipalsModificationKind | Should -Be "Union"
}


function Validate_ClusterFollowerDatabase {
	Param ([Object]$ClusterFollowerDatabase,
		[string]$AttachedDatabaseConfigurationName,
		[string]$FollowerClusterResourceId,
		[string]$DatabaseName)
		$ClusterFollowerDatabase.AttachedDatabaseConfigurationName | Should -Be $AttachedDatabaseConfigurationName
		$ClusterFollowerDatabase.ClusterResourceId | Should -Be $FollowerClusterResourceId
		$ClusterFollowerDatabase.DatabaseName | Should -Be $DatabaseName
}

function Validate_SandboxCustomImage {
	Param ([Object]$SandboxCustomImage,
		[string]$LanguageVersion,
		[string]$RequirementsFileContent)
	$SandboxCustomImage.LanguageVersion | Should -Be $LanguageVersion
	$SandboxCustomImage.RequirementsFileContent | Should -Be $RequirementsFileContent
}
