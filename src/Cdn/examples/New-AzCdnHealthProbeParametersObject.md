### Example 1: Create an in-memory object for AzureCDN HealthProbeParameters
```powershell
New-AzCdnHealthProbeParametersObject -ProbeIntervalInSecond 120 -ProbePath "/check-health.aspx" -ProbeProtocol "Http" -ProbeRequestType "HEAD"
```

```output
ProbeIntervalInSecond ProbePath          ProbeProtocol ProbeRequestType
--------------------- ---------          ------------- ----------------
120                   /check-health.aspx Http          HEAD
```

Create an in-memory object for AzureCDN HealthProbeParameters

