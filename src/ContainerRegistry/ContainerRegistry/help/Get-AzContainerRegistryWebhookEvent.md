---
external help file: Az.ContainerRegistry-help.xml
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/get-azcontainerregistrywebhookevent
schema: 2.0.0
---

# Get-AzContainerRegistryWebhookEvent

## SYNOPSIS
Lists recent events for the specified webhook.

## SYNTAX

### List (Default)
```
Get-AzContainerRegistryWebhookEvent -RegistryName <String> -ResourceGroupName <String> -WebhookName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetByWebhook
```
Get-AzContainerRegistryWebhookEvent [-SubscriptionId <String[]>] -Webhook <IWebhook>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Lists recent events for the specified webhook.

## EXAMPLES

### Example 1: Gets events of a container registry webhook.
```powershell
Get-AzContainerRegistryWebhookEvent  -ResourceGroupName lnxtest -RegistryName lnxcr -WebhookName webhook001
```

```output
ContentAction ContentTimestamp     ResponseMessageStatusCode
------------- ----------------     -------------------------
ping          1/19/2023 6:57:21 AM 200
ping          1/16/2023 9:30:18 PM 200
ping          1/16/2023 9:27:30 PM 200
ping          1/16/2023 9:23:50 PM 200
ping          1/16/2023 9:13:47 PM 200
ping          1/16/2023 9:04:55 PM 200
```

Gets events of a container registry webhook.

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

### -RegistryName
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: List
Aliases: ContainerRegistryName

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
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Webhook
The Webhook Object.
To construct, see NOTES section for WEBHOOK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IWebhook
Parameter Sets: GetByWebhook
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WebhookName
The name of the webhook.

```yaml
Type: System.String
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IWebhook

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IEvent

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`WEBHOOK <IWebhook>`: The Webhook Object.
  - `Location <String>`: The location of the resource. This cannot be changed after the resource is created.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource modification (UTC).
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <LastModifiedByType?>]`: The type of identity that last modified the resource.
  - `[Tag <IResourceTags>]`: The tags of the resource.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Action <WebhookAction[]>]`: The list of actions that trigger the webhook to post notifications.
  - `[Scope <String>]`: The scope of repositories where the event can be triggered. For example, 'foo:*' means events for all tags under repository 'foo'. 'foo:bar' means events for 'foo:bar' only. 'foo' is equivalent to 'foo:latest'. Empty means all events.
  - `[Status <WebhookStatus?>]`: The status of the webhook at the time the operation was called.

## RELATED LINKS
