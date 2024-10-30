---
external help file: Az.Workloads-help.xml
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/invoke-azworkloadssapsupportedsku
schema: 2.0.0
---

# Invoke-AzWorkloadsSapSupportedSku

## SYNOPSIS
Get a list of SAP supported SKUs for ASCS, Application and Database tier.

## SYNTAX

### SapExpanded (Default)
```
Invoke-AzWorkloadsSapSupportedSku -Location <String> [-SubscriptionId <String>] -AppLocation <String>
 -DatabaseType <SapDatabaseType> -DeploymentType <SapDeploymentType> -Environment <SapEnvironmentType>
 -SapProduct <SapProductType> [-HighAvailabilityType <SapHighAvailabilityType>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SapViaIdentityExpanded
```
Invoke-AzWorkloadsSapSupportedSku -InputObject <ISapVirtualInstanceIdentity> -AppLocation <String>
 -DatabaseType <SapDatabaseType> -DeploymentType <SapDeploymentType> -Environment <SapEnvironmentType>
 -SapProduct <SapProductType> [-HighAvailabilityType <SapHighAvailabilityType>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Get a list of SAP supported SKUs for ASCS, Application and Database tier.

## EXAMPLES

### Example 1: Get SAP sizing recommendations by providing input SAPS for application tier and memory required for database tier
```powershell
Invoke-AzWorkloadsSapSupportedSku -Location eastus -AppLocation eastus -DatabaseType HANA -DeploymentType ThreeTier -Environment Prod -SapProduct S4HANA
```

```output
IsAppServerCertified IsDatabaseCertified VMSku
-------------------- ------------------- -----
True                 False               Standard_D16ds_v4
True                 False               Standard_D16ds_v5
True                 False               Standard_D32ds_v4
True                 False               Standard_D32ds_v5
True                 False               Standard_D48ds_v4
True                 False               Standard_D48ds_v5
```

This command helps you understand the list of SAP certified Azure SKUs supported for the SAP deployment type you want to deploy and for the region in which you want to deploy the SAP system with Azure Center for SAP solutions

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
Eg: HANA, DB2, etc

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Support.SapDatabaseType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Support.SapDeploymentType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Support.SapEnvironmentType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Support.SapHighAvailabilityType
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Support.SapProductType
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.Api20231001Preview.ISapSupportedSku

## NOTES

ALIASES

Invoke-AzVISSupportedSku

## RELATED LINKS
