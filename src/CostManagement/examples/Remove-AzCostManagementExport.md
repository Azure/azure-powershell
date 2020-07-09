### Example 1: Remove a cost management export by name
```powershell
PS C:\> Remove-AzCostManagementExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name AzureExport-T01

```

This command removes a cost management export by name

### Example 2: Remove a cost management export by object
```powershell
PS C:\> $export = Get-AzCostManagementExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name AzureExport-T02
PS C:\> Remove-AzCostManagementExport -InputObject $export

```

This command removes a cost management export by object

