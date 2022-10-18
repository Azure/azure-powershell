---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Get-AzEventGridChannel

## SYNOPSIS
Gets the details of an Event Grid channel or gets a list of all Event Grid channels in a given partner namespace.

## SYNTAX

### ChannelListByPartnerNamespaceParameterSet (Default)
```
Get-AzEventGridChannel -ResourceGroupName <String> -PartnerNamespaceName <String> [-ODataQuery <String>]
 [-Top <Int32>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ChannelNameParameterSet
```
Get-AzEventGridChannel -ResourceGroupName <String> -PartnerNamespaceName <String> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### NextLinkParameterSet
```
Get-AzEventGridChannel -NextLink <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzEventGridChannel cmdlet gets either the detauls of a specified Event Grid channel, or a list of all Event Grid channels in the specified Event Grid partner namespace.
If the channel name is provided, the details of a single Event Grid channel is returned.
If the channel name is not provided, a list of domains is returned. The number of elements returned in this list is controlled by the Top parameter. If the Top value is not specified or $null, the list will contain all the domains items returned at once. Otherwise, Top will indicate the maximum number of elements to be returned in the list.
If more channels are still available, the value in NextLink should be used in the next call to get the next page of channels.
Finally, ODataQuery parameter is used to perform filtering for the search results. The filtering query follows OData syntax using the Name property only. The supported operations include: CONTAINS, eq (for equal), ne (for not equal), AND, OR and NOT.

## EXAMPLES

### Example 1
```powershell
Get-AzEventGridChannel -ResourceGroup MyResourceGroupName -PartnerNamespaceName PartnerNamespace1 -Name Channel1
```

Gets the details of Event Grid channel \`Channel1\` in partner namespace \`PartnerNameSpace1\` in resource group \`MyResourceGroupName\`.

### Example 2
```powershell
Get-AzEventGridChannel -ResourceGroup MyResourceGroupName -PartnerNamespaceName PartnerNameSpace1
```

Lists the details of Event Grid channels in partner namespace \`PartnerNameSpace1\` in resource group \`MyResourceGroupName\`.

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

### -Name
The name of the Event Grid channel.

```yaml
Type: String
Parameter Sets: ChannelNameParameterSet
Aliases: ChannelName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Parameter Sets: ChannelListByPartnerNamespaceParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PartnerNamespaceName
Event Grid partner namespace name.

```yaml
Type: String
Parameter Sets: ChannelListByPartnerNamespaceParameterSet, ChannelNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: ChannelListByPartnerNamespaceParameterSet, ChannelNameParameterSet
Aliases: ResourceGroup

Required: True
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
Parameter Sets: ChannelListByPartnerNamespaceParameterSet
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

### Microsoft.Azure.Commands.EventGrid.Models.PSChannelListInstance

### Microsoft.Azure.Commands.EventGrid.Models.PSChannel

## NOTES

## RELATED LINKS
