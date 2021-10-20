### Example 1: Create user body.
```powershell
PS C:\> $userBody = New-AzLabServicesUserObject -Email "Email@contoso.com"
PS C:\> New-AzLabServicesUser -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "User Name" ` $rg -Body $userBody

Name
----
User Name
```

This cmdlet creates the minimum information to save or update a User using the body parameter.
