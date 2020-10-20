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


# ----------------------------------------------------------------------------------
# Instance pool level tests
# For the following tests below, see Common.ps1 to identify helpers (e.g. Create-InstancePoolForTest)
# ----------------------------------------------------------------------------------

<#
    .SYNOPSIS
    Tests creating an instance pool
#>
function Test-CreateInstancePool
{
    # Create an instance pool
    $props = Get-InstancePoolTestProperties
    $virtualNetwork = CreateAndGetVirtualNetworkForManagedInstance $props.vnetName $props.subnetName $props.location $props.resourceGroup
    $subnetId = $virtualNetwork.Subnets.where({ $_.Name -eq $props.subnetName })[0].Id

    $instancePool = New-AzSqlInstancePool -ResourceGroupName $props.resourceGroup -Name $props.name `
                    -Location $props.location -SubnetId $subnetId -VCore $props.vCores `
                    -Edition $props.edition -ComputeGeneration $props.computeGen `
                    -LicenseType $props.licenseType -Tag $props.tags

    Assert-InstancePoolProperties $instancePool

    # Clean up instances in pool
    Remove-ManagedInstancesInInstancePool($instancePool)
}

<#
    .SYNOPSIS
    Tests getting an instance pool
#>
function Test-GetInstancePool
{
    # Setup
    $instancePool = Create-InstancePoolForTest
    Assert-InstancePoolProperties $instancePool

    try
    {
        # Test get single - default params
        $instancePool = Get-AzSqlInstancePool -ResourceGroupName $instancePool.ResourceGroupName -Name $instancePool.InstancePoolName
        Assert-InstancePoolProperties $instancePool

        # Test get single - resource id
        $instancePool = Get-AzSqlInstancePool -ResourceId $instancePool.Id
        Assert-InstancePoolProperties $instancePool

        # Test get all in resource group - default params
        $instancePools = Get-AzSqlInstancePool -ResourceGroupName $instancePool.ResourceGroupName
        Assert-NotNull $instancePools

        # Test get all in subscription - default params
        $instancePools = Get-AzSqlInstancePool
        Assert-NotNull $instancePools
    }
    finally
    {
        # Clean up instances in pool
        Remove-ManagedInstancesInInstancePool($instancePool)
    }
}

<#
    .SYNOPSIS
    Tests updating an instance pool
#>
function Test-UpdateInstancePool
{
    # Setup
    $instancePool = Create-InstancePoolForTest

    try
    {
        # Test default
        $newTags = @{ tag1="Test1" };
        $newLicenseType = "BasePrice";
        $instancePool = Set-AzSqlInstancePool -ResourceGroupName $instancePool.ResourceGroupName -Name $instancePool.InstancePoolName `
                                              -Tags $newTags -LicenseType $newLicenseType
        Assert-InstancePoolProperties $instancePool $newTags $newLicenseType

        # Test resource id
        $newTags = @{ tag2="Test2" };
        $newLicenseType = "LicenseIncluded";
        $instancePool = Set-AzSqlInstancePool -ResourceId $instancePool.Id -LicenseType $newLicenseType -Tags $newTags
        Assert-InstancePoolProperties $instancePool $newTags $newLicenseType

        # Test input object
        $newTags = @{ tag3="Test3" };
        $newLicenseType = "BasePrice";
        $instancePool = Set-AzSqlInstancePool -InputObject $instancePool -LicenseType $newLicenseType -Tags $newTags
        Assert-InstancePoolProperties $instancePool $newTags $newLicenseType

        # Test piping
        $newTags = @{ tag4="Test4" };
        $newLicenseType = "LicenseIncluded";
        $instancePool = $instancePool | Set-AzSqlInstancePool -LicenseType $newLicenseType -Tags $newTags
        Assert-InstancePoolProperties $instancePool $newTags $newLicenseType
    }
    finally
    {
        # Clean up instances in pool
        Remove-ManagedInstancesInInstancePool($instancePool)
    }
}

<#
    .SYNOPSIS
    Tests remove an instance pool
