---
external help file: Az.DocumentDB-help.xml
Module Name: Az.DocumentDB
online version: https://learn.microsoft.com/powershell/module/az.documentdb/new-azdocumentdbreplica
schema: 2.0.0
---

# New-AzDocumentDBReplica

## SYNOPSIS
Create a read replica of an existing mongo cluster.

## SYNTAX

```
New-AzDocumentDBReplica -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> -SourceCluster <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a read replica of an existing mongo cluster.
The source cluster must have the
"GeoReplicas" preview feature enabled.
The replica is provisioned as a new mongo cluster
and inherits its configuration (compute, storage, sharding) from the source cluster.
A
replica in the same region as the source is created as an in-region 'AsyncReplica'; a
replica in a different region is created as a cross-region 'GeoAsyncReplica'.

## EXAMPLES

### Example 1: Create a cross-region read replica of a mongo cluster
```powershell
New-AzDocumentDBReplica -Name myReplica -ResourceGroupName myResourceGroup -Location westus2 -SourceCluster myCluster
```

```output
Name        Location ProvisioningState
----        -------- -----------------
myReplica   westus2  Succeeded
```

Create a cross-region read replica of a source mongo cluster.
The replica inherits
its configuration and administrator credentials from the source, so no password is
supplied.
A replica placed in a different region is created as a `GeoAsyncReplica`.
The source cluster must have the `GeoReplicas` preview feature enabled.

## PARAMETERS

### -AsJob
Run the command as a job.

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

### -Location
The geo-location where the replica lives.

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

### -Name
The name of the replica mongo cluster to create.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: MongoClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously.

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
The name of the resource group.
The name is case insensitive.

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

### -SourceCluster
Name or resource ID of the source (primary) mongo cluster to replicate from.
If a name is given, the current subscription and resource group are assumed.
Provide a full ARM ID for a source in another resource group or subscription.

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

### -SubscriptionId
The ID of the target subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IMongoCluster

## NOTES

## RELATED LINKS
