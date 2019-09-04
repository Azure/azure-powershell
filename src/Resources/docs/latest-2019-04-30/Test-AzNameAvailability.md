---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/test-aznameavailability
schema: 2.0.0
---

# Test-AzNameAvailability

## SYNOPSIS
Checks if the specified management group name is valid and unique

## SYNTAX

### CheckExpanded (Default)
```
Test-AzNameAvailability [-Name <String>] [-Type <Type>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Check
```
Test-AzNameAvailability -CheckNameAvailabilityRequest <ICheckNameAvailabilityRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Checks if the specified management group name is valid and unique

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -CheckNameAvailabilityRequest
Management group name availability check parameters.
To construct, see NOTES section for CHECKNAMEAVAILABILITYREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180301Preview.ICheckNameAvailabilityRequest
Parameter Sets: Check
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Name
the name to check for availability

```yaml
Type: System.String
Parameter Sets: CheckExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Type
fully qualified resource type which includes provider namespace

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.Type
Parameter Sets: CheckExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180301Preview.ICheckNameAvailabilityRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180301Preview.ICheckNameAvailabilityResult

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CHECKNAMEAVAILABILITYREQUEST <ICheckNameAvailabilityRequest>: Management group name availability check parameters.
  - `[Name <String>]`: the name to check for availability
  - `[Type <Type?>]`: fully qualified resource type which includes provider namespace

## RELATED LINKS

