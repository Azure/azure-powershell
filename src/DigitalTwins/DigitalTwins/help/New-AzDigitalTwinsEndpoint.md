---
external help file: Az.DigitalTwins-help.xml
Module Name: Az.DigitalTwins
online version: https://learn.microsoft.com/powershell/module/az.digitaltwins/new-azdigitaltwinsendpoint
schema: 2.0.0
---

# New-AzDigitalTwinsEndpoint

## SYNOPSIS
Create or update DigitalTwinsInstance endpoint.

## SYNTAX

### EventHub (Default)
```
New-AzDigitalTwinsEndpoint -EndpointName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] -EndpointType <EndpointType> -ConnectionStringPrimaryKey <String>
 [-EndpointDescription <IDigitalTwinsEndpointResource>] [-AuthenticationType <AuthenticationType>]
 [-ConnectionStringSecondaryKey <String>] [-DeadLetterSecret <String>] [-DeadLetterUri <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ServiceBus
```
New-AzDigitalTwinsEndpoint -EndpointName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] -EndpointType <EndpointType> [-EndpointDescription <IDigitalTwinsEndpointResource>]
 [-AuthenticationType <AuthenticationType>] [-DeadLetterSecret <String>] [-DeadLetterUri <String>]
 -PrimaryConnectionString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### EventGrid
```
New-AzDigitalTwinsEndpoint -EndpointName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] -EndpointType <EndpointType> [-EndpointDescription <IDigitalTwinsEndpointResource>]
 [-AuthenticationType <AuthenticationType>] [-DeadLetterSecret <String>] [-DeadLetterUri <String>]
 -TopicEndpoint <String> -AccessKey1 <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update DigitalTwinsInstance endpoint.

## EXAMPLES

### Example 1: Create an AzDigitalTwinsEndpoint for Eventhub
```powershell
New-AzDigitalTwinsEndpoint -EndpointName azps-dt-eh -EndpointType EventHub -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -connectionStringPrimaryKey 'Endpoint=sb://azps-eventhubs.servicebus.windows.net/;SharedAccessKeyName=abc123;SharedAccessKey=******;EntityPath=azps-eh' -AuthenticationType 'KeyBased'
```

```output
Name       EndpointType AuthenticationType ResourceGroupName
----       ------------ ------------------ -----------------
azps-dt-eh EventHub     KeyBased           azps_test_group
```

Create an AzDigitalTwinsEndpoint for Eventhub by connectionStringPrimaryKey

### Example 2: Create an AzDigitalTwinsEndpoint for EventGrid
```powershell
New-AzDigitalTwinsEndpoint -EndpointName azps-dt-eg -EndpointType EventGrid -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -TopicEndpoint 'https://azps-eventgrid.eastus-1.eventgrid.azure.net/api/events' -AccessKey1 '******=' -AuthenticationType 'KeyBased'
```

```output
Name       EndpointType AuthenticationType ResourceGroupName
----       ------------ ------------------ -----------------
azps-dt-eg EventGrid    KeyBased           azps_test_group
```

Create an AzDigitalTwinsEndpoint for Eventhub by TopicEndpoint and accessKey1

### Example 3: Create an AzDigitalTwinsEndpoint for ServiceBus
```powershell
New-AzDigitalTwinsEndpoint -EndpointName azps-dt-sb -EndpointType ServiceBus -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -PrimaryConnectionString "Endpoint=sb://azps-servicebus.servicebus.windows.net/;SharedAccessKeyName=abc123;SharedAccessKey=******;EntityPath=azps-sb" -AuthenticationType 'KeyBased'
```

```output
Name       EndpointType AuthenticationType ResourceGroupName
----       ------------ ------------------ -----------------
azps-dt-sb ServiceBus   KeyBased           azps_test_group
```

Create an AzDigitalTwinsEndpoint for ServicBus by PrimaryConnectionString

## PARAMETERS

### -AccessKey1
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: EventGrid
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

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

### -AuthenticationType
Specifies the authentication type being used for connecting to the endpoint.
Defaults to 'KeyBased'.
If 'KeyBased' is selected, a connection string must be specified (at least the primary connection string).
If 'IdentityBased' is select, the endpointUri and entityPath properties must be specified.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.AuthenticationType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionStringPrimaryKey
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: EventHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConnectionStringSecondaryKey
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: EventHub
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeadLetterSecret
Dead letter storage secret for key-based authentication.
Will be obfuscated during read.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeadLetterUri
Dead letter storage URL for identity-based authentication.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### -EndpointDescription
DigitalTwinsInstance endpoint resource.
To construct, see NOTES section for ENDPOINTDESCRIPTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20220531.IDigitalTwinsEndpointResource
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EndpointName
Name of Endpoint Resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointType
The type of Digital Twins endpoint

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.EndpointType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PrimaryConnectionString
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: ServiceBus
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the DigitalTwinsInstance.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the DigitalTwinsInstance.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopicEndpoint
The subscription identifier.

```yaml
Type: System.String
Parameter Sets: EventGrid
Aliases:

Required: True
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20220531.IDigitalTwinsEndpointResource

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20220531.IDigitalTwinsEndpointResource

## NOTES

## RELATED LINKS
