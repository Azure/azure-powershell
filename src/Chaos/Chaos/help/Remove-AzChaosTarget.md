---
external help file: Az.Chaos-help.xml
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/az.chaos/remove-azchaostarget
schema: 2.0.0
---

# Remove-AzChaosTarget

## SYNOPSIS
Delete a Target resource that extends a tracked regional resource.

## SYNTAX

### Delete (Default)
```
Remove-AzChaosTarget -Name <String> -ParentProviderNamespace <String> -ParentResourceName <String>
 -ParentResourceType <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzChaosTarget -InputObject <IChaosIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Delete a Target resource that extends a tracked regional resource.

## EXAMPLES

### Example 1: Delete a Target resource that extends a tracked regional resource.
```powershell
Remove-AzChaosTarget -Name microsoft-virtualmachine -ParentProviderNamespace Microsoft.Compute -ParentResourceName exampleVM -ParentResourceType virtualMachines -ResourceGroupName azps_test_group_chaos
```

Delete a Target resource that extends a tracked regional resource.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
String that represents a Target resource name.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases: TargetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentProviderNamespace
String that represents a resource provider namespace.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentResourceName
String that represents a resource name.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentResourceType
String that represents a resource type.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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
String that represents an Azure resource group.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
GUID that represents an Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: Delete
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IChaosIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
