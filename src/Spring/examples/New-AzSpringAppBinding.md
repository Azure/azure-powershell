### Example 1: Create a new Binding or update an exiting Binding
```powershell
New-AzSpringAppBinding -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -name redis -Key myKey -ResourceId myResourceId -AppName tools -BindingParameter @{ "useSsl"= "true" }
```

```output
ResourceName Name  ResourceGroupName    ResourceType
------------ ----  -----------------    ------------
redisService redis Spring-gp-junxi Microsoft.Cache
```

Create a new Binding or update an exiting Binding.