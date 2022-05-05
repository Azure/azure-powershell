---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Get-AzEventGridSystemTopic

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### ResourceGroupNameParameterSet (Default)
```
Get-AzEventGridSystemTopic [-ResourceGroupName <String>] [-ODataQuery <String>] [-Top <Int32>]
 [-NextLink <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SystemTopicNameParameterSet
```
Get-AzEventGridSystemTopic [-ResourceGroupName <String>] [-Name <String>] [-ODataQuery <String>] [-Top <Int32>]
 [-NextLink <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
EventGrid topic name.

```yaml
Type: System.String
Parameter Sets: SystemTopicNameParameterSet
Aliases: SystemTopicName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NextLink
The link for the next page of resources to be obtained.
This value is obtained with the first Get-AzEventGrid cmdlet call when more resources are still available to be queried.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ODataQuery
The OData query used for filtering the list results.
Filtering is currently allowed on the Name property only.The supported operations include: CONTAINS, eq (for equal), ne (for not equal), AND, OR and NOT.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceGroup

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Top
The maximum number of resources to be obtained.
Valid value is between 1 and 100.
If top value is specified and more results are still available, the result will contain a link to the next page to be queried in NextLink.
If the Top value is not specified, the full list of resources will be returned at once.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSSystemTopic

### Microsoft.Azure.Commands.EventGrid.Models.PSSytemTopicListInstance

## NOTES

## RELATED LINKS
