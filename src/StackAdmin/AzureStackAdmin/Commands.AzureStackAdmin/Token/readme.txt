
*** BRIEF GUIDE ***
Here are sample snippets of supported arguments/modes by the cmdlet:

# PSCredential mode [upn-style] (aka. Resource Owner Password Credentials Grant flow)
$secpasswd = ConvertTo-SecureString "password_goes_here" -AsPlainText -Force
$mycreds = New-Object System.Management.Automation.PSCredential ("username@domain.com", $secpasswd)
Get-AzureRMToken -Authority https://ip_or_hostname_of_winauthsite:12998/ -Credential $mycreds


# PSCredential mode [domain\username-style] (aka. Resource Owner Password Credentials Grant flow)
$secpasswd = ConvertTo-SecureString "password_goes_here" -AsPlainText -Force
$mycreds = New-Object System.Management.Automation.PSCredential ("domain\username", $secpasswd)
Get-AzureRMToken -Authority https://ip_or_hostname_of_winauthsite:12998/ -Credential $mycreds


# PSCredential mode [username-style, ONLY available when WinAuthSite runs in LocalMachine mode] (aka. Resource Owner Password Credentials Grant flow)
$secpasswd = ConvertTo-SecureString "password_goes_here" -AsPlainText -Force
$mycreds = New-Object System.Management.Automation.PSCredential ("local_machine_username", $secpasswd)
Get-AzureRMToken -Authority https://ip_or_hostname_of_winauthsite:12998/ -Credential $mycreds


# Interactive mode [with UX prompt to collect credentials] (aka. Authorization Code Grant flow)
Get-AzureRMToken -Authority https://ip_or_hostname_of_winauthsite:12998/