### Example 1: Create new lab plan body.
```powershell
PS C:\> $body = New-AzLabServicesLabPlanObject -AllowedRegion @("westus2") -Location "westus2" `
    -DefaultConnectionProfileClientRDPAccess "Public" `
    -DefaultConnectionProfileClientSSHAccess "None" `
    -DefaultConnectionProfileWebSSHAccess "None" `
    -DefaultConnectionProfileWebRDPAccess "None" 
PS C:\> New-AzLabServicesLabPlan -Name "testplan" -ResourceGroupName "Group Name" -Body $body


Location Name
-------- ----
westus2  testplan
```

This cmdlet creates the minimum information to create a lab plan using the body parameter.  Defaulting to not setting shutdown options.