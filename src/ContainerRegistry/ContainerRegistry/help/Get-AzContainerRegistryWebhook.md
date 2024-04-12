---
external help file: Az.ContainerRegistry-help.xml
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/get-azcontainerregistrywebhook
schema: 2.0.0
---

# Get-AzContainerRegistryWebhook

## SYNOPSIS
Gets the properties of the specified webhook.

## SYNTAX

### List (Default)
```
Get-AzContainerRegistryWebhook -RegistryName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzContainerRegistryWebhook -RegistryName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -Name <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerRegistryWebhook -InputObject <IContainerRegistryIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByRegistry
```
Get-AzContainerRegistryWebhook -Registry <IRegistry> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of the specified webhook.

## EXAMPLES

### Example 1: Gets a container registry webhook.
```powershell
Get-AzContainerRegistryWebhook  -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name "webhook001"
```

```output
Name       Location Status  Scope ProvisioningState
----       -------- ------  ----- -----------------
webhook001 eastus2  enabled       Succeeded
```

Gets a container registry webhook.

### Example 2: Get all the webhooks of a container registry
```powershell
Get-AzContainerRegistryWebhook  -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample"
```

```output
Name       Location Status  Scope ProvisioningState
----       -------- ------  ----- -----------------
webhook001 eastus2  enabled       Succeeded
webhook002 eastus2  enabled       Succeeded
webhook003 eastus   enabled foo:* Succeeded
```

Get all the webhooks of a container registry

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

### -Name
The name of the webhook.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: WebhookName, ResourceName

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

### -Registry
The Registry Object.
To construct, see NOTES section for REGISTRY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IRegistry
Parameter Sets: GetByRegistry
Aliases:

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.IContainerRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IWebhook

## NOTES

## RELATED LINKS
