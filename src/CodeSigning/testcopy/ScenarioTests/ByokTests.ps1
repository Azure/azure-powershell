function Test-Byok() {
    # BYOK only works on Canary regions (with suffix “euap”).
    $resourceGroupLocation = Get-Location "Microsoft.Resources" "resourceGroups" "East US 2 EUAP"
    $vaultLocation = Get-Location "Microsoft.KeyVault" "vaults" "East US 2 EUAP"
    $resourceGroupName = (GetAssetName)
    $vaultName = (GetAssetName)
    $keyName = (GetAssetName)
    $fs = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.DataStore

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation
        $vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroupName -Location $vaultLocation -Sku "Premium"

        # set up access policy

        # KEK creation
        $key = $vault | Add-AzKeyVaultKey -Name $keyName -Destination HSM -Size 2048 -KeyOps "import"
        Assert-AreEqual "RSA-HSM" $key.Key.Kty "key type != 'RSA-HSM'"
        Assert-AreEqual 1 $key.Key.KeyOps.Count "has >1 key ops"
        Assert-AreEqual "import" $key.Key.KeyOps[0] "key ops != 'import'"

        # KEK creation (negative)
        Assert-Throws { $vault | Add-AzKeyVaultKey -Name (GetAssetName) -Destination HSM -Size 2048 -KeyOps "import", "sign" } "'import' is exclusive to other key ops"
        Assert-Throws { $vault | Add-AzKeyVaultKey -Name (GetAssetName) -Destination Software -Size 2048 -KeyOps "import" } "KEK, identified by key ops == 'import', must have key type = 'RSA-HSM'"

        # KEK download
        $path = "D:\public.pem"
        Assert-False { $fs.FileExists($path) } "$path should not exist before downloading"
        Get-AzKeyVaultKey -VaultName $vaultName -KeyName $keyName -OutFile $path
        Assert-True { $fs.FileExists($path) } "$path should exist after downloading"
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}