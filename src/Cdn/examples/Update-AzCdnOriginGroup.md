### Example 1: Update an AzureCDN origin group under the AzureCDN endpoint
```powershell
$updateHealthProbeParameters = New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 60 -ProbePath "/new-check-health.aspx" -ProbeProtocol "Http" -ProbeRequestType "HEAD"
Update-AzCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -Name org001 -HealthProbeSetting $updateHealthProbeParameters
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```

Update an AzureCDN origin group under the AzureCDN endpoint



