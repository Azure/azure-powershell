### Example 1: Get a specific guest configuration assignment
```powershell
Get-AzGuestConfigurationAssignment -ResourceGroupName test-rg -VMName test-vm  -GuestConfigurationAssignmentName test-assignment
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

Get a specific guest configuration assignment

### Example 2: List guest configuration assignments for a VM
```powershell
Get-AzGuestConfigurationAssignment -ResourceGroupName test-rg -VMName test-vm
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

List guest configuration assignments for a VM

### Example 3: List guest configuration assignments for a VMSS
```powershell
Get-AzGuestConfigurationAssignment -ResourceGroupName test-rg -VmssName test-vmss
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

List guest configuration assignments for a VMSS

### Example 4: List guest configuration assignments for a ARC machine
```powershell
Get-AzGuestConfigurationAssignment -ResourceGroupName test-rg -MachineName test-machine
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment test-rg
```

List guest configuration assignments for a ARC machine

### Example 5: List guest configuration assignments for a resource group
```powershell
Get-AzGuestConfigurationAssignment -ResourceGroupName test-rg
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment1 test-rg
westcentralus test-assignment2 test-rg
```

List guest configuration assignments for a resource group

### Example 6: List guest configuration assignments for a subscription
```powershell
Get-AzGuestConfigurationAssignment -SubscriptionId xxxxx-xxxx-xxxxx-xxx
```

```output
Location      Name     ResourceGroupName
--------      ----     -----------------
westcentralus test-assignment1 test-rg
westcentralus test-assignment2 test-rg
```

List guest configuration assignments for a subscription