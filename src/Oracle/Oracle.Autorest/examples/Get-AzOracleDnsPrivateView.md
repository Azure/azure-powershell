### Example 1: Get a list of the DNS Private Views by location
```powershell
Get-AzOracleDnsPrivateView -Location "eastus"
```

```output
Name                                                                               SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                                                               ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
ocid1.dnsview.oc1.iad.aaaaaaaaytqscqgo3vowvligvkeaiqozwywcbkm336keyzz34xiorgfximza                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaalf3jpv4bmwdg6nxw7ciudrb3smln6a46h7asgrwoironcxuoslea                                                                                                                                                
ocid1.dnsview.oc1.iad.aaaaaaaags4sek6p7ocgs5sjarfm26dgmz23yegxxwqk4aowebismrbbgm6q
```

Get a list of the DNS Private Views by location.
For more information, execute `Get-Help Get-AzOracleDnsPrivateView`.