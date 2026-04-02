---
external help file: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.dll-help.xml
Module Name: Az.PolicyInsights
online version: https://learn.microsoft.com/powershell/module/az.policyinsights/get-azpolicymetadata
schema: 2.0.0
---

# Get-AzPolicyMetadata

## SYNOPSIS
Gets Policy Metadata resources.

## SYNTAX

### List (Default)
```
Get-AzPolicyMetadata [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByName
```
Get-AzPolicyMetadata -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicyMetadata** cmdlet gets all policy metadata resources or a particular policy metadata resource.

## EXAMPLES

### Example 1: Get all policy metadata resources
```powershell
Get-AzPolicyMetadata
```

This command gets all policy metadata resources.

### Example 2: Get a collection of 10 policy metadata resources
```powershell
Get-AzPolicyMetadata -Top 10
```

This command gets a collection of 10 policy metadata resources.

### Example 3: Get a single policy metadata resource with the name 'ACF1348'
```powershell
Get-AzPolicyMetadata -Name ACF1348
```

This command gets a single policy metadata resource with the name 'ACF1348'.

It will include a bit more info about the resource than collection calls.

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

### -Name
The name of the policy metadata resource.
Returns additional information about the specified policy metadata resource.

```yaml
Type: System.String
Parameter Sets: GetByName
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Maximum number of records to return.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.Models.IPolicyMetadata

## NOTES

## RELATED LINKS
