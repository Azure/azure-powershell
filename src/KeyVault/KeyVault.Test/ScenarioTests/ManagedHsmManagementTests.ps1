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
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "East US 2"
    $administrator = "c1be1392-39b8-4521-aafc-819a47008545"
    New-AzResourceGroup -Name $rgName -Location $rgLocation

    try {
        # Test create a default managed HSM
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator
        Assert-AreEqual $hsmName $hsm.Name
        Assert-AreEqual $rgName $hsm.ResourceGroupName
        Assert-AreEqual $hsmLocation $hsm.Location
        Assert-AreEqual 1  $hsm.InitialAdminObjectIds.Count
        Assert-True  { $hsm.InitialAdminObjectIds.Contains($administrator) } 
        Assert-AreEqual "StandardB1" $hsm.Sku
        
        # Default retention days
        Assert-AreEqual 90 $hsm.SoftDeleteRetentionInDays "By default SoftDeleteRetentionInDays should be 90"

        # Test get managed HSM
        $got = Get-AzKeyVaultManagedHsm -Name $hsmName    
        Assert-NotNull $got
        Assert-AreEqual $hsmName $got.Name
        Assert-AreEqual $rgName $got.ResourceGroupName
        Assert-AreEqual $hsmLocation $got.Location
        
        # Test throws for existing managed HSM
        Assert-Throws { New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator }

        # Test remove managed HSM
        Remove-AzKeyVaultManagedHsm -InputObject $got -Force
        $deletedMhsm = Get-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName
        Assert-Null $deletedMhsm

        # Test throws for resourcegroup nonexistent
        Assert-Throws {  New-AzKeyVaultManagedHsm -Name (getAssetName) -ResourceGroupName (getAssetName) -Location $hsmLocation -Administrator $administrator }
    }

    finally {
        Remove-AzResourceGroup -Name $rgName -Force
    }

}

<#
.SYNOPSIS
Tests creating managed HSM with PublicNetworkAccess.
#>
function Test-CreateManagedHsmWithPublicNetworkAccess{
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $hsmName = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "West US"
    # bez's object id
    $administrator = "2f153a9e-5be9-4f43-abd2-04561777c8b0"
    New-AzResourceGroup -Name $rgName -Location $rgLocation
    try {
        # Test creating a default managed HSM
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator
        Assert-AreEqual "Enabled" $hsm.PublicNetworkAccess "1. The default of PublicNetworkAccess is Enabled"
        
        # Test create a managed HSM with disabled PublicNetworkAccess
        $hsmName2 = getAssetName
        $hsm2 = New-AzKeyVaultManagedHsm -Name $hsmName2 -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -PublicNetworkAccess Disabled
        Assert-AreEqual "Disabled" $hsm2.PublicNetworkAccess "2. create managed HSM with disabled PublicNetworkAccess"

        # Test create a managed HSM with enabled PublicNetworkAccess
        $hsmName3 = getAssetName
        $hsm3 = New-AzKeyVaultManagedHsm -Name $hsmName3 -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -PublicNetworkAccess Enabled
        Assert-AreEqual "Enabled" $hsm3.PublicNetworkAccess "3. create managed HSM with enabled PublicNetworkAccess"

    }finally{
        Remove-AzResourceGroup -Name $rgName -Force
    }
}

<#
.SYNOPSIS
Tests updating managed HSM with PublicNetworkAccess.
#>
function Test-UpdateManagedHsmWithPublicNetworkAccess{
    $rgName = getAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "East US"
    $hsmName = getAssetName
    $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "West US"
    # bez's object id
    $administrator = "2f153a9e-5be9-4f43-abd2-04561777c8b0"
    New-AzResourceGroup -Name $rgName -Location $rgLocation
    try {
        # Test creating a default managed HSM
        $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator
        Assert-AreEqual "Enabled" $hsm.PublicNetworkAccess "1. The default of PublicNetworkAccess is Enabled"
        
        # Test updating PublicNetworkAccess as Disabled
        $hsm = Update-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -PublicNetworkAccess Disabled
        Assert-AreEqual "Disabled" $hsm.PublicNetworkAccess "2. Set PublicNetworkAccess as Disabled"
        
        # Update other property, PublicNetworkAccess should not change
        $hsm = Update-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Tag @{key = "value"}
        Assert-AreEqual "Disabled" $hsm.PublicNetworkAccess "3. PublicNetworkAccess should not change"

        # Test updating PublicNetworkAccess as Enabled
        $hsm = Update-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -PublicNetworkAccess Enabled
        Assert-AreEqual "Enabled" $hsm.PublicNetworkAccess "4. Set PublicNetworkAccess as Enabled"
    }finally{
        Remove-AzResourceGroup -Name $rgName -Force
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
            $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator -SoftDeleteRetentionInDays 70
            Assert-AreEqual 70 $hsm.SoftDeleteRetentionInDays "SoftDeleteRetentionInDays should be 70 as specified"

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
            $hsmLocation = Get-Location "Microsoft.KeyVault" "managedHSMs" "East US 2"
            $administrator = "37f6731d-0484-43e3-b7e2-1f1bbc562109"
            New-AzResourceGroup -Name $rgName -Location $rgLocation

            # Test: create a default managed HSM
            $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator
            
            # Test: EnablePurgeProtection
            $purgeProtectedHsm = Update-AzKeyVaultManagedHsm -InputObject $hsm -EnablePurgeProtection
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
            $hsm = New-AzKeyVaultManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator

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