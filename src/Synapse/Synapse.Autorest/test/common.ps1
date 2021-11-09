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
Validate if kusto pool is valid
#>
function Validate_Cluster{
	Param ([Object]$KustoPool,
		[string]$workspaceName,
		[string]$KustoPoolName,
		[string]$Location,
		[string]$State,
		[string]$ProvisioningState,
		[string]$ResourceType,
        [string]$SkuName,
        [string]$SkuSize,
		[int]$Capacity)
	$KustoPool.Name | Should -Be ($workspaceName + "/" + $KustoPoolName)
	$KustoPool.Location | Should -Be $Location
	$KustoPool.State | Should -Be $State
	$KustoPool.ProvisioningState | Should -Be  $ProvisioningState
	$KustoPool.Type | Should -Be $ResourceType
    $KustoPool.SkuName | Should -Be $SkuName
    $KustoPool.SkuSize | Should -Be $SkuSize
	$KustoPool.SkuCapacity | Should -Be $Capacity
}

<#
.SYNOPSIS
Validate principal assignment
#>
function Validate_PrincipalAssignment {
	Param ([Object]$PrincipalAssignment,
		[string]$PrincipalAssignmentFullName,
		[string]$PrincipalId,
		[string]$PrincipalType,
		[string]$Role)
		$PrincipalAssignment.Name | Should -Be $PrincipalAssignmentFullName
		$PrincipalAssignment.PrincipalId | Should -Be $PrincipalId
		$PrincipalAssignment.PrincipalType | Should -Be $PrincipalType
		$PrincipalAssignment.Role | Should -Be $Role
}

<#
.SYNOPSIS
Gets a kusto database soft delet perios in days parameter
#>
function Get-Soft-Delete-Period-In-Days
{
	return New-TimeSpan -Days 4
}

<#
.SYNOPSIS
Gets a kusto database hot cache period in days
#>
function Get-Hot-Cache-Period-In-Days
{
	return New-TimeSpan -Days 2
}

<#
.SYNOPSIS
Validate if kusto database is valid
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

function Validate_AttachedDatabaseConfiguration {
	Param ([Object]$AttachedDatabaseConfigurationCreated,
		[string]$AttachedDatabaseConfigurationFullName,
		[string]$Location,
		[string]$KustoPoolResourceId,
		[string]$DatabaseName,
		[string]$DefaultPrincipalsModificationKind)
		$AttachedDatabaseConfigurationCreated.Name | Should -Be $AttachedDatabaseConfigurationFullName
		$AttachedDatabaseConfigurationCreated.Location | Should -Be $Location
		$AttachedDatabaseConfigurationCreated.KustoPoolResourceId | Should -Be $KustoPoolResourceId
		$AttachedDatabaseConfigurationCreated.DatabaseName | Should -Be $DatabaseName
		$AttachedDatabaseConfigurationCreated.DefaultPrincipalsModificationKind | Should -Be $DefaultPrincipalsModificationKind
}

function Validate_ClusterFollowerDatabase {
	Param ([Object]$ClusterFollowerDatabase,
		[string]$AttachedDatabaseConfigurationName,
		[string]$FollowerClusterResourceId,
		[string]$DatabaseName)
		$ClusterFollowerDatabase.AttachedDatabaseConfigurationName | Should -Be $AttachedDatabaseConfigurationName
		$ClusterFollowerDatabase.KustoPoolResourceId | Should -Be $FollowerClusterResourceId
		$ClusterFollowerDatabase.DatabaseName | Should -Be $DatabaseName
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
		[string]$kind)
		$DataConnection.Name | Should -Be $dataConnectionFullName
		$DataConnection.Location | Should -Be $location
		$DataConnection.EventHubResourceId | Should -Be $eventHubResourceId
		$DataConnection.Kind | Should -Be $kind
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
		[string]$kind)
		$DataConnection.Name | Should -Be $dataConnectionFullName
		$DataConnection.Location | Should -Be $location
		$DataConnection.EventHubResourceId | Should -Be $eventHubResourceId
		$DataConnection.StorageAccountResourceId | Should -Be $storageAccountResourceId
		$DataConnection.Kind | Should -Be $kind
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
		[string]$kind)
		$DataConnection.Name | Should -Be $dataConnectionFullName
		$DataConnection.Location | Should -Be $location
		$DataConnection.IotHubResourceId | Should -Be $iotHubResourceId
		$DataConnection.SharedAccessPolicyName | Should -Be $sharedAccessPolicyName
		$DataConnection.Kind | Should -Be $kind
}
