### Example 1: Update address details
```powershell
PS C:\> $contactDetail = New-AzEdgeOrderContactDetailsObject -ContactName "ContactName2" -EmailList @("emailId") -Phone Phone
PS C:\> $updatedContactInAddress = Update-AzEdgeOrderAddress -Name "TestPwAddress" -ResourceGroupName "resourceGroupName" -SubscriptionId SubscriptionId -ContactDetail $contactDetail -ShippingAddres $ShippingDetails
PS C:\> $updatedContactInAddress.ContactDetail.ContactName
ContactName2
```