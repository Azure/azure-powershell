---
external help file:
Module Name: Az.HdInsight
online version: https://docs.microsoft.com/en-us/powershell/module/az.hdinsight/new-azhdinsightapplication
schema: 2.0.0
---

# New-AzHdInsightApplication

## SYNOPSIS
Creates applications for the HDInsight cluster.

## SYNTAX

```
New-AzHdInsightApplication -ClusterName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ApplicationType <String>] [-ComputeProfileRole <IRole[]>] [-Error <IErrors[]>]
 [-Etag <String>] [-HttpsEndpoint <IApplicationGetHttpsEndpoint[]>]
 [-InstallScriptAction <IRuntimeScriptAction[]>] [-PrivateLinkConfiguration <IPrivateLinkConfiguration[]>]
 [-SshEndpoint <IApplicationGetEndpoint[]>] [-Tag <Hashtable>]
 [-UninstallScriptAction <IRuntimeScriptAction[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates applications for the HDInsight cluster.

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

### -ApplicationType
The application type.

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

### -ClusterName
The name of the cluster.

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

### -ComputeProfileRole
The list of roles in the cluster.
To construct, see NOTES section for COMPUTEPROFILEROLE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IRole[]
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

### -Error
The list of errors.
To construct, see NOTES section for ERROR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IErrors[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Etag
The ETag for the application

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

### -HttpsEndpoint
The list of application HTTPS endpoints.
To construct, see NOTES section for HTTPSENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IApplicationGetHttpsEndpoint[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstallScriptAction
The list of install script actions.
To construct, see NOTES section for INSTALLSCRIPTACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IRuntimeScriptAction[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The constant value for the application name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ApplicationName

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

### -PrivateLinkConfiguration
The private link configurations.
To construct, see NOTES section for PRIVATELINKCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IPrivateLinkConfiguration[]
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

### -SshEndpoint
The list of application SSH endpoints.
To construct, see NOTES section for SSHENDPOINT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IApplicationGetEndpoint[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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
The tags for the application.

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

### -UninstallScriptAction
The list of uninstall script actions.
To construct, see NOTES section for UNINSTALLSCRIPTACTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IRuntimeScriptAction[]
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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsight.Models.Api20210601.IApplication

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


COMPUTEPROFILEROLE <IRole[]>: The list of roles in the cluster.
  - `[CapacityMaxInstanceCount <Int32?>]`: The maximum instance count of the cluster
  - `[CapacityMinInstanceCount <Int32?>]`: The minimum instance count of the cluster
  - `[DataDisksGroup <IDataDisksGroups[]>]`: The data disks groups for the role.
    - `[DisksPerNode <Int32?>]`: The number of disks per node.
  - `[EncryptDataDisk <Boolean?>]`: Indicates whether encrypt the data disks.
  - `[HardwareProfileVMSize <String>]`: The size of the VM
  - `[LinuxOperatingSystemProfilePassword <String>]`: The password.
  - `[LinuxOperatingSystemProfileUsername <String>]`: The username.
  - `[MinInstanceCount <Int32?>]`: The minimum instance count of the cluster.
  - `[Name <String>]`: The name of the role.
  - `[RecurrenceSchedule <IAutoscaleSchedule[]>]`: Array of schedule-based autoscale rules
    - `[Day <DaysOfWeek[]>]`: Days of the week for a schedule-based autoscale rule
    - `[TimeAndCapacityMaxInstanceCount <Int32?>]`: The maximum instance count of the cluster
    - `[TimeAndCapacityMinInstanceCount <Int32?>]`: The minimum instance count of the cluster
    - `[TimeAndCapacityTime <String>]`: 24-hour time in the form xx:xx
  - `[RecurrenceTimeZone <String>]`: The time zone for the autoscale schedule times
  - `[ScriptAction <IScriptAction[]>]`: The list of script actions on the role.
    - `Name <String>`: The name of the script action.
    - `Parameter <String>`: The parameters for the script provided.
    - `Uri <String>`: The URI to the script.
  - `[SshProfilePublicKey <ISshPublicKey[]>]`: The list of SSH public keys.
    - `[CertificateData <String>]`: The certificate for SSH.
  - `[TargetInstanceCount <Int32?>]`: The instance count of the cluster.
  - `[VMGroupName <String>]`: The name of the virtual machine group.
  - `[VirtualNetworkProfileId <String>]`: The ID of the virtual network.
  - `[VirtualNetworkProfileSubnet <String>]`: The name of the subnet.

ERROR <IErrors[]>: The list of errors.
  - `[Code <String>]`: The error code.
  - `[Message <String>]`: The error message.

HTTPSENDPOINT <IApplicationGetHttpsEndpoint[]>: The list of application HTTPS endpoints.
  - `[AccessMode <String[]>]`: The list of access modes for the application.
  - `[DestinationPort <Int32?>]`: The destination port to connect to.
  - `[DisableGatewayAuth <Boolean?>]`: The value indicates whether to disable GatewayAuth.
  - `[PrivateIPAddress <String>]`: The private ip address of the endpoint.
  - `[SubDomainSuffix <String>]`: The subdomain suffix of the application.

INSTALLSCRIPTACTION <IRuntimeScriptAction[]>: The list of install script actions.
  - `Name <String>`: The name of the script action.
  - `Role <String[]>`: The list of roles where script will be executed.
  - `Uri <String>`: The URI to the script.
  - `[Parameter <String>]`: The parameters for the script

PRIVATELINKCONFIGURATION <IPrivateLinkConfiguration[]>: The private link configurations.
  - `GroupId <String>`: The HDInsight private linkable sub-resource name to apply the private link configuration to. For example, 'headnode', 'gateway', 'edgenode'.
  - `IPConfiguration <IIPConfiguration[]>`: The IP configurations for the private link service.
    - `Name <String>`: The name of private link IP configuration.
    - `[Primary <Boolean?>]`: Indicates whether this IP configuration is primary for the corresponding NIC.
    - `[PrivateIPAddress <String>]`: The IP address.
    - `[PrivateIPAllocationMethod <PrivateIPAllocationMethod?>]`: The method that private IP address is allocated.
    - `[SubnetId <String>]`: The azure resource id.
  - `Name <String>`: The name of private link configuration.

SSHENDPOINT <IApplicationGetEndpoint[]>: The list of application SSH endpoints.
  - `[DestinationPort <Int32?>]`: The destination port to connect to.
  - `[Location <String>]`: The location of the endpoint.
  - `[PrivateIPAddress <String>]`: The private ip address of the endpoint.
  - `[PublicPort <Int32?>]`: The public port to connect to.

UNINSTALLSCRIPTACTION <IRuntimeScriptAction[]>: The list of uninstall script actions.
  - `Name <String>`: The name of the script action.
  - `Role <String[]>`: The list of roles where script will be executed.
  - `Uri <String>`: The URI to the script.
  - `[Parameter <String>]`: The parameters for the script

## RELATED LINKS

