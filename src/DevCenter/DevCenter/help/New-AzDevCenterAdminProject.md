---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/new-azdevcenteradminproject
schema: 2.0.0
---

# New-AzDevCenterAdminProject

## SYNOPSIS
Creates or updates a project.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDevCenterAdminProject -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> -DevCenterId <String> [-Description <String>] [-MaxDevBoxesPerUser <Int32>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzDevCenterAdminProject -InputObject <IDevCenterIdentity> -Location <String> -DevCenterId <String>
 [-Description <String>] [-MaxDevBoxesPerUser <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a project.

## EXAMPLES

### Example 1: Create a project
```powershell
New-AzDevCenterAdminProject -Name DevProject -ResourceGroupName testRg -Location eastus -DevCenterId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso" -MaxDevBoxesPerUser 3
```

This command creates a project name "DevProject" in the resource group "testRg".

### Example 2: Create a project using InputObject
```powershell
$project = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminProject -InputObject $project -Location eastus -DevCenterId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/testRg/providers/Microsoft.DevCenter/devcenters/Contoso" -MaxDevBoxesPerUser 3
```

This command creates a project name "DevProject" in the resource group "testRg".

## PARAMETERS

### -AsJob
Run the command as a job

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

### -Description
Description of the project.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DevCenterId
Resource Id of an associated DevCenter

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxDevBoxesPerUser
When specified, limits the maximum number of Dev Boxes a single user can create across all pools in the project.
This will have no effect on existing Dev Boxes when reduced.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the project.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases: ProjectName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20230401.IProject

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IDevCenterIdentity>`: Identity Parameter
  - `[AttachedNetworkConnectionName <String>]`: The name of the attached NetworkConnection.
  - `[CatalogName <String>]`: The name of the Catalog.
  - `[DevBoxDefinitionName <String>]`: The name of the Dev Box definition.
  - `[DevCenterName <String>]`: The name of the devcenter.
  - `[EnvironmentTypeName <String>]`: The name of the environment type.
  - `[GalleryName <String>]`: The name of the gallery.
  - `[Id <String>]`: Resource identity path
  - `[ImageName <String>]`: The name of the image.
  - `[Location <String>]`: The Azure region
  - `[NetworkConnectionName <String>]`: Name of the Network Connection that can be applied to a Pool.
  - `[OperationId <String>]`: The ID of an ongoing async operation
  - `[PoolName <String>]`: Name of the pool.
  - `[ProjectName <String>]`: The name of the project.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ScheduleName <String>]`: The name of the schedule that uniquely identifies it.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[VersionName <String>]`: The version of the image.

## RELATED LINKS
