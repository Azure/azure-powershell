---
external help file: Az.Commvault-help.xml
Module Name: Az.Commvault
online version: https://learn.microsoft.com/powershell/module/az.commvault/restore-azcommvaultprotecteditem
schema: 2.0.0
---

# Restore-AzCommvaultProtectedItem

## SYNOPSIS
Restore resource for a protected item.

## SYNTAX

### RestoreViaIdentity (Default)
```
Restore-AzCommvaultProtectedItem -InputObject <ICommvaultIdentity> -Request <IRestoreProtectionItemRequest>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreViaJsonString
```
Restore-AzCommvaultProtectedItem -CloudAccountName <String> -Name <String> -ProtectionGroupName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreViaJsonFilePath
```
Restore-AzCommvaultProtectedItem -CloudAccountName <String> -Name <String> -ProtectionGroupName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreExpanded
```
Restore-AzCommvaultProtectedItem -CloudAccountName <String> -Name <String> -ProtectionGroupName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-InPlaceRestore]
 -VMDestinationInfoVminfoList <IVMInfo[]> [-RestoreType <String>] [-ToTime <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Restore
```
Restore-AzCommvaultProtectedItem -CloudAccountName <String> -Name <String> -ProtectionGroupName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -Request <IRestoreProtectionItemRequest>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreViaIdentityProtectionGroupExpanded
```
Restore-AzCommvaultProtectedItem -Name <String> -ProtectionGroupInputObject <ICommvaultIdentity>
 [-InPlaceRestore] -VMDestinationInfoVminfoList <IVMInfo[]> [-RestoreType <String>] [-ToTime <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreViaIdentityProtectionGroup
```
Restore-AzCommvaultProtectedItem -Name <String> -ProtectionGroupInputObject <ICommvaultIdentity>
 -Request <IRestoreProtectionItemRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreViaIdentityCloudAccountExpanded
```
Restore-AzCommvaultProtectedItem -Name <String> -ProtectionGroupName <String>
 -CloudAccountInputObject <ICommvaultIdentity> [-InPlaceRestore] -VMDestinationInfoVminfoList <IVMInfo[]>
 [-RestoreType <String>] [-ToTime <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreViaIdentityCloudAccount
```
Restore-AzCommvaultProtectedItem -Name <String> -ProtectionGroupName <String>
 -CloudAccountInputObject <ICommvaultIdentity> -Request <IRestoreProtectionItemRequest>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RestoreViaIdentityExpanded
```
Restore-AzCommvaultProtectedItem -InputObject <ICommvaultIdentity> [-InPlaceRestore]
 -VMDestinationInfoVminfoList <IVMInfo[]> [-RestoreType <String>] [-ToTime <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Restore resource for a protected item.

## EXAMPLES

### Example 1: Restore a protected item in place
```powershell
Restore-AzCommvaultProtectedItem -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -Name vm-app01 -InPlaceRestore -VMDestinationInfoVminfoList @{ SourceVMGuid = '40000000-aaaa-4bbb-8ccc-000000000000'; StorageAccountId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-restore/providers/Microsoft.Storage/storageAccounts/strestore01'; PowerOnVMAfterRestore = $true }
```

Restores the virtual machine in place and powers it on after the restore completes.

### Example 2: Restore a protected item as a new virtual machine by using a JSON request
```powershell
Restore-AzCommvaultProtectedItem -ResourceGroupName rg-commvault -CloudAccountName cca-contoso -ProtectionGroupName pg-prod-vms -Name vm-app01 -JsonString '{"inPlaceRestore":false,"restoreType":"VIRTUAL_MACHINE","vmDestinationInfo":{"vmInfoList":[{"sourceVmGuid":"40000000-aaaa-4bbb-8ccc-000000000000","name":"vm-app01-restored","resourceGroup":"rg-restore","region":"eastus","storageAccountId":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-restore/providers/Microsoft.Storage/storageAccounts/strestore01","networkId":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-restore/providers/Microsoft.Network/virtualNetworks/vnet-restore","subnetId":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg-restore/providers/Microsoft.Network/virtualNetworks/vnet-restore/subnets/default","powerOnVmAfterRestore":true}]}}'
```

Restores the virtual machine as a new virtual machine in another resource group and region by passing the request body as a JSON string.

## PARAMETERS

### -CloudAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: RestoreViaIdentityCloudAccountExpanded, RestoreViaIdentityCloudAccount
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
Parameter Sets: RestoreViaJsonString, RestoreViaJsonFilePath, RestoreExpanded, Restore
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
Parameter Sets: RestoreExpanded, RestoreViaIdentityProtectionGroupExpanded, RestoreViaIdentityCloudAccountExpanded, RestoreViaIdentityExpanded
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
The protectedItem Id, name of 2 protected items can be same under a PG if they belong to different resource group or even different data source types VM/DB/AKS, etc; and name is mandatory in Azure Typespec, hence using name parameter for id in Commvault In case of Vm it will be vmGuid

```yaml
Type: System.String
Parameter Sets: RestoreViaJsonString, RestoreViaJsonFilePath, RestoreExpanded, Restore, RestoreViaIdentityProtectionGroupExpanded, RestoreViaIdentityProtectionGroup, RestoreViaIdentityCloudAccountExpanded, RestoreViaIdentityCloudAccount
Aliases: ProtectedItemName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProtectionGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Commvault.Models.ICommvaultIdentity
Parameter Sets: RestoreViaIdentityProtectionGroupExpanded, RestoreViaIdentityProtectionGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProtectionGroupName
Name of the ProtectionGroup resource

```yaml
Type: System.String
Parameter Sets: RestoreViaJsonString, RestoreViaJsonFilePath, RestoreExpanded, Restore, RestoreViaIdentityCloudAccountExpanded, RestoreViaIdentityCloudAccount
Aliases:

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
Parameter Sets: RestoreViaIdentity, Restore, RestoreViaIdentityProtectionGroup, RestoreViaIdentityCloudAccount
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
Parameter Sets: RestoreViaJsonString, RestoreViaJsonFilePath, RestoreExpanded, Restore
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
Parameter Sets: RestoreExpanded, RestoreViaIdentityProtectionGroupExpanded, RestoreViaIdentityCloudAccountExpanded, RestoreViaIdentityExpanded
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
Parameter Sets: RestoreViaJsonString, RestoreViaJsonFilePath, RestoreExpanded, Restore
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
Parameter Sets: RestoreExpanded, RestoreViaIdentityProtectionGroupExpanded, RestoreViaIdentityCloudAccountExpanded, RestoreViaIdentityExpanded
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
Parameter Sets: RestoreExpanded, RestoreViaIdentityProtectionGroupExpanded, RestoreViaIdentityCloudAccountExpanded, RestoreViaIdentityExpanded
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
