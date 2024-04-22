---
external help file: Az.DataProtection-help.xml
Module Name: Az.DataProtection
online version: https://learn.microsoft.com/powershell/module/az.dataprotection/set-azdataprotectionresourceguardmapping
schema: 2.0.0
---

# Set-AzDataProtectionResourceGuardMapping

## SYNOPSIS
Creates or Updates a ResourceGuardProxy

## SYNTAX

```
Set-AzDataProtectionResourceGuardMapping -ResourceGroupName <String> -VaultName <String>
 [-SubscriptionId <String>] [-ResourceGuardId <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or Updates a ResourceGuardProxy

## EXAMPLES

### Example 1: Enable MUA on backup vault (set resource guard mapping)
```powershell
$proxy = Set-AzDataProtectionResourceGuardMapping -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName -ResourceGuardId $resourceGuardARMId
$proxy | fl
```

```output
Description                  : 
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/hiagarg/providers/Microsoft.DataProtection/backupVaults/m
                               ua-pstest-backupvault/backupResourceGuardProxies/DppResourceGuardProxy
LastUpdatedTime              : 2023-08-29T07:23:05.1111730Z
Name                         : DppResourceGuardProxy
ResourceGuardId              : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/hiaga-rg/providers/Microsoft.DataProtection/resourceGuard
                               s/mua-pstest-resguard
ResourceGuardOperationDetail : {Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.ResourceGuardOperationDetail,
                               Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.ResourceGuardOperationDetail}
SystemData                   : Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api40.SystemData
Type                         : Microsoft.DataProtection/vaults/backupResourceGuardProxies
```

This command creates the mapping between resource guard and backup vault, this prevent any unauthorized access over any of the critical operations, performed on the backup vault, protected by the resource guard.
Backup Admin needs to ensure to have reader access on the resource guard to Enable MUA on the backup vault.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### -ResourceGuardId
Resource Guard ARM Id to enable MUA protection for Backup Vault.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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

### -VaultName
The name of the backup vault.

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

### Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20240401.IResourceGuardProxyBaseResource

## NOTES

## RELATED LINKS
