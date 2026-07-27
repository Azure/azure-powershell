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
Verifies that the value returned by a cmdlet matches one of the cmdlet's declared output types.
#>
function Check-CmdletReturnType
{
    param($cmdletName, $cmdletReturn)

    $cmdletData = Get-Command $cmdletName
    Assert-NotNull $cmdletData
    [array]$cmdletReturnTypes = $cmdletData.OutputType.Name | Foreach-Object { return ($_ -replace "Microsoft.Azure.Commands.Network.Models.","") }
    [array]$cmdletReturnTypes = $cmdletReturnTypes | Foreach-Object { return ($_ -replace "System.","") }
    $realReturnType = $cmdletReturn.GetType().Name -replace "Microsoft.Azure.Commands.Network.Models.",""
    return $cmdletReturnTypes -contains $realReturnType
}

<#
.SYNOPSIS
Creates the resource group, Virtual WAN, Virtual Hub and Network Virtual Appliance
used by the migration scenario tests, and returns the created NVA.
#>
function New-NetworkVirtualApplianceForMigration
{
    param(
        [Parameter(Mandatory = $true)] [string] $rgname,
        [Parameter(Mandatory = $true)] [string] $location,
        [Parameter(Mandatory = $true)] [string] $nvaname,
        [Parameter(Mandatory = $true)] [string] $wanname,
        [Parameter(Mandatory = $true)] [string] $hubname
    )

    $vendor = "ciscosdwan"
    $scaleunit = 20
    $version = 'latest'
    $asn = 65222
    $prefix = "10.0.0.0/16"

    New-AzResourceGroup -Name $rgname -Location $location | Out-Null
    $sku = New-AzVirtualApplianceSkuProperty -VendorName $vendor -BundledScaleUnit $scaleunit -MarketPlaceVersion $version
    Assert-NotNull $sku

    $wan = New-AzVirtualWan -ResourceGroupName $rgname -Name $wanname -Location $location
    $hub = New-AzVirtualHub -ResourceGroupName $rgname -Name $hubname -Location $location -VirtualWan $wan -AddressPrefix $prefix

    # Wait for the Virtual Hub routing state to settle before deploying the appliance.
    while ($hub.RoutingState -eq "Provisioning")
    {
        Start-TestSleep -Seconds 30
        $hub = Get-AzVirtualHub -ResourceGroupName $rgname -Name $hubname
    }
    Assert-AreEqual $hub.RoutingState "Provisioned"

    $nva = New-AzNetworkVirtualAppliance -ResourceGroupName $rgname -Name $nvaname -Location $location -VirtualApplianceAsn $asn -VirtualHubId $hub.Id -Sku $sku -CloudInitConfiguration "echo hi"
    Assert-NotNull $nva

    return $nva
}

<#
.SYNOPSIS
Validates the full internal load balancer (ILB) architecture migration workflow:
Prepare -> Execute -> Commit.
#>
function Test-NetworkVirtualApplianceIlbMigration
{
    $rgname = Get-ResourceGroupName

    # The commands are not supported in all regions yet.
    $location = "eastus2"
    $nvaname = Get-ResourceName
    $wanname = Get-ResourceName
    $hubname = Get-ResourceName
    $migrationType = "MigrateToNewILBArchitecture"

    try
    {
        $nva = New-NetworkVirtualApplianceForMigration -rgname $rgname -location $location -nvaname $nvaname -wanname $wanname -hubname $hubname

        # Prepare the appliance for the new ILB architecture.
        $prepared = Invoke-AzNetworkVirtualAppliancePrepareMigration -ResourceGroupName $rgname -Name $nvaname -MigrationType $migrationType
        Assert-NotNull $prepared
        Assert-True { Check-CmdletReturnType "Invoke-AzNetworkVirtualAppliancePrepareMigration" $prepared }
        Assert-AreEqual $nvaname $prepared.Name

        # Execute the prepared migration.
        $executed = Invoke-AzNetworkVirtualApplianceExecuteMigration -ResourceGroupName $rgname -Name $nvaname -MigrationType $migrationType
        Assert-NotNull $executed
        Assert-AreEqual $nvaname $executed.Name

        # Commit the migration to finalize the move to the new ILB architecture.
        $committed = Invoke-AzNetworkVirtualApplianceCommitMigration -ResourceGroupName $rgname -Name $nvaname -MigrationType $migrationType
        Assert-NotNull $committed
        Assert-AreEqual $nvaname $committed.Name
    }
    finally
    {
        # Clean up.
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Validates that a prepared migration can be aborted, rolling the appliance back to
its original configuration.
#>
function Test-NetworkVirtualApplianceMigrationAbort
{
    $rgname = Get-ResourceGroupName

    # The commands are not supported in all regions yet.
    $location = "eastus2"
    $nvaname = Get-ResourceName
    $wanname = Get-ResourceName
    $hubname = Get-ResourceName
    $migrationType = "MigrateToNewILBArchitecture"

    try
    {
        $nva = New-NetworkVirtualApplianceForMigration -rgname $rgname -location $location -nvaname $nvaname -wanname $wanname -hubname $hubname

        # Prepare, then abort the migration.
        $prepared = Invoke-AzNetworkVirtualAppliancePrepareMigration -ResourceGroupName $rgname -Name $nvaname -MigrationType $migrationType
        Assert-NotNull $prepared

        $aborted = Invoke-AzNetworkVirtualApplianceAbortMigration -ResourceGroupName $rgname -Name $nvaname
        Assert-NotNull $aborted
        Assert-True { Check-CmdletReturnType "Invoke-AzNetworkVirtualApplianceAbortMigration" $aborted }
        Assert-AreEqual $nvaname $aborted.Name
    }
    finally
    {
        # Clean up.
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Validates the ResourceId parameter set together with the OS version migration type.
#>
function Test-NetworkVirtualApplianceMigrationByResourceId
{
    $rgname = Get-ResourceGroupName

    # The commands are not supported in all regions yet.
    $location = "eastus2"
    $nvaname = Get-ResourceName
    $wanname = Get-ResourceName
    $hubname = Get-ResourceName
    $migrationType = "MigrateToNewOSVersion"
    $marketplaceVersion = "latest"

    try
    {
        $nva = New-NetworkVirtualApplianceForMigration -rgname $rgname -location $location -nvaname $nvaname -wanname $wanname -hubname $hubname

        # Prepare using the resource id parameter set and a target marketplace version.
        $prepared = Invoke-AzNetworkVirtualAppliancePrepareMigration -ResourceId $nva.Id -MigrationType $migrationType -MarketPlaceVersion $marketplaceVersion
        Assert-NotNull $prepared
        Assert-AreEqual $nvaname $prepared.Name

        # Abort using the resource id parameter set.
        $aborted = Invoke-AzNetworkVirtualApplianceAbortMigration -ResourceId $nva.Id
        Assert-NotNull $aborted
        Assert-AreEqual $nvaname $aborted.Name
    }
    finally
    {
        # Clean up.
        Clean-ResourceGroup $rgname
    }
}
