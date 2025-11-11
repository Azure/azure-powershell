### Example 1: Update a rules engine configuration with new header action rules
```powershell
$headerActions = New-AzFrontDoorHeaderActionObject -HeaderActionType "Overwrite" -HeaderName "Strict-Transport-Security" -Value "max-age=63072000; includeSubDomains; preload"
$rulesEngineAction = New-AzFrontDoorRulesEngineActionObject -ResponseHeaderAction $headerActions
$matchCondition = New-AzFrontDoorRulesEngineMatchConditionObject -MatchVariable RequestPath -Operator BeginsWith -MatchValue "/secure"
$rulesEngineRule = New-AzFrontDoorRulesEngineRuleObject -Name "SecurityHeaderRule" -Priority 1 -Action $rulesEngineAction -MatchCondition $matchCondition -MatchProcessingBehavior Continue
Set-AzFrontDoorRulesEngine -ResourceGroupName "myResourceGroup" -FrontDoorName "myFrontDoor" -Name "myRulesEngine" -Rule $rulesEngineRule
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

Update an existing rules engine configuration to add a new rule that applies security headers to requests matching a specific path pattern.

### Example 2: Update rules engine configuration to redirect specific paths
```powershell
$redirectAction = New-AzFrontDoorRulesEngineActionObject -RedirectType Moved -RedirectProtocol MatchRequest -CustomHost "www.contoso.com" -CustomPath "/newlocation"
$matchCondition = New-AzFrontDoorRulesEngineMatchConditionObject -MatchVariable RequestPath -Operator Equal -MatchValue "/oldpath"
$redirectRule = New-AzFrontDoorRulesEngineRuleObject -Name "RedirectOldPath" -Priority 0 -Action $redirectAction -MatchCondition $matchCondition -MatchProcessingBehavior Stop
Set-AzFrontDoorRulesEngine -ResourceGroupName "myResourceGroup" -FrontDoorName "myFrontDoor" -Name "myRulesEngine" -Rule $redirectRule
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

Update the rules engine configuration to redirect requests from an old path to a new location with a 301 Moved redirect.