---
external help file: Microsoft.Azure.Commands.EventGrid.dll-Help.xml
Module Name: AzureRM.EventGrid
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.eventgrid/get-azurermeventgridtopictype
schema: 2.0.0
---

# Get-AzureRmEventGridTopicType

## SYNOPSIS
Gets the details about the topic types supported by Azure Event Grid.

## SYNTAX

```
Get-AzureRmEventGridTopicType [[-Name] <String>] [-IncludeEventTypeData]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Gets the details of topic types supported by Azure Event Grid.
If a topic type name is specified, details about that topic type are returned.
If a topic type name is not specified, details about all topic types are returned.
If IncludeEventTypes is specified, information about event types supported by each topic type is included in the response.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmEventGridTopicType
```

Gets a list of the topic types.

### Example 2
```
PS C:\> Get-AzureRmEventGridTopicType -Name "Microsoft.Storage.StorageAccounts"
```

Gets information about the StorageAccounts topic type.

### Example 3
```
PS C:\> Get-AzureRmEventGridTopicType -Name "Microsoft.Storage.StorageAccounts" -IncludeEventTypeData
```

Gets information about the StorageAccounts topic type, including the event types supported by StorageAccounts.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeEventTypeData
If specified, the response will include the event types supported by a topic type.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
EventGrid Topic Type Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
System.Management.Automation.SwitchParameter

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.EventGrid.Models.PSTopicTypeInfoListInstance, Microsoft.Azure.Commands.EventGrid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]
Microsoft.Azure.Commands.EventGrid.Models.PSTopicTypeInfo

## NOTES

## RELATED LINKS

