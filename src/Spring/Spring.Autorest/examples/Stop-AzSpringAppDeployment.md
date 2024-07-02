### Example 1: Stop the deployment.
```powershell
Stop-AzSpringAppDeployment -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-02 -AppName tools -Name green -PassThru
```

```output
True
```

Stop the deployment.