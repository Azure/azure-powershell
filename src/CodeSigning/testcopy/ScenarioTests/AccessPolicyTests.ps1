function Test-SetAllAccessPolicies()
{
    $rg = Get-ResourceGroupName
    $vaultName = GetAssetName
    $rgLocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $vaultLocation = Get-Location "Microsoft.KeyVault" "vault" "West US"
    $objectId = "d7e17135-d5a7-4b8b-89e5-252aa15b7e01"
    New-AzResourceGroup -Name $rg -Location $rgLocation

    try {
        New-AzKeyVault -ResourceGroupName $rg -VaultName $vaultName -Location $vaultLocation
        Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ObjectId $objectId -PermissionsToCertificates all -PermissionsToKeys all -PermissionsToSecrets all -PermissionsToStorage all -BypassObjectIdValidation
        $vault = Get-AzKeyVault -ResourceGroupName $rg -VaultName $vaultName
        $accessPolicy = $vault.AccessPolicies | ? {$_.ObjectId -eq $objectId}
        Assert-NotNull $accessPolicy
        Assert-AreEqual "all" $accessPolicy.PermissionsToCertificatesStr
        Assert-AreEqual "all" $accessPolicy.PermissionsToKeysStr
        Assert-AreEqual "all" $accessPolicy.PermissionsToSecretsStr
        Assert-AreEqual "all" $accessPolicy.PermissionsToStorageStr
    }
    finally {
        Remove-AzResourceGroup -Name $rg -Force
    }
}