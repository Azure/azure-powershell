---
external help file: Az.Aks-help.xml
Module Name: Az.Aks
online version: https://learn.microsoft.com/powershell/module/az.aks/get-azakstrustedaccessrolebinding
schema: 2.0.0
---

# Get-AzAksTrustedAccessRoleBinding

## SYNOPSIS
Get a trusted access role binding.

## SYNTAX

### List (Default)
```
Get-AzAksTrustedAccessRoleBinding -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityManagedCluster
```
Get-AzAksTrustedAccessRoleBinding -Name <String> -ManagedClusterInputObject <IAksIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzAksTrustedAccessRoleBinding -Name <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzAksTrustedAccessRoleBinding -InputObject <IAksIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a trusted access role binding.

## EXAMPLES

### Example 1: List the trusted access role bindings
```powershell
Get-AzAksTrustedAccessRoleBinding -ResourceGroupName AKS_TEST_RG -ResourceName AKS_Test_Cluster
```

```output
Id                           : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.ContainerService/managedClusters/AKS_Test_Cluster/trustedAccessRoleBindings/testBinding
Name                         : testBinding
ProvisioningState            : Succeeded
ResourceGroupName            : AKS_TEST_RG
Role                         : {Microsoft.MachineLearningServices/workspaces/mlworkload}
SourceResourceId             : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.MachineLearningServices/workspaces/TestAML001
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.ContainerService/managedClusters/trustedAccessRoleBindings
```

List the trusted access role bindings.

### Example 2: Get the trusted access role binding
```powershell
Get-AzAksTrustedAccessRoleBinding -ResourceGroupName AKS_TEST_RG -ResourceName AKS_Test_Cluster -Name testBinding
```

```output
Id                           : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.ContainerService/managedClusters/AKS_Test_Cluster/trustedAccessRoleBindings/testBinding
Name                         : testBinding
ProvisioningState            : Succeeded
ResourceGroupName            : AKS_TEST_RG
Role                         : {Microsoft.MachineLearningServices/workspaces/mlworkload}
SourceResourceId             : /subscriptions/0e745469-49f8-48c9-873b-24ca87143db1/resourceGroups/AKS_TEST_RG/providers/Microsoft.MachineLearningServices/workspaces/TestAML001
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.ContainerService/managedClusters/trustedAccessRoleBindings
```

Get the trusted access role binding.

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity
Parameter Sets: GetViaIdentityManagedCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of trusted access role binding.

```yaml
Type: System.String
Parameter Sets: GetViaIdentityManagedCluster, Get
Aliases: TrustedAccessRoleBindingName

Required: True
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
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the managed cluster resource.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.IAksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Aks.Models.ITrustedAccessRoleBinding

## NOTES

## RELATED LINKS
