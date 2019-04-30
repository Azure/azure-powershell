---
external help file: Az.ServiceBus-help.xml
Module Name: Az.ServiceBus
online version: https://docs.microsoft.com/en-us/powershell/module/az.servicebus/new-azservicebusnamespace
schema: 2.0.0
---

# New-AzServiceBusNamespace

## SYNOPSIS
Creates or updates a service namespace.
Once created, this namespace's resource manifest is immutable.
This operation is idempotent.

## SYNTAX

### CreateSubscriptionIdViaHost (Default)
```
New-AzServiceBusNamespace [-Name] <String> [-ResourceGroupName] <String> [-Parameter <ISbNamespace>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded
```
New-AzServiceBusNamespace [-Name] <String> [-ResourceGroupName] <String> -SubscriptionId <String>
 [-Location] <String> [-SkuCapacity <Int32>] -SkuName <SkuName> [-SkuTier <SkuTier>]
 [-Tag <ITrackedResourceTags>] [-ZoneRedundant <Boolean>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### Create
```
New-AzServiceBusNamespace [-Name] <String> [-ResourceGroupName] <String> -SubscriptionId <String>
 [-Parameter <ISbNamespace>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateSubscriptionIdViaHostExpanded
```
New-AzServiceBusNamespace [-Name] <String> [-ResourceGroupName] <String> [-Location] <String>
 [-SkuCapacity <Int32>] -SkuName <SkuName> [-SkuTier <SkuTier>] [-Tag <ITrackedResourceTags>]
 [-ZoneRedundant <Boolean>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a service namespace.
Once created, this namespace's resource manifest is immutable.
This operation is idempotent.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The Geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The namespace name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NamespaceName

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Description of a namespace resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api201801Preview.ISbNamespace
Parameter Sets: CreateSubscriptionIdViaHost, Create
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
The specified messaging units for the tier.
For Premium tier, capacity are 1,2 and 4.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of this SKU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.SkuName
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
The billing tier of this particular SKU.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Support.SkuTier
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api20170401.ITrackedResourceTags
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ZoneRedundant
Enabling this property creates a Premium Service Bus Namespace in regions supported availability zones.

```yaml
Type: System.Boolean
Parameter Sets: CreateExpanded, CreateSubscriptionIdViaHostExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.Models.Api201801Preview.ISbNamespace
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.servicebus/new-azservicebusnamespace](https://docs.microsoft.com/en-us/powershell/module/az.servicebus/new-azservicebusnamespace)

