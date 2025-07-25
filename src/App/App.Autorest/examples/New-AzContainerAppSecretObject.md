### Example 1: Create an in-memory object for Secret.
```powershell
New-AzContainerAppSecretObject -Name "redis-secret" -Value "redis-password"
```

```output
Identity KeyVaultUrl Name         Value
-------- ----------- ----         -----
                     redis-secret redis-password
```

Create an in-memory object for Secret.