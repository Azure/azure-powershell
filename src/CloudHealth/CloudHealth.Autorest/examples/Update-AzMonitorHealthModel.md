### Example 1: Switch a health model to a user-assigned managed identity
```powershell
# Replace the system-assigned identity on azpwsh-healthmodel1 with a user-assigned one
$identityId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourcegroups/azpwsh-test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpwsh-uai'
Update-AzMonitorHealthModel -Name azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EnableSystemAssignedIdentity $false -UserAssignedIdentity $identityId
```

Turns off the system-assigned identity and attaches a user-assigned one.
Pass only -UserAssignedIdentity to keep both.

### Example 2: Update the tags on a health model
```powershell
# Replace the tags on the health model azpwsh-healthmodel1
Update-AzMonitorHealthModel -Name azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Tag @{ environment = 'production' }
```

Replaces the tags on an existing health model.
