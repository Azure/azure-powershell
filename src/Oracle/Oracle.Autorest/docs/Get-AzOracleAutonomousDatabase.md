---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/get-azoracleautonomousdatabase
schema: 2.0.0
---

# Get-AzOracleAutonomousDatabase

## SYNOPSIS
Get a AutonomousDatabase

## SYNTAX

### List (Default)
```
Get-AzOracleAutonomousDatabase [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzOracleAutonomousDatabase -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleAutonomousDatabase -InputObject <IOracleIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzOracleAutonomousDatabase -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a AutonomousDatabase

## EXAMPLES

### Example 1: Get a list of the Autonomous Database resources
```powershell
Get-AzOracleAutonomousDatabase
```

```output
...
Name                                          : OFakePowerShellTestAdbs
NcharacterSet                                 : AL16UTF16
NextLongTermBackupTimeStamp                   : 
OciUrl                                        : https://cloud.oracle.com/db/adbs/ocid1.autonomousdatabase.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuuwov4vm626yj46caifxh4le5uoxa?region=us-ashbur
                                                n-1&tenant=orpsandbox3&compartmentId=ocid1.compartment.oc1..aaaaaaaazcet2jt2uowjtgxsae5uositfy2thngqgokwdifyzmyygdpckeua
Ocid                                          : ocid1.autonomousdatabase.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuuwov4vm626yj46caifxh4le5uoxa
OpenMode                                      : ReadWrite
OperationsInsightsStatus                      : 
PeerDbId                                      : 
PeerDbIds                                     : 
PermissionLevel                               : 
PrivateEndpoint                               : byui3zo3.adb.us-ashburn-1.oraclecloud.com
PrivateEndpointIP                             : 10.0.1.51
PrivateEndpointLabel                          : byui3zo3
Property                                      : {
                                                  ...
                                                }
ProvisionableCpu                              : 
ProvisioningState                             : Succeeded
ResourceGroupName                             : PowerShellTestRg
Role                                          : 
ScheduledOperationScheduledStartTime          : 
ScheduledOperationScheduledStopTime           : 
ServiceConsoleUrl                             : 
SqlWebDeveloperUrl                            : 
SubnetId                                      : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet/subn
                                                ets/delegated
SupportedRegionsToCloneTo                     : 
SystemDataCreatedAt                           : 05/07/2024 13:40:35
SystemDataCreatedBy                           : example@oracle.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 06/07/2024 09:19:26
SystemDataLastModifiedBy                      : 857ad006-4380-4712-ba4c-22f7c64d84e7
SystemDataLastModifiedByType                  : Application
Tag                                           : {
                                                }
TimeCreated                                   : 05/07/2024 13:44:18
TimeDataGuardRoleChanged                      : 
TimeDeletionOfFreeAutonomousDatabase          : 
TimeLocalDataGuardEnabled                     : Fri Jul 05 13:44:40 UTC 2024
TimeMaintenanceBegin                          : 07/07/2024 09:00:00
TimeMaintenanceEnd                            : 07/07/2024 11:00:00
TimeOfLastFailover                            : 
TimeOfLastRefresh                             : 
TimeOfLastRefreshPoint                        : 
TimeOfLastSwitchover                          : 
TimeReclamationOfFreeAutonomousDatabase       : 
Type                                          : oracle.database/autonomousdatabases
UsedDataStorageSizeInGb                       : 
UsedDataStorageSizeInTb                       : 
VnetId                                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet
WhitelistedIP                                 : 
```

Get an Autonomous Database resource by name and resource group name.
For more information, execute `Get-Help Get-AzOracleAutonomousDatabase`.

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
The database name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: Autonomousdatabasename

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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IAutonomousDatabase

## NOTES

## RELATED LINKS

