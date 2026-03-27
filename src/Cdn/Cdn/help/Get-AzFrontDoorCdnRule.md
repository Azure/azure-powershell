---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/get-azfrontdoorcdnrule
schema: 2.0.0
---

# Get-AzFrontDoorCdnRule

## SYNOPSIS
Gets an existing delivery rule within a rule set.

## SYNTAX

### List (Default)
```
Get-AzFrontDoorCdnRule -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityRuleSet
```
Get-AzFrontDoorCdnRule -Name <String> -RuleSetInputObject <ICdnIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityProfile
```
Get-AzFrontDoorCdnRule -Name <String> -SetName <String> -ProfileInputObject <ICdnIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzFrontDoorCdnRule -Name <String> -ProfileName <String> -ResourceGroupName <String> -SetName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFrontDoorCdnRule -InputObject <ICdnIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an existing delivery rule within a rule set.

## EXAMPLES

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

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the delivery rule which is unique within the endpoint.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityRuleSet, GetViaIdentityProfile, Get
Aliases: RuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: GetViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RuleSetInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: GetViaIdentityRuleSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SetName
Name of the rule set under the profile.

```yaml
Type: System.String
Parameter Sets: List, GetViaIdentityProfile, Get
Aliases: RuleSetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IRule

## NOTES

## RELATED LINKS
