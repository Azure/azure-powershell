Invoke-LiveTestScenario -Name "Storage.NewStorageAccount Test" -Description "Test create storage account" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $name = New-LiveTestResourceName
    $vaultLocation = "westus"

    $sa = Get-AzStorageAccount -ResourceGroupName $rgName -Name $name  
    if ($null -eq $sa) {
        $actual = New-AzStorageAccount  -ResourceGroupName $rgName -Name $name  -Location $vaultLocation -SkuName Standard_GRS 
    }

    Assert-AreEqual $name $actual.Name
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $vaultLocation $actual.Location
    Assert-AreEqual "Standard_GRS" $actual.SkuName
    Assert-AreEqual $false $actual.EnabledForDeployment
    Assert-True { $actual.AllowBlobPublicAccess } "By default AllowBlobPublicAccess should be true"
    Assert-Null $actual.AllowSharedKeyAccess "By default AllowSharedKeyAccess should be null"
    Assert-False { $actual.EnableHttpsTrafficOnly } "By default EnableHttpsTrafficOnly should be false"
}

Invoke-LiveTestScenario -Name "Storage.RemoveStorageAccount Test" -Description "Test remove storage account" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $name = New-LiveTestResourceName
    $vaultLocation = "westus"

    New-AzStorageAccount -ResourceGroupName $rgname -Name $name -Location $vaultLocation -SkuName Standard_GRS 
    Remove-AzStorageAccount -ResourceGroupName $rgname -Name $name -Force

    $removedAccount = Get-AzStorageAccount -ResourceGroupName $rgName -Name $name
    Assert-Null $removedAccount

    # purge deleted vault
    Remove-AzStorageAccount -ResourceGroupName $rgName -Name $name -Force
}
