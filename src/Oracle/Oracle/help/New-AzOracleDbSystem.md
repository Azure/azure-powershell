---
external help file: Az.Oracle-help.xml
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/new-azoracledbsystem
schema: 2.0.0
---

# New-AzOracleDbSystem

## SYNOPSIS
Create a DbSystem

## SYNTAX

### CreateExpanded (Default)
```
New-AzOracleDbSystem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 [-AdminPassword <SecureString>] [-ClusterName <String>] [-ComputeCount <Int32>] [-ComputeModel <String>]
 [-DatabaseEdition <String>] [-DbSystemOptionStorageManagement <String>] [-DbVersion <String>]
 [-DiskRedundancy <String>] [-DisplayName <String>] [-DomainV2 <String>] [-Hostname <String>]
 [-InitialDataStorageSizeInGb <Int32>] [-LicenseModelV2 <String>] [-NetworkAnchorId <String>]
 [-NodeCount <Int32>] [-PdbName <String>] [-ResourceAnchorId <String>] [-Shape <String>]
 [-SshPublicKey <String[]>] [-StorageVolumePerformanceMode <String>] [-Tag <Hashtable>] [-TimeZone <String>]
 [-Zone <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzOracleDbSystem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzOracleDbSystem -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a DbSystem

## EXAMPLES

### Example 1: Create a DbSystem
```powershell
New-AzOracleDbSystem `
  -ResourceGroupName PowerShellTestRg `
  -Name OFake_PowerShellTestDbSystem `
  -Location eastus2 `
  -Shape VM.Standard3.Flex `
  -AdminPassword (ConvertTo-SecureString 'password' -AsPlainText -Force)
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
SystemDataLastModifiedAt                      : 05/07/2024 13:40:35
SystemDataLastModifiedBy                      : example@oracle.com
SystemDataLastModifiedByType                  : User
TimeCreated                                   : 05/07/2024 13:40:35
```

Creates a DbSystem in the specified resource group and location.
For more information, execute `Get-Help New-AzOracleDbSystem`.

### Example 2: Create a DbSystem with tags
```powershell
New-AzOracleDbSystem `
  -ResourceGroupName PowerShellTestRg `
  -Name OFake_PowerShellTestDbSystem `
  -Location eastus2 `
  -Shape VM.Standard3.Flex `
  -Tag @{ env="test"; owner="example@oracle.com" } `
  -AdminPassword (ConvertTo-SecureString 'password' -AsPlainText -Force)
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
                                                  env=test
                                                  owner=example@oracle.com
                                                }
SystemDataCreatedAt                           : 05/07/2024 13:42:10
SystemDataCreatedBy                           : example@oracle.com
SystemDataCreatedByType                       : User
SystemDataLastModifiedAt                      : 05/07/2024 13:42:10
SystemDataLastModifiedBy                      : example@oracle.com
SystemDataLastModifiedByType                  : User
TimeCreated                                   : 05/07/2024 13:42:10
```

Creates a DbSystem and assigns tags.
For more information, execute `Get-Help New-AzOracleDbSystem`.

## PARAMETERS

### -AdminPassword
A strong password for SYS, SYSTEM, and PDB Admin.
The password must be at least nine characters and contain at least two uppercase, two lowercase, two numbers, and two special characters.
The special characters must be _, #, or -.

```yaml
Type: System.Security.SecureString
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

### -ClusterName
The cluster name for Exadata and 2-node RAC virtual machine DB systems.
The cluster name must begin with an alphabetic character, and may contain hyphens (-).
Underscores (_) are not permitted.
The cluster name can be no longer than 11 characters and is not case sensitive.

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

### -ComputeCount
The number of compute servers for the DB system.

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

### -ComputeModel
The compute model for Base Database Service.
This is required if using the `computeCount` parameter.
If using `cpuCoreCount` then it is an error to specify `computeModel` to a non-null value.
The ECPU compute model is the recommended model, and the OCPU compute model is legacy.

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

### -DatabaseEdition
The Oracle Database Edition that applies to all the databases on the DB system.
Exadata DB systems and 2-node RAC DB systems require EnterpriseEditionExtremePerformance.

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

### -DbSystemOptionStorageManagement
The storage option used in DB system.
ASM - Automatic storage management, LVM - Logical Volume management.

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

### -DbVersion
A valid Oracle Database version.
For a list of supported versions, use the ListDbVersions operation.

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

### -DiskRedundancy
The type of redundancy configured for the DB system.
NORMAL is 2-way redundancy.
HIGH is 3-way redundancy.

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
The user-friendly name for the DB system.
The name does not have to be unique.

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

### -DomainV2
The domain name for the DB system.

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

### -Hostname
The hostname for the DB system.

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

### -InitialDataStorageSizeInGb
Size in GB of the initial data volume that will be created and attached to a virtual machine DB system.
You can scale up storage after provisioning, as needed.
Note that the total storage size attached will be more than the amount you specify to allow for REDO/RECO space and software volume.

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

### -LicenseModelV2
The Oracle license model that applies to all the databases on the DB system.
The default is LicenseIncluded.

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
The name of the DbSystem

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DbSystemName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAnchorId
Azure Network Anchor ID

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

### -NodeCount
The number of nodes in the DB system.
For RAC DB systems, the value is greater than 1.

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

### -PdbName
The name of the pluggable database.
The name must begin with an alphabetic character and can contain a maximum of thirty alphanumeric characters.
Special characters are not permitted.
Pluggable database should not be same as database name.

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

### -ResourceAnchorId
Azure Resource Anchor ID

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

### -Shape
The shape of the DB system.
The shape determines resources to allocate to the DB system.
For virtual machine shapes, the number of CPU cores and memory.
For bare metal and Exadata shapes, the number of CPU cores, storage, and memory.

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

### -SshPublicKey
The public key portion of one or more key pairs used for SSH access to the DB system.

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

### -StorageVolumePerformanceMode
The block storage volume performance level.
Valid values are Balanced and HighPerformance.
See [Block Volume Performance](/Content/Block/Concepts/blockvolumeperformance.htm) for more information.

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
The time zone of the DB system, e.g., UTC, to set the timeZone as UTC.

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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDbSystem

## NOTES

## RELATED LINKS
