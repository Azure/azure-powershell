---
external help file:
Module Name: Az.ContainerAppsApi
online version: https://learn.microsoft.com/powershell/module/az.containerappsapi/update-azcontainerappsapimanagedenvironment
schema: 2.0.0
---

# Update-AzContainerAppsApiManagedEnvironment

## SYNOPSIS
Patches a Managed Environment using JSON Merge Patch

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzContainerAppsApiManagedEnvironment -EnvironmentName <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-AppLogConfigurationDestination <String>]
 [-CustomDomainConfigurationCertificatePassword <String>]
 [-CustomDomainConfigurationCertificateValueInputFile <String>] [-CustomDomainConfigurationDnsSuffix <String>]
 [-DaprAiConnectionString <String>] [-DaprAiInstrumentationKey <String>]
 [-InfrastructureResourceGroup <String>] [-Kind <String>] [-LogAnalyticConfigurationCustomerId <String>]
 [-LogAnalyticConfigurationSharedKey <String>] [-Tag <Hashtable>]
 [-VnetConfigurationDockerBridgeCidr <String>] [-VnetConfigurationInfrastructureSubnetId <String>]
 [-VnetConfigurationInternal] [-VnetConfigurationPlatformReservedCidr <String>]
 [-VnetConfigurationPlatformReservedDnsIP <String>] [-WorkloadProfile <IWorkloadProfile[]>] [-ZoneRedundant]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzContainerAppsApiManagedEnvironment -InputObject <IContainerAppsApiIdentity> -Location <String>
 [-AppLogConfigurationDestination <String>] [-CustomDomainConfigurationCertificatePassword <String>]
 [-CustomDomainConfigurationCertificateValueInputFile <String>] [-CustomDomainConfigurationDnsSuffix <String>]
 [-DaprAiConnectionString <String>] [-DaprAiInstrumentationKey <String>]
 [-InfrastructureResourceGroup <String>] [-Kind <String>] [-LogAnalyticConfigurationCustomerId <String>]
 [-LogAnalyticConfigurationSharedKey <String>] [-Tag <Hashtable>]
 [-VnetConfigurationDockerBridgeCidr <String>] [-VnetConfigurationInfrastructureSubnetId <String>]
 [-VnetConfigurationInternal] [-VnetConfigurationPlatformReservedCidr <String>]
 [-VnetConfigurationPlatformReservedDnsIP <String>] [-WorkloadProfile <IWorkloadProfile[]>] [-ZoneRedundant]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patches a Managed Environment using JSON Merge Patch

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

### -AppLogConfigurationDestination
Logs destination

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

### -CustomDomainConfigurationCertificatePassword
Certificate password

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

### -CustomDomainConfigurationCertificateValueInputFile
Input File for CustomDomainConfigurationCertificateValue (PFX or PEM blob)

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

### -CustomDomainConfigurationDnsSuffix
Dns suffix for the environment domain

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

### -DaprAiConnectionString
Application Insights connection string used by Dapr to export Service to Service communication telemetry

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

### -DaprAiInstrumentationKey
Azure Monitor instrumentation key used by Dapr to export Service to Service communication telemetry

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

### -EnvironmentName
Name of the Environment.

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

### -InfrastructureResourceGroup
Name of the platform-managed resource group created for the Managed Environment to host infrastructure resources.
If a subnet ID is provided, this resource group will be created in the same subscription as the subnet.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.IContainerAppsApiIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
Kind of the Environment.

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

### -LogAnalyticConfigurationCustomerId
Log analytics customer id

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

### -LogAnalyticConfigurationSharedKey
Log analytics customer key

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

### -VnetConfigurationDockerBridgeCidr
CIDR notation IP range assigned to the Docker bridge, network.
Must not overlap with any other provided IP ranges.

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

### -VnetConfigurationInfrastructureSubnetId
Resource ID of a subnet for infrastructure components.
Must not overlap with any other provided IP ranges.

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

### -VnetConfigurationInternal
Boolean indicating the environment only has an internal load balancer.
These environments do not have a public static IP resource.
They must provide infrastructureSubnetId if enabling this property

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

### -VnetConfigurationPlatformReservedCidr
IP range in CIDR notation that can be reserved for environment infrastructure IP addresses.
Must not overlap with any other provided IP ranges.

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

### -VnetConfigurationPlatformReservedDnsIP
An IP address from the IP range defined by platformReservedCidr that will be reserved for the internal DNS server.

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

### -WorkloadProfile
Workload profiles configured for the Managed Environment.
To construct, see NOTES section for WORKLOADPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20221101Preview.IWorkloadProfile[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ZoneRedundant
Whether or not this Managed Environment is zone-redundant.

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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.IContainerAppsApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20221101Preview.IManagedEnvironment

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IContainerAppsApiIdentity>`: Identity Parameter
  - `[AuthConfigName <String>]`: Name of the Container App AuthConfig.
  - `[CertificateName <String>]`: Name of the Certificate.
  - `[ComponentName <String>]`: Name of the Dapr Component.
  - `[ConnectedEnvironmentName <String>]`: Name of the connectedEnvironment.
  - `[ContainerAppName <String>]`: Name of the Container App.
  - `[DetectorName <String>]`: Name of the Container App Detector.
  - `[EnvironmentName <String>]`: Name of the Environment.
  - `[Id <String>]`: Resource identity path
  - `[JobExecutionName <String>]`: Job execution name.
  - `[JobName <String>]`: Name of the Container Apps Job.
  - `[Location <String>]`: The name of Azure region.
  - `[ManagedCertificateName <String>]`: Name of the Managed Certificate.
  - `[ReplicaName <String>]`: Name of the Container App Revision Replica.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RevisionName <String>]`: Name of the Container App Revision.
  - `[SourceControlName <String>]`: Name of the Container App SourceControl.
  - `[StorageName <String>]`: Name of the storage.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

`WORKLOADPROFILE <IWorkloadProfile[]>`: Workload profiles configured for the Managed Environment.
  - `Name <String>`: Workload profile type for the workloads to run on.
  - `Type <String>`: Workload profile type for the workloads to run on.
  - `[MaximumCount <Int32?>]`: The maximum capacity.
  - `[MinimumCount <Int32?>]`: The minimum capacity.

## RELATED LINKS

