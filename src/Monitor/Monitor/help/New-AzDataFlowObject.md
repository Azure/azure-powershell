---
external help file: Az.DataCollectionRule.psm1-help.xml
Module Name: Az.Monitor
online version: https://learn.microsoft.com/powershell/module/Az.Monitor/new-azdataflowobject
schema: 2.0.0
---

# New-AzDataFlowObject

## SYNOPSIS
Create an in-memory object for DataFlow.

## SYNTAX

```
New-AzDataFlowObject [-BuiltInTransform <String>] [-Destination <String[]>] [-OutputStream <String>]
 [-Stream <String[]>] [-TransformKql <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DataFlow.

## EXAMPLES

### Example 1: Create a data flow object
```powershell
New-AzDataFlowObject -Stream Microsoft-Perf,Microsoft-Syslog,Microsoft-WindowsEvent -Destination eastusWorkSpace
```

```output
BuiltInTransform : 
Destination      : {eastusWorkSpace}
OutputStream     : 
Stream           : {Microsoft-Perf, Microsoft-Syslog, Microsoft-WindowsEvent}
TransformKql     :
```

This command creates a data flow object.

## PARAMETERS

### -BuiltInTransform
The builtIn transform to transform stream data.

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

### -Destination
List of destinations for this data flow.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OutputStream
The output stream of the transform.
Only required if the transform changes data to a different stream.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Stream
List of streams for this data flow.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TransformKql
The KQL query to transform stream data.

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

### Microsoft.Azure.PowerShell.Cmdlets.Monitor.DataCollection.Models.DataFlow

## NOTES

## RELATED LINKS
