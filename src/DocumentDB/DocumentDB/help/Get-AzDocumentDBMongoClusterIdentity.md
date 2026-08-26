---
external help file: Az.DocumentDB-help.xml
Module Name: Az.DocumentDB
online version: https://learn.microsoft.com/powershell/module/az.documentdb/get-azdocumentdbmongoclusteridentity
schema: 2.0.0
---

# Get-AzDocumentDBMongoClusterIdentity

## SYNOPSIS
Get the managed identities assigned to a mongo cluster.

## SYNTAX

```
Get-AzDocumentDBMongoClusterIdentity -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the managed identity configuration of a mongo cluster, including the identity type
and the set of user-assigned managed identities currently assigned to it.

## EXAMPLES

### Example 1: Get the managed identities assigned to a mongo cluster
```powershell
Get-AzDocumentDBMongoClusterIdentity -Name myCluster -ResourceGroupName myResourceGroup
```

```output
Type         PrincipalId TenantId
----         ----------- --------
UserAssigned
```

Get the managed identity configuration of a mongo cluster, including the identity type
and the set of user-assigned managed identities currently assigned to it.

## PARAMETERS

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

### -Name
The name of the mongo cluster.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ClusterName, MongoClusterName

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS
