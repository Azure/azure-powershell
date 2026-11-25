---
external help file:
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/restore-azcommvaultprotectiongroup
schema: 2.0.0
---

# Restore-AzCommvaultProtectionGroup

## SYNOPSIS
Restore resource for a protected items in given protection group.

## SYNTAX

### RestoreViaIdentity (Default)
```
Restore-AzCommvaultProtectionGroup -InputObject <ICommvaultIdentity> -Request <IRestoreProtectionItemRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Restore
```
Restore-AzCommvaultProtectionGroup -CloudAccountName <String> -Name <String> -ResourceGroupName <String>
 -Request <IRestoreProtectionItemRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### RestoreExpanded
```
Restore-AzCommvaultProtectionGroup -CloudAccountName <String> -Name <String> -ResourceGroupName <String>
 -InPlaceRestore -VMDestinationInfoVminfoList <IVMInfo[]> [-SubscriptionId <String>] [-RestoreType <String>]
 [-ToTime <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentityCloudAccount
```
Restore-AzCommvaultProtectionGroup -CloudAccountInputObject <ICommvaultIdentity> -Name <String>
 -Request <IRestoreProtectionItemRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RestoreViaIdentityCloudAccountExpanded
```
Restore-AzCommvaultProtectionGroup -CloudAccountInputObject <ICommvaultIdentity> -Name <String>
 -InPlaceRestore -VMDestinationInfoVminfoList <IVMInfo[]> [-RestoreType <String>] [-ToTime <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaIdentityExpanded
```
Restore-AzCommvaultProtectionGroup -InputObject <ICommvaultIdentity> -InPlaceRestore
 -VMDestinationInfoVminfoList <IVMInfo[]> [-RestoreType <String>] [-ToTime <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### RestoreViaJsonFilePath
```
Restore-AzCommvaultProtectionGroup -CloudAccountName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### RestoreViaJsonString
```
Restore-AzCommvaultProtectionGroup -CloudAccountName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Restore resource for a protected items in given protection group.

## EXAMPLES

### Example 1: Restore a protection group in place
```powershell
Restore-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name pg-prod-vms -InPlaceRestore -VMDestinationInfoVminfoList @{ SourceVMGuid = '40000000-aaaa-4bbb-8ccc-000000000000'; StorageAccountId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-restore/providers/Microsoft.Storage/storageAccounts/strestore01'; PowerOnVMAfterRestore = $true }
```

Restores the specified virtual machine of the protection group in place and powers it on after the restore completes.

### Example 2: Restore a protection group by using a JSON file
```powershell
Restore-AzCommvaultProtectionGroup -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -Name pg-prod-vms -JsonFilePath '.\restore-request.json'
```

Restores the protection group by using the request body in the JSON file.

## PARAMETERS

### -CloudAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: RestoreViaIdentityCloudAccount, RestoreViaIdentityCloudAccountExpanded
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
Parameter Sets: Restore, RestoreExpanded, RestoreViaJsonFilePath, RestoreViaJsonString
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

### -InPlaceRestore
Check whether inplace or out of place restore.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestoreExpanded, RestoreViaIdentityCloudAccountExpanded, RestoreViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: RestoreViaIdentity, RestoreViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Restore operation

```yaml
Type: System.String
Parameter Sets: RestoreViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Restore operation

```yaml
Type: System.String
Parameter Sets: RestoreViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the ProtectionGroup resource

```yaml
Type: System.String
Parameter Sets: Restore, RestoreExpanded, RestoreViaIdentityCloudAccount, RestoreViaIdentityCloudAccountExpanded, RestoreViaJsonFilePath, RestoreViaJsonString
Aliases: ProtectionGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Request
The properties of RestoreProtectionItemRequest

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IRestoreProtectionItemRequest
Parameter Sets: Restore, RestoreViaIdentity, RestoreViaIdentityCloudAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Restore, RestoreExpanded, RestoreViaJsonFilePath, RestoreViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestoreType
Type of Restore

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityCloudAccountExpanded, RestoreViaIdentityExpanded
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
Parameter Sets: Restore, RestoreExpanded, RestoreViaJsonFilePath, RestoreViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -ToTime
Time to restore

```yaml
Type: System.String
Parameter Sets: RestoreExpanded, RestoreViaIdentityCloudAccountExpanded, RestoreViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMDestinationInfoVminfoList
List of information on VMs

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IVMInfo[]
Parameter Sets: RestoreExpanded, RestoreViaIdentityCloudAccountExpanded, RestoreViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IRestoreProtectionItemRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.IRestoreProtectionItemResponse

## NOTES

## RELATED LINKS

