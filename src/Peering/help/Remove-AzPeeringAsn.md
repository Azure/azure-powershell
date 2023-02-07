---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/remove-azpeeringasn
schema: 2.0.0
---

# Remove-AzPeeringAsn

## SYNOPSIS
Deletes an existing peer ASN with the specified name under the given subscription.

## SYNTAX

### Delete (Default)
```
Remove-AzPeeringAsn -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzPeeringAsn -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Deletes an existing peer ASN with the specified name under the given subscription.

## EXAMPLES

### Example 1: Remove peer asn
```powershell
Remove-AzPeeringAsn -Name PsTestAsn
```

Removes peer asn with the name specified

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The peer ASN name.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: PeerAsnName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: Delete
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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IPeeringIdentity>`: Identity Parameter
  - `[ConnectionMonitorTestName <String>]`: The name of the connection monitor test
  - `[Id <String>]`: Resource identity path
  - `[PeerAsnName <String>]`: The peer ASN name.
  - `[PeeringName <String>]`: The name of the peering.
  - `[PeeringServiceName <String>]`: The name of the peering service.
  - `[PrefixName <String>]`: The name of the prefix.
  - `[RegisteredAsnName <String>]`: The name of the registered ASN.
  - `[RegisteredPrefixName <String>]`: The name of the registered prefix.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: The Azure subscription ID.

## RELATED LINKS

