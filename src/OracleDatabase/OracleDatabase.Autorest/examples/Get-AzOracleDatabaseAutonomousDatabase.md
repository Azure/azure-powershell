### Example 1: Gets a list of the Autonomous Database resources
```powershell
Get-AzOracleDatabaseAutonomousDatabase
```

```output
Location           Name                       SystemDataCreatedAt SystemDataCreatedBy                      SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType ResourceGroupName
--------           ----                       ------------------- -------------------                      ----------------------- ------------------------ ------------------------             ---------------------------- -----------------
eastus             ADBScli1                   05/07/2024 13:07:02 ramakrishnan.vilathur.sriniva@oracle.com User                    05/07/2024 13:15:49      857ad006-4380-4712-ba4c-22f7c64d84e7 Application                  SDKTestRG
eastus             OFakePowerShellTestAdbs    05/07/2024 13:40:35 jamie.c.cheung@oracle.com                User                    06/07/2024 11:04:13      857ad006-4380-4712-ba4c-22f7c64d84e7 Application                  PowerShellTestRg
germanywestcentral drTestFra                  15/04/2024 16:02:44 gregory.cowart@oracle.com                User                    06/07/2024 11:04:11      857ad006-4380-4712-ba4c-22f7c64d84e7 Application                  FRA
germanywestcentral orppreprodadbs162          16/05/2024 18:33:16 satyam.shankar.prasad@oracle.com         User                    16/05/2024 21:47:24      857ad006-4380-4712-ba4c-22f7c64d84e7 Application                  tstpreprod16
germanywestcentral OFakeSurya                 22/05/2024 18:48:44 surya.prakash.reddy.putluru@oracle.com   User                    22/05/2024 22:16:38      857ad006-4380-4712-ba4c-22f7c64d84e7 Application                  SystemVersions
germanywestcentral OFakeSuryaAdbs             22/05/2024 19:11:28 surya.prakash.reddy.putluru@oracle.com   User                    22/05/2024 22:31:38      857ad006-4380-4712-ba4c-22f7c64d84e7 Application                  SystemVersions
germanywestcentral OFakeAdbs                  23/05/2024 13:02:13 surya.prakash.reddy.putluru@oracle.com   User                    23/05/2024 16:17:52      857ad006-4380-4712-ba4c-22f7c64d84e7 Application                  SystemVersions
germanywestcentral AdbsTest                   23/05/2024 15:57:33 surya.prakash.reddy.putluru@oracle.com   User                    23/05/2024 19:17:53      857ad006-4380-4712-ba4c-22f7c64d84e7 Application                  SystemVersions
```

Gets a list of the Autonomous Database resources

### Example 2: Gets an Autonomous Database resource by name and resource group name
```powershell
Get-AzOracleDatabaseAutonomousDatabase -Name "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg"
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

Gets an Autonomous Database resource by name and resource group name