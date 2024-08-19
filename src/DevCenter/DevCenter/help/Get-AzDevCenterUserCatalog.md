---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenterusercatalog
schema: 2.0.0
---

# Get-AzDevCenterUserCatalog

## SYNOPSIS
Gets the specified catalog within the project

## SYNTAX

### List (Default)
```
Get-AzDevCenterUserCatalog -Endpoint <String> -ProjectName <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserCatalog -Endpoint <String> -ProjectName <String> -CatalogName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserCatalog -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserCatalog -DevCenterName <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserCatalog -DevCenterName <String> -ProjectName <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserCatalog -DevCenterName <String> -ProjectName <String> -CatalogName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified catalog within the project

## EXAMPLES

### Example 1: List catalogs by endpoint
```powershell
Get-AzDevCenterUserCatalog -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject
```

This command lists catalogs in the project "DevProject".

### Example 2: List catalogs by dev center
```powershell
Get-AzDevCenterUserCatalog -DevCenterName Contoso -ProjectName DevProject
```

This command lists catalogs in the project "DevProject".

### Example 3: Get a catalog by endpoint
```powershell
Get-AzDevCenterUserCatalog -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -CatalogName CentralCatalog
```

This command gets a catalog named "CentralCatalog" in the project "DevProject".

### Example 4: Get a catalog by dev center
```powershell
Get-AzDevCenterUserCatalog -DevCenterName Contoso -ProjectName DevProject -CatalogName CentralCatalog
```

This command gets a catalog named "CentralCatalog" in the project "DevProject".

### Example 5: Get a catalog by endpoint and InputObject
```powershell
$catalogInput = @{"CatalogName" = "CentralCatalog"; "ProjectName" =" DevProject" }
Get-AzDevCenterUserCatalog -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $catalogInput
```

This command gets a catalog named "CentralCatalog" in the project "DevProject".

### Example 6: Get a catalog by dev center and InputObject
```powershell
$catalogInput = @{"CatalogName" = "CentralCatalog"; "ProjectName" = "DevProject" }
Get-AzDevCenterUserCatalog -DevCenterName Contoso -InputObject $catalogInput
```

This command gets a catalog named "CentralCatalog" in the project "DevProject".

## PARAMETERS

### -CatalogName
The name of the catalog

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

### -DevCenterName
The DevCenter upon which to execute operations.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityByDevCenter, ListByDevCenter, GetByDevCenter
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
Parameter Sets: List, Get, GetViaIdentity
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
Parameter Sets: List, Get, ListByDevCenter, GetByDevCenter
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20231001Preview.ICatalog

### System.String

## NOTES

## RELATED LINKS
