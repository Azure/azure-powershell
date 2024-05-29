---
external help file: Az.DiskPool-help.xml
Module Name: Az.DiskPool
online version: https://learn.microsoft.com/powershell/module/Az.DiskPool/new-AzDiskPoolAclObject
schema: 2.0.0
---

# New-AzDiskPoolAclObject

## SYNOPSIS
Create an in-memory object for Acl.

## SYNTAX

```
New-AzDiskPoolAclObject -InitiatorIqn <String> -MappedLun <String[]>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Acl.

## EXAMPLES

### Example 1: Create an acl object
```powershell
New-AzDiskPoolAclObject -InitiatorIqn 'iqn.2021-05.com.microsoft:target0' -MappedLun @('lun0')
```

```output
InitiatorIqn                      MappedLun
------------                      ---------
iqn.2021-05.com.microsoft:target0 {lun0}
```

This command creates an acl object.

## PARAMETERS

### -InitiatorIqn
iSCSI initiator IQN (iSCSI Qualified Name); example: "iqn.2005-03.org.iscsi:client".

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

### -MappedLun
List of LUN names mapped to the ACL.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DiskPool.Models.Api20210801.Acl

## NOTES

## RELATED LINKS
