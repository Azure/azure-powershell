# Authentication and Authorization in RDFE (Azure) and ARM (Az/AzureRM)
## RDFE Authorization
In RDFE, users are authorized on a per-subscription basis. Users who are authorized to access a subscription may perform any action within that subscription - on the subscription itself, or on any resources in the subscription. There is no mechanism for limiting the access of an authorized user within a subscription.
## RDFE Authentication Mechanisms
- Management Certificate Authentication
- User Authentication
### RDFE Management Certificate Authentication
Management certificate authentication is the most popular mechanism for authenticating RDFE calls for automation.  In this authentication mechanism, the public key of a management certificate is associated with one or more subscriptions.  Users in possession of the certificate private key use standard Http certificate authentication to negotiate an SSL session with the RDFE endpoint, and all subsequent calls in that session have access to any subscriptions associated with the certificate.

To acquire management certificate credentials, you must download  a PublishingProfile from the portal (using Get-AzurePublishSettingsFile, or direct download from the portal), and import it using Import-AzurePublishSettingsFile.  This downloads a file containing management certificates for selected subscriptions. Importing will automatically add each certificate as an account.

### RDFE User Authentication
The Add-AzureAccount command can be used to acquire a token based on user credentials, and if the associated user is authorized for RDFE access to a subscription (they must be a classic administrator or co-admin of the subscription), they will have access to those subscriptions authorized to their account for classic administrator access

## General Notes
- Managemnt certificate authentication lasts for an entire TCP session.  User authentication is self-renewing, just as it is in ARM.

## Programmatic Authentication for PowerShell clients
- Clients are still authenticated using an IAuthenticationFactory, and the following overload:

```c#
SubscriptionCloudCredentials GetSubscriptionCloudCredentials(IAzureContext context)
```
Note that, the ARM token audience is different than the token audience used for RDFE, although the RDFE tolken audience is accepted by both endpoints.

Similarly, RDFE clients can be created using the IClientFactory interface: 

```c#
TClient CreateClient<TClient>(IAzureContext context, string endpoint) where TClient : ServiceClient<TClient>;
```

Also note that, for management certificate authentication, authentication is performed as part of creating the http client - the ```ServiceClientCredentials``` returned above automatically apply the certificate to the http connection, which automatically performs HTTP certificate authentication using the certificate private key.  You can see this implementation here: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/mgmtcommon/ClientRuntime/ClientRuntime/CertificateCredentials.cs 
