---
external help file: Az.ContainerRegistry-help.xml
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/get-azcontainerregistry
schema: 2.0.0
---

# Get-AzContainerRegistry

## SYNOPSIS
Gets the properties of the specified container registry.

## SYNTAX

### List2 (Default)
```
Get-AzContainerRegistry [-SubscriptionId <String[]>] [-IncludeDetail] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzContainerRegistry [-SubscriptionId <String[]>] [-IncludeDetail] -ResourceGroupName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerRegistry [-SubscriptionId <String[]>] [-IncludeDetail] -Name <String>
 -ResourceGroupName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerRegistry [-IncludeDetail] -InputObject <IContainerRegistryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of the specified container registry.

## EXAMPLES

### Example 1: Get a specified container registry
```powershell
Get-AzContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "MyRegistry"
```

```output
Name  SkuName LoginServer      CreationDate          ProvisioningState AdminUserEnabled
----  ------- -----------      ------------          ----------------- ----------------
testc Premium testc.azurecr.io 16/01/2023 8:45:50 pm Succeeded         True
```

This command gets the specified container registry.

### Example 2: Get all the container registries in a resource group
```powershell
Get-AzContainerRegistry -ResourceGroupName "MyResourceGroup"
```

```output
Name   SkuName LoginServer       CreationDate          ProvisioningState AdminUserEnabled
----   ------- -----------       ------------          ----------------- ----------------
testc2 Premium testc2.azurecr.io 17/01/2023 3:47:50 pm Succeeded         True
testc  Premium testc.azurecr.io  16/01/2023 8:45:50 pm Succeeded         True
```

This command gets all the container registries in a resource group.

### Example 3:  Get all the container registries in the subscription
```powershell
Get-AzContainerRegistry
```

```output
Name   SkuName LoginServer       CreationDate          ProvisioningState AdminUserEnabled
----   ------- -----------       ------------          ----------------- ----------------
testc2 Premium testc2.azurecr.io 17/01/2023 3:47:50 pm Succeeded         True
testc  Premium testc.azurecr.io  16/01/2023 8:45:50 pm Succeeded         True
```

This command gets all the container registries in the subscription.

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

### -IncludeDetail
Usage of an azure container registry.

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
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RegistryName, ResourceName, ContainerRegistryName

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
Parameter Sets: List1, Get
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
Parameter Sets: List2, List1, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IRegistry

## NOTES

## RELATED LINKS
