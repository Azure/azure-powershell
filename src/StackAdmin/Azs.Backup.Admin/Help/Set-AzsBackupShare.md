---
external help file: Azs.Backup.Admin-help.xml
Module Name: Azs.Backup.Admin
online version: 
schema: 2.0.0
---

# Set-AzsBackupShare

## SYNOPSIS
Create a new backup location.

## SYNTAX

### Update (Default)
```
Set-AzsBackupShare [-ResourceGroupName <String>] [-Location <String>] -BackupShare <String> -Username <String>
 -Password <SecureString> -EncryptionKey <SecureString> [-Wait] [<CommonParameters>]
```

### InputObject
```
Set-AzsBackupShare -InputObject <BackupLocation> [-BackupShare <String>] [-Username <String>]
 [-Password <SecureString>] [-EncryptionKey <SecureString>] [-Wait] [<CommonParameters>]
```

### ResourceId
```
Set-AzsBackupShare -ResourceId <String> -BackupShare <String> -Username <String> -Password <SecureString>
 -EncryptionKey <SecureString> [-Wait] [<CommonParameters>]
```

## DESCRIPTION
Create a new backup location.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Set-AzsBackupShare -ResourceGroupName system.local -Location local -BackupShare "\\su1fileserver\SU1_Infrastructure_3" -Username "azurestack\azurestackadmin" -Password $password  -EncryptionKey $encryptionKey
```

BackupDataVersion :
BackupId          : 4e90bd2f-c7ab-47a3-a3c7-908cddd1ad0e
RoleStatus        : {NRP, SRP, CRP, KeyVaultInternalControlPlane...}
Status            : Succeeded
CreatedDateTime   : 3/15/2018 1:31:01 AM
TimeTakenToCreate : PT6M41.7853037S
Id                : /subscriptions/b3d6379e-711c-48eb-b051-3c71305ec104/resourceGroups/system.local/providers/Microsoft.Backup.Admin/backupLocations/local/backups/4e90bd2f-c7ab-47a3-a3c7-908cddd1ad0e
Name              : 4e90bd2f-c7ab-47a3-a3c7-908cddd1ad0e
Type              : Microsoft.Backup.Admin/backupLocations/backups
Location          : local
Tags              : {}

Set Azure Stack backup configuration.

## PARAMETERS

### -BackupShare
Location where backups will be stored.

```yaml
Type: String
Parameter Sets: Update, ResourceId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: InputObject
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionKey
Encryption key used to encrypt backups.

```yaml
Type: SecureString
Parameter Sets: Update, ResourceId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: SecureString
Parameter Sets: InputObject
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The input object of type Microsoft.AzureStack.Management.Backup.Admin.Models.BackupLocation.

```yaml
Type: BackupLocation
Parameter Sets: InputObject
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
Name of the backup location.

```yaml
Type: String
Parameter Sets: Update
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Password
Password required to access backup location.

```yaml
Type: SecureString
Parameter Sets: Update, ResourceId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: SecureString
Parameter Sets: InputObject
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: String
Parameter Sets: Update
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Username
Username required to access backup location.

```yaml
Type: String
Parameter Sets: Update, ResourceId
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: InputObject
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Wait
{{Fill Wait Description}}

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Backup.Admin.Models.BackupLocation

## NOTES

## RELATED LINKS

