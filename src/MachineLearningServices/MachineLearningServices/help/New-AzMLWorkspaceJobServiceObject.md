---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/Az.MachineLearningServices/new-azmlworkspacejobserviceobject
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IJobServiceProperties
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.JobService

## NOTES

## RELATED LINKS
