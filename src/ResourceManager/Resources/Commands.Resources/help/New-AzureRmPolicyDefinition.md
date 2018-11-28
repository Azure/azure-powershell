---
external help file: Microsoft.Azure.Commands.ResourceManager.Cmdlets.dll-Help.xml
Module Name: AzureRM.Resources
ms.assetid: 31F2AF24-488D-4CAF-A9C8-C8DAE76E031F
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.resources/new-azurermpolicydefinition
schema: 2.0.0
---

# New-AzureRmPolicyDefinition

## SYNOPSIS
Creates a policy definition.

## SYNTAX

### NameParameterSet (Default)
```
New-AzureRmPolicyDefinition -Name <String> [-DisplayName <String>] [-Description <String>] -Policy <String>
 [-Metadata <String>] [-Parameter <String>] [-Mode <PolicyDefinitionMode>] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-InformationAction <ActionPreference>]
 [-InformationVariable <String>] [<CommonParameters>]
```

### ManagementGroupNameParameterSet
```
New-AzureRmPolicyDefinition -Name <String> [-DisplayName <String>] [-Description <String>] -Policy <String>
 [-Metadata <String>] [-Parameter <String>] [-Mode <PolicyDefinitionMode>] -ManagementGroupName <String>
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

### SubscriptionIdParameterSet
```
New-AzureRmPolicyDefinition -Name <String> [-DisplayName <String>] [-Description <String>] -Policy <String>
 [-Metadata <String>] [-Parameter <String>] [-Mode <PolicyDefinitionMode>] -SubscriptionId <Guid>
 [-ApiVersion <String>] [-Pre] [-DefaultProfile <IAzureContextContainer>]
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmPolicyDefinition** cmdlet creates a policy definition that includes a policy rule in JavaScript Object Notation (JSON) format.

## EXAMPLES

### Example 1: Create a policy definition by using a policy file
```
{
   "if": {
      "field": "location",
      "notIn": ["eastus", "westus", "centralus"]
   },
   "then": {
      "effect": "audit"
   }
}
```

```
PS C:\> New-AzureRmPolicyDefinition -Name 'LocationDefinition' -Policy C:\LocationPolicy.json
```

This command creates a policy definition named LocationDefinition that contains the policy rule specified in C:\LocationPolicy.json. Example content for the LocationPolicy.json file is provided above.

### Example 2: Create a parameterized policy definition using inline parameters
```
{
   "if": {
      "field": "location",
      "notIn": "[parameters('listOfAllowedLocations')]"
   },
   "then": {
      "effect": "audit"
   }
}
```

```
PS C:\> New-AzureRmPolicyDefinition -Name 'LocationDefinition' -Policy C:\LocationPolicy.json -Parameter '{ "listOfAllowedLocations": { "type": "array" } }'
```

This command creates a policy definition named LocationDefinition that contains the policy rule specified in C:\LocationPolicy.json. The parameter definition for the policy rule is provided inline.

### Example 3: Create a policy definition inline in a management group
```
PS C:\> New-AzureRmPolicyDefinition -Name 'VMPolicyDefinition' -ManagementGroupName Dept42 -DisplayName 'Virtual Machine policy definition' -Policy '{"if":{"source":"action","equals":"Microsoft.Compute/virtualMachines/write"},"then":{"effect":"deny"}}'
```

This command creates a policy definition named VMPolicyDefinition in management group Dept42.
The command specifies the policy as a string in valid JSON format.

### Example 4: Create a policy definition inline with metadata
```
PS C:\> New-AzureRmPolicyDefinition -Name 'VMPolicyDefinition' -Metadata '{"Category":"Virtual Machine"}' -Policy '{"if":{"source":"action","equals":"Microsoft.Compute/virtualMachines/write"},"then":{"effect":"deny"}}'


Name               : VMPolicyDefinition
ResourceId         : /subscriptions/11111111-1111-1111-1111-111111111111/providers/Microsoft.Authorization/policyDefinitions/VMPolicyDefinition
ResourceName       : VMPolicyDefinition
ResourceType       : Microsoft.Authorization/policyDefinitions
SubscriptionId     : 11111111-1111-1111-1111-111111111111
Properties         : @{displayName=VMPolicyDefinition; policyType=Custom; mode=All; metadata=; policyRule=}
PolicyDefinitionId : /subscriptions/11111111-1111-1111-1111-111111111111/providers/Microsoft.Authorization/policyDefinitions/VMPolicyDefinition
```

This command creates a policy definition named VMPolicyDefinition with metadata indicating its category is "Virtual Machine".
The command specifies the policy as a string in valid JSON format.

## PARAMETERS

### -ApiVersion
Specifies the version of the resource provider API to use.
If you do not specify a version, this cmdlet uses the latest available version.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
Specifies a description for the policy definition.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplayName
Specifies a display name for the policy definition.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
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
Type: System.Management.Automation.ActionPreference
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
Type: System.String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementGroupName
The name of the management group of the new policy definition.

```yaml
Type: System.String
Parameter Sets: ManagementGroupNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Metadata
The metadata for policy definition. This can either be a path to a file name containing the metadata, or the metadata as string

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Mode
The mode of the policy definition

```yaml
Type: System.Nullable`1[Microsoft.Azure.Commands.ResourceManager.Cmdlets.Entities.Policy.PolicyDefinitionMode]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies a name for the policy definition.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Parameter
The parameters declaration for policy definition. This can either be a path to a file name containing the parameters declaration, or the parameters declaration as string.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Policy
Specifies a policy rule for the policy definition.
You can specify the path of a .json file or a string that contains the policy in JSON format.

```yaml
Type: System.String
Parameter Sets: (All)
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID of the new policy definition.

```yaml
Type: System.Nullable`1[System.Guid]
Parameter Sets: SubscriptionIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Get-AzureRmPolicyDefinition](./Get-AzureRmPolicyDefinition.md)

[Remove-AzureRmPolicyDefinition](./Remove-AzureRmPolicyDefinition.md)

[Set-AzureRmPolicyDefinition](./Set-AzureRmPolicyDefinition.md)


