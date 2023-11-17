# Azure Profiles

## Description

Azure comprises several clouds (Public, Azure Stack, Government), each of which comprises several services (APIs) that have different versions.

For a script to be compatible with several clouds, the developer has to identify, for each operation, the API version that is compatible on each cloud. The same applies if the developer wants to ensure that a script will always use a known API Version.

For example, the operation `ResourceSkus_List` that gets the list of SKUs for compute available in a subscription is exposed with the 2019-04-01 API version. The same operation is currently not exposed in Azure Stack. An application that aims a being compatible with both environments would have to refrain from using this operation. the mangement of the Azure PowerShell modules adds some extra complexity to it.

We are introducting **Azure Profiles** to help manage this complexity accross the entire set of Azure services. We are providing a set of Azure profiles that are known to work with different clouds. This preview only includes two profiles:

- Hybrid: The `hybrid-2019-03-01` profile comprises the API Versions and resources that are compatible between Azure and Azure Stack version 1904.
- Latest: The `latest-2019-04-30` profile comprises the API versions and resources that were generally availabe and stable in Public Azure as of April 30, 2019.

We will be adding profiles over time and we plan to phase out older profiles after a certain time.

## Usage

```PowerShell
Select-AzProfile -name 'hybrid-2019-03-01'
```

Only the following profiles are supported in the current preview:

```PowerShell
hybrid-2019-03-01
latest-2019-04-30
```

> **IMPORTANT NOTES:**
>
> - If you use a non supported value, the command will not return any errors and will not switch profiles.
> - The command may takes some time to be executed.

## Known Issues

The following issues have been identified with the use of Azure Profiles:

1. If you use a profile name that is not one of the supported ones, the command will not return an error and the profile will not be changed. We are tracking this with [Issue 10116](https://github.com/Azure/azure-powershell/issues/10116)

## Feedback

We want to hear from you about Azure Profiles, please read the [RFC about profiles][RFC0001] and submit comments or questions in the corresponding section.

If you are encountering issues, please [create an issue][GitHubIssues] in this repo.

<!-- References -->

<!-- Local -->
[GitHubIssues]:https://aka.ms/azps4issue
[SendFeedback]:http://aka.ms/azps4feedback
[Features]:documentation/preview/Features.md

[RFC0001]:documentation/RFC/RFC0001-Azure-Profiles.md

<!-- Exteral -->

<!-- Docs -->
[ConnectAzAccount]: https://learn.microsoft.com/en-us/powershell/module/az.accounts/connect-azaccount
