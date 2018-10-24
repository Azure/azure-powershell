// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemUtility.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <summary>
//   Defines the SystemUtility type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.StorageSync.Common
{
    using System;
    using System.Net;
    using System.Net.NetworkInformation;

    /// <summary>
    /// Helper class for handling all registry related operations.
    /// </summary>
    public static class SystemUtility
    {
        public static string GetMachineName()
        {
            var machineName = string.Empty;

            try
            {
                IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();

                if (ipGlobalProperties != null)
                {
                    string hostName = Dns.GetHostName();

                    string domainNameSuffix = $".{ipGlobalProperties.DomainName}";

                    if (!hostName.EndsWith(domainNameSuffix, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(ipGlobalProperties.DomainName))
                    {
                        hostName += domainNameSuffix;
                    }

                    machineName = hostName;
                }
            }
            catch (Exception)
            {
                machineName = Environment.MachineName;
            }

            return machineName;
        }

    }
}