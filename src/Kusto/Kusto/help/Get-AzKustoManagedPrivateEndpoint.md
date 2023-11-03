---
external help file:
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/get-azkustomanagedprivateendpoint
schema: 2.0.0
---

# Get-AzKustoManagedPrivateEndpoint

## SYNOPSIS
Gets a managed private endpoint.

## SYNTAX

### List (Default)
```
Get-AzKustoManagedPrivateEndpoint -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzKustoManagedPrivateEndpoint -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKustoManagedPrivateEndpoint -InputObject <IKustoIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a managed private endpoint.

## EXAMPLES

### Example 1: List all Kusto ManagedPrivateEndpoint in a cluster
```powershell
Get-AzKustoManagedPrivateEndpoint -ClusterName "mycluster" -ResourceGroupName "testrg"
```

```output
Name                                                       Type
----                                                       ----
ManagedPrivateEndpointName1                                Microsoft.Kusto/Clusters/ManagedPrivateEndpoints
ManagedPrivateEndpointName2                                Microsoft.Kusto/Clusters/ManagedPrivateEndpoints
```

The above command returns all Kusto ManagedPrivateEndpoint in the cluster "mycluster" found in the resource group "testrg".

### Example 2: Get a specific Kusto ManagedPrivateEndpoint by name
```powershell
Get-AzKustoManagedPrivateEndpoint -ClusterName "mycluster" -ResourceGroupName "testrg" -SubscriptionId "12345678-1234-1234-1234-123456789098" -Name "ManagedPrivateEndpointName"
```

```output
Name                                                       Type
----                                                       ----
ManagedPrivateEndpointName                                 Microsoft.Kusto/Clusters/ManagedPrivateEndpoints
```

The above command returns the Kusto ManagedPrivateEndpoint named "ManagedPrivateEndpointName" in the cluster "mycluster" found in the resource group "testrg".

## PARAMETERS

### -ClusterName
The name of the Kusto cluster.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the managed private endpoint.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ManagedPrivateEndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group containing the Kusto cluster.

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
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20221229.IManagedPrivateEndpoint

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IKustoIdentity>`: Identity Parameter
  - `[AttachedDatabaseConfigurationName <String>]`: The name of the attached database configuration.
  - `[ClusterName <String>]`: The name of the Kusto cluster.
  - `[DataConnectionName <String>]`: The name of the data connection.
  - `[DatabaseName <String>]`: The name of the database in the Kusto cluster.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: Azure location (region) name.
  - `[ManagedPrivateEndpointName <String>]`: The name of the managed private endpoint.
  - `[OperationId <String>]`: The Guid of the operation ID
  - `[PrincipalAssignmentName <String>]`: The name of the Kusto principalAssignment.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[PrivateLinkResourceName <String>]`: The name of the private link resource.
  - `[ResourceGroupName <String>]`: The name of the resource group containing the Kusto cluster.
  - `[ScriptName <String>]`: The name of the Kusto database script.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

