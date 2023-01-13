---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Batch.dll-Help.xml
Module Name: Az.Batch
online version: https://docs.microsoft.com/powershell/module/az.batch/get-azbatchsupportedvirtualmachinesku
schema: 2.0.0
---

# Get-AzBatchSupportedVirtualMachineSku

## SYNOPSIS
Gets the list of Batch supported Virtual Machine VM sizes available at the given location.

## SYNTAX

```
Get-AzBatchSupportedVirtualMachineSku [-Location] <String> [[-MaxResultCount] <Int32>] [[-Filter] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION

## EXAMPLES

### Example 1 Get supported skus for a region
```powershell
Get-AzBatchSupportedVirtualMachineSku eastus
```

```output
Name               FamilyName            Capabilities
----               ----------            ------------
Basic_A1           basicAFamily          {MaxResourceVolumeMB, OSVhdSizeMB, vCPUs, MemoryPreservingMaintenanceSupporte...
Basic_A2           basicAFamily          {MaxResourceVolumeMB, OSVhdSizeMB, vCPUs, MemoryPreservingMaintenanceSupporte...
Basic_A3           basicAFamily          {MaxResourceVolumeMB, OSVhdSizeMB, vCPUs, MemoryPreservingMaintenanceSupporte...
...
```

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

### -Filter
OData filter expression.
Valid properties for filtering are "familyName".

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
The region to get the supported SKUs from.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaxResultCount
The maximum number of items to return in the response.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Batch.Models.PSSupportedSku

## NOTES

## RELATED LINKS
