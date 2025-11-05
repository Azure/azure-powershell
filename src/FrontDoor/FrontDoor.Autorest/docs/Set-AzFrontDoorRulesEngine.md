---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/az.frontdoor/set-azfrontdoorrulesengine
schema: 2.0.0
---

# Set-AzFrontDoorRulesEngine

## SYNOPSIS
Update a new Rules Engine Configuration with the specified name within the specified Front Door.

## SYNTAX

```
Set-AzFrontDoorRulesEngine -FrontDoorName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Rule <IRulesEngineRule[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a new Rules Engine Configuration with the specified name within the specified Front Door.

## EXAMPLES

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

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FrontDoorName
Name of the Front Door which is globally unique.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Rules Engine which is unique within the Front Door.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RulesEngineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Rule
A list of rules that define a particular Rules Engine Configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRulesEngineRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IRulesEngine

## NOTES

## RELATED LINKS

