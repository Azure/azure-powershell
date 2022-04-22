---
external help file:
Module Name: Az.Arc
online version: https://docs.microsoft.com/en-us/powershell/module/az.arc/update-azarcdatacontroller
schema: 2.0.0
---

# Update-AzArcDataController

## SYNOPSIS
Updates a dataController resource

## SYNTAX

### PatchExpanded (Default)
```
Update-AzArcDataController -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BasicLoginInformationPassword <String>] [-BasicLoginInformationUsername <String>] [-ClusterId <String>]
 [-ExtensionId <String>] [-Infrastructure <Infrastructure>] [-K8SRaw <IAny>] [-LastUploadedDate <DateTime>]
 [-LogAnalyticWorkspaceConfigPrimaryKey <String>] [-LogAnalyticWorkspaceConfigWorkspaceId <String>]
 [-LogDashboardCredentialPassword <String>] [-LogDashboardCredentialUsername <String>]
 [-MetricDashboardCredentialPassword <String>] [-MetricDashboardCredentialUsername <String>]
 [-OnPremisePropertyId <String>] [-OnPremisePropertyPublicSigningKey <String>]
 [-OnPremisePropertySigningCertificateThumbprint <String>] [-Tag <Hashtable>]
 [-UploadServicePrincipalAuthority <String>] [-UploadServicePrincipalClientId <String>]
 [-UploadServicePrincipalClientSecret <String>] [-UploadServicePrincipalTenantId <String>]
 [-UploadWatermarkLog <DateTime>] [-UploadWatermarkMetric <DateTime>] [-UploadWatermarkUsage <DateTime>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Patch
```
Update-AzArcDataController -Name <String> -ResourceGroupName <String>
 -DataControllerResource <IDataControllerUpdate> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentity
