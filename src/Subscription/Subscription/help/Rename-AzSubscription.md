---
external help file: Az.Subscription-help.xml
Module Name: Az.Subscription
online version: https://learn.microsoft.com/powershell/module/az.subscription/rename-azsubscription
schema: 2.0.0
---

# Rename-AzSubscription

## SYNOPSIS
The operation to rename a subscription

## SYNTAX

### RenameExpanded (Default)
```
Rename-AzSubscription -Id <String> -SubscriptionName <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RenameViaIdentityExpanded
```
Rename-AzSubscription -InputObject <ISubscriptionIdentity> -SubscriptionName <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The operation to rename a subscription

## EXAMPLES

### Example 1: The operation to rename a subscription.
```powershell
Rename-AzSubscription -Id XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX -SubscriptionName test-subscription
```

```output
XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX
```

The operation to rename a subscription.

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

### -Id
Subscription Id.

```yaml
Type: System.String
Parameter Sets: RenameExpanded
Aliases: SubscriptionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.ISubscriptionIdentity
Parameter Sets: RenameViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionName
New subscription name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DisplayName

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

### Microsoft.Azure.PowerShell.Cmdlets.Subscription.Models.ISubscriptionIdentity

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
