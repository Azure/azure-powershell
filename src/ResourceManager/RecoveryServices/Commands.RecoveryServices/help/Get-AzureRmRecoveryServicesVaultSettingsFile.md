---
external help file: Microsoft.Azure.Commands.RecoveryServices.ARM.dll-Help.xml
Module Name: AzureRM.RecoveryServices
ms.assetid: 56074606-28A6-4F91-A56C-4C8A9A31543F
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.recoveryservices/get-azurermrecoveryservicesvaultsettingsfile
schema: 2.0.0
---

# Get-AzureRmRecoveryServicesVaultSettingsFile

## SYNOPSIS
Gets the Azure Site Recovery vault settings file.

## SYNTAX

### ForSite
```
Get-AzureRmRecoveryServicesVaultSettingsFile [-Vault] <ARSVault> -SiteIdentifier <String>
 -SiteFriendlyName <String> [[-Path] <String>] [-SiteRecovery] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByDefault
```
Get-AzureRmRecoveryServicesVaultSettingsFile [-Vault] <ARSVault> [[-Path] <String>] [-SiteRecovery]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ForBackupVaultType
```
Get-AzureRmRecoveryServicesVaultSettingsFile [-Vault] <ARSVault> [[-Path] <String>] [-Backup]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmRecoveryServicesVaultSettingsFile** cmdlet gets the settings file for an Azure Site Recovery vault.

## EXAMPLES

### Example 1: Register a Windows Server or DPM machine for Azure Backup
```
PS C:\> $Vault01 = Get-AzureRmRecoveryServicesVault -Name "TestVault"
PS C:\> $CredsPath = "C:\Downloads"
PS C:\> $Credsfilename = Get-AzureRmRecoveryServicesVaultSettingsFile -Backup -Vault $Vault01 -Path $CredsPath
```

The first command gets the vault named TestVault, and then stores it in the $Vault01 variable.

The second command sets the $CredsPath variable to C:\Downloads.

The last command gets the vault credentials file for $Vault01 using the credentials in $CredsPath for Azure Backup.

### Example 2:
```
PS C:\> $Credsfilename = Get-AzureRmRecoveryServicesVaultSettingsFile -SiteIdentifier -Vault $Vault01
```

The command gets the vault credentials file for $Vault01 of vault type siteRecovery.

### Example 3: Register a Windows Server or DPM machine for Azure Backup
```
PS C:\> $Credsfilename = Get-AzureRmRecoveryServicesVaultSettingsFile -SiteIdentifier -Vault $Vault01
```

The command gets the vault credentials file for $Vault01.

## PARAMETERS

### -Backup
Indicates the vault credentials file is applicable to Azure Backup.

```yaml
Type: SwitchParameter
Parameter Sets: ForBackupVaultType
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Specifies the path to the Azure Site Recovery vault settings file.
You can download this file from the Azure Site Recovery vault portal and store it locally.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteFriendlyName
Specifies the site friendly name.
Use this parameter if you are downloading the vault credentials for a Hyper-V site.

```yaml
Type: String
Parameter Sets: ForSite
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteIdentifier
Specifies the site identifier.
Use this parameter if you are downloading the vault credentials for a Hyper-V site.

```yaml
Type: String
Parameter Sets: ForSite
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SiteRecovery
Indicates the vault credentials file is applicable to Azure Site Recovery.

```yaml
Type: SwitchParameter
Parameter Sets: ForSite, ByDefault
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Vault
Specifies the Azure Site Recovery vault object.

```yaml
Type: ARSVault
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### ARSVault
Parameter 'Vault' accepts value of type 'ARSVault' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.RecoveryServices.VaultSettingsFilePath

## NOTES

## RELATED LINKS

[Get-AzureRmRecoveryServicesVault](./Get-AzureRmRecoveryServicesVault.md)

[New-AzureRmRecoveryServicesVault](./New-AzureRmRecoveryServicesVault.md)

[Remove-AzureRmRecoveryServicesVault](./Remove-AzureRmRecoveryServicesVault.md)


