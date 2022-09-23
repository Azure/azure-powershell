---
external help file:
Module Name: Az.HealthcareApis
online version: https://docs.microsoft.com/powershell/module/az.healthcareapis/new-azhealthcarefhirservice
schema: 2.0.0
---

# New-AzHealthcareFhirService

## SYNOPSIS
Creates or updates a FHIR Service resource with the specified parameters.

## SYNTAX

```
New-AzHealthcareFhirService -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 -Kind <FhirServiceKind> -Location <String> [-SubscriptionId <String>]
 [-AccessPolicyObjectId <IFhirServiceAccessPolicyEntry[]>] [-AcrConfigurationLoginServer <String[]>]
 [-AcrConfigurationOciArtifact <IServiceOciArtifactEntry[]>] [-AllowCorsCredential] [-Audience <String>]
 [-Authority <String>] [-CorsHeader <String[]>] [-CorsMaxAge <Int32>] [-CorsMethod <String[]>]
 [-CorsOrigin <String[]>] [-EnableSmartProxy] [-Etag <String>] [-ExportStorageAccountName <String>]
 [-IdentityType <ServiceManagedIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-PublicNetworkAccess <PublicNetworkAccess>]
 [-ResourceVersionPolicyConfigurationDefault <FhirResourceVersionPolicy>]
 [-ResourceVersionPolicyConfigurationResourceTypeOverride <Hashtable>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a FHIR Service resource with the specified parameters.

## EXAMPLES

### Example 1: Creates or updates a FHIR Service resource with the specified parameters.
```powershell
New-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Location eastus2 -Kind 'fhir-R4' -Authority "https://login.microsoftonline.com/{DirectoryID}" -Audience "https://azpshcws-{FhirServiceName}.fhir.azurehealthcareapis.com"
```

```output
Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

Creates or updates a FHIR Service resource with the specified parameters.

## PARAMETERS

### -AccessPolicyObjectId
Fhir Service access policies.
To construct, see NOTES section for ACCESSPOLICYOBJECTID properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IFhirServiceAccessPolicyEntry[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AcrConfigurationLoginServer
The list of the Azure container registry login servers.

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

### -AcrConfigurationOciArtifact
The list of Open Container Initiative (OCI) artifacts.
To construct, see NOTES section for ACRCONFIGURATIONOCIARTIFACT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IServiceOciArtifactEntry[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowCorsCredential
If credentials are allowed via CORS.

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

### -Audience
The audience url for the service

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

### -Authority
The authority url for the service

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

### -CorsHeader
The headers to be allowed via CORS.

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

### -CorsMaxAge
The max age to be allowed via CORS.

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

### -CorsMethod
The methods to be allowed via CORS.

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

### -CorsOrigin
The origins to be allowed via CORS.

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

### -EnableSmartProxy
If the SMART on FHIR proxy is enabled

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

### -Etag
An etag associated with the resource, used for optimistic concurrency when editing it.

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

### -ExportStorageAccountName
The name of the default export storage account.

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

### -IdentityType
Type of identity being specified, currently SystemAssigned and None are allowed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.ServiceManagedIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

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

### -Kind
The kind of the service.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.FhirServiceKind
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The resource location.

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

### -Name
The name of FHIR Service resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FhirServiceName

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

### -PublicNetworkAccess
Control permission for data plane traffic coming from public networks while private endpoint is enabled.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.PublicNetworkAccess
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the service instance.

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

### -ResourceVersionPolicyConfigurationDefault
The default value for tracking history across all resources.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.FhirResourceVersionPolicy
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceVersionPolicyConfigurationResourceTypeOverride
A list of FHIR Resources and their version policy overrides.

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

### -SubscriptionId
The subscription identifier.

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
Resource tags.

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

### -WorkspaceName
The name of workspace resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IFhirService

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ACCESSPOLICYOBJECTID <IFhirServiceAccessPolicyEntry[]>: Fhir Service access policies.
  - `ObjectId <String>`: An Azure AD object ID (User or Apps) that is allowed access to the FHIR service.

ACRCONFIGURATIONOCIARTIFACT <IServiceOciArtifactEntry[]>: The list of Open Container Initiative (OCI) artifacts.
  - `[Digest <String>]`: The artifact digest.
  - `[ImageName <String>]`: The artifact name.
  - `[LoginServer <String>]`: The Azure Container Registry login server.

## RELATED LINKS

