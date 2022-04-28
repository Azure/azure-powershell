---
external help file:
Module Name: Az.MachineLearningWorkspaces
online version: https://docs.microsoft.com/en-us/powershell/module/az.machinelearningworkspaces/update-azmachinelearningworkspacesworkspace
schema: 2.0.0
---

# Update-AzMachineLearningWorkspacesWorkspace

## SYNOPSIS
Updates a machine learning workspace with the specified parameters.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMachineLearningWorkspacesWorkspace -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-CosmoDbCollectionsThroughput <Int32>] [-Description <String>]
 [-FriendlyName <String>] [-IdentityType <ResourceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-ImageBuildCompute <String>] [-PrimaryUserAssignedIdentity <String>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-SkuName <String>] [-SkuTier <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMachineLearningWorkspacesWorkspace -InputObject <IMachineLearningWorkspacesIdentity>
 [-CosmoDbCollectionsThroughput <Int32>] [-Description <String>] [-FriendlyName <String>]
 [-IdentityType <ResourceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-ImageBuildCompute <String>] [-PrimaryUserAssignedIdentity <String>]
 [-PublicNetworkAccess <PublicNetworkAccess>] [-SkuName <String>] [-SkuTier <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a machine learning workspace with the specified parameters.

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

### -CosmoDbCollectionsThroughput
The throughput of the collections in cosmosdb database

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
The description of this workspace.

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

### -FriendlyName
The friendly name for this workspace.

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

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The user assigned identities associated with the resource.

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

### -ImageBuildCompute
The compute name for image build

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Models.IMachineLearningWorkspacesIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of Azure Machine Learning workspace.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: WorkspaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrimaryUserAssignedIdentity
The user assigned identity resource id that represents the workspace identity.

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

### -PublicNetworkAccess
Whether requests from Public Network are allowed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Support.PublicNetworkAccess
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

### -SkuName
Name of the sku

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
Tier of the sku like Basic or Enterprise

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
The resource tags for the machine learning workspace.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Models.IMachineLearningWorkspacesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningWorkspaces.Models.Api20210701.IWorkspace

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IMachineLearningWorkspacesIdentity>: Identity Parameter
  - `[ComputeName <String>]`: Name of the Azure Machine Learning compute.
  - `[ConnectionName <String>]`: Friendly name of the workspace connection
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The location for which resource usage is queried.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection associated with the workspace
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[WorkspaceName <String>]`: Name of Azure Machine Learning workspace.

## RELATED LINKS

