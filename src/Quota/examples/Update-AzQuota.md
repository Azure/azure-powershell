### Example 1: Update the quota limit for a specific resource to the specified value
```powershell
PS C:\> $limit = New-AzQuotaLimitObject -Value 1001
PS C:\> Update-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses" -Name "PublicIPAddresses" -Limit $limit

Name              NameLocalizedValue          UsageUsagesType UsageValue ETag
----              ------------------          --------------- ---------- ----
PublicIPAddresses Public IP Addresses - Basic                 0
```

This command update the quota limit for a specific resource to the specified value.

### Example 2: Update the quota limit for a specific resource to the specified value by pipeline
```powershell
PS C:\> 
PS C:\> $limit = New-AzQuotaLimitObject -Value 1007
PS C:\> Get-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses" | Update-AzQuota -Name "PublicIPAddresses" -Limit $limit

Name              NameLocalizedValue          UsageUsagesType UsageValue ETag
----              ------------------          --------------- ---------- ----
PublicIPAddresses Public IP Addresses - Basic                 0
```

This command update the quota limit for a specific resource to the specified value by pipeline.

