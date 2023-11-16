### Example 1: Update the Tags of a Dashboard
```powershell
Update-AzPortalDashboard -ResourceGroupName my-rg -Name dashbase03 -Tag @{'hidden-title'="My Dashboard Title"; NewTag="NewValue"}
```

```output
Location Name       Type
-------- ----       ----
eastasia dashbase03 Microsoft.Portal/dashboards
```

Update the tags in a dashboard.  Tags are represented as an inline hashtable.

### Example 2: Update Dashboard tags using the pipeline
```powershell
Get-AzPortalDashboard -ResourceGroupName my-rg -Name dashbase03 | Update-AzPortalDashboard -Tag @{'hidden-title'="My Dashboard Title"; NewTag="NewValue"}
```

```output
Location Name       Type
-------- ----       ----
eastasia dashbase03 Microsoft.Portal/dashboards
```

Update the Tags in a Dashboard retried using Get-AzPortalDashboard.  This can be used to update the tags over a single dashboard, or multiple dashboardfs.

