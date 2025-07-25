### Example 1: Create an AzureCDN origin group under the AzureCDN endpoint
```powershell
$healthProbeParameters = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 120 -ProbePath "/check-health.aspx" -ProbeProtocol "Http" -ProbeRequestType "HEAD"
$origin = Get-AzCdnOrigin -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name origin1
New-AzCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name org001 -HealthProbeSetting $healthProbeParameters -Origin @(@{ Id = $origin.Id })
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```

Create an AzureCDN origin group under the AzureCDN endpoint

