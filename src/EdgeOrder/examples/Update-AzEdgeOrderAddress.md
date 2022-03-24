### Example 1: Update address details
```powershell
$contactDetail = New-AzEdgeOrderContactDetailsObject -ContactName "ContactName2" -EmailList @("emailId") -Phone Phone
$DebugPreference = "Continue"
# You can use `$DebugPreference = "Continue"`, with any example/usecase to get exact details of error in below format when update command fails.
# {
#   "Error": {
#     "Code": "StaticValidationGenericCountryCodeHasInvalidLength",
#     "Message": "The attribute country code does not meet length constraints.\r\nEnter a value with 2 characters for country code.",
#     "Details": [
#       null
#     ],
#     "Target": null
#   }
# } 
$updatedContactInAddress = Update-AzEdgeOrderAddress -Name "TestPwAddress" -ResourceGroupName "resourceGroupName" -SubscriptionId SubscriptionId -ContactDetail $contactDetail -ShippingAddress $ShippingDetails
$updatedContactInAddress.ContactDetail.ContactName
```

```output
ContactName2
```
Update address details.