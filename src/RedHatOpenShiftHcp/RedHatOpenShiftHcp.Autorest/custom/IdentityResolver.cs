// ----------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the Apache License, Version 2.0 (the "License"); see LICENSE for details.
// ----------------------------------------------------------------------------------
//
// Shared helper for the C2/C3 cluster identity customizations (New-/Update-Cluster).
// Mirrors the CLI's _resolve_identity_resource_id: a user-assigned managed identity (UAMI) value may be
// a full ARM resource ID or a bare name; a bare name is expanded to a full resource ID using the
// subscription + resource group parsed from the cluster's subnet ID.
//
// Targets netstandard2.0 / C# 7.1 (module csproj). No external dependencies.

using System;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.Custom
{
    public static class IdentityResolver
    {
        private static readonly Regex ScopeRx = new Regex(
            @"^/subscriptions/(?<sub>[^/]+)/resourceGroups/(?<rg>[^/]+)/",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        /// <summary>
        /// Return <paramref name="value"/> unchanged if it is already a resource ID; otherwise treat it as a
        /// bare UAMI name and build the full resource ID from the subscription/RG parsed from
        /// <paramref name="subnetId"/>.
        /// </summary>
        public static string Resolve(string value, string subnetId)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }
            // Already a UAMI resource ID (or any full ARM id) -> leave as-is.
            if (value.IndexOf("/providers/Microsoft.ManagedIdentity/userAssignedIdentities/", StringComparison.OrdinalIgnoreCase) >= 0
                || value.StartsWith("/subscriptions/", StringComparison.OrdinalIgnoreCase))
            {
                return value;
            }
            if (string.IsNullOrWhiteSpace(subnetId))
            {
                throw new InvalidOperationException(
                    "Cannot resolve the bare identity name '" + value + "' because -PlatformSubnetId was not provided.");
            }
            var m = ScopeRx.Match(subnetId);
            if (!m.Success)
            {
                throw new InvalidOperationException(
                    "Cannot parse subscription/resource group from subnet ID '" + subnetId +
                    "' to resolve identity name '" + value + "'.");
            }
            return "/subscriptions/" + m.Groups["sub"].Value +
                   "/resourceGroups/" + m.Groups["rg"].Value +
                   "/providers/Microsoft.ManagedIdentity/userAssignedIdentities/" + value;
        }
    }
}
