### Example 1: Create Secret Auth info with raw value
```powershell
New-AzServiceLinkerSecretAuthInfoObject -Name user -SecretValue password
```

```output
AuthType Name
-------- ----
secret   user
```

Create Secret Auth info with raw value

### Example 2: Create Secret Auth info with keyvault secret uri
```powershell
New-AzServiceLinkerSecretAuthInfoObject -Name user -SecretKeyVaultUri "https://servicelinker-kv-ref.vault.azure.net/secrets/test-secret/cc5d8095a54f4755b342f4e7884b5c84" 
```

```output
AuthType Name
-------- ----
secret   user
```

Create Secret Auth info with keyvault secret uri

### Example 3: Create Secret Auth info with keyvault secret reference(It's for AKS only and `-SecretStoreVaultId` must be set at the same time when creating linker)
```powershell
New-AzServiceLinkerSecretAuthInfoObject -Name user -SecretNameInKeyVault test-secret
```

```output
AuthType Name
-------- ----
secret   user
```

Create Secret Auth info with keyvault secret reference
It's for AKS only and `-SecretStoreVaultId` must be set at the same time when creating linker

