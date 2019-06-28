---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataBox.dll-Help.xml
Module Name: Az.DataBox
online version:
schema: 2.0.0
---

# Get-AzDataBoxJobs

## SYNOPSIS
Gets information about DataBox Jobs

## SYNTAX

### ListParameterSet (Default)
```
Get-AzDataBoxJobs [-ResourceGroupName <String>] [-Completed] [-CompletedWithErrors] [-Cancelled] [-Aborted]
[<CommonParameters>]
```

### GetByNameParameterSet
```
Get-AzDataBoxJobs -ResourceGroupName <String> -Name <String>
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzDataBoxJobs** cmdlet gets information about databox jobs in an Azure subscription.
If you specify the Resource Group, this cmdlet gets all the databox jobs under that resource group. If you specify the Name of the job along with the resource group name, this cmdlet gets information about that specific databox job.
If you do not specify anything other than subscription id, this cmdlet gets information about all of the databox jobs under that subscription.


## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Aborted
{{ Fill Aborted Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Cancelled
{{ Fill Cancelled Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Completed
{{ Fill Completed Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CompletedWithErrors
{{ Fill CompletedWithErrors Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Detatiled
{{ Fill Detatiled Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
{{ Fill Name Description }}

```yaml
Type: String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
{{ Fill ResourceGroupName Description }}

```yaml
Type: String
Parameter Sets: ListParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: GetByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
{{ Fill ResourceId Description }}

```yaml
Type: String
Parameter Sets: GetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Management.DataBox.Models.JobResource

## NOTES

## RELATED LINKS
