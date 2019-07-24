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

# For the purposes of these instance pool crud tests, we'll be using the following parameters:
$instancePoolRg = "instancePoolCSSdemo";
$instancePoolName = "cssinstancepool0";
$instancePoolSubnetId = "/subscriptions/2e7fe4bd-90c7-454e-8bb6-dc44649f27b2/resourceGroups/instancePoolCSSdemo/providers/Microsoft.Network/virtualNetworks/vnet-cssinstancepool0/subnets/InstancePool";
$instancePoolTags = @{ instance="Pools" }
$instancePoolComputeGen = "Gen5"
$instancePoolEdition = "GeneralPurpose"
$instancePoolLocation = "canadacentral"
$instancePoolLicenseType = "LicenseIncluded"
$instancePoolVCores = 16

<#
    .SYNOPSIS
    Tests creating an instance pool
#>
function Test-CreateInstancePool
{
    $instancePool = Get-AzSqlInstancePool -ResourceGroupName $instancePoolRg -Name $instancePoolName

    Assert-AreEqual $instancePool.ResourceGroupName $instancePoolRg
    Assert-AreEqual $instancePool.InstancePoolName $instancePoolName
    Assert-AreEqual $instancePool.VCores 16
    Assert-AreEqual $instancePool.SubnetId $instancePoolSubnetId
    Assert-AreEqual $instancePool.ComputeGeneration "Gen5"
    Assert-AreEqual $instancePool.Edition "GeneralPurpose"
    Assert-AreEqual $instancePool.Location "canadacentral"
    Assert-AreEqual $instancePool.LicenseType "LicenseIncluded"
    Assert-AreEqual $instancePool.Tags
}

<#
    .SYNOPSIS
    Tests creating an instance an instance pool
#>
function Test-CreateManagedInstanceInInstancePool
{
    $instancePool = Get-AzSqlInstancePool -ResourceGroupName $instancePoolRg -Name $instancePoolName
}

<#
    .SYNOPSIS
    Tests updating an instance pool
#>
function Test-UpdateInstancePool
{
    $instancePool = Get-AzSqlInstancePool -ResourceGroupName $instancePoolRg -Name $instancePoolName

    $instancePool | Set-AzSqlInstancePool -Tag $instancePoolTags
}

<#
    .SYNOPSIS
    Tests updating an instance in an instance pool
#>
function Test-UpdateManagedInstanceInInstancePool
{
    $instancePool = Get-AzSqlInstancePool -ResourceGroupName $instancePoolRg -Name $instancePoolName
}

<#
    .SYNOPSIS
    Tests getting an instance pool
#>
function Test-GetInstancePool
{
    # Get a single instance pool
    $instancePool = Get-AzSqlInstancePool -ResourceGroupName $instancePoolRg -Name $instancePoolName

    Assert-AreEqual $instancePool.ResourceGroupName $instancePoolRg
    Assert-AreEqual $instancePool.InstancePoolName $instancePoolName
    Assert-AreEqual $instancePool.VCores $instancePoolVCores
    Assert-AreEqual $instancePool.SubnetId $instancePoolSubnetId
    Assert-AreEqual $instancePool.ComputeGeneration $instancePoolComputeGen
    Assert-AreEqual $instancePool.Edition $instancePoolEdition
    Assert-AreEqual $instancePool.Location $instancePoolLocation
    Assert-AreEqual $instancePool.LicenseType $instancePoolLicenseType
    Assert-AreEqual $instancePool.Tags $instancePoolTags

    # Get all instance pools in a resource group
    $instancePools = Get-AzSqlInstancePool -ResourceGroupName $instancePoolRg
    Assert-AreEqual $instancePools.Count 1

    # Gets all instance pools across a subscription
    $instancePools = Get-AzSqlInstancePool
}



<#
    .SYNOPSIS
    Tests remove an instance pool
#>
function Test-RemoveInstancePool
{
    $instancePool = Get-AzSqlInstancePool -ResourceGroupName $instancePoolRg -Name $instancePoolName
}