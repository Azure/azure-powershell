---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/az.frontdoor/get-azfrontdoorwafpolicy
schema: 2.0.0
---

# Get-AzFrontDoorWafPolicy

## SYNOPSIS
Retrieve protection policy with specified name within a resource group.

## SYNTAX

### List1 (Default)
```
Get-AzFrontDoorWafPolicy [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzFrontDoorWafPolicy -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFrontDoorWafPolicy -InputObject <IFrontDoorIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzFrontDoorWafPolicy -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieve protection policy with specified name within a resource group.

## EXAMPLES

### Example 1
```powershell
Get-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName
```

```output
Customrule           : {customrule0, customrule01}
Etag                 :
FrontendEndpointLink : {}
Id                   : /subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/{policyName}
Location             : Global
ManagedRuleSet       : {{
                         "ruleSetType": "Microsoft_DefaultRuleSet",
                         "ruleSetVersion": "2.0",
                         "ruleSetAction": "Block",
                         "exclusions": [ ],
                         "ruleGroupOverrides": [ ]
                       }}
Name                 : {policyName}
PolicySetting        : {
                         "enabledState": "Enabled",
                         "mode": "Detection",
                         "customBlockResponseStatusCode": 403,
                         "requestBodyCheck": "Enabled"
                       }
ProvisioningState    : Succeeded
ResourceGroupName    : {rg}
ResourceState        : Enabled
RoutingRuleLink      :
SecurityPolicyLink   : {{
                         "id": "/subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Cdn/profiles/hdis-fe/securitypolicies/premium"
                       }}
SkuName              : Premium_AzureFrontDoor
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoorwebapplicationfirewallpolicies
```

Get a WAF policy called $policyName in $resourceGroupName

### Example 2
```powershell
Get-AzFrontDoorWafPolicy -ResourceGroupName $resourceGroupName
```

```output
Location Name              Etag ResourceGroupName
-------- ----              ---- -----------------
Global   n1                     rg
Global   n2                     rg
Global   n3                     rg
Global   n4                     rg
Global   n5                     rg
Global   n6                     rg
Global   n7                     rg
Global   n8                     rg
Global   n9                     rg
```

Get all WAF policy in $resourceGroupName

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
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Web Application Firewall Policy.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IWebApplicationFirewallPolicy

## NOTES

## RELATED LINKS

