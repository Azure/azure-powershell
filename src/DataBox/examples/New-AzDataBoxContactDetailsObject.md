### Example 1: Create a in-memory object for ContactDetails 
```powershell
New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
```

```output
ContactName EmailList            Mobile Phone      PhoneExtension
----------- ---------            ------ -----      --------------
random      {emailId}        1234567891
```

Create a in-memory object for ContactDetails 

