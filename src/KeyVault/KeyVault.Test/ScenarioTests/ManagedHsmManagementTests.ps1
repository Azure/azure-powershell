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

# Replace with Object id of operator of tests
$administrator = "2f153a9e-5be9-4f43-abd2-04561777c8b0"

# Replace with a userAssignedIdentity of operator of tests
$userAssignedIdentity = "/subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourcegroups/dl-hsm-kv/providers/Microsoft.ManagedIdentity/userAssignedIdentities/daniel-id01"

<#
.SYNOPSIS
Tests CRUD for managed HSM.
#>
function Test-ManagedHsmCRUD {
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $hsmName = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "West Europe"

    New-AzResourceGroup -Name $rgName -Location $rgLocation

    try {
        # Test create a default managed HSM
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -SoftDeleteRetentionInDays 7
        Assert-AreEqual $hsmName $hsm.Name
        Assert-AreEqual $rgName $hsm.ResourceGroupName
        Assert-AreEqual $hsmLocation $hsm.Location
        Assert-AreEqual 1  $hsm.InitialAdminObjectIds.Count
        Assert-True  { $hsm.InitialAdminObjectIds.Contains($administrator) } 
        Assert-AreEqual "StandardB1" $hsm.Sku
        Assert-AreEqual 7 $hsm.SoftDeleteRetentionInDays

        # Test get managed HSM
        $got = Get-AzKeyVaultManagedHsm -Name $hsmName    
        Assert-NotNull $got
        Assert-AreEqual $hsmName $got.Name
        Assert-AreEqual $rgName $got.ResourceGroupName
        Assert-AreEqual $hsmLocation $got.Location
        Assert-NotNull $got.SecurityDomain

        # Test throws for existing managed HSM
        Assert-Throws { New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -SoftDeleteRetentionInDays 7}

        # Test remove managed HSM
        Remove-AzKeyVaultManagedHsm -InputObject $got -Force
        $deletedMhsm = Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName
        Assert-Null $deletedMhsm

        # Test throws for resourcegroup nonexistent
        Assert-Throws {  New-AzKeyVaultManagedHsm -Name (getAssetName) -ResourceGroupName (getAssetName) -Location $hsmLocation -Administrator $administrator -SoftDeleteRetentionInDays 7}
    }

    finally {
        # Clean Up
        Remove-AzResourceGroup -Name $rgName -Force        
        Remove-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState -Force
    }
}

<#
.SYNOPSIS
Tests creating new managed HSM with UserAssignedIdentity.
#>
function Test-NewManagedHsmWithManagedServiceIdentity{
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $hsmName = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "India"

    New-AzResourceGroup -Name $rgName -Location $rgLocation

    try {
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -SoftDeleteRetentionInDays 7 -UserAssignedIdentity $userAssignedIdentity
        
        Assert-NotNull $hsm
        Assert-True ($hsm.Identity.UserAssignedIdentities.ContainsKey($userAssignedIdentity)) "Failed to create managed HSM with userAssignedIdentity"

    }finally{        
        Remove-AzResourceGroup -Name $rgName -Force
        Remove-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState -Force
    }
}

<#
.SYNOPSIS
Tests updating existing HSM with UserAssignedIdentity.
#>
function Test-UpdateManagedHsmWithManagedServiceIdentity{
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $hsmName = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "East Asia"

    New-AzResourceGroup -Name $rgName -Location $rgLocation

    try {
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -SoftDeleteRetentionInDays 7

        # below fails as "userAssignedIdentity" property is top level (same as `tags`)
        $hsm2 = $hsm | Update-AzKeyVaultManagedHsm -UserAssignedIdentity $userAssignedIdentity
        Assert-AreEqual $userAssignedIdentity $hsm2.Identity.UserAssignedIdentities[0] "update managed HSM with userAssignedIdentity"

    }finally{        
        Remove-AzResourceGroup -Name $rgName -Force
        Remove-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState -Force
    }
}

<#
.SYNOPSIS
Tests creating and updating managed HSM with PublicNetworkAccess. Updating tag should not change PublicNetworkAccess
#>
function Test-CreateManagedHsmDefaultPublicNetworkAccess {
    # @NOTE: this flow currently breaks on update (500 error)
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $hsmName = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "Central India"

    New-AzResourceGroup -Name $rgName -Location $rgLocation

    try {
        # Create default managed HSM (PublicNetworkAccess should be Enabled by default)
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -SoftDeleteRetentionInDays 90
        Assert-AreEqual "Enabled" $hsm.PublicNetworkAccess "Default PublicNetworkAccess should be Enabled"
        
        # Update tag, PublicNetworkAccess should not change
        $hsm = Update-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Tag @{ key = "value" }
        Assert-AreEqual "Enabled" $hsm.PublicNetworkAccess "PublicNetworkAccess should remain Enabled after update"
    }
    finally {
        Remove-AzResourceGroup -Name $rgName -Force
        Remove-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState -Force
    }
}

