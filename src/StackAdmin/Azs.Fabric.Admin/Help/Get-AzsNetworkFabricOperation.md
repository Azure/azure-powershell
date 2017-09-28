---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsNetworkFabricOperation

## SYNOPSIS
Get the status of a network fabric operation.

## SYNTAX

```
Get-AzsNetworkFabricOperation -Provider <String> -Location <String> -NetworkOperationResult <String>
```

## DESCRIPTION
Get the status of a network fabric operation.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsComputeFabricOperation -Location "local" -Provider "Microsoft.Fabric.Admin" -NetworkOperationResult "fdcdefb6-6fd0-402c-8b0c-5765b8fc4dc1"

ProvisioningState
-----------------------
Succeeded
```

Get the status of a fabric network operation.

## PARAMETERS

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

### -NetworkOperationResult
Id of a network fabric operation.

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

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Fabric.Admin.Models.OperationStatus

## NOTES

## RELATED LINKS

