---
external help file:
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/get-azkustoprivatelinkresource
schema: 2.0.0
---

# Get-AzKustoPrivateLinkResource

## SYNOPSIS
Gets a private link resource.

## SYNTAX

### List (Default)
```
Get-AzKustoPrivateLinkResource -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzKustoPrivateLinkResource -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzKustoPrivateLinkResource -InputObject <IKustoIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a private link resource.

## EXAMPLES

### Example 1: List all PrivateLinkResource in a cluster
```powershell
Get-AzKustoPrivateLinkResource -ClusterName "mycluster" -ResourceGroupName "testrg"
```

```output
Name                                                       Type
----                                                       ----
mycluster/cluster                                		   Microsoft.Kusto/Clusters/PrivateLinkResources
```

The above command returns all PrivateLinkResource in the cluster "mycluster" found in the resource group "testrg".

### Example 2: Get a specific PrivateLinkResource by name
```powershell
Get-AzKustoPrivateLinkResource -ClusterName "mycluster" -ResourceGroupName "testrg" -Name "ManagedPrivateEndpointName"
```

```output
Name                                                       Type
----                                                       ----
mycluster/cluster                                		   Microsoft.Kusto/Clusters/PrivateLinkResources
```

The above command returns the PrivateLinkResource named "mycluster/cluster" in the cluster "mycluster" found in the resource group "testrg".

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
The name of the private link resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PrivateLinkResourceName

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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.Api20240413.IPrivateLinkResource

## NOTES

## RELATED LINKS

