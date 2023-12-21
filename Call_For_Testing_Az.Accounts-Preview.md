We have just released **Az.Accounts-2.14.0-preivew**, which contains the following important features. 


Most of the customers will be affected and so we invite you to test the new version.
# How to Test 
Run the following cmdlet on PowerShell to install Az.Accounts-2.14.0-preivew 
```pwsh
Install-Module -Name Az.Accounts -Repository PSGallery -AllowPrerelease –Force 
```
Run your script or `Connect-AzAccount`
# Send Feedback 
Report your findings on [GitHub](https://github.com/Azure/azure-powershell/issues)

# What are in the Preview Version

## Update Az.Identity 1.6.1 to 1.10.3 to fix high vulnerability issue.  
Azure.Identity 1.6.1 is reported with [high vulnerability](https://github.com/advisories/GHSA-5mfx-4wcx-rv27). However, the updated version renames the token cache file from `msal.cache` to `msal.cache.cae` (or `msal.cache.cae`). In the Az.Accounts preview, we do the migration to eliminate the influence of renaming. Our customers are not expected to depend on the token cache file directly. We emphasize here again that it is highly not recommended to do so. Currently, we use token cache only in the following login method.  
- Interactive 
- Device Code 
- User name + Password 
- Service Principal + Federated Token

If you are using any of them, please try the new version to see whether everything goes well. 
## Enabled Continuous Access Evaluation (CAE) for Service Principal login methods.  

In **Azure PowerShell client side**, we already enabled CAE for the following login method
- Interactive 
- Device Code 
- User name + Password 

In this preview version, we enable CAE when you login using Service Principal related methods, which are
- Service Principal + Credential
- Service Principal + Certificate
- Service Principal + Federated Token.

We highly recommend you try the new feature as it improves security. You need to do some configuration on your tenant. Please refer to https://learn.microsoft.com/entra/identity/conditional-access/concept-continuous-access-evaluation for more information. 

## Optimize output UX of cmdlets in Az.Accounts 
We adjusted cmdlet output format to make it more user-friendly based on the feedback of UX study of Az.Accounts. Adjustments include:
- ordering and grouping output items to make items easy to find
- re-prioritizing positions for output properties to highlight valuable properties

Affected cmdlets include `Get-AzContext`, `Get-AzTenant`, `Get-AzSubscription` and `Invoke-AzRestMethod`. Take cmdlet `Get-AzContext` for example, we group outputs by TenantId and alphabetically order them then. 

**Please note** 
- We only adjust the visual display of output in the preview version, which means no breaking changes are introduced in output object and script will not be broken due to the lack of property even if the property is moved or hidden in display.
- **Script may be broken logically** if the script assumes the certain order of outputs since we adjusted the order of output items. 

## Fixed the authentication issue when using `FederatedToken` in Sovereign Clouds
In Soverign Clouds, `Connect-AzAccounts` fails when using `Service Principal + Federated Token`.  The issue is currently reported on [GitHub Actions](https://github.com/Azure/login/issues/355).  
If you login Soverign Clouds using federated token, Please run the following cmdlet on powershell
```pwsh
Connect-AzAccount -ServicePrincipal -Application $appId -FederatedToken $token -Environment $SoverignCloudName
```
Please you are using GitHub action, please refer to [how to test Az.Accounts-2.14.0-preivew in GitHub Actions](https://github.com/Azure/login/issues/355#issuecomment-1865516832) for more details.

## Fixed the authentication issue when using “FederatedToken” in Sovereign Clouds. 
In Soverign Clouds, `Connect-AzAccounts` is found to fail when using `Service Principal + federated token`. We also include the fix into this preivew. Please refer to https://github.com/Azure/azure-powershell/issues/23742 for more details.

**We are going to release these preview feature in next regular release in January.** Please feel free leave your comments here if you have ideas or concerns.
