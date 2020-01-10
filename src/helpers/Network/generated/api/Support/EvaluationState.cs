namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Support
{

    public partial struct EvaluationState :
        System.IEquatable<EvaluationState>
    {
        /// <summary>FIXME: Field Completed is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState Completed = @"Completed";

        /// <summary>FIXME: Field InProgress is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState InProgress = @"InProgress";

        /// <summary>FIXME: Field NotStarted is MISSING DESCRIPTION</summary>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState NotStarted = @"NotStarted";

        /// <summary>the value for an instance of the <see cref="EvaluationState" /> Enum.</summary>
        private string _value { get; set; }

        /// <summary>Conversion from arbitrary object to EvaluationState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="EvaluationState" />.</param>
        /// <returns>FIXME: Method CreateFrom <returns> is MISSING DESCRIPTION</returns>
        internal static object CreateFrom(object value)
        {
            return new EvaluationState(System.Convert.ToString(value));
        }

        /// <summary>Compares values of enum type EvaluationState</summary>
        /// <param name="e">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public bool Equals(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState e)
        {
            return _value.Equals(e._value);
        }

        /// <summary>Compares values of enum type EvaluationState (override for Object)</summary>
        /// <param name="obj">the value to compare against this instance.</param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public override bool Equals(object obj)
        {
            return obj is EvaluationState && Equals((EvaluationState)obj);
        }

        /// <summary>Creates an instance of the <see cref="EvaluationState" Enum class./></summary>
        /// <param name="underlyingValue">the value to create an instance for.</param>
        private EvaluationState(string underlyingValue)
        {
            this._value = underlyingValue;
        }

        /// <summary>Returns hashCode for enum EvaluationState</summary>
        /// <returns>The hashCode of the value</returns>
        public override int GetHashCode()
        {
            return this._value.GetHashCode();
        }

        /// <summary>Returns string representation for EvaluationState</summary>
        /// <returns>A string for this value.</returns>
        public override string ToString()
        {
            return this._value;
        }

        /// <summary>Implicit operator to convert string to EvaluationState</summary>
        /// <param name="value">the value to convert to an instance of <see cref="EvaluationState" />.</param>

        public static implicit operator EvaluationState(string value)
        {
            return new EvaluationState(value);
        }

        /// <summary>Implicit operator to convert EvaluationState to string</summary>
        /// <param name="e">the value to convert to an instance of <see cref="EvaluationState" />.</param>

        public static implicit operator string(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState e)
        {
            return e._value;
        }

        /// <summary>Overriding != operator for enum EvaluationState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are not equal to the same value</returns>
        public static bool operator !=(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState e2)
        {
            return !e2.Equals(e1);
        }

        /// <summary>Overriding == operator for enum EvaluationState</summary>
        /// <param name="e1">the value to compare against <see cref="e2" /></param>
        /// <param name="e2">the value to compare against <see cref="e1" /></param>
        /// <returns><c>true</c> if the two instances are equal to the same value</returns>
        public static bool operator ==(Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState e1, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.EvaluationState e2)
        {
            return e2.Equals(e1);
        }
    }
}