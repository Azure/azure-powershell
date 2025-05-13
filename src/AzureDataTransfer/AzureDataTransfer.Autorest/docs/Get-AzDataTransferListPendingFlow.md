---
external help file:
Module Name: Az.DataTransfer
online version: https://learn.microsoft.com/powershell/module/az.datatransfer/get-azdatatransferlistpendingflow
schema: 2.0.0
---

# Get-AzDataTransferListPendingFlow

## SYNOPSIS
Lists all pending flows for a connection.

## SYNTAX

```
Get-AzDataTransferListPendingFlow -ConnectionName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Lists all pending flows for a connection.

## EXAMPLES

### Example 1: List all pending flows for a specific connection
```powershell
$pendingFlows = Get-AzDataTransferListPendingFlow -ResourceGroupName ResourceGroup01 -ConnectionName Connection01
```

```output
Id                : pending-flow-id-123
ConnectionName    : Connection01
ResourceGroupName : ResourceGroup01
Status            : Pending
Requestor         : user@example.com

Id                : pending-flow-id-456
ConnectionName    : Connection01
ResourceGroupName : ResourceGroup01
Status            : Pending
Requestor         : admin@example.com
```

This example lists all pending flows for the connection `Connection01` within the resource group `ResourceGroup01`.

---

## PARAMETERS

### -ConnectionName
The name for the connection that is to be requested.

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
The value must be an UUID.

```yaml
Type: System.String[]
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

### PrivateADT.Models.IPendingFlow

## NOTES

## RELATED LINKS

