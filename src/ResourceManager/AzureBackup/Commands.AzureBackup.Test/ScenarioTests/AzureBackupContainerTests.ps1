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

$ResourceGroupName = "backuprg"
$ResourceName = "backuprn"
$Location = "westus"
$ManagedResourceGroupName = "powershellbvt"
$ManagedResourceName = "powershellbvt"

<#
.SYNOPSIS
Tests to test list containers
#>
function Test-GetAzureBackupContainerWithoutFilterReturnsNonZeroContainers
{
	$vault = Get-AzureBackupVault -Name $ResourceName;
	$containers = Get-AzureBackupContainer -vault $vault;
	Assert-NotNull $containers 'Container list should not be null';
}

function Test-GetAzureBackupContainerWithUniqueFilterReturnsOneContainer
{
	$vault = Get-AzureBackupVault -Name $ResourceName;
	$container = Get-AzureBackupContainer -vault $vault -ManagedResourceGroupName $ManagedResourceGroupName -ManagedResourceName $ManagedResourceName
	Assert-NotNull $container 'Container should not be null';
	Assert-AreEqual $container.ManagedResourceName $ManagedResourceName -CaseSensitive 'Returned container resource name (a.k.a friendly name) does not match the test VM resource name';
	Assert-AreEqual $container.ManagedResourceGroupName $ManagedResourceGroupName -CaseSensitive 'Returned container resource group name (a.k.a parent friendly name) does not match the test VM resource group name';
}

<#
.SYNOPSIS
Tests to register the container
#>
function Test-RegisterAzureBackupContainer
{
	$vault = Get-AzureBackupVault -Name $ResourceName;
	$jobId = Register-AzureBackupContainer -vault $vault -Name $ManagedResourceName -ServiceName $ManagedResourceGroupName
    
    Assert-NotNull $jobId 'JobID should not be null';
}

function Test-UnregisterAzureBackupContainer
{
	$vault = Get-AzureBackupVault -Name $ResourceName;
    $container = Get-AzureBackupContainer -vault $vault -ManagedResourceName $ManagedResourceName -ManagedResourceGroupName $ManagedResourceGroupName
	$jobId = Unregister-AzureBackupContainer -vault $vault -AzureBackupContainer $container
    
    Assert-NotNull $jobId 'JobID should not be null';
}