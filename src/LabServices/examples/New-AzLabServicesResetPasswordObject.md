### Example 1: Create reset vm password body.
```powershell
PS C:\> $resetBody = New-AzLabServicesResetPasswordObject -Password $(ConvertTo-SecureString "Password" -AsPlainText -Force)
PS C:\> Reset-AzLabServicesVMPassword -LabName "Lab Name" -ResourceGroupName "Group Name" -VirtualMachineName 1 -Body $resetBody 

```

This cmdlet creates the minimum information to reset a VM password using the body parameter.
