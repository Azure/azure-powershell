### Example 1: Create a new lab.
```powershell
<<<<<<< HEAD
New-AzLabServicesLab `
=======
PS C:\>  New-AzLabServicesLab `
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
        -Name "NewLab" `
        -ResourceGroupName $ENV:ResourceGroupName `
        -Location $ENV:Location `
        -AdditionalCapabilityInstallGpuDriver Disabled `
        -AdminUserPassword "PlaceholderPassword" `
        -AdminUserUsername "PlaceholderAccountName" `
        -AutoShutdownProfileShutdownOnDisconnect Disabled `
        -AutoShutdownProfileShutdownOnIdle None `
        -AutoShutdownProfileShutdownWhenNotConnected Disabled `
        -ConnectionProfileClientRdpAccess Public `
        -ConnectionProfileClientSshAccess None `
        -ConnectionProfileWebRdpAccess None `
        -ConnectionProfileWebSshAccess None `
        -Description "New lab description" `
        -ImageReferenceOffer "Windows-10" `
        -ImageReferencePublisher "MicrosoftWindowsDesktop" `
        -ImageReferenceSku "20h2-pro" `
        -ImageReferenceVersion "latest" `
        -SecurityProfileOpenAccess Disabled `
        -SkuCapacity 3 `
        -SkuName "Standard" `
        -Title $ENV:NewLabName `
        -VirtualMachineProfileCreateOption "TemplateVM" `
        -VirtualMachineProfileUseSharedPassword Enabled
<<<<<<< HEAD
```

```output
=======

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name
-------- ----
westus2  NewLab
```

Creates a new Lab.
