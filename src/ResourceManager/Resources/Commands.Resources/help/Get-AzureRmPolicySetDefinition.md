---
external help file: Microsoft.Azure.Commands.ResourceManager.Cmdlets.dll-Help.xml
Module Name: AzureRM.Resources
online version: 
schema: 2.0.0
---

# Get-AzureRmPolicySetDefinition

## SYNOPSIS
Gets policy set definitions.

## SYNTAX

### The list all policy set definitions parameter set. (Default)
```
Get-AzureRmPolicySetDefinition [-ApiVersion <String>] [-Pre] [<CommonParameters>]
```

### The policy set definition name parameter set.
```
Get-AzureRmPolicySetDefinition -Name <String> [-ApiVersion <String>] [-Pre] [<CommonParameters>]
```

### The policy set definition Id parameter set.
```
Get-AzureRmPolicySetDefinition -Id <String> [-ApiVersion <String>] [-Pre] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmPolicySetDefinition** cmdlet gets all the policy set definitions or a specific policy set definition identified by name or ID.

## EXAMPLES

### Example 1: Get all policy set definition
```
PS C:\>Get-AzureRmPolicySetDefinition
```

This command gets all the policy set definitions.

### Example 2: Get policy set definition by name
```
PS C:\>Get-AzureRmPolicySetDefinition -Name "VMPolicyDefinition"
```

This command gets the policy set definition named VMPolicyDefinition.

## PARAMETERS

### -ApiVersion
When set, indicates the version of the resource provider API to use.
If not specified, the API version is automatically determined as the latest available.

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
The fully qualified policy set definition Id, including the subscription.
e.g.
/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}

```yaml
Type: String
Parameter Sets: The policy set definition Id parameter set.
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The policy set definition name.

```yaml
Type: String
Parameter Sets: The policy set definition name parameter set.
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Pre
When set, indicates that the cmdlet should use pre-release API versions when automatically determining which version to use.

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

### System.String

## OUTPUTS

### System.Management.Automation.PSObject

## NOTES

## RELATED LINKS

