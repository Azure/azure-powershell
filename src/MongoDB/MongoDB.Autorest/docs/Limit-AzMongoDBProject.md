---
external help file:
Module Name: Az.MongoDB
online version: https://learn.microsoft.com/powershell/module/az.mongodb/limit-azmongodbproject
schema: 2.0.0
---

# Limit-AzMongoDBProject

## SYNOPSIS
Check if tier limit is reached for the project.

## SYNTAX

### Limit (Default)
```
Limit-AzMongoDBProject -Name <String> -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### LimitViaIdentity
```
Limit-AzMongoDBProject -InputObject <IMongoDbIdentity> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### LimitViaIdentityOrganization
```
Limit-AzMongoDBProject -Name <String> -OrganizationInputObject <IMongoDbIdentity> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Check if tier limit is reached for the project.

## EXAMPLES

### Example 1: Check whether the cluster-tier limit has been reached
```powershell
Limit-AzMongoDBProject -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -ProjectName test-project-1 | Format-List
```

```output
Current   : 0
IsReached : False
Maximum   : 1
Type      : FREE
```

Queries the partner to find out, per cluster tier, how many clusters the project currently has, the per-tier maximum, and whether the limit has been reached.
Useful as a pre-flight check before `New-AzMongoDBCluster`.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity
Parameter Sets: LimitViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the MongoDB Atlas Project resource.

```yaml
Type: System.String
Parameter Sets: Limit, LimitViaIdentityOrganization
Aliases: ProjectName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity
Parameter Sets: LimitViaIdentityOrganization
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationName
Name of the Organization resource

```yaml
Type: System.String
Parameter Sets: Limit
Aliases:

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
Parameter Sets: Limit
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
Parameter Sets: Limit
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

### Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.ITierLimitReachedResponse

## NOTES

## RELATED LINKS

