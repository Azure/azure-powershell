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
Tests CRUD for managed HSM.
#>
function Test-ManagedHsmCRUD {
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $hsmName = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "West Europe"
    $administrator = "2f153a9e-5be9-4f43-abd2-04561777c8b0" # (Get-AzADUser -StartsWith Beisi).Id
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
Tests managed HSM with ManagedHsmWithManagedServiceIdentity.
#>
function Test-ManagedHsmWithManagedServiceIdentity{
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $hsmName = getAssetName
    $hsmName2 = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "India"
    $hsmLocation2 = Get-Location "Microsoft.KeyVault" "managedHSMs" "East Asia"
    # bez's object id
    $administrator = "2f153a9e-5be9-4f43-abd2-04561777c8b0"
    # bez's user assigned identity
    $userAssignedIdentity = "/subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/resourceGroups/bez-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/bez-id01"
    New-AzResourceGroup -Name $rgName -Location $rgLocation
    try {
    
        # Test create a managed HSM with a UserAssignedIdentity
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -SoftDeleteRetentionInDays 7 -UserAssignedIdentity $userAssignedIdentity
        
        # Test creating a default managed HSM
        $hsm2 = New-AzKeyVaultManagedHsm -Name $hsmName2 -ResourceGroupName $rgName -Location $hsmLocation2 -Administrator $administrator -SoftDeleteRetentionInDays 7
        $hsm3 = $hsm2 | Update-AzKeyVaultManagedHsm -UserAssignedIdentity $userAssignedIdentity
        Assert-AreEqual $userAssignedIdentity $hsm3.Identity.UserAssignedIdentities[0] "update managed HSM with userAssignedIdentity"

    }finally{        
        Remove-AzResourceGroup -Name $rgName -Force
        Remove-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState -Force
        Remove-AzKeyVaultManagedHsm -Name $hsmName2 -Location $hsmLocation2 -InRemovedState -Force
    }
}

<#
.SYNOPSIS
Tests creating and updating managed HSM with PublicNetworkAccess.
#>
function Test-CreateAndUpdateManagedHsmWithPublicNetworkAccess{
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $hsmName = getAssetName
    $hsmName2 = getAssetName
    $hsmName3 = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "India"
    $hsmLocation2 = Get-Location "Microsoft.KeyVault" "managedHSMs" "East Asia"
    $hsmLocation3 = Get-Location "Microsoft.KeyVault" "managedHSMs" "West Europe"
    # bez's object id
    $administrator = "2f153a9e-5be9-4f43-abd2-04561777c8b0"
    New-AzResourceGroup -Name $rgName -Location $rgLocation
    try {
        # Test creating a default managed HSM
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -SoftDeleteRetentionInDays 90
        Assert-AreEqual "Enabled" $hsm.PublicNetworkAccess "1. The default of PublicNetworkAccess is Enabled"
        
        # Update other property, PublicNetworkAccess should not change
        $hsm = Update-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Tag @{key = "value"}
        Assert-AreEqual "Enabled" $hsm.PublicNetworkAccess "1. PublicNetworkAccess should not change"

        # Test create a managed HSM with disabled PublicNetworkAccess
        $hsm2 = New-AzKeyVaultManagedHsm -Name $hsmName2 -ResourceGroupName $rgName -Location $hsmLocation2 -Administrator $administrator -PublicNetworkAccess Disabled -SoftDeleteRetentionInDays 90
        Assert-AreEqual "Disabled" $hsm2.PublicNetworkAccess "2. create managed HSM with disabled PublicNetworkAccess"
        
        # Test updating PublicNetworkAccess as Enabled
        $hsm2 = Update-AzKeyVaultManagedHsm -Name $hsmName2 -ResourceGroupName $rgName -PublicNetworkAccess Enabled
        Assert-AreEqual "Enabled" $hsm2.PublicNetworkAccess "2. Set PublicNetworkAccess as Enabled"

        # Test create a managed HSM with enabled PublicNetworkAccess
        $hsm3 = New-AzKeyVaultManagedHsm -Name $hsmName3 -ResourceGroupName $rgName -Location $hsmLocation3 -Administrator $administrator -PublicNetworkAccess Enabled -SoftDeleteRetentionInDays 90
        Assert-AreEqual "Enabled" $hsm3.PublicNetworkAccess "3. create managed HSM with enabled PublicNetworkAccess"

        # Test updating PublicNetworkAccess as Disabled
        $hsm3 = Update-AzKeyVaultManagedHsm -Name $hsmName3 -ResourceGroupName $rgName -PublicNetworkAccess Disabled
        Assert-AreEqual "Disabled" $hsm3.PublicNetworkAccess "3. Set PublicNetworkAccess as Disabled"
    }finally{        
        Remove-AzResourceGroup -Name $rgName -Force
        Remove-AzKeyVaultManagedHsm -Name $hsmName -Location $hsmLocation -InRemovedState -Force
        Remove-AzKeyVaultManagedHsm -Name $hsmName2 -Location $hsmLocation2 -InRemovedState -Force
        Remove-AzKeyVaultManagedHsm -Name $hsmName3 -Location $hsmLocation3 -InRemovedState -Force
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
            $administrator = "37f6731d-0484-43e3-b7e2-1f1bbc562109"
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
            $administrator = "37f6731d-0484-43e3-b7e2-1f1bbc562109"
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
            # bez's object id
            $administrator = "2f153a9e-5be9-4f43-abd2-04561777c8b0"
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