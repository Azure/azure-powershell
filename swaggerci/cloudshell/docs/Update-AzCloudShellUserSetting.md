---
external help file:
Module Name: Az.CloudShell
online version: https://docs.microsoft.com/en-us/powershell/module/az.cloudshell/update-azcloudshellusersetting
schema: 2.0.0
---

# Update-AzCloudShellUserSetting

## SYNOPSIS
Patch cloud shell settings for current signed in user

## SYNTAX

### PatchExpanded1 (Default)
```
Update-AzCloudShellUserSetting -SName <String> [-PreferredLocation <String>] [-PreferredOSType <OSType>]
 [-PreferredShellType <ShellType>] [-StorageProfileDiskSizeInGb <Int32>]
 [-StorageProfileFileShareName <String>] [-StorageProfileStorageAccountResourceId <String>]
 [-TerminalSettingFontSize <FontSize>] [-TerminalSettingFontStyle <FontStyle>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Patch
```
Update-AzCloudShellUserSetting -Location <String> -SName <String> -Parameter <ICloudShellPatchUserSettings>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Patch1
```
Update-AzCloudShellUserSetting -SName <String> -Parameter <ICloudShellPatchUserSettings>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchExpanded
```
Update-AzCloudShellUserSetting -Location <String> -SName <String> [-PreferredLocation <String>]
 [-PreferredOSType <OSType>] [-PreferredShellType <ShellType>] [-StorageProfileDiskSizeInGb <Int32>]
 [-StorageProfileFileShareName <String>] [-StorageProfileStorageAccountResourceId <String>]
 [-TerminalSettingFontSize <FontSize>] [-TerminalSettingFontStyle <FontStyle>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentity
```
Update-AzCloudShellUserSetting -InputObject <ICloudShellIdentity> -Parameter <ICloudShellPatchUserSettings>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentity1
```
Update-AzCloudShellUserSetting -InputObject <ICloudShellIdentity> -Parameter <ICloudShellPatchUserSettings>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentityExpanded
```
Update-AzCloudShellUserSetting -InputObject <ICloudShellIdentity> [-PreferredLocation <String>]
 [-PreferredOSType <OSType>] [-PreferredShellType <ShellType>] [-StorageProfileDiskSizeInGb <Int32>]
 [-StorageProfileFileShareName <String>] [-StorageProfileStorageAccountResourceId <String>]
 [-TerminalSettingFontSize <FontSize>] [-TerminalSettingFontStyle <FontStyle>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentityExpanded1
```
Update-AzCloudShellUserSetting -InputObject <ICloudShellIdentity> [-PreferredLocation <String>]
 [-PreferredOSType <OSType>] [-PreferredShellType <ShellType>] [-StorageProfileDiskSizeInGb <Int32>]
 [-StorageProfileFileShareName <String>] [-StorageProfileStorageAccountResourceId <String>]
 [-TerminalSettingFontSize <FontSize>] [-TerminalSettingFontStyle <FontStyle>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patch cloud shell settings for current signed in user

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudShell.Models.ICloudShellIdentity
Parameter Sets: PatchViaIdentity, PatchViaIdentity1, PatchViaIdentityExpanded, PatchViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The provider location

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Cloud shell patch operation user settings.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudShell.Models.Api20181001.ICloudShellPatchUserSettings
Parameter Sets: Patch, Patch1, PatchViaIdentity, PatchViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PreferredLocation
The preferred location of the cloud shell.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchExpanded1, PatchViaIdentityExpanded, PatchViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreferredOSType
The operating system type of the cloud shell.
Deprecated, use preferredShellType.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudShell.Support.OSType
Parameter Sets: PatchExpanded, PatchExpanded1, PatchViaIdentityExpanded, PatchViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PreferredShellType
The shell type of the cloud shell.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudShell.Support.ShellType
Parameter Sets: PatchExpanded, PatchExpanded1, PatchViaIdentityExpanded, PatchViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SName
The name of the user settings

```yaml
Type: System.String
Parameter Sets: Patch, Patch1, PatchExpanded, PatchExpanded1
Aliases: UserSettingsName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageProfileDiskSizeInGb
Size of file share

```yaml
Type: System.Int32
Parameter Sets: PatchExpanded, PatchExpanded1, PatchViaIdentityExpanded, PatchViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageProfileFileShareName
Name of the mounted file share.
63 characters or less, lowercase alphabet, numbers, and -

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchExpanded1, PatchViaIdentityExpanded, PatchViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageProfileStorageAccountResourceId
Full resource ID of storage account.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchExpanded1, PatchViaIdentityExpanded, PatchViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TerminalSettingFontSize
Size of terminal font.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudShell.Support.FontSize
Parameter Sets: PatchExpanded, PatchExpanded1, PatchViaIdentityExpanded, PatchViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TerminalSettingFontStyle
Style of terminal font.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudShell.Support.FontStyle
Parameter Sets: PatchExpanded, PatchExpanded1, PatchViaIdentityExpanded, PatchViaIdentityExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudShell.Models.Api20181001.ICloudShellPatchUserSettings

### Microsoft.Azure.PowerShell.Cmdlets.CloudShell.Models.ICloudShellIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudShell.Models.Api20181001.IUserSettingsResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ICloudShellIdentity>: Identity Parameter
  - `[ConsoleName <String>]`: The name of the console
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The provider location
  - `[UserSettingsName <String>]`: The name of the user settings

PARAMETER <ICloudShellPatchUserSettings>: Cloud shell patch operation user settings.
  - `[PreferredLocation <String>]`: The preferred location of the cloud shell.
  - `[PreferredOSType <OSType?>]`: The operating system type of the cloud shell. Deprecated, use preferredShellType.
  - `[PreferredShellType <ShellType?>]`: The shell type of the cloud shell.
  - `[StorageProfileDiskSizeInGb <Int32?>]`: Size of file share
  - `[StorageProfileFileShareName <String>]`: Name of the mounted file share. 63 characters or less, lowercase alphabet, numbers, and -
  - `[StorageProfileStorageAccountResourceId <String>]`: Full resource ID of storage account.
  - `[TerminalSettingFontSize <FontSize?>]`: Size of terminal font.
  - `[TerminalSettingFontStyle <FontStyle?>]`: Style of terminal font.

## RELATED LINKS

