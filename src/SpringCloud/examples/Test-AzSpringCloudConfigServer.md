### Example 1: Check if the config server settings are valid
```powershell
 Test-AzSpringCloudConfigServer -ResourceGroupName SpringCloud-gp-junxi -Name springcloud-service
```

```output
IsValid
-------
True
```

Check if the config server settings are valid.

### Example 2: Check if the config server settings are valid by pipeline
```powershell
Get-AzSpringCloudConfigServer -ResourceGroupName SpringCloud-gp-junxi -Name springcloud-service | Test-AzSpringCloudConfigServer
```

```output
IsValid
-------
True
```

Check if the config server settings are valid by pipeline.

