---
external help file:
Module Name: Az.Application
online version: https://docs.microsoft.com/en-us/powershell/module/az.application/new-azapplicationdefinition
schema: 2.0.0
---

# New-AzApplicationDefinition

## SYNOPSIS
Creates a new managed application definition.

## SYNTAX

```
New-AzApplicationDefinition -Name <String> -ResourceGroupName <String> -LockLevel <ApplicationLockLevel>
 [-SubscriptionId <String>] [-Artifact <IApplicationDefinitionArtifact[]>]
 [-Authorization <IApplicationAuthorization[]>] [-CreateUiDefinition <IAny>]
 [-DeploymentPolicyDeploymentMode <DeploymentMode>] [-Description <String>] [-DisplayName <String>]
 [-IsEnabled] [-Location <String>] [-LockingPolicyAllowedAction <String[]>]
 [-LockingPolicyAllowedDataAction <String[]>] [-MainTemplate <IAny>] [-ManagedBy <String>]
 [-ManagementPolicyMode <ApplicationManagementMode>]
 [-NotificationPolicyNotificationEndpoint <IApplicationNotificationEndpoint[]>] [-PackageFileUri <String>]
 [-Policy <IApplicationPolicy[]>] [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>]
 [-SkuName <String>] [-SkuSize <String>] [-SkuTier <String>] [-StorageAccountId <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new managed application definition.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Artifact
The collection of managed application artifacts.
The portal will use the files specified as artifacts to construct the user experience of creating a managed application from a managed application definition.
To construct, see NOTES section for ARTIFACT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Application.Models.Api20210701.IApplicationDefinitionArtifact[]
Parameter Sets: (All)
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Authorization
The managed application provider authorizations.
To construct, see NOTES section for AUTHORIZATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Application.Models.Api20210701.IApplicationAuthorization[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CreateUiDefinition
The createUiDefinition json for the backing template with Microsoft.Solutions/applications resource.
It can be a JObject or well-formed JSON string.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Application.Models.IAny
Parameter Sets: (All)
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

### -DeploymentPolicyDeploymentMode
The managed application deployment mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Application.Support.DeploymentMode
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsEnabled
A value indicating whether the package is enabled or not.

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

### -Location
Resource location

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

### -LockingPolicyAllowedAction
The deny assignment excluded actions.

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

### -LockingPolicyAllowedDataAction
The deny assignment excluded data actions.

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

### -LockLevel
The managed application lock level.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Application.Support.ApplicationLockLevel
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Application.Models.IAny
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagementPolicyMode
The managed application management mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Application.Support.ApplicationManagementMode
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases: ApplicationDefinitionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationPolicyNotificationEndpoint
The managed application notification endpoint.
To construct, see NOTES section for NOTIFICATIONPOLICYNOTIFICATIONENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Application.Models.Api20210701.IApplicationNotificationEndpoint[]
Parameter Sets: (All)
Aliases:

Required: False
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

### -PackageFileUri
The managed application definition package file Uri.
Use this element

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

### -Policy
The managed application provider policies.
To construct, see NOTES section for POLICY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Application.Models.Api20210701.IApplicationPolicy[]
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
The SKU capacity.

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

### -SkuFamily
The SKU family.

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

### -SkuModel
The SKU model.

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

### -SkuName
The SKU name.

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

### -SkuSize
The SKU size.

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

### -SkuTier
The SKU tier.

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

### -StorageAccountId
The storage account id for bring your own storage scenario.

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Application.Models.Api20210701.IApplicationDefinition

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ARTIFACT <IApplicationDefinitionArtifact[]>: The collection of managed application artifacts. The portal will use the files specified as artifacts to construct the user experience of creating a managed application from a managed application definition.
  - `Name <ApplicationDefinitionArtifactName>`: The managed application definition artifact name.
  - `Type <ApplicationArtifactType>`: The managed application definition artifact type.
  - `Uri <String>`: The managed application definition artifact blob uri.

AUTHORIZATION <IApplicationAuthorization[]>: The managed application provider authorizations.
  - `PrincipalId <String>`: The provider's principal identifier. This is the identity that the provider will use to call ARM to manage the managed application resources.
  - `RoleDefinitionId <String>`: The provider's role definition identifier. This role will define all the permissions that the provider must have on the managed application's container resource group. This role definition cannot have permission to delete the resource group.

NOTIFICATIONPOLICYNOTIFICATIONENDPOINT <IApplicationNotificationEndpoint[]>: The managed application notification endpoint.
  - `Uri <String>`: The managed application notification endpoint uri.

POLICY <IApplicationPolicy[]>: The managed application provider policies.
  - `[Name <String>]`: The policy name
  - `[Parameter <String>]`: The policy parameters.
  - `[PolicyDefinitionId <String>]`: The policy definition Id.

## RELATED LINKS

