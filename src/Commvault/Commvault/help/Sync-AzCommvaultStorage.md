---
external help file: Az.Commvault-help.xml
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/sync-azcommvaultstorage
schema: 2.0.0
---

# Sync-AzCommvaultStorage

## SYNOPSIS
Refresh storage state from partner.
Fetches latest compliance lock status from Commvault and refresh the ARM resource.

## SYNTAX

### Refresh (Default)
```
Sync-AzCommvaultStorage -CloudAccountName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### RefreshViaIdentityCloudAccount
```
Sync-AzCommvaultStorage -Name <String> -CloudAccountInputObject <ICommvaultIdentity>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RefreshViaIdentity
```
Sync-AzCommvaultStorage -InputObject <ICommvaultIdentity> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Refresh storage state from partner.
Fetches latest compliance lock status from Commvault and refresh the ARM resource.

## EXAMPLES

### Example 1: Refresh a storage
```powershell
Sync-AzCommvaultStorage -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name storage-hot
```

Refreshes the storage so that its properties, such as the compliance lock status, match the current state on the partner side.

## PARAMETERS

### -CloudAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: RefreshViaIdentityCloudAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CloudAccountName
Name of the Cloud Account resource

```yaml
Type: System.String
Parameter Sets: Refresh
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: RefreshViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Storage resource

```yaml
Type: System.String
Parameter Sets: Refresh, RefreshViaIdentityCloudAccount
Aliases: StorageName

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
Parameter Sets: Refresh
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
Parameter Sets: Refresh
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

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IStorage

## NOTES

## RELATED LINKS
