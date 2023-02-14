### Example 1: Create a in-memory object for ContactDetails 
```powershell
<<<<<<< HEAD
New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
```

```output
=======
PS C:\> $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("emailId") -Phone "1234567891"
PS C:\>  $contactDetail

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
ContactName EmailList            Mobile Phone      PhoneExtension
----------- ---------            ------ -----      --------------
random      {emailId}        1234567891
```

Create a in-memory object for ContactDetails 

