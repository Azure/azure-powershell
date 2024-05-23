---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/az.eventgrid/update-azeventgridclient
schema: 2.0.0
---

# Update-AzEventGridClient

## SYNOPSIS
Update a client with the specified parameters.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzEventGridClient -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Attribute <Hashtable>] [-AuthenticationName <String>]
 [-CertificateSubjectCommonName <String>] [-CertificateSubjectCountryCode <String>]
 [-CertificateSubjectOrganization <String>] [-CertificateSubjectOrganizationUnit <String>]
 [-CertificateThumbprintPrimary <String>] [-CertificateThumbprintSecondary <String>]
 [-ClientCertificateAuthenticationAllowedThumbprint <String[]>]
 [-ClientCertificateAuthenticationValidationScheme <String>] [-Description <String>] [-State <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityNamespaceExpanded
```
Update-AzEventGridClient -Name <String> -NamespaceInputObject <IEventGridIdentity> [-Attribute <Hashtable>]
 [-AuthenticationName <String>] [-CertificateSubjectCommonName <String>]
 [-CertificateSubjectCountryCode <String>] [-CertificateSubjectOrganization <String>]
 [-CertificateSubjectOrganizationUnit <String>] [-CertificateThumbprintPrimary <String>]
 [-CertificateThumbprintSecondary <String>] [-ClientCertificateAuthenticationAllowedThumbprint <String[]>]
 [-ClientCertificateAuthenticationValidationScheme <String>] [-Description <String>] [-State <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzEventGridClient -InputObject <IEventGridIdentity> [-Attribute <Hashtable>]
 [-AuthenticationName <String>] [-CertificateSubjectCommonName <String>]
 [-CertificateSubjectCountryCode <String>] [-CertificateSubjectOrganization <String>]
 [-CertificateSubjectOrganizationUnit <String>] [-CertificateThumbprintPrimary <String>]
 [-CertificateThumbprintSecondary <String>] [-ClientCertificateAuthenticationAllowedThumbprint <String[]>]
 [-ClientCertificateAuthenticationValidationScheme <String>] [-Description <String>] [-State <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a client with the specified parameters.

## EXAMPLES

### Example 1: Create a client with the specified parameters.
```powershell
$attribute = @{"room"="345";"floor"="3";"deviceTypes"="AC"}
Update-AzEventGridClient -Name azps-client -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid -Attribute $attribute -Description "This is a test client"
```

```output
Name        ResourceGroupName
----        -----------------
azps-client azps_test_group_eventgrid
```

Create a client with the specified parameters.

### Example 2: Create a client with the specified parameters.
```powershell
$attribute = @{"room"="345";"floor"="3";"deviceTypes"="AC"}
$client = Get-AzEventGridClient -Name azps-client -NamespaceName azps-eventgridnamespace -ResourceGroupName azps_test_group_eventgrid
Update-AzEventGridClient -InputObject $client -Attribute $attribute -Description "This is a test client"
```

```output
Name        ResourceGroupName
----        -----------------
azps-client azps_test_group_eventgrid
```

Create a client with the specified parameters.

### Example 3: Create a client with the specified parameters.
```powershell
$attribute = @{"room"="345";"floor"="3";"deviceTypes"="AC"}
$namespace = Get-AzEventGridNamespace -ResourceGroupName azps_test_group_eventgrid -Name azps-eventgridnamespace
Update-AzEventGridClient -Name azps-client -NamespaceInputObject $namespace -Attribute $attribute -Description "This is a test client"
```

```output
Name        ResourceGroupName
----        -----------------
azps-client azps_test_group_eventgrid
```

Create a client with the specified parameters.

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

### -Attribute
Attributes for the client.
Supported values are int, bool, string, string[].Example:"attributes": { "room": "345", "floor": 12, "deviceTypes": ["Fan", "Light"] }

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

### -AuthenticationName
The name presented by the client for authentication.
The default value is the name of the resource.

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

### -CertificateSubjectCommonName
The common name field in the subject name.
The allowed limit is 64 characters and it should be specified.

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

### -CertificateSubjectCountryCode
The country code field in the subject name.
If present, the country code should be represented by two-letter code defined in ISO 2166-1 (alpha-2).
For example: 'US'.

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

### -CertificateSubjectOrganization
The organization field in the subject name.
If present, the allowed limit is 64 characters.

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

### -CertificateSubjectOrganizationUnit
The organization unit field in the subject name.
If present, the allowed limit is 32 characters.

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

### -CertificateThumbprintPrimary
The primary thumbprint used for validation.

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

### -CertificateThumbprintSecondary
The secondary thumbprint used for validation.

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

### -ClientCertificateAuthenticationAllowedThumbprint
The list of thumbprints that are allowed during client authentication.
This property is required only if the validationScheme is 'ThumbprintMatch'.

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

### -ClientCertificateAuthenticationValidationScheme
The validation scheme used to authenticate the client.
Default value is SubjectMatchesAuthenticationName.

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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The client name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded
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
Parameter Sets: UpdateViaIdentityNamespaceExpanded
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
Parameter Sets: UpdateExpanded
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ResourceGroup

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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IEventGridIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.IClient

## NOTES

## RELATED LINKS
