---
external help file: platyPSHelp-help.xml
online version: 
schema: 2.0.0
---

# Update-ServiceMarkdownHelp

## SYNOPSIS
This cmdlet will update markdown help files for each cmdlet in a given service, as well as regenerate the XML help (MAML) to reflect the information in these markdown files.

## SYNTAX

### ServiceManagement
```
Update-ServiceMarkdownHelp -Service <String> -BuildTarget <String> [-ServiceManagement] [<CommonParameters>]
```

### ResourceManager
```
Update-ServiceMarkdownHelp -Service <String> -BuildTarget <String> [-ResourceManager] [<CommonParameters>]
```

### Storage
```
Update-ServiceMarkdownHelp -BuildTarget <String> [-Storage] [<CommonParameters>]
```

### FullPath
```
Update-ServiceMarkdownHelp -PathToModule <String> -PathToCommandsFolder <String> [<CommonParameters>]
```

## DESCRIPTION
The Updated-ServiceMarkdownHelp cmdlet uses the platyPS module to update markdown help files for each cmdlet in a given service. This cmdlet will use the service module to update the markdown help files for each cmdlet.

This cmdlet should be run whenever changes have been made to the cmdlet source code (e.g., add/edit/remove parameters, add/remove cmdlets, etc.) or if documentation has been added to the markdown help files.

The existing XML help (MAML) will then be regenerated to contain the information found in this markdown help files. Anytime the markdown is edited, the XML help (MAML) will need to be regenerated to reflect these changes.

To ensure that the generated markdown help files have all of the necessary fields filled out, it is strongly recommended to run Validate-ServiceMarkdownHelp after running this cmdlet so the markdown can be appropriately edited.

## EXAMPLES

### -------------------------- Example 1: Updating markdown for an ARM service --------------------------
```
PS C:\> Update-ServiceMarkdownHelp -Service Profile -BuildTarget Debug -ResourceManager
```

This example will update markdown help files for all of the Profile cmdlets. It will import the Profile module from PATH_TO_REPO\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1. Then it will update the help files found on the same level as the XML help (MAML).

It will then regenerate the XML help (MAML) located at PATH_TO_REPO\src\ResourceManager\Profile\Commands.Profile\Microsoft.Azure.Commands.Profile.dll-Help.xml.

### -------------------------- Example 2: Updating markdown for Storage --------------------------
```
PS C:\> Update-ServiceMarkdownHelp -BuildTarget Debug -Storage
```

This example will update markdown help files for all of the Storage cmdlets. It will import the Storage module from PATH_TO_REPO\src\Package\Debug\Storage\Azure.Storage\Azure.Storage.psd1. Then it will update the help files found on the same level as the XML help (MAML).

It will also regenerate the XML help (MAML) located at PATH_TO_REPO\src\Storage\Commands.Storage\Microsoft.WindowsAzure.Commands.Storage.dll-Help.xml.

### -------------------------- Example 3: Updating markdown with specified paths --------------------------
```
PS C:\> $PathToModule = "C:\azure-powershell\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.TrafficManager\AzureRM.TrafficManager.psd1"
PS C:\> $PathToCommandsFolder = "C:\azure-powershell\src\ResourceManager\TrafficManager\Commands.TrafficManager2"
PS C:\> Update-ServiceMarkdownHelp -PathToModule $PathToModule -PathToCommandsFolder $PathToCommandsFolder
```

This example will update markdown help files for all of the TrafficManager cmdlets. The reason the ResourceManager parameter set is not used is because the commands folder path does not follow the format that this cmdlet is expecting: rather than ending in Commands.TrafficManager, it ends in Commands.TrafficManager2.

It will also regenerate the XML help (MAML) located at C:\azure-powershell\src\ResourceManager\TrafficManager\Commands.TrafficManager2\Microsoft.Azure.Commands.TrafficManager.dll-Help.xml.

## PARAMETERS

### -BuildTarget
Defines the build target (Debug or Release) for the service project that was built in order to obtain the updated local module.

```yaml
Type: String
Parameter Sets: ServiceManagement, ResourceManager, Storage
Aliases: 
Accepted values: Debug, Release

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PathToCommandsFolder
A path to the commands folder for the given service which contains the existing XML help (MAML), and will also contain the help folder with all of the markdown help files.

```yaml
Type: String
Parameter Sets: FullPath
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PathToModule
A path to the psd1 or dll file for the given service module.

```yaml
Type: String
Parameter Sets: FullPath
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceManager
Specifies that the service that help is being updated for is ARM.

```yaml
Type: SwitchParameter
Parameter Sets: ResourceManager
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Service
The name of the service that help is being updated for.

```yaml
Type: String
Parameter Sets: ServiceManagement, ResourceManager
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceManagement
Specifies that the service that help is being updated for is RDFE.

```yaml
Type: SwitchParameter
Parameter Sets: ServiceManagement
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Storage
Specifies that the service that help is being updated for is Storage.

```yaml
Type: SwitchParameter
Parameter Sets: Storage
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

