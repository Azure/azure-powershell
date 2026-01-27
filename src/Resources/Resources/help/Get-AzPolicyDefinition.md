---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azpolicydefinition
schema: 2.0.0
---

# Get-AzPolicyDefinition

## SYNOPSIS
Gets policy set definitions.

## SYNTAX

### Name (Default)
```
Get-AzPolicyDefinition [-Name <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ManagementGroupName
```
Get-AzPolicyDefinition [-Name <String>] -ManagementGroupName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### SubscriptionId
```
Get-AzPolicyDefinition [-Name <String>] -SubscriptionId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Version
```
Get-AzPolicyDefinition [-Name <String>] [-Id <String>] [-ManagementGroupName <String>]
 [-SubscriptionId <String>] -Version <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListVersion
```
Get-AzPolicyDefinition [-Name <String>] [-Id <String>] [-ManagementGroupName <String>]
 [-SubscriptionId <String>] [-ListVersion] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Id
```
Get-AzPolicyDefinition -Id <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Builtin
```
Get-AzPolicyDefinition [-ManagementGroupName <String>] [-SubscriptionId <String>] [-Builtin]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Custom
```
Get-AzPolicyDefinition [-ManagementGroupName <String>] [-SubscriptionId <String>] [-Custom]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Static
```
Get-AzPolicyDefinition [-ManagementGroupName <String>] [-SubscriptionId <String>] [-Static]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicyDefinition** cmdlet gets a collection of policy set definitions or a specific policy set definition identified by name or ID.

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
Parameter Sets: Version, ListVersion, Builtin, Custom, Static
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
Aliases: PolicyDefinitionName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Static
Causes cmdlet to return only static policy definitions.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Static
Aliases:

Required: True
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
Parameter Sets: Version, ListVersion, Builtin, Custom, Static
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Version
The policy definition version in #.#.# format.

```yaml
Type: System.String
Parameter Sets: Version
Aliases: PolicyDefinitionVersion

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

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyDefinition

## NOTES

## RELATED LINKS
