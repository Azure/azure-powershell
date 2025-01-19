### Example 1: List test keys for a Service.
```powershell
Get-AzSpringTestKey -Name azps-spring-01 -ResourceGroupName azps_test_group_spring
```

```output
Enabled               : True
PrimaryKey            : AL4W969BM5bfDRyXsa3WXtxpQHr5dL6f3RGnq2Xf6BZ3VFA4WXs7scSklzNAudKE
PrimaryTestEndpoint   : https://primary:AL4W969BM5bfDRyXsa3WXtxpQHr5dL6f3RGnq2Xf6BZ3VFA4WXs7scSklzNAudKE@azps-spring-01.test.azuremicroservices.io
SecondaryKey          : HiagYRIgAPJpFkOSxRFDjXzVDQ6d4QBWRMW89WCgCQKCMPvaYEhK4VThpKesfzYT
SecondaryTestEndpoint : https://secondary:HiagYRIgAPJpFkOSxRFDjXzVDQ6d4QBWRMW89WCgCQKCMPvaYEhK4VThpKesfzYT@azps-spring-01.test.azuremicroservices.io
```

List test keys for a Service.

### Example 2: List test keys for a Service.
```powershell
Disable-AzSpringTestEndpoint -ResourceGroupName azps_test_group_spring -Name azps-spring-01
Get-AzSpringTestKey -Name azps-spring-01 -ResourceGroupName azps_test_group_spring
```

```output
Enabled               : False
PrimaryKey            :
PrimaryTestEndpoint   :
SecondaryKey          :
SecondaryTestEndpoint :
```

List test keys for a Service.