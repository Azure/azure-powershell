---
external help file: Microsoft.Azure.PowerShell.Cmdlets.PolicyInsights.dll-Help.xml
Module Name: Az.PolicyInsights
online version: https://docs.microsoft.com/powershell/module/az.policyinsights/get-azpolicymetadata
schema: 2.0.0
---

# Get-AzPolicyMetadata

## SYNOPSIS
Gets Policy Metadata resources

## SYNTAX

```
Get-AzPolicyMetadata [-Name <String>] [-Top <Int32>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzPolicyRemediation** cmdlet gets all policy metadata resources or a particular policy metadata resource.

## EXAMPLES

### Example 1: Get all policy metadata resources
```powershell
PS C:\> Get-AzPolicyMetadata
```

This command gets all policy metadata resources

### Example 2: Get a collection of 10 policy metadata resources
```powershell
PS C:\> Get-AzPolicyMetadata -Top 10
```

This command gets a collection of 10 policy metadata resources

### Example 3: Get a single policy metadata resource with the name 'ACF1348'
```powershell
PS C:\> Get-AzPolicyMetadata -Name ACF1348
```

This command gets a single policy metadata resource with the name 'ACF1348'

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Resource name.

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

### -Top
Maximum number of policy metadata resources to return.

```yaml
Type: System.Int32
Parameter Sets: (All)
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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.PolicyInsights.Models.PSPolicyMetadata

## NOTES

## RELATED LINKS
