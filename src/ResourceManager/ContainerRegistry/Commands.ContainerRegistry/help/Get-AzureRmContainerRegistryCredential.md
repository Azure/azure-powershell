---
external help file: Microsoft.Azure.Commands.ContainerRegistry.dll-Help.xml
Module Name: AzureRM.ContainerRegistry
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.containerregistry/get-azurermcontainerregistrycredential
schema: 2.0.0
---

# Get-AzureRmContainerRegistryCredential

## SYNOPSIS
Gets the login credentials for a container registry.

## SYNTAX

### NameResourceGroupParameterSet
```
Get-AzureRmContainerRegistryCredential [-ResourceGroupName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>]
```

### RegistryObjectParameterSet
```
Get-AzureRmContainerRegistryCredential -Registry <PSContainerRegistry>
 [-DefaultProfile <IAzureContextContainer>]
```

### ResourceIdParameterSet
```
Get-AzureRmContainerRegistryCredential -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The Get-AzureRmContainerRegistryCredential cmdlet gets the login credentials for a container registry.

## EXAMPLES

### Example 1: Get the login credentials for a container registry
```
PS C:\>Get-AzureRmContainerRegistryCredential -ResourceGroupName "MyResourceGroup" -Name "MyRegistry"

Username   Password                         Password2
--------   --------                         ---------
MyRegistry +Y+==B==KdT=YV=ZgH=p/zQ/e1sNQq/d //JRPkgxx+r+z/ztU=R//E==vum=pRKL
```

This command gets the login credentials for the specified container registry.
Admin user has to be enabled for the container registry \`MyRegistry\` to get login credentials.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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
Container Registry Name.

```yaml
Type: String
Parameter Sets: NameResourceGroupParameterSet
Aliases: ContainerRegistryName, RegistryName, ResourceName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Registry
Container Registry Object.

```yaml
Type: PSContainerRegistry
Parameter Sets: RegistryObjectParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: NameResourceGroupParameterSet
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The container registry resource id

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

### PSContainerRegistry
Parameter 'Registry' accepts value of type 'PSContainerRegistry' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryCredential

## NOTES

## RELATED LINKS

[New-AzureRmContainerRegistry]()

[Update-AzureRmContainerRegistry]()

[Update-AzureRmContainerRegistryCredential]()

