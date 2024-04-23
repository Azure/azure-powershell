---
external help file: Az.ADDomainServices-help.xml
Module Name: Az.ADDomainServices
online version: https://learn.microsoft.com/powershell/module/az.addomainservices/update-azaddomainservice
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
 [-DomainConfigurationType <String>] [-DomainName <String>] [-DomainSecuritySettingNtlmV1 <NtlmV1>]
 [-DomainSecuritySettingSyncKerberosPassword <SyncKerberosPasswords>]
 [-DomainSecuritySettingSyncNtlmPassword <SyncNtlmPasswords>]
 [-DomainSecuritySettingSyncOnPremPassword <SyncOnPremPasswords>] [-DomainSecuritySettingTlsV1 <TlsV1>]
 [-Etag <String>] [-FilteredSync <FilteredSync>] [-ForestTrust <IForestTrust[]>]
 [-LdapSettingExternalAccess <ExternalAccess>] [-LdapSettingLdaps <Ldaps>]
 [-LdapSettingPfxCertificateInputFile <String>] [-LdapSettingPfxCertificatePassword <SecureString>]
 [-Location <String>] [-NotificationSettingAdditionalRecipient <String[]>]
 [-NotificationSettingNotifyDcAdmin <NotifyDcAdmins>]
 [-NotificationSettingNotifyGlobalAdmin <NotifyGlobalAdmins>] [-ReplicaSet <IReplicaSet[]>]
 [-ResourceForest <String>] [-Sku <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzADDomainService -InputObject <IAdDomainServicesIdentity> [-DomainConfigurationType <String>]
 [-DomainName <String>] [-DomainSecuritySettingNtlmV1 <NtlmV1>]
 [-DomainSecuritySettingSyncKerberosPassword <SyncKerberosPasswords>]
 [-DomainSecuritySettingSyncNtlmPassword <SyncNtlmPasswords>]
 [-DomainSecuritySettingSyncOnPremPassword <SyncOnPremPasswords>] [-DomainSecuritySettingTlsV1 <TlsV1>]
 [-Etag <String>] [-FilteredSync <FilteredSync>] [-ForestTrust <IForestTrust[]>]
 [-LdapSettingExternalAccess <ExternalAccess>] [-LdapSettingLdaps <Ldaps>]
 [-LdapSettingPfxCertificateInputFile <String>] [-LdapSettingPfxCertificatePassword <SecureString>]
 [-Location <String>] [-NotificationSettingAdditionalRecipient <String[]>]
 [-NotificationSettingNotifyDcAdmin <NotifyDcAdmins>]
 [-NotificationSettingNotifyGlobalAdmin <NotifyGlobalAdmins>] [-ReplicaSet <IReplicaSet[]>]
 [-ResourceForest <String>] [-Sku <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Update Domain Service operation can be used to update the existing deployment.
The update call only supports the properties listed in the PATCH body.

## EXAMPLES

### Example 1: Update AzADDomainService By ResourceGroupName and Name
```powershell
Update-AzADDomainService -Name youriADdomain -ResourceGroupName youriADdomain -DomainSecuritySettingTlsV1 Disabled
```

```output
Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Update AzADDomainService By ResourceGroupName and Name

### Example 2: Update AzADDomainService By InputObject
```powershell
$getAzAddomain = Get-AzADDomainService -Name youriADdomain -ResourceGroupName youriADdomain
Update-AzADDomainService -InputObject $getAzAddomain -DomainSecuritySettingTlsV1 Disabled
```

```output
Name          Domain Name       Location Sku
----          -----------       -------- ---
youriADdomain youriAddomain.com westus   Enterprise
```

Update AzADDomainService By InputObject

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

### -DomainSecuritySettingNtlmV1
A flag to determine whether or not NtlmV1 is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NtlmV1
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncKerberosPasswords
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncNtlmPasswords
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.SyncOnPremPasswords
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.TlsV1
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.FilteredSync
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ForestTrust
List of settings for Resource Forest
To construct, see NOTES section for FORESTTRUST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IForestTrust[]
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

### -LdapSettingExternalAccess
A flag to determine whether or not Secure LDAP access over the internet is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.ExternalAccess
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LdapSettingLdaps
A flag to determine whether or not Secure LDAP is enabled or disabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.Ldaps
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LdapSettingPfxCertificateInputFile
Input File for LdapSettingPfxCertificate (The certificate required to configure Secure LDAP.
The parameter passed here should be a base64encoded representation of the certificate pfx file.)

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
Type: System.Security.SecureString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyDcAdmins
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Support.NotifyGlobalAdmins
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### -ResourceForest
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

### Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.IAdDomainServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ADDomainServices.Models.Api202001.IDomainService

## NOTES

## RELATED LINKS
