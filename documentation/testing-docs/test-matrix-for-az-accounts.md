# Test Matrix for Authentication in Az.Accounts

The authentication functionality in Az.Accounts is one of the most important pieces in Azure PowerShell. To make sure Azure PowerShell be delivered to customers with high quality, we define the test matrix which should be honored by each release of Az.Accounts when there is any change related to authentication.

## Test Scenario

Each test scenario is marked with one priority P0, P1, P2 based on two factors:

- The importance of the test scenario, i.e. whether used by customers popularly, P0 means most popular.
- Whether be easily affected by authentication related code change, P0 means most easily be affected.

### Connect-AzAccount Using Work/School Account

|Scenario\AuthN Method|Interactive|Device Code (`-DeviceCode`)|User Name+Password (`-Credential`)|Access Token (`-AccessToken`)|SP Secret (`-ServicePrincipal -Credential`)|SP Cert (`-ServicePrincipal -CertificateThumbprint`)|System MSI (`-Identity`)|User MSI (`-Identity -AccountId`)|User MSI-Func App published by VS Code (`-Identity -AccountId`)|
|----|----|----|----|----|----|----|----|----|----|
|`No Subscrption/Tenant`|P0 (SemiAuto)|P0|P0 (Auto-No)|P0 (SemiAuto-No)|P0 (Auto-No)|P0 (SemiAuto-No)|P0|P0|P0|
|`-Subscription sub-id`|P0 (SemiAuto)|P1|P1 (Auto-No)|P1 (SemiAuto-No)|P1 (Auto-No)|P2 (SemiAuto-No)|P1|P1|P1|
|`-Subscription sub-name`|P1 (SemiAuto)|P2|P2 (Auto-No)|P2 (SemiAuto-No)|P2 (Auto-No)|P2 (SemiAuto-No)|P2|P2|P2|
|`-Subscription sub-id-in-2nd-tenant`|P0 (SemiAuto-No)|P2|P2 (Auto-No)|P2 (SemiAuto-No)|P2 (Auto-No)|P2 (SemiAuto-No)|NA|NA|NA|
|`-Tenant tenant-id`|P0 (SemiAuto)|P1|P1 (Auto-No)|P1 (SemiAuto-No)|P1 (Auto-No)|P2 (SemiAuto-No)|P1|P1|P1|
|`-Tenant 2nd-tenant-id`|P1 (SemiAuto-No)|P1|P1 (Auto-No)|P1 (SemiAuto-No)|P1 (Auto-No)|P1 (SemiAuto-No)|NA|NA|NA|
|`-Tenant tenant-id -Subscription sub-id`|P0 (SemiAuto)|P1|P1 (Auto-No)|P1 (SemiAuto-No)|P1 (Auto-No)|P1 (SemiAuto-No)|P1|P1|P1|
|`-Tenant 2nd-tenant-id -Subscription sub-id-in-2nd-tenant`|P1 (SemiAuto-No)|P2|P2 (Auto-No)|P2 (SemiAuto-No)|P2 (Auto-No)|P2 (SemiAuto-No)|NA|NA|NA|
|`No Parameter` Click back button before inputing password(Negative)|P2|P2|NA|NA|NA|NA|NA|NA|NA|
|`-Subscripiton -sub-id-no-permission`(Negative)|P2|P2|P2|P2|P2|P2|P2|P2|P2|
|`-Tenant -tenant-id-no-permission`(Negative)|P2|P2|P2|P2|P2|P2|P2|P2|P2|
|`-Tenant 1st-tenant-id -Subscription sub-id-in-2nd-tenant`(Negative)|P2|P2|P2|P2|P2|P2|P2|P2|P2|

**Test Case Automation Status**

- *SemiAuto* means the test case is available, but it needs manual input during running test.
- *SemiAuto-No* means the test case could be written in SemiAuto way, but it is not there yet.
- *Auto-No* means the test case could be written in automatic way(by environment variable), but it is not there yet.
- Test case without any status means manual, the cost for automation is high.

### Connect-AzAccount Using MSA Account

|Scenario\AuthN Method|Interactive|Device Code (`-DeviceCode`)|
|----|----|----|
|`No Subscription/Tenant`|P0 (SemiAuto)|P0|
|`-Subscription sub-id`|P2 (SemiAuto)|P2|
|`-Tenant tenant-id`|P2 (SemiAuto)|P2|
|`-Tenant tenant-id -Subscription sub-id`|P2 (SemiAuto)|P2|

### Connect-AzAccount - Special Test Scenario

|Test|Priority|Comment|
|----|----|----|
|Interactive authentication should return warning if connecting to Linux using SSH|P0 (Auto)||
|Interactive authentication should be successful even the port 8400 is taken by other process first|P0 (Auto)||
|Token should be auto refreshed for long running operation(> 1 hour)|P2|Please refer `How To Test` section|
|Token cache file should be compatible with az|P2|Please refer `How To Test` section|
|Service Principal authentication should be successful if http proxy is set|P2|Please refer `How To Test` section|
|FMR scenario(Integrated Windows Authentication)|P2|Please refer `How To Test` section|

### Other Authentication Test Scenario

It should be fine to run these test cases in just one platform, e.g. Windows PowerShell 5.1.

|Test|Priority|
|---|---|
|Login in Process scope `-Scope`|P1|
|Login with Multi Users|P1|
|Disconnect-AzAccount|P0|
|Disconnect-AzAccount(Service Principal) `-ApplicationId xxx -TenantId xxx`|P2|
|Disconnect-AzAccount(specifying context) `-AzureContext contextObject`|P2|
|Disconnect-AzAccount(Login with multi users, log out one)|P2|
|Save-AzContext and Import-AzContext|P2|
|Get-AzAccessToken|P1|
|Token Cache Fallback(Linux Only)|P1|

