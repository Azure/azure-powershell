### Example 1: Build a managed identity authentication setting
```powershell
# Build an authentication setting property object for a managed identity
New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject -ManagedIdentityName SystemAssigned -DisplayName 'Default managed identity'
```

Creates the property object to pass to New-AzMonitorHealthModelAuthenticationSetting.
Use SystemAssigned, or the resource ID of a user-assigned identity.
