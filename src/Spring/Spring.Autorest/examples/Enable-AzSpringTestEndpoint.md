### Example 1: Enable test endpoint functionality for a Service.
```powershell
Enable-AzSpringTestEndpoint -ResourceGroupName azps_test_group_spring -Name azps-spring-01
```

```output
Enabled               : True
PrimaryKey            : uuCEzTaXQ15sxbe2fMmmDC4uBsXxSt91fM1AHpZR1eCOM7tlmmmdLD2Esf6t5nej
PrimaryTestEndpoint   : https://primary:uuCEzTaXQ15sxbe2fMmmDC4uBsXxSt91fM1AHpZR1eCOM7tlmmmdLD2Esf6t5nej@azps-spring-01.test.azuremicroservices.io
SecondaryKey          : HiagYRIgAPJpFkOSxRFDjXzVDQ6d4QBWRMW89WCgCQKCMPvaYEhK4VThpKesfzYT
SecondaryTestEndpoint : https://secondary:HiagYRIgAPJpFkOSxRFDjXzVDQ6d4QBWRMW89WCgCQKCMPvaYEhK4VThpKesfzYT@azps-spring-01.test.azuremicroservices.io
```

Enable test endpoint functionality for a Service.