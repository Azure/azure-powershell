### Example 1: Update quota for each VM family in workspace
```powershell
Update-AzMLServiceQuota -Location eastus -Value @{'key1'='value1'}
```

```output
```

Update quota for each VM family in workspace

### Example 2: Update quota for each VM family in workspace by pipeline
```powershell
Get-AzMLServiceQuota -Location eastus | Update-AzMLServiceQuota-Value @{'key1'='value1'}
```

```output
```

Update quota for each VM family in workspace by pipeline

