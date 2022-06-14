---
external help file:
Module Name: Az.ServiceFabricMesh
online version: https://docs.microsoft.com/en-us/powershell/module/az.servicefabricmesh/get-azservicefabricmeshservice
schema: 2.0.0
---

# Get-AzServiceFabricMeshService

## SYNOPSIS
Gets the information about the service resource with the given name.
The information include the description and other properties of the service.

## SYNTAX

### List (Default)
```
Get-AzServiceFabricMeshService -ApplicationResourceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzServiceFabricMeshService -ApplicationResourceName <String> -ResourceGroupName <String>
 -ResourceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzServiceFabricMeshService -InputObject <IServiceFabricMeshIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the information about the service resource with the given name.
The information include the description and other properties of the service.

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
Parameter Sets: Get, List
Aliases:

Required: True
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.IServiceFabricMeshIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Azure resource group name

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

### -ResourceName
The identity of the service.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ServiceResourceName

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.IServiceFabricMeshIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.Api20180901Preview.IServiceResourceDescription

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

