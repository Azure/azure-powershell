### Example 1: Create a windows event log data source object
```powershell
New-AzWindowsEventLogDataSourceObject -Name cloudSecurityTeamEvents -Stream Microsoft-WindowsEvent -XPathQuery "Security!"
```

```output
Name                    Stream                   XPathQuery
----                    ------                   ----------
cloudSecurityTeamEvents {Microsoft-WindowsEvent} {Security!}
```

This command creates a windows event log data source object with XPathQuery.

### Example 2: Create a windows event log data source object
```powershell
New-AzWindowsEventLogDataSourceObject -Name appTeam1AppEvents -Stream Microsoft-WindowsEvent -XPathQuery "System![System[(Level = 1 or Level = 2 or Level = 3)]]","Application!*[System[(Level = 1 or Level = 2 or Level = 3)]]"
```

```output
Name              Stream                   XPathQuery
----              ------                   ----------
appTeam1AppEvents {Microsoft-WindowsEvent} {System![System[(Level = 1 or Level = 2 or Level = 3)]], Application!*[System[(Level = 1 or Level = 2 or Level = 3)]]}
```

This command creates a windows event log data source object with XPathQueries.

