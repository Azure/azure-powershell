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
Create Get and Delete Spatial Anchors Account
#>
function Test-SpatialAnchorsAccountOperations
{
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS2"
    $accountName = getAssetName

    $createdAccount = New-AzSpatialAnchorsAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName -Location $resourceLocation
    Assert-AreEqual $accountName $createdAccount.Name
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdAccount.ResourceGroupName
    Assert-AreEqual $resourceLocation $createdAccount.Location

    $account = Get-AzSpatialAnchorsAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName
    Assert-AreEqual $accountName $account.Name
    Assert-AreEqual $resourceGroup.ResourceGroupName $account.ResourceGroupName
    Assert-AreEqual $resourceLocation $account.Location

	Assert-ThrowsContains { New-AzSpatialAnchorsAccountKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName -Force } "Parameter set cannot be resolved using the specified named parameters."

	$old = Get-AzSpatialAnchorsAccountKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName
	$new = New-AzSpatialAnchorsAccountKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName -Primary -Force
	Assert-AreNotEqual $old.PrimaryKey $new.PrimaryKey

	$old = $new
	$new = New-AzSpatialAnchorsAccountKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName -Secondary -Force
	Assert-AreNotEqual $old.SecondaryKey $new.SecondaryKey

    $accountRemoved = Remove-AzSpatialAnchorsAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName -PassThru
    Assert-True{$accountRemoved}

    Assert-ThrowsContains { Get-AzSpatialAnchorsAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName } "NotFound"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Create Get and Delete Spatial Anchors Account
#>
function Test-SpatialAnchorsAccountOperationsWithPiping
{
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS2"
    $accountName = getAssetName

    $createdAccount = New-AzSpatialAnchorsAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName -Location $resourceLocation
    Assert-AreEqual $accountName $createdAccount.Name
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdAccount.ResourceGroupName
    Assert-AreEqual $resourceLocation $createdAccount.Location

	Assert-ThrowsContains { $createdAccount | New-AzSpatialAnchorsAccountKey -Force } "Parameter set cannot be resolved using the specified named parameters."

	$old = $createdAccount | Get-AzSpatialAnchorsAccountKey
	$new = $createdAccount | New-AzSpatialAnchorsAccountKey -Primary -Force
	Assert-AreNotEqual $old.PrimaryKey $new.PrimaryKey

	$old = $new
	$new = $createdAccount | New-AzSpatialAnchorsAccountKey -Secondary -Force
	Assert-AreNotEqual $old.SecondaryKey $new.SecondaryKey

    $accountRemoved = $createdAccount | Remove-AzSpatialAnchorsAccount -PassThru
    Assert-True{$accountRemoved}

    Assert-ThrowsContains { Get-AzSpatialAnchorsAccount -Id $createdAccount.Id } "NotFound"

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Endpoint pipeline exercise
#>
function Test-ListSpatialAnchorsAccounts
{
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceLocation = "EastUS2"
    $accountName = getAssetName

	$accounts = Get-AzSpatialAnchorsAccount -ResourceGroupName $resourceGroup.ResourceGroupName
	$originalCount = $accounts.Count

    $createdAccount = New-AzSpatialAnchorsAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName -Location $resourceLocation
    Assert-AreEqual $accountName $createdAccount.Name
    Assert-AreEqual $resourceGroup.ResourceGroupName $createdAccount.ResourceGroupName
    Assert-AreEqual $resourceLocation $createdAccount.Location

	$accounts = Get-AzSpatialAnchorsAccount -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $accounts.Count ($originalCount + 1)

	$old = Get-AzSpatialAnchorsAccountKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName
	$new = New-AzSpatialAnchorsAccountKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName -Primary -Force
	Assert-AreNotEqual $old.PrimaryKey $new.PrimaryKey

	$old = $new
	$new = New-AzSpatialAnchorsAccountKey -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName -Secondary -Force
	Assert-AreNotEqual $old.SecondaryKey $new.SecondaryKey

    $accountRemoved = Remove-AzSpatialAnchorsAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $accountName -PassThru
    Assert-True{$accountRemoved}

	$accounts = Get-AzSpatialAnchorsAccount -ResourceGroupName $resourceGroup.ResourceGroupName
    Assert-AreEqual $accounts.Count $originalCount

    Remove-AzureRmResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}
