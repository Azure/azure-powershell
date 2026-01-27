---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azpolicysetdefinition
schema: 2.0.0
---

# Get-AzPolicySetDefinition

## SYNOPSIS
Gets policy set definitions.

## SYNTAX

### Name (Default)
```
Get-AzPolicySetDefinition [-Name <String>] [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ManagementGroupName
```
Get-AzPolicySetDefinition [-Name <String>] -ManagementGroupName <String> [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### SubscriptionId
```
Get-AzPolicySetDefinition [-Name <String>] -SubscriptionId <String> [-Expand <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Version
```
Get-AzPolicySetDefinition [-Name <String>] [-Id <String>] [-ManagementGroupName <String>]
 [-SubscriptionId <String>] [-Expand <String>] -Version <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListVersion
```
Get-AzPolicySetDefinition [-Name <String>] [-Id <String>] [-ManagementGroupName <String>]
 [-SubscriptionId <String>] [-ListVersion] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Id
```
Get-AzPolicySetDefinition -Id <String> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Builtin
```
Get-AzPolicySetDefinition [-ManagementGroupName <String>] [-SubscriptionId <String>] [-Builtin]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Custom
```
Get-AzPolicySetDefinition [-ManagementGroupName <String>] [-SubscriptionId <String>] [-Custom]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicySetDefinition** cmdlet gets a collection of policy set definitions or a specific policy set definition identified by name or ID.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Builtin
Causes cmdlet to return only built-in policy definitions.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Builtin
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Custom
Causes cmdlet to return only custom policy definitions.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Custom
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -Expand
Comma-separated list of additional properties to be included in the response.
Supported values are 'LatestDefinitionVersion, EffectiveDefinitionVersion'.

```yaml
Type: System.String
Parameter Sets: Name, ManagementGroupName, SubscriptionId, Version, Id
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Id
The full Id of the policy definition to get.

```yaml
Type: System.String
Parameter Sets: Version, ListVersion
Aliases: ResourceId

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Id
Aliases: ResourceId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ListVersion
Causes cmdlet to return only custom policy definitions.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ListVersion
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ManagementGroupName
The name of the management group.

```yaml
Type: System.String
Parameter Sets: ManagementGroupName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Version, ListVersion, Builtin, Custom
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the policy definition to get.

```yaml
Type: System.String
Parameter Sets: Name, ManagementGroupName, SubscriptionId, Version, ListVersion
Aliases: PolicySetDefinitionName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: SubscriptionId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: Version, ListVersion, Builtin, Custom
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
The policy set definition version in #.#.# format.

```yaml
Type: System.String
Parameter Sets: Version
Aliases: PolicySetDefinitionVersion, PolicyDefinitionVersion

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.Management.Automation.SwitchParameter

### System.String

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicySetDefinition

## NOTES

## RELATED LINKS
