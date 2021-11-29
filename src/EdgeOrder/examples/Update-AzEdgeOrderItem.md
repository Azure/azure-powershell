### Example 1: Update orderItem
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
PS C:\> $updatedOrderItem = Update-AzEdgeOrderItem -Name "examplePowershell" -ResourceGroupName "resourceGroupName" -SubscriptionId SubscriptionId -ForwardAddressContactDetail $contactDetail

PS C:\> $updatedOrderItem.ForwardAddressContactDetail | fl

ContactName    : ContactName2
EmailList      : {useremailId}
Mobile         :
Phone          : 1234567891
PhoneExtension :
```
Update orderItem details.
