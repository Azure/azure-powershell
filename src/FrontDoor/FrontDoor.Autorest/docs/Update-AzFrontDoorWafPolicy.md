---
external help file:
Module Name: Az.FrontDoor
online version: https://learn.microsoft.com/powershell/module/az.frontdoor/update-azfrontdoorwafpolicy
schema: 2.0.0
---

# Update-AzFrontDoorWafPolicy

## SYNOPSIS
Update policy with specified rule set name within a resource group.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzFrontDoorWafPolicy -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-CaptchaExpirationInMinutes <Int32?>] [-CustomBlockResponseBody <String>]
 [-CustomBlockResponseStatusCode <Int32?>] [-Customrule <ICustomRule[]>] [-EnabledState <String>]
 [-Etag <String>] [-JavascriptChallengeExpirationInMinutes <Int32?>]
 [-LogScrubbingSetting <IPolicySettingsLogScrubbing>] [-ManagedRuleSet <IManagedRuleSet[]>] [-Mode <String>]
 [-RedirectUrl <String>] [-RequestBodyCheck <String>] [-SkuName <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ByFieldsParameterSet
```
Update-AzFrontDoorWafPolicy [-Name <String>] [-ResourceGroupName <String>] [-SubscriptionId <String>]
 [-CaptchaExpirationInMinutes <Int32?>] [-CustomBlockResponseBody <String>]
 [-CustomBlockResponseStatusCode <Int32?>] [-Customrule <ICustomRule[]>] [-EnabledState <String>]
 [-Etag <String>] [-JavascriptChallengeExpirationInMinutes <Int32?>]
 [-LogScrubbingSetting <IPolicySettingsLogScrubbing>] [-ManagedRuleSet <IManagedRuleSet[]>] [-Mode <String>]
 [-RedirectUrl <String>] [-RequestBodyCheck <String>] [-SkuName <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzFrontDoorWafPolicy -InputObject <IFrontDoorIdentity> [-CaptchaExpirationInMinutes <Int32?>]
 [-CustomBlockResponseBody <String>] [-CustomBlockResponseStatusCode <Int32?>] [-Customrule <ICustomRule[]>]
 [-EnabledState <String>] [-Etag <String>] [-JavascriptChallengeExpirationInMinutes <Int32?>]
 [-LogScrubbingSetting <IPolicySettingsLogScrubbing>] [-ManagedRuleSet <IManagedRuleSet[]>] [-Mode <String>]
 [-RedirectUrl <String>] [-RequestBodyCheck <String>] [-SkuName <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update policy with specified rule set name within a resource group.

## EXAMPLES

### Example 1: Updates an existing WAF policy custom status code.
```powershell
Update-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName -CustomBlockResponseStatusCode 403
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

Update an existing WAF policy custom status code.

### Example 2: Update an existing WAF policy mode.
```powershell
Update-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName -Mode Detection
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

Update an existing WAF policy mode.

### Example 3: Update an existing WAF policy enabled state and mode.
```powershell
Update-AzFrontDoorWafPolicy -Name $policyName -ResourceGroupName $resourceGroupName -Mode Detection -EnabledState Disabled
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
ResourceState        : Disabled
RoutingRuleLink      :
SecurityPolicyLink   : {{
                         "id": "/subscriptions/{subid}/resourcegroups/{rg}/providers/Microsoft.Cdn/profiles/hdis-fe/securitypolicies/premium"
                       }}
SkuName              : Premium_AzureFrontDoor
Tag                  : {
                       }
Type                 : Microsoft.Network/frontdoorwebapplicationfirewallpolicies
```

Update an existing WAF policy enabled state and mode.

### Example 4: Update all WAF policies in $resourceGroupName
```powershell
Get-AzFrontDoorWafPolicy -ResourceGroupName $resourceGroupName | Update-AzFrontDoorWafPolicy -Mode Detection -EnabledState Disabled
```

Update all WAF policies in $resourceGroupName

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

### -CaptchaExpirationInMinutes
Defines the Captcha cookie validity lifetime in minutes.
This setting is only applicable to Premium_AzureFrontDoor.
Value must be an integer between 5 and 1440 with the default value being 30.

```yaml
Type: System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomBlockResponseBody
If the action type is block, customer can override the response body.
The body must be specified in base64 encoding.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomBlockResponseStatusCode
If the action type is block, customer can override the response status code.

```yaml
Type: System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Customrule
List of rules

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.ICustomRule[]
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

### -EnabledState
Describes if the policy is in enabled or disabled state.
Defaults to Enabled if not specified.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Etag
Gets a unique read-only string that changes whenever the resource is updated.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JavascriptChallengeExpirationInMinutes
Defines the JavaScript challenge cookie validity lifetime in minutes.
This setting is only applicable to Premium_AzureFrontDoor.
Value must be an integer between 5 and 1440 with the default value being 30.

```yaml
Type: System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogScrubbingSetting
Defines rules that scrub sensitive fields in the Web Application Firewall logs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IPolicySettingsLogScrubbing
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedRuleSet
List of rule sets.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IManagedRuleSet[]
Parameter Sets: (All)
Aliases: ManagedRule

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Mode
Describes if it is in detection mode or prevention mode at policy level.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Web Application Firewall Policy.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet, UpdateExpanded
Aliases: PolicyName

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

### -RedirectUrl
If action type is redirect, this field represents redirect URL for the client.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestBodyCheck
Describes if policy managed rules will inspect the request body content.

```yaml
Type: System.String
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
Parameter Sets: ByFieldsParameterSet, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the pricing tier.

```yaml
Type: System.String
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
Parameter Sets: ByFieldsParameterSet, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IFrontDoorIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FrontDoor.Models.IWebApplicationFirewallPolicy

## NOTES

## RELATED LINKS

