### Example 1: Update an existing ACS resource to have tags

```powershell
Update-AzCommunicationService -Name ContosoAcsResource2 -ResourceGroupName ContosoResourceProvider1 -Tag @{ExampleKey1="ExampleValue1"}
```

```output
Location Name                SystemDataCreatedAt  SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType
-------- ----                -------------------  -------------------        ----------------------- ------------------------ ------------------------  ----------------------------
Global   ContosoAcsResource2 7/10/2024 5:41:40 AM contosouser@microsoft.com  User                    7/16/2024 3:40:40 AM     contosouser@microsoft.com User
```

Attaches the given tags to the specified ACS resource.

### Example 2: Update an existing ACS resource to have tags and link the domain

```powershell
$linkedDomains = @(
	"/subscriptions/73fc3592-3cef-4300-5e19-8d18b65ce0e8/resourceGroups/tcsacstest/providers/Microsoft.Communication/emailServices/tcsacstestECSps/domains/AzureManagedDomain"
)

Update-AzCommunicationService -Name ContosoAcsResource1 -ResourceGroupName ContosoResourceProvider1 -Tag @{ExampleKey1="ExampleValue1"}  -LinkedDomain @linkedDomains
```

```output
Location Name                SystemDataCreatedAt  SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType
-------- ----                -------------------  -------------------        ----------------------- ------------------------ ------------------------  ----------------------------
Global   ContosoAcsResource1 7/10/2024 5:41:40 AM contosouser@microsoft.com  User                    7/16/2024 3:40:40 AM     contosouser@microsoft.com User
```

Attaches the given tags and links the doamin to the specified ACS resource.
