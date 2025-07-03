---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/update-azoracleexascaledbstoragevault
schema: 2.0.0
---

# Update-AzOracleExascaleDbStorageVault

## SYNOPSIS
Update a ExascaleDbStorageVault

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzOracleExascaleDbStorageVault -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzOracleExascaleDbStorageVault -InputObject <IOracleIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzOracleExascaleDbStorageVault -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzOracleExascaleDbStorageVault -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a ExascaleDbStorageVault

## EXAMPLES

### Example 1: Update a Exascale DbStorage Vault resource
```powershell
$tagHashTable = @{'tagName'="tagValue"}
Update-AzOracleExadbVMCluster -Name "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg" -Tag $tagHashTable
```

```output
id                          : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/exascaleDbStorageVaults/OFake_PowerShellTestExaScaleDbStorage
name                        : OFake_PowerShellTestExaScaleDbStorage
type                        : oracle.database/exascaledbstoragevaults
location                    : eastus
zones                       : 3
tags                        : {
                                        "tagName": "tagValue"
                               }
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
For more information, execute `Get-Help Update-AzOracleExascaleDbStorageVault`.

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IExascaleDbStorageVault

## NOTES

## RELATED LINKS

