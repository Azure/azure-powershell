# Transition to `SecureString` in Azure PowerShell

- [Transition to `SecureString` in Azure PowerShell](#transition-to-securestring-in-azure-powershell)
  - [Introduction](#introduction)
  - [General Transition Approach](#general-transition-approach)
    - [**Two-Step Transition Strategy**](#two-step-transition-strategy)
    - [**Impact on Users**](#impact-on-users)
    - [**Best Practices**](#best-practices)
  - [Affected Modules and Cmdlets](#affected-modules-and-cmdlets)
    - [`<Module>`](#module)
      - [`<Cmdlet>`](#cmdlet)
        - [Input Parameter `<parameterName>`](#input-parameter-parametername)
        - [Output Property `<propertyName>`](#output-property-propertyname)
    - [Az.App](#azapp)
      - [New-AzContainerAppConnectedEnvStorage](#new-azcontainerappconnectedenvstorage)
        - [Input Parameter `AzureFileAccountKey`](#input-parameter-azurefileaccountkey)
      - [New-AzContainerAppManagedEnvStorage](#new-azcontainerappmanagedenvstorage)
        - [Input Parameter `AzureFileAccountKey`](#input-parameter-azurefileaccountkey-1)
      - [Update-AzContainerAppConnectedEnvStorage](#update-azcontainerappconnectedenvstorage)
        - [Input Parameter `AzureFileAccountKey`](#input-parameter-azurefileaccountkey-2)
      - [Update-AzContainerAppManagedEnvStorage](#update-azcontainerappmanagedenvstorage)
        - [Input Parameter `AzureFileAccountKey`](#input-parameter-azurefileaccountkey-3)
    - [Az.EventHub](#azeventhub)
      - [`Get-AzEventHubKey`](#get-azeventhubkey)
        - [Output Property`PrimaryKey` \& `SecondaryKey` \& `PrimaryConnectionString` \& `SecondaryConnectionString`](#output-propertyprimarykey--secondarykey--primaryconnectionstring--secondaryconnectionstring)
  - [Converting Between `String` and `SecureString` on Different PowerShell Platforms](#converting-between-string-and-securestring-on-different-powershell-platforms)
    - [**PowerShell 7 (Cross-Platform)**](#powershell-7-cross-platform)
      - [**Example: Convert `String` to `SecureString` (Same as Windows PowerShell)**](#example-convert-string-to-securestring-same-as-windows-powershell)
      - [**Example: `SecureString` to Plain Text**](#example-securestring-to-plain-text)
    - [**PowerShell 5.1 (Windows PowerShell)**](#powershell-51-windows-powershell)
      - [**Example: Convert Plain Text to `SecureString` (Same as PowerShell 7)**](#example-convert-plain-text-to-securestring-same-as-powershell-7)
      - [**Example: Convert Plain Text to SecureString**](#example-convert-plain-text-to-securestring)
  - [Deprecation Timeline](#deprecation-timeline)
  - [FAQ](#faq)
    - [**Why is this change necessary?**](#why-is-this-change-necessary)
    - [**What happens if I don't update my scripts?**](#what-happens-if-i-dont-update-my-scripts)
    - [**How do I update my scripts?**](#how-do-i-update-my-scripts)
  - [Additional Resources](#additional-resources)
  - [Feedback \& Support](#feedback--support)

## Introduction

- **Target Audience**: Azure PowerShell users.
- **Purpose**: This guide explains how to handle the transition from `string` to `SecureString` for input parameters and output properties in Azure PowerShell cmdlets.
- **Reason for Change**: To enhance security when handling secrets in Azure PowerShell.
- **Scope**: This transition spans multiple Azure PowerShell versions and will be continuously maintained.

## General Transition Approach

### **Two-Step Transition Strategy**

- **Phase 1**: Introduce `SecureString` properties/parameters alongside existing `string` types.
- **Phase 2**: Remove `string` properties/parameters in a major release.

### **Impact on Users**

After the **Phase 1** release, both `String` and `SecureString` types will coexist.  
At the same time, users will see an **upcoming breaking change message**, prompting them to replace `String` usage with `SecureString`.  
At this stage, users can refer to the examples on this page to update their scripts accordingly.

After the **Phase 2** release, this change becomes a **breaking change**.  
If users have already updated their scripts after **Phase 1**, they will not be affected.  
However, if they have not made the necessary updates, their scripts will fail.

### **Best Practices**

Once you see a breaking change message related to SecureString, immediately search this page for relevant information and update your script.

## Affected Modules and Cmdlets

### `<Module>`

#### `<Cmdlet>`

##### Input Parameter `<parameterName>`

##### Output Property `<propertyName>`

### Az.App

#### New-AzContainerAppConnectedEnvStorage

##### Input Parameter `AzureFileAccountKey`

|         | Az Version         | Az.App Version   |
| ------- | ------------------ | ---------------- |
| Phase 1 | `[13.3.0, 15.0.0)` | `[2.1.0, 4.0.0)` |
| Phase 2 | ≥ 15.0.0           | ≥ 4.0.0          |

**Old Usage (Before Phase 1)**

```powershell
$storageAccountKey = "myStorageAccountKey"

New-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName <ConnectedEnvironmentName> -ResourceGroupName <ResourceGroupName> -Name <Name> -AzureFileAccessMode <AzureFileAccessMode> -AzureFileAccountKey $storageAccountKey -AzureFileAccountName <AzureFileAccountName> -AzureFileShareName <AzureFileShareName>
```

**New Usage (After Phase 1)**

```powershell
$storageAccountKey = "myStorageAccountKey" | ConvertTo-SecureString -AsPlainText

New-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName <ConnectedEnvironmentName> -ResourceGroupName <ResourceGroupName> -Name <Name> -AzureFileAccessMode <AzureFileAccessMode> -AzureFileAccountKeySecure $storageAccountKey -AzureFileAccountName <AzureFileAccountName> -AzureFileShareName <AzureFileShareName>
```

#### New-AzContainerAppManagedEnvStorage

##### Input Parameter `AzureFileAccountKey`

|         | Az Version         | Az.App Version   |
| ------- | ------------------ | ---------------- |
| Phase 1 | `[13.3.0, 15.0.0)` | `[2.1.0, 4.0.0)` |
| Phase 2 | ≥ 15.0.0           | ≥ 4.0.0          |

**Old Usage (Before Phase 1)**

```powershell
$storageAccountKey = "myStorageAccountKey"

New-AzContainerAppManagedEnvStorage -EnvName <EnvName> -ResourceGroupName <ResourceGroupName> -Name <Name> -AzureFileAccessMode <AzureFileAccessMode> -AzureFileAccountKey $storageAccountKey -AzureFileAccountName <AzureFileAccountName> -AzureFileShareName <AzureFileShareName>
```

**New Usage (After Phase 1)**

```powershell
$storageAccountKey = "myStorageAccountKey" | ConvertTo-SecureString -AsPlainText

New-AzContainerAppManagedEnvStorage -EnvName <EnvName> -ResourceGroupName <ResourceGroupName> -Name <Name> -AzureFileAccessMode <AzureFileAccessMode> -AzureFileAccountKeySecure $storageAccountKey -AzureFileAccountName <AzureFileAccountName> -AzureFileShareName <AzureFileShareName>
```

#### Update-AzContainerAppConnectedEnvStorage

##### Input Parameter `AzureFileAccountKey`

|         | Az Version         | Az.App Version   |
| ------- | ------------------ | ---------------- |
| Phase 1 | `[13.3.0, 15.0.0)` | `[2.1.0, 4.0.0)` |
| Phase 2 | ≥ 15.0.0           | ≥ 4.0.0          |

**Old Usage (Before Phase 1)**

```powershell
$storageAccountKey = "myStorageAccountKey"

Update-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName <ConnectedEnvironmentName> -ResourceGroupName <ResourceGroupName> -Name <Name> -AzureFileAccessMode <AzureFileAccessMode> -AzureFileAccountKey $storageAccountKey -AzureFileAccountName <AzureFileAccountName> -AzureFileShareName <AzureFileShareName>
```

**New Usage (After Phase 1)**

```powershell
$storageAccountKey = "myStorageAccountKey" | ConvertTo-SecureString -AsPlainText

Update-AzContainerAppConnectedEnvStorage -ConnectedEnvironmentName <ConnectedEnvironmentName> -ResourceGroupName <ResourceGroupName> -Name <Name> -AzureFileAccessMode <AzureFileAccessMode> -AzureFileAccountKeySecure $storageAccountKey -AzureFileAccountName <AzureFileAccountName> -AzureFileShareName <AzureFileShareName>
```

#### Update-AzContainerAppManagedEnvStorage

##### Input Parameter `AzureFileAccountKey`

|         | Az Version         | Az.App Version   |
| ------- | ------------------ | ---------------- |
| Phase 1 | `[13.3.0, 15.0.0)` | `[2.1.0, 4.0.0)` |
| Phase 2 | ≥ 15.0.0           | ≥ 4.0.0          |

**Old Usage (Before Phase 1)**

```powershell
$storageAccountKey = "myStorageAccountKey"

Update-AzContainerAppManagedEnvStorage -EnvName <EnvName> -ResourceGroupName <ResourceGroupName> -Name <Name> -AzureFileAccessMode <AzureFileAccessMode> -AzureFileAccountKey $storageAccountKey -AzureFileAccountName <AzureFileAccountName> -AzureFileShareName <AzureFileShareName>
```

**New Usage (After Phase 1)**

```powershell
$storageAccountKey = "myStorageAccountKey" | ConvertTo-SecureString -AsPlainText

Update-AzContainerAppManagedEnvStorage -EnvName <EnvName> -ResourceGroupName <ResourceGroupName> -Name <Name> -AzureFileAccessMode <AzureFileAccessMode> -AzureFileAccountKeySecure $storageAccountKey -AzureFileAccountName <AzureFileAccountName> -AzureFileShareName <AzureFileShareName>
```

### Az.EventHub

#### `Get-AzEventHubKey`

##### Output Property`PrimaryKey` & `SecondaryKey` & `PrimaryConnectionString` & `SecondaryConnectionString`

|         | Az Version         | Az.EventHub Version |
| ------- | ------------------ | ------------------- |
| Phase 1 | `[13.3.0, 14.0.0)` | `[5.2.0, 6.0.0)`    |
| Phase 2 | ≥ 14.0.0           | ≥ 6.0.0             |

| Old Property Name         | New Property Name               |
| ------------------------- | ------------------------------- |
| PrimaryKey                | PrimaryKeySecure                |
| SecondaryKey              | SecondaryKeySecure              |
| PrimaryConnectionString   | PrimaryConnectionStringSecure   |
| SecondaryConnectionString | SecondaryConnectionStringSecure |

- If the property will be converted to SecureString in the original script

  **Old Usage (Before Phase 1)**

  ```powershell
  $keys = Get-AzEventHubKey -ResourceGroupName <ResourceGroupName> -NamespaceName <NamespaceName> -AuthorizationRuleName <AuthorizationRuleName>
  $key1  = ConvertTo-SecureString -String $keys.PrimaryKey -AsPlainText -Force
  $key2  = ConvertTo-SecureString -String $keys.SecondaryKey -AsPlainText -Force
  $connectionString1  = ConvertTo-SecureString -String $keys.PrimaryConnectionString -AsPlainText -Force
  $connectionString2  = ConvertTo-SecureString -String $keys.SecondaryConnectionString -AsPlainText -Force
  # use $key1 & $key2 & $connectionString1 & $connectionString2
  ```

  **New Usage (After Phase 1)**

  ```powershell
  $keys = Get-AzEventHubKey -ResourceGroupName <ResourceGroupName> -NamespaceName <NamespaceName> -AuthorizationRuleName <AuthorizationRuleName>
  # use $keys.PrimaryKeySecure
  # use $keys.SecondaryKeySecure
  # use $keys.PrimaryConnectionStringSecure
  # use $keys.SecondaryConnectionStringSecure
  ```

- If the property will be used directly in the original script
  **Old Usage (Before Phase 1)**

  ```powershell
  $keys = Get-AzEventHubKey -ResourceGroupName <ResourceGroupName> -NamespaceName <NamespaceName> -AuthorizationRuleName <AuthorizationRuleName>
  $key1  = $keys.PrimaryKey
  $key2  = $keys.SecondaryKey
  $connectionString1  = $keys.PrimaryConnectionString
  $connectionString2  = $keys.SecondaryConnectionString
  # use $key1 & $key2 & $connectionString1 & $connectionString2
  ```

  **New Usage (After Phase 1)**

  ```powershell
  $keys = Get-AzEventHubKey -ResourceGroupName <ResourceGroupName> -NamespaceName <NamespaceName> -AuthorizationRuleName <AuthorizationRuleName>
  $key1  = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto([System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($keys.PrimaryKeySecure))
  $key2  = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto([System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($keys.SecondaryKeySecure))
  $connectionString1  = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto([System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($keys.PrimaryConnectionStringSecure))
  $connectionString2  = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto([System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($keys.SecondaryConnectionStringSecure))
  # use $key1 & $key2 & $connectionString1 & $connectionString2
  ```

## Converting Between `String` and `SecureString` on Different PowerShell Platforms

The method for converting between `String` and `SecureString` varies across different PowerShell platforms.

### **PowerShell 7 (Cross-Platform)**

#### **Example: Convert `String` to `SecureString` (Same as Windows PowerShell)**

```powershell
$secureString = ConvertTo-SecureString -String "MySecretString" -AsPlainText -Force
```

#### **Example: `SecureString` to Plain Text**

```powershell
$MySecretString = ConvertFrom-SecureString -SecureString $secureString -AsPlainText
```

or

```powershell
# Same as Windows PowerShell
$MySecretString = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto([System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($secureString))
```

### **PowerShell 5.1 (Windows PowerShell)**

#### **Example: Convert Plain Text to `SecureString` (Same as PowerShell 7)**

```powershell
$secureString = ConvertTo-SecureString -String "MySecretString" -AsPlainText -Force
```

#### **Example: Convert Plain Text to SecureString**

```powershell
$MySecretString = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto([System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($secureString))
```

## Deprecation Timeline

- **Azure PowerShell Version Timeline**
- **Key Dates for Transition**
- **Future Plans for `SecureString` Implementation**

## FAQ

### **Why is this change necessary?**

When you interact with Azure resources using Azure PowerShell, some cmdlets may inadvertently expose sensitive information or secrets in their output. This includes passwords, tokens, connection strings, and other confidential data.

Additionally, some cmdlets accept plain text parameters to handle sensitive information or secrets. This can introduce security risks when these values are passed within a script's execution context.

This issue is particularly severe in automated environments, such as **GitHub Actions**, **Azure Pipelines**, and other CI/CD systems. These platforms often log command outputs by default, which may inadvertently expose secret strings.

To mitigate these risks, **Azure PowerShell** needs to convert identified `string` properties and parameters that represent secrets into `SecureString`.

### **What happens if I don't update my scripts?**

After the **Phase 1** changes are released, if you do not update your script, it will continue to run as expected without any issues.

However, after the **Phase 2** changes are released, if you still have not updated your script, it will fail to execute.

### **How do I update my scripts?**

After the **Phase 1** release, you will see an **upcoming breaking change** message when executing the affected cmdlets. At this point, you can search this page for information related to the specific cmdlet.

In most cases, we will provide detailed steps for updating your scripts accordingly. If you encounter any issues, feel free to leave a comment.

## Additional Resources

- [`SecureString` in PowerShell](https://learn.microsoft.com/dotnet/api/system.security.securestring#how-secure-is-securestring)
- [ConvertTo-SecureString](https://learn.microsoft.com/powershell/module/microsoft.powershell.security/convertto-securestring)
- [ConvertFrom-SecureString](https://learn.microsoft.com/powershell/module/microsoft.powershell.security/convertfrom-securestring)

## Feedback & Support

- **Where to Report Issues**
  - If you encounter any issues, please create an issue in the [Azure/azure-powershell](https://github.com/Azure/azure-powershell) repository.
- **How to Provide Feedback**
  - If you have any questions or suggestions, you can reply on this page.
- **Report new secrets**
  - If you find any property or parameter that is actually a secret but is defined as a string, please reply on this page.
