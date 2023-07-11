### Example 1: Delete a KPack builder
```powershell
Remove-AzSpringBuildServiceBuilder -ResourceGroupName Spring-gp-junxi -ServiceName Spring-01 -Name mybuilder
```

```output
```

Delete a KPack builder.

### Example 2: Delete a KPack builder by pipeline
```powershell
Get-AzSpringBuildServiceBuilder -ResourceGroupName Spring-gp-junxi -ServiceName Spring-01 -Name mybuilder | Remove-AzSpringBuildServiceBuilder
```

```output
```

Delete a KPack builder by pipeline.