---
external help file: Az.FluidRelay-help.xml
Module Name: Az.FluidRelay
online version: https://learn.microsoft.com/powershell/module/az.fluidrelay/new-azfluidrelayserver
schema: 2.0.0
---

# New-AzFluidRelayServer

## SYNOPSIS
create a Fluid Relay server.

## SYNTAX

### CreateExpanded (Default)
```
New-AzFluidRelayServer -Name <String> -ResourceGroup <String> [-SubscriptionId <String>] -Location <String>
 [-CustomerManagedKeyEncryptionKeyUrl <String>] [-EnableSystemAssignedIdentity]
 [-KeyEncryptionKeyIdentityType <String>] [-KeyEncryptionKeyIdentityUserAssignedIdentityResourceId <String>]
 [-ProvisioningState <String>] [-Storagesku <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzFluidRelayServer -Name <String> -ResourceGroup <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzFluidRelayServer -Name <String> -ResourceGroup <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityResourceGroupExpanded
```
New-AzFluidRelayServer -Name <String> -ResourceGroupInputObject <IFluidRelayIdentity> -Location <String>
 [-CustomerManagedKeyEncryptionKeyUrl <String>] [-EnableSystemAssignedIdentity]
 [-KeyEncryptionKeyIdentityType <String>] [-KeyEncryptionKeyIdentityUserAssignedIdentityResourceId <String>]
 [-ProvisioningState <String>] [-Storagesku <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
create a Fluid Relay server.

## EXAMPLES

### Example 1: Create or Update a Fluid Relay server.
```powershell
New-AzFluidRelayServer -Name azps-fluidrelay -ResourceGroup azpstest-gp -Location westus2 -Storagesku 'basic' -ProvisioningState 'Succeeded' -UserAssignedIdentity "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/azpstest-gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uami" -EnableSystemAssignedIdentity:$true -KeyEncryptionKeyIdentityUserAssignedIdentityResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/azpstest-gp/providers/Microsoft.ManagedIdentity/userAssignedIdentities/azpstest-uami" -KeyEncryptionKeyIdentityType 'SystemAssigned'
```

```output
Location Name            ResourceGroupName
-------- ----            -----------------
westus2  azps-fluidrelay azpstest-gp
```

Create or Update a Fluid Relay server.

## PARAMETERS

### -CustomerManagedKeyEncryptionKeyUrl
key encryption key Url, with or without a version.
Ex: https://contosovault.vault.azure.net/keys/contosokek/562a4bb76b524a1493a6afe8e536ee78 or https://contosovault.vault.azure.net/keys/contosokek.
Key auto rotation is enabled by providing a key uri without version.
Otherwise, customer is responsible for rotating the key.
The keyEncryptionKeyIdentity(either SystemAssigned or UserAssigned) should have permission to access this key url.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityResourceGroupExpanded
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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityResourceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -KeyEncryptionKeyIdentityType
Values can be SystemAssigned or UserAssigned

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityResourceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyEncryptionKeyIdentityUserAssignedIdentityResourceId
user assigned identity to use for accessing key encryption key Url.
Ex: /subscriptions/fa5fc227-a624-475e-b696-cdd604c735bc/resourceGroups/\<resource group\>/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myId.
Mutually exclusive with identityType systemAssignedIdentity.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityResourceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityResourceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The Fluid Relay server resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FluidRelayServerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningState
Provision states for FluidRelay RP

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityResourceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroup
The resource group containing the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IFluidRelayIdentity
Parameter Sets: CreateViaIdentityResourceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Storagesku
Sku of the storage associated with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityResourceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription id (GUID) for this resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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
Parameter Sets: CreateExpanded, CreateViaIdentityResourceGroupExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityResourceGroupExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IFluidRelayIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IFluidRelayServer

## NOTES

## RELATED LINKS
