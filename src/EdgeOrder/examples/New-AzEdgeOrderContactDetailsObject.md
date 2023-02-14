### Example 1: Contact details object
```powershell
$contactDetail = New-AzEdgeOrderContactDetailsObject -ContactName ContactName -EmailList @("emailId") -Phone Phone
<<<<<<< HEAD
```

```output
=======

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ContactName    : random
EmailList      : {"emailId"}
Mobile         :
Phone          : 1234567890
PhoneExtension :
```

Creates a in-memory contact details object