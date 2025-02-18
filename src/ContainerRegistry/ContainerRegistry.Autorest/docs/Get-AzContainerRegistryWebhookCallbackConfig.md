---
external help file:
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/get-azcontainerregistrywebhookcallbackconfig
schema: 2.0.0
---

# Get-AzContainerRegistryWebhookCallbackConfig

## SYNOPSIS
Gets the configuration of service URI and custom headers for the webhook.

## SYNTAX

### Get (Default)
```
Get-AzContainerRegistryWebhookCallbackConfig -RegistryName <String> -ResourceGroupName <String>
 -WebhookName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerRegistryWebhookCallbackConfig -InputObject <IContainerRegistryIdentity>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Gets the configuration of service URI and custom headers for the webhook.

## EXAMPLES

### Example 1: Gets the configuration of service URI and custom headers for the webhook.
```powershell
Get-AzContainerRegistryWebhookCallbackConfig -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -WebhookName "webhook001"
```

```output
ServiceUri
----------
http://www.bing.com
```

Gets the configuration of service URI and custom headers for the webhook.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RegistryName
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: Get
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
Parameter Sets: Get
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
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebhookName
The name of the webhook.

```yaml
Type: System.String
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.ICallbackConfig

## NOTES

## RELATED LINKS

