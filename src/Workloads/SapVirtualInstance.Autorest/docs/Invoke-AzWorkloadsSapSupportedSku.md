---
external help file:
Module Name: Az.Workloads
online version: https://learn.microsoft.com/powershell/module/az.workloads/invoke-azworkloadssapsupportedsku
schema: 2.0.0
---

# Invoke-AzWorkloadsSapSupportedSku

## SYNOPSIS
Get a list of SAP supported SKUs for ASCS, Application and Database tier.

## SYNTAX

### InvokeExpanded (Default)
```
Invoke-AzWorkloadsSapSupportedSku -Location <String> -AppLocation <String> -DatabaseType <String>
 -DeploymentType <String> -Environment <String> -SapProduct <String> [-SubscriptionId <String>]
 [-HighAvailabilityType <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Invoke
```
Invoke-AzWorkloadsSapSupportedSku -Location <String> -Body <ISapSupportedSkusRequest>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaIdentity
```
Invoke-AzWorkloadsSapSupportedSku -InputObject <ISapVirtualInstanceIdentity> -Body <ISapSupportedSkusRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaIdentityExpanded
```
Invoke-AzWorkloadsSapSupportedSku -InputObject <ISapVirtualInstanceIdentity> -AppLocation <String>
 -DatabaseType <String> -DeploymentType <String> -Environment <String> -SapProduct <String>
 [-HighAvailabilityType <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaJsonFilePath
```
Invoke-AzWorkloadsSapSupportedSku -Location <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### InvokeViaJsonString
```
Invoke-AzWorkloadsSapSupportedSku -Location <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
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
Parameter Sets: InvokeExpanded, InvokeViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
The SAP request to get list of supported SKUs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapSupportedSkusRequest
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

### -HighAvailabilityType
The high availability type.

```yaml
Type: System.String
Parameter Sets: InvokeExpanded, InvokeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity
Parameter Sets: InvokeViaIdentity, InvokeViaIdentityExpanded
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
Parameter Sets: Invoke, InvokeExpanded, InvokeViaJsonFilePath, InvokeViaJsonString
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
Parameter Sets: Invoke, InvokeExpanded, InvokeViaJsonFilePath, InvokeViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapSupportedSkusRequest

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapVirtualInstanceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Workloads.SapVirtualInstance.Models.ISapSupportedResourceSkusResult

## NOTES

ALIASES

Invoke-AzVISSupportedSku

## RELATED LINKS

