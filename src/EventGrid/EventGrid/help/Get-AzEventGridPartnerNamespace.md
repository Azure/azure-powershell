---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Get-AzEventGridPartnerNamespace

## SYNOPSIS
Gets the details of an Event Grid partner namespace, or lists partner namespaces at the scope of the current Azure subscription or specified resource group.

## SYNTAX

### PartnerNamespaceListBySubscriptionParameterSet (Default)
```
Get-AzEventGridPartnerNamespace [-ODataQuery <String>] [-Top <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceGroupNameParameterSet
```
Get-AzEventGridPartnerNamespace -ResourceGroupName <String> [-ODataQuery <String>] [-Top <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### PartnerNamespaceNameParameterSet
```
Get-AzEventGridPartnerNamespace -ResourceGroupName <String> -Name <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### NextLinkParameterSet
```
Get-AzEventGridPartnerNamespace -NextLink <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzEventGridPartnerNamespace cmdlet gets either the details of a specified Event Grid partner namespace, or lists partner namespaces.
If the partner namespace name is provided, the details of a single Event Grid partner namespace is returned.
If the partner namespace name is not provided but the resource group name is provided, a list of partner namespaces at the resource group scope is returned.
If neither the partner namespace name or the resource group name are provided, a list of partner namespaces at the current Azure subscription scope is returned.
## EXAMPLES

### Example 1
```powershell
Get-AzEventGridPartnerNamespace -ResourceGroup MyResourceGroupName -Name PartnerNamespace1
```

Gets the details of Event Grid partner namespace \`PartnerNamespace1\` in resource group \`MyResourceGroupName\`.

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
Event Grid partner namespace name.

```yaml
Type: String
Parameter Sets: PartnerNamespaceNameParameterSet
Aliases: PartnerNamespaceName

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
Parameter Sets: PartnerNamespaceListBySubscriptionParameterSet, ResourceGroupNameParameterSet
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
Parameter Sets: ResourceGroupNameParameterSet, PartnerNamespaceNameParameterSet
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
Parameter Sets: PartnerNamespaceListBySubscriptionParameterSet, ResourceGroupNameParameterSet
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

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerNamespaceListInstance

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerNamespace

## NOTES

## RELATED LINKS