#>
function Test-RemoveInstancePool
{
    # Setup
    $instancePool = Create-InstancePoolForTest
    Assert-InstancePoolProperties $instancePool

    try
    {
        # Test default remove instance pool
        $instancePool = Remove-AzSqlInstancePool -ResourceGroupName $instancePool.ResourceGroupName -Name $instancePool.InstancePoolName
        Assert-InstancePoolProperties $instancePool

        # Setup
        $instancePool = Create-InstancePoolForTest
        Assert-InstancePoolProperties $instancePool

        # Test input object remove instance pool
        $instancePool = Remove-AzSqlInstancePool -InputObject $instancePool
        Assert-InstancePoolProperties $instancePool

        # Setup
        $instancePool = Create-InstancePoolForTest
        Assert-InstancePoolProperties $instancePool

        # Test resource id remove instance pool
        $instancePool = Remove-AzSqlInstancePool -ResourceId $instancePool.Id
        Assert-InstancePoolProperties $instancePool

        # Setup
        $instancePool = Create-InstancePoolForTest
        Assert-InstancePoolProperties $instancePool

        # Test piping remove instance pool
        $instancePool = $instancePool | Remove-AzSqlInstancePool
        Assert-InstancePoolProperties $instancePool
    }
    finally
    {
        # Clean up instances in pool
        Remove-ManagedInstancesInInstancePool($instancePool)
    }
}


# ----------------------------------------------------------------------------------
# Managed instance in instance pool level tests
# ----------------------------------------------------------------------------------

<#
    .SYNOPSIS
    Tests creating an instance an instance pool
