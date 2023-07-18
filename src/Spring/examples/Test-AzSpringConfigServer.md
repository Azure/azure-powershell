### Example 1: Check if the config server settings are valid
```powershell
 Test-AzSpringConfigServer -ResourceGroupName Spring-gp-junxi -Name Spring-service
```

```output
IsValid
-------
True
```

Check if the config server settings are valid.

### Example 2: Check if the config server settings are valid by pipeline
```powershell
Get-AzSpringConfigServer -ResourceGroupName Spring-gp-junxi -Name Spring-service | Test-AzSpringConfigServer
```

```output
IsValid
-------
True
```

Check if the config server settings are valid by pipeline.