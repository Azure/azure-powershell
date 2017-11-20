---
external help file: Microsoft.Azure.Commands.ContainerRegistry.dll-Help.xml
Module Name: AzureRM.ContainerRegistry
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.containerregistry/get-azurermcontainerregistrycredential
schema: 2.0.0
---

# Get-AzureRmContainerRegistryWebhookEvent

## SYNOPSIS
Get events of a container registry webhook.

## SYNTAX

### ListWebhookEventsByNameResourceGroupParameterSet
```
Get-AzureRmContainerRegistryWebhookEvent [-Name] <String> [-ResourceGroupName] <String>
 [-RegistryName] <String> [-DefaultProfile <IAzureContextContainer>]
```

### ListWebhookEventsByWebhookObjectParameterSet
```
Get-AzureRmContainerRegistryWebhookEvent -Webhook <PSContainerRegistryWebhook>
 [-DefaultProfile <IAzureContextContainer>]
```

### ResourceIdParameterSet
```
Get-AzureRmContainerRegistryWebhookEvent -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The Get-AzureRmContainerRegistryWebhookEvent cmdlet lists all the events of a webhook.

## EXAMPLES

### Example 1: Get all the events of a webhook.
```powershell
PS C:\>Get-AzureRmContainerRegistryWebhookEvent -ResourceGroupName mattacrtest001 -RegistryName premium001 -Name webhook001

Reque Request Headers      Respo Response Headers     Response Content
st Me                      nse S
thod                       tatus
                           Code
----- ---------------      ----- ----------------     ----------------
POST  {[SpecialHeader, ... 200   {[Vary, Accept-En... <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"...
POST  {[SpecialHeader, ... 200   {[Vary, Accept-En... <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"...
POST  {[SpecialHeader, ... 200   {[Vary, Accept-En... <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"...
```
Get all the events of a webhook.

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
Webhook Name.

```yaml
Type: String
Parameter Sets: ListWebhookEventsByNameResourceGroupParameterSet
Aliases: WebhookName

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistryName
Container Registry Name.

```yaml
Type: String
Parameter Sets: ListWebhookEventsByNameResourceGroupParameterSet
Aliases: ContainerRegistryName, ResourceName

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: ListWebhookEventsByNameResourceGroupParameterSet
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The container registry Webhook resource id

```yaml
Type: String
Parameter Sets: ResourceIdParameterSet
Aliases: Id

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Webhook
Container Registry Object.

```yaml
Type: PSContainerRegistryWebhook
Parameter Sets: ListWebhookEventsByWebhookObjectParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### System.String


## OUTPUTS

### System.Collections.Generic.IList`1[[Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryWebhookEvent, Microsoft.Azure.Commands.ContainerRegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS

