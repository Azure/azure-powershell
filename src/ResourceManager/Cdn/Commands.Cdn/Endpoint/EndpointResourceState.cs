////////////////////////////////////////////////////////////////////////////////
//
// Copyright (C) Microsoft Corporation. All rights reserved.
//
////////////////////////////////////////////////////////////////////////////////

namespace Microsoft.Azure.Cdn.Services.ResourceProvider.Models.EndpointModels
{
    public enum EndpointResourceState
    {
        Creating,
        Deleting,
        Running,
        Starting,
        Stopped,
        Stopping
    }
}
