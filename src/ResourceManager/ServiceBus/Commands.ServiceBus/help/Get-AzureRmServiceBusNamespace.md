---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
Module Name: AzureRM.ServiceBus
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.ServiceBus/get-azurermServiceBusnamespace
schema: 2.0.0
---

# Get-AzureRmServiceBusNamespace

## SYNOPSIS
Gets the details of an Event Hubs namespace, or gets a list of all Event Hubs namespaces in the current Azure subscription.

## SYNTAX

```
Get-AzureRmServiceBusNamespace [[-ResourceGroupName] <String>] [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmServiceBusNamespace cmdlet gets either the details of a specified Event Hubs namespace, or a list of all Event Hubs namespaces in the current Azure subscription.
If the namespace name is provided, the details of a single Event Hubs namespace is returned.
If the namespace name is not provided, a list of namespaces is returned.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmServiceBusNamespace -ResourceGroupName MyResourceGroupName -NamespaceName MyNamespaceName

Name                   : MyNamespaceName
Id                     : /subscriptions/XXXXXXXXXXXXXXXXX/resourceGroups/MyResourceGroupName/providers/Microsoft.ServiceBus/namespaces/MyNamespaceName
Location               : West US
ResourceGroup          : MyResourceGroupName
Sku                    : Name : Standard , Capacity : 1 , Tier : Standard
ProvisioningState      : Succeeded
Status                 : Active
CreatedAt              : X/XX/XXXX 11:54:52 PM
UpdatedAt              : X/XX/XXXX 11:55:17 PM
ServiceBusEndpoint     : https://MyNamespaceName.servicebus.windows.net:443/
Enabled                : True
IsAutoInflateEnabled   : False
MaximumThroughputUnits : 0
ZoneRedundant          : False
```

Gets the details of namespace \`MyNamespaceName\` in the resource group \`MyResourceGroupName\`.

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
ServiceBus Namespace Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NamespaceName

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String


## OUTPUTS

### Microsoft.Azure.Commands.ServiceBus.Models.PSNamespaceAttributes


## NOTES

## RELATED LINKS
