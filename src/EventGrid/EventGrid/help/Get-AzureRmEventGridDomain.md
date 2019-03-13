---
external help file: Microsoft.Azure.Commands.EventGrid.dll-Help.xml
Module Name: AzureRM.EventGrid
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.eventgrid/get-azurermeventgriddomain
schema: 2.0.0
---

# Get-AzureRmEventGridDomain

## SYNOPSIS
Gets the details of an Event Grid domain, or gets a list of all Event Grid domains in the current Azure subscription.

## SYNTAX

### ResourceGroupNameParameterSet (Default)
```
Get-AzureRmEventGridDomain [[-ResourceGroupName] <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### DomainNameParameterSet
```
Get-AzureRmEventGridDomain [-ResourceGroupName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdEventSubscriptionParameterSet
```
Get-AzureRmEventGridDomain [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmEventGridDomain cmdlet gets either the details of a specified Event Grid domain, or a list of all Event Grid domains in the current Azure subscription.
If the domain name is provided, the details of a single Event Grid domain is returned. 
If the domain name is not provided, a list of domains is returned.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmEventGridDomain -ResourceGroup MyResourceGroupName -Name Domain1
```

Gets the details of Event Grid domain \`Domain1\` in resource group \`MyResourceGroupName\`.

### Example 2
```
PS C:\> Get-AzureRmEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/MyResourceGroupName/providers/Microsoft.EventGrid/domains/Domain1"
```

Gets the details of Event Grid domain \`Domain1\` in resource group \`MyResourceGroupName\`.

### Example 3
```
PS C:\> Get-AzureRmEventGridDomain -ResourceGroup MyResourceGroupName
```

List all the Event Grid domains in resource group \`MyResourceGroupName\`.

### Example 4
```
PS C:\> Get-AzureRmEventGridDomain
```

List all the Event Grid domains in the subscription.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
EventGrid domain name.

```yaml
Type: System.String
Parameter Sets: DomainNameParameterSet
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
Type: System.String
Parameter Sets: ResourceGroupNameParameterSet
Aliases: ResourceGroup

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: DomainNameParameterSet
Aliases: ResourceGroup

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Resource Identifier representing the Event Grid Domain.

```yaml
Type: System.String
Parameter Sets: ResourceIdEventSubscriptionParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSDomain

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.EventGrid.Models.PSDomainListInstance, Microsoft.Azure.Commands.EventGrid, Version=0.3.3.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
