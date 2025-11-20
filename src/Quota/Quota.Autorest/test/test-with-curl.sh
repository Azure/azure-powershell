#!/bin/bash

# Simple curl test using PowerShell to get token
echo "Getting token from PowerShell..."

TOKEN=$(pwsh -c '$token = Get-AzAccessToken -ResourceUrl "https://management.azure.com"; $token.Token | ConvertFrom-SecureString -AsPlainText')

if [ -z "$TOKEN" ] || [ ${#TOKEN} -lt 100 ]; then
    echo "ERROR: Failed to get token (length: ${#TOKEN})"
    echo "Make sure you're logged in with Connect-AzAccount in PowerShell"
    exit 1
fi

echo "Token retrieved (length: ${#TOKEN})"

URL="https://management.azure.com/providers/Microsoft.Management/managementGroups/mg-demo/providers/Microsoft.Quota/groupQuotas/testlocation/subscriptionRequests?api-version=2025-09-01"

echo ""
echo "Test: Get-AzQuotaGroupQuotaSubscriptionRequest"
echo "==============================================="
echo "URL: $URL"
echo ""
curl -X GET "$URL" \
  -H "Authorization: Bearer $TOKEN" \
  -H "Content-Type: application/json" \
  -s -w "\nHTTP Code: %{http_code}\n" | jq -C '.'

echo ""
echo "Note: This API may return 401 if there are no active subscription requests"
echo "      or if async operation tokens have expired."

