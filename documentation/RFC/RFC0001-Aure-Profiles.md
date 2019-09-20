---
RFC: RFC0001
Author: Azure PowerShell team
Status:  Draft
SupercededBy: n/a
Version: 1.0
---

# Enable Azure Profiles with Azure PowerShell

Azure comprises several clouds (Public, Azure Stack, Government), each of which comprises several services (APIs) that have different versions.

Writing an application or a script that is compatible with several clouds can quickly become a very complex task as the developer has to identify for each operation to be performed which API version is compatible on each cloud. Since most applications and services in Azure require a set of resources from different services, managing the api-versions of each needed service API in a script quickly multiplies this complexity.
As Azure evolves, existing services will expose new resources or properties and potentially change how to interact with those, subject to breaking changes. We are adding the support of Azure profiles in Azure PowerShell. An Azure profiles is a definition of resources providers and associated API Version.

Using a profile, a PowerShell script will be attached to a set of known API versions bringing the follwing benefits:

- Compatibility with a specific version of Azure. For example the profile namde `hybrid-2019-03-01`  that will make a script compatible with Azure Stack on version 1904 and above.
- Stability over time. Your script will be shielded from changes happening in the cloud, but still be able to consume the latest bug fixes. However, in order to be able to use the newer capabilities of Azure, a different profile would have to be selected.

New profiles will be added on a regular cadence that still needs to be defined and old profiles will be kept available in the latest Azure PowerShell module for some months.

## Motivation

The support of Azure profiles will enable the following scenarios.

```code
As a PowerShell script developer
I can attach my script to a profile of Azure
so that my script does not break when Azure changes
```

```code
As a PowerShell script developer
I can select a a profile of Azure
so that my script will run seamlessly on Azure Stack or Azure Sovereign clouds and Public Azure
```

## User Experience

Example of the user experience with code sample

```PowerShell
Select-AzureProfile -name 'hybrid-2019-03-01'
```

## Comments and Questions

Please insert below your anwser to the following questions or add any additional questions that you may have:

- What is your prefered cadence for updating the profiles?

  - _Your prefered cadence_

- How long would you like to see a profile to be maintained?

  - _Your prefered lifetime_

## Specifications

## Alernate proposals and considerations
