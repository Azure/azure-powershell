### Example 1: Count the protected items of cloud accounts
```powershell
Get-AzCommvaultProtectedItemCount -ResourceId '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-commvault/providers/Commvault.ContentStore/cloudAccounts/cca-contoso', '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-commvault/providers/Commvault.ContentStore/cloudAccounts/cca-fabrikam'
```

Gets the number of protected items across the specified cloud accounts.

### Example 2: Count the protected items by using a JSON request
```powershell
Get-AzCommvaultProtectedItemCount -JsonString '{"resourceIds":["/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-commvault/providers/Commvault.ContentStore/cloudAccounts/cca-contoso"]}'
```

Gets the number of protected items by passing the request body as a JSON string.

