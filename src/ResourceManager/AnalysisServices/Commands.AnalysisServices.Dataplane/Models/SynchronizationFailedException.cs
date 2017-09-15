using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Azure.Commands.AnalysisServices.Dataplane.Properties;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane.Models
{
    public class SynchronizationFailedException : Exception
    {
        public SynchronizationFailedException()
            : base(Resources.SynchronizationFailedException)
        {
        }

        public SynchronizationFailedException(Exception e)
            : base(Resources.SynchronizationFailedException, e)
        {
        }

        public SynchronizationFailedException(string messageDetails)
            : base(messageDetails)
        {
        }

    }
}
