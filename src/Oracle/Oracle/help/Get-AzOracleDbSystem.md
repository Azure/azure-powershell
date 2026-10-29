---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/get-azoracledbsystem
schema: 2.0.0
---

# Get-AzOracleDbSystem

## SYNOPSIS
Get a DbSystem

## SYNTAX

### List (Default)
```
Get-AzOracleDbSystem [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOracleDbSystem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDbSystem -InputObject <IOracleIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzOracleDbSystem -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a DbSystem

## EXAMPLES

### Example 1: Get a list of the DbSystem resources
```powershell
Get-AzOracleDbSystem
```

```output
...
Name                                          : OFake_PowerShellTestDbSystem
Id                                            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/dbSystems/OFake_PowerShellTestDbSystem
Type                                          : oracle.database/dbsystems
Location                                      : eastus2
ResourceGroupName                             : PowerShellTestRg
OciUrl                                        : https://cloud.oracle.com/dbaas/dbsystems/ocid1.dbsystem.oc1.iad.aaaaaaaexample?region=us-ashbur
                                                n-1&tenant=orpsandbox3&compartmentId=ocid1.compartment.oc1..aaaaaaaazcet2jt2uowjtgxsae5uositfy2thngqgokwdifyzmyygdpckeua
Ocid                                          : ocid1.dbsystem.oc1.iad.aaaaaaaexample
Shape                                         : VM.Standard3.Flex
CpuCoreCount                                  : 4
DataStorageSizeInGb                           : 256
SubnetId                                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet/subn
                                                ets/delegated
ProvisioningState                             : Succeeded
Hostname                                      : psdbs01
Tag                                           : {
                                                }
SystemDataCreatedAt                           : 05/07/2024 13:40:35
SystemDataCreatedBy                           : example@oracle.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 06/07/2024 09:19:26
SystemDataLastModifiedBy                      : 857ad006-4380-4712-ba4c-22f7c64d84e7
SystemDataLastModifiedByType                  : Application
TimeCreated                                   : 05/07/2024 13:44:18
```

Get a DbSystem resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleDbSystem`.

### Example 2: Get a DbSystem by name and resource group name
```powershell
Get-AzOracleDbSystem -ResourceGroupName PowerShellTestRg -Name OFake_PowerShellTestDbSystem
```

```output
Name                                          : OFake_PowerShellTestDbSystem
Id                                            : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/dbSystems/OFake_PowerShellTestDbSystem
Type                                          : oracle.database/dbsystems
Location                                      : eastus2
ResourceGroupName                             : PowerShellTestRg
OciUrl                                        : https://cloud.oracle.com/dbaas/dbsystems/ocid1.dbsystem.oc1.iad.aaaaaaaexample?region=us-ashbur
                                                n-1&tenant=orpsandbox3&compartmentId=ocid1.compartment.oc1..aaaaaaaazcet2jt2uowjtgxsae5uositfy2thngqgokwdifyzmyygdpckeua
Ocid                                          : ocid1.dbsystem.oc1.iad.aaaaaaaexample
Shape                                         : VM.Standard3.Flex
CpuCoreCount                                  : 4
DataStorageSizeInGb                           : 256
SubnetId                                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet/subn
                                                ets/delegated
ProvisioningState                             : Succeeded
Hostname                                      : psdbs01
Tag                                           : {
                                                }
SystemDataCreatedAt                           : 05/07/2024 13:40:35
SystemDataCreatedBy                           : example@oracle.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 06/07/2024 09:19:26
SystemDataLastModifiedBy                      : 857ad006-4380-4712-ba4c-22f7c64d84e7
SystemDataLastModifiedByType                  : Application
TimeCreated                                   : 05/07/2024 13:44:18
```

Gets a specific DbSystem resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleDbSystem`.

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
The name of the DbSystem

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DbSystemName

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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDbSystem

## NOTES

## RELATED LINKS

