---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebsiteconnection
schema: 2.0.0
---

# New-AzWebSiteConnection

## SYNOPSIS
Creates or updates a connection.

## SYNTAX

### CreateExpanded (Default)
```
New-AzWebSiteConnection -ConnectionName <String> -ResourceGroupName <String> -SubscriptionId <String>
 -Location <String> [-Name <String>] [-ApiId <String>] [-ApiKind <String>] [-ApiLocation <String>]
 [-ApiName <String>] [-ApiTag <Hashtable>] [-ApiType <String>] [-ChangedTime <DateTime>]
 [-CreatedTime <DateTime>] [-CustomParameterValue <Hashtable>] [-DisplayName <String>]
 [-Entity <IResponseMessageEnvelopeApiEntity>] [-FirstExpirationTime <DateTime>] [-Id <String>]
 [-Keyword <String[]>] [-Kind <String>] [-Metadata <IObject>] [-NonSecretParameterValue <Hashtable>]
 [-ParameterValue <Hashtable>] [-PropertiesId <String>] [-PropertiesName <String>]
 [-Statuses <IConnectionStatus[]>] [-Tag <Hashtable>] [-TenantId <String>] [-Type <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzWebSiteConnection -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -Connection <IConnection> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzWebSiteConnection -InputObject <IWebSiteIdentity> -Connection <IConnection> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzWebSiteConnection -InputObject <IWebSiteIdentity> -Location <String> [-Name <String>] [-ApiId <String>]
 [-ApiKind <String>] [-ApiLocation <String>] [-ApiName <String>] [-ApiTag <Hashtable>] [-ApiType <String>]
 [-ChangedTime <DateTime>] [-CreatedTime <DateTime>] [-CustomParameterValue <Hashtable>]
 [-DisplayName <String>] [-Entity <IResponseMessageEnvelopeApiEntity>] [-FirstExpirationTime <DateTime>]
 [-Id <String>] [-Keyword <String[]>] [-Kind <String>] [-Metadata <IObject>]
 [-NonSecretParameterValue <Hashtable>] [-ParameterValue <Hashtable>] [-PropertiesId <String>]
 [-PropertiesName <String>] [-Statuses <IConnectionStatus[]>] [-Tag <Hashtable>] [-TenantId <String>]
 [-Type <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a connection.

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

### -ApiId
Resource Id

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApiKind
Kind of resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApiLocation
Resource Location

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApiName
Resource Name

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApiTag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApiType
Resource type

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ChangedTime
Timestamp of last connection change.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Connection
API Connection
To construct, see NOTES section for CONNECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801Preview.IConnection
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ConnectionName
The connection name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CreatedTime
Timestamp of the connection creation

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CustomParameterValue
Custom login setting values.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -DisplayName
display name

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Entity
Id of connection provider
To construct, see NOTES section for ENTITY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801Preview.IResponseMessageEnvelopeApiEntity
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -FirstExpirationTime
Time in UTC when the first expiration of OAuth tokens

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Resource Id

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Keyword
List of Keywords that tag the acl

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource Location

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Metadata
HELP MESSAGE MISSING

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801Preview.IObject
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The connection name.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NonSecretParameterValue
Tokens/Claim

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ParameterValue
Tokens/Claim

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesId
Id of connection provider

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesName
connection name

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Statuses
Status of the connection
To construct, see NOTES section for STATUSES properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801Preview.IConnectionStatus[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TenantId
HELP MESSAGE MISSING

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Type
Resource type

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801Preview.IConnection

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801Preview.IConnection

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CONNECTION <IConnection>: API Connection
  - `Location <String>`: Resource Location
  - `ApiLocation <String>`: Resource Location
  - `[Id <String>]`: Resource Id
  - `[Kind <String>]`: Kind of resource
  - `[Name <String>]`: Resource Name
  - `[Tag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Type <String>]`: Resource type
  - `[ApiId <String>]`: Resource Id
  - `[ApiKind <String>]`: Kind of resource
  - `[ApiName <String>]`: Resource Name
  - `[ApiTag <IResourceTags>]`: Resource tags
  - `[ApiType <String>]`: Resource type
  - `[ChangedTime <DateTime?>]`: Timestamp of last connection change.
  - `[CreatedTime <DateTime?>]`: Timestamp of the connection creation
  - `[CustomParameterValue <IConnectionPropertiesCustomParameterValues>]`: Custom login setting values.
    - `[(Any) <IParameterCustomLoginSettingValues>]`: This indicates any property can be added to this object.
      - `Location <String>`: Resource Location
      - `[Id <String>]`: Resource Id
      - `[Kind <String>]`: Kind of resource
      - `[Name <String>]`: Resource Name
      - `[Tag <IResourceTags>]`: Resource tags
        - `[(Any) <String>]`: This indicates any property can be added to this object.
      - `[Type <String>]`: Resource type
  - `[DisplayName <String>]`: display name
  - `[Entity <IResponseMessageEnvelopeApiEntity>]`: Id of connection provider
    - `BackendServiceLocation <String>`: Resource Location
    - `GeneralInformationLocation <String>`: Resource Location
    - `PolicyLocation <String>`: Resource Location
    - `PropertiesLocation <String>`: Resource Location
    - `[ApiDefinitionUrl <String>]`: API definition Url - url where the swagger can be downloaded from
    - `[BackendServiceId <String>]`: Resource Id
    - `[BackendServiceKind <String>]`: Kind of resource
    - `[BackendServiceName <String>]`: Resource Name
    - `[BackendServiceTag <IResourceTags>]`: Resource tags
    - `[BackendServiceType <String>]`: Resource type
    - `[Capability <String[]>]`: Capabilities
    - `[ChangedTime <DateTime?>]`: Timestamp of last connection change.
    - `[ConnectionDisplayName <String>]`: DefaultConnectionNameTemplate
    - `[ConnectionParameter <IApiEntityPropertiesConnectionParameters>]`: Connection parameters
      - `[(Any) <IConnectionParameter>]`: This indicates any property can be added to this object.
    - `[ConnectionPortalUrl <IObject>]`: ConnectionPortalUrl
    - `[Content <String>]`: Content of xml policy
    - `[CreatedTime <DateTime?>]`: Timestamp of the connection creation
    - `[Description <String>]`: Description
    - `[DisplayName <String>]`: Display Name
    - `[GeneralInformationId <String>]`: Resource Id
    - `[GeneralInformationKind <String>]`: Kind of resource
    - `[GeneralInformationName <String>]`: Resource Name
    - `[GeneralInformationTag <IResourceTags>]`: Resource tags
    - `[GeneralInformationType <String>]`: Resource type
    - `[HostingEnvironmentServiceUrl <IHostingEnvironmentServiceDescriptions[]>]`: Service Urls per Hosting environment
      - `[HostId <String>]`: Host Id
      - `[HostingEnvironmentId <String>]`: Hosting environment Id
      - `[ServiceUrl <String>]`: service url to use
      - `[UseInternalRouting <Boolean?>]`: When the backend url is in same ASE, for performance reason this flag can be set to true                     If WebApp.DisableHostNames is also set it improves the security by making the back end accessible only                     via API calls                     Note: calls will fail if this option is used but back end is not on the same ASE
    - `[IconUrl <String>]`: Icon Url
    - `[Id <String>]`: Resource Id. Typically id is populated only for responses to GET requests. Caller is responsible for passing in this                     value for GET requests only.                     For example: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupId}/providers/Microsoft.Web/sites/{sitename}
    - `[Kind <String>]`: Kind of resource
    - `[Location <String>]`: Geo region resource belongs to e.g. SouthCentralUS, SouthEastAsia
    - `[Metadata <IObject>]`: Free form object for the data caller wants to store
    - `[Name <String>]`: Name of resource
    - `[Path <String>]`: the URL path of this API when exposed via APIM
    - `[PlanName <String>]`: The name
    - `[PlanProduct <String>]`: The product
    - `[PlanPromotionCode <String>]`: The promotion code
    - `[PlanPublisher <String>]`: The publisher
    - `[PlanVersion <String>]`: Version of product
    - `[PolicyId <String>]`: Resource Id
    - `[PolicyKind <String>]`: Kind of resource
    - `[PolicyName <String>]`: Resource Name
    - `[PolicyTag <IResourceTags>]`: Resource tags
    - `[PolicyType <String>]`: Resource type
    - `[PropertiesId <String>]`: Resource Id
    - `[PropertiesName <String>]`: Name of the API                     the URL path of this API when exposed via APIM
    - `[PropertiesTag <IResourceTags>]`: Resource tags
    - `[PropertiesType <String>]`: Resource type
    - `[Protocol <String[]>]`: Protocols supported by the front end - http/https
    - `[ResourceName <String>]`: Resource Name
    - `[RuntimeUrl <String[]>]`: Read only property returning the runtime endpoints where the API can be called
    - `[ServiceUrl <String>]`: Url from which the swagger payload will be fetched
    - `[SkuCapacity <Int32?>]`: Current number of instances assigned to the resource.
    - `[SkuFamily <String>]`: Family code of the resource SKU.
    - `[SkuName <String>]`: Name of the resource SKU.
    - `[SkuSize <String>]`: Size specifier of the resource SKU.
    - `[SkuTier <String>]`: Service tier of the resource SKU.
    - `[Tag <IResponseMessageEnvelopeApiEntityTags>]`: Tags associated with resource
      - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[TermsOfUseUrl <String>]`: a public accessible url of the Terms Of Use Url of this API
    - `[Type <String>]`: Type of resource e.g Microsoft.Web/sites
  - `[FirstExpirationTime <DateTime?>]`: Time in UTC when the first expiration of OAuth tokens
  - `[Keyword <String[]>]`: List of Keywords that tag the acl
  - `[Metadata <IObject>]`: 
  - `[NonSecretParameterValue <IConnectionPropertiesNonSecretParameterValues>]`: Tokens/Claim
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ParameterValue <IConnectionPropertiesParameterValues>]`: Tokens/Claim
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[PropertiesId <String>]`: Id of connection provider
  - `[PropertiesName <String>]`: connection name
  - `[Statuses <IConnectionStatus[]>]`: Status of the connection
    - `Location <String>`: Resource Location
    - `ErrorLocation <String>`: Resource Location
    - `[Id <String>]`: Resource Id
    - `[Kind <String>]`: Kind of resource
    - `[Name <String>]`: Resource Name
    - `[Tag <IResourceTags>]`: Resource tags
    - `[Type <String>]`: Resource type
    - `[Code <String>]`: code of the status
    - `[ErrorId <String>]`: Resource Id
    - `[ErrorKind <String>]`: Kind of resource
    - `[ErrorName <String>]`: Resource Name
    - `[ErrorTag <IResourceTags>]`: Resource tags
    - `[ErrorType <String>]`: Resource type
    - `[Message <String>]`: Description of the status
    - `[Status <String>]`: Status
    - `[Target <String>]`: Target of the error
  - `[TenantId <String>]`: 

