---
external help file:
Module Name: Az.Mdp
online version: https://learn.microsoft.com/powershell/module/az.mdp/new-azmdppool
schema: 2.0.0
---

# New-AzMdpPool

## SYNOPSIS
create a Pool

## SYNTAX

### CreateExpanded (Default)
```
New-AzMdpPool -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-AgentProfile <IAgentProfile>] [-DevCenterProjectResourceId <String>] [-EnableSystemAssignedIdentity]
 [-FabricProfile <IFabricProfile>] [-MaximumConcurrency <Int32>] [-OrganizationProfile <IOrganizationProfile>]
 [-ProvisioningState <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzMdpPool -Name <String> -ResourceGroupName <String> -Resource <IPool> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzMdpPool -InputObject <IMdpIdentity> -Resource <IPool> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzMdpPool -InputObject <IMdpIdentity> -Location <String> [-AgentProfile <IAgentProfile>]
 [-DevCenterProjectResourceId <String>] [-EnableSystemAssignedIdentity] [-FabricProfile <IFabricProfile>]
 [-MaximumConcurrency <Int32>] [-OrganizationProfile <IOrganizationProfile>] [-ProvisioningState <String>]
 [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzMdpPool -Name <String> -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzMdpPool -Name <String> -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
create a Pool

## EXAMPLES

### Example 1: Create a Managed DevOps Pool
```powershell
New-AzMdpPool -Name Contoso -ResourceGroupName testRG -Location westus -MaximumConcurrency 2 -DevCenterProjectResourceId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/example/providers/Microsoft.DevCenter/projects/contoso-proj" -AgentProfile '{"kind": "stateless"}' -OrganizationProfile '{"kind": "AzureDevOps","organizations": [{"url": "https://dev.azure.com/contoso-org","projects": null,"parallelism": 1}],"permissionProfile": {"kind": "CreatorOnly"}}' -FabricProfile '{"kind": "Vmss", "sku": {"name": "Standard_DS12_v2"}, "storageProfile": { "osDiskStorageAccountType": "Standard","dataDisks": []},"images": [{"resourceId": "/Subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/Providers/Microsoft.Compute/Locations/eastus2/Publishers/canonical/ArtifactTypes/VMImage/Offers/0001-com-ubuntu-server-focal/Skus/20_04-lts-gen2/versions/latest","buffer": "*"}]}'
```

This command creates a Managed DevOps Pool named "Contoso" under the resource group "testRG"

### Example 2: Create a Managed DevOps Pool using InputObject
```powershell
$pool = @{"ResourceGroupName" = "testRg"; "PoolName" = "Contoso"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}

New-AzMdpPool -InputObject $pool -Location westus -MaximumConcurrency 2 -DevCenterProjectResourceId "/subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/resourceGroups/example/providers/Microsoft.DevCenter/projects/contoso-proj" -AgentProfile '{"kind": "stateless"}' -OrganizationProfile '{"kind": "AzureDevOps","organizations": [{"url": "https://dev.azure.com/contoso-org","projects": null,"parallelism": 1}],"permissionProfile": {"kind": "CreatorOnly"}}' -FabricProfile '{"kind": "Vmss", "sku": {"name": "Standard_DS12_v2"}, "storageProfile": { "osDiskStorageAccountType": "Standard","dataDisks": []},"images": [{"resourceId": "/Subscriptions/0ac520ee-14c0-480f-b6c9-0a90c58ffff/Providers/Microsoft.Compute/Locations/eastus2/Publishers/canonical/ArtifactTypes/VMImage/Offers/0001-com-ubuntu-server-focal/Skus/20_04-lts-gen2/versions/latest","buffer": "*"}]}'
```

This command creates a Managed DevOps Pool named "Contoso" under the resource group "testRG"

## PARAMETERS

### -AgentProfile
Defines how the machine will be handled once it executed a job.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IAgentProfile
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -DevCenterProjectResourceId
The resource id of the DevCenter Project the pool belongs to.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricProfile
Defines the type of fabric the agent will run on.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IFabricProfile
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IMdpIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaximumConcurrency
Defines how many resources can there be created at any given time.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the pool.
It needs to be globally unique.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: PoolName

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

### -OrganizationProfile
Defines the organization in which the pool will be used.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IOrganizationProfile
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningState
The status of the current operation.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
Concrete tracked resource types can be created by aliasing this type using a specific property type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IPool
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IMdpIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IPool

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Mdp.Models.IPool

## NOTES

## RELATED LINKS

