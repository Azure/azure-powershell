---
external help file:
Module Name: Az.ServiceFabricMesh
online version: https://learn.microsoft.com/powershell/module/az.servicefabricmesh/get-azservicefabricmeshcodepackagecontainerlog
schema: 2.0.0
---

# Get-AzServiceFabricMeshCodePackageContainerLog

## SYNOPSIS
Gets the logs for the container of the specified code package of the service replica.

## SYNTAX

### Get (Default)
```
Get-AzServiceFabricMeshCodePackageContainerLog -ApplicationResourceName <String> -CodePackageName <String>
 -ReplicaName <String> -ResourceGroupName <String> -ServiceResourceName <String> [-SubscriptionId <String[]>]
 [-Tail <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzServiceFabricMeshCodePackageContainerLog -InputObject <IServiceFabricMeshIdentity> [-Tail <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the logs for the container of the specified code package of the service replica.

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

### -ApplicationResourceName
The identity of the application.

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

### -CodePackageName
The name of code package of the service.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.IServiceFabricMeshIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ReplicaName
Service Fabric replica name.

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

### -ResourceGroupName
Azure resource group name

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

### -ServiceResourceName
The identity of the service.

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

### -SubscriptionId
The customer subscription identifier

```yaml
Type: System.String[]
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tail
Number of lines to show from the end of the logs.
Default is 100.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

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

### System.String

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IServiceFabricMeshIdentity>`: Identity Parameter
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

