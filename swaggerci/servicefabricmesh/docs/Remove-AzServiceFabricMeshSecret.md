---
external help file:
Module Name: Az.ServiceFabricMesh
online version: https://docs.microsoft.com/en-us/powershell/module/az.servicefabricmesh/remove-azservicefabricmeshsecret
schema: 2.0.0
---

# Remove-AzServiceFabricMeshSecret

## SYNOPSIS
Deletes the secret resource identified by the name.

## SYNTAX

### Delete (Default)
```
Remove-AzServiceFabricMeshSecret -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzServiceFabricMeshSecret -InputObject <IServiceFabricMeshIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Deletes the secret resource identified by the name.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.IServiceFabricMeshIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ResourceGroupName
Azure resource group name

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the secret resource.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: SecretResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The customer subscription identifier

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.IServiceFabricMeshIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IServiceFabricMeshIdentity>: Identity Parameter
  - `[ApplicationResourceName <String>]`: The identity of the application.
  - `[CodePackageName <String>]`: The name of code package of the service.
  - `[GatewayResourceName <String>]`: The identity of the gateway.
  - `[Id <String>]`: Resource identity path
  - `[NetworkResourceName <String>]`: The identity of the network.
  - `[ReplicaName <String>]`: Service Fabric replica name.
  - `[ResourceGroupName <String>]`: Azure resource group name
  - `[SecretResourceName <String>]`: The name of the secret resource.
  - `[SecretValueResourceName <String>]`: The name of the secret resource value which is typically the version identifier for the value.
  - `[ServiceResourceName <String>]`: The identity of the service.
  - `[SubscriptionId <String>]`: The customer subscription identifier
  - `[VolumeResourceName <String>]`: The identity of the volume.

## RELATED LINKS

