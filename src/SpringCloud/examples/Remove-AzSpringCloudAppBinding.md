### Example 1: Operation to delete a Binding
```powershell
Remove-AzSpringCloudAppBinding -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -AppName gateway -Name redis
```

Operation to delete a Binding.

### Example 1: Operation to delete a Binding by pipeline
```powershell
Get-AzSpringCloudAppBinding -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -AppName gateway -Name redis | Remove-AzSpringCloudAppBinding
```

Operation to delete a Binding by pipeline.