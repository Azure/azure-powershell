---
external help file: Az.ServiceGroups-help.xml
Module Name: Az.ServiceGroups
online version: https://learn.microsoft.com/powershell/module/az.servicegroups/get-azservicegroupancestor
schema: 2.0.0
---

# Get-AzServiceGroupAncestor

## SYNOPSIS
Get the details of the serviceGroup's ancestors

## SYNTAX

```
Get-AzServiceGroupAncestor -ServiceGroupName <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Get the details of the serviceGroup's ancestors

## EXAMPLES

### Example 1: List all ancestors of a service group
```powershell
Get-AzServiceGroupAncestor -ServiceGroupName "ContosoChild"
```

```output
DisplayName   : Contoso Group
Id            : /providers/Microsoft.Management/serviceGroups/Contoso
Name          : Contoso

DisplayName   : Root Service Group
Id            : /providers/Microsoft.Management/serviceGroups/00000000-0000-0000-0000-000000000000
Name          : 00000000-0000-0000-0000-000000000000
```

Returns all ancestor service groups in the hierarchy for 'ContosoChild', from its immediate parent up to the root service group.
The root service group ID is always the tenant ID.

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

### -ServiceGroupName
ServiceGroup Name.

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceGroups.Models.IServiceGroupCollectionResponse

## NOTES

## RELATED LINKS
