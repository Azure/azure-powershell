---
external help file:
Module Name: Az.FluidRelay
online version: https://docs.microsoft.com/powershell/module/az.FluidRelay/new-azfluidrelayregeneratekeyrequestobject
schema: 2.0.0
---

# New-AzFluidRelayRegenerateKeyRequestObject

## SYNOPSIS
Create an in-memory object for RegenerateKeyRequest.

## SYNTAX

```
New-AzFluidRelayRegenerateKeyRequestObject -KeyName <KeyName> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RegenerateKeyRequest.

## EXAMPLES

### Example 1: Create a RegenerateKeyName object for FluidRelayServerKey.
```powershell
New-AzFluidRelayRegenerateKeyRequestObject -KeyName 'key1'
```

```output
KeyName
-------
key1
```

Create a RegenerateKeyName object for FluidRelayServerKey.

## PARAMETERS

### -KeyName
The key to regenerate.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Support.KeyName
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.Api20220421.RegenerateKeyRequest

## NOTES

ALIASES

## RELATED LINKS

