---
external help file: Microsoft.Azure.Commands.Management.Storage.dll-Help.xml
Module Name: AzureRM.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.storage/get-azurermstorageaccountlastsynctime
schema: 2.0.0
---

# Get-AzureRmStorageAccountLastSyncTime

## SYNOPSIS
Retrieves last sync time of a RA-GRS and GRS Storage accounts.

## SYNTAX

### AccountName (Default)
```
Get-AzureRmStorageAccountLastSyncTime [-ResourceGroupName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### AccountObject
```
Get-AzureRmStorageAccountLastSyncTime -InputObject <PSStorageAccount>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmStorageAccountLastSyncTime** cmdlet retrieves last sync time of a RA-GRS and GRS Storage accounts.
All primary writes preceding last sync time are guaranteed to be replicated to secondary. Primary writes after this point in time may or may not be replicated. It is the minimum last sync time of the account's Blob/Table/Queue/File endpoints. The value may be account's creation time if LastSyncTime is not available. This can happen if the replication status is bootstrap or unavailable.
The status in the result means:
- Live: Indicates that the secondary location is active and operational.
- Bootstrap: Indicates initial synchronization from the primary location to the secondary location is in progress, this typically occurs when replication is first enabled.
- Unavailable: Indicates that the secondary location is temporarily unavailable. 

## EXAMPLES

### Example 1: Get last sync time of a specified Storage account
```
PS C:\> Get-AzureRmStorageAccountLastSyncTime  -ResourceGroupName "rg1" -Name "mystorageaccount"

Status LastSyncTime        
------ ------------        
Live   10/9/2018 9:10:19 AM
```

This command gets last sync time of a specified Storage account. 

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

### -InputObject
Storage account object

```yaml
Type: Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount
Parameter Sets: AccountObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Storage Account Name.

```yaml
Type: System.String
Parameter Sets: AccountName
Aliases: StorageAccountName, AccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: System.String
Parameter Sets: AccountName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSManagementPolicy

## NOTES

## RELATED LINKS
