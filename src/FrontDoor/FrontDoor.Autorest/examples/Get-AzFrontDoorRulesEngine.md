### Example 1
```powershell
Get-AzFrontDoorRulesEngine -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name rulesengine3
```

```output
Id                : /subscriptions/{subId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Network/frontdoors/{frontDoorName}/rulesengines/rulesengine3
Name              : rulesengine3
ResourceGroupName : {resourceGroupName}
ResourceState     : Enabled
Rule              : {{
                      "name": "rule111",
                      "priority": 0,
                      "action": {
                        "requestHeaderActions": [ ],
                        "responseHeaderActions": [
                          {
                            "headerActionType": "Overwrite",
                            "headerName": "ff",
                            "value": "ff"
                          }
                        ]
                      },
                      "matchConditions": [
                        {
                          "rulesEngineMatchVariable": "QueryString",
                          "rulesEngineOperator": "Contains",
                          "negateCondition": false,
                          "rulesEngineMatchValue": [ "fdfd" ],
                          "transforms": [ ]
                        }
                      ],
                      "matchProcessingBehavior": "Continue"
                    }}
Type              : Microsoft.Network/frontdoors/rulesengines
```

Get specific rules engine configuration.


### Example 2

```powershell
Get-AzFrontDoorRulesEngine -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name nonexistent
```

```output
Get-AzFrontDoorRulesEngine_Get: The requested resource was not found.
```

Expected output when getting a nonexistent rules engine. 