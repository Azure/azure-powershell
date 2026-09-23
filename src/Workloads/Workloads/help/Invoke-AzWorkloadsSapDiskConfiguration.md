---
external help file: Az.Workloads-help.xml
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/invoke-azworkloadssapdiskconfiguration
schema: 2.0.0
---

# Invoke-AzWorkloadsSapDiskConfiguration

## SYNOPSIS
Get the SAP Disk Configuration Layout prod/non-prod SAP System.

## SYNTAX

### InvokeExpanded (Default)
```
Invoke-AzWorkloadsSapDiskConfiguration -Location <String> [-SubscriptionId <String>] -AppLocation <String>
 -DatabaseType <String> -DbVMSku <String> -DeploymentType <String> -Environment <String> -SapProduct <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeViaJsonString
```
Invoke-AzWorkloadsSapDiskConfiguration -Location <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeViaJsonFilePath
```
Invoke-AzWorkloadsSapDiskConfiguration -Location <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Invoke
```
Invoke-AzWorkloadsSapDiskConfiguration -Location <String> [-SubscriptionId <String>]
 -Body <ISapDiskConfigurationsRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeViaIdentityExpanded
```
Invoke-AzWorkloadsSapDiskConfiguration -InputObject <ISapVirtualInstanceIdentity> -AppLocation <String>
 -DatabaseType <String> -DbVMSku <String> -DeploymentType <String> -Environment <String> -SapProduct <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InvokeViaIdentity
```
Invoke-AzWorkloadsSapDiskConfiguration -InputObject <ISapVirtualInstanceIdentity>
 -Body <ISapDiskConfigurationsRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
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
Parameter Sets: InvokeExpanded, InvokeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
The SAP request to get list of disk configurations.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapDiskConfigurationsRequest
Parameter Sets: Invoke, InvokeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DatabaseType
The database type.
Eg: HANA, DB2, etc

```yaml
Type: System.String
Parameter Sets: InvokeExpanded, InvokeViaIdentityExpanded
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
Parameter Sets: InvokeExpanded, InvokeViaIdentityExpanded
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
Type: System.String
Parameter Sets: InvokeExpanded, InvokeViaIdentityExpanded
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
Type: System.String
Parameter Sets: InvokeExpanded, InvokeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity
Parameter Sets: InvokeViaIdentityExpanded, InvokeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Invoke operation

```yaml
Type: System.String
Parameter Sets: InvokeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Invoke operation

```yaml
Type: System.String
Parameter Sets: InvokeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

```yaml
Type: System.String
Parameter Sets: InvokeExpanded, InvokeViaJsonString, InvokeViaJsonFilePath, Invoke
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
Type: System.String
Parameter Sets: InvokeExpanded, InvokeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: InvokeExpanded, InvokeViaJsonString, InvokeViaJsonFilePath, Invoke
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapDiskConfigurationsRequest

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapDiskConfigurationsResult

## NOTES

ALIASES

Invoke-AzVISDiskConfiguration

## RELATED LINKS
