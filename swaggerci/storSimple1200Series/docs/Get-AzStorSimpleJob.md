---
external help file:
Module Name: Az.StorSimple
online version: https://docs.microsoft.com/en-us/powershell/module/az.storsimple/get-azstorsimplejob
schema: 2.0.0
---

# Get-AzStorSimpleJob

## SYNOPSIS
Returns the properties of the specified job name.

## SYNTAX

### List1 (Default)
```
Get-AzStorSimpleJob -ManagerName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStorSimpleJob -DeviceName <String> -ManagerName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStorSimpleJob -InputObject <IStorSimpleIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzStorSimpleJob -DeviceName <String> -ManagerName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns the properties of the specified job name.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -DeviceName
The device name.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
OData Filter options

```yaml
Type: System.String
Parameter Sets: List, List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Models.IStorSimpleIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagerName
The manager name

```yaml
Type: System.String
Parameter Sets: Get, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The job name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: JobName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name

```yaml
Type: System.String
Parameter Sets: Get, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription id

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

### Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Models.IStorSimpleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Models.Api20161001.IJob

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IStorSimpleIdentity>: Identity Parameter
  - `[AccessControlRecordName <String>]`: Name of access control record to be fetched.
  - `[BackupName <String>]`: The backup name.
  - `[CertificateName <String>]`: Certificate Name
  - `[ChapUserName <String>]`: The user name of chap to be fetched.
  - `[CredentialName <String>]`: The name of storage account credential to be fetched.
  - `[DeviceName <String>]`: The device name.
  - `[DiskName <String>]`: The disk name.
  - `[ElementName <String>]`: The backup element name.
  - `[FileServerName <String>]`: The file server name.
  - `[Id <String>]`: Resource identity path
  - `[IscsiServerName <String>]`: The iSCSI server name.
  - `[JobName <String>]`: The job name.
  - `[ManagerName <String>]`: The manager name
  - `[ResourceGroupName <String>]`: The resource group name
  - `[ScheduleGroupName <String>]`: The name of the schedule group.
  - `[ShareName <String>]`: The file share name.
  - `[StorageDomainName <String>]`: The storage domain name.
  - `[SubscriptionId <String>]`: The subscription id

## RELATED LINKS

