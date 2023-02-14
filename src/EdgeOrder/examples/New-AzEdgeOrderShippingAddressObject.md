### Example 1: Creates shipping address object
```powershell
<<<<<<< HEAD
$ShippingDetails = New-AzEdgeOrderShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"

$ShippingDetails | Format-List
```

```output
=======
PS C:\> $ShippingDetails = New-AzEdgeOrderShippingAddressObject -StreetAddress1 "101 TOWNSEND ST" -StateOrProvince "CA" -Country "US" -City "San Francisco" -PostalCode "94107" -AddressType "Commercial"

$ShippingDetails | fl

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
AddressType     : Commercial
City            : San Francisco
CompanyName     :
Country         : US
PostalCode      : 94107
StateOrProvince : CA
StreetAddress1  : 101 TOWNSEND ST
StreetAddress2  :
StreetAddress3  :
ZipExtendedCode :
```
Creates a in-memory shipping address object