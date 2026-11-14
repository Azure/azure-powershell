### Example 1: Link a SaaS resource to a cloud account
```powershell
Connect-AzCommvaultCloudAccountSaaS -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -SaaSResourceId '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-commvault/providers/Microsoft.SaaS/resources/commvault-saas'
```

Links the SaaS resource to the cloud account.

### Example 2: Link a SaaS resource to a cloud account by using a JSON request
```powershell
Connect-AzCommvaultCloudAccountSaaS -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -JsonString '{"saaSResourceId":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-commvault/providers/Microsoft.SaaS/resources/commvault-saas"}'
```

Links the SaaS resource to the cloud account by passing the request body as a JSON string.

