---
external help file:
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/update-azdataprotectionresourceguard
schema: 2.0.0
---

# Update-AzDataProtectionResourceGuard

## SYNOPSIS
Updates a resource guard belonging to a resource group

## SYNTAX

```
Update-AzDataProtectionResourceGuard -Name <String> -ResourceGroupName <String>
 [-CriticalOperationExclusionList <String[]>] [-DefaultProfile <PSObject>] [-ETag <String>]
 [-IdentityType <String>] [-SubscriptionId <String>] [-Tag <Hashtable>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates a resource guard belonging to a resource group

## EXAMPLES

### Example 1: Update a resource guard
```powershell
$resourceGuard = Get-AzDataProtectionResourceGuard -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "rgName" -Name "resGuardName"
$criticalOperations = $resourceGuard.ResourceGuardOperation.VaultCriticalOperation
$operationsToBeExcluded = $criticalOperations | Where-Object { $_ -match "backupSecurityPIN/action" -or $_ -match "backupInstances/delete" }
Update-AzDataProtectionResourceGuard -SubscriptionId "xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx" -ResourceGroupName "rgName" -Name $resourceGuard.Name -CriticalOperationExclusionList $operationsToBeExcluded
```

```output
ETag Id                                                                                                                                                       IdentityPrincipalId IdentityTenantId IdentityType Location      Name
---- --                                                                                                                                                       ------------------- ---------------- ------------ --------      ----
     /subscriptions/xxxxxxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/mua-rg/providers/Microsoft.DataProtection/resourceGuards/mua-resource-guard                                                   centraluseuap mua-resource-guard
```

The first command is used to fetch the resource guard to be updated.
The second and third command is used to fecth the critical operations user want to update.

The fourth command is used to exclude some critical operations from the resource guard

## PARAMETERS

### -CriticalOperationExclusionList
List of critical operations which are not protected by this resourceGuard.
Supported values are DeleteProtection, UpdateProtection, UpdatePolicy, GetSecurityPin

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile


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

### -ETag
Optional ETag

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identityType to be updated in resource guard, example: SystemAssigned, None

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the resource guard

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

### -ResourceGroupName
Resource Group name of the resource guard

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
Subscription Id of the resource guard

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202301.IResourceGuardResource

## NOTES

ALIASES

## RELATED LINKS

