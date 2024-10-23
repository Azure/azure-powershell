---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/update-azsecuritydefenderforstorage
schema: 2.0.0
---

# Update-AzSecurityDefenderForStorage

## SYNOPSIS
Update the Defender for Storage settings on a specified storage account.

## SYNTAX

```
Update-AzSecurityDefenderForStorage -ResourceId <String> [-IsEnabled]
 [-MalwareScanningScanResultsEventGridTopicResourceId <String>] [-OnUploadCapGbPerMonth <Int32>]
 [-OnUploadIsEnabled] [-OverrideSubscriptionLevelSetting] [-SensitiveDataDiscoveryIsEnabled]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the Defender for Storage settings on a specified storage account.

## EXAMPLES

### Example 1: Enable Defender for Storage V2 and Scanning Services
```powershell
Update-AzSecurityDefenderForStorage -ResourceId "/subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>" -IsEnabled -OnUploadIsEnabled -OnUploadCapGbPerMonth 7000 -SensitiveDataDiscoveryIsEnabled
```

```output
Id                                                 : /subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>
IsEnabled                                          : True
MalwareScanningOperationStatusCode                 : Succeeded
MalwareScanningOperationStatusMessage              :
MalwareScanningScanResultsEventGridTopicResourceId :
Name                                               : current
OnUploadCapGbPerMonth                              : 7000
OnUploadIsEnabled                                  : True
OverrideSubscriptionLevelSetting                   : False
ResourceGroupName                                  : <ResourceGroupName>
SensitiveDataDiscoveryIsEnabled                    : True
SensitiveDataDiscoveryOperationStatusCode          : Succeeded
SensitiveDataDiscoveryOperationStatusMessage       :
Type                                               : Microsoft.Security/defenderForStorageSettings
```



### Example 2: Disable Defender for Storage V2 when Scanning Services are enabled
```powershell
Update-AzSecurityDefenderForStorage -ResourceId "/subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>" -IsEnabled:$false -OnUploadIsEnabled:$false -SensitiveDataDiscoveryIsEnabled:$false
```

```output
Id                                                 : /subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>
IsEnabled                                          : False
MalwareScanningOperationStatusCode                 : Succeeded
MalwareScanningOperationStatusMessage              :
MalwareScanningScanResultsEventGridTopicResourceId :
Name                                               : current
OnUploadCapGbPerMonth                              : -1
OnUploadIsEnabled                                  : False
OverrideSubscriptionLevelSetting                   : False
ResourceGroupName                                  : <ResourceGroupName>
SensitiveDataDiscoveryIsEnabled                    : False
SensitiveDataDiscoveryOperationStatusCode          : Succeeded
SensitiveDataDiscoveryOperationStatusMessage       :
Type                                               : Microsoft.Security/defenderForStorageSettings
```

Note that when Scanning Services are enabled, disabling them explicitly is required in order to disable Defender for Storage V2 (-IsEnabled:$false is not enough).

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

### -IsEnabled
Indicates whether Defender for Storage is enabled on this storage account.

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

### -MalwareScanningScanResultsEventGridTopicResourceId
Optional.
Resource id of an Event Grid Topic to send scan results to.

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

### -OnUploadCapGbPerMonth
Defines the max GB to be scanned per Month.
Set to -1 if no capping is needed.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OnUploadIsEnabled
Indicates whether On Upload malware scanning should be enabled.

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

### -OverrideSubscriptionLevelSetting
Indicates whether the settings defined for this storage account should override the settings defined for the subscription.

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

### -ResourceId
The identifier of the resource.

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

### -SensitiveDataDiscoveryIsEnabled
Indicates whether Sensitive Data Discovery should be enabled.

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

### Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSetting

## NOTES

## RELATED LINKS

