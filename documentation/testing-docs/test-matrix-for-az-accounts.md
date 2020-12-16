# Test Matrix for Authentication in Az.Accounts

The authentication functionality in Az.Accounts is one of most important piece for Azure PowerShell, to make sure Azure PowerShell be delivered to customers with high quality, we define the test matrix and it should be honored by each release of Az.Accounts.

**Priority Clarification**

- `P0`: Run if any authentication related code change in Az.Accounts
- `P1`: Run if upgrading minor version of Azure.Identity and/or MSAL library
- `P2`: Run if upgrading major version of Azure.Identity and/or MSAL library

## Azure Global Instance

Azure Global Instance is the most important Azure instance, all tests should run against it.

### PWSH Platform Matrix

In theory all the combination of different OS platforms and PWSH versions should be covered, to compromise time effort and platform coverages, we should at least cover the following platforms. (For different versions of pwsh 7, need to cover at least smallest and biggest patch version for each major.minor version, currently it should be 7.0.0, 7.0.3 and 7.1.0. The reason to cover 7.0.0 is the future version of Azure.Core may contain higher version of built-in assemblies of pwsh.)

- Windows PowerShell 5.1
- PWSH 7.0.0 on Windows
- PWSH 7.0.x on Windows (latest patch version of PWSH 7.0)
- PWSH 7.1.0 on Windows
- PWSH 7.0.0 on Ubuntu
- PWSH 7.0.x on Ubuntu
- PWSH 7.1.0 on Ubuntu
- PWSH 7.0.x on MacOS
- CloudShell
- Docker Env for Ubuntu

There's no need to run all tests on each of above platforms, the recommendation is to run most of tests on `Windows PowerShell 5.1` and to run the remaining tests on `PWSH 7.0.x on Windows`; just run smoke test `Connect-AzAccount`/`Connect-AzAccount -DeviceCode` on other platforms.

### Connect-AzAccount Using Work/School Account

|Scenario\Auth Method|Interactive|Device Code (`-DeviceCode`)|User Name+Password (`-Credential`)|Access Token (`-AccessToken`)|SP Secret (`-ServicePrincipal -Credential`)|SP Cert (`-ServicePrincipal -CertificateThumbprint`)|System MSI (`-Identity`)|User MSI (`-Identity -AccountId`)|User MSI-Func App published by VS Code (`-Identity -AccountId`)|
|----|----|----|----|----|----|----|----|----|----|
|`No parameter`|P0(SemiAuto)|P0|P0(SemiAuto-No)|P0(SemiAuto-No)|P0(SemiAuto-No)|P0(SemiAuto-No)|P0|P0|P0|
|`-Subscription sub-id`|P0(SemiAuto)|P1|P1(SemiAuto-No)|P1(SemiAuto-No)|P1(SemiAuto-No)|P2(SemiAuto-No)|P1|P1|P1|
|`-Subscription sub-name`|P1(SemiAuto)|P2|P2(SemiAuto-No)|P2(SemiAuto-No)|(SemiAuto-No)|P2(SemiAuto-No)|P2|P2|P2|
|`-Subscription sub-id-in-2nd-tenant`|P0(SemiAuto-No)|P2|P2(SemiAuto-No)|P2(SemiAuto-No)|P2(SemiAuto-No)|P2(SemiAuto-No)|NA|NA|NA|
|`-Tenant tenant-id`|P0(SemiAuto)|P1|P1(SemiAuto-No)|P1(SemiAuto-No)|P1(SemiAuto-No)|P2(SemiAuto-No)|P1|P1|P1|
|`-Tenant 2nd-tenant-id`|P1(SemiAuto-No)|P1|P1(SemiAuto-No)|P1(SemiAuto-No)|P1(SemiAuto-No)|P1(SemiAuto-No)|NA|NA|NA|
|`-Tenant tenant-id -Subscription sub-id`|P0(SemiAuto)|P1|P1(SemiAuto-No)|P1(SemiAuto-No)|P1(SemiAuto-No)|P1(SemiAuto-No)|P1|P1|P1|
|`-Tenant 2nd-tenant-id -Subscription sub-id-in-2nd-tenant`|P1(SemiAuto-No)|P2|P2(SemiAuto-No)|P2(SemiAuto-No)|P2(SemiAuto-No)|P2(SemiAuto-No)|NA|NA|NA|
|`No Parameter` Click back button before inputing password(Negative)|P2|P2|NA|NA|NA|NA|NA|NA|NA|
|`-Subscripiton -sub-id-no-permission`(Negative)|P2|P2|P2|P2|P2|P2|P2|P2|P2|
|`-Tenant -tenant-id-no-permission`(Negative)|P2|P2|P2|P2|P2|P2|P2|P2|P2|
|`-Tenant 1st-tenant-id -Subscription sub-id-in-2nd-tenant`(Negative)|P2|P2|P2|P2|P2|P2|P2|P2|P2|

**Test Case Automation Status**

- *SemiAuto* means the test case is available, but it needs manual input during running test.
- *SemiAuto-No* means the test case could be written in SemiAuto way, but it is not there yet.
- Test case without any status means manual, the cost for automation is high.

### Connect-AzAccount Using MSA Account

|Scenario\Auth Method|Interactive|Device Code (`-DeviceCode`)|
|----|----|----|
|`No parameter`|P0(SemiAuto)|P0|
|`-Subscription sub-id`|P2(SemiAuto)|P2|
|`-Tenant tenant-id`|P2(SemiAuto)|P2|
|`-Tenant tenant-id -Subscription sub-id`|P2(SemiAuto)|P2|

### Other Authentication Related Tests

It should be fine to run these test cases in just one platform.

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

**NOTE**

1. Special Test Environments

- ADFS Env (P1)
- SAW Machine (P2)

2. Azure Government Instances (Will be covered by dedicated teams)

- Mooncake
- Blackforest
- Fairfax

3. Special Scenario:

- Interactive authentication should return warning if connecting to Linux using SSH (P0, Auto)
- Interactive authentication should be successful even the port 8400 is taken by other process first (P0, Auto)
- Token should be auto refreshed for long running operation(> 1 hour) (P2, Manual, please refer `How To Test` section)
- Token cache file should be compatible with az (P2, Manual, please refer `How To Test` section)
- Service Principal authentication should be successful if http proxy is set (P2, Manual, please refer to `How To Test` section)
- FMR scenario(Integrated Windows Auth) (P2, Manual, please refer `How To Test` section)

4. If possible, we should provide preview/engineering bits to our partners for verifying: (P2)

- Azure Stack team to verify ADFS scenario
- Azure Function team
- Azure StackHCI team

## How To Test

1. How to test LRO

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

2. How to test Http Proxy

    a. Start Fiddler
    b. Restart Windows PowerShell and run `Connect-AzAccount`
    c. You should see http request in Fiddler like `https://login.microsoftonline.com/organizations/oauth2/v2.0/token`

3. How to test compatability with az

    Expect no error happens:
    a. az login
    b. Delete the token cache file (C:\Users<user>\AppData\Local.IdentityService\msal.cache)
    c. Connect-AzAccount
    d. Get-AzSubscription
    e. az group list
    f. Disconnect-AzAccount

4. How to test Integrated Windows Auth

    a. Start Fiddler
    b. Restart Windows PowerShell and Connect-AzAccount using your corp account

    ```powershell
    $cred = Get-Credential
    Connect-AzAccount -Credential $cred
    ```

    c. Although failed to login, but the http reqeust `https://msft.sts.microsoft.com/adfs/services/trust/2005/usernamemixed` should be successful.
