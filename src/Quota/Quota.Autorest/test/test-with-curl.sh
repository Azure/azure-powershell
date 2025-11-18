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

URL="https://management.azure.com/providers/Microsoft.Management/managementGroups/mg-demo/providers/Microsoft.Quota/groupQuotas/testlocation/resourceProviders/Microsoft.Compute/locationSettings/eastus?api-version=2025-09-01"

echo ""
echo "Test 1: enforcementEnabled = 'Enabled'"
echo "========================================"
curl -X PUT "$URL" \
  -H "Authorization: Bearer $TOKEN" \
  -H "Content-Type: application/json" \
  -d '{"properties":{"enforcementEnabled":"Enabled"}}' \
  -s -w "\nHTTP Code: %{http_code}\n"

echo ""
echo ""
echo "Test 2: enforcementEnabled = 'Disabled'"
echo "========================================"
curl -X PUT "$URL" \
  -H "Authorization: Bearer $TOKEN" \
  -H "Content-Type: application/json" \
  -d '{"properties":{"enforcementEnabled":"Disabled"}}' \
  -s -w "\nHTTP Code: %{http_code}\n"
