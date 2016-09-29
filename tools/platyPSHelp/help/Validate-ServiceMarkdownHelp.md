---
external help file: platyPSHelp-help.xml
online version: 
schema: 2.0.0
---

# Validate-ServiceMarkdownHelp

## SYNOPSIS
This cmdlet will validate that the markdown help for each cmdlet in a service has all of the necessary sections filled out.

## SYNTAX

### ServiceManagement
```
Validate-ServiceMarkdownHelp -Service <String> -PathToRepo <String> [-ServiceManagement] [<CommonParameters>]
```

### ResourceManager
```
Validate-ServiceMarkdownHelp -Service <String> -PathToRepo <String> [-ResourceManager] [<CommonParameters>]
```

### Storage
```
Validate-ServiceMarkdownHelp -PathToRepo <String> [-Storage] [<CommonParameters>]
```

### FullPath
```
Validate-ServiceMarkdownHelp -PathToHelp <String> -ModuleName <String> [<CommonParameters>]
```

## DESCRIPTION
The Validate-ServiceMarkdownHelp cmdlet can be used whenever markdown help is created or updated for cmdlets to make sure that the necessary sections of the help are filled out. It is recommended that this cmdlet be run after New-ServiceMarkdownHelp or Update-ServiceMarkdownHelp is run.

This cmdlet checks to see if the following categories are filled out:
- Synopsis
- Description
- Examples
- Parameter descriptions
- Outputs

For each cmdlet in the service module, information about the missing help will be collected and displayed in the following format:

==========

File: Some-Cmdlet.md

-- No description found
-- No examples found

==========

If any cmdlet is found to be missing help, Validate-ServiceMarkdownHelp will thrown an error.

## EXAMPLES

### -------------------------- Example 1: Validating help for an ARM service --------------------------
```
PS C:\> Validate-ServiceMarkdownHelp -Service Profile -PathToRepo C:\azure-powershell -ResourceManager
```

This example will validate the markdown help for the Profile cmdlets. It will find the help folder containing all of the markdown help and iterate over those files, checking if the necessary sections are filled out to completion.

### -------------------------- Example 2: Validating help for Storage --------------------------
```
PS C:\> Validate-ServiceMarkdownHelp -PathToRepo C:\azure-powershell -Storage
```

This example will validate the markdown help for the Storage cmdlets. It will find the help folder containing all of the markdown help and iterate over those files, checking if the necessary sections are filled out to completion.

### -------------------------- Example 3: Validating help with specified paths --------------------------
```
PS C:\> $PathToHelp = "C:\azure-powershell\src\ResourceManager\TrafficManager\Commands.TrafficManager2\help"
PS C:\> $ModuleName = "AzureRM.TrafficManager"
PS C:\> Validate-ServiceMarkdownHelp -PathToHelp $PathToHelp -ModuleName $ModuleName
```

This example will validate the markdown help for the TrafficManager cmdlets. The reason the ResourceManager parameter set is not used is because the help folder path does not follow the format that this cmdlet is expecting: rather than ending in Commands.TrafficManager\help, it ends in Commands.TrafficManager2\help.

## PARAMETERS

### -ModuleName
The name of the service module whose cmdlets are being validated.

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

### -PathToHelp
A path to the help folder containing all of the markdown help files for the given service.

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

### -PathToRepo
A path to the root of the azure-powershell repository that has been cloned.

```yaml
Type: String
Parameter Sets: ServiceManagement, ResourceManager, Storage
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceManager
Specifies that the service that help is being validated for is ARM.

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
The name of the service that help is being validated for.

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
Specifies that the service that help is being validated for is RDFE.

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
Specifies that the service that help is being validated for is Storage.

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

