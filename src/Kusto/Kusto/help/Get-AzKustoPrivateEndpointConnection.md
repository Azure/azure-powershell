---
external help file: Az.Kusto-help.xml
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/get-azkustoprivateendpointconnection
schema: 2.0.0
---

# Get-AzKustoPrivateEndpointConnection

## SYNOPSIS
Gets a private endpoint connection.

## SYNTAX

### List (Default)
```
Get-AzKustoPrivateEndpointConnection -ClusterName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzKustoPrivateEndpointConnection -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKustoPrivateEndpointConnection -InputObject <IKustoIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a private endpoint connection.

## EXAMPLES

### Example 1: List all Kusto PrivateEndpointConnection in a cluster by name
```powershell
Get-AzKustoPrivateEndpointConnection -ClusterName "mycluster" -ResourceGroupName "testrg" -SubscriptionId "12345678-1234-1234-1234-123456789098"
```

```output
Name                                                       Type
----                                                       ----
privateEndpointConnectionName1                             Microsoft.Kusto/Clusters/PrivateEndpointConnections
privateEndpointConnectionName2                             Microsoft.Kusto/Clusters/PrivateEndpointConnections
```

The above command returns all Kusto PrivateEndpointConnection in the cluster "mycluster" found in the resource group "testrg".

### Example 2: Get a specific Kusto PrivateEndpointConnection by name
```powershell
Get-AzKustoPrivateEndpointConnection -ClusterName "mycluster" -ResourceGroupName "testrg" -SubscriptionId "12345678-1234-1234-1234-123456789098" -Name "privateEndpointConnectionName"
```

```output
Name                                                       Type
----                                                       ----
privateEndpointConnectionName                              Microsoft.Kusto/Clusters/PrivateEndpointConnections
```

The above command returns the Kusto PrivateEndpointConnection named "privateEndpointConnectionName" in the cluster "mycluster" found in the resource group "testrg".

## PARAMETERS

### -ClusterName
The name of the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: List, Get
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
The name of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PrivateEndpointConnectionName

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20230815.IPrivateEndpointConnection

## NOTES

## RELATED LINKS
