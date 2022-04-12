### Example 1: Create a new LogAnalytics workspace
```powershell
New-AzOperationalInsightsWorkspace -ResourceGroupName RG-name -Name WS-name -Location Resource-location
```

```output
Location Name                   ETag ResourceGroupName
-------- ----                   ---- -----------------
{Resource-location}   {WS-name}
```

Creates a new LogAnalytics workspace for provided resource-group in the provided location.