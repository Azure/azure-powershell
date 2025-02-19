---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azrmstorageshare
schema: 2.0.0
---

# Get-AzRmStorageShare

## SYNOPSIS
Gets or lists Storage file shares.

## SYNTAX

### AccountNameSingle (Default)
```
Get-AzRmStorageShare [-ResourceGroupName] <String> [-StorageAccountName] <String> [-Name <String>]
 [-SnapshotTime <DateTime>] [-GetShareUsage] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### AccountName
```
Get-AzRmStorageShare [-ResourceGroupName] <String> [-StorageAccountName] <String> [-IncludeDeleted]
 [-IncludeSnapshot] [-Filter <String>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### AccountObjectSingle
```
Get-AzRmStorageShare -StorageAccount <PSStorageAccount> -Name <String> [-SnapshotTime <DateTime>]
 [-GetShareUsage] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### AccountObject
```
Get-AzRmStorageShare -StorageAccount <PSStorageAccount> [-IncludeDeleted] [-IncludeSnapshot] [-Filter <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ShareResourceId
```
Get-AzRmStorageShare [-ResourceId] <String> [-GetShareUsage] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzRmStorageShare** cmdlet gets or lists Storage file shares.

## EXAMPLES

### Example 1: Get a Storage file share with Storage account name and share name
```powershell
Get-AzRmStorageShare -ResourceGroupName "myresourcegroup" -StorageAccountName "mystorageaccount" -Name "myshare"
```

```output
ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name     QuotaGiB EnabledProtocols AccessTier Deleted Version ShareUsageBytes
----     -------- ---------------- ---------- ------- ------- ---------------
myshare  5120
```

This command gets a Storage file share with Storage account name and share name.

### Example 2: List all Storage file shares of a Storage account
```powershell
Get-AzRmStorageShare -ResourceGroupName "myresourcegroup" -StorageAccountName "mystorageaccount"
```

```output
ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name     QuotaGiB EnabledProtocols AccessTier           Deleted Version ShareUsageBytes
----     -------- ---------------- ----------           ------- ------- ---------------
share1   5120                     TransactionOptimized
share2   5120                     TransactionOptimized
```

This command lists all Storage file shares of a Storage account with Storage account name.

### Example 3: Get a Storage blob container with Storage account object and container name.
```powershell
Get-AzStorageAccount -ResourceGroupName "myresourcegroup" -StorageAccountName "mystorageaccount" | Get-AzRmStorageShare -Name "myshare"
```

```output
ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name     QuotaGiB EnabledProtocols AccessTier Deleted Version ShareUsageBytes
----     -------- ---------------- ---------- ------- ------- ---------------
myshare  5120
```

This command gets a Storage blob container with Storage account object and container name.

### Example 4: Get a Storage file share with the share usage in bytes
```powershell
Get-AzRmStorageShare -ResourceGroupName "myresourcegroup" -StorageAccountName "mystorageaccount" -Name "myshare" -GetShareUsage
```

```output
ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name     QuotaGiB EnabledProtocols AccessTier Deleted Version ShareUsageBytes
----     -------- ---------------- ---------- ------- ------- ---------------
myshare  5120                                                2097152
```

This command gets a Storage file share with Storage account name and share name, and include the share usage in bytes.

### Example 5: List all Storage file shares of a Storage account, include the deleted shares, include the share snapshots
```powershell
Get-AzRmStorageShare -ResourceGroupName "myresourcegroup" -StorageAccountName "mystorageaccount" -IncludeDeleted -IncludeSnapshot
```

```output
ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name       QuotaGiB EnabledProtocols AccessTier           Deleted Version          ShareUsageBytes snapshotTime       
----       -------- ---------------- ----------           ------- -------          --------------- ------------       
testshare1 5120                     TransactionOptimized                                          2021-05-10T08:04:08Z
testshare1 5120                     TransactionOptimized                                                      
share1     100                      TransactionOptimized True    01D61FD1FC5498B6
```

This command lists all Storage file shares include the deleted shares and share snapshots.

### Example 6: Get a single share snapshot
```powershell
Get-AzRmStorageShare -ResourceGroupName "myresourcegroup" -StorageAccountName "mystorageaccount" -Name "testshare1" -SnapshotTime "2021-05-10T08:04:08Z"
```

```output
ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name       QuotaGiB EnabledProtocols AccessTier           Deleted Version ShareUsageBytes snapshotTime       
----       -------- ---------------- ----------           ------- ------- --------------- ------------       
testshare1 5120                     TransactionOptimized                                 2021-05-10T08:04:08Z
```

This command gets a single file share snapshot with share name and snapshot time.

### Example 7: List Storage file shares of a Storage account with a filter
```powershell
Get-AzRmStorageShare -ResourceGroupName "myresourcegroup" -StorageAccountName "mystorageaccount" -Filter "startswith(name, test)"
```

```output
ResourceGroupName: myresourcegroup, StorageAccountName: mystorageaccount

Name       QuotaGiB EnabledProtocols AccessTier           Deleted Version ShareUsageBytes snapshotTime
----       -------- ---------------- ----------           ------- ------- --------------- ------------
testshare1 5120     SMB              TransactionOptimized
testshare2 5120     SMB              TransactionOptimized
```

This command lists all Storage file shares with names that begin with "test".

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
The filter of share name. When specified, only share names starting with the filter will be listed. The filter must be in format: startswith(name, `<prefix>`)

```yaml
Type: System.String
Parameter Sets: AccountName, AccountObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GetShareUsage
Specify this parameter to get the Share Usage in Bytes.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AccountNameSingle, AccountObjectSingle, ShareResourceId
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeDeleted
Include deleted shares, by default list shares won't include deleted shares

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AccountName, AccountObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeSnapshot
Include share snapshots, by default list shares won't include share snapshots.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AccountName, AccountObject
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Share Name

```yaml
Type: System.String
Parameter Sets: AccountNameSingle
Aliases: N, ShareName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: AccountObjectSingle
Aliases: N, ShareName

Required: True
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
Resource Group Name.

```yaml
Type: System.String
Parameter Sets: AccountNameSingle, AccountName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Input a File Share Resource Id.

```yaml
Type: System.String
Parameter Sets: ShareResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SnapshotTime
Share SnapshotTime

```yaml
Type: System.Nullable`1[System.DateTime]
Parameter Sets: AccountNameSingle, AccountObjectSingle
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccount
Storage account object

```yaml
Type: Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount
Parameter Sets: AccountObjectSingle, AccountObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -StorageAccountName
Storage Account Name.

```yaml
Type: System.String
Parameter Sets: AccountNameSingle, AccountName
Aliases: AccountName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSShare

## NOTES

## RELATED LINKS