#### ENTITY <IResponseMessageEnvelopeApiEntity>: Id of connection provider
  - `BackendServiceLocation <String>`: Resource Location
  - `GeneralInformationLocation <String>`: Resource Location
  - `PolicyLocation <String>`: Resource Location
  - `PropertiesLocation <String>`: Resource Location
  - `[ApiDefinitionUrl <String>]`: API definition Url - url where the swagger can be downloaded from
  - `[BackendServiceId <String>]`: Resource Id
  - `[BackendServiceKind <String>]`: Kind of resource
  - `[BackendServiceName <String>]`: Resource Name
  - `[BackendServiceTag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[BackendServiceType <String>]`: Resource type
  - `[Capability <String[]>]`: Capabilities
  - `[ChangedTime <DateTime?>]`: Timestamp of last connection change.
  - `[ConnectionDisplayName <String>]`: DefaultConnectionNameTemplate
  - `[ConnectionParameter <IApiEntityPropertiesConnectionParameters>]`: Connection parameters
    - `[(Any) <IConnectionParameter>]`: This indicates any property can be added to this object.
  - `[ConnectionPortalUrl <IObject>]`: ConnectionPortalUrl
  - `[Content <String>]`: Content of xml policy
  - `[CreatedTime <DateTime?>]`: Timestamp of the connection creation
  - `[Description <String>]`: Description
  - `[DisplayName <String>]`: Display Name
  - `[GeneralInformationId <String>]`: Resource Id
  - `[GeneralInformationKind <String>]`: Kind of resource
  - `[GeneralInformationName <String>]`: Resource Name
  - `[GeneralInformationTag <IResourceTags>]`: Resource tags
  - `[GeneralInformationType <String>]`: Resource type
  - `[HostingEnvironmentServiceUrl <IHostingEnvironmentServiceDescriptions[]>]`: Service Urls per Hosting environment
    - `[HostId <String>]`: Host Id
    - `[HostingEnvironmentId <String>]`: Hosting environment Id
    - `[ServiceUrl <String>]`: service url to use
    - `[UseInternalRouting <Boolean?>]`: When the backend url is in same ASE, for performance reason this flag can be set to true                     If WebApp.DisableHostNames is also set it improves the security by making the back end accessible only                     via API calls                     Note: calls will fail if this option is used but back end is not on the same ASE
  - `[IconUrl <String>]`: Icon Url
  - `[Id <String>]`: Resource Id. Typically id is populated only for responses to GET requests. Caller is responsible for passing in this                     value for GET requests only.                     For example: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupId}/providers/Microsoft.Web/sites/{sitename}
  - `[Kind <String>]`: Kind of resource
  - `[Location <String>]`: Geo region resource belongs to e.g. SouthCentralUS, SouthEastAsia
  - `[Metadata <IObject>]`: Free form object for the data caller wants to store
  - `[Name <String>]`: Name of resource
  - `[Path <String>]`: the URL path of this API when exposed via APIM
  - `[PlanName <String>]`: The name
  - `[PlanProduct <String>]`: The product
  - `[PlanPromotionCode <String>]`: The promotion code
  - `[PlanPublisher <String>]`: The publisher
  - `[PlanVersion <String>]`: Version of product
  - `[PolicyId <String>]`: Resource Id
  - `[PolicyKind <String>]`: Kind of resource
  - `[PolicyName <String>]`: Resource Name
  - `[PolicyTag <IResourceTags>]`: Resource tags
  - `[PolicyType <String>]`: Resource type
  - `[PropertiesId <String>]`: Resource Id
  - `[PropertiesName <String>]`: Name of the API                     the URL path of this API when exposed via APIM
  - `[PropertiesTag <IResourceTags>]`: Resource tags
  - `[PropertiesType <String>]`: Resource type
  - `[Protocol <String[]>]`: Protocols supported by the front end - http/https
  - `[ResourceName <String>]`: Resource Name
  - `[RuntimeUrl <String[]>]`: Read only property returning the runtime endpoints where the API can be called
  - `[ServiceUrl <String>]`: Url from which the swagger payload will be fetched
  - `[SkuCapacity <Int32?>]`: Current number of instances assigned to the resource.
  - `[SkuFamily <String>]`: Family code of the resource SKU.
  - `[SkuName <String>]`: Name of the resource SKU.
  - `[SkuSize <String>]`: Size specifier of the resource SKU.
  - `[SkuTier <String>]`: Service tier of the resource SKU.
  - `[Tag <IResponseMessageEnvelopeApiEntityTags>]`: Tags associated with resource
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[TermsOfUseUrl <String>]`: a public accessible url of the Terms Of Use Url of this API
  - `[Type <String>]`: Type of resource e.g Microsoft.Web/sites

#### INPUTOBJECT <IWebSiteIdentity>: Identity Parameter
  - `[AnalysisName <String>]`: Analysis Name
  - `[ApiName <String>]`: The managed API name.
  - `[BackupId <String>]`: ID of the backup.
  - `[BaseAddress <String>]`: Module base address.
  - `[CertificateOrderName <String>]`: Name of the certificate order.
  - `[ConnectionName <String>]`: The connection name.
  - `[DeletedSiteId <String>]`: The numeric ID of the deleted app, e.g. 12345
  - `[DetectorName <String>]`: Detector Resource Name
  - `[DiagnosticCategory <String>]`: Diagnostic Category
  - `[DiagnosticsName <String>]`: Name of the diagnostics item.
  - `[DomainName <String>]`: Name of the domain.
  - `[DomainOwnershipIdentifierName <String>]`: Name of domain ownership identifier.
  - `[EntityName <String>]`: Name of the hybrid connection.
  - `[FunctionName <String>]`: Function name.
  - `[GatewayName <String>]`: Name of the gateway. Only the 'primary' gateway is supported.
  - `[HostName <String>]`: Hostname in the hostname binding.
  - `[HostingEnvironmentName <String>]`: Name of the hosting environment.
  - `[Id <String>]`: Resource identity path
  - `[Instance <String>]`: Name of the instance in the multi-role pool.
  - `[InstanceId <String>]`: ID of web app instance.
  - `[Location <String>]`: 
  - `[Name <String>]`: Name of the certificate.
  - `[NamespaceName <String>]`: Name of the Service Bus namespace.
  - `[OperationId <String>]`: GUID of the operation.
  - `[PremierAddOnName <String>]`: Add-on name.
  - `[ProcessId <String>]`: PID.
  - `[PublicCertificateName <String>]`: Public certificate name.
  - `[RelayName <String>]`: Name of the Service Bus relay.
  - `[ResourceGroupName <String>]`: Name of the resource group to which the resource belongs.
  - `[RouteName <String>]`: Name of the Virtual Network route.
  - `[SiteExtensionId <String>]`: Site extension name.
  - `[SiteName <String>]`: Site Name
  - `[Slot <String>]`: Name of web app slot. If not specified then will default to production slot.
  - `[SnapshotId <String>]`: The ID of the snapshot to read.
  - `[SourceControlType <String>]`: Type of source control
  - `[SubscriptionId <String>]`: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[ThreadId <String>]`: TID.
  - `[View <String>]`: The type of view. This can either be "summary" or "detailed".
  - `[VnetName <String>]`: Name of the Virtual Network.
  - `[WebJobName <String>]`: Name of Web Job.
  - `[WorkerName <String>]`: Name of worker machine, which typically starts with RD.
  - `[WorkerPoolName <String>]`: Name of the worker pool.

#### STATUSES <IConnectionStatus[]>: Status of the connection
  - `Location <String>`: Resource Location
  - `ErrorLocation <String>`: Resource Location
  - `[Id <String>]`: Resource Id
  - `[Kind <String>]`: Kind of resource
  - `[Name <String>]`: Resource Name
  - `[Tag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Type <String>]`: Resource type
  - `[Code <String>]`: code of the status
  - `[ErrorId <String>]`: Resource Id
  - `[ErrorKind <String>]`: Kind of resource
  - `[ErrorName <String>]`: Resource Name
  - `[ErrorTag <IResourceTags>]`: Resource tags
  - `[ErrorType <String>]`: Resource type
  - `[Message <String>]`: Description of the status
  - `[Status <String>]`: Status
  - `[Target <String>]`: Target of the error

## RELATED LINKS

