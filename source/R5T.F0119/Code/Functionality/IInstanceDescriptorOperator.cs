using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0170;
using R5T.T0171;

using R5T.F0119.Extensions;


namespace R5T.F0119
{
    [FunctionalityMarker]
    public partial interface IInstanceDescriptorOperator : IFunctionalityMarker
    {
        public IEnumerable<InstanceDescriptor> WhereIsOneOf(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            IEnumerable<IInstanceVarietyName> instanceVarietyNames)
        {
            var output = instanceDescriptors
                .Where(x => instanceVarietyNames.Contains(x.InstanceVarietyName))
                ;

            return output;
        }

        public IEnumerable<InstanceDescriptor> WhereIs(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            params IInstanceVarietyName[] instanceVarietyNames)
        {
            var output = this.WhereIsOneOf(
                instanceDescriptors,
                instanceVarietyNames.AsEnumerable());

            return output;
        }

        public IEnumerable<InstanceDescriptor> WhereIsFunction(IEnumerable<InstanceDescriptor> instanceDescriptors)
        {
            var output = instanceDescriptors
                .WhereIs(Instances.InstanceVarietyNames.Functions)
                ;

            return output;
        }

        public IEnumerable<InstanceDescriptor> WhereIsValue(IEnumerable<InstanceDescriptor> instanceDescriptors)
        {
            var output = instanceDescriptors
                .WhereIs(Instances.InstanceVarietyNames.Values)
                ;

            return output;
        }
    }
}
