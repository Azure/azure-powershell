---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/az.oracledatabase/new-azoracledatabaseautonomousdatabase
schema: 2.0.0
---

# New-AzOracleDatabaseAutonomousDatabase

## SYNOPSIS
Create a AutonomousDatabase

## SYNTAX

### CreateExpanded (Default)
```
New-AzOracleDatabaseAutonomousDatabase -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-AdminPassword <SecureString>] [-AutonomousDatabaseId <String>]
 [-AutonomousMaintenanceScheduleType <String>] [-BackupRetentionPeriodInDay <Int32>] [-CharacterSet <String>]
 [-ComputeCount <Single>] [-ComputeModel <String>] [-CpuCoreCount <Int32>]
 [-CustomerContact <ICustomerContact[]>] [-DatabaseEdition <String>] [-DataBaseType <String>]
 [-DataStorageSizeInGb <Int32>] [-DataStorageSizeInTb <Int32>] [-DayOfWeekName <String>] [-DbVersion <String>]
 [-DbWorkload <String>] [-DisplayName <String>] [-IsAutoScalingEnabled] [-IsAutoScalingForStorageEnabled]
 [-IsLocalDataGuardEnabled] [-IsMtlsConnectionRequired] [-IsPreviewVersionWithServiceTermsAccepted]
 [-LicenseModel <String>] [-NcharacterSet <String>] [-PrivateEndpointIP <String>]
 [-PrivateEndpointLabel <String>] [-ScheduledOperationScheduledStartTime <String>]
 [-ScheduledOperationScheduledStopTime <String>] [-SubnetId <String>] [-Tag <Hashtable>] [-VnetId <String>]
 [-WhitelistedIP <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Create
```
New-AzOracleDatabaseAutonomousDatabase -Name <String> -ResourceGroupName <String>
 -Resource <IAutonomousDatabase> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzOracleDatabaseAutonomousDatabase -InputObject <IOracleDatabaseIdentity> -Resource <IAutonomousDatabase>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzOracleDatabaseAutonomousDatabase -InputObject <IOracleDatabaseIdentity> -Location <String>
 [-AdminPassword <SecureString>] [-AutonomousDatabaseId <String>]
 [-AutonomousMaintenanceScheduleType <String>] [-BackupRetentionPeriodInDay <Int32>] [-CharacterSet <String>]
 [-ComputeCount <Single>] [-ComputeModel <String>] [-CpuCoreCount <Int32>]
 [-CustomerContact <ICustomerContact[]>] [-DatabaseEdition <String>] [-DataBaseType <String>]
 [-DataStorageSizeInGb <Int32>] [-DataStorageSizeInTb <Int32>] [-DayOfWeekName <String>] [-DbVersion <String>]
 [-DbWorkload <String>] [-DisplayName <String>] [-IsAutoScalingEnabled] [-IsAutoScalingForStorageEnabled]
 [-IsLocalDataGuardEnabled] [-IsMtlsConnectionRequired] [-IsPreviewVersionWithServiceTermsAccepted]
 [-LicenseModel <String>] [-NcharacterSet <String>] [-PrivateEndpointIP <String>]
 [-PrivateEndpointLabel <String>] [-ScheduledOperationScheduledStartTime <String>]
 [-ScheduledOperationScheduledStopTime <String>] [-SubnetId <String>] [-Tag <Hashtable>] [-VnetId <String>]
 [-WhitelistedIP <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzOracleDatabaseAutonomousDatabase -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzOracleDatabaseAutonomousDatabase -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Create a AutonomousDatabase

## EXAMPLES

### Example 1: Creates an Autonomous Database resource
```powershell
$subscriptionId = "dcb0912a-9b6f-46e3-a11b-5296913d89b5"
$resourceGroup = "PowerShellTestRg"

$vnetName = "PSTestVnet"
$vnetId = "/subscriptions/$($subscriptionId)/resourceGroups/$($resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($vnetName)"

$subnetName = "delegated"
$subnetId = "/subscriptions/$($subscriptionId)/resourceGroups/$($resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($vnetName)/subnets/$($subnetName)"

[SecureString]$adbsAdminPassword = ConvertTo-SecureString -String "PowerShellTestPass123" -AsPlainText -Force

$adbsName = "OFakePowerShellTestAdbs"
New-AzOracleDatabaseAutonomousDatabase -Name $adbsName -ResourceGroupName $resourceGroup -Location "eastus" -DisplayName $adbsName -DbWorkload "OLTP" -ComputeCount 2.0 -ComputeModel "ECPU" -DbVersion "19c" -DataStorageSizeInGb 32 -AdminPassword $adbsAdminPassword -LicenseModel "BringYourOwnLicense" -SubnetId $subnetId -VnetId $vnetId -DataBaseType "Regular" -CharacterSet "AL32UTF8" -NcharacterSet "AL16UTF16"
```

```output
ActualUsedDataStorageSizeInTb                 : 0.00343003869056702
AdminPassword                                 : 
AllConnectionStringHigh                       : 
AllConnectionStringLow                        : 
AllConnectionStringMedium                     : 
AllocatedStorageSizeInTb                      : 0.0087890625
ApexDetailApexVersion                         : 
ApexDetailOrdsVersion                         : 
AutonomousDatabaseId                          : 
AutonomousMaintenanceScheduleType             : Regular
AvailableUpgradeVersion                       : 
BackupRetentionPeriodInDay                    : 60
CharacterSet                                  : AL32UTF8
ComputeCount                                  : 2
ComputeModel                                  : ECPU
ConnectionStringDedicated                     : 
ConnectionStringHigh                          : adb.us-ashburn-1.oraclecloud.com:1522/g65795d1a5ce1e9_ofakepowershelltestadbs_high.adb.oraclecloud.com
ConnectionStringLow                           : adb.us-ashburn-1.oraclecloud.com:1522/g65795d1a5ce1e9_ofakepowershelltestadbs_low.adb.oraclecloud.com
ConnectionStringMedium                        : adb.us-ashburn-1.oraclecloud.com:1522/g65795d1a5ce1e9_ofakepowershelltestadbs_medium.adb.oraclecloud.com
ConnectionStringProfile                       : {{
                                                  "consumerGroup": "High",
                                                  "displayName": "ofakepowershelltestadbs_high",
                                                  "hostFormat": "Fqdn",
                                                  "protocol": "TCPS",
                                                  "sessionMode": "Direct",
                                                  "syntaxFormat": "Long",
                                                  "tlsAuthentication": "Server",
                                                  "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1521)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.com))(c
                                                onnect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_high.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                }, {
                                                  "consumerGroup": "Low",
                                                  "displayName": "ofakepowershelltestadbs_low",
                                                  "hostFormat": "Fqdn",
                                                  "protocol": "TCPS",
                                                  "sessionMode": "Direct",
                                                  "syntaxFormat": "Long",
                                                  "tlsAuthentication": "Server",
                                                  "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1521)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.com))(c
                                                onnect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_low.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                }, {
                                                  "consumerGroup": "Medium",
                                                  "displayName": "ofakepowershelltestadbs_medium",
                                                  "hostFormat": "Fqdn",
                                                  "protocol": "TCPS",
                                                  "sessionMode": "Direct",
                                                  "syntaxFormat": "Long",
                                                  "tlsAuthentication": "Server",
                                                  "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1521)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.com))(c
                                                onnect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_medium.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                }, {
                                                  "consumerGroup": "Tp",
                                                  "displayName": "ofakepowershelltestadbs_tp",
                                                  "hostFormat": "Fqdn",
                                                  "protocol": "TCPS",
                                                  "sessionMode": "Direct",
                                                  "syntaxFormat": "Long",
                                                  "tlsAuthentication": "Server",
                                                  "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1521)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.com))(c
                                                onnect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_tp.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                }…}
ConnectionUrlApexUrl                          : https://byui3zo3.adb.us-ashburn-1.oraclecloudapps.com/ords/apex
ConnectionUrlDatabaseTransformsUrl            : https://byui3zo3.adb.us-ashburn-1.oraclecloudapps.com/odi/
ConnectionUrlGraphStudioUrl                   : https://byui3zo3.adb.us-ashburn-1.oraclecloudapps.com/graphstudio/
ConnectionUrlMachineLearningNotebookUrl       : https://byui3zo3.adb.us-ashburn-1.oraclecloudapps.com/oml/
ConnectionUrlMongoDbUrl                       : 
ConnectionUrlOrdsUrl                          : https://byui3zo3.adb.us-ashburn-1.oraclecloudapps.com/ords/
ConnectionUrlSqlDevWebUrl                     : https://byui3zo3.adb.us-ashburn-1.oraclecloudapps.com/ords/sql-developer
CpuCoreCount                                  : 
CustomerContact                               : 
DataBaseType                                  : Regular
DataSafeStatus                                : 
DataStorageSizeInGb                           : 32
DataStorageSizeInTb                           : 
DatabaseEdition                               : EnterpriseEdition
DayOfWeekName                                 : 
DbVersion                                     : 19c
DbWorkload                                    : OLTP
DisplayName                                   : OFakePowerShellTestAdbs
FailedDataRecoveryInSecond                    : 
Id                                            : /subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/resourceGroups/PowerShellTestRg/providers/Oracle.Database/autonomousDatabases/OFakePowerShe
                                                llTestAdbs
InMemoryAreaInGb                              : 
IsAutoScalingEnabled                          : False
IsAutoScalingForStorageEnabled                : False
IsLocalDataGuardEnabled                       : False
IsMtlsConnectionRequired                      : False
IsPreview                                     : 
IsPreviewVersionWithServiceTermsAccepted      : 
IsRemoteDataGuardEnabled                      : False
LicenseModel                                  : BringYourOwnLicense
LifecycleDetail                               : 
LifecycleState                                : Available
LocalAdgAutoFailoverMaxDataLossLimit          : 
LocalDisasterRecoveryType                     : BackupBased
LocalStandbyDbLagTimeInSecond                 : 
LocalStandbyDbLifecycleDetail                 : 
LocalStandbyDbLifecycleState                  : Standby
LocalStandbyDbTimeDataGuardRoleChanged        : 
LocalStandbyDbTimeDisasterRecoveryRoleChanged : 
Location                                      : eastus
LongTermBackupScheduleIsDisabled              : 
LongTermBackupScheduleRepeatCadence           : 
LongTermBackupScheduleRetentionPeriodInDay    : 
LongTermBackupScheduleTimeOfBackup            : 
MemoryPerOracleComputeUnitInGb                : 
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
                                                  "localStandbyDb": {
                                                    "lifecycleState": "Standby"
                                                  },
                                                  "connectionStrings": {
                                                    "high": "adb.us-ashburn-1.oraclecloud.com:1522/g65795d1a5ce1e9_ofakepowershelltestadbs_high.adb.oraclecloud.com",
                                                    "low": "adb.us-ashburn-1.oraclecloud.com:1522/g65795d1a5ce1e9_ofakepowershelltestadbs_low.adb.oraclecloud.com",
                                                    "medium": "adb.us-ashburn-1.oraclecloud.com:1522/g65795d1a5ce1e9_ofakepowershelltestadbs_medium.adb.oraclecloud.com",
                                                    "profiles": [
                                                      {
                                                        "consumerGroup": "High",
                                                        "displayName": "ofakepowershelltestadbs_high",
                                                        "hostFormat": "Fqdn",
                                                        "protocol": "TCPS",
                                                        "sessionMode": "Direct",
                                                        "syntaxFormat": "Long",
                                                        "tlsAuthentication": "Server",
                                                        "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1521)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.c
                                                om))(connect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_high.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                      },
                                                      {
                                                        "consumerGroup": "Low",
                                                        "displayName": "ofakepowershelltestadbs_low",
                                                        "hostFormat": "Fqdn",
                                                        "protocol": "TCPS",
                                                        "sessionMode": "Direct",
                                                        "syntaxFormat": "Long",
                                                        "tlsAuthentication": "Server",
                                                        "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1521)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.c
                                                om))(connect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_low.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                      },
                                                      {
                                                        "consumerGroup": "Medium",
                                                        "displayName": "ofakepowershelltestadbs_medium",
                                                        "hostFormat": "Fqdn",
                                                        "protocol": "TCPS",
                                                        "sessionMode": "Direct",
                                                        "syntaxFormat": "Long",
                                                        "tlsAuthentication": "Server",
                                                        "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1521)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.c
                                                om))(connect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_medium.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                      },
                                                      {
                                                        "consumerGroup": "Tp",
                                                        "displayName": "ofakepowershelltestadbs_tp",
                                                        "hostFormat": "Fqdn",
                                                        "protocol": "TCPS",
                                                        "sessionMode": "Direct",
                                                        "syntaxFormat": "Long",
                                                        "tlsAuthentication": "Server",
                                                        "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1521)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.c
                                                om))(connect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_tp.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                      },
                                                      {
                                                        "consumerGroup": "Tpurgent",
                                                        "displayName": "ofakepowershelltestadbs_tpurgent",
                                                        "hostFormat": "Fqdn",
                                                        "protocol": "TCPS",
                                                        "sessionMode": "Direct",
                                                        "syntaxFormat": "Long",
                                                        "tlsAuthentication": "Server",
                                                        "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1521)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.c
                                                om))(connect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_tpurgent.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                      },
                                                      {
                                                        "consumerGroup": "High",
                                                        "displayName": "ofakepowershelltestadbs_high",
                                                        "hostFormat": "Fqdn",
                                                        "protocol": "TCPS",
                                                        "sessionMode": "Direct",
                                                        "syntaxFormat": "Long",
                                                        "tlsAuthentication": "Mutual",
                                                        "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1522)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.c
                                                om))(connect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_high.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                      },
                                                      {
                                                        "consumerGroup": "Low",
                                                        "displayName": "ofakepowershelltestadbs_low",
                                                        "hostFormat": "Fqdn",
                                                        "protocol": "TCPS",
                                                        "sessionMode": "Direct",
                                                        "syntaxFormat": "Long",
                                                        "tlsAuthentication": "Mutual",
                                                        "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1522)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.c
                                                om))(connect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_low.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                      },
                                                      {
                                                        "consumerGroup": "Medium",
                                                        "displayName": "ofakepowershelltestadbs_medium",
                                                        "hostFormat": "Fqdn",
                                                        "protocol": "TCPS",
                                                        "sessionMode": "Direct",
                                                        "syntaxFormat": "Long",
                                                        "tlsAuthentication": "Mutual",
                                                        "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1522)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.c
                                                om))(connect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_medium.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                      },
                                                      {
                                                        "consumerGroup": "Tp",
                                                        "displayName": "ofakepowershelltestadbs_tp",
                                                        "hostFormat": "Fqdn",
                                                        "protocol": "TCPS",
                                                        "sessionMode": "Direct",
                                                        "syntaxFormat": "Long",
                                                        "tlsAuthentication": "Mutual",
                                                        "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1522)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.c
                                                om))(connect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_tp.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                      },
                                                      {
                                                        "consumerGroup": "Tpurgent",
                                                        "displayName": "ofakepowershelltestadbs_tpurgent",
                                                        "hostFormat": "Fqdn",
                                                        "protocol": "TCPS",
                                                        "sessionMode": "Direct",
                                                        "syntaxFormat": "Long",
                                                        "tlsAuthentication": "Mutual",
                                                        "value": "(description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1522)(host=byui3zo3.adb.us-ashburn-1.oraclecloud.c
                                                om))(connect_data=(service_name=g65795d1a5ce1e9_ofakepowershelltestadbs_tpurgent.adb.oraclecloud.com))(security=(ssl_server_dn_match=no)))"
                                                      }
                                                    ]
                                                  },
                                                  "connectionUrls": {
                                                    "apexUrl": "https://byui3zo3.adb.us-ashburn-1.oraclecloudapps.com/ords/apex",
                                                    "databaseTransformsUrl": "https://byui3zo3.adb.us-ashburn-1.oraclecloudapps.com/odi/",
                                                    "graphStudioUrl": "https://byui3zo3.adb.us-ashburn-1.oraclecloudapps.com/graphstudio/",
                                                    "machineLearningNotebookUrl": "https://byui3zo3.adb.us-ashburn-1.oraclecloudapps.com/oml/",
                                                    "ordsUrl": "https://byui3zo3.adb.us-ashburn-1.oraclecloudapps.com/ords/",
                                                    "sqlDevWebUrl": "https://byui3zo3.adb.us-ashburn-1.oraclecloudapps.com/ords/sql-developer"
                                                  },
                                                  "autonomousMaintenanceScheduleType": "Regular",
                                                  "characterSet": "AL32UTF8",
                                                  "computeCount": 2,
                                                  "computeModel": "ECPU",
                                                  "dataStorageSizeInGbs": 32,
                                                  "dbVersion": "19c",
                                                  "dbWorkload": "OLTP",
                                                  "displayName": "OFakePowerShellTestAdbs",
                                                  "isAutoScalingEnabled": false,
                                                  "isAutoScalingForStorageEnabled": false,
                                                  "isLocalDataGuardEnabled": false,
                                                  "isRemoteDataGuardEnabled": false,
                                                  "localDisasterRecoveryType": "BackupBased",
                                                  "isMtlsConnectionRequired": false,
                                                  "licenseModel": "BringYourOwnLicense",
                                                  "ncharacterSet": "AL16UTF16",
                                                  "provisioningState": "Succeeded",
                                                  "lifecycleState": "Available",
                                                  "privateEndpointIp": "10.0.1.51",
                                                  "privateEndpointLabel": "byui3zo3",
                                                  "ociUrl": "https://cloud.oracle.com/db/adbs/ocid1.autonomousdatabase.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuuwov4vm626yj46caifxh4le5uoxa?reg
                                                ion=us-ashburn-1\u0026tenant=orpsandbox3\u0026compartmentId=ocid1.compartment.oc1..aaaaaaaazcet2jt2uowjtgxsae5uositfy2thngqgokwdifyzmyygdpckeua
                                                ",
                                                  "subnetId": "/subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/
                                                PSTestVnet/subnets/delegated",
                                                  "vnetId": 
                                                "/subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet",
                                                  "timeCreated": "2024-07-05T13:44:18.2090000Z",
                                                  "timeMaintenanceBegin": "2024-07-07T09:00:00.0000000Z",
                                                  "timeMaintenanceEnd": "2024-07-07T11:00:00.0000000Z",
                                                  "actualUsedDataStorageSizeInTbs": 0.0034300386905670166,
                                                  "allocatedStorageSizeInTbs": 0.0087890625,
                                                  "databaseEdition": "EnterpriseEdition",
                                                  "openMode": "ReadWrite",
                                                  "privateEndpoint": "byui3zo3.adb.us-ashburn-1.oraclecloud.com",
                                                  "timeLocalDataGuardEnabled": "Fri Jul 05 13:44:40 UTC 2024",
                                                  "ocid": "ocid1.autonomousdatabase.oc1.iad.anuwcljtnirvylqa7vzcwywunyc2mjnuuwov4vm626yj46caifxh4le5uoxa",
                                                  "backupRetentionPeriodInDays": 60
                                                }
ProvisionableCpu                              : 
ProvisioningState                             : Succeeded
ResourceGroupName                             : PowerShellTestRg
Role                                          : 
ScheduledOperationScheduledStartTime          : 
ScheduledOperationScheduledStopTime           : 
ServiceConsoleUrl                             : 
SqlWebDeveloperUrl                            : 
SubnetId                                      : /subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet/subn
                                                ets/delegated
SupportedRegionsToCloneTo                     : 
SystemDataCreatedAt                           : 05/07/2024 13:40:35
SystemDataCreatedBy                           : jamie.c.cheung@oracle.com
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
VnetId                                        : /subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet
WhitelistedIP                                 : 
```

Creates an Autonomous Database resource.
For more information, execute `Get-Help New-AzOracleDatabaseAutonomousDatabase`

## PARAMETERS

### -AdminPassword
Admin password.

```yaml
Type: System.Security.SecureString
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -AutonomousDatabaseId
Autonomous Database ID

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutonomousMaintenanceScheduleType
The maintenance schedule type of the Autonomous Database Serverless.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BackupRetentionPeriodInDay
Retention period, in days, for long-term backups

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CharacterSet
The character set for the autonomous database.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeCount
The compute amount (CPUs) available to the database.

```yaml
Type: System.Single
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ComputeModel
The compute model of the Autonomous Database.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CpuCoreCount
The number of CPU cores to be made available to the database.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomerContact
Customer Contacts.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.ICustomerContact[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseEdition
The Oracle Database Edition that applies to the Autonomous databases.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataBaseType
Database type to be created.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataStorageSizeInGb
The size, in gigabytes, of the data volume that will be created and attached to the database.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DataStorageSizeInTb
The quantity of data in the database, in terabytes.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DayOfWeekName
Name of the day of the week.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DbVersion
A valid Oracle Database version for Autonomous Database.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DbWorkload
The Autonomous Database workload type

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -DisplayName
The user-friendly name for the Autonomous Database.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsAutoScalingEnabled
Indicates if auto scaling is enabled for the Autonomous Database CPU core count.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsAutoScalingForStorageEnabled
Indicates if auto scaling is enabled for the Autonomous Database storage.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsLocalDataGuardEnabled
Indicates whether the Autonomous Database has local or called in-region Data Guard enabled.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsMtlsConnectionRequired
Specifies if the Autonomous Database requires mTLS connections.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IsPreviewVersionWithServiceTermsAccepted
Specifies if the Autonomous Database preview version is being provisioned.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -LicenseModel
The Oracle license model that applies to the Oracle Autonomous Database.
The default is LICENSE_INCLUDED.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The database name.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases: Autonomousdatabasename

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NcharacterSet
The character set for the Autonomous Database.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### -PrivateEndpointIP
The private endpoint Ip address for the resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateEndpointLabel
The resource's private endpoint label.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
Autonomous Database resource model.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IAutonomousDatabase
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduledOperationScheduledStartTime
auto start time.
value must be of ISO-8601 format HH:mm

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduledOperationScheduledStopTime
auto stop time.
value must be of ISO-8601 format HH:mm

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
Client subnet

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: Create, CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VnetId
VNET for network connectivity

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhitelistedIP
The client IP access control list (ACL).
This is an array of CIDR notations and/or IP addresses.
Values should be separate strings, separated by commas.
Example: ['1.1.1.1','1.1.1.0/24','1.1.2.25']

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IAutonomousDatabase

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IAutonomousDatabase

## NOTES

## RELATED LINKS

