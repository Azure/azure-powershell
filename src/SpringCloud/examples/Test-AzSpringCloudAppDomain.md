### Example 1: Check the resource name is valid as well as not in use
```powershell
Test-AzSpringCloudAppDomain -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service-01 -Name springcloud-service-01.azuremicroservices.io -AppName tools
```

```output
IsValid Message
------- -------
True
```

Check the resource name is valid as well as not in use.

### Example 2: Check the resource name is valid as well as not in use by pipeline
```powershell
Get-AzSpringCloudAppDomain -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service-01 -Name springcloud-service-01.azuremicroservices.io -AppName tools | Test-AzSpringCloudAppDomain
```

```output
IsValid Message
------- -------
True
```

Check the resource name is valid as well as not in use by pipeline.

