#!/bin/bash
azure account add --spn --appid "$spn" --secret "$secret" -t "$tenant" -s "$subscription"