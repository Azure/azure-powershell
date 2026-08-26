---
external help file: Az.DocumentDB-help.xml
Module Name: Az.DocumentDB
online version: https://learn.microsoft.com/powershell/module/az.documentdb/remove-azdocumentdbmongoclusteridentity
schema: 2.0.0
---

# Remove-AzDocumentDBMongoClusterIdentity

## SYNOPSIS
Remove user-assigned managed identities from a mongo cluster.

## SYNTAX

```
Remove-AzDocumentDBMongoClusterIdentity -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -UserAssignedIdentity <String[]> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Remove one or more user-assigned managed identities from a mongo cluster.
Only the
supplied identities are removed; any other identities already assigned to the cluster
are preserved.
Only user-assigned managed identities are supported.

## EXAMPLES

### Example 1: Remove a user-assigned managed identity from a mongo cluster
```powershell
$identityId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myIdentity'
Remove-AzDocumentDBMongoClusterIdentity -Name myCluster -ResourceGroupName myResourceGroup -UserAssignedIdentity $identityId
```

```output
Type PrincipalId TenantId
---- ----------- --------
None
```

Remove a user-assigned managed identity from a mongo cluster.
Only the supplied
identity is removed; any other identities already assigned to the cluster are
preserved.
The `-UserAssigned` alias can be used in place of `-UserAssignedIdentity`.

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

### -UserAssignedIdentity
Resource ID(s) of the user-assigned managed identities to remove from the mongo cluster.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases: UserAssigned, MiUserAssigned

Required: True
Position: Named
Default value: None
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

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS
