---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Get-AzEventGridSystemTopic

## SYNOPSIS
Gets the details of an Event Grid system topic, or gets a list of all Event Grid system topics in the current Azure subscription.

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
The Get-AzEventGridSystemTopic cmdlet gets either the details of a specified Event Grid System Topic, or a list of all Event Grid topics in the current Azure subscription.
If the topic name is provided, the details of a single Event Grid Topic is returned.
If the topic name is not provided, a list of topics is returned. The number of elements returned in this list is controlled by the Top parameter. If the Top value is not specified or $null, the list will contain all the topics items. Otherwise, Top will indicate the maximum number of elements to be returned in the list.
If more topics are still available, the value in NextLink should be used in the next call to get the next page of topics.
Finally, ODataQuery parameter is used to perform filtering for the search results. The filtering query follows OData syntax using the Name property only. The supported operations include: CONTAINS, eq (for equal), ne (for not equal), AND, OR and NOT.

## EXAMPLES

### Example 1
```powershell
Get-AzEventGridSystemTopic -ResourceGroup MyResourceGroupName -Name Topic1
```

Gets the details of Event Grid System topic \`Topic1\` in resource group \`MyResourceGroupName\`.

### Example 2
```powershell
Get-AzEventGridSystemTopic -ResourceGroup MyResourceGroupName
```

List all the Event Grid System topics in resource group \`MyResourceGroupName\` without pagination.

### Example 3
```powershell
$odataFilter = "Name ne 'ABCD'"
$result = Get-AzEventGridSystemTopic -ResourceGroup MyResourceGroupName -Top 10 -ODataQuery $odataFilter
Get-AzEventGridSystemTopic $result.NextLink
```

List the first 10 Event Grid System topics (if any) in resource group \`MyResourceGroupName\` that satisfies the $odataFilter query. If more results are available, the $result.NextLink will not be $null. In order to get next page(s) of topics, user is expected to re-call Get-AzEventGridSystemTopic and uses result.NextLink obtained from the previous call. Caller should stop when result.NextLink becomes $null.

### Example 4
```powershell
Get-AzEventGridSystemTopic
```

List all the Event Grid topics in the subscription without pagination.

### Example 5
```powershell
$odataFilter = "Name ne 'ABCD'"
$result = Get-AzEventGridSystemTopic -Top 10 -ODataQuery $odataFilter
Get-AzEventGridSystemTopic $result.NextLink
```

List the first 10 Event Grid System topics (if any) in the subscription that satisfies the $odataFilter query. If more results are available, the $result.NextLink will not be $null. In order to get next page(s) of topics, user is expected to re-call Get-AzEventGridSystemTopic and uses result.NextLink obtained from the previous call. Caller should stop when result.NextLink becomes $null.

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
