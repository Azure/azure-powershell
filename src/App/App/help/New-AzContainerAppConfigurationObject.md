---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappconfigurationobject
schema: 2.0.0
---

# New-AzContainerAppConfigurationObject

## SYNOPSIS
Create an in-memory object for Configuration.

## SYNTAX

```
New-AzContainerAppConfigurationObject [-ActiveRevisionsMode <String>] [-CorPolicyAllowCredentials <Boolean>]
 [-CorPolicyAllowedHeader <String[]>] [-CorPolicyAllowedMethod <String[]>] [-CorPolicyAllowedOrigin <String[]>]
 [-CorPolicyExposeHeader <String[]>] [-CorPolicyMaxAge <Int32>] [-DaprAppId <String>] [-DaprAppPort <Int32>]
 [-DaprAppProtocol <String>] [-DaprEnableApiLogging <Boolean>] [-DaprEnabled <Boolean>]
 [-DaprHttpMaxRequestSize <Int32>] [-DaprHttpReadBufferSize <Int32>] [-DaprLogLevel <String>]
 [-IngressAllowInsecure <Boolean>] [-IngressClientCertificateMode <String>]
 [-IngressCustomDomain <ICustomDomain[]>] [-IngressExposedPort <Int32>] [-IngressExternal <Boolean>]
 [-IngressIPSecurityRestriction <IIPSecurityRestrictionRule[]>] [-IngressTargetPort <Int32>]
 [-IngressTraffic <ITrafficWeight[]>] [-IngressTransport <String>] [-MaxInactiveRevision <Int32>]
 [-Registry <IRegistryCredentials[]>] [-Secret <ISecret[]>] [-ServiceType <String>]
 [-StickySessionAffinity <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Configuration.

## EXAMPLES

### Example 1: Create an in-memory object for Configuration.
```powershell
$customDomain = New-AzContainerAppCustomDomainObject -Name "www.my-name.com" -BindingType "SniEnabled" -CertificateId "/subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.App/managedEnvironments/{manageEnvName}/certificates/{testcert}"
$trafficWeight = New-AzContainerAppTrafficWeightObject -Label "production" -RevisionName "testcontainerApp0-ab1234" -Weight 100
$iPSecurityRestrictionRule = New-AzContainerAppIPSecurityRestrictionRuleObject -Action "Allow" -IPAddressRange "192.168.1.1/32" -Name "Allow work IP A subnet"

New-AzContainerAppConfigurationObject -IngressCustomDomain $customDomain -IngressIPSecurityRestriction $iPSecurityRestrictionRule -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 3000 -IngressClientCertificateMode "accept" -CorPolicyAllowedOrigin "https://a.test.com","https://b.test.com" -CorPolicyAllowedMethod "GET","POST" -CorPolicyAllowedHeader "HEADER1","HEADER2" -CorPolicyExposeHeader "HEADER3","HEADER4" -CorPolicyMaxAge 1234 -CorPolicyAllowCredentials:$True -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -IngressTransport "http"
```

```output
ActiveRevisionsMode MaxInactiveRevision
------------------- -------------------
                    10
```

Create an in-memory object for Configuration.

## PARAMETERS

### -ActiveRevisionsMode
ActiveRevisionsMode controls how active revisions are handled for the Container app:
        \<list\>\<item\>Multiple: multiple revisions can be active.\</item\>\<item\>Single: Only one revision can be active at a time.
Revision weights can not be used in this mode.
If no value if provided, this is the default.\</item\>\</list\>.

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

### -CorPolicyAllowCredentials
Specifies whether the resource allows credentials.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CorPolicyAllowedHeader
Specifies the content for the access-control-allow-headers header.

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

### -CorPolicyAllowedMethod
Specifies the content for the access-control-allow-methods header.

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

### -CorPolicyAllowedOrigin
Specifies the content for the access-control-allow-origins header.

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

### -CorPolicyExposeHeader
Specifies the content for the access-control-expose-headers header .

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

### -CorPolicyMaxAge
Specifies the content for the access-control-max-age header.

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

### -DaprAppId
Dapr application identifier.

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

### -DaprAppPort
Tells Dapr which port your application is listening on.

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

### -DaprAppProtocol
Tells Dapr which protocol your application is using.
Valid options are http and grpc.
Default is http.

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

### -DaprEnableApiLogging
Enables API logging for the Dapr sidecar.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DaprEnabled
Boolean indicating if the Dapr side car is enabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DaprHttpMaxRequestSize
Increasing max size of request body http and grpc servers parameter in MB to handle uploading of big files.
Default is 4 MB.

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

### -DaprHttpReadBufferSize
Dapr max size of http header read buffer in KB to handle when sending multi-KB headers.
Default is 65KB.

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

### -DaprLogLevel
Sets the log level for the Dapr sidecar.
Allowed values are debug, info, warn, error.
Default is info.

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

### -IngressAllowInsecure
Bool indicating if HTTP connections to is allowed.
If set to false HTTP connections are automatically redirected to HTTPS connections.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngressClientCertificateMode
Client certificate mode for mTLS authentication.
Ignore indicates server drops client certificate on forwarding.
Accept indicates server forwards client certificate but does not require a client certificate.
Require indicates server requires a client certificate.

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

### -IngressCustomDomain
custom domain bindings for Container Apps' hostnames.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.ICustomDomain[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngressExposedPort
Exposed Port in containers for TCP traffic from ingress.

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

### -IngressExternal
Bool indicating if app exposes an external http endpoint.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngressIPSecurityRestriction
Rules to restrict incoming IP address.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IIPSecurityRestrictionRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngressTargetPort
Target Port in containers for traffic from ingress.

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

### -IngressTraffic
Traffic weights for app's revisions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.ITrafficWeight[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngressTransport
Ingress transport protocol.

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

### -MaxInactiveRevision
Optional.
Max inactive revisions a Container App can have.

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

### -Registry
Collection of private container registry credentials for containers used by the Container app.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IRegistryCredentials[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Secret
Collection of secrets used by a Container app.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.ISecret[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceType
Dev ContainerApp service type.

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

### -StickySessionAffinity
Sticky Session Affinity.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Configuration

## NOTES

## RELATED LINKS
