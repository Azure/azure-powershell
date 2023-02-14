### Example 1: Create a new Lab plan.
```powershell
<<<<<<< HEAD
New-AzLabServicesLabPlan `
=======
PS C:\> New-AzLabServicesLabPlan `
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
	-LabPlanName "testplan" `
	-ResourceGroupName "Group Name" `
	-Location "westus2" `
	-AllowedRegion @('westus2', 'eastus2') `
	-DefaultAutoShutdownProfileShutdownOnDisconnect Disabled `
	-DefaultAutoShutdownProfileShutdownOnIdle None `
	-DefaultAutoShutdownProfileShutdownWhenNotConnected Disabled `
	-DefaultConnectionProfileClientRdpAccess Public `
	-DefaultConnectionProfileClientSshAccess None `
	-SupportInfoEmail 'test@contoso.com' `
	-SupportInfoInstruction 'test information' `
	-SupportInfoPhone '123-456-7890' `
	-SupportInfoUrl 'https:\\test.com' `
	-DefaultConnectionProfileWebRdpAccess None `
	-DefaultConnectionProfileWebSshAccess None
<<<<<<< HEAD
```

```output
=======

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name
-------- ----
westus2  testplan
```

Create a lab plan.
