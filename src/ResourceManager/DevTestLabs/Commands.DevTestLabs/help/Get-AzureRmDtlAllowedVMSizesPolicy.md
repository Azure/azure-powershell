---
external help file: Microsoft.Azure.Commands.DevTestLabs.dll-Help.xml
ms.assetid: 869167AA-54F8-4A1C-AC08-5555A63EE1BC
online version: 
schema: 2.0.0
---

# Get-AzureRmDtlAllowedVMSizesPolicy

## SYNOPSIS
Gets the allowed virtual machine sizes policy of a lab in DevTest Labs.

## SYNTAX

```
Get-AzureRmDtlAllowedVMSizesPolicy [-LabName] <String> [-ResourceGroupName] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmDtlAllowedVMSizesPolicy** cmdlet gets the allowed virtual machine sizes policy, which allows you to specify a list of virtual machine sizes allowed in the lab.
The cmdlet returns the enabled or disabled status of the policy and a list of all the allowed virtual machine sizes that you have set in the specified policy.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -LabName
Specifies the name of the lab for which this cmdlet gets virtual machines size policy.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group that the lab belongs to.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.DevTestLabs.Models.PSPolicy
This cmdlet returns the policy that specifies the list of virtual machine sizes allowed in the lab.

## NOTES

## RELATED LINKS

[Set-AzureRmDtlAllowedVMSizesPolicy](./Set-AzureRmDtlAllowedVMSizesPolicy.md)

[Azure Development Test Lab Cmdlets](./AzureRM.DevTestLabs.md)


