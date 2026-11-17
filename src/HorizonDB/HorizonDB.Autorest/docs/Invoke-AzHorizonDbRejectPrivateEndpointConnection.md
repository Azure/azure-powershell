---
external help file:
Module Name: Az.HorizonDB
online version: https://learn.microsoft.com/powershell/module/az.horizondb/invoke-azhorizondbrejectprivateendpointconnection
schema: 2.0.0
---

# Invoke-AzHorizonDbRejectPrivateEndpointConnection

## SYNOPSIS
Approves or rejects an existing private endpoint connection.
Approval requires the parent Cluster to contain at least one Pool.
An approval attempt when the Cluster has no Pools fails with 409 Conflict and the stable error code PrivateEndpointRequiresPool.
Rejection remains allowed when the Cluster has no Pools so that existing connections can be cleaned up.

## SYNTAX

### RejectExpanded (Default)
```
Invoke-AzHorizonDbRejectPrivateEndpointConnection -ClusterName <String>
 -PrivateEndpointConnectionName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-PrivateLinkServiceConnectionStateActionsRequired <String>]
 [-PrivateLinkServiceConnectionStateDescription <String>] [-PrivateLinkServiceConnectionStateStatus <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Reject
```
Invoke-AzHorizonDbRejectPrivateEndpointConnection -ClusterName <String>
 -PrivateEndpointConnectionName <String> -ResourceGroupName <String> -Resource <IPrivateEndpointConnection>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RejectViaIdentity
```
Invoke-AzHorizonDbRejectPrivateEndpointConnection -InputObject <IHorizonDbIdentity>
 -Resource <IPrivateEndpointConnection> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RejectViaIdentityCluster
```
Invoke-AzHorizonDbRejectPrivateEndpointConnection -ClusterInputObject <IHorizonDbIdentity>
 -PrivateEndpointConnectionName <String> -Resource <IPrivateEndpointConnection> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RejectViaIdentityClusterExpanded
```
Invoke-AzHorizonDbRejectPrivateEndpointConnection -ClusterInputObject <IHorizonDbIdentity>
 -PrivateEndpointConnectionName <String> [-PrivateLinkServiceConnectionStateActionsRequired <String>]
 [-PrivateLinkServiceConnectionStateDescription <String>] [-PrivateLinkServiceConnectionStateStatus <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RejectViaIdentityExpanded
```
Invoke-AzHorizonDbRejectPrivateEndpointConnection -InputObject <IHorizonDbIdentity>
 [-PrivateLinkServiceConnectionStateActionsRequired <String>]
 [-PrivateLinkServiceConnectionStateDescription <String>] [-PrivateLinkServiceConnectionStateStatus <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RejectViaJsonFilePath
```
Invoke-AzHorizonDbRejectPrivateEndpointConnection -ClusterName <String>
 -PrivateEndpointConnectionName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RejectViaJsonString
```
Invoke-AzHorizonDbRejectPrivateEndpointConnection -ClusterName <String>
 -PrivateEndpointConnectionName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Approves or rejects an existing private endpoint connection.
Approval requires the parent Cluster to contain at least one Pool.
An approval attempt when the Cluster has no Pools fails with 409 Conflict and the stable error code PrivateEndpointRequiresPool.
Rejection remains allowed when the Cluster has no Pools so that existing connections can be cleaned up.

## EXAMPLES

### Example 1: Approve a private endpoint connection
```powershell
Invoke-AzHorizonDbRejectPrivateEndpointConnection -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PrivateEndpointConnectionName 'example-private-endpoint-connection' -PrivateLinkServiceConnectionStateStatus 'Approved' -PrivateLinkServiceConnectionStateDescription 'Approved for the production database network' | Format-List -Property Name, PrivateLinkServiceConnectionStateStatus, PrivateLinkServiceConnectionStateDescription, ProvisioningState
```

```output
Name                                         : example-private-endpoint-connection
PrivateLinkServiceConnectionStateStatus      : Approved
PrivateLinkServiceConnectionStateDescription : Approved for the production database network
ProvisioningState                            : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Reject a private endpoint connection
```powershell
Invoke-AzHorizonDbRejectPrivateEndpointConnection -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -PrivateEndpointConnectionName 'example-private-endpoint-connection' -PrivateLinkServiceConnectionStateStatus 'Rejected' -PrivateLinkServiceConnectionStateDescription 'Connection is not authorized'
```

Rejects the specified private endpoint connection.

The supplied REST example includes an approval response only, so no rejection output is shown.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -ClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: RejectViaIdentityCluster, RejectViaIdentityClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the HorizonDB cluster.

```yaml
Type: System.String
Parameter Sets: Reject, RejectExpanded, RejectViaJsonFilePath, RejectViaJsonString
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity
Parameter Sets: RejectViaIdentity, RejectViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Reject operation

```yaml
Type: System.String
Parameter Sets: RejectViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Reject operation

```yaml
Type: System.String
Parameter Sets: RejectViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PrivateEndpointConnectionName
The name of the private endpoint connection associated with the Azure resource.

```yaml
Type: System.String
Parameter Sets: Reject, RejectExpanded, RejectViaIdentityCluster, RejectViaIdentityClusterExpanded, RejectViaJsonFilePath, RejectViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkServiceConnectionStateActionsRequired
A message indicating if changes on the service provider require any updates on the consumer.

```yaml
Type: System.String
Parameter Sets: RejectExpanded, RejectViaIdentityClusterExpanded, RejectViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkServiceConnectionStateDescription
The reason for approval/rejection of the connection.

```yaml
Type: System.String
Parameter Sets: RejectExpanded, RejectViaIdentityClusterExpanded, RejectViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkServiceConnectionStateStatus
Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service.

```yaml
Type: System.String
Parameter Sets: RejectExpanded, RejectViaIdentityClusterExpanded, RejectViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
The private endpoint connection resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IPrivateEndpointConnection
Parameter Sets: Reject, RejectViaIdentity, RejectViaIdentityCluster
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
Parameter Sets: Reject, RejectExpanded, RejectViaJsonFilePath, RejectViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Reject, RejectExpanded, RejectViaJsonFilePath, RejectViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IHorizonDbIdentity

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IPrivateEndpointConnection

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HorizonDB.Models.IPrivateEndpointConnection

## NOTES

## RELATED LINKS

