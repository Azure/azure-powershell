### Example 1: Create or update the quota limit for the specified resource with the requested value
```powershell
<<<<<<< HEAD
$limit = New-AzQuotaLimitObject -Value 1003
New-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses" -Name "PublicIPAddresses" -Limit $limit
```

```output
=======
PS C:\> $limit = New-AzQuotaLimitObject -Value 1003
PS C:\> New-AzQuota -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/providers/Microsoft.Network/locations/eastus2" -ResourceName "PublicIPAddresses" -Name "PublicIPAddresses" -Limit $limit

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name              NameLocalizedValue          Unit  ETag
----              ------------------          ----  ----
PublicIPAddresses Public IP Addresses - Basic Count
```

This command create or update the quota limit for the specified resource with the requested value.