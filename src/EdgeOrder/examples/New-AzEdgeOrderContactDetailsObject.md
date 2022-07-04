### Example 1: Contact details object
```powershell
$contactDetail = New-AzEdgeOrderContactDetailsObject -ContactName ContactName -EmailList @("emailId") -Phone Phone
```

```output
ContactName    : random
EmailList      : {"emailId"}
Mobile         :
Phone          : 1234567890
PhoneExtension :
```

Creates a in-memory contact details object