---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-AzMLWorkspaceJobServiceObject
schema: 2.0.0
---

# New-AzMLWorkspaceJobServiceObject

## SYNOPSIS
Create an in-memory object for JobService.

## SYNTAX

```
New-AzMLWorkspaceJobServiceObject [-Endpoint <String>] [-Port <Int32>] [-Property <IJobServiceProperties>]
 [-Type <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for JobService.

## EXAMPLES

### Example 1: Create an in-memory object for JobService
```powershell
New-AzMLWorkspaceJobServiceObject
```

Create an in-memory object for JobService

## PARAMETERS

### -Endpoint
Url for endpoint.

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

### -Port
Port for endpoint.

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

### -Property
Additional properties to set on the endpoint.
To construct, see NOTES section for PROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.IJobServiceProperties
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Endpoint type.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.JobService

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PROPERTY <IJobServiceProperties>`: Additional properties to set on the endpoint.
  - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

