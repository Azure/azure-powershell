---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserenvironmentdefinition
schema: 2.0.0
---

# Get-AzDevCenterUserEnvironmentDefinition

## SYNOPSIS
Get an environment definition from a catalog.

## SYNTAX

### List (Default)
```
Get-AzDevCenterUserEnvironmentDefinition -Endpoint <String> -ProjectName <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserEnvironmentDefinition -Endpoint <String> -ProjectName <String> -CatalogName <String>
 -DefinitionName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserEnvironmentDefinition -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1
```
Get-AzDevCenterUserEnvironmentDefinition -Endpoint <String> -ProjectName <String> -CatalogName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List1ByDevCenter
```
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName <String> -ProjectName <String> -CatalogName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName <String> -ProjectName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName <String> -ProjectName <String> -CatalogName <String>
 -DefinitionName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Get an environment definition from a catalog.

## EXAMPLES

### Example 1: List environment definitions by endpoint and project
```powershell

```

```powershell
Get-AzDevCenterUserEnvironmentDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject
```

This command lists environment definitions under the project "DevProject".

### Example 2: List environment definitions by dev center and project
```powershell
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName Contoso -ProjectName DevProject
```

This command lists environment definitions under the project "DevProject".

### Example 3: List environment definitions by endpoint, catalog, and project
```powershell
Get-AzDevCenterUserEnvironmentDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -CatalogName CentralCatalog
```

This command lists environment definitions under the project "DevProject" and the catalog "CentralCatalog".

### Example 4: List environment definitions by dev center, catalog, and project
```powershell
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName Contoso -ProjectName DevProject -CatalogName CentralCatalog
```

This command lists environment definitions under the project "DevProject" and the catalog "CentralCatalog".

### Example 5: Get an environment definition by endpoint
```powershell
Get-AzDevCenterUserEnvironmentDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -CatalogName CentralCatalog  -DefinitionName Sandbox
```

This command gets the environment definition "Sandbox" under the project "DevProject" and the catalog "CentralCatalog".

### Example 6: Get an environment definition by dev center
```powershell
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName Contoso -ProjectName DevProject -CatalogName CentralCatalog -DefinitionName Sandbox
```

This command gets the environment definition "Sandbox" under the project "DevProject" and the catalog "CentralCatalog".

### Example 7: Get an environment definition by endpoint and InputObject
```powershell
$envInput = @{"CatalogName" = "CentralCatalog"; "ProjectName" = "DevProject"; "DefinitionName" = "Sandbox" }
Get-AzDevCenterUserEnvironmentDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $envInput
```

This command gets the environment definition "Sandbox" under the project "DevProject" and the catalog "CentralCatalog".

### Example 8: Get an environment definition by dev center and InputObject
```powershell
$envInput = @{"CatalogName" = "CentralCatalog"; "ProjectName" = "DevProject"; "DefinitionName" = "Sandbox" }
Get-AzDevCenterUserEnvironmentDefinition -DevCenterName Contoso -InputObject $envInput
```

This command gets the environment definition "Sandbox" under the project "DevProject" and the catalog "CentralCatalog".

## PARAMETERS

### -CatalogName
The name of the catalog

```yaml
Type: System.String
Parameter Sets: Get, List1, List1ByDevCenter, GetByDevCenter
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
The name of the environment definition

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
Parameter Sets: GetViaIdentityByDevCenter, List1ByDevCenter, ListByDevCenter, GetByDevCenter
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
Parameter Sets: List, Get, GetViaIdentity, List1
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

### -ProjectName
The DevCenter Project upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: List, Get, List1, List1ByDevCenter, ListByDevCenter, GetByDevCenter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20231001Preview.IEnvironmentDefinition

## NOTES

## RELATED LINKS
