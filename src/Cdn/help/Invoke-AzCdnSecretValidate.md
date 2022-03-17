---
external help file:
Module Name: Az.Cdn
online version: https://docs.microsoft.com/powershell/module/az.cdn/invoke-azcdnsecretvalidate
schema: 2.0.0
---

# Invoke-AzCdnSecretValidate

## SYNOPSIS
Validate a Secret in the profile.

## SYNTAX

### SecretExpanded (Default)
```
Invoke-AzCdnSecretValidate -SecretType <SecretType> [-SubscriptionId <String>] [-SecretSourceId <String>]
 [-SecretVersion <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Secret
```
Invoke-AzCdnSecretValidate -ValidateSecretInput <IValidateSecretInput> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SecretViaIdentity
```
Invoke-AzCdnSecretValidate -InputObject <ICdnIdentity> -ValidateSecretInput <IValidateSecretInput>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SecretViaIdentityExpanded
```
Invoke-AzCdnSecretValidate -InputObject <ICdnIdentity> -SecretType <SecretType> [-SecretSourceId <String>]
 [-SecretVersion <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validate a Secret in the profile.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Parameter Sets: SecretViaIdentity, SecretViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SecretSourceId
Resource ID.

```yaml
Type: System.String
Parameter Sets: SecretExpanded, SecretViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretType
The secret type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.SecretType
Parameter Sets: SecretExpanded, SecretViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretVersion
Secret version, if customer is using a specific version.

```yaml
Type: System.String
Parameter Sets: SecretExpanded, SecretViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: Secret, SecretExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidateSecretInput
Input of the secret to be validated.
To construct, see NOTES section for VALIDATESECRETINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IValidateSecretInput
Parameter Sets: Secret, SecretViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IValidateSecretInput

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20210601.IValidateSecretOutput

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ICdnIdentity>: Identity Parameter
  - `[CustomDomainName <String>]`: Name of the domain under the profile which is unique globally.
  - `[EndpointName <String>]`: Name of the endpoint under the profile which is unique globally.
  - `[Id <String>]`: Resource identity path
  - `[OriginGroupName <String>]`: Name of the origin group which is unique within the endpoint.
  - `[OriginName <String>]`: Name of the origin which is unique within the profile.
  - `[PolicyName <String>]`: The name of the CdnWebApplicationFirewallPolicy.
  - `[ProfileName <String>]`: Name of the Azure Front Door Standard or Azure Front Door Premium or CDN profile which is unique within the resource group.
  - `[ResourceGroupName <String>]`: Name of the Resource group within the Azure subscription.
  - `[RouteName <String>]`: Name of the routing rule.
  - `[RuleName <String>]`: Name of the delivery rule which is unique within the endpoint.
  - `[RuleSetName <String>]`: Name of the rule set under the profile which is unique globally.
  - `[SecretName <String>]`: Name of the Secret under the profile.
  - `[SecurityPolicyName <String>]`: Name of the security policy under the profile.
  - `[SubscriptionId <String>]`: Azure Subscription ID.

VALIDATESECRETINPUT <IValidateSecretInput>: Input of the secret to be validated.
  - `SecretType <SecretType>`: The secret type.
  - `[SecretSourceId <String>]`: Resource ID.
  - `[SecretVersion <String>]`: Secret version, if customer is using a specific version.

## RELATED LINKS

