---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/new-azeventgridclient
schema: 2.0.0
---

# New-AzEventGridClient

## SYNOPSIS
Create a client with the specified parameters.

## SYNTAX

### CreateExpanded (Default)
```
New-AzEventGridClient -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Attribute <Hashtable>] [-AuthenticationName <String>]
 [-CertificateSubjectCommonName <String>] [-CertificateSubjectCountryCode <String>]
 [-CertificateSubjectOrganization <String>] [-CertificateSubjectOrganizationUnit <String>]
 [-CertificateThumbprintPrimary <String>] [-CertificateThumbprintSecondary <String>]
 [-ClientCertificateAuthenticationAllowedThumbprint <String[]>]
 [-ClientCertificateAuthenticationValidationScheme <String>] [-Description <String>] [-State <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzEventGridClient -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzEventGridClient -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-Break]
 [-HttpPipelineAppend <SendAsyncStep[]>] [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>]
 [-ProxyCredential <PSCredential>] [-ProxyUseDefaultCredentials] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNamespaceExpanded
```
New-AzEventGridClient -Name <String> -NamespaceInputObject <IEventGridIdentity> [-Attribute <Hashtable>]
 [-AuthenticationName <String>] [-CertificateSubjectCommonName <String>]
 [-CertificateSubjectCountryCode <String>] [-CertificateSubjectOrganization <String>]
 [-CertificateSubjectOrganizationUnit <String>] [-CertificateThumbprintPrimary <String>]
 [-CertificateThumbprintSecondary <String>] [-ClientCertificateAuthenticationAllowedThumbprint <String[]>]
 [-ClientCertificateAuthenticationValidationScheme <String>] [-Description <String>] [-State <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzEventGridClient -InputObject <IEventGridIdentity> [-Attribute <Hashtable>] [-AuthenticationName <String>]
 [-CertificateSubjectCommonName <String>] [-CertificateSubjectCountryCode <String>]
 [-CertificateSubjectOrganization <String>] [-CertificateSubjectOrganizationUnit <String>]
 [-CertificateThumbprintPrimary <String>] [-CertificateThumbprintSecondary <String>]
 [-ClientCertificateAuthenticationAllowedThumbprint <String[]>]
 [-ClientCertificateAuthenticationValidationScheme <String>] [-Description <String>] [-State <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Break] [-HttpPipelineAppend <SendAsyncStep[]>]
 [-HttpPipelinePrepend <SendAsyncStep[]>] [-NoWait] [-Proxy <Uri>] [-ProxyCredential <PSCredential>]
 [-ProxyUseDefaultCredentials] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a client with the specified parameters.

## EXAMPLES

### EXAMPLE 1
```
$attribute = @{"room"="345";"floor"="3";"deviceTypes"="Fan"}
New-AzEventGridClient -Name azps-client -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -Attribute $attribute -State Enabled -ClientCertificateAuthenticationValidationScheme "SubjectMatchesAuthenticationName"
```

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Attribute
Attributes for the client.
Supported values are int, bool, string, string\[\].Example:"attributes": { "room": "345", "floor": 12, "deviceTypes": \["Fan", "Light"\] }

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthenticationName
The name presented by the client for authentication.
The default value is the name of the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Break
Wait for .NET debugger to attach

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateSubjectCommonName
The common name field in the subject name.
The allowed limit is 64 characters and it should be specified.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateSubjectCountryCode
The country code field in the subject name.
If present, the country code should be represented by two-letter code defined in ISO 2166-1 (alpha-2).
For example: 'US'.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateSubjectOrganization
The organization field in the subject name.
If present, the allowed limit is 64 characters.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateSubjectOrganizationUnit
The organization unit field in the subject name.
If present, the allowed limit is 32 characters.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateThumbprintPrimary
The primary thumbprint used for validation.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateThumbprintSecondary
The secondary thumbprint used for validation.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientCertificateAuthenticationAllowedThumbprint
The list of thumbprints that are allowed during client authentication.
This property is required only if the validationScheme is 'ThumbprintMatch'.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientCertificateAuthenticationValidationScheme
The validation scheme used to authenticate the client.
Default value is SubjectMatchesAuthenticationName.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
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

### -Description
Description for the Client resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelineAppend
SendAsync Pipeline Steps to be appended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.SendAsyncStep[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpPipelinePrepend
SendAsync Pipeline Steps to be prepended to the front of the pipeline

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Runtime.SendAsyncStep[]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The client name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityNamespaceExpanded
Aliases: ClientName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
Parameter Sets: CreateViaIdentityNamespaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
Name of the namespace.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

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
Default value: False
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

### -Proxy
The URI for the proxy server to use

```yaml
Type: System.Uri
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyCredential
Credentials for a proxy server to use for the remote call

```yaml
Type: System.Management.Automation.PSCredential
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProxyUseDefaultCredentials
Use the default credentials for the proxy

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
Indicates if the client is enabled or not.
Default value is Enabled.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IClient
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT \<IEventGridIdentity\>: Identity Parameter
  \[CaCertificateName \<String\>\]: Name of the CA certificate.
  \[ChannelName \<String\>\]: Name of the channel.
  \[ClientGroupName \<String\>\]: Name of the client group.
  \[ClientName \<String\>\]: Name of the client.
  \[DomainName \<String\>\]: Name of the domain.
  \[DomainTopicName \<String\>\]: Name of the topic.
  \[EventSubscriptionName \<String\>\]: Name of the event subscription.
  \[Id \<String\>\]: Resource identity path
  \[Location \<String\>\]: Name of the location.
  \[NamespaceName \<String\>\]: Name of the namespace.
  \[ParentName \<String\>\]: The name of the parent resource (namely, either, the topic name, domain name, or partner namespace name or namespace name).
  \[ParentType \<String\>\]: The type of the parent resource.
This can be either \'topics\', \'domains\', or \'partnerNamespaces\' or \'namespaces\'.
  \[PartnerDestinationName \<String\>\]: Name of the partner destination.
  \[PartnerNamespaceName \<String\>\]: Name of the partner namespace.
  \[PartnerRegistrationName \<String\>\]: Name of the partner registration.
  \[PartnerTopicName \<String\>\]: Name of the partner topic.
  \[PermissionBindingName \<String\>\]: Name of the permission binding.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection connection.
  \[PrivateLinkResourceName \<String\>\]: The name of private link resource will be either topic, domain, partnerNamespace or namespace.
  \[ProviderNamespace \<String\>\]: Namespace of the provider of the topic.
  \[ResourceGroupName \<String\>\]: The name of the resource group within the user's subscription.
  \[ResourceName \<String\>\]: Name of the resource.
  \[ResourceTypeName \<String\>\]: Name of the resource type.
  \[Scope \<String\>\]: The scope of the event subscription.
The scope can be a subscription, or a resource group, or a top level resource belonging to a resource provider namespace, or an EventGrid topic.
For example, use '/subscriptions/{subscriptionId}/' for a subscription, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for a resource group, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}' for a resource, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{topicName}' for an EventGrid topic.
  \[SubscriptionId \<String\>\]: Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.
  \[SystemTopicName \<String\>\]: Name of the system topic.
  \[TopicName \<String\>\]: Name of the domain topic.
  \[TopicSpaceName \<String\>\]: Name of the Topic space.
  \[TopicTypeName \<String\>\]: Name of the topic type.
  \[VerifiedPartnerName \<String\>\]: Name of the verified partner.

NAMESPACEINPUTOBJECT \<IEventGridIdentity\>: Identity Parameter
  \[CaCertificateName \<String\>\]: Name of the CA certificate.
  \[ChannelName \<String\>\]: Name of the channel.
  \[ClientGroupName \<String\>\]: Name of the client group.
  \[ClientName \<String\>\]: Name of the client.
  \[DomainName \<String\>\]: Name of the domain.
  \[DomainTopicName \<String\>\]: Name of the topic.
  \[EventSubscriptionName \<String\>\]: Name of the event subscription.
  \[Id \<String\>\]: Resource identity path
  \[Location \<String\>\]: Name of the location.
  \[NamespaceName \<String\>\]: Name of the namespace.
  \[ParentName \<String\>\]: The name of the parent resource (namely, either, the topic name, domain name, or partner namespace name or namespace name).
  \[ParentType \<String\>\]: The type of the parent resource.
This can be either \'topics\', \'domains\', or \'partnerNamespaces\' or \'namespaces\'.
  \[PartnerDestinationName \<String\>\]: Name of the partner destination.
  \[PartnerNamespaceName \<String\>\]: Name of the partner namespace.
  \[PartnerRegistrationName \<String\>\]: Name of the partner registration.
  \[PartnerTopicName \<String\>\]: Name of the partner topic.
  \[PermissionBindingName \<String\>\]: Name of the permission binding.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection connection.
  \[PrivateLinkResourceName \<String\>\]: The name of private link resource will be either topic, domain, partnerNamespace or namespace.
  \[ProviderNamespace \<String\>\]: Namespace of the provider of the topic.
  \[ResourceGroupName \<String\>\]: The name of the resource group within the user's subscription.
  \[ResourceName \<String\>\]: Name of the resource.
  \[ResourceTypeName \<String\>\]: Name of the resource type.
  \[Scope \<String\>\]: The scope of the event subscription.
The scope can be a subscription, or a resource group, or a top level resource belonging to a resource provider namespace, or an EventGrid topic.
For example, use '/subscriptions/{subscriptionId}/' for a subscription, '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}' for a resource group, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}' for a resource, and '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/topics/{topicName}' for an EventGrid topic.
  \[SubscriptionId \<String\>\]: Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.
  \[SystemTopicName \<String\>\]: Name of the system topic.
  \[TopicName \<String\>\]: Name of the domain topic.
  \[TopicSpaceName \<String\>\]: Name of the Topic space.
  \[TopicTypeName \<String\>\]: Name of the topic type.
  \[VerifiedPartnerName \<String\>\]: Name of the verified partner.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.eventgrid/new-azeventgridclient](https://learn.microsoft.com/powershell/module/az.eventgrid/new-azeventgridclient)

