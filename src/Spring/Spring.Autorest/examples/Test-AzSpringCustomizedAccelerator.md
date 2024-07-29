### Example 1: Check the customized accelerator are valid.
```powershell
Test-AzSpringCustomizedAccelerator -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -Name default -GitRepositoryUrl "https://github.com/lijinpei2008/ghatest" -ApplicationAcceleratorName default -AuthSettingAuthType Accelerator
```

```output
IsValid Message
------- -------
  False Custom domain 'default' is invalid.
```

Check the customized accelerator are valid.