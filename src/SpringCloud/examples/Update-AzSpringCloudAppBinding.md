### Example 1: Operation to update an exiting Binding
```powershell
Update-AzSpringCloudAppBinding -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -AppName gateway -Name redis -Key myKey -BindingParameter @{ "useSsl"= "true" }
```

```output
Name  
----   
redis
```

Operation to update an exiting Binding.

### Example 2: Operation to update an exiting Binding by pipeline
```powershell
Get-AzSpringCloudAppBinding -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -AppName gateway -Name redis | Update-AzSpringCloudAppBinding -Key myKey -BindingParameter @{ "useSsl"= "true" }
```

```output
Name  
----   
redis
```

Operation to update an exiting Binding by pipeline.

