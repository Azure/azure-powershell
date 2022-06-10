---
external help file:
Module Name: Az.StorSimple
online version: https://docs.microsoft.com/en-us/powershell/module/az.storsimple/update-azstorsimplemanagerextendedinfo
schema: 2.0.0
---

# Update-AzStorSimpleManagerExtendedInfo

## SYNOPSIS
Updates the extended info of the manager.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStorSimpleManagerExtendedInfo -ManagerName <String> -ResourceGroupName <String> -IfMatch <String>
 -Algorithm <String> -IntegrityKey <String> [-SubscriptionId <String>] [-EncryptionKey <String>]
 [-EncryptionKeyThumbprint <String>] [-Etag <String>] [-PortalCertificateThumbprint <String>]
 [-Version <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStorSimpleManagerExtendedInfo -InputObject <IStorSimpleIdentity> -IfMatch <String>
 -Algorithm <String> -IntegrityKey <String> [-EncryptionKey <String>] [-EncryptionKeyThumbprint <String>]
 [-Etag <String>] [-PortalCertificateThumbprint <String>] [-Version <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates the extended info of the manager.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Algorithm
Represents the encryption algorithm used to encrypt the other keys.
None - if EncryptionKey is saved in plain text format.
AlgorithmName - if encryption is used

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
```

### -EncryptionKey
Represents the CEK of the resource

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

### -EncryptionKeyThumbprint
Represents the Cert thumbprint that was used to encrypt the CEK

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

### -Etag
ETag of the Resource

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

### -IfMatch
Pass the ETag of ExtendedInfo fetched from GET call

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Models.IStorSimpleIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IntegrityKey
Represents the CIK of the resource

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

### -ManagerName
The manager name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PortalCertificateThumbprint
Represents the portal thumbprint which can be used optionally to encrypt the entire data before storing it.

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

### -ResourceGroupName
The resource group name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription id

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Represents the version of the ExtendedInfo object being persisted

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

### Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Models.IStorSimpleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Models.Api20161001.IManagerExtendedInfo

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IStorSimpleIdentity>: Identity Parameter
  - `[AccessControlRecordName <String>]`: Name of access control record to be fetched.
  - `[BackupName <String>]`: The backup name.
  - `[CertificateName <String>]`: Certificate Name
  - `[ChapUserName <String>]`: The user name of chap to be fetched.
  - `[CredentialName <String>]`: The name of storage account credential to be fetched.
  - `[DeviceName <String>]`: The device name.
  - `[DiskName <String>]`: The disk name.
  - `[ElementName <String>]`: The backup element name.
  - `[FileServerName <String>]`: The file server name.
  - `[Id <String>]`: Resource identity path
  - `[IscsiServerName <String>]`: The iSCSI server name.
  - `[JobName <String>]`: The job name.
  - `[ManagerName <String>]`: The manager name
  - `[ResourceGroupName <String>]`: The resource group name
  - `[ScheduleGroupName <String>]`: The name of the schedule group.
  - `[ShareName <String>]`: The file share name.
  - `[StorageDomainName <String>]`: The storage domain name.
  - `[SubscriptionId <String>]`: The subscription id

## RELATED LINKS

