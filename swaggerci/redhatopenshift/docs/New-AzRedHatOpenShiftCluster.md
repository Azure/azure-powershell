---
external help file:
Module Name: Az.RedHatOpenShift
online version: https://docs.microsoft.com/en-us/powershell/module/az.redhatopenshift/new-azredhatopenshiftcluster
schema: 2.0.0
---

# New-AzRedHatOpenShiftCluster

## SYNOPSIS
The operation returns properties of a OpenShift cluster.

## SYNTAX

```
New-AzRedHatOpenShiftCluster -ResourceGroupName <String> -ResourceName <String> -Location <String>
 [-SubscriptionId <String>] [-ApiserverProfileIP <String>] [-ApiserverProfileUrl <String>]
 [-ApiserverProfileVisibility <Visibility>] [-ClusterProfileDomain <String>]
 [-ClusterProfileFipsValidatedModule <FipsValidatedModules>] [-ClusterProfilePullSecret <String>]
 [-ClusterProfileResourceGroupId <String>] [-ClusterProfileVersion <String>] [-ConsoleProfileUrl <String>]
 [-IngressProfile <IIngressProfile[]>] [-MasterProfileDiskEncryptionSetId <String>]
 [-MasterProfileEncryptionAtHost <EncryptionAtHost>] [-MasterProfileSubnetId <String>]
 [-MasterProfileVMSize <String>] [-NetworkProfilePodCidr <String>] [-NetworkProfileServiceCidr <String>]
 [-ProvisioningState <String>] [-ServicePrincipalProfileClientId <String>]
 [-ServicePrincipalProfileClientSecret <String>] [-Tag <Hashtable>] [-WorkerProfile <IWorkerProfile[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation returns properties of a OpenShift cluster.

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

### -ApiserverProfileIP
The IP of the cluster API server.

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

### -ApiserverProfileUrl
The URL to access the cluster API server.

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

### -ApiserverProfileVisibility
API server visibility.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShift.Support.Visibility
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

### -ClusterProfileDomain
The domain for the cluster.

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

### -ClusterProfileFipsValidatedModule
If FIPS validated crypto modules are used

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShift.Support.FipsValidatedModules
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterProfilePullSecret
The pull secret for the cluster.

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

### -ClusterProfileResourceGroupId
The ID of the cluster resource group.

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

### -ClusterProfileVersion
The version of the cluster.

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

### -ConsoleProfileUrl
The URL to access the cluster console.

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

### -IngressProfile
The cluster ingress profiles.
To construct, see NOTES section for INGRESSPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShift.Models.Api20220401.IIngressProfile[]
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MasterProfileDiskEncryptionSetId
The resource ID of an associated DiskEncryptionSet, if applicable.

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

### -MasterProfileEncryptionAtHost
Whether master virtual machines are encrypted at host.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShift.Support.EncryptionAtHost
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MasterProfileSubnetId
The Azure resource ID of the master subnet.

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

### -MasterProfileVMSize
The size of the master VMs.

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

### -NetworkProfilePodCidr
The CIDR used for OpenShift/Kubernetes Pods.

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

### -NetworkProfileServiceCidr
The CIDR used for OpenShift/Kubernetes Services.

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

### -ProvisioningState
The cluster provisioning state.

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

### -ResourceName
The name of the OpenShift cluster resource.

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

### -ServicePrincipalProfileClientId
The client ID used for the cluster.

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

### -ServicePrincipalProfileClientSecret
The client secret used for the cluster.

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

### -WorkerProfile
The cluster worker profiles.
To construct, see NOTES section for WORKERPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShift.Models.Api20220401.IWorkerProfile[]
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

### Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShift.Models.Api20220401.IOpenShiftCluster

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INGRESSPROFILE <IIngressProfile[]>: The cluster ingress profiles.
  - `[IP <String>]`: The IP of the ingress.
  - `[Name <String>]`: The ingress profile name.
  - `[Visibility <Visibility?>]`: Ingress visibility.

WORKERPROFILE <IWorkerProfile[]>: The cluster worker profiles.
  - `[Count <Int32?>]`: The number of worker VMs.
  - `[DiskEncryptionSetId <String>]`: The resource ID of an associated DiskEncryptionSet, if applicable.
  - `[DiskSizeGb <Int32?>]`: The disk size of the worker VMs.
  - `[EncryptionAtHost <EncryptionAtHost?>]`: Whether master virtual machines are encrypted at host.
  - `[Name <String>]`: The worker profile name.
  - `[SubnetId <String>]`: The Azure resource ID of the worker subnet.
  - `[VMSize <String>]`: The size of the worker VMs.

## RELATED LINKS

