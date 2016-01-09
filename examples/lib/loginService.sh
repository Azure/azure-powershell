#!/bin/bash
az account add --spn --appid "$spn" --secret "$secret" -t "$tenant" -s "$spnSubscription"