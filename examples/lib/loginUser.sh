#!/bin/bash
echo "Logging in as user"
azure account add -u "$azureUser" -p "$password" -s "$subscription"