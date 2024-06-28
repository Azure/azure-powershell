---
external help file:
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
Get-AzPolicyDefinition [-Name <String>] [-BackwardCompatible] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Builtin
```
Get-AzPolicyDefinition -Builtin [-ManagementGroupName <String>] [-SubscriptionId <String>]
 [-BackwardCompatible] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Custom
```
Get-AzPolicyDefinition -Custom [-ManagementGroupName <String>] [-SubscriptionId <String>]
 [-BackwardCompatible] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Id
```
Get-AzPolicyDefinition -Id <String> [-BackwardCompatible] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListVersion
```
Get-AzPolicyDefinition -ListVersion [-Id <String>] [-Name <String>] [-BackwardCompatible]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ManagementGroupName
```
Get-AzPolicyDefinition -ManagementGroupName <String> [-Name <String>] [-BackwardCompatible]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Static
```
Get-AzPolicyDefinition -Static [-ManagementGroupName <String>] [-SubscriptionId <String>]
 [-BackwardCompatible] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### SubscriptionId
```
Get-AzPolicyDefinition -SubscriptionId <String> [-Name <String>] [-BackwardCompatible]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Version
```
Get-AzPolicyDefinition -Version <String> [-Id <String>] [-Name <String>] [-BackwardCompatible]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicyDefinition** cmdlet gets a collection of policy set definitions or a specific policy set definition identified by name or ID.

## EXAMPLES

### Example 1: Get all policy definitions
```powershell
Get-AzPolicyDefinition
```

This command gets all the policy definitions.

### Example 2: Get policy definition from current subscription by name
```powershell
Get-AzPolicyDefinition -Name 'VMPolicyDefinition'
```

This command gets the policy definition named VMPolicyDefinition from the current default subscription.

### Example 3: Get policy definition from management group by name
```powershell
Get-AzPolicyDefinition -Name 'VMPolicyDefinition' -ManagementGroupName 'Dept42'
```

This command gets the policy definition named VMPolicyDefinition from the management group named Dept42.

### Example 4: Get all built-in policy definitions from subscription
```powershell
Get-AzPolicyDefinition -SubscriptionId '3bf44b72-c631-427a-b8c8-53e2595398ca' -Builtin
```

This command gets all built-in policy definitions from the subscription with ID 3bf44b72-c631-427a-b8c8-53e2595398ca.

### Example 5: Get policy definitions from a given category
```powershell
Get-AzPolicyDefinition | Where-Object {$_.Properties.metadata.category -eq 'Tags'}
```

This command gets all policy definitions in the category **Tags**.

### Example 6: Get the display name, description, policy type, and metadata of all policy definitions formatted as a list
```powershell
Get-AzPolicyDefinition | Select-Object -Property DisplayName, Description, PolicyType, Metadata | Format-List
```

This command is useful when you need to find the reader-friendly **DisplayName** property of an Azure
Policy definition.
You can parse the **Metadata** property to discover the policy definition's version number and category assignment.

### Example 7: [Backcompat] Get the display name, description, policy type, and metadata of all policy definitions formatted as a list
```powershell
Get-AzPolicyDefinition -BackwardCompatible | Select-Object -ExpandProperty properties | Select-Object -Property DisplayName, Description, PolicyType, Metadata | Format-List
```

This command is useful when you need to find the reader-friendly **DisplayName** property of an Azure
Policy definition.
You can parse the **Metadata** property to discover the policy definition's version number and category assignment.

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
Parameter Sets: Builtin, Custom, ManagementGroupName, Static
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
Parameter Sets: Builtin, Custom, Static, SubscriptionId
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

