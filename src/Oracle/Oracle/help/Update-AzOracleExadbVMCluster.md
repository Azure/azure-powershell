---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/update-azoracleexadbvmcluster
schema: 2.0.0
---

# Update-AzOracleExadbVMCluster

## SYNOPSIS
Update a ExadbVmCluster

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzOracleExadbVMCluster -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-NodeCount <Int32>] [-Tag <Hashtable>] [-Zone <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzOracleExadbVMCluster -InputObject <IOracleIdentity> [-NodeCount <Int32>] [-Tag <Hashtable>]
 [-Zone <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzOracleExadbVMCluster -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzOracleExadbVMCluster -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Update a ExadbVmCluster

## EXAMPLES

### Example 1: Update a Exadb VM Cluster resource
```powershell
$tagHashTable = @{'tagName'="tagValue"}
Update-AzOracleExadbVMCluster -Name "OFake_PowerShellTestVmCluster" -ResourceGroupName "PowerShellTestRg" -Tag $tagHashTable
```

```output
name                       : OFake_PowerShellTestExadbVmCluster
type                       : oracle.database/exadbvmclusters
location                   : eastus
zones                      : 3
Tag                        : {
                                    "tagName": "tagValue"
                             }
clusterName                : OFake_PowerShellTestExadbVmCluster
nsgUrl                     : https://cloud.oracle.com/networking/vcns/ocid1.vcn.oc1.iad.amaaaaaaboqpjsqa6goluo2oze7brbcturrhjp4dbiqynybygcaowysqh4vq/network-security-groups/ocid1.networksecuritygroup.oc1.iad.aaaaaaaapab43hogjh77qaduxsbbormuyoxrnpzydaueyeqhhnipykd3obxa?region=us-ashburn-1
provisioningState          : Succeeded
lifecycleState             : Available
vnetId                     : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet
subnetId                   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Microsoft.Network/virtualNetworks/PSTestVnet/sub
displayName                : OFake_PowerShellTestExadbVmCluster
domain                     : ocidelegated.ocivnettestexa.oraclevcn.com
enabledEcpuCount           : 16
exascaleDbStorageVaultId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/providers/Oracle.Database/exascaleDbStorageVaults/OFake_PowerShellTestExaScaleStorage
gridImageOcid              : ocid1.dbpatch.oc1.iad.anuwcljrt5t4sqqarmom7cvfg5oy47ccceplnqx6qugb7vyfdfjrrp7rz4nq
gridImageType              : ReleaseUpdate
giVersion                  : 23.8.0.25.04
hostname                   : theo
licenseModel               : LicenseIncluded
memorySizeInGbs            : 44
nodeCount                  : 2
scanListenerPortTcp        : 1521
scanListenerPortTcpSsl     : 2484
listenerPort               : 1521
shape                      : EXADBXS
sshPublicKeys              : ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABgQD2uOXC283JO8ig2dd2oxGie0KzgtDs/z1V2JHQXYRs3pRzr3WESSEvQgANhYBFC5BkxDQQvURTGRYkaLirs0OdxnuUNm2TZHB0T+u5UK4nKC0mUCWL++sbI+VYP+dzovJRa8e61xDMboheuqolxeJf6kyfIiJA3GJeYtQKSig0+DOfCrEFjp1hiqfr0eUxDItLn5BoG3d5IVG0DE4Z5gy9dtjG6AkJE6Gh+n3WxQbJu8/gkJYVmcjlFGyw9Wd3FTQ/4EocBwW9RXoTCfyqmidxwDeq34i9L1yYcnTDjFWwQ3xfaKuWeRugucl2ogjFVbU8Op/ODhs1h8eZLg/qezl3B4iI3De1FXWVhEuuNsbntuRgZZ2JFvsIgzBTUKLKTsibxbSWiMIIbIDmPuswkZvy70yukv7t/hTaX+cIxo4kgGVFET4HjOqqdWm7fiDX6rAcoRSYOp29CWYFcFkKZQ4rwD51JkOKUA4xNtQHFrWuaEjjxqfEdPuI0hjWyW6IJ40= generated-by-azure
systemVersion              : 19.2.12.0.0.200317
timeZone                   : UTC
totalEcpuCount             : 16
vmFileSystemStorage        : totalSizeInGbs: 560
scanDnsName                : fakeScanDnsName
scanIpIds                  :
scanDnsRecordId            : ocid1.vcndnsrecord.oc1.iad.anuwcljrhnge2iqaycryvslv72somguxmjxgd3fxbk5tzwoksiekg4dguljq
snapshotFileSystemStorage  : totalSizeInGbs: 0
totalFileSystemStorage     : totalSizeInGbs: 560
vipIds                     :
zoneOcid                   : ocid1.dns-zone.oc1.iad.aaaaaaaafla3b2uh67e4qxqcsl4mzoqh4nckbb243lvvy2ukgqpxubn5trra
```

Create a ExaDb VM Cluster resource.
For more information, execute `Get-Help Update-AzOracleExaDbVMCluster`.

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
The name of the ExadbVmCluster

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: ExadbVMClusterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NodeCount
The number of nodes in the Exadata VM cluster on Exascale Infrastructure.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -Zone
The availability zones.

```yaml
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IExadbVMCluster

## NOTES

## RELATED LINKS

