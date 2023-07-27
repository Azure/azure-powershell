### Example 1: Create a new App or update an exiting App
```powershell
New-AzSpringApp -ResourceGroupName azps_test_group_spring -ServiceName azps-spring -Name tools
```

```output
Name  SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----  ------------------- -------------------     ----------------------- ------------------------ ------------------------
tools 2022/6/28 8:33:27   ******@microsoft.com    User                    2022/6/28 8:33:27         ******@microsoft.com
```

Create a new App or update an exiting App.