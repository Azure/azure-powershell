### Example 1: Create an in-memory object for AzureFrontDoor origin group `HealthProbeSetting` object
```powershell
New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" -ProbeProtocol "Https" -ProbeRequestType "GET"
```

```output
ProbeIntervalInSecond ProbePath ProbeProtocol ProbeRequestType
--------------------- --------- ------------- ----------------
1                     /         Https         GET
```

Create an in-memory object for AzureFrontDoor origin group `HealthProbeSetting` object