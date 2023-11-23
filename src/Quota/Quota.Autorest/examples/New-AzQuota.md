### Example 1: Create or update the quota limit for the specified resource with the requested value
```powershell
PS C:\> $limit = New-AzQuotaLimitObject -Value 1003
PS C:\> New-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses" -Name "PublicIPAddresses" -Limit $limit

Name              NameLocalizedValue          Unit  ETag
----              ------------------          ----  ----
PublicIPAddresses Public IP Addresses - Basic Count
```

This command create or update the quota limit for the specified resource with the requested value.