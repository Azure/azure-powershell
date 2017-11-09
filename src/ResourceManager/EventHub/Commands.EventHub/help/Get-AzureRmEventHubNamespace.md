---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
Module Name: AzureRM
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.eventhub/get-azurermeventhubnamespace
schema: 2.0.0
---

# Get-AzureRmEventHubNamespace

## SYNOPSIS
Gets the details of an Event Hubs namespace, or gets a list of all Event Hubs namespaces in the current Azure subscription.

## SYNTAX

```
Get-AzureRmEventHubNamespace [[-ResourceGroupName] <String>] [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmEventHubNamespace cmdlet gets either the details of a specified Event Hubs namespace, or a list of all Event Hubs namespaces in the current Azure subscription.
If the namespace name is provided, the details of a single Event Hubs namespace is returned.
If the namespace name is not provided, a list of namespaces is returned.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmEventHubNamespace -ResourceGroupName MyResourceGroupName -NamespaceName MyNamespaceName
```

Gets the details of the Event Hubs namespace \`MyNamespaceName\` in the resource group \`MyResourceGroupName\`.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -Name
EventHub Namespace Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: NamespaceName

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

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

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.EventHub.Models.NamespaceAttributes, Microsoft.Azure.Commands.EventHub, Version=0.0.1.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS

