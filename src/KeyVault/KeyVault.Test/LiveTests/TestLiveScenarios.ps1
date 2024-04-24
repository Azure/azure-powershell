Invoke-LiveTestScenario -Name "Create new standard key vault" -Description "Test creating a new standard key vault with all default values" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $vaultName = New-LiveTestResourceName
    $vaultLocation = "westus"

    New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $vaultLocation
    $actual = Get-AzKeyVault -ResourceGroupName $rgName -VaultName $vaultName
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

    New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $vaultLocation -Sku premium -EnabledForDeployment
    $actual = Get-AzKeyVault -ResourceGroupName $rgName -VaultName $vaultName
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

    $vault = $vault | Update-AzKeyVault -DisableRbacAuthorization $true
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

Invoke-LiveTestScenario -Name "Create key vault secret" -Description "Test creating a key vault secret" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $vaultName = New-LiveTestResourceName
    $vaultLocation = "eastus"
    $secretName = New-LiveTestResourceName

    New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $vaultLocation
    $sp = Get-AzADServicePrincipal -ApplicationId (Get-AzContext).Account.Id
    $objectId = $sp.Id
    Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ObjectId $objectId -PermissionsToSecrets get, set, list

    $secretValue = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
    Set-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -SecretValue $secretValue

    $actual = Get-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -ErrorAction SilentlyContinue
    Assert-NotNull $actual
    Assert-AreEqual $vaultName $actual.VaultName
    Assert-AreEqual $secretName $actual.Name
}

Invoke-LiveTestScenario -Name "Create key vault secret with multi-versions" -Description "Test creating a key vault secret with multiple versions" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $vaultName = New-LiveTestResourceName
    $vaultLocation = "westus"
    $secretName = New-LiveTestResourceName

    New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $vaultLocation
    $sp = Get-AzADServicePrincipal -ApplicationId (Get-AzContext).Account.Id
    $objectId = $sp.Id
    Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ObjectId $objectId -PermissionsToSecrets get, set, list

    $secretValue = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
    Set-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -SecretValue $secretValue
    Set-AzKeyVaultSecret -VaultName $vaultName -name $secretName -SecretValue $secretValue

    $actual = Get-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -IncludeVersions -ErrorAction SilentlyContinue
    Assert-NotNull $actual
    Assert-AreEqual 2 $actual.Count
}

Invoke-LiveTestScenario -Name "Update key vault secret attributes" -Description "Test updating attributes of a key vault secret" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $vaultName = New-LiveTestResourceName
    $vaultLocation = "westus"
    $secretName = New-LiveTestResourceName

    New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $vaultLocation
    $sp = Get-AzADServicePrincipal -ApplicationId (Get-AzContext).Account.Id
    $objectId = $sp.Id
    Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ObjectId $objectId -PermissionsToSecrets get, set, list

    $secretValue = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
    Set-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -SecretValue $secretValue

    $exp = (Get-Date).AddYears(1).ToUniversalTime()
    $nbf = (Get-Date).ToUniversalTime()
    $ctp= "text"
    $tags = @{ "Severity" = "low" }
    Update-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -NotBefore $nbf -Expires $exp -ContentType $ctp -Tag $tags -Enable $true

    $actual = Get-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -ErrorAction SilentlyContinue
    Assert-NotNull $actual
    Assert-AreEqual $true $actual.Enabled
    Assert-AreEqual $ctp $actual.ContentType
}

Invoke-LiveTestScenario -Name "Remove key vault secret" -Description "Test removing a key vault secret" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $vaultName = New-LiveTestResourceName
    $vaultLocation = "eastus"
    $secretName = New-LiveTestResourceName

    New-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgName -Location $vaultLocation
    $sp = Get-AzADServicePrincipal -ApplicationId (Get-AzContext).Account.Id
    $objectId = $sp.Id
    Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ObjectId $objectId -PermissionsToSecrets get, set, list, delete

    $secretValue = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
    Set-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -SecretValue $secretValue

    Remove-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -Force

    $actual = Get-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -ErrorAction SilentlyContinue
    Assert-Null $actual
}

Invoke-LiveTestScenario -Name "Backup and restore key vault secret" -Description "Test backing up and restoring a key vault secret" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $vaultName1 = New-LiveTestResourceName
    $vaultName2 = New-LiveTestResourceName
    $vaultLocation = "eastus"
    $secretName = New-LiveTestResourceName

    New-AzKeyVault -VaultName $vaultName1 -ResourceGroupName $rgName -Location $vaultLocation
    New-AzKeyVault -VaultName $vaultName2 -ResourceGroupName $rgName -Location $vaultLocation
    $sp = Get-AzADServicePrincipal -ApplicationId (Get-AzContext).Account.Id
    $objectId = $sp.Id
    Set-AzKeyVaultAccessPolicy -VaultName $vaultName1 -ObjectId $objectId -PermissionsToSecrets get, set, list, backup
    Set-AzKeyVaultAccessPolicy -VaultName $vaultName2 -ObjectId $objectId -PermissionsToSecrets get, set, list, restore

    $secretValue = ConvertTo-SecureString -String 'Password' -AsPlainText -Force
    Set-AzKeyVaultSecret -VaultName $vaultName1 -Name $secretName -SecretValue $secretValue

    Backup-AzKeyVaultSecret -VaultName $vaultName1 -Name $secretName -OutputFile "SecretBackup.blob" -Force

    Restore-AzKeyVaultSecret -VaultName $vaultName2 -InputFile "SecretBackup.blob"

    $actual = Get-AzKeyVaultSecret -VaultName $vaultName2 -Name $secretName -ErrorAction SilentlyContinue
    Assert-NotNull $actual
    Assert-AreEqual $vaultName2 $actual.VaultName
    Assert-AreEqual $secretName $actual.Name
}

& "$PSScriptRoot\KeyVaultDataPlaneLiveTests\TestNetworkRuleSet.ps1"
& "$PSScriptRoot\ManagedHsmDataPlaneLiveTests\TestSetting.ps1"