```
Update-AzArcDataController -InputObject <IArcIdentity> -DataControllerResource <IDataControllerUpdate>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### PatchViaIdentityExpanded
```
Update-AzArcDataController -InputObject <IArcIdentity> [-BasicLoginInformationPassword <String>]
 [-BasicLoginInformationUsername <String>] [-ClusterId <String>] [-ExtensionId <String>]
 [-Infrastructure <Infrastructure>] [-K8SRaw <IAny>] [-LastUploadedDate <DateTime>]
 [-LogAnalyticWorkspaceConfigPrimaryKey <String>] [-LogAnalyticWorkspaceConfigWorkspaceId <String>]
 [-LogDashboardCredentialPassword <String>] [-LogDashboardCredentialUsername <String>]
 [-MetricDashboardCredentialPassword <String>] [-MetricDashboardCredentialUsername <String>]
 [-OnPremisePropertyId <String>] [-OnPremisePropertyPublicSigningKey <String>]
 [-OnPremisePropertySigningCertificateThumbprint <String>] [-Tag <Hashtable>]
 [-UploadServicePrincipalAuthority <String>] [-UploadServicePrincipalClientId <String>]
 [-UploadServicePrincipalClientSecret <String>] [-UploadServicePrincipalTenantId <String>]
 [-UploadWatermarkLog <DateTime>] [-UploadWatermarkMetric <DateTime>] [-UploadWatermarkUsage <DateTime>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a dataController resource

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -BasicLoginInformationPassword
Login password.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BasicLoginInformationUsername
Login username.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterId
If a CustomLocation is provided, this contains the ARM id of the connected cluster the custom location belongs to.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataControllerResource
Used for updating a data controller resource.
To construct, see NOTES section for DATACONTROLLERRESOURCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20220301Preview.IDataControllerUpdate
Parameter Sets: Patch, PatchViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ExtensionId
If a CustomLocation is provided, this contains the ARM id of the extension the custom location belongs to.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Infrastructure
The infrastructure the data controller is running on.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Support.Infrastructure
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.IArcIdentity
Parameter Sets: PatchViaIdentity, PatchViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -K8SRaw
The raw kubernetes information

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.IAny
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastUploadedDate
Last uploaded date from Kubernetes cluster.
Defaults to current date time

```yaml
Type: System.DateTime
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogAnalyticWorkspaceConfigPrimaryKey
Primary key of the workspace

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogAnalyticWorkspaceConfigWorkspaceId
Azure Log Analytics workspace ID

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogDashboardCredentialPassword
Login password.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LogDashboardCredentialUsername
Login username.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricDashboardCredentialPassword
Login password.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MetricDashboardCredentialUsername
Login username.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the data controller

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases: DataControllerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OnPremisePropertyId
A globally unique ID identifying the associated Kubernetes cluster

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OnPremisePropertyPublicSigningKey
Certificate that contains the Kubernetes cluster public key used to verify signing

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OnPremisePropertySigningCertificateThumbprint
Unique thumbprint returned to customer to verify the certificate being uploaded

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -ResourceGroupName
The name of the Azure resource group

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the Azure subscription

```yaml
Type: System.String
Parameter Sets: Patch, PatchExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UploadServicePrincipalAuthority
Authority for the service principal.
Example: https://login.microsoftonline.com/

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UploadServicePrincipalClientId
Client ID of the service principal for uploading data.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UploadServicePrincipalClientSecret
Secret of the service principal

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UploadServicePrincipalTenantId
Tenant ID of the service principal.

```yaml
Type: System.String
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UploadWatermarkLog
Last uploaded date for logs from kubernetes cluster.
Defaults to current date time

```yaml
Type: System.DateTime
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UploadWatermarkMetric
Last uploaded date for metrics from kubernetes cluster.
Defaults to current date time

```yaml
Type: System.DateTime
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UploadWatermarkUsage
Last uploaded date for usages from kubernetes cluster.
Defaults to current date time

```yaml
Type: System.DateTime
Parameter Sets: PatchExpanded, PatchViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20220301Preview.IDataControllerUpdate

### Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.IArcIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20220301Preview.IDataControllerResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DATACONTROLLERRESOURCE <IDataControllerUpdate>: Used for updating a data controller resource.
  - `[BasicLoginInformationPassword <String>]`: Login password.
  - `[BasicLoginInformationUsername <String>]`: Login username.
  - `[ClusterId <String>]`: If a CustomLocation is provided, this contains the ARM id of the connected cluster the custom location belongs to.
  - `[ExtensionId <String>]`: If a CustomLocation is provided, this contains the ARM id of the extension the custom location belongs to.
  - `[Infrastructure <Infrastructure?>]`: The infrastructure the data controller is running on.
  - `[K8SRaw <IAny>]`: The raw kubernetes information
  - `[LastUploadedDate <DateTime?>]`: Last uploaded date from Kubernetes cluster. Defaults to current date time
  - `[LogAnalyticWorkspaceConfigPrimaryKey <String>]`: Primary key of the workspace
  - `[LogAnalyticWorkspaceConfigWorkspaceId <String>]`: Azure Log Analytics workspace ID
  - `[LogDashboardCredentialPassword <String>]`: Login password.
  - `[LogDashboardCredentialUsername <String>]`: Login username.
  - `[MetricDashboardCredentialPassword <String>]`: Login password.
  - `[MetricDashboardCredentialUsername <String>]`: Login username.
  - `[OnPremisePropertyId <String>]`: A globally unique ID identifying the associated Kubernetes cluster
  - `[OnPremisePropertyPublicSigningKey <String>]`: Certificate that contains the Kubernetes cluster public key used to verify signing
  - `[OnPremisePropertySigningCertificateThumbprint <String>]`: Unique thumbprint returned to customer to verify the certificate being uploaded
  - `[Tag <IDataControllerUpdateTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[UploadServicePrincipalAuthority <String>]`: Authority for the service principal. Example: https://login.microsoftonline.com/
  - `[UploadServicePrincipalClientId <String>]`: Client ID of the service principal for uploading data.
  - `[UploadServicePrincipalClientSecret <String>]`: Secret of the service principal
  - `[UploadServicePrincipalTenantId <String>]`: Tenant ID of the service principal.
  - `[UploadWatermarkLog <DateTime?>]`: Last uploaded date for logs from kubernetes cluster. Defaults to current date time
  - `[UploadWatermarkMetric <DateTime?>]`: Last uploaded date for metrics from kubernetes cluster. Defaults to current date time
  - `[UploadWatermarkUsage <DateTime?>]`: Last uploaded date for usages from kubernetes cluster. Defaults to current date time

INPUTOBJECT <IArcIdentity>: Identity Parameter
  - `[ActiveDirectoryConnectorName <String>]`: The name of the Active Directory connector instance
  - `[DataControllerName <String>]`: The name of the data controller
  - `[Id <String>]`: Resource identity path
  - `[PostgresInstanceName <String>]`: Name of Postgres Instance
  - `[ResourceGroupName <String>]`: The name of the Azure resource group
  - `[SqlManagedInstanceName <String>]`: Name of SQL Managed Instance
  - `[SqlServerInstanceName <String>]`: Name of SQL Server Instance
  - `[SubscriptionId <String>]`: The ID of the Azure subscription

## RELATED LINKS