<#
.SYNOPSIS
Tests creating and updating managed HSM with PublicNetworkAccess. Creating with disabled, then changing to enabled
#>
function Test-CreateManagedHsmWithDisabledPublicNetworkAccess {
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $hsmName = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "East Asia"

    New-AzResourceGroup -Name $rgName -Location $rgLocation

    try {
        # Create managed HSM with PublicNetworkAccess Disabled
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -PublicNetworkAccess Disabled -SoftDeleteRetentionInDays 90
        Assert-AreEqual "Disabled" $hsm.PublicNetworkAccess "Create with PublicNetworkAccess Disabled"
        
        # Update PublicNetworkAccess to Enabled
        $hsm = Update-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -PublicNetworkAccess Enabled
        Assert-AreEqual "Enabled" $hsm.PublicNetworkAccess "Update PublicNetworkAccess to Enabled"
    }
    finally {
        Remove-AzResourceGroup -Name $rgName -Force
        Remove-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState -Force
    }
}

<#
.SYNOPSIS
Tests creating and updating managed HSM with PublicNetworkAccess. Creating with enabled, then changing to disabled
#>
function Test-CreateManagedHsmWithEnabledPublicNetworkAccess {
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $hsmName = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "West Europe"

    New-AzResourceGroup -Name $rgName -Location $rgLocation

    try {
        # Create managed HSM with PublicNetworkAccess Enabled explicitly
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -PublicNetworkAccess Enabled -SoftDeleteRetentionInDays 90
        Assert-AreEqual "Enabled" $hsm.PublicNetworkAccess "Create with PublicNetworkAccess Enabled"
        
        # Update PublicNetworkAccess to Disabled
        $hsm = Update-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -PublicNetworkAccess Disabled
        Assert-AreEqual "Disabled" $hsm.PublicNetworkAccess "Update PublicNetworkAccess to Disabled"
    }
    finally {
        Remove-AzResourceGroup -Name $rgName -Force
        Remove-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState -Force
    }
}

<#
.SYNOPSIS
Tests soft delete for managed HSM.
#>
function Test-ManagedHsmSoftDelete{
    try{
            $rgName = getAssetName
            $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
            $hsmName = getAssetName
            $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "West US"

            New-AzResourceGroup -Name $rgName -Location $rgLocation

            # Test: create a SoftDeleteRetentionInDays-specified managed HSM
            $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -SoftDeleteRetentionInDays 7
            Assert-AreEqual 7 $hsm.SoftDeleteRetentionInDays "SoftDeleteRetentionInDays should be 7 as specified"

            Remove-AzKeyVaultManagedHsm -InputObject $hsm -Force
            
            # Test: get deleted managed HSM
            $deletedMhsm = Get-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState
            Assert-NotNull $deletedMhsm

            # Test: purge deleted managed Hsm
            Remove-AzKeyVaultManagedHsm -InputObject $deletedMhsm -InRemovedState -Force
    }
    finally {
        Remove-AzResourceGroup -Name $rgName -Force
    }
}

<#
.SYNOPSIS
Tests purge protection for managed HSM.
#>
function Test-ManagedHsmPurgeProtection{
    try{
            $rgName = getAssetName
            $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
            $hsmName = getAssetName
            $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "East Asia"

            New-AzResourceGroup -Name $rgName -Location $rgLocation

            # Test: create a default managed HSM
            $purgeProtectedHsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -EnablePurgeProtection -SoftDeleteRetentionInDays 7
            Assert-AreEqual $true $purgeProtectedHsm.EnablePurgeProtection
            
            # Test: purge deleted managed Hsm            
            Remove-AzKeyVaultManagedHsm -InputObject $purgeProtectedHsm -Force
            Assert-Throws { Remove-AzKeyVaultManagedHsm -InputObject $deletedMhsm -InRemovedState -Force}
    }
    finally {
        Remove-AzResourceGroup -Name $rgName -Force
    }
}

function Test-UndoManagedHsmRemoval{
    try{
            $rgName = getAssetName
            $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
            $hsmName = getAssetName
            $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "West US"
            
            New-AzResourceGroup -Name $rgName -Location $rgLocation

            # Test: create a managed HSM
            $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -SoftDeleteRetentionInDays 7

            Remove-AzKeyVaultManagedHsm -InputObject $hsm -Force
            
            # Test: get deleted managed HSM
            $deletedMhsm = Get-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState
            Assert-NotNull $deletedMhsm

            # Test: recover deleted managed Hsm
            Undo-AzKeyVaultManagedHsmRemoval -InputObject $deletedMhsm
            $recoveredMhsm = Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName
            Assert-NotNull $recoveredMhsm
    }
    finally {
        Remove-AzResourceGroup -Name $rgName -Force
    }
}
