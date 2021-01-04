---
external help file:
Module Name: Az.ADDomainServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.addomainservices/update-azaddomainservice
schema: 2.0.0
---

# Update-AzADDomainService

## SYNOPSIS
The Update Domain Service operation can be used to update the existing deployment.
The update call only supports the properties listed in the PATCH body.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzADDomainService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DomainConfigurationType <String>] [-DomainSecuritySetting <DomainSecuritySettings>]
 [-FilteredSync <String>] [-LdapsSetting <LdapsSettings>] [-NotificationSetting <NotificationSettings>]
 [-ReplicaSet <IReplicaSet[]>] [-ResourceForestSetting <ResourceForestSettings>] [-Sku <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzADDomainService -InputObject <IAdDomainServicesIdentity> [-DomainConfigurationType <String>]
 [-DomainSecuritySetting <DomainSecuritySettings>] [-FilteredSync <String>] [-LdapsSetting <LdapsSettings>]
 [-NotificationSetting <NotificationSettings>] [-ReplicaSet <IReplicaSet[]>]
 [-ResourceForestSetting <ResourceForestSettings>] [-Sku <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The Update Domain Service operation can be used to update the existing deployment.
The update call only supports the properties listed in the PATCH body.

## EXAMPLES

### Example 1: Update AzADDomainService By ResourceGroupName and Name
```powershell
PS C:\> $ADDomainSetting = New-AzADDomainServiceDomainSecuritySettingObject -TlsV1 Disabled
Update-AzADDomainService -Name youriADdomain -ResourceGroupName youriADdomain -DomainSecuritySetting $ADDomainSetting

Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Update AzADDomainService By ResourceGroupName and Name

### Example 2: Update AzADDomainService By Inputobject
```powershell
PS C:\> $getAzAddomain = Get-AzADDomainService -Name youriADdomain -ResourceGroupName youriADdomain
$ADDomainSetting = New-AzADDomainServiceDomainSecuritySettingObject -TlsV1 Disabled
Update-AzADDomainService -InputObject $getAzAddomain -DomainSecuritySetting $ADDomainSetting

Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Update AzADDomainService By Inputobject

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

### -DomainSecuritySetting
Domain Security Settings.
To construct, see NOTES section for DOMAINSECURITYSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.DomainSecuritySettings
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IAdDomainServicesIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LdapsSetting
Secure LDAP Settings.
To construct, see NOTES section for LDAPSSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.LdapsSettings
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

### -NotificationSetting
Notification Settings.
To construct, see NOTES section for NOTIFICATIONSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.NotificationSettings
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IReplicaSet[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceForestSetting
Settings for Resource Forest.
To construct, see NOTES section for RESOURCEFORESTSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.ResourceForestSettings
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

### Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IAdDomainServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainService

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DOMAINSECURITYSETTING <DomainSecuritySettings>: Domain Security Settings.
  - `[NtlmV1 <NtlmV1?>]`: A flag to determine whether or not NtlmV1 is enabled or disabled.
  - `[SyncKerberosPassword <SyncKerberosPasswords?>]`: A flag to determine whether or not SyncKerberosPasswords is enabled or disabled.
  - `[SyncNtlmPassword <SyncNtlmPasswords?>]`: A flag to determine whether or not SyncNtlmPasswords is enabled or disabled.
  - `[SyncOnPremPassword <SyncOnPremPasswords?>]`: A flag to determine whether or not SyncOnPremPasswords is enabled or disabled.
  - `[TlsV1 <TlsV1?>]`: A flag to determine whether or not TlsV1 is enabled or disabled.

INPUTOBJECT <IAdDomainServicesIdentity>: Identity Parameter
  - `[DomainServiceName <String>]`: The name of the domain service.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group within the user's subscription. The name is case insensitive.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

LDAPSSETTING <LdapsSettings>: Secure LDAP Settings.
  - `[ExternalAccess <ExternalAccess?>]`: A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.
  - `[Ldap <Ldaps?>]`: A flag to determine whether or not Secure LDAP is enabled or disabled.
  - `[PfxCertificate <String>]`: The certificate required to configure Secure LDAP. The parameter passed here should be a base64encoded representation of the certificate pfx file.
  - `[PfxCertificatePassword <String>]`: The password to decrypt the provided Secure LDAP certificate pfx file.

NOTIFICATIONSETTING <NotificationSettings>: Notification Settings.
  - `[AdditionalRecipient <String[]>]`: The list of additional recipients
  - `[NotifyDcAdmin <NotifyDcAdmins?>]`: Should domain controller admins be notified
  - `[NotifyGlobalAdmin <NotifyGlobalAdmins?>]`: Should global admins be notified

REPLICASET <IReplicaSet[]>: List of ReplicaSets
  - `[Location <String>]`: Virtual network location
  - `[SubnetId <String>]`: The name of the virtual network that Domain Services will be deployed on. The id of the subnet that Domain Services will be deployed on. /virtualNetwork/vnetName/subnets/subnetName.

RESOURCEFORESTSETTING <ResourceForestSettings>: Settings for Resource Forest.
  - `[ResourceForest <String>]`: Resource Forest
  - `[Setting <IForestTrust[]>]`: List of settings for Resource Forest
    - `[FriendlyName <String>]`: Friendly Name
    - `[RemoteDnsIP <String>]`: Remote Dns ips
    - `[TrustDirection <String>]`: Trust Direction
    - `[TrustPassword <String>]`: Trust Password
    - `[TrustedDomainFqdn <String>]`: Trusted Domain FQDN

## RELATED LINKS

