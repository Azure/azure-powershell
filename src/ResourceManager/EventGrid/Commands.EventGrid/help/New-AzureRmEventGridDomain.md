---
external help file: Microsoft.Azure.Commands.EventGrid.dll-Help.xml
Module Name: AzureRM.EventGrid
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.eventgrid/new-azurermeventgriddomain
schema: 2.0.0
---

# New-AzureRmEventGridDomain

## SYNOPSIS
Creates a new Azure Event Grid Domain.

## SYNTAX

```
New-AzureRmEventGridDomain [-ResourceGroupName] <String> [-Name] <String> [-Location] <String>
 [[-Tag] <Hashtable>] [-InputSchema <String>] [-InputMappingField <Hashtable>]
 [-InputMappingDefaultValue <Hashtable>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new Azure Event Grid Domain. Once the domain is created, an application can publish events to the topic endpoint.

## EXAMPLES

### Example 1
```powershell
PS C:\> New-AzureRmEventGridDomain -ResourceGroupName MyResourceGroupName -Name Domain1 -Location westus2
```

Creates an Event Grid domain \`Domain1\` in the specified geographic location \`westus2\`, in resource group \`MyResourceGroupName\`.

### Example 2
```
PS C:\> New-AzureRmEventGridDomain -ResourceGroupName MyResourceGroupName -Name Domain1 -Location westus2 -Tag @{ Department="Finance"; Environment="Test" }
```

Creates an Event Grid domain \`Domain1\` in the specified geographic location \`westus2\`, in resource group \`MyResourceGroupName\` with the specified tags "Department" and "Environment".

### Example 2
```
PS C:\> New-AzureRmEventGridDomain -ResourceGroupName MyResourceGroupName -Name Domain1 -Location westus2 -Tag @{ Department="Finance"; Environment="Test" }
New-AzureRmEventGridDomain -ResourceGroupName MyResourceGroupName -Name Domain1 -Location westus2 --Tag @{ Department="Finance"; Environment="Test" } -InputSchema customeventschema -InputMappingField @{id="CustomIdField"; topic="CustomTopicField"; eventtime="CustomEventTimeField"; subject="CustomSubjectField"; eventtype="CustomEventTypeField"; dataversion="CustomDataVersionField"} -InputMappingDefaultValue @{subject="CustomSubjectDefaultValue"; eventtype="CustomEventTypeDefaultValue"; dataversion="CustomDataVersionDefaultValue"}
```

Creates an Event Grid domain \`Domain1\` in the specified geographic location \`westus2\`, in resource group \`MyResourceGroupName\` with the specified tags "Department" and "Environment" with the specified customeventschema Input Schema along with the corresponding input mapping fields and default values that are used for input mapping.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -InputMappingDefaultValue
Hashtable which represents the input mapping fields with default value in space separated key = value format.
Allowed key names are: subject, eventtype, and dataversion.
This is used when InputSchemaHelp is customeventschema only.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputMappingField
Hashtable which represents the input mapping fields in space separated key = value format.
Allowed key names are: id, topic, eventtime, subject, eventtype, and dataversion.
This is used when InputSchemaHelp is customeventschema only.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputSchema
The schema of the input events for the topic.
Allowed values are: eventgridschema, customeventschema, or cloudeventv01Schema.
Default value is eventgridschema.
Note that if customeventschema is specified, then InputMappingField or/and InputMappingDefaultValue parameters need to be specified as well.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: EventGridSchema, CustomEventSchema, CloudEventV01Schema

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
The location of the domain.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
EventGrid domain name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: DomainName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceGroup

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Hashtable which represents resource Tags.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSDomain

## NOTES

## RELATED LINKS
