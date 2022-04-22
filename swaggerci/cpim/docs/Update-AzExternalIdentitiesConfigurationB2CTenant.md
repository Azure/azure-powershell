---
external help file:
Module Name: Az.ExternalIdentitiesConfiguration
online version: https://docs.microsoft.com/en-us/powershell/module/az.externalidentitiesconfiguration/update-azexternalidentitiesconfigurationb2ctenant
schema: 2.0.0
---

# Update-AzExternalIdentitiesConfigurationB2CTenant

## SYNOPSIS
Update the Azure AD B2C tenant resource.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzExternalIdentitiesConfigurationB2CTenant -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-BillingConfigBillingType <BillingType>] [-SkuName <B2CResourceSkuname>]
 [-SkuTier <B2CResourceSkutier>] [-Tag <Hashtable>] [-TenantId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzExternalIdentitiesConfigurationB2CTenant -InputObject <IExternalIdentitiesConfigurationIdentity>
 [-BillingConfigBillingType <BillingType>] [-SkuName <B2CResourceSkuname>] [-SkuTier <B2CResourceSkutier>]
 [-Tag <Hashtable>] [-TenantId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update the Azure AD B2C tenant resource.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -BillingConfigBillingType
The type of billing.
Will be MAU for all new customers.
If 'Auths', it can be updated to 'MAU'.
Cannot be changed if value is 'MAU'.
Learn more about Azure AD B2C billing at [aka.ms/b2cBilling](https://aka.ms/b2cbilling).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ExternalIdentitiesConfiguration.Support.BillingType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ExternalIdentitiesConfiguration.Models.IExternalIdentitiesConfigurationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The initial domain name of the Azure AD B2C tenant.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
The name of the SKU for the tenant.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ExternalIdentitiesConfiguration.Support.B2CResourceSkuname
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
The tier of the tenant.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ExternalIdentitiesConfiguration.Support.B2CResourceSkutier
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource Tags

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

### -TenantId
An identifier of the Azure AD B2C tenant.

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

### Microsoft.Azure.PowerShell.Cmdlets.ExternalIdentitiesConfiguration.Models.IExternalIdentitiesConfigurationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ExternalIdentitiesConfiguration.Models.Api20210401.IB2CTenantResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IExternalIdentitiesConfigurationIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ResourceName <String>]`: The initial domain name of the Azure AD B2C tenant.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

