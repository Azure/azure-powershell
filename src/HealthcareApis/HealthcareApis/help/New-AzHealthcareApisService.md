---
external help file:
Module Name: Az.HealthcareApis
online version: https://learn.microsoft.com/powershell/module/az.healthcareapis/new-azhealthcareapisservice
schema: 2.0.0
---

# New-AzHealthcareApisService

## SYNOPSIS
Create or update the metadata of a service instance.

## SYNTAX

```
New-AzHealthcareApisService -Name <String> -ResourceGroupName <String> -CosmosOfferThroughput <Int32>
 -Kind <Kind> -Location <String> [-SubscriptionId <String>]
 [-AccessPolicyObjectId <IServiceAccessPolicyEntry[]>] [-AcrConfigurationLoginServer <String[]>]
 [-AcrConfigurationOciArtifact <IServiceOciArtifactEntry[]>] [-AllowCorsCredential] [-Audience <String>]
 [-Authority <String>] [-CorsHeader <String[]>] [-CorsMaxAge <Int32>] [-CorsMethod <String[]>]
 [-CorsOrigin <String[]>] [-CosmosKeyVaultKeyUri <String>] [-EnableSmartProxy] [-Etag <String>]
 [-ExportStorageAccountName <String>] [-IdentityType <ManagedServiceIdentityType>]
 [-PrivateEndpointConnection <IPrivateEndpointConnection[]>] [-PublicNetworkAccess <PublicNetworkAccess>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update the metadata of a service instance.

## EXAMPLES

### Example 1: Create or update the metadata of a service instance.
```powershell
New-AzHealthcareApisService -ResourceGroupName azps_test_group -Name azpsapiservice -Kind 'fhir' -Location eastus2 -CosmosOfferThroughput 400
```

```output
Location Name           Kind ResourceGroupName
-------- ----           ---- -----------------
eastus2  azpsapiservice fhir azps_test_group
```

Create or update the metadata of a service instance.

## PARAMETERS

### -AccessPolicyObjectId
The access policies of the service instance.
To construct, see NOTES section for ACCESSPOLICYOBJECTID properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IServiceAccessPolicyEntry[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AcrConfigurationLoginServer
The list of the ACR login servers.

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

### -CosmosKeyVaultKeyUri
The URI of the customer-managed key for the backing database.

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

### -CosmosOfferThroughput
The provisioned throughput for the backing database.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
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
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.ManagedServiceIdentityType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Support.Kind
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
The name of the service instance.

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

### -PrivateEndpointConnection
The list of private endpoint connections that are set up for this resource.
To construct, see NOTES section for PRIVATEENDPOINTCONNECTION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api10.IPrivateEndpointConnection[]
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
The resource tags.

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

### Microsoft.Azure.PowerShell.Cmdlets.HealthcareApis.Models.Api20211101.IServicesDescription

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ACCESSPOLICYOBJECTID <IServiceAccessPolicyEntry[]>: The access policies of the service instance.
  - `ObjectId <String>`: a Microsoft Entra object ID (User or Apps) that is allowed access to the FHIR service.

ACRCONFIGURATIONOCIARTIFACT <IServiceOciArtifactEntry[]>: The list of Open Container Initiative (OCI) artifacts.
  - `[Digest <String>]`: The artifact digest.
  - `[ImageName <String>]`: The artifact name.
  - `[LoginServer <String>]`: The Azure Container Registry login server.

PRIVATEENDPOINTCONNECTION <IPrivateEndpointConnection[]>: The list of private endpoint connections that are set up for this resource.
  - `[PrivateLinkServiceConnectionStateActionsRequired <String>]`: A message indicating if changes on the service provider require any updates on the consumer.
  - `[PrivateLinkServiceConnectionStateDescription <String>]`: The reason for approval/rejection of the connection.
  - `[PrivateLinkServiceConnectionStateStatus <PrivateEndpointServiceConnectionStatus?>]`: Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service.

## RELATED LINKS
