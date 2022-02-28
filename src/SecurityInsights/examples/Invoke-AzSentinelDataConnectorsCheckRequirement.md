### Example 1: Check requirements for a Data Connector
```powershell
PS C:\> Invoke-AzSentinelDataConnectorsCheckRequirement -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Kind OfficeATP -TenantId (Get-AzContext).Tenant.Id

AuthorizationState : Valid
LicenseState       : Valid
```
This example command checks the Data Connector Requirements for the Office 365 data connector.

Other -Kind values are:
AzureSecurityCenter
AzureActiveDirectory
AzureAdvancedThreatProtection
Dynamics365
MicrosoftCloudAppSecurity
MicrosoftDefenderAdvancedThreatProtection
MicrosoftThreatIntelligence
MicrosoftThreatProtection
OfficeATP
OfficeIRM
ThreatIntelligence
ThreatIntelligenceTaxii