---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/update-azwebappcertificate
schema: 2.0.0
---

# Update-AzWebAppCertificate

## SYNOPSIS
Create or update a certificate.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzWebAppCertificate -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 [-HostingEnvironmentProfileId <String>] [-HostName <String[]>] [-KeyVaultId <String>]
 [-KeyVaultSecretName <String>] [-Kind <String>] [-Password <String>] [-PfxBlobInputFile <String>]
 [-ServerFarmId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzWebAppCertificate -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -CertificateEnvelope <ICertificatePatchResource> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzWebAppCertificate -InputObject <IAppServiceIdentity> -CertificateEnvelope <ICertificatePatchResource>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWebAppCertificate -InputObject <IAppServiceIdentity> [-HostingEnvironmentProfileId <String>]
 [-HostName <String[]>] [-KeyVaultId <String>] [-KeyVaultSecretName <String>] [-Kind <String>]
 [-Password <String>] [-PfxBlobInputFile <String>] [-ServerFarmId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a certificate.

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

### -CertificateEnvelope
ARM resource for a certificate.
To construct, see NOTES section for CERTIFICATEENVELOPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ICertificatePatchResource
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -HostingEnvironmentProfileId
Resource ID of the App Service Environment.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -HostName
Host names the certificate applies to.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultId
Key Vault Csm resource Id.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeyVaultSecretName
Key Vault secret name.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the certificate.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Password
Certificate password.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PfxBlobInputFile
Input File for PfxBlob (Pfx blob.)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServerFarmId
Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ICertificatePatchResource

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ICertificate

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CERTIFICATEENVELOPE <ICertificatePatchResource>: ARM resource for a certificate.
  - `Password <String>`: Certificate password.
  - `[Kind <String>]`: Kind of resource.
  - `[HostName <String[]>]`: Host names the certificate applies to.
  - `[HostingEnvironmentProfileId <String>]`: Resource ID of the App Service Environment.
  - `[KeyVaultId <String>]`: Key Vault Csm resource Id.
  - `[KeyVaultSecretName <String>]`: Key Vault secret name.
  - `[PfxBlob <Byte[]>]`: Pfx blob.
  - `[ServerFarmId <String>]`: Resource ID of the associated App Service plan, formatted as: "/subscriptions/{subscriptionID}/resourceGroups/{groupName}/providers/Microsoft.Web/serverfarms/{appServicePlanName}".

#### INPUTOBJECT <IAppServiceIdentity>: Identity Parameter
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

## RELATED LINKS

