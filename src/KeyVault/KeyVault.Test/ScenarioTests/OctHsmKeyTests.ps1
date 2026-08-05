<#
.SYNOPSIS
Scenario tests for oct-HSM (AES, HSM-backed) keys on a Premium Azure Key Vault.

oct-HSM keys require:
 - Vault SKU = 'Premium'
 - -KeyType oct
 - -Destination HSM
 - -Size in { 128, 192, 256 }

The service rewrites the key type to 'oct-HSM' on the wire.

Note: vaults are created with -DisableRbacAuthorization because the test
identity is a guest in the test tenant, so MS Graph UPN lookups fail. With
access-policy mode, New-AzKeyVault auto-adds a full-permission policy for the
caller, which is what these tests rely on for the data-plane calls.
#>
function Test-CreateOctHsmKey {
	$resourceGroupLocation = Get-Location "Microsoft.Resources" "resourceGroups" "East US 2 EUAP"
	$vaultLocation = Get-Location "Microsoft.KeyVault" "vaults" "East US 2 EUAP"
	$resourceGroupName = (GetAssetName)
	$vaultName = (GetAssetName)
	$keyName = (GetAssetName)

	try {
		New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation
		$vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroupName -Location $vaultLocation -Sku "Premium" -DisableRbacAuthorization

		# Create an oct-HSM key with the default 256-bit size
		$key = $vault | Add-AzKeyVaultKey -Name $keyName -KeyType oct -Destination HSM -Size 256
		Assert-NotNull $key "Add-AzKeyVaultKey returned null"
		Assert-AreEqual "oct-HSM" $key.Key.Kty "key type != 'oct-HSM'"
		Assert-AreEqual $keyName $key.Name "key name mismatch"

		# Get-AzKeyVaultKey must round-trip the same kty
		$got = Get-AzKeyVaultKey -VaultName $vaultName -Name $keyName
		Assert-NotNull $got "Get-AzKeyVaultKey returned null"
		Assert-AreEqual "oct-HSM" $got.Key.Kty "round-tripped key type != 'oct-HSM'"
	}
	finally {
		Remove-AzResourceGroup -Name $resourceGroupName -Force
	}
}

function Test-CreateOctHsmKeyAllSizes {
	$resourceGroupLocation = Get-Location "Microsoft.Resources" "resourceGroups" "East US 2 EUAP"
	$vaultLocation = Get-Location "Microsoft.KeyVault" "vaults" "East US 2 EUAP"
	$resourceGroupName = (GetAssetName)
	$vaultName = (GetAssetName)

	try {
		New-AzResourceGroup -Name $resourceGroupName -Location $resourceGroupLocation
		$vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroupName -Location $vaultLocation -Sku "Premium" -DisableRbacAuthorization

		foreach ($size in 128, 192, 256) {
			$keyName = (GetAssetName)
			$key = $vault | Add-AzKeyVaultKey -Name $keyName -KeyType oct -Destination HSM -Size $size
			Assert-AreEqual "oct-HSM" $key.Key.Kty "size=${size}: key type != 'oct-HSM'"
		}
	}
	finally {
		Remove-AzResourceGroup -Name $resourceGroupName -Force
	}
}
