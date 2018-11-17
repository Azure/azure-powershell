set SUBSCRIPTIONID=%1
set TESTENV=%2
set TENANT=%3
set USERID=%4
set PASSWORD=%5

set AZURE_TEST_MODE=Record
set TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=%SUBSCRIPTIONID%;Environment=%TESTENV%;Tenant=%TENANT%;UserId=%USERID%;Password=%PASSWORD%

REM History
REM set TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=%SUBSCRIPTIONID%;AADAuthEndpoint=https://login.windows-ppe.net/;BaseUri=https://api-dogfood.resources.windows-int.net/;UserId=%USERID%;Password=%PASSWORD%
REM set TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=%SUBSCRIPTIONID%;AADAuthEndpoint=https://login.windows-ppe.net/;BaseUri=https://api-dogfood.resources.windows-int.net/;GraphResource=https://graph.ppe.windows.net/
