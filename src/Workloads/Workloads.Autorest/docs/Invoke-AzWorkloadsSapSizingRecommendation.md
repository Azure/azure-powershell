---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/invoke-azworkloadssapsizingrecommendation
schema: 2.0.0
---

# Invoke-AzWorkloadsSapSizingRecommendation

## SYNOPSIS
Get SAP sizing recommendations by providing input SAPS for application tier and memory required for database tier

## SYNTAX

### SapExpanded (Default)
```
Invoke-AzWorkloadsSapSizingRecommendation -Location <String> -AppLocation <String>
 -DatabaseType <SapDatabaseType> -DbMemory <Int64> -DeploymentType <SapDeploymentType>
 -Environment <SapEnvironmentType> -Sap <Int64> -SapProduct <SapProductType> [-SubscriptionId <String>]
 [-DbScaleMethod <SapDatabaseScaleMethod>] [-HighAvailabilityType <SapHighAvailabilityType>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SapViaIdentityExpanded
```
Invoke-AzWorkloadsSapSizingRecommendation -InputObject <IWorkloadsIdentity> -AppLocation <String>
 -DatabaseType <SapDatabaseType> -DbMemory <Int64> -DeploymentType <SapDeploymentType>
 -Environment <SapEnvironmentType> -Sap <Int64> -SapProduct <SapProductType>
 [-DbScaleMethod <SapDatabaseScaleMethod>] [-HighAvailabilityType <SapHighAvailabilityType>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Get SAP sizing recommendations by providing input SAPS for application tier and memory required for database tier

## EXAMPLES

### Example 1: Get SAP sizing recommendations by providing SAPS for application tier and memory required for database tier
```powershell
Invoke-AzWorkloadsSapSizingRecommendation -Location eastus -AppLocation eastus -DatabaseType HANA -DbMemory 256 -DeploymentType SingleServer -Environment NonProd -SapProduct S4HANA -Sap 10000 -DbScaleMethod ScaleUp
```

```output
DeploymentType VMSku
-------------- -----
SingleServer   Standard_E32ds_v4
```

The command will take input of the Deployment type, region, SAPS number and Database memory size requirement for the SAP system and help you understand the right size and count of Azure SKUs that you should use for the App server instance, Central service instance and Database instance while deploying your SAP system with Azure Center for SAP solutions.

## PARAMETERS

### -AppLocation
The geo-location where the resource is to be created.

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

### -DbMemory
The database memory configuration.

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DbScaleMethod
The DB scale method.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.SapDatabaseScaleMethod
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

### -HighAvailabilityType
The high availability type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.SapHighAvailabilityType
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

### -Sap
The SAP Application Performance Standard measurement.

```yaml
Type: System.Int64
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.Support.SapDeploymentType

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

