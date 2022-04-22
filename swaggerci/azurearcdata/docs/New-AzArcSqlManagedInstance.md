---
external help file:
Module Name: Az.Arc
online version: https://docs.microsoft.com/en-us/powershell/module/az.arc/new-azarcsqlmanagedinstance
schema: 2.0.0
---

# New-AzArcSqlManagedInstance

## SYNOPSIS
Creates or replaces a SQL Managed Instance resource

## SYNTAX

```
New-AzArcSqlManagedInstance -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-Admin <String>] [-BasicLoginInformationPassword <String>]
 [-BasicLoginInformationUsername <String>] [-ClusterId <String>] [-DataControllerId <String>]
 [-EndTime <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <ExtendedLocationTypes>]
 [-ExtensionId <String>] [-K8SRaw <ISqlManagedInstanceK8SRaw>] [-KeytabInformationKeytab <String>]
 [-LastUploadedDate <DateTime>] [-LicenseType <ArcSqlManagedInstanceLicenseType>] [-SkuCapacity <Int32>]
 [-SkuDev] [-SkuFamily <String>] [-SkuSize <String>] [-SkuTier <SqlManagedInstanceSkuTier>]
 [-StartTime <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or replaces a SQL Managed Instance resource

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

### -Admin
The instance admin user

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

### -BasicLoginInformationPassword
Login password.

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

### -BasicLoginInformationUsername
Login username.

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

### -ClusterId
If a CustomLocation is provided, this contains the ARM id of the connected cluster the custom location belongs to.

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

### -DataControllerId
null

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

### -EndTime
The instance end time

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

### -ExtendedLocationName
The name of the extended location.

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

### -ExtendedLocationType
The type of the extended location.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Support.ExtendedLocationTypes
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -K8SRaw
The raw kubernetes information
To construct, see NOTES section for K8SRAW properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20220301Preview.ISqlManagedInstanceK8SRaw
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeytabInformationKeytab
A base64-encoded keytab.

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

### -LastUploadedDate
Last uploaded date from Kubernetes cluster.
Defaults to current date time

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LicenseType
The license type to apply for this managed instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Support.ArcSqlManagedInstanceLicenseType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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
Name of SQL Managed Instance

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: SqlManagedInstanceName

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
The name of the Azure resource group

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

### -SkuCapacity
The SKU capacity

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

### -SkuDev
Whether dev/test is enabled.
When the dev field is set to true, the resource is used for dev/test purpose.

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

### -SkuFamily
The SKU family

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

### -SkuSize
The SKU size.
When the name field is the combination of tier and some other value, this would be the standalone code.

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
The pricing tier for the instance.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Arc.Support.SqlManagedInstanceSkuTier
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartTime
The instance start time

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
The ID of the Azure subscription

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

### Microsoft.Azure.PowerShell.Cmdlets.Arc.Models.Api20220301Preview.ISqlManagedInstance

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


K8SRAW <ISqlManagedInstanceK8SRaw>: The raw kubernetes information
  - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[Spec <ISqlManagedInstanceK8SSpec>]`: The kubernetes spec information.
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
    - `[Replica <Int32?>]`: This option specifies the number of SQL Managed Instance replicas that will be deployed in your Kubernetes cluster for high availability purposes. If sku.tier is BusinessCritical, allowed values are '2' or '3' with default of '3'. If sku.tier is GeneralPurpose, replicas must be '1'.
    - `[Scheduling <IK8SScheduling>]`: The kubernetes scheduling information.
      - `[(Any) <Object>]`: This indicates any property can be added to this object.
      - `[Default <IK8SSchedulingOptions>]`: The kubernetes scheduling options. It describes restrictions used to help Kubernetes select appropriate nodes to host the database service
        - `[(Any) <Object>]`: This indicates any property can be added to this object.
        - `[Resource <IK8SResourceRequirements>]`: The kubernetes resource limits and requests used to restrict or reserve resource usage.
          - `[(Any) <Object>]`: This indicates any property can be added to this object.
          - `[Limit <IK8SResourceRequirementsLimits>]`: Limits for a kubernetes resource type (e.g 'cpu', 'memory'). The 'cpu' request must be less than or equal to 'cpu' limit. Default 'cpu' is 2, minimum is 1. Default 'memory' is '4Gi', minimum is '2Gi. If sku.tier is GeneralPurpose, maximum 'cpu' is 24 and maximum 'memory' is '128Gi'.
            - `[(Any) <String>]`: This indicates any property can be added to this object.
          - `[Request <IK8SResourceRequirementsRequests>]`: Requests for a kubernetes resource type (e.g 'cpu', 'memory'). The 'cpu' request must be less than or equal to 'cpu' limit. Default 'cpu' is 2, minimum is 1. Default 'memory' is '4Gi', minimum is '2Gi. If sku.tier is GeneralPurpose, maximum 'cpu' is 24 and maximum 'memory' is '128Gi'.
            - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

