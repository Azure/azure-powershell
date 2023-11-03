### Example 1: List AzureCDN origins under the AzureCDN endpoint
```powershell
Get-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001
```

```output
Name    ResourceGroupName
----    -----------------
origin1 testps-rg-da16jm
origin2 testps-rg-da16jm
```

List AzureCDN origins under the AzureCDN endpoint

### Example 2: Get an AzureCDN origin under the AzureCDN endpoint
```powershell
Get-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name origin1
```

```output
Name    ResourceGroupName
----    -----------------
origin1 testps-rg-da16jm
```

Get an AzureCDN origin under the AzureCDN endpoint


### Example 3: Get an AzureCDN origin under the AzureCDN endpoint via identity
```powershell
New-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest010 -Name origin1 -HostName "host1.hello.com" | Get-AzCdnOrigin
```

```output
Name    Location ResourceGroupName
----    -------- -----------------
origin1          testps-rg-da16jm
```

Get an AzureCDN origin under the AzureCDN endpoint via identity

