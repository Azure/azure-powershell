---
external help file:
Module Name: Az.NotificationHubs
online version: https://docs.microsoft.com/en-us/powershell/module/az.notificationhubs/update-aznotificationhubsnotificationhub
schema: 2.0.0
---

# Update-AzNotificationHubsNotificationHub

## SYNOPSIS
Patch a NotificationHub in a namespace.

## SYNTAX

### PatchExpanded (Default)
```
Update-AzNotificationHubsNotificationHub -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-ApnsCertificate <String>] [-ApnsCredentialPropertiesCertificateKey <String>]
 [-ApnsCredentialPropertiesThumbprint <String>] [-AppId <String>] [-AppName <String>]
 [-AuthorizationRule <ISharedAccessAuthorizationRuleProperties[]>] [-AuthTokenUrl <String>]
 [-BaiduApiKey <String>] [-BaiduEndPoint <String>] [-BaiduSecretKey <String>] [-ClientId <String>]
 [-ClientSecret <String>] [-Endpoint <String>] [-GcmEndpoint <String>] [-GoogleApiKey <String>]
 [-KeyId <String>] [-Location <String>] [-MpnsCertificate <String>]
 [-MpnsCredentialPropertiesCertificateKey <String>] [-MpnsCredentialPropertiesThumbprint <String>]
 [-PackageSid <String>] [-PropertiesName <String>] [-RegistrationTtl <String>] [-SecretKey <String>]
 [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuName <SkuName>] [-SkuSize <String>] [-SkuTier <String>]
 [-Tag <Hashtable>] [-Token <String>] [-WindowsLiveEndpoint <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Patch
```
Update-AzNotificationHubsNotificationHub -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 -Parameter <INotificationHubPatchParameters> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentity
```
Update-AzNotificationHubsNotificationHub -InputObject <INotificationHubsIdentity>
 -Parameter <INotificationHubPatchParameters> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### PatchViaIdentityExpanded
```
Update-AzNotificationHubsNotificationHub -InputObject <INotificationHubsIdentity> [-ApnsCertificate <String>]
 [-ApnsCredentialPropertiesCertificateKey <String>] [-ApnsCredentialPropertiesThumbprint <String>]
 [-AppId <String>] [-AppName <String>] [-AuthorizationRule <ISharedAccessAuthorizationRuleProperties[]>]
 [-AuthTokenUrl <String>] [-BaiduApiKey <String>] [-BaiduEndPoint <String>] [-BaiduSecretKey <String>]
 [-ClientId <String>] [-ClientSecret <String>] [-Endpoint <String>] [-GcmEndpoint <String>]
 [-GoogleApiKey <String>] [-KeyId <String>] [-Location <String>] [-MpnsCertificate <String>]
 [-MpnsCredentialPropertiesCertificateKey <String>] [-MpnsCredentialPropertiesThumbprint <String>]
 [-PackageSid <String>] [-PropertiesName <String>] [-RegistrationTtl <String>] [-SecretKey <String>]
 [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuName <SkuName>] [-SkuSize <String>] [-SkuTier <String>]
 [-Tag <Hashtable>] [-Token <String>] [-WindowsLiveEndpoint <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patch a NotificationHub in a namespace.

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

### -ApnsCertificate
The APNS certificate.
Specify if using Certificate Authentication Mode.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApnsCredentialPropertiesCertificateKey
The APNS certificate password if it exists.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApnsCredentialPropertiesThumbprint
The APNS certificate thumbprint.
Specify if using Certificate Authentication Mode.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppId
The issuer (iss) registered claim key.
The value is a 10-character TeamId, obtained from your developer account.
Specify if using Token Authentication Mode.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppName
The name of the application or BundleId.
Specify if using Token Authentication Mode.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorizationRule
The AuthorizationRules of the created NotificationHub
To construct, see NOTES section for AUTHORIZATIONRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.Api20170401.ISharedAccessAuthorizationRuleProperties[]
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthTokenUrl
The URL of the authorization token.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BaiduApiKey
Baidu Api Key.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BaiduEndPoint
Baidu Endpoint.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BaiduSecretKey
Baidu Secret Key

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientId
The client identifier.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientSecret
The credential secret access key.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
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

### -Endpoint
The APNS endpoint of this credential.
If using Certificate Authentication Mode and Sandbox specify 'gateway.sandbox.push.apple.com'.
If using Certificate Authentication Mode and Production specify 'gateway.push.apple.com'.
If using Token Authentication Mode and Sandbox specify 'https://api.development.push.apple.com:443/3/device'.
If using Token Authentication Mode and Production specify 'https://api.push.apple.com:443/3/device'.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GcmEndpoint
The FCM legacy endpoint.
Default value is 'https://fcm.googleapis.com/fcm/send'

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GoogleApiKey
The Google API key.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.INotificationHubsIdentity
Parameter Sets: PatchViaIdentity, PatchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyId
A 10-character key identifier (kid) key, obtained from your developer account.
Specify if using Token Authentication Mode.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
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
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MpnsCertificate
The MPNS certificate.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MpnsCredentialPropertiesCertificateKey
The certificate key for this credential.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MpnsCredentialPropertiesThumbprint
The MPNS certificate Thumbprint

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The notification hub name.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases: NotificationHubName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The namespace name.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageSid
The package ID for this credential.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Parameters supplied to the patch NotificationHub operation.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.Api20170401.INotificationHubPatchParameters
Parameter Sets: Patch, PatchViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PropertiesName
The NotificationHub name.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistrationTtl
The RegistrationTtl of the created NotificationHub

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
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
Parameter Sets: Patch, PatchExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecretKey
The secret key.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
The capacity of the resource

```yaml
Type: System.Int32
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuFamily
The Sku Family

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
Name of the notification hub sku

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Support.SkuName
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuSize
The Sku size

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuTier
The tier of particular sku

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
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
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Token
Provider Authentication Token, obtained through your developer account.
Specify if using Token Authentication Mode.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowsLiveEndpoint
The Windows Live endpoint.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.Api20170401.INotificationHubPatchParameters

### Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.INotificationHubsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NotificationHubs.Models.Api20170401.INotificationHubResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


AUTHORIZATIONRULE <ISharedAccessAuthorizationRuleProperties[]>: The AuthorizationRules of the created NotificationHub
  - `[Rights <AccessRights[]>]`: The rights associated with the rule.

INPUTOBJECT <INotificationHubsIdentity>: Identity Parameter
  - `[AuthorizationRuleName <String>]`: Authorization Rule Name.
  - `[Id <String>]`: Resource identity path
  - `[NamespaceName <String>]`: The namespace name.
  - `[NotificationHubName <String>]`: The notification hub name.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

PARAMETER <INotificationHubPatchParameters>: Parameters supplied to the patch NotificationHub operation.
  - `[Location <String>]`: Resource location
  - `[SkuCapacity <Int32?>]`: The capacity of the resource
  - `[SkuFamily <String>]`: The Sku Family
  - `[SkuName <SkuName?>]`: Name of the notification hub sku
  - `[SkuSize <String>]`: The Sku size
  - `[SkuTier <String>]`: The tier of particular sku
  - `[Tag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[ApnsCertificate <String>]`: The APNS certificate. Specify if using Certificate Authentication Mode.
  - `[ApnsCredentialPropertiesCertificateKey <String>]`: The APNS certificate password if it exists.
  - `[ApnsCredentialPropertiesThumbprint <String>]`: The APNS certificate thumbprint. Specify if using Certificate Authentication Mode.
  - `[AppId <String>]`: The issuer (iss) registered claim key. The value is a 10-character TeamId, obtained from your developer account. Specify if using Token Authentication Mode.
  - `[AppName <String>]`: The name of the application or BundleId. Specify if using Token Authentication Mode.
  - `[AuthTokenUrl <String>]`: The URL of the authorization token.
  - `[AuthorizationRule <ISharedAccessAuthorizationRuleProperties[]>]`: The AuthorizationRules of the created NotificationHub
    - `[Rights <AccessRights[]>]`: The rights associated with the rule.
  - `[BaiduApiKey <String>]`: Baidu Api Key.
  - `[BaiduEndPoint <String>]`: Baidu Endpoint.
  - `[BaiduSecretKey <String>]`: Baidu Secret Key
  - `[ClientId <String>]`: The client identifier.
  - `[ClientSecret <String>]`: The credential secret access key.
  - `[Endpoint <String>]`: The APNS endpoint of this credential. If using Certificate Authentication Mode and Sandbox specify 'gateway.sandbox.push.apple.com'. If using Certificate Authentication Mode and Production specify 'gateway.push.apple.com'. If using Token Authentication Mode and Sandbox specify 'https://api.development.push.apple.com:443/3/device'. If using Token Authentication Mode and Production specify 'https://api.push.apple.com:443/3/device'.
  - `[GcmEndpoint <String>]`: The FCM legacy endpoint. Default value is 'https://fcm.googleapis.com/fcm/send'
  - `[GoogleApiKey <String>]`: The Google API key.
  - `[KeyId <String>]`: A 10-character key identifier (kid) key, obtained from your developer account. Specify if using Token Authentication Mode.
  - `[MpnsCertificate <String>]`: The MPNS certificate.
  - `[MpnsCredentialPropertiesCertificateKey <String>]`: The certificate key for this credential.
  - `[MpnsCredentialPropertiesThumbprint <String>]`: The MPNS certificate Thumbprint
  - `[PackageSid <String>]`: The package ID for this credential.
  - `[PropertiesName <String>]`: The NotificationHub name.
  - `[RegistrationTtl <String>]`: The RegistrationTtl of the created NotificationHub
  - `[SecretKey <String>]`: The secret key.
  - `[Token <String>]`: Provider Authentication Token, obtained through your developer account. Specify if using Token Authentication Mode.
  - `[WindowsLiveEndpoint <String>]`: The Windows Live endpoint.

## RELATED LINKS

