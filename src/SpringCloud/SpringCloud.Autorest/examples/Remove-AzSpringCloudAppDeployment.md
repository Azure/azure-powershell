### Example 1: Remove Spring Cloud Deployment by name
```powershell
Remove-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default
```

Remove Spring Cloud Deployment by name.

### Example 2: Remove Spring Cloud Deployment by pipeline
```powershell
Get-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default | Remove-AzSpringCloudAppDeployment
```

Remove Spring Cloud Deployment by pipeline.