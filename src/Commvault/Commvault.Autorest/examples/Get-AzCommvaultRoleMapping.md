### Example 1: Get the role mapping of a cloud account
```powershell
Get-AzCommvaultRoleMapping -ResourceGroupName rg-commvault -CloudAccountName cca-contoso
```

Gets the role mapping of the cloud account.
Each cloud account has a single role mapping that maps Commvault roles to Microsoft Entra users and groups.

