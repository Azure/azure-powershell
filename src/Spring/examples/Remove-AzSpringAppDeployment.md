### Example 1: Remove Spring Cloud Deployment by name
```powershell
Remove-AzSpringAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default
```

```output
```

Remove Spring Cloud Deployment by name.

### Example 2: Remove Spring Cloud Deployment by pipeline
```powershell
Get-AzSpringAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default | Remove-AzSpringAppDeployment
```

```output
```

Remove Spring Cloud Deployment by pipeline.