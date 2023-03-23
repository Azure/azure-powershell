---
external help file:
Module Name: Az.AppPlatform
online version: https://learn.microsoft.com/powershell/module/az.appplatform/update-azappplatformapp
schema: 2.0.0
---

# Update-AzAppPlatformApp

## SYNOPSIS
Operation to update an exiting App.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAppPlatformApp -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String>] [-AddonConfig <Hashtable>] [-ClientAuthCertificate <String[]>]
 [-CustomPersistentDisk <ICustomPersistentDiskResource[]>] [-EnableEndToEndTl] [-HttpsOnly]
 [-IdentityPrincipalId <String>] [-IdentityTenantId <String>] [-IdentityType <ManagedIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-IngressSettingBackendProtocol <BackendProtocol>]
 [-IngressSettingReadTimeoutInSecond <Int32>] [-IngressSettingSendTimeoutInSecond <Int32>]
 [-IngressSettingSessionAffinity <SessionAffinity>] [-IngressSettingSessionCookieMaxAge <Int32>]
 [-LoadedCertificate <ILoadedCertificate[]>] [-Location <String>] [-PersistentDiskMountPath <String>]
 [-PersistentDiskSizeInGb <Int32>] [-Public] [-Secret <ISecret[]>] [-TemporaryDiskMountPath <String>]
 [-TemporaryDiskSizeInGb <Int32>] [-VnetAddonPublicEndpoint] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAppPlatformApp -InputObject <IAppPlatformIdentity> [-AddonConfig <Hashtable>]
 [-ClientAuthCertificate <String[]>] [-CustomPersistentDisk <ICustomPersistentDiskResource[]>]
 [-EnableEndToEndTl] [-HttpsOnly] [-IdentityPrincipalId <String>] [-IdentityTenantId <String>]
 [-IdentityType <ManagedIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-IngressSettingBackendProtocol <BackendProtocol>] [-IngressSettingReadTimeoutInSecond <Int32>]
 [-IngressSettingSendTimeoutInSecond <Int32>] [-IngressSettingSessionAffinity <SessionAffinity>]
 [-IngressSettingSessionCookieMaxAge <Int32>] [-LoadedCertificate <ILoadedCertificate[]>] [-Location <String>]
 [-PersistentDiskMountPath <String>] [-PersistentDiskSizeInGb <Int32>] [-Public] [-Secret <ISecret[]>]
 [-TemporaryDiskMountPath <String>] [-TemporaryDiskSizeInGb <Int32>] [-VnetAddonPublicEndpoint]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Operation to update an exiting App.

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

### -AddonConfig
Collection of addons

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

### -ClientAuthCertificate
Collection of certificate resource id.

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

### -CustomPersistentDisk
List of custom persistent disks
To construct, see NOTES section for CUSTOMPERSISTENTDISK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.Api20230301Preview.ICustomPersistentDiskResource[]
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

### -EnableEndToEndTl
Indicate if end to end TLS is enabled.

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

### -HttpsOnly
Indicate if only https is allowed.

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

### -IdentityPrincipalId
Principal Id of system-assigned managed identity.

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

### -IdentityTenantId
Tenant Id of system-assigned managed identity.

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
Type of the managed identity

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Support.ManagedIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
Properties of user-assigned managed identities

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

### -IngressSettingBackendProtocol
How ingress should communicate with this app backend service.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Support.BackendProtocol
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngressSettingReadTimeoutInSecond
Ingress read time out in seconds.

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

### -IngressSettingSendTimeoutInSecond
Ingress send time out in seconds.

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

