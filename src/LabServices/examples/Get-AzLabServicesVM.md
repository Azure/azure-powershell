### Example 1: Gets all the Virtual machines in the lab.
```powershell
<<<<<<< HEAD
Get-AzLabServicesVM -LabName "Lab Name" -ResourceGroupName "Group Name"
```

```output
=======
PS C:\> Get-AzLabServicesVM -LabName "Lab Name" -ResourceGroupName "Group Name"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
0
1
2
```

Returns all the VMs.

### Example 2: Gets the specific VM in the lab.
```powershell
<<<<<<< HEAD
Get-AzLabServicesVM -LabName "Lab Name" -ResourceGroupName "Group Name" -Name 2
```

```output
=======
PS C:\> Get-AzLabServicesVM -LabName "Lab Name" -ResourceGroupName "Group Name" -Name 2

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
2
```

Returns the specific VM.

