### Example 1: Create a ACS resource

```powershell
New-AzCommunicationService -ResourceGroupName ContosoResourceProvider1 -Name ContosoAcsResource1 -DataLocation UnitedStates -Location Global
```

```output
Location Name                SystemDataCreatedAt  SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType
-------- ----                -------------------  -------------------        ----------------------- ------------------------ ------------------------  ----------------------------
Global   ContosoAcsResource1 7/10/2024 4:41:40 AM contosouser@microsoft.com  User                    7/10/2024 4:41:40 AM     contosouser@microsoft.com User
```

Creates a ACS resource using the specified parameters.

### Example 2: Create a ACS resource with Linked domain

```powershell
$linkedDomains = @(
	"/subscriptions/73fc3592-3cef-4300-5e19-8d18b65ce0e8/resourceGroups/tcsacstest/providers/Microsoft.Communication/emailServices/tcsacstestECSps/domains/AzureManagedDomain"
)

New-AzCommunicationService -ResourceGroupName ContosoResourceProvider -Name ContosoAcsResource2 -DataLocation UnitedStates -Location Global  -LinkedDomain @linkedDomains
```

```output
Location Name                SystemDataCreatedAt  SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy  SystemDataLastModifiedByType
-------- ----                -------------------  -------------------        ----------------------- ------------------------ ------------------------  ----------------------------
Global   ContosoAcsResource2 7/10/2024 5:41:40 AM contosouser@microsoft.com  User                    7/10/2024 5:41:40 AM     contosouser@microsoft.com User
```

Creates a ACS resource using the specified parameters.
