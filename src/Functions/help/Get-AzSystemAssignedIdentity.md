---
external help file:
Module Name: Az.Functions
online version: https://docs.microsoft.com/en-us/powershell/module/az.functions/get-azsystemassignedidentity
schema: 2.0.0
---

# Get-AzSystemAssignedIdentity

## SYNOPSIS
Gets the systemAssignedIdentity available under the specified RP scope.

## SYNTAX

### Get (Default)
```
Get-AzSystemAssignedIdentity -Scope <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSystemAssignedIdentity -InputObject <IFunctionsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the systemAssignedIdentity available under the specified RP scope.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Scope
The resource provider scope of the resource.
Parent resource being extended by Managed Identities.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.IFunctionsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Functions.Models.Api20181130.ISystemAssignedIdentity

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IFunctionsIdentity>: Identity Parameter
  - `[AccountName <String>]`: The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
  - `[AnalysisName <String>]`: Analysis Name
  - `[AppSettingKey <String>]`: App Setting key name.
  - `[Authprovider <String>]`: The auth provider for the users.
  - `[BackupId <String>]`: ID of the backup.
  - `[BaseAddress <String>]`: Module base address.
  - `[BlobServicesName <String>]`: The name of the blob Service within the specified storage account. Blob Service Name must be 'default'
  - `[CertificateOrderName <String>]`: Name of the certificate order..
  - `[ContainerName <String>]`: The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
  - `[DeletedSiteId <String>]`: The numeric ID of the deleted app, e.g. 12345
  - `[DetectorName <String>]`: Detector Resource Name
  - `[DiagnosticCategory <String>]`: Diagnostic Category
  - `[DiagnosticsName <String>]`: Name of the diagnostics item.
  - `[DomainName <String>]`: Name of the domain.
  - `[DomainOwnershipIdentifierName <String>]`: Name of domain ownership identifier.
  - `[EntityName <String>]`: Name of the hybrid connection.
  - `[FunctionName <String>]`: Function name.
  - `[GatewayName <String>]`: Name of the gateway. Currently, the only supported string is "primary".
  - `[HostName <String>]`: Hostname in the hostname binding.
  - `[HostingEnvironmentName <String>]`: Name of the hosting environment.
  - `[Id <String>]`: Deployment ID.
  - `[Id1 <String>]`: Resource identity path
  - `[ImmutabilityPolicyName <String>]`: The name of the blob container immutabilityPolicy within the specified storage account. ImmutabilityPolicy Name must be 'default'
  - `[Instance <String>]`: Name of the instance in the multi-role pool.
  - `[InstanceId <String>]`: 
  - `[KeyId <String>]`: The API Key ID. This is unique within a Application Insights component.
  - `[KeyName <String>]`: The name of the key.
  - `[KeyType <String>]`: The type of host key.
  - `[Location <String>]`: 
  - `[ManagementPolicyName <ManagementPolicyName?>]`: The name of the Storage Account Management Policy. It should always be 'default'
  - `[Name <String>]`: Name of the certificate.
  - `[NamespaceName <String>]`: The namespace for this hybrid connection.
  - `[OperationId <String>]`: GUID of the operation.
  - `[PrId <String>]`: The stage site identifier.
  - `[PremierAddOnName <String>]`: Add-on name.
  - `[PrivateEndpointConnectionName <String>]`: 
  - `[ProcessId <String>]`: PID.
  - `[PublicCertificateName <String>]`: Public certificate name.
  - `[PurgeId <String>]`: In a purge status request, this is the Id of the operation the status of which is returned.
  - `[RelayName <String>]`: The relay name for this hybrid connection.
  - `[ResourceGroupName <String>]`: Name of the resource group to which the resource belongs.
  - `[ResourceName <String>]`: The name of the Application Insights component resource.
  - `[RouteName <String>]`: Name of the Virtual Network route.
  - `[Scope <String>]`: The resource provider scope of the resource. Parent resource being extended by Managed Identities.
  - `[SiteExtensionId <String>]`: Site extension name.
  - `[SiteName <String>]`: Site Name
  - `[Slot <String>]`: Slot Name
  - `[SnapshotId <String>]`: The ID of the snapshot to read.
  - `[SourceControlType <String>]`: Type of source control
  - `[SubscriptionId <String>]`: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[Userid <String>]`: The user id of the user.
  - `[View <String>]`: The type of view. This can either be "summary" or "detailed".
  - `[VnetName <String>]`: Name of the virtual network.
  - `[WebJobName <String>]`: Name of Web Job.
  - `[WorkerName <String>]`: Name of worker machine, which typically starts with RD.
  - `[WorkerPoolName <String>]`: Name of the worker pool.

## RELATED LINKS

