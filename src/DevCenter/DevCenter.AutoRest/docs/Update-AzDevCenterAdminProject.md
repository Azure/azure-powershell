---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/update-azdevcenteradminproject
schema: 2.0.0
---

# Update-AzDevCenterAdminProject

## SYNOPSIS
Update a project.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDevCenterAdminProject -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AzureAiServiceSettingAzureAiServicesMode <String>] [-CatalogSettingCatalogItemSyncType <String[]>]
 [-CustomizationSettingIdentity <IProjectCustomizationManagedIdentity[]>]
 [-CustomizationSettingUserCustomizationsEnableStatus <String>] [-Description <String>]
 [-DevBoxAutoDeleteSettingDeleteMode <String>] [-DevBoxAutoDeleteSettingGracePeriod <String>]
 [-DevBoxAutoDeleteSettingInactiveThreshold <String>] [-DisplayName <String>]
 [-EnableSystemAssignedIdentity <Boolean?>] [-MaxDevBoxesPerUser <Int32>]
 [-ServerlessGpuSessionSettingMaxConcurrentSessionsPerProject <Int32>]
 [-ServerlessGpuSessionSettingServerlessGpuSessionsMode <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-WorkspaceStorageSettingWorkspaceStorageMode <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDevCenterAdminProject -InputObject <IDevCenterIdentity>
 [-AzureAiServiceSettingAzureAiServicesMode <String>] [-CatalogSettingCatalogItemSyncType <String[]>]
 [-CustomizationSettingIdentity <IProjectCustomizationManagedIdentity[]>]
 [-CustomizationSettingUserCustomizationsEnableStatus <String>] [-Description <String>]
 [-DevBoxAutoDeleteSettingDeleteMode <String>] [-DevBoxAutoDeleteSettingGracePeriod <String>]
 [-DevBoxAutoDeleteSettingInactiveThreshold <String>] [-DisplayName <String>]
 [-EnableSystemAssignedIdentity <Boolean?>] [-MaxDevBoxesPerUser <Int32>]
 [-ServerlessGpuSessionSettingMaxConcurrentSessionsPerProject <Int32>]
 [-ServerlessGpuSessionSettingServerlessGpuSessionsMode <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-WorkspaceStorageSettingWorkspaceStorageMode <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a project.

## EXAMPLES

### Example 1: Update a project
```powershell
Update-AzDevCenterAdminProject -Name DevProject -ResourceGroupName testRg -MaxDevBoxesPerUser 5
```

This command updates a project name "DevProject" in the resource group "testRg".

### Example 2: Update a project using InputObject
```powershell
$projectInput = Get-AzDevCenterAdminProject -ResourceGroupName testRg -Name DevProject

Update-AzDevCenterAdminProject -InputObject $projectInput -MaxDevBoxesPerUser 5
```

This command updates a project name "DevProject" in the resource group "testRg".

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

### -AzureAiServiceSettingAzureAiServicesMode
The property indicates whether Azure AI services is enabled.

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

### -CatalogSettingCatalogItemSyncType
Indicates catalog item types that can be synced.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomizationSettingIdentity
The identities that can to be used in customization scenarios; e.g., to clone a repository.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IProjectCustomizationManagedIdentity[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomizationSettingUserCustomizationsEnableStatus
Indicates whether user customizations are enabled.

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

### -DevBoxAutoDeleteSettingDeleteMode
Indicates the delete mode for Dev Boxes within this project.

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

### -DevBoxAutoDeleteSettingGracePeriod
ISO8601 duration required for the dev box to be marked for deletion prior to it being deleted.
ISO8601 format PT[n]H[n]M[n]S.

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

### -DevBoxAutoDeleteSettingInactiveThreshold
ISO8601 duration required for the dev box to not be inactive prior to it being scheduled for deletion.
ISO8601 format PT[n]H[n]M[n]S.

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

### -DisplayName
The display name of the project.

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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=10.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerlessGpuSessionSettingMaxConcurrentSessionsPerProject
When specified, limits the maximum number of concurrent sessions across all pools in the project.

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

### -ServerlessGpuSessionSettingServerlessGpuSessionsMode
The property indicates whether serverless GPU access is enabled on the project.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceStorageSettingWorkspaceStorageMode
Indicates whether workspace storage is enabled.

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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IProject

## NOTES

## RELATED LINKS

