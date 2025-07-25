BeforeAll {
    . "$PSScriptRoot\..\Scripts\Common.ps1"  # Common setup script

    # Load the Az.KeyVault module from the debug artifacts
    $psd1Path = Join-Path $PSScriptRoot "../../../../artifacts/Debug/" -Resolve
    $keyVaultPsd1 = Join-Path $psd1Path "./Az.KeyVault/Az.KeyVault.psd1" -Resolve
    Import-Module $keyVaultPsd1 -Force

    # Define key variables
    $resourceGroupName = "yash-rg$(Get-Random)"  # Use existing resource group
    $location = "eastus"
    $vaultName = "yashkv$(Get-Random)"  # Generate unique Key Vault name
    $secretName = "TestSecret"
    $secretValue = ConvertTo-SecureString "InitialSecretValue" -AsPlainText -Force

    # Set up resource group
    New-AzResourceGroup -Name $resourceGroupName -Location $location

    # Create a Key Vault in the existing resource group
    New-AzKeyVault -ResourceGroupName $resourceGroupName -VaultName $vaultName -Location $location

    # Create a new secret in the Key Vault
    Set-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -SecretValue $secretValue
}


Describe 'Azure KeyVault Secret URI Live Tests' {

    It 'should retrieve the secret using the Secret URI with Get-AzKeyVaultSecret' {
        # Construct the secret URI
        $secretUri = "https://$vaultName.vault.azure.net/secrets/$secretName"

        # Retrieve the secret using its URI
        $retrievedSecret = Get-AzKeyVaultSecret -Id $secretUri -AsPlainText

        # Validate that the secret is retrieved successfully
        $retrievedSecret | Should -Be "InitialSecretValue"
    }

    It 'should update the secret value using Set-AzKeyVaultSecret' {
        # Update the secret value
        $newSecretValue = ConvertTo-SecureString "UpdatedSecretValue" -AsPlainText -Force
        Set-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -SecretValue $newSecretValue

        # Retrieve the updated secret
        $retrievedSecret = Get-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -AsPlainText

        # Validate the secret has been updated
        $retrievedSecret | Should -Be "UpdatedSecretValue"
    }

    It 'should remove the secret using Remove-AzKeyVaultSecret' {
        # Remove the secret
        Remove-AzKeyVaultSecret -VaultName $vaultName -Name $secretName -Force

        # Ensure the secret is deleted
        Get-AzKeyVaultSecret -VaultName $vaultName -Name $secretName | Should -BeNullOrEmpty
    }
}

AfterAll {
    # Clean up Key Vault & Resource Group)
    Remove-AzKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroupName -Force
    Remove-AzResourceGroup -Name $resourceGroupName -Force
}