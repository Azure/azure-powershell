---
external help file: Az.Kusto-help.xml
Module Name: Az.Kusto
online version: https://learn.microsoft.com/powershell/module/az.kusto/update-azkustomanagedprivateendpoint
schema: 2.0.0
---

# Update-AzKustoManagedPrivateEndpoint

## SYNOPSIS
Update a managed private endpoint.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzKustoManagedPrivateEndpoint -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-GroupId <String>] [-PrivateLinkResourceId <String>]
 [-PrivateLinkResourceRegion <String>] [-RequestMessage <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzKustoManagedPrivateEndpoint -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzKustoManagedPrivateEndpoint -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Update-AzKustoManagedPrivateEndpoint -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Parameter <IManagedPrivateEndpoint> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityClusterExpanded
```
Update-AzKustoManagedPrivateEndpoint -Name <String> -ClusterInputObject <IKustoIdentity> [-GroupId <String>]
 [-PrivateLinkResourceId <String>] [-PrivateLinkResourceRegion <String>] [-RequestMessage <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityCluster
```
Update-AzKustoManagedPrivateEndpoint -Name <String> -ClusterInputObject <IKustoIdentity>
 -Parameter <IManagedPrivateEndpoint> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzKustoManagedPrivateEndpoint -InputObject <IKustoIdentity> [-GroupId <String>]
 [-PrivateLinkResourceId <String>] [-PrivateLinkResourceRegion <String>] [-RequestMessage <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzKustoManagedPrivateEndpoint -InputObject <IKustoIdentity> -Parameter <IManagedPrivateEndpoint>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a managed private endpoint.

## EXAMPLES

### Example 1: Update an existing ManagedPrivateEndpoint
```powershell
Update-AzKustoManagedPrivateEndpoint -ResourceGroupName "testrg" -ClusterName "mycluster" -Name "ManagedPrivateEndpointName" -RequestMessage "Please Approve Managed Private Endpoint Request." -GroupId "blob" -PrivateLinkResourceId "/subscriptions/12345678-1234-1234-1234-123456789098/resourceGroups/testrg/providers/Microsoft.Storage/storageAccounts/storageAccountTest"
```

```output
Name                                                       Type
----                                                       ----
ManagedPrivateEndpointName                                 Microsoft.Kusto/Clusters/ManagedPrivateEndpoints
```

The above command updates the existing ManagedPrivateEndpoint named "ManagedPrivateEndpointName" in the cluster "mycluster".

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: UpdateViaIdentityClusterExpanded, UpdateViaIdentityCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ClusterName
The name of the Kusto cluster.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, Update
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

### -GroupId
The groupId in which the managed private endpoint is created.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the managed private endpoint.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, Update, UpdateViaIdentityClusterExpanded, UpdateViaIdentityCluster
Aliases: ManagedPrivateEndpointName

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

### -Parameter
Class representing a managed private endpoint.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IManagedPrivateEndpoint
Parameter Sets: Update, UpdateViaIdentityCluster, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateLinkResourceId
The ARM resource ID of the resource for which the managed private endpoint is created.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkResourceRegion
The region of the resource to which the managed private endpoint is created.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestMessage
The user request message.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityClusterExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, Update
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, Update
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

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IKustoIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IManagedPrivateEndpoint

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Kusto.Models.IManagedPrivateEndpoint

## NOTES

## RELATED LINKS
