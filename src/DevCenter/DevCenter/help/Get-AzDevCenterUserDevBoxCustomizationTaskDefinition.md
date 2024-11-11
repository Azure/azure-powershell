---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteruserdevboxcustomizationtaskdefinition
schema: 2.0.0
---

# Get-AzDevCenterUserDevBoxCustomizationTaskDefinition

## SYNOPSIS
Gets a customization task.

## SYNTAX

### List (Default)
```
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -Endpoint <String> -ProjectName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -Endpoint <String> -ProjectName <String>
 -CatalogName <String> -TaskName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -Endpoint <String> -InputObject <IDevCenterdataIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityByDevCenter
```
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -DevCenterName <String>
 -InputObject <IDevCenterdataIdentity> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ListByDevCenter
```
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -DevCenterName <String> -ProjectName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByDevCenter
```
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -DevCenterName <String> -ProjectName <String>
 -CatalogName <String> -TaskName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets a customization task.

## EXAMPLES

### Example 1: List customization tasks by endpoint
```powershell
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject
```

This command lists customization tasks in the project "DevProject".

### Example 2: List customization tasks by dev center
```powershell
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -DevCenterName Contoso -ProjectName DevProject
```

This command lists customization tasks in the project "DevProject".

### Example 3: Get a customization task by endpoint
```powershell
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -ProjectName DevProject -TaskName choco -CatalogName MyCatalog
```

This command gets a customization task named "choco" for the catalog "MyCatalog" in the project "DevProject".

### Example 4: Get a customization task by dev center
```powershell
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -DevCenterName Contoso -ProjectName DevProject -TaskName choco -CatalogName MyCatalog
```

This command gets a customization task named "choco" for the catalog "MyCatalog" in the project "DevProject".

### Example 5: Get a customization task by endpoint and InputObject
```powershell
$customizationTaskInput = @{"TaskName" = "choco"; "ProjectName" ="DevProject"; "CatalogName" = "MyCatalog" }
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -Endpoint "https://8a40af38-3b4c-4672-a6a4-5e964b1870ed-contosodevcenter.centralus.devcenter.azure.com/" -InputObject $customizationTaskInput
```

This command gets a customization task named "choco" for the catalog "MyCatalog" in the project "DevProject".

### Example 6: Get a customization task by dev center and InputObject
```powershell
$customizationTaskInput = @{"TaskName" = "choco"; "ProjectName" = "DevProject"; "CatalogName" = "MyCatalog" }
Get-AzDevCenterUserDevBoxCustomizationTaskDefinition -DevCenterName Contoso -InputObject $customizationTaskInput
```

This command gets a customization task named "choco" for the catalog "MyCatalog" in the project "DevProject".

## PARAMETERS

### -CatalogName
Name of the catalog.

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
Name of the project.

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

### -TaskName
Full name of the task: {catalogName}/{taskName}.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.IDevCenterdataIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.Models.Api20240501Preview.ICustomizationTaskDefinition

## NOTES

## RELATED LINKS
