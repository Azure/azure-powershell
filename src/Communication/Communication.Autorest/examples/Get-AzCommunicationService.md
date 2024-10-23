### Example 1: List existing CommunicationServices for a Subscription

```powershell
Get-AzCommunicationService -SubscriptionId 632ec9eb-fad7-4cbd-993a-e72973ba2acc
```

```output
Location Name                SystemDataCreatedAt  SystemDataCreatedBy         SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType
-------- ----                -------------------  -------------------         ----------------------- ------------------------ ------------------------   ----------------------------
Global   ContosoAcsResource1 7/09/2024 4:41:40 AM contosouser@microsoft.com   User                    7/09/2024 4:41:40 AM     contosouser@microsoft.com  User
Global   ContosoAcsResource2 4/10/2024 2:41:40 AM contosouser2@microsoft.com  User                    4/10/2024 2:41:40 AM     contosouser2@microsoft.com User
Global   ContosoAcsResource3 5/01/2024 1:41:40 AM contosouser3@microsoft.com  User                    5/01/2024 1:41:40 AM     contosouser3@microsoft.com User
Global   ContosoAcsResource4 6/08/2024 5:41:40 AM contosouser4@microsoft.com  User                    6/08/2024 5:41:40 AM     contosouser4@microsoft.com User
Global   ContosoAcsResource5 6/09/2024 4:41:40 AM contosouser5@microsoft.com  User                    6/09/2024 4:41:40 AM     contosouser5@microsoft.com User
```

Returns a list of all ACS resources under that subscription.

### Example 2: Get infomation on specified Azure Communication resource

```powershell
Get-AzCommunicationService -Name ContosoAcsResource34 -ResourceGroupName ContosoResourceProvider1
```

```output
Location Name                SystemDataCreatedAt  SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType
-------- ----                -------------------  -------------------        ----------------------- ------------------------ ------------------------  ----------------------------
Global   ContosoAcsResource1 7/10/2024 4:41:40 AM contosouser@microsoft.com  User                    7/10/2024 9:02:15 AM     contosouser@microsoft.com User
```

Returns the information on an ACS resource, if one matching provided parameters is found.
