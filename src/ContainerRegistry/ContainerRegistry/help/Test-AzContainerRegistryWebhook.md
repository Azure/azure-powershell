---
external help file: Az.ContainerRegistry-help.xml
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/test-azcontainerregistrywebhook
schema: 2.0.0
---

# Test-AzContainerRegistryWebhook

## SYNOPSIS
Triggers a ping event to be sent to the webhook.

## SYNTAX

### Ping (Default)
```
Test-AzContainerRegistryWebhook -Name <String> -RegistryName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### PingByWebhook
```
Test-AzContainerRegistryWebhook [-SubscriptionId <String>] -Webhook <IWebhook> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Triggers a ping event to be sent to the webhook.

## EXAMPLES

### Example 1: Triggers a webhook ping event.
```powershell
Test-AzContainerRegistryWebhook -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name "webhook001"
```

```output
c5950af0-c8d0-4924-9873-1ba7da5cbf83
```

Triggers a webhook ping event.

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

### -Name
The name of the webhook.

```yaml
Type: System.String
Parameter Sets: Ping
Aliases: WebhookName, ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryName
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: Ping
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
Parameter Sets: Ping
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Webhook
The webhook object.
To construct, see NOTES section for WEBHOOK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IWebhook
Parameter Sets: PingByWebhook
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

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
