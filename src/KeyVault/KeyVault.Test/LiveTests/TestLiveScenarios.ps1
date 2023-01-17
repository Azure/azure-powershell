Invoke-LiveTestScenario -Name "Create new standard key vault" -Description "Test creating a new standard key vault with all default values" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $vaultName = New-LiveTestResourceName
    $vaultLocation = "westus"

    $actual = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $vaultLocation
    Assert-AreEqual $vaultName $actual.VaultName
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $vaultLocation $actual.Location
    Assert-AreEqual "Standard" $actual.Sku
    Assert-AreEqual $false $actual.EnabledForDeployment
    Assert-True { $actual.EnableSoftDelete } "By default EnableSoftDelete should be true"
    Assert-Null $actual.EnablePurgeProtection "By default EnablePurgeProtection should be null"
    Assert-False { $actual.EnableRbacAuthorization } "By default EnableRbacAuthorization should be false"
    Assert-AreEqual 90 $actual.SoftDeleteRetentionInDays "By default SoftDeleteRetentionInDays should be 90"
}

Invoke-LiveTestScenario -Name "Create new premium key vault" -Description "Test creating a new premium key vault with all default values" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $vaultName = New-LiveTestResourceName
    $vaultLocation = "eastus"

    $actual = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $vaultLocation -Sku premium -EnabledForDeployment
    Assert-AreEqual $vaultName $actual.VaultName
    Assert-AreEqual $rgName $actual.ResourceGroupName
    Assert-AreEqual $vaultLocation $actual.Location
    Assert-AreEqual "Premium" $actual.Sku
    Assert-AreEqual $true $actual.EnabledForDeployment
}

Invoke-LiveTestScenario -Name "Update key vault" -Description "Test updating properties EnableRbacAuthorization and Tag for existing key vault" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $vaultName = New-LiveTestResourceName
    $vaultLocation = "eastus"

    # Update EnableRbacAuthorization
    $vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $vaultLocation

    $vault = $vault | Update-AzKeyVault -EnableRbacAuthorization $false
    Assert-False { $vault.EnableRbacAuthorization } "EnableRbacAuthorization should be false"

    # Update Tags
    $vault = $vault | Update-AzKeyVault -Tag @{ key = "value" }
    Assert-AreEqual 1 $vault.Tags.Count "Tags should contain a key-value pair (key, value)"
    Assert-True { $vault.Tags.Contains("key") } "Tags should contain a key-value pair (key, value)"
    Assert-AreEqual "value" $vault.Tags["key"] "Tags should contain a key-value pair (key, value)"

    # Clean Tags
    $vault = $vault | Update-AzKeyVault -Tag @{}
    Assert-AreEqual 0 $vault.Tags.Count "Tags should be empty"
}

Invoke-LiveTestScenario -Name "Delete key vault" -Description "Test deleting key vault" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $vaultName = New-LiveTestResourceName
    $vaultLocation = "westus"

    New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname -Location $vaultLocation
    Remove-AzKeyVault -VaultName $vaultName -Force

    $deletedVault = Get-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName
    Assert-Null $deletedVault

    # purge deleted vault
    Remove-AzKeyVault -VaultName $vaultName -Location $vaultLocation -InRemovedState -Force
}
