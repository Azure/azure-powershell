#  Azure PowerShell Exceptions

## What are Azure PowerShell Exceptions?

Azure PowerShell defines most commonly used exceptions, all of which inherit from the *[IContainsAzPSErrorData](https://learn.microsoft.com/dotnet/api/microsoft.azure.commands.common.icontainsazpserrordata?view=az-ps-latest)* interface. This interface includes telemetry data. Developers working on Azure PowerShell should use these exceptions during development, rather than other more generic exceptions.


| Azure PowerShell Exception Type | Default Error Kind | Mandatory Properties | When to Use it? |
|--|--|--|--|
| AzPSCloudException | Service | HttpStatusCode | This exception should be thrown for getting incorrect http response from Azure service. |
| AzPSAuthenticationFailedException | Internal | AuthErrorCode | This exception should be thrown for authentication failures in Azure PowerShell. |
| AzPSResourceNotFoundCloudException | User |  | This exception should be thrown when the resource is not found by Azure service. |
| AzPsArgumentException | User | ParamName | This exception should be thrown for errors in an arithmetic, casting, or conversion operation. |
| AzPSArgumentNullException | User | ParamName | This exception should be thrown when a null reference (Nothing in Visual Basic) is passed to a method that does not accept it as a valid argument. |
| AzPSArgumentOutOfRangeException | User | ParamName | This exception should be thrown when the argument is out of range. |
| AzPSException | N/A |  | This exception should be thrown when errors occur during application execution. |
| AzPSInvalidOperationException | Internal |  | This exception should be thrown when a method call is invalid for the object's current state. |
| AzPSIOException | User |  | This exception should be thrown when an I/O error occurs. |
| AzPSKeyNotFoundException | Internal | MapKeyName | This exception should be thrown when the key specified for accessing an element in a collection does not match any key in the collection. |
| AzPSApplicationException | Internal |  | This exception is representative of ApplicationException in Azure PowerShell. |
| AzPSFileNotFoundException | User | FileName (Not full path) | This exception should be thrown when accessing a file that does not exist. |

There are three types of errors in Azure PowerShell.
- **User Error**: The error is caused by user.
- **Service Error**: The error is caused by Azure services.
- **Internal Error**: other errors.

## How to use Azure PowerShell Exception?

- An code example for *AzPSArgumentException*

The source code is from [NewAzureRmAks.cs](https://github.com/Azure/azure-powershell/blob/77b1e37e11179e59333edd825b2459435cab8726/src/Aks/Aks/Commands/NewAzureRmAks.cs).

```csharp
throw new AzPSArgumentException(
    Resources.AksNodePoolAutoScalingParametersMustAppearTogether,
    nameof(EnableNodeAutoScaling),
    desensitizedMessage: Resources.AksNodePoolAutoScalingParametersMustAppearTogether);
``````

- An code example for from *AzPSCloudException*

The source code is [KubeCmdletBase.cs](https://github.com/Azure/azure-powershell/blob/77b1e37e11179e59333edd825b2459435cab8726/src/Aks/Aks/Commands/KubeCmdletBase.cs).

```csharp
var newEx = new AzPSCloudException(Resources.K8sVersionNotSupported, Resources.K8sVersionNotSupported, ex)
    {
        Request = ex.Request,
        Response = ex.Response,
        Body = ex.Body,
    };
throw newEx;
``````

- An code example for *AzPSResourceNotFoundCloudException*

The source code is from [KubeCmdletBase.cs](https://github.com/Azure/azure-powershell/blob/77b1e37e11179e59333edd825b2459435cab8726/src/Aks/Aks/Commands/KubeCmdletBase.cs).

```csharp
var newEx = new AzPSResourceNotFoundCloudException(ex.Message, innerException: ex)
    {
        Request = ex.Request,
        Response = ex.Response,
        Body = ex.Body,
    };
throw newEx;
``````

## Why to use Azure PowerShell Exception?

Providing detailed error information is helpful for developers to pinpoint the root cause of errors. However, due to GDPR (General Data Protection Regulation), we do not record client's detailed error messages in telemetry data. To assist developers in more efficiently locating errors, we define unified exception interfaces that includes additional error details without containing any sensitive information.

### Azure PowerShell Exception Telemetry Data

- An exception telemetry example for *AzPSArgumentException*

```json
{
"exception-data": "ParamName=context.Account;ErrorKind=User;ErrorLineNumber=289;ErrorFileName=AuthenticationFactory",
"exception-type": "Microsoft.Azure.Commands.Common.Exceptions.AzPSArgumentException"
}
``````

- An exception telemetry example for generic *ArgumentException*

```json
{
"exception-type": "System.ArgumentException"
}
``````

Refer to [Azure PowerShell Telemetry](https://eng.ms/docs/cloud-ai-platform/azure-core/azure-management-and-platforms/control-plane-bburns/azure-cli-tools-azure-cli-powershell-and-terraform/azure-cli-tools/teams_docs/azps_docs/telemetry#client-side-telemetry) for more telemetry details.