### Example 1: Create a redirect configuration object with all parameters
```powershell
New-AzFrontDoorRedirectConfigurationObject -RedirectType "PermanentRedirect" -RedirectProtocol "HttpsOnly" -CustomHost "www.example.com" -CustomPath "/newpath" -CustomQueryString "source=frontdoor&campaign=redirect" -CustomFragment "section1"
```

```output
CustomFragment    : section1
CustomHost        : www.example.com
CustomPath        : /newpath
CustomQueryString : source=frontdoor&campaign=redirect
OdataType         : #Microsoft.Azure.FrontDoor.Models.FrontdoorRedirectConfiguration
RedirectProtocol  : HttpsOnly
RedirectType      : PermanentRedirect
```

Create a comprehensive redirect configuration object that permanently redirects requests to HTTPS protocol with custom host, path, query string, and fragment.

