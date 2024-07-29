### Example 1: Check the resource name is valid as well as not in use.
```powershell
Test-AzSpringAppCustomDomainNameAvailability -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02 -AppName tools -Name default
```

```output
IsValid Message
------- -------
  False Custom domain 'default' is invalid.
```

Check the resource name is valid as well as not in use.