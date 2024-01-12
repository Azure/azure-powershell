### Example 1: Regenerate a test key for a Service.
```powershell
New-AzSpringTestKey -Name azps-spring-01 -ResourceGroupName azps_test_group_spring -KeyType Primary
```

```output
Enabled               : True
PrimaryKey            : AL4W969BM5bfDRyXsa3WXtxpQHr5dL6f3RGnq2Xf6BZ3VFA4WXs7scSklzNAudKE
PrimaryTestEndpoint   : https://primary:AL4W969BM5bfDRyXsa3WXtxpQHr5dL6f3RGnq2Xf6BZ3VFA4WXs7scSklzNAudKE@azps-spring-01.test.azuremicroservices.io
SecondaryKey          : HiagYRIgAPJpFkOSxRFDjXzVDQ6d4QBWRMW89WCgCQKCMPvaYEhK4VThpKesfzYT
SecondaryTestEndpoint : https://secondary:HiagYRIgAPJpFkOSxRFDjXzVDQ6d4QBWRMW89WCgCQKCMPvaYEhK4VThpKesfzYT@azps-spring-01.test.azuremicroservices.io
```

Regenerate a test key for a Service.