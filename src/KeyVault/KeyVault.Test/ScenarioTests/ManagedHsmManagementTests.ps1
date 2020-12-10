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
Tests CRUD for Managed Hsm.
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
        $hsm = New-AzManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator
        Assert-AreEqual $hsmName $hsm.Name
        Assert-AreEqual $rgName $hsm.ResourceGroupName
        Assert-AreEqual $hsmLocation $hsm.Location
        Assert-AreEqual 1  $hsm.InitialAdminObjectIds.Count
        Assert-True  { $hsm.InitialAdminObjectIds.Contains($administrator) } 
        Assert-AreEqual "StandardB1" $hsm.Sku
        
        # Default retention days
        Assert-AreEqual 90 $hsm.SoftDeleteRetentionInDays "By default SoftDeleteRetentionInDays should be 90"

        # Test get managed HSM
        $got = Get-AzManagedHsm -Name $hsmName    
        Assert-NotNull $got
        Assert-AreEqual $hsmName $got.Name
        Assert-AreEqual $rgName $got.ResourceGroupName
        Assert-AreEqual $hsmLocation $got.Location
        
        # Test throws for existing managed HSM
        Assert-Throws { New-AzManagedHsm -Name $hsmName -ResourceGroupName $rgName -Location $hsmLocation -Administrator $administrator }

        # Test remove managed HSM
        Remove-AzManagedHsm -InputObject $got -Force
        $deletedMhsm = Get-AzManagedHsm -Name $hsmName -ResourceGroupName $rgName
        Assert-Null $deletedMhsm

        # Test throws for resourcegroup nonexistent
        Assert-Throws {  New-AzManagedHsm -Name (getAssetName) -ResourceGroupName (getAssetName) -Location $hsmLocation -Administrator $administrator }
    }

    finally {
        Remove-AzResourceGroup -Name $rgName -Force
    }
}
