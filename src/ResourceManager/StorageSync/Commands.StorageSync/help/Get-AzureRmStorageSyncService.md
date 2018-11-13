---
external help file: Microsoft.Azure.Commands.StorageSync.dll-Help.xml
Module Name: AzureRM.StorageSync
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.storagesync/get-azurermstoragesyncservice
schema: 2.0.0
---

# Get-AzureRmStorageSyncService

## SYNOPSIS
This command will use to get sync service.

## SYNTAX

### ParentStringParameterSet (Default)
```
Get-AzureRmStorageSyncService [[-ResourceGroupName] <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### StringParameterSet
```
Get-AzureRmStorageSyncService [-ResourceGroupName] <String> [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
This command will use to get sync service.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzureRmStorageSyncService -ResourceGroupName "myResourceGroup" -StorageSyncServiceName "myStorageSyncServiceName"
```

This command is used to get the storage sync service based on the dependent resource names.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the StorageSyncService.

```yaml
Type: System.String
Parameter Sets: StringParameterSet
Aliases: StorageSyncServiceName

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: System.String
Parameter Sets: ParentStringParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: StringParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.StorageSync.Models.PSStorageSyncService

## NOTES

## RELATED LINKS