#>
function Test-CreateManagedInstanceInInstancePool
{
    # Setup instance pool
    $instancePool = Create-InstancePoolForTest
    Assert-InstancePoolProperties $instancePool

    # Setup managed instance params
    $managedInstanceName = Get-ManagedInstanceName
    $credential = Get-ServerCredential
    $vCores = 2
    $collation = "Serbian_Cyrillic_100_CS_AS"
    $proxyOverride = "Proxy"
    $timezoneId = "Central Europe Standard Time"

    try
    {
        # Create instance with default params with sku name in instance pool
        $managedInstance1 = New-AzSqlInstance -ResourceGroupName $instancePool.ResourceGroupName -Name $managedInstanceName `
                                             -AdministratorCredential $credential -Location $instancePool.Location -SubnetId $instancePool.SubnetId `
                                             -VCore 2 -SkuName "GP_Gen5" -LicenseType LicenseIncluded -StorageSizeInGb 32 -Collation $collation `
                                             -PublicDataEndpointEnabled -TimezoneId $timezoneId -Tag $instancePool.Tags -InstancePoolName $instancePool.InstancePoolName
        Assert-ManagedInstanceInInstancePoolProperties $managedInstance1 $instancePool

        # Create instance with default params with compute gen and edition in instance pool
        $managedInstanceName = Get-ManagedInstanceName
        $managedInstance2 = New-AzSqlInstance -ResourceGroupName $instancePool.ResourceGroupName -Name $managedInstanceName `
                                             -AdministratorCredential $credential -Location $instancePool.Location -SubnetId $instancePool.SubnetId `
                                             -VCore 2 -ComputeGeneration "Gen5" -Edition "GeneralPurpose" -LicenseType LicenseIncluded `
                                             -StorageSizeInGb 32 -Collation $collation `
                                             -PublicDataEndpointEnabled -TimezoneId $timezoneId -Tag $instancePool.Tags `
                                             -InstancePoolName $instancePool.InstancePoolName
        Assert-ManagedInstanceInInstancePoolProperties $managedInstance2 $instancePool

        # Create instance with instance pool resource id - compute gen and edition in instance pool
        $managedInstanceName = Get-ManagedInstanceName
        $managedInstance3 = New-AzSqlInstance -InstancePoolResourceId $instancePool.Id -Name $managedInstanceName `
                                             -VCore 2 -AdministratorCredential $credential -StorageSizeInGb 32 -PublicDataEndpointEnabled
        Assert-ManagedInstanceInInstancePoolProperties $managedInstance3 $instancePool

        # Create instance with instance pool object - compute gen and edition in instance pool
        $managedInstanceName = Get-ManagedInstanceName
        $managedInstance4 = New-AzSqlInstance -InstancePool $instancePool -Name $managedInstanceName -VCore 2 -AdministratorCredential $credential `
                                              -StorageSizeInGb 32 -PublicDataEndpointEnabled
        Assert-ManagedInstanceInInstancePoolProperties $managedInstance4 $instancePool

        # Create instance with piping - compute gen and edition in instance pool
        $managedInstanceName = Get-ManagedInstanceName
        $managedInstance5 = $instancePool | New-AzSqlInstance -Name $managedInstanceName -VCore 2 -AdministratorCredential $credential `
                                                               -StorageSizeInGb 32 -PublicDataEndpointEnabled
        Assert-ManagedInstanceInInstancePoolProperties $managedInstance5 $instancePool
    }
    finally
    {
        # Clean up instances in pool
        Remove-ManagedInstancesInInstancePool($instancePool)
    }
}

<#
    .SYNOPSIS
    Tests getting all managed instances in an instance pool
#>
function Test-GetManagedInstanceInInstancePool
{
    # Setup instance pool
    $instancePool = Create-InstancePoolForTest
    Assert-InstancePoolProperties $instancePool

    # Setup instances in pool
    $instance1 = Create-ManagedInstanceInInstancePoolForTest $instancePool
    $instance2 = Create-ManagedInstanceInInstancePoolForTest $instancePool

    try
    {
        # Get a single instance in a pool - default params
        $instance1 = Get-AzSqlInstance -ResourceGroupName $instance1.ResourceGroupName -Name $instance1.ManagedInstanceName
        Assert-ManagedInstanceInInstancePoolProperties $instance1 $instancePool

        # Get all instances in an instance pool - default params
        $instances = Get-AzSqlInstance -ResourceGroupName $instance1.ResourceGroupName -InstancePoolName $instancePool.InstancePoolName
        Assert-NotNull $instances

        # Get all instances in a resource group - default params
        $instances = Get-AzSqlInstance -ResourceGroupname $instance1.ResourceGroupName
        Assert-NotNull $instances

        # Get an instance using managed instance resource id
        $instance2 = Get-AzSqlInstance -ResourceId $instance2.Id
        Assert-ManagedInstanceInInstancePoolProperties $instance2 $instancePool

        # Get all instances in an instance pool using instance pool resource id
        $instances = Get-AzSqlInstance -InstancePoolResourceId $instancePool.Id
        Assert-NotNull $instances

        # Get all instances in an instance pool using instance pool object
        $instances = Get-AzSqlInstance -InstancePool $instancePool
        Assert-NotNull $instances

        # Get all instances in a subscription - default params
        $instances = Get-AzSqlInstance
        Assert-NotNull $instances
    }
    finally
    {
        # Clean up instances in pool
        Remove-ManagedInstancesInInstancePool($instancePool)
    }
}

<#
    .SYNOPSIS
    Tests updating an instance in an instance pool
#>
function Test-UpdateManagedInstanceInInstancePool
{
    # Setup instance pool
    $instancePool = Create-InstancePoolForTest
    Assert-InstancePoolProperties $instancePool

    # Create instance in pool
    $securePassword = (Get-ServerCredential).Password
    $edition = "GeneralPurpose"
    $instance = Create-ManagedInstanceInInstancePoolForTest $instancePool
    Assert-ManagedInstanceInInstancePoolProperties $instance $instancePool

    try
    {
        # Update instance in instance pool - default parameters
        $instance = Set-AzSqlInstance -ResourceGroupName $instance.ResourceGroupName -Name $instance.ManagedInstanceName `
                                      -AdministratorPassword $securePassword -Edition $edition -LicenseType LicenseIncluded `
                                      -StorageSizeInGb 32 -VCore 2 -PublicDataEndpointEnabled $true `
                                      -InstancePoolName $instancePool.InstancePoolName -Force

        # Update instance in instance pool - resource id
        $instance = Set-AzSqlInstance -ResourceId $instance.Id -AdministratorPassword $securePassword -Edition $edition `
                                      -LicenseType LicenseIncluded -StorageSizeInGb 32 -VCore 2 -PublicDataEndpointEnabled $true `
                                      -InstancePoolName $instancePool.InstancePoolName -Force

        # Update instance in instance pool - input object
        $instance = Set-AzSqlInstance -InputObject $instance -VCore 2 -InstancePoolName $instancePool.InstancePoolName -PublicDataEndpointEnabled $true -Force

        # Update instance in instance pool - piping
        $instance = $instance | Set-AzSqlInstance -VCore 2 -InstancePoolName $instancePool.InstancePoolName -PublicDataEndpointEnabled $true -Force
    }
    finally
    {
        # Clean up instances in pool
        Remove-ManagedInstancesInInstancePool($instancePool)
    }
}

