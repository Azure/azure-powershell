---
external help file:
Module Name: Azs.Backup.Admin
online version: https://docs.microsoft.com/en-us/powershell/module/azs.backup.admin/set-azsbackupconfiguration
schema: 2.0.0
---

# Set-AzsBackupConfiguration

## SYNOPSIS
Update a backup location.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzsBackupConfiguration [-Location <String>] [-ResourceGroupName <String>] [-SubscriptionId <String>]
 [-BackupFrequencyInHours <Int32>] [-BackupRetentionPeriodInDays <Int32>] [-EncryptionCertPath <String>]
 [-IsBackupSchedulerEnabled] [-Password <SecureString>] [-Path <String>] [-Tag <Hashtable>]
 [-UserName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Update
```
Set-AzsBackupConfiguration -Backup <IBackupLocation> [-Location <String>] [-ResourceGroupName <String>]
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a backup location.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> Set-AzsBackupConfiguration -Path "\\***.***.***.***\Share" -Username "asdomain1\azurestackadmin" -Password $password  -EncryptionCertPath $encryptionCertPath

```

Set Azure Stack backup configuration.

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
Dynamic: False
```

### -Backup
Information about the backup location.
To construct, see NOTES section for BACKUP properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IBackupLocation
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -BackupFrequencyInHours
The interval, in hours, for the frequency that the scheduler takes a backup.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -BackupRetentionPeriodInDays
The retention period, in days, for backs in the storage location.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EncryptionCertPath
Path to the encryption cert file with public key (.cer).

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IsBackupSchedulerEnabled
True if the backup scheduler is enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Name of the backup location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzLocation)[0].Name
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Password
Password to access the location.

```yaml
Type: System.Security.SecureString
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Path
Path to the update location

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: "system.$((Get-AzLocation)[0].Name)"
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials that uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
List of key value pairs.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UserName
Username to access the location.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IBackupLocation

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IBackupLocation

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### BACKUP <IBackupLocation>: Information about the backup location.
  - `[Location <String>]`: Location of the resource.
  - `[Tag <IResourceTags>]`: List of key value pairs.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[BackupFrequencyInHours <Int32?>]`: The interval, in hours, for the frequency that the scheduler takes a backup.
  - `[BackupRetentionPeriodInDays <Int32?>]`: The retention period, in days, for backs in the storage location.
  - `[EncryptionCertBase64 <String>]`: The base64 raw data for the backup encryption certificate.
  - `[IsBackupSchedulerEnabled <Boolean?>]`: True if the backup scheduler is enabled.
  - `[Password <String>]`: Password to access the location.
  - `[Path <String>]`: Path to the update location
  - `[UserName <String>]`: Username to access the location.

## RELATED LINKS

