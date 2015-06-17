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
$Location = "SouthEast Asia"
$ContainerResourceGroupName = "dev01Testing"
$ContainerResourceName = "dev01Testing"

<#
.SYNOPSIS
Tests to test list containers
#>
function Test-GetAzureBackupContainerWithoutFilterReturnsNonZeroContainers
{
	$containers = Get-AzureBackupContainer -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location
	Assert-NotNull $containers 'Container list should not be null';
}

function Test-GetAzureBackupContainerWithUniqueFilterReturnsOneContainer
{
	$container = Get-AzureBackupContainer -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -ContainerResourceGroupName $ContainerResourceGroupName -ContainerResourceName $ContainerResourceName
	Assert-NotNull $container 'Container should not be null';
	Assert-AreEqual $container.ResourceName $ContainerResourceName -CaseSensitive 'Returned container resource name (a.k.a friendly name) does not match the test VM resource name';
	Assert-AreEqual $container.ResourceGroupName $ContainerResourceGroupName -CaseSensitive 'Returned container resource group name (a.k.a parent friendly name) does not match the test VM resource group name';
}

<#
.SYNOPSIS
Tests to register the container
#>
function Test-RegisterAzureBackupContainer
{
	$jobId = Register-AzureBackupContainer -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -location $Location -Name $ContainerResourceName -ServiceName $ContainerResourceGroupName
    
    Assert-NotNull $jobId 'JobID should not be null';
}

function Test-UnregisterAzureBackupContainer
{
    $container = Get-AzureBackupContainer -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -location $Location -ContainerResourceName $ContainerResourceName -ContainerResourceGroupName $ContainerResourceGroupName
	$jobId = Unregister-AzureBackupContainer -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -location $Location -AzureBackupContainer $container
    
    Assert-NotNull $jobId 'JobID should not be null';
}