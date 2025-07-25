### Example 1: Delete a KPack builder
```powershell
Remove-AzSpringCloudBuildServiceBuilder -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-01 -Name mybuilder
```

Delete a KPack builder.

### Example 2: Delete a KPack builder by pipeline
```powershell
Get-AzSpringCloudBuildServiceBuilder -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-01 -Name mybuilder | Remove-AzSpringCloudBuildServiceBuilder
```

Delete a KPack builder by pipeline.