---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.Management.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/powershell/module/az.storage/update-azstoragefileserviceproperty
schema: 2.0.0
---

# Update-AzStorageFileServiceProperty

## SYNOPSIS
Modifies the service properties for the Azure Storage File service.

## SYNTAX

### AccountName (Default)
```
Update-AzStorageFileServiceProperty [-ResourceGroupName] <String> [-StorageAccountName] <String>
 [-EnableShareDeleteRetentionPolicy <Boolean>] [-ShareRetentionDays <Int32>] [-EnableSmbMultichannel <Boolean>]
 [-SmbProtocolVersion <String[]>] [-SmbAuthenticationMethod <String[]>] [-SmbChannelEncryption <String[]>]
 [-SmbKerberosTicketEncryption <String[]>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### AccountObject
```
Update-AzStorageFileServiceProperty -StorageAccount <PSStorageAccount>
 [-EnableShareDeleteRetentionPolicy <Boolean>] [-ShareRetentionDays <Int32>] [-EnableSmbMultichannel <Boolean>]
 [-SmbProtocolVersion <String[]>] [-SmbAuthenticationMethod <String[]>] [-SmbChannelEncryption <String[]>]
 [-SmbKerberosTicketEncryption <String[]>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### FileServicePropertiesResourceId
```
Update-AzStorageFileServiceProperty [-ResourceId] <String> [-EnableShareDeleteRetentionPolicy <Boolean>]
 [-ShareRetentionDays <Int32>] [-EnableSmbMultichannel <Boolean>] [-SmbProtocolVersion <String[]>]
 [-SmbAuthenticationMethod <String[]>] [-SmbChannelEncryption <String[]>]
 [-SmbKerberosTicketEncryption <String[]>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzStorageFileServiceProperty** cmdlet modifies the service properties for the Azure Storage File service.

## EXAMPLES

### Example 1: Enable File share softdelete
<!-- Skip: Output cannot be splitted from code -->
```powershell
PS C:\> Update-AzStorageFileServiceProperty -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -EnableShareDeleteRetentionPolicy $true -ShareRetentionDays 5

StorageAccountName                            : mystorageaccount
ResourceGroupName                             : myresourcegroup
ShareDeleteRetentionPolicy.Enabled            : True
ShareDeleteRetentionPolicy.Days               : 5
ProtocolSettings.Smb.Multichannel.Enabled     : False
ProtocolSettings.Smb.Versions                 : 
ProtocolSettings.Smb.AuthenticationMethods    : 
ProtocolSettings.Smb.KerberosTicketEncryption : 
ProtocolSettings.Smb.ChannelEncryption        :
```

This command enables File share softdelete delete with retention days as 5

### Example 2: Enable Smb Multichannel
<!-- Skip: Output cannot be splitted from code -->
```powershell
PS C:\> Update-AzStorageFileServiceProperty -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" -EnableSmbMultichannel $true

StorageAccountName                            : mystorageaccount
ResourceGroupName                             : myresourcegroup
ShareDeleteRetentionPolicy.Enabled            : True
ShareDeleteRetentionPolicy.Days               : 5
ProtocolSettings.Smb.Multichannel.Enabled     : True
ProtocolSettings.Smb.Versions                 : 
ProtocolSettings.Smb.AuthenticationMethods    : 
ProtocolSettings.Smb.KerberosTicketEncryption : 
ProtocolSettings.Smb.ChannelEncryption        :
```

This command enables Smb Multichannel, only supported on Premium FileStorage account.

### Example 3: Updates secure smb settings
<!-- Skip: Output cannot be splitted from code -->
```powershell
PS C:\> Update-AzStorageFileServiceProperty -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" `
			-SMBProtocolVersion SMB2.1,SMB3.0,SMB3.1.1  `
			-SMBAuthenticationMethod Kerberos,NTLMv2 `
			-SMBKerberosTicketEncryption RC4-HMAC,AES-256 `
			-SMBChannelEncryption AES-128-CCM,AES-128-GCM,AES-256-GCM 

StorageAccountName                            : mystorageaccount
ResourceGroupName                             : myresourcegroup
ShareDeleteRetentionPolicy.Enabled            : True
ShareDeleteRetentionPolicy.Days               : 5
ProtocolSettings.Smb.Multichannel.Enabled     : True
ProtocolSettings.Smb.Versions                 : {SMB2.1, SMB3.0, SMB3.1.1}
ProtocolSettings.Smb.AuthenticationMethods    : {Kerberos, NTLMv2}
ProtocolSettings.Smb.KerberosTicketEncryption : {RC4-HMAC, AES-256}
ProtocolSettings.Smb.ChannelEncryption        : {AES-128-CCM, AES-128-GCM, AES-256-GCM}
```

This command updates secure smb settings.

### Example 4: Clear secure smb settings
<!-- Skip: Output cannot be splitted from code -->
```powershell
PS C:\> Update-AzStorageFileServiceProperty -ResourceGroupName "myresourcegroup" -AccountName "mystorageaccount" `
			-SMBProtocolVersion @() `
			-SMBAuthenticationMethod @() `
			-SMBKerberosTicketEncryption @() `
			-SMBChannelEncryption @() 

StorageAccountName                            : mystorageaccount
ResourceGroupName                             : myresourcegroup
ShareDeleteRetentionPolicy.Enabled            : True
ShareDeleteRetentionPolicy.Days               : 5
ProtocolSettings.Smb.Multichannel.Enabled     : True
ProtocolSettings.Smb.Versions                 : 
ProtocolSettings.Smb.AuthenticationMethods    : 
ProtocolSettings.Smb.KerberosTicketEncryption : 
ProtocolSettings.Smb.ChannelEncryption        :
```

This command clears secure smb settings.

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

### -EnableShareDeleteRetentionPolicy
Enable share Delete Retention Policy for the storage account by set to $true, disable share Delete Retention Policy  by set to $false.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSmbMultichannel
Enable Multichannel by set to $true, disable Multichannel by set to $false. Applies to Premium FileStorage only.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

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
Parameter Sets: AccountName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Input a Storage account Resource Id, or a File service properties Resource Id.

```yaml
Type: System.String
Parameter Sets: FileServicePropertiesResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ShareRetentionDays
Sets the number of retention days for the share DeleteRetentionPolicy.
The value should only be set when enable share Delete Retention Policy.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases: Days, RetentionDays

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SmbAuthenticationMethod
Gets or sets SMB authentication methods supported by server. Valid values are NTLMv2, Kerberos.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:
Accepted values: Kerberos, NTLMv2

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SmbChannelEncryption
Gets or sets SMB channel encryption supported by server. Valid values are AES-128-CCM, AES-128-GCM, AES-256-GCM.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:
Accepted values: AES-128-CCM, AES-128-GCM, AES-256-GCM

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SmbKerberosTicketEncryption
Gets or sets kerberos ticket encryption supported by server. Valid values are RC4-HMAC, AES-256.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:
Accepted values: AES-256, RC4-HMAC

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SmbProtocolVersion
Gets or sets SMB protocol versions supported by server. Valid values are SMB2.1, SMB3.0, SMB3.1.1.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:
Accepted values: SMB2.1, SMB3.0, SMB3.1.1

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
Parameter Sets: AccountObject
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
Parameter Sets: AccountName
Aliases: AccountName, Name

Required: True
Position: 1
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

### Microsoft.Azure.Commands.Management.Storage.Models.PSStorageAccount

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.Storage.Models.PSFileServiceProperties

## NOTES

## RELATED LINKS
