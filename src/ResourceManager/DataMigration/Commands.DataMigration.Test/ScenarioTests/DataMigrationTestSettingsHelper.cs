// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataMigrationTestSettingsHelper.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Microsoft.Azure.Commands.ScenarioTest.DmsTest
{
    public static class DataMigrationTestSettingsHelper
    {
        /// <summary>
        /// This will set Environment variables needed for PS Test cases
        /// Make changes to this file locally,
        /// DO NOT CHECK IN This file with actual values for Environment variables
        /// </summary>
        public static void SetDmsEnvironmentVariables()
        {
            // Location for Resource/Service/Project creation
            Environment.SetEnvironmentVariable("Location", "southcentralus");

            // This will clean up any services / Resource group created from test cases
            Environment.SetEnvironmentVariable("cleanup", "true");

            //This will use existing services created for test cases, Provide ResourceGroup and ServiceName
            Environment.SetEnvironmentVariable("useExistingService", "false");

            // This will use existing ResourceGroup
            Environment.SetEnvironmentVariable("ResourceGroupName", "Add-ResourceGroup-Here");

            // This will use existing ServiceName
            Environment.SetEnvironmentVariable("ServiceName", "Add-ServiceName-Here");

            // Change this as per your test 
            Environment.SetEnvironmentVariable("VIRTUAL_SUBNET_ID", "Add-Virtual-Subnet-Id-Here");

            Environment.SetEnvironmentVariable("SQL_SOURCE_DATASOURCE", "Add-ServiceName-Here");

            Environment.SetEnvironmentVariable("SQLDB_TARGET_DATASOURCE", "Add-ServiceName-Here");

            Environment.SetEnvironmentVariable("SQL_PASSWORD", "Add-ServiceName-Here");

            Environment.SetEnvironmentVariable("SQLDB_PASSWORD", "Add-ServiceName-Here");
        }
    }
}