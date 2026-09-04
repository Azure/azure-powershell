### Example 1: Point an authentication setting at a user-assigned managed identity
```powershell
# Update the authentication setting workload-auth to use a user-assigned identity
$identityId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/azpwsh-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpwsh-uai'
$property = New-AzMonitorHealthModelManagedIdentityAuthenticationSettingPropertiesObject -ManagedIdentityName $identityId -DisplayName 'Checkout workload identity'
Update-AzMonitorHealthModelAuthenticationSetting -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name workload-auth -Property $property
```

Repoints the authentication setting at a user-assigned identity.
The identity must already be attached to the health model.
