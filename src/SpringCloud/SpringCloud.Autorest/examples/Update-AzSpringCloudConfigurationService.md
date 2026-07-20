### Example 1: Update the existing Application Configuration Service
```powershell
Update-AzSpringCloudConfigurationService -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-01 -GitRepository ***
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2025/4/22 3:26:33   tester@microsoft.com    User                    2025/4/22 7:46:06        tester@microsoft.com
```

This command updates the existing Application Configuration Service.