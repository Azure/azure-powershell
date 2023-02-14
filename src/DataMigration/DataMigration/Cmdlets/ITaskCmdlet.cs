// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITaskCmdlet.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.Azure.Management.DataMigration.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    internal interface ITaskCmdlet
    {
        ProjectTaskProperties ProcessTaskCmdlet();

        RuntimeDefinedParameterDictionary RuntimeDefinedParams { get; }
    }
}
