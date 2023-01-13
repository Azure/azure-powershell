### Example 1: Returns supported VM Sizes in a location
```powershell
Get-AzMLServiceVMSize -Location eastus
```

```output
Family                      Gpu LowPriorityCapable MaxResourceVolumeMb MemoryGb Name                      OSVhdSizeMb PremiumIo SupportedComputeType                         VCpUs
------                      --- ------------------ ------------------- -------- ----                      ----------- --------- --------------------                         -----
standardDFamily             0   True               51200               3.5      Standard_D1               1047552     False     {AmlCompute}                                 1
standardDFamily             0   True               102400              14       Standard_D11              1047552     False     {AmlCompute}                                 2
standardDv2Family           0   True               102400              14       Standard_D11_v2           1047552     False     {AmlCompute, ComputeInstance}                2
standardDFamily             0   True               204800              28       Standard_D12              1047552     False     {AmlCompute}                                 4
standardDv2Family           0   True               204800              28       Standard_D12_v2           1047552     False     {AmlCompute, ComputeInstance}                4
```

Returns supported VM Sizes in a location.