## Test Strategy

### Azure Environments

|Azure Environment|Priority|Comment|
|----|-----|----|
|Azure Global Instance|P0||
|Azure US Instance|P2|Will be covered by dedicated team|
|Azure China Instance|P2|Will be covered by dedicated team|
|Azure German Instance|P2|Will be covered by dedicated team|
|ADFS Environment|P1|Ask Azure Stack team to help|

### PowerShell Platforms

In theory all the combination of different OS platforms and PowerShell versions should be covered, to compromise time effort and platform coverages, we should at least cover the following platforms. (For different versions of PowerShell 7, need to cover at least smallest and biggest patch version for each major.minor version, currently it should be 7.0.0, 7.0.3 and 7.1.0. The reason to cover 7.0.0 is the future version of Azure.Core may contain higher version of built-in assemblies of PowerShell.)

- Windows PowerShell 5.1
- PowerShell 7.0.0 on Windows
- PowerShell 7.0.x(latest patch version) on Windows
- PowerShell 7.1.0 on Windows
- PowerShell 7.0.0 on Ubuntu
- PowerShell 7.0.x on Ubuntu
- PowerShell 7.1.0 on Ubuntu
- PowerShell 7.0.x on MacOS
- CloudShell
- Docker Env for Ubuntu
- Windows PowerShell 5.1 in Constrained Language Mode

There's no need to run all tests on each of above platforms, the recommendation is:

1. For `Windows PowerShell 5.1`, run all applicable tests.
2. For `PowerShell 7.0.x on Windows`, run tests on columns **Interactive/Device Code/SP Secret** (please refer to test scenario table).
3. For other platforms, just run smoke test `Connect-AzAccount`/`Connect-AzAccount -DeviceCode`.

### Authentication Code Change Impact

When there is authentication related code change in Az.Accounts, there's no need to run all test scenario on all platforms and environments. In contrast, we may choose to run different test scenario based on different authentication code change impact, so that only affected test cases are covered.

#### Just Authentication Code Change without Version Upgrade of MSAL/Azure.Identity in Az.Accounts

Only need to verify P0 test scenario.

#### Minor/Patch Version Upgrade of MSAL/Azure.Identity in Az.Accounts

Only need to verify P0 and P1 test scenario.

#### Major Version Upgrade of MSAL/Azure.Identity in Az.Accounts

Need to verify P0, P1 and P2 test scenario.

### Partner Teams

If possible, we should provide preview/engineering bits to our partners for verifying their modules: (P2)

- Azure Stack team to verify ADFS scenario
- Azure Function team
- Azure StackHCI team

## How To Test

1. How to Test Long Running Operation (LRO)

```powershell
New-AzResourceGroupDeployment -Name xxxx -ResourceGroupName xxxx -TemplateFile path-to-template-file
```

You may save json content below as template file, make sure the value of `parameters.userAssignedIdentity.defaultValue` has been set correctly and the user MSI has permission.

```json
{
    "$schema": "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#",
    "contentVersion": "1.0.0.0",
    "parameters": {
      "userAssignedIdentity": {
        "type": "string",
        "defaultValue": "/subscriptions/331856d2-64ff-4cde-abe7-b782335b52da/resourceGroups/yourgroupname/providers/Microsoft.ManagedIdentity/userAssignedIdentities/youruseridentityname"
      },
        "newGuid": {
            "type": "string",
            "defaultValue": "[newGuid()]"
        }
    },
    "variables": {
        "scriptName": "sleep11"
    },
    "resources": [
        {
            "type": "Microsoft.Resources/deploymentScripts",
            "apiVersion": "2019-10-01-preview",
            "name": "[variables('scriptName')]",
            "location": "[resourceGroup().location]",
            "identity": {
                "type": "UserAssigned",
                "userAssignedIdentities": {
                    "[parameters('userAssignedIdentity')]": {
                    }
                }
            },
            "kind": "AzurePowerShell",
            "properties": {
                "forceUpdateTag": "[parameters('newGuid')]",
                "azPowerShellVersion": "4.8",
                "timeout": "PT90M",
                "retentionInterval": "P1D",
                "cleanupPreference": "Always",
                "scriptContent": "Start-Sleep -Seconds 5000"
            }
        }
    ],
    "outputs": {
        "ip": {
            "type": "string",
            "value": "Slept"
        }
    }
}
```

2. How to Test Http Proxy

    a. Start Fiddler
    b. Restart Windows PowerShell and run `Connect-AzAccount`
    c. You should see http request in Fiddler like `https://login.microsoftonline.com/organizations/oauth2/v2.0/token`

3. How to Test compatability with az

    Expect no error happens:
    a. az login
    b. Delete the token cache file (C:\Users\<user>\AppData\Local.IdentityService\msal.cache)
    c. Connect-AzAccount
    d. Get-AzSubscription
    e. az group list
    f. Disconnect-AzAccount

4. How to Test Integrated Windows Authentication

    a. Start Fiddler
    b. Restart Windows PowerShell and Connect-AzAccount using your corp account

    ```powershell
    $cred = Get-Credential
    Connect-AzAccount -Credential $cred
    ```

    c. Although failed to login, but the http reqeust `https://msft.sts.microsoft.com/adfs/services/trust/2005/usernamemixed` should be successful.

5. How to Test in Constrained Language Mode

    If you're from MSFT and have SAW machine at hand, you could just run Windows PowerShell on SAW Machine on which constrained language mode is enabled by default. If not, please run PowerShell under [Constrained Language Mode](https://devblogs.microsoft.com/powershell/powershell-constrained-language-mode/).
