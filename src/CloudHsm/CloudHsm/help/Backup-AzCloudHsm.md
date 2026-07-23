---
external help file: Az.CloudHsm-help.xml
Module Name: Az.CloudHsm
online version: https://learn.microsoft.com/powershell/module/az.cloudhsm/backup-azcloudhsm
schema: 2.0.0
---

# Backup-AzCloudHsm

## SYNOPSIS
Begin a backup of the Cloud HSM.

## SYNTAX

```
Backup-AzCloudHsm -ClusterName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BlobContainerUri <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Backups a Cloud HSM to a storage account.
Use `Restore-AzCloudHsm` to restore the backup.

## EXAMPLES

### Example 1:  Backup a Cloud HSM.
```powershell
Backup-AzCloudHsm -ClusterName chsm1 -ResourceGroupName group -BlobContainerUri "https://{accountName}.blob.core.windows.net/{containerName}"
```

```output
AdditionalInfo               :
AzureStorageBlobContainerUri : https://backup.blob.core.windows.net/testbackup
BackupId                     : cloudhsm-eb0e0bf9-9d12-4201-b38c-567c8a452dd5-2025061208354444
Code                         :
Detail                       :
EndTime                      : 12/06/2025 8:35:54 am
JobId                        : 472f1c6185d74e78bf796c9a8e993a42
Message                      :
StartTime                    : 12/06/2025 8:35:44 am
Status                       : Succeeded
StatusDetail                 : HSM Backup Time: 6/12/2025 8:17:27 AM +00:00 UTC.
Target                       :
XmsRequestId                 : 378da564-737d-4f40-86f5-9623e19c74e1
```

The cmdlet will create a folder (typically named `cloudhsm-{guid}-{timestamp}`) in the storage container, store the backup in that folder and output the folder URI.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -BlobContainerUri
The Azure blob storage container Uri which contains the backup

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

### -ClusterName
The name of the Cloud HSM Cluster within the specified resource group.
Cloud HSM Cluster names must be between 3 and 23 characters in length.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CloudHsmClusterName

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

### -NoWait
Run the command asynchronously

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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHsm.Models.IBackupResult

## NOTES

## RELATED LINKS
