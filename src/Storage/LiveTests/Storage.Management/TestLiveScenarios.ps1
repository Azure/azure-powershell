Invoke-LiveTestScenario -Name "Creates a Storage account" -Description "Test create storage account" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    # $name = "alex12391d87"
    $name = New-LiveTestResourceName
    $location = "westus"
    $actual = New-AzStorageAccount  -ResourceGroupName $rgName -Name $name  -Location $location -SkuName Standard_GRS 
    
    Assert-AreEqual $name $actual.StorageAccountName
    # Assert-AreEqual $rgName $actual.ResourceGroupName
    # Assert-AreEqual $vaultLocation $actual.PrimaryLocation
    # Assert-AreEqual "Standard_GRS" $actual.SkuName
    # Assert-AreEqual $false $actual.EnabledForDeployment
    # Assert-True { $actual.AllowBlobPublicAccess } "By default AllowBlobPublicAccess should be true"
    # Assert-Null $actual.AllowSharedKeyAccess "By default AllowSharedKeyAccess should be null"
    # Assert-False { $actual.EnableHttpsTrafficOnly } "By default EnableHttpsTrafficOnly should be false"
}

Invoke-LiveTestScenario -Name "Removes a Storage account" -Description "Test removes a Storage account from Azure." -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    # $name = "alex12391d87"
    $name = New-LiveTestResourceName
    $location = "westus"

    New-AzStorageAccount -ResourceGroupName $rgname -Name $name -Location $location -SkuName Standard_GRS 
    Remove-AzStorageAccount -ResourceGroupName $rgname -Name $name -Force

    $removedAccount = Get-AzStorageAccount -ResourceGroupName $rgName -Name $name -ErrorAction SilentlyContinue
    Assert-Null $removedAccount

}

& "$PSScriptRoot\QueueTests.ps1"
& "$PSScriptRoot\BlobTests.ps1"
& "$PSScriptRoot\TableTests.ps1"
& "$PSScriptRoot\FileTests.ps1"