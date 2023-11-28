---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/new-azfrontdoorcdnsecuritypolicy
schema: 2.0.0
---

# New-AzFrontDoorCdnSecurityPolicy

## SYNOPSIS
Creates a new security policy within the specified profile.

## SYNTAX

```
New-AzFrontDoorCdnSecurityPolicy -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Parameter <ISecurityPolicyPropertiesParameters>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new security policy within the specified profile.

## EXAMPLES

### Example 1: Create an AzureFrontDoor security policy within the specified AzureFrontDoor profile
```powershell
$wafPolicyId = "/subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf01"
$endpoint = Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001
$association = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
$wafParameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association  $association  -WafPolicyId $wafPolicyId

New-AzFrontDoorCdnSecurityPolicy -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name policy001 -Parameter $wafParameter   
```

```output
Name      ResourceGroupName
----      -----------------
policy001 testps-rg-da16jm
```

Create an AzureFrontDoor security policy within the specified AzureFrontDoor profile

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

### -Name
Name of the security policy under the profile.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SecurityPolicyName

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

### -Parameter
object which contains security policy parameters

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ISecurityPolicyPropertiesParameters
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium profile which is unique within the resource group.

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

### -SubscriptionId
Azure Subscription ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ISecurityPolicy

## NOTES

ALIASES

## RELATED LINKS

