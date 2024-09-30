---
external help file:
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/get-azsecuritydefenderforstorage
schema: 2.0.0
---

# Get-AzSecurityDefenderForStorage

## SYNOPSIS
Gets the Defender for Storage settings for the specified storage account.

## SYNTAX

```
Get-AzSecurityDefenderForStorage -ResourceId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the Defender for Storage settings for the specified storage account.

## EXAMPLES

### Example 1: Get Defender for Storage V2 settings on a storage account
```powershell
Get-AzSecurityDefenderForStorage -ResourceId "/subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>"
```

```output
Id                                                 : /subscriptions/<SubscriptionId>/resourcegroups/<ResourceGroupName>/providers/Microsoft.Storage/storageAccounts/<StorageAccountName>
IsEnabled                                          : True
MalwareScanningOperationStatusCode                 :
MalwareScanningOperationStatusMessage              :
MalwareScanningScanResultsEventGridTopicResourceId :
Name                                               : current
OnUploadCapGbPerMonth                              : 5000
OnUploadIsEnabled                                  : True
OverrideSubscriptionLevelSetting                   : False
ResourceGroupName                                  : <ResourceGroupName>
SensitiveDataDiscoveryIsEnabled                    : True
SensitiveDataDiscoveryOperationStatusCode          :
SensitiveDataDiscoveryOperationStatusMessage       :
Type                                               : Microsoft.Security/defenderForStorageSettings
```



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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DefenderForStorage.Models.IDefenderForStorageSetting

## NOTES

## RELATED LINKS

