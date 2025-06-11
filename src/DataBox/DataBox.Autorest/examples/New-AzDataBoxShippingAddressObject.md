### Example 1: Shipping Address object 
```powershell
New-AzDataBoxShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"
```

```output
AddressType             : Commercial
City                    : San Francisco
CompanyName             :
Country                 : US
PostalCode              : 94107
SkipAddressValidation   :
StateOrProvince         : CA
StreetAddress1          : 101 TOWNSEND ST
StreetAddress2          :
StreetAddress3          :
TaxIdentificationNumber :
ZipExtendedCode         :
```

Creates a in-memory shipping address object 