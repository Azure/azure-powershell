---
external help file:
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
Get-AzPolicySetDefinition [-Name <String>] [-BackwardCompatible] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Builtin
```
Get-AzPolicySetDefinition -Builtin [-ManagementGroupName <String>] [-SubscriptionId <String>]
 [-BackwardCompatible] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Custom
```
Get-AzPolicySetDefinition -Custom [-ManagementGroupName <String>] [-SubscriptionId <String>]
 [-BackwardCompatible] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Id
```
Get-AzPolicySetDefinition -Id <String> [-BackwardCompatible] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListVersion
```
Get-AzPolicySetDefinition -ListVersion [-Id <String>] [-Name <String>] [-BackwardCompatible]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ManagementGroupName
```
Get-AzPolicySetDefinition -ManagementGroupName <String> [-Name <String>] [-BackwardCompatible]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### SubscriptionId
```
Get-AzPolicySetDefinition -SubscriptionId <String> [-Name <String>] [-BackwardCompatible]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Version
```
Get-AzPolicySetDefinition -Version <String> [-Id <String>] [-Name <String>] [-BackwardCompatible]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicySetDefinition** cmdlet gets a collection of policy set definitions or a specific policy set definition identified by name or ID.

## EXAMPLES

### Example 1: Get all policy set definitions
```powershell
Get-AzPolicySetDefinition
```

This command gets all the policy set definitions.

### Example 2: Get policy set definition from current subscription by name
```powershell
Get-AzPolicySetDefinition -Name 'VMPolicySetDefinition'
```

This command gets the policy set definition named VMPolicySetDefinition from the current default subscription.

### Example 3: Get policy set definition from subscription by name
```powershell
Get-AzPolicySetDefinition -Name 'VMPolicySetDefinition' -subscriptionId '3bf44b72-c631-427a-b8c8-53e2595398ca'
```

This command gets the policy definition named VMPolicySetDefinition from the subscription with ID 3bf44b72-c631-427a-b8c8-53e2595398ca.

### Example 4: Get all custom policy set definitions from management group
```powershell
Get-AzPolicySetDefinition -ManagementGroupName 'Dept42' -Custom
```

This command gets all custom policy set definitions from the management group named Dept42.

### Example 5: Get policy set definitions from a given category
```powershell
Get-AzPolicySetDefinition | Where-Object {$_.metadata.category -eq "Virtual Machine"}
```

This command gets all policy set definitions in category "Virtual Machine".

### Example 6: [Backcompat] Get policy set definitions from a given category
```powershell
Get-AzPolicySetDefinition -BackwardCompatible | Where-Object {$_.Properties.metadata.category -eq "Virtual Machine"}
```

This command gets all policy set definitions in category "Virtual Machine".

## PARAMETERS

### -BackwardCompatible
Causes cmdlet to return artifacts using legacy format placing policy-specific properties in a property bag object.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Id
The full Id of the policy definition to get.

```yaml
Type: System.String
Parameter Sets: Id, ListVersion, Version
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
Parameter Sets: Builtin, Custom, ManagementGroupName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the policy definition to get.

```yaml
Type: System.String
Parameter Sets: ListVersion, ManagementGroupName, Name, SubscriptionId, Version
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
Parameter Sets: Builtin, Custom, SubscriptionId
Aliases:

Required: True
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
Aliases: PolicySetDefinitionVersion

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

