Write-Host "Storage test live scenarios"

Invoke-LiveTestScenario -Name "Storage.NewStorageAccount Test" -Description "Test create storage account" -ScenarioScript `
{
    param ($rgName, $rgLocation)

    Write-Host "Resource group name: $rgName"

    $vaultLocation = "westus"
    $vaultName = New-LiveTestResourceName

    $kv = Get-AzStorageAccount -ResourceGroupName $rgName -Name $vaultName 
    if ($null -eq $kv) {
        New-AzStorageAccount  -ResourceGroupName $rgName -Name $vaultName -Location $vaultLocation
    }
    $got = Get-AzStorageAccount  -ResourceGroupName $rgName -Name $vaultName

    Assert-NotNull $got
    Assert-AreEqual $got.Location $vaultLocation
    Assert-AreEqual $got.ResourceGroupName $rgName
    Assert-AreEqual $got.Name $vaultName

    $got = Get-AzStorageAccount -Name $vaultName

    Assert-NotNull $got
    Assert-AreEqual $got.Location $vaultLocation
    Assert-AreEqual $got.ResourceGroupName $rgName
    Assert-AreEqual $got.Name $vaultName
}

Invoke-LiveTestScenario -Name "Storage.RemoveStorageAccount Test" -Description "Test remove storage account" -ResourceGroupLocation "eastus" -ScenarioScript `
{
    param ([string] $rgName, [string] $rgLocation)

    Write-Host "Resource group name: $rgName"

    $vaultLocation = "westus"
    $vaultName = New-LiveTestResourceName

    New-AzStorageAccount -ResourceGroupName $rgname -Name $vaultName -Location $vaultLocation
    Remove-AzStorageAccount -Name $vaultName -Force

    $deletedVault = Get-AzStorageAccount -ResourceGroupName $rgName -Name $vaultName
    Assert-Null $deletedVault

    # purge deleted vault
    Remove-AzStorageAccount -ResourceGroupName $rgName -Name $vaultName -Location $vaultLocation -InRemovedState -Force

    # Test piping
    New-AzStorageAccount -ResourceGroupName $rgname -Name $vaultName -Location $vaultLocation

    Get-AzStorageAccount -ResourceGroupName $rgname -Name $vaultName | Remove-AzStorageAccount -Force

    $removedAccount = Get-AzStorageAccount -ResourceGroupName $rgName -Name $vaultName
    Assert-Null $removedAccount
}
