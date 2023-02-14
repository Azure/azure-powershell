### Example 1: Redeploy the specific Virtual machine.
```powershell
<<<<<<< HEAD
Start-AzLabServicesVMRedeployment -LabName "Lab Name" -ResourceGroupName "Group Name" -VirtualMachineName 1
=======
PS C:\> Start-AzLabServicesVMRedeployment -LabName "Lab Name" -ResourceGroupName "Group Name" -VirtualMachineName 1

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

The Redeploy removes the machine and creates a new one.
