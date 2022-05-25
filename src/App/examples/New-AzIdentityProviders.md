### Example 1: Create an IdentityProviders object for AuthConfig.
```powershell
New-AzIdentityProviders -RegistrationAppId xxxxxx@xxx.com -RegistrationAppSecretSettingName facebook-secret
```

```output
...                              : ...
RegistrationAppId                : xxxxxx@xxx.com
RegistrationAppSecretSettingName : facebook-secret
...                              : ...
```

Create an IdentityProviders object for AuthConfig.