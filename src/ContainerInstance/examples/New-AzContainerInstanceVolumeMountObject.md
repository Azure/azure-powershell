### Example 1: Specify a volume mount available to a container instance
```powershell
<<<<<<< HEAD
New-AzContainerInstanceVolumeMountObject -Name "mnt" -MountPath "/mnt/azfile" -ReadOnly $true
=======
New-AzContainerInstanceVolumeMountObject -Name 
"mnt" -MountPath "/mnt/azfile" -ReadOnly $true
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

```output
MountPath   Name ReadOnly
---------   ---- --------
/mnt/azfile mnt  True
```

This command specifies a volume mount available to a container instance


