### Example 1: Regenerate a test key for a Service.
```powershell
New-AzSpringTestKey -Name azps-spring-01 -ResourceGroupName azps_test_group_spring -KeyType Primary
```

```output
Enabled               : True
PrimaryKey            : k2JdGFkUwwG5NyQUM0Ahl2CuX3HbcjsTKK3ozU1QqmTBEnRWwy4SVkIqfUs6fm7D
PrimaryTestEndpoint   : https://primary:k2JdGFkUwwG5NyQUM0Ahl2CuX3HbcjsTKK3ozU1QqmTBEnRWwy4SVkIqfUs6fm7D@azps-spring-01.test.azuremicroservices.io
SecondaryKey          : yz9NLBHLcIbju3O3VTPVy9080nKviyaWygT0XW891n6n7ce1NSWA8oWuh0qJpjwA
SecondaryTestEndpoint : https://secondary:yz9NLBHLcIbju3O3VTPVy9080nKviyaWygT0XW891n6n7ce1NSWA8oWuh0qJpjwA@azps-spring-01.test.azuremicroservices.io
```

Regenerate a test key for a Service.