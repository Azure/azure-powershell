### Example 1: Update address details
```powershell
PS C:\> $contactDetail = New-AzEdgeOrderContactDetailsObject -ContactName "ContactName2" -EmailList @("emailId") -Phone Phone
PS C:\> $DebugPreference = "Continue"
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
PS C:\> $updatedContactInAddress = Update-AzEdgeOrderAddress -Name "TestPwAddress" -ResourceGroupName "resourceGroupName" -SubscriptionId SubscriptionId -ContactDetail $contactDetail -ShippingAddres $ShippingDetails
PS C:\> $updatedContactInAddress.ContactDetail.ContactName
ContactName2
```
Update address details.