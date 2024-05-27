---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/update-azspringcloudgateway
schema: 2.0.0
---

# Update-AzSpringCloudGateway

## SYNOPSIS
Update the default Spring Cloud Gateway or Update the existing Spring Cloud Gateway.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSpringCloudGateway -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String>] [-ApiMetadataPropertyDescription <String>]
 [-ApiMetadataPropertyDocumentation <String>] [-ApiMetadataPropertyServerUrl <String>]
 [-ApiMetadataPropertyTitle <String>] [-ApiMetadataPropertyVersion <String>] [-Apm <IApmReference[]>]
 [-ClientAuthCertificate <String[]>] [-ClientAuthCertificateVerification <String>]
 [-CorPropertyAllowCredentials] [-CorPropertyAllowedHeader <String[]>] [-CorPropertyAllowedMethod <String[]>]
 [-CorPropertyAllowedOrigin <String[]>] [-CorPropertyAllowedOriginPattern <String[]>]
 [-CorPropertyExposedHeader <String[]>] [-CorPropertyMaxAge <Int32>]
 [-EnvironmentVariableProperty <Hashtable>] [-EnvironmentVariableSecret <Hashtable>] [-HttpsOnly] [-Public]
 [-ResourceRequestsCpu <String>] [-ResourceRequestsMemory <String>] [-SkuCapacity <Int32>] [-SkuName <String>]
 [-SkuTier <String>] [-SsoPropertyClientId <String>] [-SsoPropertyClientSecret <String>]
 [-SsoPropertyIssuerUri <String>] [-SsoPropertyScope <String[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSpringCloudGateway -InputObject <ISpringAppsIdentity> [-ApiMetadataPropertyDescription <String>]
 [-ApiMetadataPropertyDocumentation <String>] [-ApiMetadataPropertyServerUrl <String>]
 [-ApiMetadataPropertyTitle <String>] [-ApiMetadataPropertyVersion <String>] [-Apm <IApmReference[]>]
 [-ClientAuthCertificate <String[]>] [-ClientAuthCertificateVerification <String>]
 [-CorPropertyAllowCredentials] [-CorPropertyAllowedHeader <String[]>] [-CorPropertyAllowedMethod <String[]>]
 [-CorPropertyAllowedOrigin <String[]>] [-CorPropertyAllowedOriginPattern <String[]>]
 [-CorPropertyExposedHeader <String[]>] [-CorPropertyMaxAge <Int32>]
 [-EnvironmentVariableProperty <Hashtable>] [-EnvironmentVariableSecret <Hashtable>] [-HttpsOnly] [-Public]
 [-ResourceRequestsCpu <String>] [-ResourceRequestsMemory <String>] [-SkuCapacity <Int32>] [-SkuName <String>]
 [-SkuTier <String>] [-SsoPropertyClientId <String>] [-SsoPropertyClientSecret <String>]
 [-SsoPropertyIssuerUri <String>] [-SsoPropertyScope <String[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentitySpringExpanded
```
Update-AzSpringCloudGateway -Name <String> -SpringInputObject <ISpringAppsIdentity>
 [-ApiMetadataPropertyDescription <String>] [-ApiMetadataPropertyDocumentation <String>]
 [-ApiMetadataPropertyServerUrl <String>] [-ApiMetadataPropertyTitle <String>]
 [-ApiMetadataPropertyVersion <String>] [-Apm <IApmReference[]>] [-ClientAuthCertificate <String[]>]
 [-ClientAuthCertificateVerification <String>] [-CorPropertyAllowCredentials]
 [-CorPropertyAllowedHeader <String[]>] [-CorPropertyAllowedMethod <String[]>]
 [-CorPropertyAllowedOrigin <String[]>] [-CorPropertyAllowedOriginPattern <String[]>]
 [-CorPropertyExposedHeader <String[]>] [-CorPropertyMaxAge <Int32>]
 [-EnvironmentVariableProperty <Hashtable>] [-EnvironmentVariableSecret <Hashtable>] [-HttpsOnly] [-Public]
 [-ResourceRequestsCpu <String>] [-ResourceRequestsMemory <String>] [-SkuCapacity <Int32>] [-SkuName <String>]
 [-SkuTier <String>] [-SsoPropertyClientId <String>] [-SsoPropertyClientSecret <String>]
 [-SsoPropertyIssuerUri <String>] [-SsoPropertyScope <String[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the default Spring Cloud Gateway or Update the existing Spring Cloud Gateway.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -ApiMetadataPropertyDescription
Detailed description of the APIs available on the Gateway instance (default: `Generated OpenAPI 3 document that describes the API routes configured.`)

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

### -ApiMetadataPropertyDocumentation
Location of additional documentation for the APIs available on the Gateway instance

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

### -ApiMetadataPropertyServerUrl
Base URL that API consumers will use to access APIs on the Gateway instance.

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

### -ApiMetadataPropertyTitle
Title describing the context of the APIs available on the Gateway instance (default: `Spring Cloud Gateway for K8S`)

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

### -ApiMetadataPropertyVersion
Version of APIs available on this Gateway instance (default: `unspecified`).

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

### -Apm
Collection of ApmReferences in service level

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IApmReference[]
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
Collection of certificate resource Ids in Azure Spring Apps.

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

### -ClientAuthCertificateVerification
Whether to enable certificate verification or not

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

### -CorPropertyAllowCredentials
Whether user credentials are supported on cross-site requests.
Valid values: `true`, `false`.

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

### -CorPropertyAllowedHeader
Allowed headers in cross-site requests.
The special value `*` allows actual requests to send any header.

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

### -CorPropertyAllowedMethod
Allowed HTTP methods on cross-site requests.
The special value `*` allows all methods.
If not set, `GET` and `HEAD` are allowed by default.

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

### -CorPropertyAllowedOrigin
Allowed origins to make cross-site requests.
The special value `*` allows all domains.

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

### -CorPropertyAllowedOriginPattern
Allowed origin patterns to make cross-site requests.

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

### -CorPropertyExposedHeader
HTTP response headers to expose for cross-site requests.

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

### -CorPropertyMaxAge
How long, in seconds, the response from a pre-flight request can be cached by clients.

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

### -EnvironmentVariableProperty
Non-sensitive properties

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

### -EnvironmentVariableSecret
Sensitive properties

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of Spring Cloud Gateway.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentitySpringExpanded
Aliases: GatewayName

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

### -Public
Indicates whether the Spring Cloud Gateway exposes endpoint.

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

### -ResourceRequestsCpu
Cpu allocated to each Spring Cloud Gateway instance.

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

### -ResourceRequestsMemory
Memory allocated to each Spring Cloud Gateway instance.

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

### -SkuCapacity
Current capacity of the target resource

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

### -SkuName
Name of the Sku

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

### -SkuTier
Tier of the Sku

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

### -SpringInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: UpdateViaIdentitySpringExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SsoPropertyClientId
The public identifier for the application

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

### -SsoPropertyClientSecret
The secret known only to the application and the authorization server

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

### -SsoPropertyIssuerUri
The URI of Issuer Identifier

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

### -SsoPropertyScope
It defines the specific actions applications can be allowed to do on a user's behalf

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IGatewayResource

## NOTES

## RELATED LINKS

