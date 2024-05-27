### Example 1: Get remote debugging config.
```powershell
Get-AzSpringAppDeploymentRemoteDebuggingConfig -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02 -AppName tools -DeploymentName green
```

```output
Enabled Port
------- ----
  False 5005
```

Get remote debugging config.