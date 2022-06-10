---
external help file:
Module Name: Az.ManagedNetwork
online version: https://docs.microsoft.com/en-us/powershell/module/az.managednetwork/new-azmanagednetwork
schema: 2.0.0
---

# New-AzManagedNetwork

## SYNOPSIS
The Put ManagedNetworks operation creates/updates a Managed Network Resource, specified by resource group and Managed Network name

## SYNTAX

```
New-AzManagedNetwork -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Location <String>] [-ScopeManagementGroup <IResourceId[]>] [-ScopeSubnet <IResourceId[]>]
 [-ScopeSubscription <IResourceId[]>] [-ScopeVirtualNetwork <IResourceId[]>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Put ManagedNetworks operation creates/updates a Managed Network Resource, specified by resource group and Managed Network name

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

### -Location
The geo-location where the resource lives

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
The name of the Managed Network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ManagedNetworkName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

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

### -ScopeManagementGroup
The collection of management groups covered by the Managed Network
To construct, see NOTES section for SCOPEMANAGEMENTGROUP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.Models.Api20190601Preview.IResourceId[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeSubnet
The collection of subnets covered by the Managed Network
To construct, see NOTES section for SCOPESUBNET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.Models.Api20190601Preview.IResourceId[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeSubscription
The collection of subscriptions covered by the Managed Network
To construct, see NOTES section for SCOPESUBSCRIPTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.Models.Api20190601Preview.IResourceId[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeVirtualNetwork
The collection of virtual nets covered by the Managed Network
To construct, see NOTES section for SCOPEVIRTUALNETWORK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.Models.Api20190601Preview.IResourceId[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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
Resource tags

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetwork.Models.Api20190601Preview.IManagedNetwork

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


SCOPEMANAGEMENTGROUP <IResourceId[]>: The collection of management groups covered by the Managed Network
  - `[Id <String>]`: Resource Id

SCOPESUBNET <IResourceId[]>: The collection of subnets covered by the Managed Network
  - `[Id <String>]`: Resource Id

SCOPESUBSCRIPTION <IResourceId[]>: The collection of subscriptions covered by the Managed Network
  - `[Id <String>]`: Resource Id

SCOPEVIRTUALNETWORK <IResourceId[]>: The collection of virtual nets covered by the Managed Network
  - `[Id <String>]`: Resource Id

## RELATED LINKS

