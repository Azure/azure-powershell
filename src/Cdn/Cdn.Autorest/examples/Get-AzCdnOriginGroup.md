### Example 1: List AzureCDN origin groups under the AzureCDN endpoint
```powershell
Get-AzCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
org002 testps-rg-da16jm
```

List AzureCDN origin groups under the AzureCDN endpoint

### Example 2: Get an AzureCDN origin group under the AzureCDN endpoint
```powershell
Get-AzCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name org001
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```

Get an AzureCDN origin group under the AzureCDN endpoint


### Example 3: Get an AzureCDN origin group under the AzureCDN endpoint via identity
```powershell
$healthProbeParameters = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 120 -ProbePath "/check-health.aspx" -ProbeProtocol "Http" -ProbeRequestType "HEAD"
$origin = Get-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest010 -Name origin1
New-AzCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest010 -Name org001 -HealthProbeSetting $healthProbeParameters -Origin @(@{ Id = $origin.Id }) | Get-AzCdnOriginGroup
```

```output
Name   Location ResourceGroupName
----   -------- -----------------
org001          testps-rg-da16jm
```

Get an AzureCDN origin group under the AzureCDN endpoint via identity