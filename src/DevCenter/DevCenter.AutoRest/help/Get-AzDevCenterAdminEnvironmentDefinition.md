---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteradminenvironmentdefinition
schema: 2.0.0
---

# Get-AzDevCenterAdminEnvironmentDefinition

## SYNOPSIS
Gets an environment definition from the catalog.

## SYNTAX

### List (Default)
```
Get-AzDevCenterAdminEnvironmentDefinition -CatalogName <String> -DevCenterName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterAdminEnvironmentDefinition -CatalogName <String> -DevCenterName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterAdminEnvironmentDefinition -InputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an environment definition from the catalog.

## EXAMPLES

### Example 1: List environment definitions in a catalog
```powershell
Get-AzDevCenterAdminEnvironmentDefinition -DevCenterName Contoso -CatalogName CentralCatalog -ResourceGroupName testRg
```

This command lists the environment definitions in a catalog.

### Example 2: Get an environment definition 
```powershell
Get-AzDevCenterAdminEnvironmentDefinition -DevCenterName Contoso -CatalogName CentralCatalog -ResourceGroupName testRg -Name envDefName
```

This command gets the environment definition "envDefName".

### Example 3: Get an environment definition using InputObject
```powershell
$environmentDefinition = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"; "EnvironmentDefinitionName"="envDefName"}
$environmentDefinition = Get-AzDevCenterAdminEnvironmentDefinition -InputObject $environmentDefinition
```

This command gets the environment definition "envDefName" using InputObject.

## PARAMETERS

### -CatalogName
The name of the Catalog.

```yaml
Type: System.String
Parameter Sets: Get, List
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
The name of the devcenter.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Environment Definition.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: EnvironmentDefinitionName

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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IEnvironmentDefinition

## NOTES

## RELATED LINKS

