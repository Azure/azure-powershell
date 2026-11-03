---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/Az.Chaos/new-azchaosscenarioparameterobject
schema: 2.0.0
---

# New-AzChaosScenarioParameterObject

## SYNOPSIS
Create an in-memory object for ScenarioParameter.

## SYNTAX

```
New-AzChaosScenarioParameterObject -Name <String> -Type <String> [-Default <String>] [-Description <String>]
 [-Required <Boolean>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ScenarioParameter.

## EXAMPLES

### Example 1: Create a required scenario parameter
```powershell
New-AzChaosScenarioParameterObject -Name 'region' -Type 'string' -Required $true -Description 'The Azure region to target.'
```

```output
Name   Type   Required
----   ----   --------
region string True
```

Creates an in-memory required scenario parameter.
Pass the result to `New-AzChaosScenario -Parameter`.

### Example 2: Create an optional scenario parameter with a default
```powershell
New-AzChaosScenarioParameterObject -Name 'duration' -Type 'string' -Required $false -Default 'PT10M'
```

```output
Name     Type   Required Default
----     ----   -------- -------
duration string False    PT10M
```

Creates an optional scenario parameter with a default value of ten minutes.

## PARAMETERS

### -Default
Default value for the parameter.

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

### -Description
Description of the parameter.

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

### -Name
The name of the parameter.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Required
Whether this parameter is required.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Parameter data type.

```yaml
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.ScenarioParameter

## NOTES

## RELATED LINKS

