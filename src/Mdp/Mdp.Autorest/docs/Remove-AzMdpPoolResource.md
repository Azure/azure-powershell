---
external help file:
Module Name: Az.Mdp
online version: https://learn.microsoft.com/powershell/module/az.mdp/remove-azmdppoolresource
schema: 2.0.0
---

# Remove-AzMdpPoolResource

## SYNOPSIS
A synchronous resource action.

## SYNTAX

### DeleteExpanded (Default)
```
Remove-AzMdpPoolResource -PoolName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -ResourceId <String[]> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Delete
```
Remove-AzMdpPoolResource -PoolName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -Body <IDeleteResourcesDetails> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzMdpPoolResource -InputObject <IMdpIdentity> -Body <IDeleteResourcesDetails>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaIdentityExpanded
```
Remove-AzMdpPoolResource -InputObject <IMdpIdentity> -ResourceId <String[]> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaJsonFilePath
```
Remove-AzMdpPoolResource -PoolName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### DeleteViaJsonString
```
Remove-AzMdpPoolResource -PoolName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -JsonString <String> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
A synchronous resource action.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Body
Request body for deleting many resources by their IDs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IDeleteResourcesDetails
Parameter Sets: Delete, DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IMdpIdentity
Parameter Sets: DeleteViaIdentity, DeleteViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Delete operation

```yaml
Type: System.String
Parameter Sets: DeleteViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Delete operation

```yaml
Type: System.String
Parameter Sets: DeleteViaJsonString
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

### -PoolName
Name of the pool.
It needs to be globally unique.

```yaml
Type: System.String
Parameter Sets: Delete, DeleteExpanded, DeleteViaJsonFilePath, DeleteViaJsonString
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
Parameter Sets: Delete, DeleteExpanded, DeleteViaJsonFilePath, DeleteViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
List of resource IDs to delete.

```yaml
Type: System.String[]
Parameter Sets: DeleteExpanded, DeleteViaIdentityExpanded
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
Parameter Sets: Delete, DeleteExpanded, DeleteViaJsonFilePath, DeleteViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IDeleteResourcesDetails

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IMdpIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

