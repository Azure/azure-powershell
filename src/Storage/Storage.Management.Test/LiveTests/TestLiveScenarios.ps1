Invoke-LiveTestScenario -Name "Creates a Storage account" -Description "Test create storage account" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $name = "alex123987"
    $location = "westus"
    $actual = New-AzStorageAccount  -ResourceGroupName $rgName -Name $name  -Location $location -SkuName Standard_GRS 
    
    Assert-AreEqual $name $actual.Name
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $vaultLocation $actual.Location
    Assert-AreEqual "Standard_GRS" $actual.SkuName
    Assert-AreEqual $false $actual.EnabledForDeployment
    Assert-True { $actual.AllowBlobPublicAccess } "By default AllowBlobPublicAccess should be true"
    Assert-Null $actual.AllowSharedKeyAccess "By default AllowSharedKeyAccess should be null"
    Assert-False { $actual.EnableHttpsTrafficOnly } "By default EnableHttpsTrafficOnly should be false"
}

Invoke-LiveTestScenario -Name "Removes a Storage account" -Description "Test removes a Storage account from Azure." -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $name = "alex123987"
    $location = "westus"

    New-AzStorageAccount -ResourceGroupName $rgname -Name $name -Location $location -SkuName Standard_GRS 
    Remove-AzStorageAccount -ResourceGroupName $rgname -Name $name -Force

    $removedAccount = Get-AzStorageAccount -ResourceGroupName $rgName -Name $name
    Assert-Null $removedAccount

}
