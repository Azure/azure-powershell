### Example 1: Create a new LogAnalytics workspace
```powershell
PS C:\> New-AzOperationalInsightsWorkspace -ResourceGroupName {RG-name} -Name {WS-name} -Location {Resource-location}

Location Name                   ETag ResourceGroupName
-------- ----                   ---- -----------------
{Resource-location}   {WS-name}
```