### Example 1: Operation to update an exiting Binding
```powershell
Update-AzSpringAppBinding -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -AppName gateway -Name redis -Key myKey -BindingParameter @{ "useSsl"= "true" }
```

```output
Name  
----   
redis
```

Operation to update an exiting Binding.

### Example 2: Operation to update an exiting Binding by pipeline
```powershell
Get-AzSpringAppBinding -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -AppName gateway -Name redis | Update-AzSpringAppBinding -Key myKey -BindingParameter @{ "useSsl"= "true" }
```

```output
Name  
----   
redis
```

Operation to update an exiting Binding by pipeline.

