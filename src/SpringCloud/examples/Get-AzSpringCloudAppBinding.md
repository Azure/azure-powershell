### Example 1: Get all Binding under the spring app
```powershell
 Get-AzSpringCloudAppBinding -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -AppName gateway
```

```output
Name  
----  
redis
```

Get all Binding under the spring app.

### Example 2: Get a Binding and its properties
```powershell
Get-AzSpringCloudAppBinding -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -AppName gateway -Name redis
```

```output
Name  
----  
redis
```

Get a Binding and its properties.

### Example 3: Get a Binding and its properties by pipeline
```powershell
New-AzSpringCloudAppBinding -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -name redis -Key myKey -ResourceId myResourceId -AppName tools -BindingParameter @{ "useSsl"= "true" } | Get-AzSpringCloudAppBinding
```

```output
Name  
----  
redis
```

Get a Binding and its properties by pipeline.