using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;
using R5T.T0170;

using R5T.F0119.Extensions;


namespace R5T.F0119
{
    [FunctionalityMarker]
    public partial interface IInstanceDescriptorOperator : IFunctionalityMarker
    {
        public Func<InstanceDescriptor, bool> Get_SignatureStringValue_Contains(string searchText)
            => instanceDescriptor => this.SignatureStringValue_Contains(
                instanceDescriptor, searchText);

        public bool SignatureStringValue_Contains(
            InstanceDescriptor instanceDescriptor,
            string searchText)
            => instanceDescriptor.SignatureString.Value.Contains(searchText, StringComparison.InvariantCultureIgnoreCase);

        public Func<InstanceDescriptor, bool> Get_Is_InstanceVarietyPredicate(T0171.IInstanceVarietyName instanceVarietyName)
            => this.Get_Is_InstanceVarietyPredicate(instanceVarietyName.Value);

        public Func<InstanceDescriptor, bool> Get_Is_InstanceVarietyPredicate(string instanceVarietyName)
            => instanceDescriptor => instanceDescriptor.InstanceVarietyName.Value == instanceVarietyName;

        public IEnumerable<InstanceDescriptor> WhereIsOneOf(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            IEnumerable<T0171.IInstanceVarietyName> instanceVarietyNames)
        {
            var output = instanceDescriptors
                .Where(x => instanceVarietyNames.Contains(x.InstanceVarietyName))
                ;

            return output;
        }

        public IEnumerable<InstanceDescriptor> WhereIs(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            params T0171.IInstanceVarietyName[] instanceVarietyNames)
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

        /// <summary>
        /// Values include both property member types and methods.
        /// (See R5T.Z0057.IInstanceVarietyDescriptors.Values.)
        /// </summary>
        public IEnumerable<InstanceDescriptor> WhereIsValue(IEnumerable<InstanceDescriptor> instanceDescriptors)
        {
            var output = instanceDescriptors
                .WhereIs(Instances.InstanceVarietyNames.Values)
                ;

            return output;
        }
    }
}
