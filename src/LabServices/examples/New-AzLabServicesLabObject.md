### Example 1: Create lab body.
```powershell
PS C:\> $labBody = New-AzLabServicesLabObject -Name "rbestALab" `
	-Location "westcentralus" `
	-Title "rbestALab Title"`
	-AdditionalCapabilityInstallGpuDriver "Disabled" `
	-AdminUserPassword $(ConvertTo-SecureString "P@ssW0rD!" -AsPlainText -Force) `
	-AdminUserUserName "testuser" `
	-ConnectionProfileClientRdpAccess "Public" `
	-ConnectionProfileClientSshAccess "None" `
	-ImageReferenceOffer "Windows-10" `
	-ImageReferencePublisher "MicrosoftWindowsDesktop" `
	-ImageReferenceSku "20h2-pro" `
	-ImageReferenceVersion "latest" `
	-SecurityProfileOpenAccess "Disabled" `
	-SkuCapacity "2" `
	-SkuName "Basic" `
	-VirtualMachineProfileCreateOption "TemplateVM" `
	-VirtualMachineProfileUseSharedPassword "Enabled"
PS C:\> New-AzLabServicesLab -Name "rbestBLab" -ResourceGroupName $rg -Body $labBody


Location Name
-------- ----
westus2  NewLab
```

This cmdlet creates the minimum information to a lab using the body parameter.
