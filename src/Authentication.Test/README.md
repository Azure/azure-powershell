# Authentication Test

## Running Live Authentication Tests

In the [`LoginTests.cs`](.\LoginTests.cs) file, there are two tests that can be run to perform live authentication: `LoginWithUsernameAndPassword` and `LoginWithServicePrincipal`.

### Username and Password

The [`LoginWithUsernameAndPassword`](.\LoginTests.cs#L79) test simulates running the `Connect-AzAccount` cmdlet with a username and password. This test requires no additional setup; however, since the .NET Core authentication uses device code login, and because we aren't using a PowerShell widow to display messages during the test, you will need to set a breakpoint in the [`UserTokenProvider.Netcore.cs`](..\Authentication\Authentication\UserTokenProvider.Netcore.cs#L217) file where the `code` variable is used. The `Message` property of this variable contains the message that is normally displayed in .NET Core authentication, which will tell you to visit https://microsoft.com/devicelogin and enter the given code for authentication.

### Service Principal

The [`LoginWithServicePrincipal`](.\LoginTests.cs#L87) test simulates running the `Connect-AzAccount` cmdlet with a service principal. This test requires the following fields to be updated in the `LoginTests.cs` file:
- [`_tenantId`](.\LoginTests.cs#L45) - Id of the tenant that the service principal is registered to
- [`_userName`](.\LoginTests.cs#L48) - Application id of the service principal
- [`_password`](.\LoginTests.cs#L49) - Secret of the service principal

Once these values are updated, no other action is needed outside of running the test.