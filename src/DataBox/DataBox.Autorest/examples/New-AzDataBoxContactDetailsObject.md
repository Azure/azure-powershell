### Example 1: Create a in-memory object for ContactDetails 
```powershell
New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
```

```output
ContactName            : random
EmailList              : {emailId}
Mobile                 :
NotificationPreference :
Phone                  : 1234567891
PhoneExtension         :
```

Create a in-memory object for ContactDetails