---
external help file: Microsoft.Azure.Commands.ResourceManager.Cmdlets.dll-Help.xml
ms.assetid: 6396AEC3-DFE6-45DA-BCF4-69C55C5D051B
online version: 
schema: 2.0.0
---

# Get-AzureRmPolicyDefinition

## SYNOPSIS
Gets policy definitions.

## SYNTAX

### The list all policy definitions parameter set. (Default)
```
Get-AzureRmPolicyDefinition [-ApiVersion <String>] [-Pre] [-InformationAction <ActionPreference>]
 [-InformationVariable <String>] [<CommonParameters>]
```

### The policy definition name parameter set.
```
Get-AzureRmPolicyDefinition -Name <String> [-ApiVersion <String>] [-Pre]
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

### The policy definition Id parameter set.
```
Get-AzureRmPolicyDefinition -Id <String> [-ApiVersion <String>] [-Pre] [-InformationAction <ActionPreference>]
 [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmPolicyDefinition** cmdlet gets all the policy definitions or a specific policy definition identified by name or ID.

## EXAMPLES

### Example 1: Get all policy definition
```
PS C:\>Get-AzureRmPolicyDefinition
```

This command gets all the policy definitions.

### Example 2: Get policy definition by name
```
PS C:\>Get-AzureRmPolicyDefinition -Name "VMPolicyDefinition"
```

This command gets the policy definition named VMPolicyDefinition.

## PARAMETERS

### -ApiVersion
Specifies the version of the resource provider API to use.
If you do not specify a version, this cmdlet uses the latest available version.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Specifies the fully qualified resource ID for the policy definition that this cmdlet gets.

```yaml
Type: String
Parameter Sets: The policy definition Id parameter set.
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of the policy definition that this cmdlet gets.

```yaml
Type: String
Parameter Sets: The policy definition name parameter set.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Pre
Indicates that this cmdlet considers pre-release API versions when it automatically determines which version to use.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[New-AzureRmPolicyDefinition](./New-AzureRmPolicyDefinition.md)

[Remove-AzureRmPolicyDefinition](./Remove-AzureRmPolicyDefinition.md)

[Set-AzureRmPolicyDefinition](./Set-AzureRmPolicyDefinition.md)


