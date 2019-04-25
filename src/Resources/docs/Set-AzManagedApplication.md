---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azmanagedapplication
schema: 2.0.0
---

# Set-AzManagedApplication

## SYNOPSIS
Creates a new managed application.

## SYNTAX

### Update1 (Default)
```
Set-AzManagedApplication -Id <String> [-Parameters <IApplication>] [-DefaultProfile <PSObject>] [-AsJob]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateSubscriptionIdViaHostExpanded
```
Set-AzManagedApplication -Name <String> -ResourceGroupName <String> [-Parameters <IApplication>]
 [-DefinitionId <String>] [-Identity <IIdentity>] -Kind <String> [-Location <String>] [-ManagedBy <String>]
 -ManagedResourceGroupId <String> [-Plan <IPlan>] [-ProvisioningState <String>] [-Sku <ISku>]
 [-Tag <IResourceTags>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateSubscriptionIdViaHost
```
Set-AzManagedApplication -Name <String> -ResourceGroupName <String> [-Parameters <IApplication>]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzManagedApplication -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameters <IApplication>] [-DefinitionId <String>] [-Identity <IIdentity>] -Kind <String>
 [-Location <String>] [-ManagedBy <String>] -ManagedResourceGroupId <String> [-Plan <IPlan>]
 [-ProvisioningState <String>] [-Sku <ISku>] [-Tag <IResourceTags>] [-DefaultProfile <PSObject>] [-AsJob]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Update
```
Set-AzManagedApplication -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-Parameters <IApplication>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzManagedApplication -Id <String> [-Parameters <IApplication>] [-DefinitionId <String>]
 [-Identity <IIdentity>] -Kind <String> [-Location <String>] [-ManagedBy <String>]
 -ManagedResourceGroupId <String> [-Plan <IPlan>] [-ProvisioningState <String>] [-Sku <ISku>]
 [-Tag <IResourceTags>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new managed application.

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

### -DefinitionId
The fully qualified path of managed application definition Id.

```yaml
Type: System.String
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
The fully qualified ID of the managed application, including the managed application name and the managed application resource type.
Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/Microsoft.Solutions/applications/{application-name}

```yaml
Type: System.String
Parameter Sets: Update1, UpdateExpanded1
Aliases:

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
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
The kind of the managed application.
Allowed values are MarketPlace and ServiceCatalog.

```yaml
Type: System.String
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateExpanded1
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
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedResourceGroupId
The managed resource group Id.

```yaml
Type: System.String
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the managed application.

```yaml
Type: System.String
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateSubscriptionIdViaHost, UpdateExpanded, Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameters
Information about managed application.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180601.IApplication
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Plan
The plan information.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20160901Preview.IPlan
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningState
The managed application provisioning state.

```yaml
Type: System.String
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateExpanded1
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
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateSubscriptionIdViaHost, UpdateExpanded, Update
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
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateExpanded1
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
Parameter Sets: UpdateSubscriptionIdViaHostExpanded, UpdateExpanded, UpdateExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180601.IApplication
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azmanagedapplication](https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azmanagedapplication)

