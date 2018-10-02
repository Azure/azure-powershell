---
external help file: Microsoft.Azure.Commands.ServiceBus.dll-Help.xml
Module Name: AzureRM.ServiceBus
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.ServiceBus/set-azurermServiceBusnamespace
schema: 2.0.0
---

# Set-AzureRmServiceBusNamespace

## SYNOPSIS
Updates the specified Event Hubs namespace.

## SYNTAX

### NamespaceParameterSet (Default)
```
Set-AzureRmServiceBusNamespace [-ResourceGroupName] <String> [-Name] <String> [-Location] <String>
 [[-SkuName] <String>] [[-SkuCapacity] <Int32>] [[-Tag] <Hashtable>]
 [-EnableZoneRedundant] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AutoInflateParameterSet
```
Set-AzureRmServiceBusNamespace [-ResourceGroupName] <String> [-Name] <String> [-Location] <String>
 [[-SkuName] <String>] [[-SkuCapacity] <Int32>] [[-Tag] <Hashtable>]
 [-EnableAutoInflate] [-MaximumThroughputUnits <Int32>] [-EnableZoneRedundant] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Set-AzureRmServiceBusNamespace cmdlet updates the properties of the specified Event Hubs namespace.

## EXAMPLES

### Example 1
```
PS C:\> Set-AzureRmServiceBusNamespace -ResourceGroupName MyResourceGroupName -NamespaceName MyNamespaceName -Location "WestUS" -EnableAutoInflate -MaximumThroughputUnits 11
Name                   : MyNamespaceName
Id                     : /subscriptions/XXXXXXXXXXXXXXXXX/resourceGroups/MyResourceGroupName/providers/Microsoft.ServiceBus/namespaces/MyNamespaceName
Location               : MyLocation
ResourceGroup          : MyResourceGroupName
Sku                    : Name : Standard , Capacity : 1 , Tier : Standard
ProvisioningState      : Succeeded
Status                 : Active
CreatedAt              : X/XX/XXXX XX:XX:XX XX
UpdatedAt              : X/XX/XXXX XX:XX:XX XX
ServiceBusEndpoint     : https://MyNamespaceName.servicebus.windows.net:443/
Enabled                : True
IsAutoInflateEnabled   : True
MaximumThroughputUnits : 11
ZoneRedundant          : False
```

Updates  namespace \`MyNamespaceName\` with AutoInflate = enabled and MaximumThroughputUnits = 10

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

### -EnableAutoInflate
Indicates whether AutoInflate is enabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: AutoInflateParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableZoneRedundant
Indicates whether ZoneRedundant is enabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
ServiceBus Namespace Location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MaximumThroughputUnits
Upper limit of throughput units when AutoInflate is enabled, value should be within 0 to 20 throughput units.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: AutoInflateParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
ServiceBus Namespace Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NamespaceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkuCapacity
The ServiceBus throughput units.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkuName
Namespace Sku Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: Basic, Standard, Premium

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Hashtables which represents resource Tag.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]
System.Collections.Hashtable


## OUTPUTS

### Microsoft.Azure.Commands.ServiceBus.Models.PSNamespaceAttributes


## NOTES

## RELATED LINKS
