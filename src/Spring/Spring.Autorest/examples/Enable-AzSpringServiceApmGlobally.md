### Example 1: Enable predefined accelerator.
```powershell
$apmObj = Get-AzSpringApm -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name azps-apm
Enable-AzSpringServiceApmGlobally -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -ResourceId $apmObj.Id -PassThru
```

```output
True
```

Enable predefined accelerator.