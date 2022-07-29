### Example 1: Create an AzureCDN Endpoint under the AzureCDN profile
```powershell
$origin = @{
    Name = "origin1"
    HostName = "host1.hello.com"
};
New-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001 -Location westus -Origin $origin             
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
WestUs   endptest001 testps-rg-da16jm
```

Create an AzureCDN Endpoint under the AzureCDN profile

