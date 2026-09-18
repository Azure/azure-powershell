---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteradminprojectcatalogimagedefinitionbuilddetail
schema: 2.0.0
---

# Get-AzDevCenterAdminProjectCatalogImageDefinitionBuildDetail

## SYNOPSIS
Gets Build details

## SYNTAX

### Get (Default)
```
Get-AzDevCenterAdminProjectCatalogImageDefinitionBuildDetail -BuildName <String> -CatalogName <String>
 -ImageDefinitionName <String> -ProjectName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterAdminProjectCatalogImageDefinitionBuildDetail -InputObject <IDevCenterIdentity>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Gets Build details

## EXAMPLES

### Example 1: Get build details for a specific image definition build
```powershell
Get-AzDevCenterAdminProjectCatalogImageDefinitionBuildDetail `
  -BuildName "0a28fc61-6f87-4611-8fe2-32df44ab93b7" `
  -CatalogName "CentralCatalog" `
  -ImageDefinitionName "DefaultDevImage" `
  -ProjectName "DevProject" `
  -ResourceGroupName "rg1" `
  -SubscriptionId "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
```

This command gets the details for the build with ID "0a28fc61-6f87-4611-8fe2-32df44ab93b7" for the image definition "DefaultDevImage" in the catalog "CentralCatalog" under project "DevProject".

### Example 2: Get build details using InputObject
```powershell
$inputObject = @{
    ResourceGroupName = "rg1"
    ProjectName = "DevProject"
    CatalogName = "CentralCatalog"
    ImageDefinitionName = "DefaultDevImage"
    BuildName = "0a28fc61-6f87-4611-8fe2-32df44ab93b7"
    SubscriptionId = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"
}
Get-AzDevCenterAdminProjectCatalogImageDefinitionBuildDetail -InputObject $inputObject
```

This command gets the build details using an input object.

## PARAMETERS

### -BuildName
The ID of the Image Definition Build.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CatalogName
The name of the Catalog.

```yaml
Type: System.String
Parameter Sets: Get
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

### -ImageDefinitionName
The name of the Image Definition.

```yaml
Type: System.String
Parameter Sets: Get
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

### -ProjectName
The name of the project.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

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
Parameter Sets: Get
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
Parameter Sets: Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20250401Preview.IImageDefinitionBuildDetails

## NOTES

## RELATED LINKS
