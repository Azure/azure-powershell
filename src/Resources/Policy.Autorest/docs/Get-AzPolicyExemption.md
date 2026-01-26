---
external help file:
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azpolicyexemption
schema: 2.0.0
---

# Get-AzPolicyExemption

## SYNOPSIS
Gets policy exemptions.

## SYNTAX

### Name (Default)
```
Get-AzPolicyExemption [-Name <String>] [-PolicyAssignmentIdFilter <String>] [-Scope <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Id
```
Get-AzPolicyExemption -Id <String> [-PolicyAssignmentIdFilter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### IncludeDescendent
```
Get-AzPolicyExemption -IncludeDescendent [-Scope <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicyExemption** cmdlet gets a collection of policy exemptions or a specific policy exemption identified by name or ID.

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
The fully qualified resource Id of the exemption.

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

### -IncludeDescendent
Causes the list of returned policy exemptions to include all exemptions related to the given scope, including those from ancestor scopes and those from descendent scopes.
If not provided, only exemptions at and above the given scope are included.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: IncludeDescendent
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the policy exemption.

```yaml
Type: System.String
Parameter Sets: Name
Aliases: PolicyExemptionName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PolicyAssignmentIdFilter
The policy assignment id filter.

```yaml
Type: System.String
Parameter Sets: Id, Name
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Scope
The scope of the policy exemption.
Valid scopes are: management group (format: '/providers/Microsoft.Management/managementGroups/{managementGroup}'), subscription (format: '/subscriptions/{subscriptionId}'), resource group (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}', or resource (format: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/[{parentResourcePath}/]{resourceType}/{resourceName}'

```yaml
Type: System.String
Parameter Sets: IncludeDescendent, Name
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Policy.Models.IPolicyExemption

## NOTES

## RELATED LINKS

