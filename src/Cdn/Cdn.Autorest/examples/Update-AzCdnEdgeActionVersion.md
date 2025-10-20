### Example 1: Update Edge Action Version with JSON string
```powershell
$jsonString = '{"properties":{"description":"Updated version description"}}'
Update-AzCdnEdgeActionVersion -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Name version001 -JsonString $jsonString
```

```output
Name       ResourceGroupName EdgeActionName
----       ----------------- --------------
version001 testps-rg-da16jm  edgeaction001
```

Update an Edge Action Version using JSON string configuration

### Example 2: Update Edge Action Version from JSON file
```powershell
Update-AzCdnEdgeActionVersion -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Name version001 -JsonFilePath "C:\config\edgeaction-version.json"
```

```output
Name       ResourceGroupName EdgeActionName
----       ----------------- --------------
version001 testps-rg-da16jm  edgeaction001
```

Update an Edge Action Version using configuration from a JSON file

