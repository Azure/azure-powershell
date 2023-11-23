### Example 1: Get all App under the spring service
```powershell
Get-AzSpringCloudApp -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service
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
Get-AzSpringCloudApp -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -Name tools
```

```output
Name  SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----  ------------------- -------------------     ----------------------- ------------------------ ------------------------
tools 2022/6/28 8:33:27   *********@microsoft.com User                    2022/6/28 8:33:27        *********@microsoft.com
```

Get an App and its properties.

### Example 3: Get an App and its properties by pipeline
```powershell
New-AzSpringCloudApp -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -Name tools | Get-AzSpringCloudApp
```

```output
Name  SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----  ------------------- -------------------     ----------------------- ------------------------ ------------------------
tools 2022/6/28 8:33:27   *********@microsoft.com User                    2022/6/28 8:33:27        *********@microsoft.com
```

Get an App and its properties by pipeline.

