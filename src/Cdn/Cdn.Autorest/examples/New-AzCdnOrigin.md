### Example 1: Create an AzureCDN origin under the AzureCDN endpoint

```powershell
New-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name origin1 -HostName "host1.hello.com" 
```

```output
Name    ResourceGroupName
----    -----------------
origin1 testps-rg-da16jm
```
Create an AzureCDN origin under the AzureCDN endpoint

