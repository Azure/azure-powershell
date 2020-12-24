---
external help file:
Module Name: Az.ADDomainServices
online version: https://docs.microsoft.com/en-us/powershell/module/az.addomainservices/new-azaddomainservice
schema: 2.0.0
---

# New-AzADDomainService

## SYNOPSIS
The Create Domain Service operation creates a new domain service with the specified parameters.
If the specific service already exists, then any patchable properties will be updated and any immutable properties will remain unchanged.

## SYNTAX

```
New-AzADDomainService -Name <String> -ResourceGroupName <String> -DomainName <String>
 -ReplicaSet <IReplicaSet[]> [-SubscriptionId <String>] [-DomainConfigurationType <String>]
 [-DomainSecuritySetting <DomainSecuritySettings>] [-FilteredSync <String>] [-LdapSetting <LdapsSettings>]
 [-NotificationSetting <NotificationSettings>] [-ResourceForestSetting <ResourceForestSettings>]
 [-Sku <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
The Create Domain Service operation creates a new domain service with the specified parameters.
If the specific service already exists, then any patchable properties will be updated and any immutable properties will remain unchanged.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

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

Required: True
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

### -LdapSetting
Secure LDAP Settings.
To construct, see NOTES section for LDAPSETTING properties and create a hash table.

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
Parameter Sets: (All)
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

Required: True
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

LDAPSETTING <LdapsSettings>: Secure LDAP Settings.
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

