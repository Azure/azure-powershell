### Example 1: Get all App under the spring service
```powershell
Get-AzSpringApp -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----   ------------------- -------------------     ----------------------- ------------------------ ------------------------
plugin 2022/6/28 9:15:47   *********@microsoft.com User                    2022/6/28 9:15:47        *********@microsoft.com
tools  2022/6/28 8:33:27   *********@microsoft.com User                    2022/6/28 8:33:27        *********@microsoft.com
```

Get all App under the spring service.

### Example 2: Get an App and its properties
```powershell
Get-AzSpringApp -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -Name tools
```

```output
Name  SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----  ------------------- -------------------     ----------------------- ------------------------ ------------------------
tools 2022/6/28 8:33:27   *********@microsoft.com User                    2022/6/28 8:33:27        *********@microsoft.com
```

Get an App and its properties.

### Example 3: Get an App and its properties by pipeline
```powershell
New-AzSpringApp -ResourceGroupName Spring-gp-junxi -ServiceName Spring-service -Name tools | Get-AzSpringApp
```

```output
Name  SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----  ------------------- -------------------     ----------------------- ------------------------ ------------------------
tools 2022/6/28 8:33:27   *********@microsoft.com User                    2022/6/28 8:33:27        *********@microsoft.com
```

Get an App and its properties by pipeline.