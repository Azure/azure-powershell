---
external help file: Azs.Update.Admin-help.xml
Module Name: Azs.Update.Admin
online version: 
schema: 2.0.0
---

# Resume-AzsUpdateRun

## SYNOPSIS
Resumes a previously started update run that failed.

## SYNTAX

### UpdateRuns_Rerun (Default)
```
Resume-AzsUpdateRun -Name <String> [-Location <String>] [-ResourceGroupName <String>] -UpdateName <String>
 [-Wait] [<CommonParameters>]
```

### ResourceId
```
Resume-AzsUpdateRun [-Wait] -ResourceId <String> [<CommonParameters>]
```

## DESCRIPTION
Resumes a previously started update run that failed. 
Resumeed update runs will resume at the point they last failed.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsUpdateRun -Name 5173e9f4-3040-494f-b7a7-738a6331d55c -UpdateName Microsoft1.0.180305.1 | Resume-AzsUpdateRun
```

Resumes a previously started update run that failed.

## PARAMETERS

### -Location
The name of the update location.

```yaml
Type: String
Parameter Sets: UpdateRuns_Rerun
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Update run identifier.

```yaml
Type: String
Parameter Sets: UpdateRuns_Rerun
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group the resource is located under.

```yaml
Type: String
Parameter Sets: UpdateRuns_Rerun
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -UpdateName
{{Fill UpdateName Description}}

```yaml
Type: String
Parameter Sets: UpdateRuns_Rerun
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Wait
{{Fill Wait Description}}

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

