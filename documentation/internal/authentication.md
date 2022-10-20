# Authentication
## Overview

All authentication in PowerShell follows the same basic method. All requests are authenticated with a token, that is provided by a token service.  The token identifies the principal, and the services (also called resources) that the user wants to access (and the STS can verify that the user is registered to access).  Services use this token to identify the principal, and associate the user with the appropriate authorization level.  Authorization is managed separately, by each service, and is not part of this discussion.

This document breaks down PowerShell Authentication into the following sections
- Abstractions - Discusses the Concepts used in authenticating a user
- Authentication Scenarios - Discusses the various authentication methods that can be used by each kind of principal
  - User Authentication
  - Service Authentication
  - MSI Authentication
  - Token Authentication
- MSAL Authentication - Discusses how these scenarios differ in MSAL

## Abstractions

### Context
The context is the default target of any cmdlet executed in PowerShell.  It consists of the [`Account`](#account), [`Tenant`](#tenant]), [`Environment`](#environment),  and [`Subscription`](#subscription) that the user has selected using the `Select-AzContext` or `Select-AzSubscription` cmdlets.  It also contains a reference to the token cache that is used in Authentication.  For most cmdlets, the subscription or tenant they target for their calls is the subscription/tenant in the `Default` Context.

### ContextContainer
A context container is a collection of contexts - it contains a dictionary associating its context with a unique key, and a `Default` context which is the context currently selected.  The user can switch between any contexts in the container without additional login.  The ContextContainer is populated when the user authenticates for the first time.

### Account
An account is the representation of the principal used for authentication.  This can be a User Account, a Service Principal, a Managed Service Identity, or a raw token.  The primary key for Account is a name. In the case of user authentication, this will be of the form ```<user>@<domain>```, for example ```user1@contoso.org```.  For service principal authentication, the name is the oid of the service principal object.  In the case of MSI, the name can be the oid, clientId, or resource id of the associated MSI.  For tokens, the name is the token hash.

### Subscription
A subscription represents a subscription in Azure, it has properties indicating ID, Name, and State. The default subscription (that is the description in the  `Default` context) will be the target of all cmdlets.

### Environment
An Environment is a particular Azure cloud that is targeted for commands.  'AzureCloud' is the default environment if none is selected.  Built-in clouds also include 'AzureChinaCloud' and 'AzureUSGovernment' cloud.  Each environment contains the endpoints for services on that cloud, the 'resourceId' that is required when authenticating for that service, and a set of domain suffixes that can be used to determine data plane service endpoints (for example, the StorageEndpointSuffix can be appended to a storage account name to get the default domain name of the endpoints for that storage account).

### Tenant
A Tenant represents an Active Directory tenant that may contain one or more subscriptions.  When authenticating, a user may have access to multiple tenants, and the default ContextContainer will contain all of the tenants (and associated subscriptions) the user has access to.

### Caching
Each context contains a reference to the currently active TokenCache - this allows common Authentication methods to retrieve tokens for the given context when it is passed in to common methods.

### AuthenticationFactory

The Authentication Factory is a central abstraction used by all modules to acquire authentication tokens for their calls to Azure services.  This abstract factory is used by Az.Accounts to do initial login and context acquisition, and by service modules to acquire tokens using the currently selected context for their Azure requests (management and data plane).  Generally, a client needs to pass in the current context and an indication of what service the user want to authenticate with to get back authentication tokens.

Generally, the types returned by the Authentication Factory encapsulate the actual tokens, so that tokens can be automatically renewed as requests are made without additional explicit calls from the service module.

## Authentication Scenarios

### User Authentication
In User Authentication, Azure PowerShell authenticates on behalf of a user in the authenticating tenant.  The privileges granted will be those privileges that the user is assigned.

#### Overview
In user authentication, powershell authenticates to the tenant on behalf of the user.  The authentication methods are essentially mechanisms for the user to supply their credentials for authentication.

#### Interactive Authentication
In this mechanism, the user is presented with a browser window pointing at the authentication website to provide credentials.  PowerShell supplies a callback that the token service calls once authentication is complete, returning the authentication results.  This callback must match one of the 'replyUrls' configured for the application.  In PowerShell's case, this configuration is in the first party app registration for PowerShell.

#### Username/Password Authentication
In this mechanism, the user provides a PSCredential with username and password, and powershell authenticates with the token service on the user's behalf.  This authentication mechanism is not encouraged, because it precludes the use of multi-factor authentication (MFA), which is a security best practice.  However, it is still used in some legacy customer scenarios.

#### DeviceCode Authentication
In this mechanism, the user is given a URI and a code.  They must open a browser and navigate to the given URI and supply the given code, then they proceed with interactive authentication as above.  DeviceCode authentication is useful for remote terminal access, as the user can authenticate on a remote machine using their local browser.

### Service Authentication
Service authentication authenticates PowerShell as a service principal, rather than a user principal.  Service Principal authentication is the recommended method for authenticating scripts that are executed without interaction (for example, scripts run on a particular schedule, or automatically triggered by a particular event).  This is because the service used to authenticate may be restricted to only those functions required by the specific script.  Additionally, service principal authentication returns authentication tokens, but never renewal tokens.

In service authentication, the script must present the service id and a credential - either a secret string, or a certificate private key, depending on how the service principal is configured.  The token service returns a token.  Note that, for all of the common code methods used for authentication, service principal credentials are stored in the output type, so that a new token can be automatically acquired when the access token expires, transparently to the user of the returned token abstraction. 

### MSI Authentication
MSI authentication is essentially a managed version of service authentication.  An Azure resource (such as a VM or AppService) is assigned a service principal, and the credentials of the service principal are managed without the user's intervention.  This allows credentials to be propagated to a VM and rotated without the user's intervention or knowledge.

Any code running on an Azure Resource associated with an MSI may acquire a token using a GET request to the local token service on that resource.  The token service then authenticates using the underlying service principal and credential, and returns the authentication result as the response to the GET request.  As with other authentication types, all MSI authentication performed by common code returns an abstraction over the token that automatically and transparently renews the token when needed (by making additional calls to the local token service).

### Token Authentication
In token authentication, the user simply provides an access token that want to use for accessing Azure.  The token the user supplies in `Connect-AzAccount` is simply added to the Authorization header for requests.  Generally, the user is allowed to provide one token for each of the services that they need to authenticate wth (ARM, Graph, KeyVault, etc.).  While, for parallelism, this authentication type also returns an abstraction that allows the user to renew tokens, token renewal will always fail, since no refresh token is provided, and no credential is provide that would allow re-authentication.  

Use of token authentication is an advanced scenario.

## MSAL Authentication
TBD
