# 1. new resource group

# 2. new databricks workspace (prepare encryption)
$dbr = New-AzDatabricksWorkspace -Name "yeming" -ResourceGroupName "yeming" -PrepareEncryption -Location "East US 2 EUAP" -Sku premium

# verify $dbr.PrepareEncryptionValue is $True
# verify $dbr has these properties (not null):
# - StorageAccountIdentityPrincipalId : f155fe1f-ede9-40f6-a126-e41cc96108e2
# - StorageAccountIdentityTenantId    : 72f988bf-86f1-41af-91ab-2d7cd011db47
# - StorageAccountIdentityType        : SystemAssigned
# - StorageAccountNameType            : String
# - StorageAccountNameValue           : dbstoragecowxy5isieogm

# 3. new key vault (soft delete enabled, purge protection enabled)
#    add an access policy, use the above "StorageAccountNameValue" as service principal, select all key permissions

# 4. generate a new key in key vault

# 5. update workspace (enable encryption)
$dbr = $dbr | Update-AzDatabricksWorkspace -EncryptionKeySource Microsoft.KeyVault -EncryptionKeyVaultUri https://yemingdbr.vault.azure.net/ -EncryptionKeyName rsa -EncryptionKeyVersion a78ebf48fadd477b9820a53b4c67e38a
# Update-AzDatabricksWorkspace -InputObject $dbr -EncryptionKeySource Microsoft.KeyVault -EncryptionKeyVaultUri https://dbr-kv-t02.vault.azure.net/ -EncryptionKeyName rsa -EncryptionKeyVersion f71e150be6ba4592b2369a70fc9818df

# verify these properties of $dbr equal to the input
# - ValueKeyName                      :
# - ValueKeySource                    : Microsoft.Keyvault
# - ValueKeyVaultUri                  :
# - ValueKeyVersion                   :

# 6. update workspace (disable encryption)
$dbr = Update-AzDatabricksWorkspace -ResourceGroupName yeming -Name yeming -EncryptionKeySource Default # to test "resourcegroupname / name" parameter set

# verify $dbr.ValueKeySource equals Default, and others (name, uri, version) are empty