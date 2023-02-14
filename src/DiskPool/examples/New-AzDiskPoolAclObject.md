### Example 1: Create an acl object
```powershell
<<<<<<< HEAD
New-AzDiskPoolAclObject -InitiatorIqn 'iqn.2021-05.com.microsoft:target0' -MappedLun @('lun0')
```

```output
=======
PS C:\> New-AzDiskPoolAclObject -InitiatorIqn 'iqn.2021-05.com.microsoft:target0' -MappedLun @('lun0')

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
InitiatorIqn                      MappedLun
------------                      ---------
iqn.2021-05.com.microsoft:target0 {lun0}
```

This command creates an acl object.

