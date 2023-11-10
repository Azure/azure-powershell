---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/update-azfrontdoorcdnsecuritypolicy
schema: 2.0.0
---

# Update-AzFrontDoorCdnSecurityPolicy

## SYNOPSIS
Updates an existing security policy within a profile.

## SYNTAX

### PatchExpanded (Default)
```
Update-AzFrontDoorCdnSecurityPolicy -Name <String> -ProfileName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Parameter <ISecurityPolicyPropertiesParameters>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentityExpanded
```
Update-AzFrontDoorCdnSecurityPolicy -InputObject <ICdnIdentity>
 [-Parameter <ISecurityPolicyPropertiesParameters>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates an existing security policy within a profile.

## EXAMPLES

### Example 1: Update an AzureFrontDoor security policy within the specified AzureFrontDoor profile
```powershell
$endpoint = Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001
$endpoint2 = Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end002
$updateAssociation = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
$updateAssociation2 = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint2.Id)})            

$wafPolicyId = "/subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf01"
$updateWafParameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association @($updateAssociation, $updateAssociation2) -WafPolicyId $wafPolicyId
Update-AzFrontDoorCdnSecurityPolicy -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name policy001 -Parameter $updateWafParameter
```

```output
Name      ResourceGroupName
----      -----------------
policy001 testps-rg-da16jm
```

Update an AzureFrontDoor security policy within the specified AzureFrontDoor profile

### Example 2: Update an AzureFrontDoor security policy within the specified AzureFrontDoor profile via identity
```powershell
$endpoint = Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001
$endpoint2 = Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end002
$updateAssociation = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint.Id)})
$updateAssociation2 = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallAssociationObject -PatternsToMatch @("/*") -Domain @(@{"Id"=$($endpoint2.Id)})            
                
$wafPolicyId = "/subscriptions/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx/resourcegroups/rgName01/providers/Microsoft.Network/frontdoorwebapplicationfirewallpolicies/waf01"
$updateWafParameter = New-AzFrontDoorCdnSecurityPolicyWebApplicationFirewallParametersObject  -Association @($updateAssociation, $updateAssociation2) -WafPolicyId $wafPolicyId

Get-AzFrontDoorCdnSecurityPolicy -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name policy001 | Update-AzFrontDoorCdnSecurityPolicy -Parameter $updateWafParameter
```

Update an AzureFrontDoor security policy within the specified AzureFrontDoor profile via identity

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: PatchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the security policy under the profile.

```yaml
Type: System.String
Parameter Sets: PatchExpanded
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
Parameter Sets: PatchExpanded
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
Parameter Sets: PatchExpanded
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
Parameter Sets: PatchExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ISecurityPolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ICdnIdentity>`: Identity Parameter
  - `[CustomDomainName <String>]`: Name of the domain under the profile which is unique globally.
  - `[EndpointName <String>]`: Name of the endpoint under the profile which is unique globally.
  - `[Id <String>]`: Resource identity path
  - `[OriginGroupName <String>]`: Name of the origin group which is unique within the endpoint.
  - `[OriginName <String>]`: Name of the origin which is unique within the profile.
  - `[ProfileName <String>]`: Name of the Azure Front Door Standard or Azure Front Door Premium which is unique within the resource group.
  - `[ResourceGroupName <String>]`: Name of the Resource group within the Azure subscription.
  - `[RouteName <String>]`: Name of the routing rule.
  - `[RuleName <String>]`: Name of the delivery rule which is unique within the endpoint.
  - `[RuleSetName <String>]`: Name of the rule set under the profile which is unique globally.
  - `[SecretName <String>]`: Name of the Secret under the profile.
  - `[SecurityPolicyName <String>]`: Name of the security policy under the profile.
  - `[SubscriptionId <String>]`: Azure Subscription ID.

## RELATED LINKS

