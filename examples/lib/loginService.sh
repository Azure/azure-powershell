#!/bin/env/bash
az login --spn --appid "$spn" --secret "$secret" -t "$tenant" -s "$spnSubscription"