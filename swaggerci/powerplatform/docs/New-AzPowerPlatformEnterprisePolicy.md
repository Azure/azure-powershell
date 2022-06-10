---
external help file:
Module Name: Az.PowerPlatform
online version: https://docs.microsoft.com/en-us/powershell/module/az.powerplatform/new-azpowerplatformenterprisepolicy
schema: 2.0.0
---

# New-AzPowerPlatformEnterprisePolicy

## SYNOPSIS
Creates an EnterprisePolicy

## SYNTAX

```
New-AzPowerPlatformEnterprisePolicy -Name <String> -ResourceGroupName <String> -Kind <EnterprisePolicyKind>
 -Location <String> [-SubscriptionId <String>] [-EncryptionState <State>]
 [-IdentityType <ResourceIdentityType>] [-KeyName <String>] [-KeyVaultId <String>] [-KeyVersion <String>]
 [-LockboxState <State>] [-Tag <Hashtable>] [-VirtualNetworkNextLink <String>]
 [-VirtualNetworkValue <IVirtualNetworkProperties[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates an EnterprisePolicy

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

### -EncryptionState
The state of onboarding, which only appears in the response.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerPlatform.Support.State
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The type of identity used for the EnterprisePolicy.
Currently, the only supported type is 'SystemAssigned', which implicitly creates an identity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerPlatform.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyName
The identifier of the key vault key used to encrypt data.

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

### -KeyVaultId
Uri of KeyVault

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

### -KeyVersion
The version of the identity which will be used to access key vault.

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

### -Kind
The kind (type) of Enterprise Policy.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerPlatform.Support.EnterprisePolicyKind
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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

### -LockboxState
lockbox configuration

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerPlatform.Support.State
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the EnterprisePolicy.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: EnterprisePolicyName

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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

### -VirtualNetworkNextLink
Next page link if any.

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

### -VirtualNetworkValue
Array of virtual networks.
To construct, see NOTES section for VIRTUALNETWORKVALUE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PowerPlatform.Models.Api20201030Preview.IVirtualNetworkProperties[]
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PowerPlatform.Models.Api20201030Preview.IEnterprisePolicy

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


VIRTUALNETWORKVALUE <IVirtualNetworkProperties[]>: Array of virtual networks.
  - `[Id <String>]`: Uri of the virtual network.
  - `[SubnetName <String>]`: Subnet name.

## RELATED LINKS

