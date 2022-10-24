---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Get-AzEventGridPartnerConfiguration

## SYNOPSIS
Gets the details of an Event Grid partner configuration, or gets a lost of partner configurations in the current Azure subscription.

## SYNTAX

### ResourceGroupNameParameterSet (Default)
```
Get-AzEventGridPartnerConfiguration [-ResourceGroupName <String>] [-ODataQuery <String>] [-Top <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### NextLinkParameterSet
```
Get-AzEventGridPartnerConfiguration -NextLink <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
 The Get-AzEventGridPartnerConfiguration cmdlet gets the details of a partner configuration under a specified resource group, or a list of partner configurations in the current Azure subscriptions.
 If the resource group name is provided, the details of a single Event Grid partner configuration is returned.
 If the resource group name is not provided, a list of partner configurations is returned.

## EXAMPLES

### Example 1
```powershell
Get-AzEventGridPartnerConfiguration -ResourceGroupName ResourceGroup1
```

Gets the details of the partner configuration in resource group \`ResourceGroup1\`.

### Example 2
```powershell
Get-AzEventGridPartnerConfiguration -Top 5
```

Lists the details of the first five partner configurations in the current Azure subscription.

## PARAMETERS

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

### -NextLink
The link for the next page of resources to be obtained.
This value is obtained with the first Get-AzEventGrid cmdlet call when more resources are still available to be queried.

```yaml
Type: String
Parameter Sets: NextLinkParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ODataQuery
The OData query used for filtering the list results.
Filtering is currently allowed on the Name property only.The supported operations include: CONTAINS, eq (for equal), ne (for not equal), AND, OR and NOT.

```yaml
Type: String
Parameter Sets: ResourceGroupNameParameterSet
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
Type: String
Parameter Sets: ResourceGroupNameParameterSet
Aliases:

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
Type: Int32
Parameter Sets: ResourceGroupNameParameterSet
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

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerConfigurationListInstance

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerConfiguration

## NOTES

## RELATED LINKS
