---
external help file: Az.Oracle-help.xml
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/new-azoracleexascaledbstoragevault
schema: 2.0.0
---

# New-AzOracleExascaleDbStorageVault

## SYNOPSIS
Create a ExascaleDbStorageVault

## SYNTAX

### CreateExpanded (Default)
```
New-AzOracleExascaleDbStorageVault -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-AdditionalFlashCacheInPercent <Int32>] [-Description <String>] [-DisplayName <String>]
 [-ExadataInfrastructureId <String>] [-HighCapacityDatabaseStorageInputTotalSizeInGb <Int32>]
 [-Tag <Hashtable>] [-TimeZone <String>] [-Zone <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzOracleExascaleDbStorageVault -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzOracleExascaleDbStorageVault -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a ExascaleDbStorageVault

## EXAMPLES

### Example 1: Create a ExaScaleDb Storage resource
```powershell
$subscriptionId = "00000000-0000-0000-0000-000000000000"
$resourceGroup = "PowerShellTestRg"

$exaScaleDbStorageVaultName = "OFake_PowerShellTestExaScaleDbStorage"
New-AzOracleExascaleDbStorageVault -Name $exaScaleDbStorageVaultName -ResourceGroupName $resourceGroup -Location "eastus" -DisplayName $exaScaleDbStorageVaultName -description "description" -additionalFlashCacheInPercent 100 -TimeZone "UTC"
```

```output
id                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/exascaleDbStorageVaults/OFake_PowerShellTestExaScaleDbStorage
name                        : OFake_PowerShellTestExaScaleDbStorage
type                        : oracle.database/exascaledbstoragevaults
location                    : eastus
zones                       : 3
tags                        : {}
createdBy                   : user
createdByType               : User
createdAt                   : 2025-05-20T22:01:55.819243Z
lastModifiedBy              : 85cb9edf-cccf-4ba9-a0ac-2a3394be2449
lastModifiedByType          : Application
lastModifiedAt              : 2025-05-20T22:04:20.0220552Z
additionalFlashCacheInPercent: 0
description                 : OFake_PowerShellTestExaScaleDbStorage
displayName                 : OFake_PowerShellTestExaScaleDbStorage
highCapacityDatabaseStorage.totalSizeInGbs: 300
highCapacityDatabaseStorageInput.totalSizeInGbs: 300
timeZone                    : UTC
provisioningState           : Succeeded
lifecycleState              : Available
vmClusterCount              : 0
ocid                        : ocid1.exascaledbstoragevault.oc1.iad.anuwcljrboqpjsqajsz5vw4xxtwlbiqdow3xvcerg7hbmkp4s3774xq7xciq
ociUrl                      : https://cloud.oracle.com/dbaas/exadb-xs/exascaleStorageVaults/ocid1.exascaledbstoragevault.oc1.iad.anuwcljrboqpjsqajsz5vw4xxtwlbiqdow3xvcerg7hbmkp4s3774xq7xciq?region=us-ashburn-1&tenant=orpsandbox2&compartmentId=ocid1.compartment.oc1..aaaaaaaasnfbmmlxikpz5p7gneqbqe7yvlzfx6gt2cr2y3xumxjy72gemi6q
```

Create a Oracle Exa ScaleDb Storage Vault resource.
For more information, execute `Get-Help New-AzOracleExascaleDbStorageVault`.

## PARAMETERS

### -AdditionalFlashCacheInPercent
The size of additional Flash Cache in percentage of High Capacity database storage.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
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

### -Description
Exadata Database Storage Vault description.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The user-friendly name for the Exadata Database Storage Vault.
The name does not need to be unique.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExadataInfrastructureId
Cloud Exadata infrastructure ID

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HighCapacityDatabaseStorageInputTotalSizeInGb
Total Capacity

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the ExascaleDbStorageVault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ExascaleDbStorageVaultName

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
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

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
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeZone
The time zone that you want to use for the Exadata Database Storage Vault

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Zone
The availability zones.

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IExascaleDbStorageVault

## NOTES

## RELATED LINKS
