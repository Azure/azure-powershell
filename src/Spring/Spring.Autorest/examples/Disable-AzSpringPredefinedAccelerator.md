### Example 1: Disable predefined accelerator.
```powershell
Disable-AzSpringPredefinedAccelerator -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -ApplicationAcceleratorName default -Name asa-node-express -PassThru
```

```output
True
```

Disable predefined accelerator.