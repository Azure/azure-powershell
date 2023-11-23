---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/invoke-azworkloadssapdiskconfiguration
schema: 2.0.0
---

# Invoke-AzWorkloadsSapDiskConfiguration

## SYNOPSIS
Get the SAP Disk Configuration Layout prod/non-prod SAP System.

## SYNTAX

### SapExpanded (Default)
```
Invoke-AzWorkloadsSapDiskConfiguration -Location <String> -AppLocation <String>
 -DatabaseType <SapDatabaseType> -DbVMSku <String> -DeploymentType <SapDeploymentType>
 -Environment <SapEnvironmentType> -SapProduct <SapProductType> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SapViaIdentityExpanded
```
Invoke-AzWorkloadsSapDiskConfiguration -InputObject <IWorkloadsIdentity> -AppLocation <String>
 -DatabaseType <SapDatabaseType> -DbVMSku <String> -DeploymentType <SapDeploymentType>
 -Environment <SapEnvironmentType> -SapProduct <SapProductType> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Get the SAP Disk Configuration Layout prod/non-prod SAP System.

## EXAMPLES

### Example 1: Get the SAP Disk Configuration Layout for prod/non-prod SAP System
```powershell
Invoke-AzWorkloadsSapDiskConfiguration -Location eastus -AppLocation eastus -DatabaseType HANA -DbVMSku Standard_M32ts -DeploymentType SingleServer -Environment NonProd -SapProduct S4HANA
```

```output
Keys                 : {hana/data, hana/log, hana/shared, usr/sap...}
Values               : {{
                         "recommendedConfiguration": {
                           "sku": {
                             "name": "Premium_LRS"
                           },
                           "count": 4,
                           "sizeGB": 128
                         },
                         "supportedConfigurations": [
                           {
                             "sku": {
                               "name": "Premium_LRS"
                             },
                             "sizeGB": 128,
                             "minimumSupportedDiskCount": 4,
                             "maximumSupportedDiskCount": 5,
                             "iopsReadWrite": 500,
                             "mbpsReadWrite": 100,
                             "diskTier": "P10"
                           }
                         ]
                       }}
```

This command will help you understand the default disk configuration that will b deployed for the SAP system for a selected deployment type.
You can customize this when you are deploying your SAP system from Azure Center for SAP solutions

## PARAMETERS

### -AppLocation
The geo-location where the SAP resources will be created.

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

### -DatabaseType
The database type.
Eg: HANA, DB2, etc

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.SapDatabaseType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DbVMSku
The VM SKU for database instance.

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

### -DeploymentType
The deployment type.
Eg: SingleServer/ThreeTier

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.SapDeploymentType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Environment
Defines the environment type - Production/Non Production.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.SapEnvironmentType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.IWorkloadsIdentity
Parameter Sets: SapViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of Azure region.

```yaml
Type: System.String
Parameter Sets: SapExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SapProduct
Defines the SAP Product type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.SapProductType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: SapExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.IWorkloadsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Models.Api20230401.ISapDiskConfigurationsResultVolumeConfigurations

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IWorkloadsIdentity>`: Identity Parameter
  - `[ApplicationInstanceName <String>]`: The name of SAP Application Server instance resource.
  - `[CentralInstanceName <String>]`: Central Services Instance resource name string modeled as parameter for auto generation to work correctly.
  - `[DatabaseInstanceName <String>]`: Database resource name string modeled as parameter for auto generation to work correctly.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of Azure region.
  - `[MonitorName <String>]`: Name of the SAP monitor resource.
  - `[ProviderInstanceName <String>]`: Name of the provider instance.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SapVirtualInstanceName <String>]`: The name of the Virtual Instances for SAP solutions resource
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

