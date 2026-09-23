### Example 2: Disable VM in Azure
```powershell
Remove-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" 
```

Disables VM resource in Azure. Doesn't remove Extended Machine resource or VM from SCVMM host.

### Example 2: Remove Extended Machine resource for VM
```powershell
Remove-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -DeleteMachine
```

Disables VM resource in Azure and remove Extended Machine resource for VM. Does not remove VM from SCVMM host.
`-NoWait` or `-AsJob` does not work with `-DeleteMachine`.

### Example 3: Removes VM from VMM
```powershell
Remove-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -DeleteFromHost
```

Disables VM resource in Azure and remove VM from SCVMM host. Does not removes Extended Machine resource for VM and require manual cleanup from RG.

### Example 3: Removes VM from VMM and Remove Extended Machine resource for VM
```powershell
Remove-AzScVmmVM -Name "test-vm" -ResourceGroupName "test-rg-01" -DeleteFromHost -DeleteMachine
```

Disables VM resource in Azure, removes Extended Machine resource for VM and remove VM from SCVMM host.
`-NoWait` or `-AsJob` does not work with `-DeleteMachine`.
