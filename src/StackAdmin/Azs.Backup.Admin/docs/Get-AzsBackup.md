---
external help file:
Module Name: Azs.Backup.Admin
online version: https://docs.microsoft.com/en-us/powershell/module/azs.backup.admin/get-azsbackup
schema: 2.0.0
---

# Get-AzsBackup

## SYNOPSIS
Returns a backup from a location based on name.

## SYNTAX

### List (Default)
```
Get-AzsBackup [-Location <String>] [-ResourceGroupName <String>] [-SubscriptionId <String[]>] [-Skip <String>]
 [-Top <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzsBackup -Name <String> [-Location <String>] [-ResourceGroupName <String>] [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzsBackup -InputObject <IBackupAdminIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns a backup from a location based on name.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzsBackup

```

Get information sbout all Azure Stack backups.

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzsBackup -Name 'backupName'

```

Get information for the the specified Azure Stack backup.

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
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.IBackupAdminIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Location
Name of the backup location.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzLocation)[0].Name
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the backup.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: "system.$((Get-AzLocation)[0].Name)"
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Skip
OData skip parameter.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials that uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Top
OData top parameter.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.IBackupAdminIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.BackupAdmin.Models.Api20180901.IBackup

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IBackupAdminIdentity>: Identity Parameter
  - `[Backup <String>]`: Name of the backup.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: Name of the backup location.
  - `[ResourceGroupName <String>]`: Name of the resource group.
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

