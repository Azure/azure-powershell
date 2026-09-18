---
external help file: Az.Oracle-help.xml
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/get-azoracleexascaledbstoragevault
schema: 2.0.0
---

# Get-AzOracleExascaleDbStorageVault

## SYNOPSIS
Get a ExascaleDbStorageVault

## SYNTAX

### List (Default)
```
Get-AzOracleExascaleDbStorageVault [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzOracleExascaleDbStorageVault -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzOracleExascaleDbStorageVault -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleExascaleDbStorageVault -InputObject <IOracleIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a ExascaleDbStorageVault

## EXAMPLES

### Example 1: Get a list of the ExascaleDb Storage Vault resources
```powershell
Get-AzOracleCloudVMCluster
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

Get a Oracle Exa ScaleDb Storage Vault resource.
For more information, execute `Get-Help Get-AzOracleExascaleDbStorageVault`.

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the ExascaleDbStorageVault

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ExascaleDbStorageVaultName

Required: True
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
Parameter Sets: Get, List1
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
Type: System.String[]
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IExascaleDbStorageVault

## NOTES

## RELATED LINKS
