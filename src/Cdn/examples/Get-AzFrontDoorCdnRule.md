### Example 1: list AzureFrontDoor delivery rules within the specified rule set
```powershell
Get-AzFrontDoorCdnRule -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001
```

```output
Name      ResourceGroupName
----      -----------------
testrule1 testps-rg-da16jm
testrule2 testps-rg-da16jm
rule1     testps-rg-da16jm
```

list AzureFrontDoor delivery rules within the specified rule set


### Example 2: Get an AzureFrontDoor delivery rule within the specified rule set
```powershell
Get-AzFrontDoorCdnRule -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 -Name rule1
```

```output
Name  ResourceGroupName
----  -----------------
rule1 testps-rg-da16jm
```

Get an AzureFrontDoor delivery rule within the specified rule set


### Example 3: Get an AzureFrontDoor delivery rule within the specified rule set via identity
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

New-AzFrontDoorCdnRule -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -RuleSetName ruleset001 -Name rule1 -Action $actions -Condition $conditions | Get-AzFrontDoorCdnRule
```

```output
Name  ResourceGroupName
----  -----------------
rule1 testps-rg-da16jm
```

Get an AzureFrontDoor delivery rule within the specified rule set via identity