---
external help file:
Module Name: Az.HealthcareApis
online version: https://learn.microsoft.com/powershell/module/az.healthcareapis/update-azhealthcarefhirservice
schema: 2.0.0
---

# Update-AzHealthcareFhirService

## SYNOPSIS
Update a FHIR Service resource with the specified parameters.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzHealthcareFhirService -Name <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String>] [-AccessPolicyObjectId <IFhirServiceAccessPolicyEntry[]>]
 [-AcrConfigurationLoginServer <String[]>] [-AcrConfigurationOciArtifact <IServiceOciArtifactEntry[]>]
 [-AllowCorsCredential] [-Audience <String>] [-Authority <String>] [-CorsHeader <String[]>]
 [-CorsMaxAge <Int32>] [-CorsMethod <String[]>] [-CorsOrigin <String[]>] [-EnableSmartProxy]
 [-EnableSystemAssignedIdentity <Boolean?>] [-Etag <String>] [-ExportStorageAccountName <String>]
 [-Kind <String>] [-PublicNetworkAccess <String>] [-ResourceVersionPolicyConfigurationDefault <String>]
 [-ResourceVersionPolicyConfigurationResourceTypeOverride <Hashtable>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzHealthcareFhirService -InputObject <IHealthcareApisIdentity>
 [-AccessPolicyObjectId <IFhirServiceAccessPolicyEntry[]>] [-AcrConfigurationLoginServer <String[]>]
 [-AcrConfigurationOciArtifact <IServiceOciArtifactEntry[]>] [-AllowCorsCredential] [-Audience <String>]
 [-Authority <String>] [-CorsHeader <String[]>] [-CorsMaxAge <Int32>] [-CorsMethod <String[]>]
 [-CorsOrigin <String[]>] [-EnableSmartProxy] [-EnableSystemAssignedIdentity <Boolean?>] [-Etag <String>]
 [-ExportStorageAccountName <String>] [-Kind <String>] [-PublicNetworkAccess <String>]
 [-ResourceVersionPolicyConfigurationDefault <String>]
 [-ResourceVersionPolicyConfigurationResourceTypeOverride <Hashtable>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityWorkspaceExpanded
```
Update-AzHealthcareFhirService -Name <String> -WorkspaceInputObject <IHealthcareApisIdentity>
 [-AccessPolicyObjectId <IFhirServiceAccessPolicyEntry[]>] [-AcrConfigurationLoginServer <String[]>]
 [-AcrConfigurationOciArtifact <IServiceOciArtifactEntry[]>] [-AllowCorsCredential] [-Audience <String>]
 [-Authority <String>] [-CorsHeader <String[]>] [-CorsMaxAge <Int32>] [-CorsMethod <String[]>]
 [-CorsOrigin <String[]>] [-EnableSmartProxy] [-EnableSystemAssignedIdentity <Boolean?>] [-Etag <String>]
 [-ExportStorageAccountName <String>] [-Kind <String>] [-PublicNetworkAccess <String>]
 [-ResourceVersionPolicyConfigurationDefault <String>]
 [-ResourceVersionPolicyConfigurationResourceTypeOverride <Hashtable>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a FHIR Service resource with the specified parameters.

## EXAMPLES

### Example 1: Patch FHIR Service details.
```powershell
Update-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws -Tag @{"123"="abc"}
```

```output
Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

Patch FHIR Service details.

### Example 2: Patch FHIR Service details.
```powershell
Get-AzHealthcareFhirService -Name azpsfhirservice -ResourceGroupName azps_test_group -WorkspaceName azpshcws | Update-AzHealthcareFhirService -Tag @{"123"="abc"}
```

```output
Location Name                     Kind    ResourceGroupName
-------- ----                     ----    -----------------
eastus2  azpshcws/azpsfhirservice fhir-R4 azps_test_group
```

Patch FHIR Service details.

## PARAMETERS

### -AccessPolicyObjectId
Fhir Service access policies.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IFhirServiceAccessPolicyEntry[]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IServiceOciArtifactEntry[]
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

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IHealthcareApisIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
The kind of the service.

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
The name of FHIR Service resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityWorkspaceExpanded
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
The name of the resource group that contains the service instance.

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

### -ResourceVersionPolicyConfigurationDefault
The default value for tracking history across all resources.

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
Parameter Sets: UpdateExpanded
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

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

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

### -WorkspaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IHealthcareApisIdentity
Parameter Sets: UpdateViaIdentityWorkspaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
The name of workspace resource.

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

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IHealthcareApisIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.IFhirService

## NOTES

## RELATED LINKS

