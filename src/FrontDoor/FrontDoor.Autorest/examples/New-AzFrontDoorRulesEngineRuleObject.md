### Example 1: Create new PSRulesEngineRule object and demonstrate how to see the subfields.
```powershell
New-AzFrontDoorRulesEngineRuleObject -Name rules1 -Priority 0 -Action $rulesEngineAction -MatchProcessingBehavior Stop -MatchCondition $rulesEngineMatchCondition
```

```output
Action                  : {
                            "requestHeaderActions": [
                              {
                                "headerActionType": "Append",
                                "headerName": "X-Content-Type-Options",
                                "value": "nosniff"
                              }
                            ],
                            "routeConfigurationOverride": {
                              "@odata.type": "#Microsoft.Azure.FrontDoor.Models.FrontdoorForwardingConfiguration",
                              "backendPool": {
                                "id": "/subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups/Jessicl-Test-RG/providers/Microsoft.Network/frontDoors/jessicl-test-myappfrontend/BackendPools/mybackendpool"
                              },
                              "forwardingProtocol": "HttpsOnly",
                              "cacheConfiguration": {
                                "queryParameterStripDirective": "StripNone",
                                "dynamicCompression": "Disabled"
                              }
                            }
                          }
MatchCondition          :
MatchProcessingBehavior : Stop
Name                    : rules1
Priority                : 0
```
Create new PSRulesEngineRule object and demonstrate how to see the subfields.
