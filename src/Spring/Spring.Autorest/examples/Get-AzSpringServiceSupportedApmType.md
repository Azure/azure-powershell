### Example 1: List supported APM types for a Service.
```powershell
Get-AzSpringServiceSupportedApmType -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Name
----
AppDynamics
ApplicationInsights
Dynatrace
ElasticAPM
NewRelic
```

List supported APM types for a Service.