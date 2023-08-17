### Example 1: Create a new Binding or update an exiting Binding
```powershell
New-AzSpringCloudAppBinding -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -name redis -Key myKey -ResourceId myResourceId -AppName tools -BindingParameter @{ "useSsl"= "true" }
```

```output
ResourceName Name  ResourceGroupName    ResourceType
------------ ----  -----------------    ------------
redisService redis SpringCloud-gp-junxi Microsoft.Cache
```

Create a new Binding or update an exiting Binding.

