---
external help file:
Module Name: Az.CloudService
online version: https://learn.microsoft.com/powershell/module/az.cloudservice/Switch-AzCloudService
schema: 2.0.0
---

# Switch-AzCloudService

## SYNOPSIS
Swaps VIPs between two cloud service (extended support) load balancers.

## SYNTAX

### CloudServiceName (Default)
```
Switch-AzCloudService -CloudServiceName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Async] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CloudService
```
Switch-AzCloudService -CloudService <CloudService> [-SubscriptionId <String>] [-Async]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Swaps VIPs between two cloud service (extended support) load balancers.

## EXAMPLES

### Example 1: Switch cloud service using name
```powershell
Switch-AzCloudService -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca
```

Above command invokes the vipswap operation on the Cloud service with name 'BService' and will perform the operation once the user confirms the action on the confirmation prompt.
'BService' with be swapped with its swappable cloud service.

### Example 2: Switch cloud service using cloud service object
```powershell
$cs = Get-AzCloudService -ResourceGroupName "BRGThree" -CloudServiceName BService -SubscriptionId 1133e0eb-b53c-1234-b478-2eac8f04afca
Switch-AzCloudService -CloudService $cs
```

Above command invokes the vipswap operation on the Cloud service with name 'BService' and will perform the operation once the user confirms the action on the confirmation prompt.
'BService' with be swapped with its swappable cloud service.

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

### -Async


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

### -CloudService
To construct, see NOTES section for CLOUDSERVICE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.CloudService
Parameter Sets: CloudService
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloudServiceName


