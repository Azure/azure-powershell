---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azmanagedapplicationdefinition
schema: 2.0.0
---

# Set-AzManagedApplicationDefinition

## SYNOPSIS
Creates a new managed application definition.

## SYNTAX

### Update1 (Default)
```
Set-AzManagedApplicationDefinition -Id <String> [-Parameter <IApplicationDefinition>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzManagedApplicationDefinition -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Artifact <IApplicationArtifact[]>] -Authorization <IApplicationProviderAuthorization[]>
 [-CreateUiDefinition <IApplicationDefinitionPropertiesCreateUiDefinition>] [-Description <String>]
 [-DisplayName <String>] [-Identity <IIdentity>] [-IsEnabled <String>] [-Location <String>]
 -LockLevel <ApplicationLockLevel> [-MainTemplate <IApplicationDefinitionPropertiesMainTemplate>]
 [-ManagedBy <String>] [-PackageFileUri <String>] [-Sku <ISku>] [-Tag <IResourceTags>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Set-AzManagedApplicationDefinition -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameter <IApplicationDefinition>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzManagedApplicationDefinition -Id <String> [-Artifact <IApplicationArtifact[]>]
 -Authorization <IApplicationProviderAuthorization[]>
 [-CreateUiDefinition <IApplicationDefinitionPropertiesCreateUiDefinition>] [-Description <String>]
 [-DisplayName <String>] [-Identity <IIdentity>] [-IsEnabled <String>] [-Location <String>]
 -LockLevel <ApplicationLockLevel> [-MainTemplate <IApplicationDefinitionPropertiesMainTemplate>]
 [-ManagedBy <String>] [-PackageFileUri <String>] [-Sku <ISku>] [-Tag <IResourceTags>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Set-AzManagedApplicationDefinition -InputObject <IResourcesIdentity> [-Artifact <IApplicationArtifact[]>]
 -Authorization <IApplicationProviderAuthorization[]>
 [-CreateUiDefinition <IApplicationDefinitionPropertiesCreateUiDefinition>] [-Description <String>]
 [-DisplayName <String>] [-Identity <IIdentity>] [-IsEnabled <String>] [-Location <String>]
 -LockLevel <ApplicationLockLevel> [-MainTemplate <IApplicationDefinitionPropertiesMainTemplate>]
 [-ManagedBy <String>] [-PackageFileUri <String>] [-Sku <ISku>] [-Tag <IResourceTags>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzManagedApplicationDefinition -InputObject <IResourcesIdentity> [-Artifact <IApplicationArtifact[]>]
 -Authorization <IApplicationProviderAuthorization[]>
 [-CreateUiDefinition <IApplicationDefinitionPropertiesCreateUiDefinition>] [-Description <String>]
 [-DisplayName <String>] [-Identity <IIdentity>] [-IsEnabled <String>] [-Location <String>]
 -LockLevel <ApplicationLockLevel> [-MainTemplate <IApplicationDefinitionPropertiesMainTemplate>]
 [-ManagedBy <String>] [-PackageFileUri <String>] [-Sku <ISku>] [-Tag <IResourceTags>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity1
```
Set-AzManagedApplicationDefinition -InputObject <IResourcesIdentity> [-Parameter <IApplicationDefinition>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzManagedApplicationDefinition -InputObject <IResourcesIdentity> [-Parameter <IApplicationDefinition>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new managed application definition.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -Artifact
The collection of managed application artifacts. The portal will use the files specified as artifacts to construct the user experience of creating a managed application from a managed application definition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationArtifact[]
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Authorization
The managed application provider authorizations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationProviderAuthorization[]
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreateUiDefinition
The createUiDefinition json for the backing template with Microsoft.Solutions/applications resource.
It can be a JObject or well-formed JSON string.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinitionPropertiesCreateUiDefinition
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
The managed application definition description.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The managed application definition display name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The fully qualified ID of the managed application definition, including the managed application name and the managed application definition resource type.
Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applicationDefinitions/{applicationDefinition-name}

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases: ApplicationDefinitionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Identity
The identity of the resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901Preview.IIdentity
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentity1, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsEnabled
A value indicating whether the package is enabled or not.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LockLevel
The managed application lock level.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ApplicationLockLevel
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MainTemplate
The inline main template json which has resources to be provisioned.
It can be a JObject or well-formed JSON string.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinitionPropertiesMainTemplate
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedBy
ID of the resource that manages this resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the managed application definition.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
Aliases: ApplicationDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageFileUri
The managed application definition package file Uri.
Use this element

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Information about managed application definition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinition
Parameter Sets: Update1, Update, UpdateViaIdentity1, UpdateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Sku
The SKU of the resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901Preview.ISku
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901Preview.IResourceTags
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded1, UpdateViaIdentityExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinition
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azmanagedapplicationdefinition](https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azmanagedapplicationdefinition)

