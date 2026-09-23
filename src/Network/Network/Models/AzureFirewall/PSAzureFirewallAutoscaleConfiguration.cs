namespace Microsoft.Azure.Commands.Network.Models
{
    using System;
    using System.Management.Automation;

    public class PSAzureFirewallAutoscaleConfiguration
    {
        public const int AbsoluteMinCapacity = 2;

        private int? minCapacity;
        private int? maxCapacity;

        public int? MinCapacity
        {
            get
            {
                return this.minCapacity;
            }
            set
            {
                ValidateCapacity(value);
                minCapacity = value;
            }
        }

        public int? MaxCapacity
        {
            get
            {
                return this.maxCapacity;
            }
            set
            {
                ValidateCapacity(value);
                maxCapacity = value;
            }
        }

        private void ValidateCapacity(int? capacity)
        {
            if (capacity.HasValue)
            {
                if (capacity < 2)
                {
                    throw new PSArgumentException(String.Format("\'{0}\' is below the service minimum of \'{1}\'", capacity, AbsoluteMinCapacity));
                }
            }
        }
    }
}
