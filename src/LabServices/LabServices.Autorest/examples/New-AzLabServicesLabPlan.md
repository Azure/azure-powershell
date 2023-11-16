### Example 1: Create a new Lab plan.
```powershell
New-AzLabServicesLabPlan `
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
```

```output
Location Name
-------- ----
westus2  testplan
```

Create a lab plan.
