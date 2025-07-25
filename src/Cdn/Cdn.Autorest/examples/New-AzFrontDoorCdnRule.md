### Example 1: Creates an AzureFrontDoor delivery rule within the specified rule set
```powershell
$conditions = @(
    New-AzFrontDoorCdnRuleClientPortConditionObject -Name ClientPort -ParameterOperator Equal -ParameterMatchValue 80,81
    New-AzFrontDoorCdnRuleIsDeviceConditionObject -Name IsDevice -ParameterMatchValue Mobile
    New-AzFrontDoorCdnRuleSslProtocolConditionObject -Name SslProtocol -ParameterMatchValue TLSv1.2
);

       
$actions = @(
    New-AzFrontDoorCdnRuleRequestHeaderActionObject -Name ModifyRequestHeader -ParameterHeaderAction Append -ParameterHeaderName a1 -ParameterValue a1
    New-AzFrontDoorCdnRuleResponseHeaderActionObject -Name ModifyResponseHeader -ParameterHeaderAction Append -ParameterHeaderName a1 -ParameterValue a1
    New-AzFrontDoorCdnRuleUrlRedirectActionObject -Name UrlRedirect -ParameterRedirectType Moved -ParameterDestinationProtocol MatchRequest
);

New-AzFrontDoorCdnRule -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 -Name rule1 -Action $actions -Condition $conditions
```

```output
Name  ResourceGroupName
----  -----------------
rule1 testps-rg-da16jm
```

Creates an AzureFrontDoor delivery rule within the specified rule set