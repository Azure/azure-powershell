---
external help file:
Module Name: Az.CustomLocation
online version: https://learn.microsoft.com/powershell/module/az.customlocation/update-azcustomlocation
schema: 2.0.0
---

# Update-AzCustomLocation

## SYNOPSIS
Update a Custom Location in the specified Subscription and Resource Group

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzCustomLocation -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AuthenticationType <String>] [-AuthenticationValue <String>] [-ClusterExtensionId <String[]>]
 [-DisplayName <String>] [-EnableSystemAssignedIdentity <Boolean?>] [-HostResourceId <String>]
 [-Namespace <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzCustomLocation -InputObject <ICustomLocationIdentity> [-AuthenticationType <String>]
 [-AuthenticationValue <String>] [-ClusterExtensionId <String[]>] [-DisplayName <String>]
 [-EnableSystemAssignedIdentity <Boolean?>] [-HostResourceId <String>] [-Namespace <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a Custom Location in the specified Subscription and Resource Group

## EXAMPLES

### Example 1: Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription.
```powershell
$HostResourceId = (Get-AzConnectedKubernetes -ClusterName azps-connect -ResourceGroupName azps_test_cluster).Id
$ClusterExtensionId = (Get-AzKubernetesExtension -ClusterName azps-connect -ClusterType ConnectedClusters -ResourceGroupName azps_test_cluster -Name azps-extension).Id
Update-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation -ClusterExtensionId $ClusterExtensionId -HostResourceId $HostResourceId -Namespace azps-namespace -Tag @{"Key1"="Value1"}
```

```output
Location Name                Namespace      ResourceGroupName
-------- ----                ---------      -----------------
eastus   azps-customlocation azps-namespace azps_test_cluster
```

Updates a Custom Location with the specified Resource Name in the specified Resource Group and Subscription.

### Example 2: Updates a Custom Location.
```powershell
$obj = Get-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation
Update-AzCustomLocation -InputObject $obj -Tag @{"Key1"="Value1"}
```

```output
Location Name                Namespace      ResourceGroupName
-------- ----                ---------      -----------------
eastus   azps-customlocation azps-namespace azps_test_cluster
```

Updates a Custom Location.

### Example 3: Updates a Custom Location with disable system assigned identity
```powershell
Update-AzCustomLocation -Name azps-customlocation -ResourceGroupName group01 -EnableSystemAssignedIdentity $false -Tag @{"aaa"= "111"}
```

```output
AuthenticationType           : 
AuthenticationValue          : 
ClusterExtensionId           : {/subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group01/providers/Microsoft.Kubernetes/ConnectedClusters/azps- 
                               connect/providers/Microsoft.KubernetesConfiguration/extensions/azps-extension}
DisplayName                  : 
HostResourceId               : /subscriptions/11111111-2222-3333-4444-123456789101/resourceGroups/group01/providers/Microsoft.Kubernetes/connectedClusters/azps-c 
                               onnect
HostType                     : Kubernetes
Id                           : /subscriptions/11111111-2222-3333-4444-123456789101/resourcegroups/group01/providers/microsoft.extendedlocation/customlocations/az 
                               ps-customlocation
IdentityPrincipalId          : 
IdentityTenantId             : 
IdentityType                 : None
Location                     : eastus
Name                         : azps-customlocation
Namespace                    : azps-namespace
ProvisioningState            : Succeeded
ResourceGroupName            : group01
SystemDataCreatedAt          : 4/30/2024 7:57:50 AM
SystemDataCreatedBy          : user@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 4/30/2024 8:08:55 AM
SystemDataLastModifiedBy     : user@example.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "aaa": "111"
                               }
Type                         : Microsoft.ExtendedLocation/customLocations
```

This command updates a Custom Location with disable system assigned identity.

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

### -AuthenticationType
The type of the Custom Locations authentication

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

### -AuthenticationValue
The kubeconfig value.

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

### -ClusterExtensionId
Contains the reference to the add-on that contains charts to deploy CRDs and operators.

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

### -DisplayName
Display name for the Custom Locations location.

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
Decides if enable a system assigned identity for the resource.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostResourceId
Connected Cluster or AKS Cluster.
The Custom Locations RP will perform a checkAccess API for listAdminCredentials permissions.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Custom Locations name.

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

### -Namespace
Kubernetes namespace that will be created on the specified cluster.

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

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CustomLocation.Models.ICustomLocation

## NOTES

## RELATED LINKS