<#
    .SYNOPSIS
    Tests deleting an instance in an instance pool
#>
function Test-DeleteManagedInstanceInInstancePool
{
    # Setup
    $instancePool = Create-InstancePoolForTest
    Assert-InstancePoolProperties $instancePool

    # Create an instance in pool
    $managedInstance1 = Create-ManagedInstanceInInstancePoolForTest $instancePool
    $managedInstance2 = Create-ManagedInstanceInInstancePoolForTest $instancePool
    $managedInstance3 = Create-ManagedInstanceInInstancePoolForTest $instancePool
    $managedInstance4 = Create-ManagedInstanceInInstancePoolForTest $instancePool

    try
    {
        # Delete managed instance in instance pool - default params
        $managedInstance1 = Remove-AzSqlInstance -ResourceGroupName $managedInstance1.ResourceGroupName -Name $managedInstance1.ManagedInstanceName -Force
        Assert-ManagedInstanceInInstancePoolProperties $managedInstance1 $instancePool

        # Delete managed instance in instance pool - input object
        $managedInstance2 = Remove-AzSqlInstance -InputObject $managedInstance2 -Force
        Assert-ManagedInstanceInInstancePoolProperties $managedInstance2 $instancePool

        # Delete managed instance in instance pool - resource id
        $managedInstance3 = Remove-AzSqlInstance -ResourceId $managedInstance3.Id -Force
        Assert-ManagedInstanceInInstancePoolProperties $managedInstance3 $instancePool

        # Delete managed instance in instance pool - piping
        $managedInstance4 = $managedInstance4 | Remove-AzSqlInstance -Force
        Assert-ManagedInstanceInInstancePoolProperties $managedInstance4 $instancePool
    }
    finally
    {
        # Clean up instances in pool
        Remove-ManagedInstancesInInstancePool($instancePool)
    }
}

# ----------------------------------------------------------------------------------
# Test instance pool usages
# ----------------------------------------------------------------------------------

<#
    .SYNOPSIS
    Tests get instance pool usage
#>
function Test-GetInstancePoolUsage
{
    $instancePool = Create-InstancePoolForTest
    $managedInstance1 = Create-ManagedInstanceInInstancePoolForTest $instancePool

    try
    {
        # Get instance pool usage by default parameters
        $usages = Get-AzSqlInstancePoolUsage -ResourceGroupName $instancePool.ResourceGroupname -Name $instancePool.InstancePoolName
        Assert-InstancePoolUsages $usages

        # Get instance pool usage by default parameters - expand children
        $usages = Get-AzSqlInstancePoolUsage -ResourceGroupName $instancePool.ResourceGroupName -Name $instancePool.InstancePoolName -ExpandChildren
        Assert-InstancePoolUsages $usages

        # Get instance pool usage by resource id
        $usages = Get-AzSqlInstancePoolUsage -ResourceId $instancePool.Id
        Assert-InstancePoolUsages $usages

        # Get instance pool usage by resource id - expand children
        $usages = Get-AzSqlInstancePoolUsage -ResourceId $instancePool.Id -ExpandChildren
        Assert-InstancePoolUsages $usages

        # Get instance pool usage by piping
        $usages = $instancePool | Get-AzSqlInstancePoolUsage
        Assert-InstancePoolUsages $usages

        # Get instance pool usage by piping expand children
        $usages = $instancePool | Get-AzSqlInstancePoolUsage -ExpandChildren
        Assert-InstancePoolUsages $usages
    }
    finally
    {
        # Clean up instances in pool
        Remove-ManagedInstancesInInstancePool($instancePool)
    }
}

