### Example 1: Update Edge Action Execution Filter with JSON string
```powershell
$jsonString = '{"properties":{"filterType":"response","conditions":[{"operator":"Equal","matchValues":["text/html"]}]}}'
Update-AzCdnEdgeActionExecutionFilter -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Name filter001 -JsonString $jsonString
```

```output
Name      ResourceGroupName EdgeActionName
----      ----------------- --------------
filter001 testps-rg-da16jm  edgeaction001
```

Update an Edge Action Execution Filter using JSON string configuration

### Example 2: Update Edge Action Execution Filter from JSON file
```powershell
Update-AzCdnEdgeActionExecutionFilter -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Name filter001 -JsonFilePath "C:\config\execution-filter.json"
```

```output
Name      ResourceGroupName EdgeActionName
----      ----------------- --------------
filter001 testps-rg-da16jm  edgeaction001
```

Update an Edge Action Execution Filter using configuration from a JSON file

