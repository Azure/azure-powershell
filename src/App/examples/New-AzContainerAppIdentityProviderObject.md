### Example 1: Create an IdentityProviders object for AuthConfig.
```powershell
New-AzContainerAppIdentityProviderObject -RegistrationAppId xxxxxx@xxx.com -RegistrationAppSecretSettingName redis-secret
```

```output
...                              : ...
RegistrationAppId                : xxxxxx@xxx.com
RegistrationAppSecretSettingName : redis-secret
...                              : ...
```

Create an IdentityProviders object for AuthConfig.