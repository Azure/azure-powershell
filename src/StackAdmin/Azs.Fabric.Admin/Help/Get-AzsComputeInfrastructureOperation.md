---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsComputeInfrastructureOperation

## SYNOPSIS
Get the status of a compute fabric operation.

## SYNTAX

```
Get-AzsComputeInfrastructureOperation -ComputeOperationResult <String> -Provider <String> -Location <String>
 [<CommonParameters>]
```

## DESCRIPTION
Get the status of a compute fabric operation.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsComputeInfrastructureOperation -Location "local" -Provider "Microsoft.Fabric.Admin" -ComputeOperationResult "fdcdefb6-6fd0-402c-8b0c-5765b8fc4dc1"

ProvisioningState
-----------------------
Succeeded
```

Get the status of a compute operation.  On failure an exception is thrown.

## PARAMETERS

### -ComputeOperationResult
Id of a compute fabric operation.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Provider
Name of the provider.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Fabric.Admin.Models.OperationStatus

## NOTES

## RELATED LINKS

