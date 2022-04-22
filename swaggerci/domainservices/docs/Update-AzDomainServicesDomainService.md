---
external help file:
Module Name: Az.DomainServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.domainservices/update-azdomainservicesdomainservice
schema: 2.0.0
---

# Update-AzDomainServicesDomainService

## SYNOPSIS
The Update Domain Service operation can be used to update the existing deployment.
The update call only supports the properties listed in the PATCH body.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDomainServicesDomainService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-ConfigDiagnosticLastExecuted <DateTime>]
 [-ConfigDiagnosticValidatorResult <IConfigDiagnosticsValidatorResult[]>] [-DomainConfigurationType <String>]
 [-DomainName <String>] [-DomainSecuritySettingKerberosArmoring <KerberosArmoring>]
 [-DomainSecuritySettingKerberosRc4Encryption <KerberosRc4Encryption>] [-DomainSecuritySettingNtlmV1 <NtlmV1>]
 [-DomainSecuritySettingSyncKerberosPassword <SyncKerberosPasswords>]
 [-DomainSecuritySettingSyncNtlmPassword <SyncNtlmPasswords>]
 [-DomainSecuritySettingSyncOnPremPassword <SyncOnPremPasswords>] [-DomainSecuritySettingTlsV1 <TlsV1>]
 [-Etag <String>] [-FilteredSync <FilteredSync>] [-LdapSettingExternalAccess <ExternalAccess>]
 [-LdapSettingLdap <Ldaps>] [-LdapSettingPfxCertificate <String>]
 [-LdapSettingPfxCertificatePassword <String>] [-Location <String>]
 [-NotificationSettingAdditionalRecipient <String[]>] [-NotificationSettingNotifyDcAdmin <NotifyDcAdmins>]
 [-NotificationSettingNotifyGlobalAdmin <NotifyGlobalAdmins>] [-ReplicaSet <IReplicaSet[]>]
 [-ResourceForestSetting <IForestTrust[]>] [-ResourceForestSettingResourceForest <String>] [-Sku <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDomainServicesDomainService -InputObject <IDomainServicesIdentity>
 [-ConfigDiagnosticLastExecuted <DateTime>]
 [-ConfigDiagnosticValidatorResult <IConfigDiagnosticsValidatorResult[]>] [-DomainConfigurationType <String>]
 [-DomainName <String>] [-DomainSecuritySettingKerberosArmoring <KerberosArmoring>]
 [-DomainSecuritySettingKerberosRc4Encryption <KerberosRc4Encryption>] [-DomainSecuritySettingNtlmV1 <NtlmV1>]
 [-DomainSecuritySettingSyncKerberosPassword <SyncKerberosPasswords>]
 [-DomainSecuritySettingSyncNtlmPassword <SyncNtlmPasswords>]
 [-DomainSecuritySettingSyncOnPremPassword <SyncOnPremPasswords>] [-DomainSecuritySettingTlsV1 <TlsV1>]
 [-Etag <String>] [-FilteredSync <FilteredSync>] [-LdapSettingExternalAccess <ExternalAccess>]
 [-LdapSettingLdap <Ldaps>] [-LdapSettingPfxCertificate <String>]
 [-LdapSettingPfxCertificatePassword <String>] [-Location <String>]
 [-NotificationSettingAdditionalRecipient <String[]>] [-NotificationSettingNotifyDcAdmin <NotifyDcAdmins>]
 [-NotificationSettingNotifyGlobalAdmin <NotifyGlobalAdmins>] [-ReplicaSet <IReplicaSet[]>]
 [-ResourceForestSetting <IForestTrust[]>] [-ResourceForestSettingResourceForest <String>] [-Sku <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Update Domain Service operation can be used to update the existing deployment.
The update call only supports the properties listed in the PATCH body.

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

### -ConfigDiagnosticLastExecuted
Last domain configuration diagnostics DateTime

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigDiagnosticValidatorResult
List of Configuration Diagnostics validator results.
To construct, see NOTES section for CONFIGDIAGNOSTICVALIDATORRESULT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Models.Api20210501.IConfigDiagnosticsValidatorResult[]
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

### -DomainConfigurationType
Domain Configuration Type

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

### -DomainName
The name of the Azure domain that the user would like to deploy Domain Services to.

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

### -DomainSecuritySettingKerberosArmoring
A flag to determine whether or not KerberosArmoring is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Support.KerberosArmoring
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainSecuritySettingKerberosRc4Encryption
A flag to determine whether or not KerberosRc4Encryption is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Support.KerberosRc4Encryption
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainSecuritySettingNtlmV1
A flag to determine whether or not NtlmV1 is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Support.NtlmV1
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainSecuritySettingSyncKerberosPassword
A flag to determine whether or not SyncKerberosPasswords is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Support.SyncKerberosPasswords
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainSecuritySettingSyncNtlmPassword
A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Support.SyncNtlmPasswords
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainSecuritySettingSyncOnPremPassword
A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Support.SyncOnPremPasswords
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainSecuritySettingTlsV1
A flag to determine whether or not TlsV1 is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Support.TlsV1
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Etag
Resource etag

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

### -FilteredSync
Enabled or Disabled flag to turn on Group-based filtered sync

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Support.FilteredSync
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Models.IDomainServicesIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LdapSettingExternalAccess
A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Support.ExternalAccess
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LdapSettingLdap
A flag to determine whether or not Secure LDAP is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Support.Ldaps
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LdapSettingPfxCertificate
The certificate required to configure Secure LDAP.
The parameter passed here should be a base64encoded representation of the certificate pfx file.

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

### -LdapSettingPfxCertificatePassword
The password to decrypt the provided Secure LDAP certificate pfx file.

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
Resource location

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
The name of the domain service.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DomainServiceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationSettingAdditionalRecipient
The list of additional recipients

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

### -NotificationSettingNotifyDcAdmin
Should domain controller admins be notified

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Support.NotifyDcAdmins
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NotificationSettingNotifyGlobalAdmin
Should global admins be notified

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Support.NotifyGlobalAdmins
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

### -ReplicaSet
List of ReplicaSets
To construct, see NOTES section for REPLICASET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Models.Api20210501.IReplicaSet[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceForestSetting
List of settings for Resource Forest
To construct, see NOTES section for RESOURCEFORESTSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Models.Api20210501.IForestTrust[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceForestSettingResourceForest
Resource Forest

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
The name of the resource group within the user's subscription.
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

### -Sku
Sku Type

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
Gets subscription credentials which uniquely identify the Microsoft Azure subscription.
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

### -Tag
Resource tags

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

### Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Models.IDomainServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DomainServices.Models.Api20210501.IDomainService

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CONFIGDIAGNOSTICVALIDATORRESULT <IConfigDiagnosticsValidatorResult[]>: List of Configuration Diagnostics validator results.
  - `[Issue <IConfigDiagnosticsValidatorResultIssue[]>]`: List of resource config validation issues.
    - `[DescriptionParam <String[]>]`: List of domain resource property name or values used to compose a rich description.
    - `[Id <String>]`: Validation issue identifier.
  - `[ReplicaSetSubnetDisplayName <String>]`: Replica set location and subnet name
  - `[Status <Status?>]`: Status for individual validator after running diagnostics.
  - `[ValidatorId <String>]`: Validator identifier

INPUTOBJECT <IDomainServicesIdentity>: Identity Parameter
  - `[DomainServiceName <String>]`: The name of the domain service.
  - `[Id <String>]`: Resource identity path
  - `[OuContainerName <String>]`: The name of the OuContainer.
  - `[ResourceGroupName <String>]`: The name of the resource group within the user's subscription. The name is case insensitive.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

REPLICASET <IReplicaSet[]>: List of ReplicaSets
  - `[Location <String>]`: Virtual network location
  - `[SubnetId <String>]`: The name of the virtual network that Domain Services will be deployed on. The id of the subnet that Domain Services will be deployed on. /virtualNetwork/vnetName/subnets/subnetName.

RESOURCEFORESTSETTING <IForestTrust[]>: List of settings for Resource Forest
  - `[FriendlyName <String>]`: Friendly Name
  - `[RemoteDnsIP <String>]`: Remote Dns ips
  - `[TrustDirection <String>]`: Trust Direction
  - `[TrustPassword <String>]`: Trust Password
  - `[TrustedDomainFqdn <String>]`: Trusted Domain FQDN

## RELATED LINKS

