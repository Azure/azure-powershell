### Example 1: Disable an APM globally.
```powershell
$apmObj = Get-AzSpringApm -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name azps-apm
Disable-AzSpringServiceApmGlobally -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -ResourceId $apmObj.Id -PassThru
```

```output
True
```

Disable an APM globally.