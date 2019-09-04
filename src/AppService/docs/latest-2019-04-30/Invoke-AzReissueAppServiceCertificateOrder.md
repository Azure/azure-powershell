---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/invoke-azreissueappservicecertificateorder
schema: 2.0.0
---

# Invoke-AzReissueAppServiceCertificateOrder

## SYNOPSIS
Reissue an existing certificate order.

## SYNTAX

### ReissueExpanded (Default)
```
Invoke-AzReissueAppServiceCertificateOrder -CertificateOrderName <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-Csr <String>] [-DelayExistingRevokeInHour <Int32>] [-IsPrivateKeyExternal]
 [-KeySize <Int32>] [-Kind <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Reissue
```
Invoke-AzReissueAppServiceCertificateOrder -CertificateOrderName <String> -ResourceGroupName <String>
 -SubscriptionId <String> -ReissueCertificateOrderRequest <IReissueCertificateOrderRequest1>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReissueViaIdentity
```
Invoke-AzReissueAppServiceCertificateOrder -InputObject <IAppServiceIdentity>
 -ReissueCertificateOrderRequest <IReissueCertificateOrderRequest1> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReissueViaIdentityExpanded
```
Invoke-AzReissueAppServiceCertificateOrder -InputObject <IAppServiceIdentity> [-Csr <String>]
 [-DelayExistingRevokeInHour <Int32>] [-IsPrivateKeyExternal] [-KeySize <Int32>] [-Kind <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Reissue an existing certificate order.

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

### -CertificateOrderName
Name of the certificate order.

```yaml
Type: System.String
Parameter Sets: Reissue, ReissueExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Csr
Csr to be used for re-key operation.

```yaml
Type: System.String
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
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

### -DelayExistingRevokeInHour
Delay in hours to revoke existing certificate after the new certificate is issued.

```yaml
Type: System.Int32
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
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
Parameter Sets: ReissueViaIdentity, ReissueViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -IsPrivateKeyExternal
Should we change the ASC type (from managed private key to external private key and vice versa).

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -KeySize
Certificate Key Size.

```yaml
Type: System.Int32
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
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
Parameter Sets: ReissueExpanded, ReissueViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ReissueCertificateOrderRequest
Class representing certificate reissue request.
To construct, see NOTES section for REISSUECERTIFICATEORDERREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IReissueCertificateOrderRequest1
Parameter Sets: Reissue, ReissueViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Reissue, ReissueExpanded
Aliases:

Required: True
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
Parameter Sets: Reissue, ReissueExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IReissueCertificateOrderRequest1

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity

## OUTPUTS

### System.Boolean

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

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

#### REISSUECERTIFICATEORDERREQUEST <IReissueCertificateOrderRequest1>: Class representing certificate reissue request.
  - `[Kind <String>]`: Kind of resource.
  - `[Csr <String>]`: Csr to be used for re-key operation.
  - `[DelayExistingRevokeInHour <Int32?>]`: Delay in hours to revoke existing certificate after the new certificate is issued.
  - `[IsPrivateKeyExternal <Boolean?>]`: Should we change the ASC type (from managed private key to external private key and vice versa).
  - `[KeySize <Int32?>]`: Certificate Key Size.

## RELATED LINKS

