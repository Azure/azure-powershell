---
external help file: Microsoft.Azure.Commands.ContainerRegistry.dll-Help.xml
Module Name: AzureRM.ContainerRegistry
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.containerregistry/get-azurermcontainerregistrycredential
schema: 2.0.0
---

# Get-AzureRmContainerRegistryWebhook

## SYNOPSIS
Get a container registry webhook.

## SYNTAX

### ShowWebhookByNameResourceGroupParameterSet
```
Get-AzureRmContainerRegistryWebhook [-Name] <String> [-ResourceGroupName] <String> [-RegistryName] <String>
 [-IncludeConfiguration] [-DefaultProfile <IAzureContextContainer>]
```

### ShowWebhookByRegistryObjectParameterSet
```
Get-AzureRmContainerRegistryWebhook [-Name] <String> -Registry <PSContainerRegistry> [-IncludeConfiguration]
 [-DefaultProfile <IAzureContextContainer>]
```

### ListWebhookByNameResourceGroupParameterSet
```
Get-AzureRmContainerRegistryWebhook [-ResourceGroupName] <String> [-RegistryName] <String>
 [-IncludeConfiguration] [-DefaultProfile <IAzureContextContainer>]
```

### ListWebhookByRegistryObjectParameterSet
```
Get-AzureRmContainerRegistryWebhook -Registry <PSContainerRegistry> [-IncludeConfiguration]
 [-DefaultProfile <IAzureContextContainer>]
```

### ResourceIdParameterSet
```
Get-AzureRmContainerRegistryWebhook [-IncludeConfiguration] -ResourceId <String>
 [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The Get-AzureRmContainerRegistryWebhook cmdlet gets a specified webhook of container registry or all the webhooks of a container registry.

## EXAMPLES

### Example 1: Get a specified webhook of a container registry
```powershell
PS C:\>Get-AzureRmContainerRegistryWebhook -ResourceGroupName "MyResourceGroup" -RegistryName "MyRegistry" -Name "webhook001"

Name            Location   Status     Scope           Actions         Provisioni ServiceUri                     CustomH
                                                                      ngState                                   eaders
----            --------   ------     -----           -------         ---------- ----------                     -------
webhook001      eastus     enabled    foo:*           {Delete, Push}  Succeeded
```
Get a specified webhook of a container registry

### Example 2: Get all the webhooks of a container registry
```powershell
PS C:\>Get-AzureRmContainerRegistryWebhook -ResourceGroupName "MyResourceGroup" -RegistryName "MyRegistry"

Name            Location   Status     Scope           Actions         Provisioni ServiceUri                     CustomH
                                                                      ngState                                   eaders
----            --------   ------     -----           -------         ---------- ----------                     -------
webhook001      eastus     enabled    foo:*           {Delete, Push}  Succeeded
webhook002      eastus     enabled    foo:*           {Delete, Push}  Succeeded
webhook003      eastus     enabled    foo:*           {Delete, Push}  Succeeded
```
Get all the webhooks of a container registry

### Example 3: Get a specified webhook of a container registry with configuration details
```powershell
PS C:\>Get-AzureRmContainerRegistryWebhook -ResourceGroupName "MyResourceGroup" -RegistryName "MyRegistry" -Name "webhook001" -IncludeConfiguration

Name            Location   Status     Scope           Actions         Provisioni ServiceUri                     CustomH
                                                                      ngState                                   eaders
----            --------   ------     -----           -------         ---------- ----------                     -------
webhook001      eastus     enabled    foo:*           {Delete, Push}  Succeeded  http://www.bing.com/           {[Sp...
```
Get a specified webhook of a container registry with configuration details

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

### -IncludeConfiguration
Get the configuration information for a webhook.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

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
Parameter Sets: ShowWebhookByNameResourceGroupParameterSet, ShowWebhookByRegistryObjectParameterSet
Aliases: WebhookName

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Registry
Container Registry Object.

```yaml
Type: PSContainerRegistry
Parameter Sets: ShowWebhookByRegistryObjectParameterSet, ListWebhookByRegistryObjectParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RegistryName
Container Registry Name.

```yaml
Type: String
Parameter Sets: ShowWebhookByNameResourceGroupParameterSet, ListWebhookByNameResourceGroupParameterSet
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
Parameter Sets: ShowWebhookByNameResourceGroupParameterSet, ListWebhookByNameResourceGroupParameterSet
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

## INPUTS

### Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistry
System.String


## OUTPUTS

### Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryWebhook
System.Collections.Generic.IList`1[[Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryWebhook, Microsoft.Azure.Commands.ContainerRegistry, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS

