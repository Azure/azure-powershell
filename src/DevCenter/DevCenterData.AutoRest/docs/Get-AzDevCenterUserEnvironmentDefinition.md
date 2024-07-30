---
external help file:
Module Name: Az.DevCenterdata
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserenvironmentdefinition
schema: 2.0.0
---

# Get-AzDevCenterUserEnvironmentDefinition

## SYNOPSIS
Get an environment definition from a catalog.

## SYNTAX

### List1 (Default)
```
Get-AzDevCenterUserEnvironmentDefinition -Endpoint <String> -ProjectName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserEnvironmentDefinition -Endpoint <String> -CatalogName <String> -DefinitionName <String>
 -ProjectName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName <String> -CatalogName <String>
 -DefinitionName <String> -ProjectName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserEnvironmentDefinition -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDevCenterUserEnvironmentDefinition -Endpoint <String> -CatalogName <String> -ProjectName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1ByDevCenter
```
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName <String> -ProjectName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName <String> -CatalogName <String> -ProjectName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get an environment definition from a catalog.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell

```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName Contoso -ProjectName DevProject
```



### -------------------------- EXAMPLE 3 --------------------------
```powershell
Get-AzDevCenterUserEnvironmentDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -CatalogName CentralCatalog
```



### -------------------------- EXAMPLE 4 --------------------------
```powershell
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName Contoso -ProjectName DevProject -CatalogName CentralCatalog
```



### -------------------------- EXAMPLE 5 --------------------------
```powershell
Get-AzDevCenterUserEnvironmentDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -CatalogName CentralCatalog  -DefinitionName Sandbox
```



### -------------------------- EXAMPLE 6 --------------------------
```powershell
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName Contoso -ProjectName DevProject -CatalogName CentralCatalog -DefinitionName Sandbox
```



### -------------------------- EXAMPLE 7 --------------------------
```powershell
$envInput = @{"CatalogName" = "CentralCatalog"; "ProjectName" = "DevProject"; "DefinitionName" = "Sandbox" }
Get-AzDevCenterUserEnvironmentDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $envInput
```



### -------------------------- EXAMPLE 8 --------------------------
```powershell
$envInput = @{"CatalogName" = "CentralCatalog"; "ProjectName" = "DevProject"; "DefinitionName" = "Sandbox" }
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName Contoso -InputObject $envInput
```



## PARAMETERS

### -CatalogName
Name of the catalog.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter, List, ListByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DefinitionName
Name of the environment definition.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: GetByDevCenter, GetViaIdentityByDevCenter, List1ByDevCenter, ListByDevCenter
Aliases: DevCenter

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Endpoint
The DevCenter-specific URI to operate on.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity
Parameter Sets: GetViaIdentity, GetViaIdentityByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectName
Name of the project.

```yaml
Type: System.String
Parameter Sets: Get, GetByDevCenter, List, List1, List1ByDevCenter, ListByDevCenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20240501Preview.IEnvironmentDefinition

## NOTES

## RELATED LINKS