```yaml
Type: System.String
Parameter Sets: CloudServiceName
Aliases:

Required: True
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

### -ResourceGroupName


```yaml
Type: System.String
Parameter Sets: CloudServiceName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
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

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CLOUDSERVICE <CloudService>`: 
  - `Location <String>`: Resource location.
  - `[AllowModelOverride <Boolean?>]`: (Optional) Indicates whether the role sku properties (roleProfile.roles.sku) specified in the model/template should override the role instance count and vm size specified in the .cscfg and .csdef respectively.         The default value is `false`.
  - `[Configuration <String>]`: Specifies the XML service configuration (.cscfg) for the cloud service.
  - `[ConfigurationUrl <String>]`: Specifies a URL that refers to the location of the service configuration in the Blob service. The service package URL  can be Shared Access Signature (SAS) URI from any storage account.         This is a write-only property and is not returned in GET calls.
  - `[ExtensionProfile <ICloudServiceExtensionProfile>]`: Describes a cloud service extension profile.
    - `[Extension <IExtension[]>]`: List of extensions for the cloud service.
      - `[AutoUpgradeMinorVersion <Boolean?>]`: Explicitly specify whether platform can automatically upgrade typeHandlerVersion to higher minor versions when they become available.
      - `[ForceUpdateTag <String>]`: Tag to force apply the provided public and protected settings.         Changing the tag value allows for re-running the extension without changing any of the public or protected settings.         If forceUpdateTag is not changed, updates to public or protected settings would still be applied by the handler.         If neither forceUpdateTag nor any of public or protected settings change, extension would flow to the role instance with the same sequence-number, and         it is up to handler implementation whether to re-run it or not
      - `[Name <String>]`: The name of the extension.
      - `[ProtectedSetting <String>]`: Protected settings for the extension which are encrypted before sent to the role instance.
      - `[ProtectedSettingFromKeyVaultSecretUrl <String>]`: Secret URL which contains the protected settings of the extension
      - `[Publisher <String>]`: The name of the extension handler publisher.
      - `[RolesAppliedTo <String[]>]`: Optional list of roles to apply this extension. If property is not specified or '*' is specified, extension is applied to all roles in the cloud service.
      - `[Setting <String>]`: Public settings for the extension. For JSON extensions, this is the JSON settings for the extension. For XML Extension (like RDP), this is the XML setting for the extension.
      - `[SourceVaultId <String>]`: Resource Id
      - `[Type <String>]`: Specifies the type of the extension.
      - `[TypeHandlerVersion <String>]`: Specifies the version of the extension. Specifies the version of the extension. If this element is not specified or an asterisk (*) is used as the value, the latest version of the extension is used. If the value is specified with a major version number and an asterisk as the minor version number (X.), the latest minor version of the specified major version is selected. If a major version number and a minor version number are specified (X.Y), the specific extension version is selected. If a version is specified, an auto-upgrade is performed on the role instance.
  - `[NetworkProfile <ICloudServiceNetworkProfile>]`: Network Profile for the cloud service.
    - `[LoadBalancerConfiguration <ILoadBalancerConfiguration[]>]`: List of Load balancer configurations. Cloud service can have up to two load balancer configurations, corresponding to a Public Load Balancer and an Internal Load Balancer.
      - `FrontendIPConfiguration <ILoadBalancerFrontendIPConfiguration[]>`: Specifies the frontend IP to be used for the load balancer. Only IPv4 frontend IP address is supported. Each load balancer configuration must have exactly one frontend IP configuration.
        - `Name <String>`: The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name can be used to access the resource.
        - `[PrivateIPAddress <String>]`: The virtual network private IP address of the IP configuration.
        - `[PublicIPAddressId <String>]`: Resource Id
        - `[SubnetId <String>]`: Resource Id
      - `Name <String>`: The name of the Load balancer
      - `[Id <String>]`: Resource Id
    - `[SlotType <CloudServiceSlotType?>]`: Slot type for the cloud service.         Possible values are <br /><br />**Production**<br /><br />**Staging**<br /><br />         If not specified, the default value is Production.
    - `[SwappableCloudService <ISubResource>]`: The id reference of the cloud service containing the target IP with which the subject cloud service can perform a swap. This property cannot be updated once it is set. The swappable cloud service referred by this id must be present otherwise an error will be thrown.
      - `[Id <String>]`: Resource Id
  - `[OSProfile <ICloudServiceOSProfile>]`: Describes the OS profile for the cloud service.
    - `[Secret <ICloudServiceVaultSecretGroup[]>]`: Specifies set of certificates that should be installed onto the role instances.
      - `[SourceVaultId <String>]`: Resource Id
      - `[VaultCertificate <ICloudServiceVaultCertificate[]>]`: The list of key vault references in SourceVault which contain certificates.
        - `[CertificateUrl <String>]`: This is the URL of a certificate that has been uploaded to Key Vault as a secret.
  - `[PackageUrl <String>]`: Specifies a URL that refers to the location of the service package in the Blob service. The service package URL can be Shared Access Signature (SAS) URI from any storage account.         This is a write-only property and is not returned in GET calls.
  - `[RoleProfile <ICloudServiceRoleProfile>]`: Describes the role profile for the cloud service.
    - `[Role <ICloudServiceRoleProfileProperties[]>]`: List of roles for the cloud service.
      - `[Name <String>]`: Resource name.
      - `[SkuCapacity <Int64?>]`: Specifies the number of role instances in the cloud service.
      - `[SkuName <String>]`: The sku name. NOTE: If the new SKU is not supported on the hardware the cloud service is currently on, you need to delete and recreate the cloud service or move back to the old sku.
      - `[SkuTier <String>]`: Specifies the tier of the cloud service. Possible Values are <br /><br /> **Standard** <br /><br /> **Basic**
  - `[StartCloudService <Boolean?>]`: (Optional) Indicates whether to start the cloud service immediately after it is created. The default value is `true`.         If false, the service model is still deployed, but the code is not run immediately. Instead, the service is PoweredOff until you call Start, at which time the service will be started. A deployed service still incurs charges, even if it is poweredoff.
  - `[Tag <ICloudServiceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[UpgradeMode <CloudServiceUpgradeMode?>]`: Update mode for the cloud service. Role instances are allocated to update domains when the service is deployed. Updates can be initiated manually in each update domain or initiated automatically in all update domains.         Possible Values are <br /><br />**Auto**<br /><br />**Manual** <br /><br />**Simultaneous**<br /><br />         If not specified, the default value is Auto. If set to Manual, PUT UpdateDomain must be called to apply the update. If set to Auto, the update is automatically applied to each update domain in sequence.
  - `[Zone <String[]>]`: List of logical availability zone of the resource. List should contain only 1 zone where cloud service should be provisioned. This field is optional.

## RELATED LINKS

