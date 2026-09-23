### Example 1: Create a new rules engine configuration for specified front door.
```powershell
New-AzFrontDoorRulesEngine -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name myRulesEngine -Rule $rulesEngineRule1
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

Create a new rules engine configuration for specified front door.