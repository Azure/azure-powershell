---
external help file: Microsoft.Azure.Commands.ContainerRegistry.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmContainerRegistryCredential

## SYNOPSIS
Gets the login credentials for a container registry.

## SYNTAX

```
Get-AzureRmContainerRegistryCredential [-ResourceGroupName] <String> [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmContainerRegistryCredential** cmdlet gets the login credentials for a container registry.

## EXAMPLES

### Example 1: Get the login credentials for a container registry
```
PS C:\>Get-AzureRmContainerRegistryCredential -ResourceGroupName "MyResourceGroup" -Name "MyRegistry"

Username   Password                         Password2
--------   --------                         ---------
MyRegistry +Y+==B==KdT=YV=ZgH=p/zQ/e1sNQq/d //JRPkgxx+r+z/ztU=R//E==vum=pRKL
```

This command gets the login credentials for the specified container registry. Admin user has to be enabled for the container registry `MyRegistry` to get login credentials.

## PARAMETERS

### -Name
Container Registry Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ContainerRegistryName, RegistryName, ResourceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.ContainerRegistry.PSContainerRegistryCredential

## NOTES

## RELATED LINKS

[New-AzureRmContainerRegistry](./New-AzureRmContainerRegistry.md)

[Update-AzureRmContainerRegistry](./Update-AzureRmContainerRegistry.md)

[Update-AzureRmContainerRegistryCredential](./Update-AzureRmContainerRegistryCredential.md)

