---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azresource
schema: 2.0.0
---

# New-AzResource

## SYNOPSIS
Creates a resource.

## SYNTAX

### Create1 (Default)
```
New-AzResource -ResourceId <String> [-Parameters <IGenericResource>] [-DefaultProfile <PSObject>] [-AsJob]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateSubscriptionIdViaHostExpanded
```
New-AzResource -Name <String> -ParentResourcePath <String> -ProviderNamespace <String>
 -ResourceGroupName <String> -ResourceType <String> [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentities <IIdentityUserAssignedIdentities>] [-Kind <String>] [-Location <String>]
 [-ManagedBy <String>] -PlanName <String> -PlanProduct <String> [-PlanPromotionCode <String>]
 -PlanPublisher <String> -PlanVersion <String> [-Properties <IGenericResourceProperties>]
 [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>] -SkuName <String> [-SkuSize <String>]
 [-SkuTier <String>] [-Tag <IResourceTags>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateSubscriptionIdViaHost
```
New-AzResource -Name <String> -ParentResourcePath <String> -ProviderNamespace <String>
 -ResourceGroupName <String> -ResourceType <String> [-Parameters <IGenericResource>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded
```
New-AzResource -Name <String> -ParentResourcePath <String> -ProviderNamespace <String>
 -ResourceGroupName <String> -ResourceType <String> -SubscriptionId <String>
 [-IdentityType <ResourceIdentityType>] [-IdentityUserAssignedIdentities <IIdentityUserAssignedIdentities>]
 [-Kind <String>] [-Location <String>] [-ManagedBy <String>] -PlanName <String> -PlanProduct <String>
 [-PlanPromotionCode <String>] -PlanPublisher <String> -PlanVersion <String>
 [-Properties <IGenericResourceProperties>] [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>]
 -SkuName <String> [-SkuSize <String>] [-SkuTier <String>] [-Tag <IResourceTags>] [-DefaultProfile <PSObject>]
 [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Create
```
New-AzResource -Name <String> -ParentResourcePath <String> -ProviderNamespace <String>
 -ResourceGroupName <String> -ResourceType <String> -SubscriptionId <String> [-Parameters <IGenericResource>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded1
```
New-AzResource -ResourceId <String> [-IdentityType <ResourceIdentityType>]
 [-IdentityUserAssignedIdentities <IIdentityUserAssignedIdentities>] [-Kind <String>] [-Location <String>]
 [-ManagedBy <String>] -PlanName <String> -PlanProduct <String> [-PlanPromotionCode <String>]
 -PlanPublisher <String> -PlanVersion <String> [-Properties <IGenericResourceProperties>]
 [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuModel <String>] -SkuName <String> [-SkuSize <String>]
 [-SkuTier <String>] [-Tag <IResourceTags>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a resource.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

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

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.ResourceIdentityType
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentities
The list of user identities associated with the resource.
The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IIdentityUserAssignedIdentities
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
The kind of the resource.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
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
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
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
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the resource to create.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateSubscriptionIdViaHost, CreateExpanded, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
Resource information.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IGenericResource
Parameter Sets: Create1, CreateSubscriptionIdViaHost, Create
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ParentResourcePath
The parent resource identity.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateSubscriptionIdViaHost, CreateExpanded, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanName
The plan name.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanProduct
The product code.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanPromotionCode
The promotion code.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanPublisher
The publisher ID.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanVersion
The plan's version.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Properties
The resource properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IGenericResourceProperties
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderNamespace
The namespace of the resource provider.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateSubscriptionIdViaHost, CreateExpanded, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group for the resource.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateSubscriptionIdViaHost, CreateExpanded, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The fully qualified ID of the resource, including the resource name and resource type.
Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}

```yaml
Type: System.String
Parameter Sets: Create1, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
The resource type of the resource to create.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateSubscriptionIdViaHost, CreateExpanded, Create
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
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuFamily
The SKU family.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
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
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
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
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuSize
The SKU size.

```yaml
Type: System.String
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
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
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
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
Parameter Sets: CreateExpanded, Create
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
Parameter Sets: CreateSubscriptionIdViaHostExpanded, CreateExpanded, CreateExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IGenericResource
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azresource](https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azresource)

