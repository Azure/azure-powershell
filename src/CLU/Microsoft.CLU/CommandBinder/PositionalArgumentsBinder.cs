using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.CLU.CommandBinder
{
    /// <summary>
    /// The binder for binding positional parameters from positional arguments.
    /// </summary>
    internal class PositionalArgumentsBinder
    {
        /// <summary>
        /// Create an instance of PositionalArgumentsBinder which can bind static and dynamic parameters
        /// from the positional arguments.
        /// </summary>
        /// <param name="cmdletInstance">The cmdlet instance, this cannot be null</param>
        /// <param name="dynamicParameterInstance">The  dynamic parameter instance, this can be null</param>
        /// <param name="staticBindState">The state of static parameter binding</param>
        /// <param name="dynamicBindState">The state of dynamic parameter binding</param>
        /// <param name="hasEmptyParameterSets">Indicates whether cmdlet has empty parameter set or not</param>
        public PositionalArgumentsBinder(Cmdlet cmdletInstance, object dynamicParameterInstance,
            ParameterBindState staticBindState, ParameterBindState dynamicBindState, bool hasEmptyParameterSets)
        {
            Debug.Assert(cmdletInstance != null);
            Debug.Assert(staticBindState != null);
            Debug.Assert(dynamicBindState != null);
            _cmdletInstance = cmdletInstance;
            _dynamicParameterInstance = dynamicParameterInstance;
            _staticBindState = staticBindState;
            _dynamicBindState = dynamicBindState;
            _hasEmptyParameterSets = hasEmptyParameterSets;
        }

        /// <summary>
        /// Bind the positonal parameters.
        /// </summary>
        /// <param name="parameterSets">The valid parameter-sets based on the current context</param>
        /// <returns>The resulting parameter-set after positional parameters binding</returns>
        public HashSet<string> BindOnce(HashSet<string> parameterSets)
        {
            if (_bounded)
            {
                return _savedParameterSets;
            }

            _bounded = true;
            if (_staticBindState.ParameterPositionalStringValues.Count == 0)
            {
                _savedParameterSets = new HashSet<string>(parameterSets);
                return _savedParameterSets;
            }

            // TODO: handling of dynamic positional arguments.
            if (!parameterSets.IsEmpty() || _hasEmptyParameterSets)
            {
                if (parameterSets.IsEmpty())
                {
                    BindWithParameterSet(_cmdletInstance, _staticBindState.CandidateParameters, parameterSets, _staticBindState.ParameterPositionalStringValues, null);
                }
                else
                {
                    foreach (var parameterSet in parameterSets)
                    {
                        if (BindWithParameterSet(_cmdletInstance, _staticBindState.CandidateParameters, parameterSets, _staticBindState.ParameterPositionalStringValues, parameterSet) > 0)
                        {
                            // In case of multiple parameter-sets, as soon as we identify a parameter-set with more than one positional parameters
                            // we do binding for those parameters and return. Sholud we idenitfy and use the  best fit parameter-set? which has the
                            // maximum parameters whose type compatible with postional string values?
                            break;
                        }
                    }
                }
            }

            _savedParameterSets = new HashSet<string>(parameterSets);
            return _savedParameterSets;
        }

        /// <summary>
        /// Bind the unbouded positional parameters that belongs to a given parameter set.
        /// </summary>
        /// <param name="instance">The instance in which parameters exists</param>
        /// <param name="parameters">The candidate parameters to look for unbounded positional parameters</param>
        /// <param name="parameterSets">The candiate parameter set</param>
        /// <param name="positionalArguments">The positional argument values from commandline</param>
        /// <param name="parameterSet">The parameter-set whose positional arguments needs to be bounded</param>
        /// <returns></returns>
        private int BindWithParameterSet(object instance, IEnumerable<ParameterMetadata> parameters, HashSet<string> parameterSets, List<string> positionalArguments, string parameterSet)
        {
            var unboundPositionalParameters = parameters
                .Where(p => p.Position(parameterSet) != -1 &&
                    !p.IsBound &&
                    MatchesParameterSet(p, parameterSet));
            unboundPositionalParameters = unboundPositionalParameters.OrderBy(p => p.Position(parameterSet));

            int position = 0;
            foreach (var parameter in unboundPositionalParameters)
            {
                if (position >= positionalArguments.Count)
                    break;

                try
                {
                    parameter.InterpretAndSetValue(instance, positionalArguments[position]);
                }
                catch (JsonException jsonException)
                {
                    throw new ParameterBindingException(parameter.Name, position, jsonException);
                }

                parameterSets.IntersectWith(parameter.ParameterSets.Keys.ToSet());
                position += 1;
            }

            return position;
        }

        /// <summary>
        /// Check whether the given parameter belongs to a parameter-set.
        /// </summary>
        /// <param name="parameter">The parameter to check</param>
        /// <param name="parameterSet">The parameter-set to look for</param>
        /// <returns>true if parameter belongs to the given parameter-set, false otherwise</returns>
        private static bool MatchesParameterSet(ParameterMetadata parameter, string parameterSet)
        {
            return parameterSet == null || parameter.ParameterSets.ContainsKey(parameterSet);
        }

        #region Private fields

        /// <summary>
        /// Indicates whether the positional parameters are already bounded.
        /// </summary>
        private bool _bounded;

        /// <summary>
        /// The saved parameter-sets to return to caller if already bounded.
        /// </summary>
        private HashSet<string> _savedParameterSets;

        /// <summary>
        /// The cmdlet instance.
        /// </summary>
        private Cmdlet _cmdletInstance;

        /// <summary>
        /// The dynamic parameters instance.
        /// </summary>
        private object _dynamicParameterInstance;

        /// <summary>
        /// The state of the static parameters binding.
        /// </summary>
        private ParameterBindState _staticBindState;

        /// <summary>
        /// The state of the dynamic parameters binding.
        /// </summary>
        private ParameterBindState _dynamicBindState;

        /// <summary>
        /// Indidates whether there is any parameter-set defined in the cmdlet.
        /// </summary>
        private bool _hasEmptyParameterSets;

        #endregion
    }
}