### -IngressSettingSessionAffinity
Type of the affinity, set this to Cookie to enable session affinity.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Support.SessionAffinity
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngressSettingSessionCookieMaxAge
Time in seconds until the cookie expires.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.IAppPlatformIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LoadedCertificate
Collection of loaded certificates
To construct, see NOTES section for LOADEDCERTIFICATE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.Api20230301Preview.ILoadedCertificate[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The GEO location of the application, always the same with its parent resource

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

### -Name
The name of the App resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: AppName

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

### -PersistentDiskMountPath
Mount path of the persistent disk

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

### -PersistentDiskSizeInGb
Size of the persistent disk in GB

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

### -Public
Indicates whether the App exposes public endpoint

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
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

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

### -Secret
Collection of auth secrets
To construct, see NOTES section for SECRET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.Api20230301Preview.ISecret[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the Service resource.

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
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### -TemporaryDiskMountPath
Mount path of the temporary disk

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

### -TemporaryDiskSizeInGb
Size of the temporary disk in GB

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

### -VnetAddonPublicEndpoint
Indicates whether the App in vnet injection instance exposes endpoint which could be accessed from internet.

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

### Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.IAppPlatformIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.Api20230301Preview.IAppResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CUSTOMPERSISTENTDISK <ICustomPersistentDiskResource[]>`: List of custom persistent disks
  - `StorageId <String>`: The resource id of Azure Spring Apps Storage resource.
  - `[CustomPersistentDiskPropertyEnableSubPath <Boolean?>]`: If set to true, it will create and mount a dedicated directory for every individual app instance.
  - `[CustomPersistentDiskPropertyMountOption <String[]>]`: These are the mount options for a persistent disk.
  - `[CustomPersistentDiskPropertyMountPath <String>]`: The mount path of the persistent disk.
  - `[CustomPersistentDiskPropertyReadOnly <Boolean?>]`: Indicates whether the persistent disk is a readOnly one.

`INPUTOBJECT <IAppPlatformIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the build service agent pool resource.
  - `[ApiPortalName <String>]`: The name of API portal.
  - `[AppName <String>]`: The name of the App resource.
  - `[ApplicationAcceleratorName <String>]`: The name of the application accelerator.
  - `[ApplicationLiveViewName <String>]`: The name of Application Live View.
  - `[BindingName <String>]`: The name of the Binding resource.
  - `[BuildName <String>]`: The name of the build resource.
  - `[BuildResultName <String>]`: The name of the build result resource.
  - `[BuildServiceName <String>]`: The name of the build service resource.
  - `[BuilderName <String>]`: The name of the builder resource.
  - `[BuildpackBindingName <String>]`: The name of the Buildpack Binding Name
  - `[BuildpackName <String>]`: The name of the buildpack resource.
  - `[CertificateName <String>]`: The name of the certificate resource.
  - `[ConfigurationServiceName <String>]`: The name of Application Configuration Service.
  - `[ContainerRegistryName <String>]`: The name of the container registry.
  - `[CustomizedAcceleratorName <String>]`: The name of the customized accelerator.
  - `[DeploymentName <String>]`: The name of the Deployment resource.
  - `[DevToolPortalName <String>]`: The name of Dev Tool Portal.
  - `[DomainName <String>]`: The name of the custom domain resource.
  - `[GatewayName <String>]`: The name of Spring Cloud Gateway.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: the region
  - `[PredefinedAcceleratorName <String>]`: The name of the predefined accelerator.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[RouteConfigName <String>]`: The name of the Spring Cloud Gateway route config.
  - `[ServiceName <String>]`: The name of the Service resource.
  - `[ServiceRegistryName <String>]`: The name of Service Registry.
  - `[StackName <String>]`: The name of the stack resource.
  - `[StorageName <String>]`: The name of the storage resource.
  - `[SubscriptionId <String>]`: Gets subscription ID which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

`LOADEDCERTIFICATE <ILoadedCertificate[]>`: Collection of loaded certificates
  - `ResourceId <String>`: Resource Id of loaded certificate
  - `[LoadTrustStore <Boolean?>]`: Indicate whether the certificate will be loaded into default trust store, only work for Java runtime.

`SECRET <ISecret[]>`: Collection of auth secrets
  - `[Name <String>]`: Secret Name.
  - `[Value <String>]`: Secret Value.

## RELATED LINKS