# ----------------------------------------------------------------------------------
# Helpers
# ----------------------------------------------------------------------------------

<#
    .SYNOPSIS
    Helper for asserting that instance pool properties match
#>
function Assert-InstancePoolProperties($instancePool, $newTags = $null, $newLicenseType = $null)
{
    $props = Get-InstancePoolTestProperties
    Assert-AreEqual $instancePool.ResourceGroupName $props.resourceGroup
    Assert-AreEqual $instancePool.InstancePoolName $props.Name
    Assert-AreEqual $instancePool.VCores $props.vCores

    $subnetFormat = -join("*virtualNetworks/", $props.vnetName, "/subnets/", $props.subnetName,"*")
    $subnetMatch = $instancePool.SubnetId -like $subnetFormat
    Assert-AreEqual True $subnetMatch
    Assert-AreEqual $instancePool.ComputeGeneration $props.computeGen
    Assert-AreEqual $instancePool.Edition $props.Edition
    Assert-AreEqual $instancePool.Location $props.Location
    Assert-NotNull $instancePool.Tags

    if ($newTags -ne $null)
    {
        $newTagsKey = $newTags.Keys[0]
        $newTagsValue = $newTags[$newTagsKey]
        Assert-AreEqual True $instancePool.Tags.ContainsKey($newTagsKey)
        Assert-AreEqual $newTagsValue $instancePool.Tags[$newTagsKey]
    }
    else
    {
        Assert-AreEqual True $instancePool.Tags.ContainsKey($props.tags.Keys[0])
        Assert-AreEqual $props.tags[$props.tags.Keys[0]] $instancePool.Tags[$props.tags.Keys[0]]
    }

    if ($newLicenseType -ne $null)
    {
        Assert-AreEqual $newLicenseType $instancePool.LicenseType
    }
    else
    {
        Assert-AreEqual $props.LicenseType $instancePool.LicenseType
    }
}

<#
    .SYNOPSIS
    Helper for asserting that managed instance has properties that match instance pool properties
#>
function Assert-ManagedInstanceInInstancePoolProperties($managedInstance, $instancePool)
{
    Assert-AreEqual $instancePool.Sku.Name $managedInstance.Sku.Name
    Assert-AreEqual $instancePool.Sku.Tier $managedInstance.Sku.Tier
    Assert-AreEqual $instancePool.LicenseType $managedInstance.LicenseType
    Assert-AreEqual $instancePool.SubnetId $managedInstance.SubnetId
    Assert-AreEqual $instancePool.ResourceGroupName $managedInstance.ResourceGroupName
    Assert-AreEqual $instancePool.Location $managedInstance.Location
}

<#
    .SYNOPSIS
    Helper for asserting instance pool usage properties have values
#>
function Assert-InstancePoolUsages($usages)
{
    Assert-AreEqual True ($usages.Count -ge 3)

    Assert-AreEqual "VCores" $usages[0].Unit
    Assert-AreEqual "VCore utilization" $usages[0].name
    Assert-NotNull $usages[0].CurrentValue
    Assert-NotNull $usages[0].Limit

    Assert-AreEqual "Gigabytes" $usages[1].Unit
    Assert-AreEqual "Storage utilization" $usages[1].name
    Assert-NotNull $usages[1].CurrentValue
    Assert-NotNull $usages[1].Limit

    Assert-AreEqual "Number of Databases" $usages[2].Unit
    Assert-AreEqual "Database utilization" $usages[2].name
    Assert-NotNull $usages[2].CurrentValue
    Assert-NotNull $usages[2].Limit
}