---
external help file: Az.ImageBuilder-help.xml
Module Name: Az.ImageBuilder
online version: https://learn.microsoft.com/powershell/module/az.ImageBuilder/new-azimagebuildertemplatecustomizerobject
schema: 2.0.0
---

# New-AzImageBuilderTemplateCustomizerObject

## SYNOPSIS
Create an in-memory object for ImageTemplateCustomizer.

## SYNTAX

### FileCustomizer (Default)
```
New-AzImageBuilderTemplateCustomizerObject [-FileCustomizer] [-Destination <String>] [-Sha256Checksum <String>]
 [-SourceUri <String>] [-Name <String>] [<CommonParameters>]
```

### ShellCustomizer
```
New-AzImageBuilderTemplateCustomizerObject [-Sha256Checksum <String>] [-Name <String>] [-Inline <String[]>]
 [-ScriptUri <String>] [-ShellCustomizer] [<CommonParameters>]
```

### PowerShellCustomizer
```
New-AzImageBuilderTemplateCustomizerObject [-Sha256Checksum <String>] [-Name <String>] [-PowerShellCustomizer]
 [-Inline <String[]>] [-RunAsSystem <Boolean>] [-RunElevated <Boolean>] [-ScriptUri <String>]
 [-ValidExitCode <Int32[]>] [<CommonParameters>]
```

### RestartCustomizer
```
New-AzImageBuilderTemplateCustomizerObject [-Name <String>] [-RestartCustomizer]
 [-RestartCheckCommand <String>] [-RestartCommand <String>] [-RestartTimeout <String>]
 [<CommonParameters>]
```

### WindowsUpdateCustomizer
```
New-AzImageBuilderTemplateCustomizerObject [-Name <String>] [-WindowsUpdateCustomizer] [-Filter <String[]>]
 [-SearchCriterion <String>] [-UpdateLimit <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ImageTemplateCustomizer.

## EXAMPLES

### Example 1: Create a windows update customizer.
```powershell
New-AzImageBuilderTemplateCustomizerObject -WindowsUpdateCustomizer -Name 'WindUpdate' -Filter ("BrowseOnly", "IsInstalled") -SearchCriterion "BrowseOnly=0 and IsInstalled=0" -UpdateLimit 100
```

```output
Name       Filter                    SearchCriterion                UpdateLimit
----       ------                    ---------------                -----------
WindUpdate {BrowseOnly, IsInstalled} BrowseOnly=0 and IsInstalled=0 100
```

This command creates a windows update customizer.

### Example 2: Create a file customizer.
```powershell
New-AzImageBuilderTemplateCustomizerObject -FileCustomizer -Name 'filecus' -Destination 'c:\\buildArtifacts\\index.html' -SourceUri 'https://github.com/danielsollondon/azvmimagebuilder/blob/master/quickquickstarts/exampleArtifacts/buildArtifacts/index.html'
```

```output
Name    Destination                    Sha256Checksum SourceUri
----    -----------                    -------------- ---------
filecus c:\\buildArtifacts\\index.html                https://github.com/danielsollondon/azvmimagebuilder/blob/master/quickquickstarts/exampleArtifacts/buildArtifacts/index.html
```

This command creates a file customizer.

### Example 3: Create a powershell customizer.
```powershell
New-AzImageBuilderTemplateCustomizerObject -PowerShellCustomizer -Name settingUpMgmtAgtPath -RunElevated $false -Inline "mkdir c:\\buildActions", "echo Azure-Image-Builder-Was-Here  > c:\\buildActions\\buildActionsOutput.txt"
```

```output
Name                 Inline                                                                                                  RunAsSystem RunElevated ScriptUri Sha256Checksum ValidExitCode
----                 ------                                                                                                  ----------- ----------- --------- -------------- -------------
settingUpMgmtAgtPath {mkdir c:\\buildActions, echo Azure-Image-Builder-Was-Here  > c:\\buildActions\\buildActionsOutput.txt}             False
```

This command creates a powershell customizer.

### Example 4: Create a restart customizer.
```powershell
New-AzImageBuilderTemplateCustomizerObject -RestartCustomizer -Name 'restcus' -RestartCommand 'shutdown /f /r /t 0 /c \"packer restart\"' -RestartCheckCommand 'powershell -command "& {Write-Output "restarted."}"' -RestartTimeout '10m'
```

```output
Name    RestartCheckCommand                                 RestartCommand                            RestartTimeout
----    -------------------                                 --------------                            --------------
restcus powershell -command "& {Write-Output "restarted."}" shutdown /f /r /t 0 /c \"packer restart\" 10m
```

This command creates a restart customizer.

### Example 5: Create a shell customizer.
```powershell
New-AzImageBuilderTemplateCustomizerObject -ShellCustomizer -Name downloadBuildArtifacts -ScriptUri "https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh"
```

```output
Name                   Inline ScriptUri                                                                                                      Sha256Checksum
----                   ------ ---------                                                                                                      --------------
downloadBuildArtifacts        https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh
```

This command creates a shell customizer.

## PARAMETERS

### -Destination
The absolute path to a file (with nested directory structures already created) where the file (from sourceUri) will be uploaded to in the VM.

```yaml
Type: System.String
Parameter Sets: FileCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileCustomizer
Uploads files to VMs (Linux, Windows).
Corresponds to Packer file provisioner.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: FileCustomizer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Array of filters to select updates to apply.
Omit or specify empty array to use the default (no filter).
Refer to above link for examples and detailed description of this field.

