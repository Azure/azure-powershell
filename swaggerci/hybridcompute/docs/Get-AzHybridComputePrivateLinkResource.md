---
external help file:
Module Name: Az.HybridCompute
online version: https://docs.microsoft.com/en-us/powershell/module/az.hybridcompute/get-azhybridcomputeprivatelinkresource
schema: 2.0.0
---

# Get-AzHybridComputePrivateLinkResource

## SYNOPSIS
Gets the private link resources that need to be created for a Azure Monitor PrivateLinkScope.

## SYNTAX

### List (Default)
```
Get-AzHybridComputePrivateLinkResource -ResourceGroupName <String> -ScopeName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzHybridComputePrivateLinkResource -GroupName <String> -ResourceGroupName <String> -ScopeName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHybridComputePrivateLinkResource -InputObject <IHybridComputeIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the private link resources that need to be created for a Azure Monitor PrivateLinkScope.

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

### -GroupName
The name of the private link resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HybridCompute.Models.IHybridComputeIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -ScopeName
The name of the Azure Arc PrivateLinkScope resource.

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
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.HybridCompute.Models.IHybridComputeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HybridCompute.Models.Api20220310.IPrivateLinkResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IHybridComputeIdentity>: Identity Parameter
  - `[ExtensionName <String>]`: The name of the machine extension.
  - `[GroupName <String>]`: The name of the private link resource.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The location of the target resource.
  - `[MachineName <String>]`: The name of the hybrid machine.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[PrivateLinkScopeId <String>]`: The id (Guid) of the Azure Arc PrivateLinkScope resource.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ScopeName <String>]`: The name of the Azure Arc PrivateLinkScope resource.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

