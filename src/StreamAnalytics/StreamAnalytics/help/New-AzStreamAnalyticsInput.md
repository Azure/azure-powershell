---
external help file: Az.StreamAnalytics-help.xml
Module Name: Az.StreamAnalytics
online version: https://learn.microsoft.com/powershell/module/az.streamanalytics/new-azstreamanalyticsinput
schema: 2.0.0
---

# New-AzStreamAnalyticsInput

## SYNOPSIS
Creates an input or replaces an already existing input under an existing streaming job.

## SYNTAX

```
New-AzStreamAnalyticsInput -JobName <String> -Name <String> -ResourceGroupName <String> -File <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates an input or replaces an already existing input under an existing streaming job.

## EXAMPLES

### Example 1: Create a job input with a definition from a file
```powershell
New-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name input-01 -File .\test\template-json\EventHub.json
```

```output
Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs 6c9f5122-44b9-45bf-81c9-5349a9dd8851
```

This command creates an input from the file EventHub.json.

(below is an example for "EventHub.json")
{
  "properties": {
    "type": "Stream",
    "serialization": {
      "type": "Json",
      "properties": {
        "encoding": "UTF8"
      }
    },
    "compression": {
      "type": "None"
    },
    "datasource": {
      "type": "Microsoft.EventHub/EventHub",
      "properties": {
        "serviceBusNamespace": "xxxxxxxxxxxxxx",
        "sharedAccessPolicyName": "xxxxxxxxxxxxxxxx",
        "sharedAccessPolicyKey": "xxxxxxxxxxxxxxxxxxxxxx",
        "authenticationMode": "ConnectionString",
        "eventHubName": "xxxxxxxxxxxxxxxx",
        "consumerGroupName": "xxxxxxxxxxxxxxxx"
      }
    }
  }
}

### Example 2: Create a job input with a definition from a file
```powershell
New-AzStreamAnalyticsInput -ResourceGroupName azure-rg-test -JobName sajob-02-pwsh -Name input-01 -File .\test\template-json\IotHub.json
```

```output
Name     Type                                           ETag
----     ----                                           ----
input-01 Microsoft.StreamAnalytics/streamingjobs/inputs 6c9f5122-44b9-45bf-81c9-5349a9dd8851
```

This command creates an input from the file IotHub.json.

(below is an example for "IotHub.json")
{
  "properties": {
    "type": "Stream",
    "serialization": {
      "type": "Json",
      "properties": {
        "encoding": "UTF8"
      }
    },
    "compression": {
      "type": "None"
    },
    "partitionKey": "",
    "datasource": {
      "type": "Microsoft.Devices/IotHubs",
      "properties": {
        "iotHubNamespace": "xxxxxxxxxxx",
        "sharedAccessPolicyName": "xxxxxxxxxxxxxx",
        "sharedAccessPolicyKey": "xxxxxxxxxxxxxxxxx",
        "consumerGroupName": "$Default",
        "endpoint": "messages/events"
      }
    }
  }
}

## PARAMETERS

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

### -File
The name of the streaming job.

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

### -IfMatch
The ETag of the input.
Omit this value to always overwrite the current input.
Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.

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

### -IfNoneMatch
Set to '*' to allow a new input to be created, but to prevent updating an existing input.
Other values will result in a 412 Pre-condition Failed response.

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

### -JobName
The name of the streaming job.

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

### -Name
The name of the input.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: InputName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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
The ID of the target subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.IStreamAnalyticsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StreamAnalytics.Models.Api20170401Preview.IInput

## NOTES

## RELATED LINKS