```yaml
Type: System.String[]
Parameter Sets: WindowsUpdateCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Inline
Array of PowerShell commands to execute.

```yaml
Type: System.String[]
Parameter Sets: ShellCustomizer, PowerShellCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Friendly Name to provide context on what this customization step does.

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

### -PowerShellCustomizer
Runs the specified PowerShell on the VM (Windows).
Corresponds to Packer powershell provisioner.
Exactly one of 'scriptUri' or 'inline' can be specified.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PowerShellCustomizer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestartCheckCommand
Command to check if restart succeeded [Default: ''].

```yaml
Type: System.String
Parameter Sets: RestartCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestartCommand
Command to execute the restart [Default: 'shutdown /r /f /t 0 /c "packer restart"'].

```yaml
Type: System.String
Parameter Sets: RestartCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestartCustomizer
Reboots a VM and waits for it to come back online (Windows).
Corresponds to Packer windows-restart provisioner

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: RestartCustomizer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RestartTimeout
Restart timeout specified as a string of magnitude and unit, e.g.
'5m' (5 minutes) or '2h' (2 hours) [Default: '5m'].

```yaml
Type: System.String
Parameter Sets: RestartCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunAsSystem
If specified, the PowerShell script will be run with elevated privileges using the Local System user.
Can only be true when the runElevated field above is set to true.

```yaml
Type: System.Boolean
Parameter Sets: PowerShellCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunElevated
If specified, the PowerShell script will be run with elevated privileges.

```yaml
Type: System.Boolean
Parameter Sets: PowerShellCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScriptUri
URI of the PowerShell script to be run for customizing.
It can be a github link, SAS URI for Azure Storage, etc.

```yaml
Type: System.String
Parameter Sets: ShellCustomizer, PowerShellCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SearchCriterion
Criteria to search updates.
Omit or specify empty string to use the default (search all).
Refer to above link for examples and detailed description of this field.

```yaml
Type: System.String
Parameter Sets: WindowsUpdateCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sha256Checksum
SHA256 checksum of the file provided in the sourceUri field above.

```yaml
Type: System.String
Parameter Sets: FileCustomizer, ShellCustomizer, PowerShellCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShellCustomizer
Runs a shell script during the customization phase (Linux).
Corresponds to Packer shell provisioner.
Exactly one of 'scriptUri' or 'inline' can be specified.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ShellCustomizer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceUri
The URI of the file to be uploaded for customizing the VM.
It can be a github link, SAS URI for Azure Storage, etc.

```yaml
Type: System.String
Parameter Sets: FileCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateLimit
Maximum number of updates to apply at a time.
Omit or specify 0 to use the default (1000).

```yaml
Type: System.Int32
Parameter Sets: WindowsUpdateCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidExitCode
Valid exit codes for the PowerShell script.
[Default: 0].

```yaml
Type: System.Int32[]
Parameter Sets: PowerShellCustomizer
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowsUpdateCustomizer
Installs Windows Updates.
Corresponds to Packer Windows Update Provisioner (https://github.com/rgl/packer-provisioner-windows-update)

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: WindowsUpdateCustomizer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.ImageTemplateFileCustomizer

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.ImageTemplatePowerShellCustomizer

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.ImageTemplateRestartCustomizer

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.ImageTemplateShellCustomizer

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.ImageTemplateWindowsUpdateCustomizer

## NOTES

## RELATED LINKS
