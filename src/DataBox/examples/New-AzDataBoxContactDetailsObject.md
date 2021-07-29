### Example 1: {{ Create a in-memory object for ContactDetails }}
```powershell
PS C:\> $contactDetail = New-AzDataBoxContactDetailsObject -ContactName "random" -EmailList @("dhja@microsoft.com") -Phone "1234567891"
PS C:\>  $contactDetail

ContactName EmailList            Mobile Phone      PhoneExtension
----------- ---------            ------ -----      --------------
random      {dhja@microsoft.com}        1234567891
```

{{ Create a in-memory object for ContactDetails }}

