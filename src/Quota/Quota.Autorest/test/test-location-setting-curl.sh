#!/bin/bash

# Script to test Azure Quota LocationSettings API directly with curl
# This bypasses the PowerShell/AutoRest layer to confirm the service issue

echo "Getting Azure access token..."
TOKEN=$(pwsh -c '(Get-AzAccessToken -ResourceUrl "https://management.azure.com").Token')

if [ -z "$TOKEN" ] || [ "$TOKEN" == "System.Security.SecureString" ]; then
    echo "ERROR: Failed to get access token. Please run 'Connect-AzAccount' first."
    exit 1
fi

echo "Token retrieved successfully (length: ${#TOKEN})"

MANAGEMENT_GROUP_ID="mg-demo"
GROUP_QUOTA_NAME="testlocation"
RESOURCE_PROVIDER="Microsoft.Compute"
LOCATION="eastus"
API_VERSION="2025-09-01"

URL="https://management.azure.com/providers/Microsoft.Management/managementGroups/${MANAGEMENT_GROUP_ID}/providers/Microsoft.Quota/groupQuotas/${GROUP_QUOTA_NAME}/resourceProviders/${RESOURCE_PROVIDER}/locationSettings/${LOCATION}?api-version=${API_VERSION}"

echo ""
echo "Testing Azure Quota LocationSettings API"
echo "========================================"
echo "URL: $URL"
echo ""

# Test 1: With enforcementEnabled = "Enabled"
echo "Test 1: enforcementEnabled = \"Enabled\""
echo "----------------------------------------"
curl -X PUT "$URL" \
  -H "Authorization: Bearer $TOKEN" \
  -H "Content-Type: application/json" \
  -d '{
    "properties": {
      "enforcementEnabled": "Enabled"
    }
  }' \
  -w "\nHTTP Status: %{http_code}\n" \
  -v 2>&1 | grep -E "HTTP|error|Error|failure|Failure" | head -20

echo ""
echo ""

# Test 2: With enforcementEnabled = "Disabled"
echo "Test 2: enforcementEnabled = \"Disabled\""
echo "-----------------------------------------"
curl -X PUT "$URL" \
  -H "Authorization: Bearer $TOKEN" \
  -H "Content-Type: application/json" \
  -d '{
    "properties": {
      "enforcementEnabled": "Disabled"
    }
  }' \
  -w "\nHTTP Status: %{http_code}\n" \
  2>&1 | grep -E "HTTP|error|Error|failure|Failure|NotAcceptable" | head -20

echo ""
echo ""

# Test 3: With enforcementEnabled = "NotAvailable"
echo "Test 3: enforcementEnabled = \"NotAvailable\""
echo "---------------------------------------------"
curl -X PUT "$URL" \
  -H "Authorization: Bearer $TOKEN" \
  -H "Content-Type: application/json" \
  -d '{
    "properties": {
      "enforcementEnabled": "NotAvailable"
    }
  }' \
  -w "\nHTTP Status: %{http_code}\n" \
  2>&1 | grep -E "HTTP|error|Error|failure|Failure" | head -20

echo ""
echo ""

# Test 4: With empty properties
echo "Test 4: Empty properties object"
echo "--------------------------------"
curl -X PUT "$URL" \
  -H "Authorization: Bearer $TOKEN" \
  -H "Content-Type: application/json" \
  -d '{
    "properties": {}
  }' \
  -w "\nHTTP Status: %{http_code}\n" \
  2>&1 | grep -E "HTTP|error|Error|failure|Failure|Required" | head -20

echo ""
echo "========================================"
echo "Testing complete"
