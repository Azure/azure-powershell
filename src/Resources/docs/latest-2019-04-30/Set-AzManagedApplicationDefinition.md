---
external help file:
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
Set-AzManagedApplicationDefinition -Id <String> -Parameter <IApplicationDefinition>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzManagedApplicationDefinition -Name <String> -ResourceGroupName <String>
 -Parameter <IApplicationDefinition> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzManagedApplicationDefinition -Name <String> -ResourceGroupName <String>
 -Authorization <IApplicationProviderAuthorization[]> -LockLevel <ApplicationLockLevel>
 [-SubscriptionId <String>] [-Artifact <IApplicationArtifact[]>]
 [-CreateUiDefinition <IApplicationDefinitionPropertiesCreateUiDefinition>] [-Description <String>]
 [-DisplayName <String>] [-IdentityType <ResourceIdentityType>] [-IsEnabled <String>] [-Location <String>]
 [-MainTemplate <IApplicationDefinitionPropertiesMainTemplate>] [-ManagedBy <String>]
 [-PackageFileUri <String>] [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>]
 [-SkuName <String>] [-SkuSize <String>] [-SkuTier <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzManagedApplicationDefinition -Id <String> -Authorization <IApplicationProviderAuthorization[]>
 -LockLevel <ApplicationLockLevel> [-Artifact <IApplicationArtifact[]>]
 [-CreateUiDefinition <IApplicationDefinitionPropertiesCreateUiDefinition>] [-Description <String>]
 [-DisplayName <String>] [-IdentityType <ResourceIdentityType>] [-IsEnabled <String>] [-Location <String>]
 [-MainTemplate <IApplicationDefinitionPropertiesMainTemplate>] [-ManagedBy <String>]
 [-PackageFileUri <String>] [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>]
 [-SkuName <String>] [-SkuSize <String>] [-SkuTier <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new managed application definition.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Artifact
The collection of managed application artifacts.
The portal will use the files specified as artifacts to construct the user experience of creating a managed application from a managed application definition.
To construct, see NOTES section for ARTIFACT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationArtifact[]
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

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
Dynamic: False
```

### -Authorization
The managed application provider authorizations.
To construct, see NOTES section for AUTHORIZATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationProviderAuthorization[]
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CreateUiDefinition
The createUiDefinition json for the backing template with Microsoft.Solutions/applications resource.
It can be a JObject or well-formed JSON string.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinitionPropertiesCreateUiDefinition
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -Description
The managed application definition description.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DisplayName
The managed application definition display name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ResourceIdentityType
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IsEnabled
A value indicating whether the package is enabled or not.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LockLevel
The managed application lock level.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ApplicationLockLevel
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MainTemplate
The inline main template json which has resources to be provisioned.
It can be a JObject or well-formed JSON string.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinitionPropertiesMainTemplate
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ManagedBy
ID of the resource that manages this resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the managed application definition.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases: ApplicationDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -PackageFileUri
The managed application definition package file Uri.
Use this element

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Information about managed application definition.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinition
Parameter Sets: Update, Update1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuCapacity
The SKU capacity.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuFamily
The SKU family.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuModel
The SKU model.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
The SKU name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuSize
The SKU size.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuTier
The SKU tier.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinition

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20170901.IApplicationDefinition

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### ARTIFACT <IApplicationArtifact[]>: The collection of managed application artifacts. The portal will use the files specified as artifacts to construct the user experience of creating a managed application from a managed application definition.
  - `[Name <String>]`: The managed application artifact name.
  - `[Type <ApplicationArtifactType?>]`: The managed application artifact type.
  - `[Uri <String>]`: The managed application artifact blob uri.

#### AUTHORIZATION <IApplicationProviderAuthorization[]>: The managed application provider authorizations.
  - `PrincipalId <String>`: The provider's principal identifier. This is the identity that the provider will use to call ARM to manage the managed application resources.
  - `RoleDefinitionId <String>`: The provider's role definition identifier. This role will define all the permissions that the provider must have on the managed application's container resource group. This role definition cannot have permission to delete the resource group.

#### PARAMETER <IApplicationDefinition>: Information about managed application definition.
  - `SkuName <String>`: The SKU name.
  - `Authorization <IApplicationProviderAuthorization[]>`: The managed application provider authorizations.
    - `PrincipalId <String>`: The provider's principal identifier. This is the identity that the provider will use to call ARM to manage the managed application resources.
    - `RoleDefinitionId <String>`: The provider's role definition identifier. This role will define all the permissions that the provider must have on the managed application's container resource group. This role definition cannot have permission to delete the resource group.
  - `LockLevel <ApplicationLockLevel>`: The managed application lock level.
  - `[IdentityType <ResourceIdentityType?>]`: The identity type.
  - `[ManagedBy <String>]`: ID of the resource that manages this resource.
  - `[SkuCapacity <Int32?>]`: The SKU capacity.
  - `[SkuFamily <String>]`: The SKU family.
  - `[SkuModel <String>]`: The SKU model.
  - `[SkuSize <String>]`: The SKU size.
  - `[SkuTier <String>]`: The SKU tier.
  - `[Location <String>]`: Resource location
  - `[Tag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Artifact <IApplicationArtifact[]>]`: The collection of managed application artifacts. The portal will use the files specified as artifacts to construct the user experience of creating a managed application from a managed application definition.
    - `[Name <String>]`: The managed application artifact name.
    - `[Type <ApplicationArtifactType?>]`: The managed application artifact type.
    - `[Uri <String>]`: The managed application artifact blob uri.
  - `[CreateUiDefinition <IApplicationDefinitionPropertiesCreateUiDefinition>]`: The createUiDefinition json for the backing template with Microsoft.Solutions/applications resource. It can be a JObject or well-formed JSON string.
  - `[Description <String>]`: The managed application definition description.
  - `[DisplayName <String>]`: The managed application definition display name.
  - `[IsEnabled <String>]`: A value indicating whether the package is enabled or not.
  - `[MainTemplate <IApplicationDefinitionPropertiesMainTemplate>]`: The inline main template json which has resources to be provisioned. It can be a JObject or well-formed JSON string.
  - `[PackageFileUri <String>]`: The managed application definition package file Uri. Use this element

## RELATED LINKS

