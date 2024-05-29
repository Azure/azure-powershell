### Example 1: Lists all of the available server versions supported by Microsoft.AppPlatform provider.
```powershell
Get-AzSpringServiceSupportedServerVersion -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01
```

```output
Server Value     Version
------ -----     -------
Tomcat Tomcat_9  9
Tomcat Tomcat_10 10
```

Lists all of the available server versions supported by Microsoft.AppPlatform provider.