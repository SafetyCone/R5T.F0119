using System;

using R5T.T0131;
using R5T.T0170;


namespace R5T.F0119
{
    /// <summary>
    /// Predicates for the <see cref="InstanceDescriptor"/> type.
    /// </summary>
    [ValuesMarker]
    public partial interface IInstanceDescriptorPredicates : IValuesMarker,
        N000.IPredicates<InstanceDescriptor>
    {
        /// <summary>
        /// Determines if the instance is a <see cref="Z0037.IInstanceVarietyNames.ServiceDefinitions"/> ("<inheritdoc cref="Z0037.IInstanceVarietyNames.ServiceDefinitions" path="descendant::value"/>") instance variety.
        /// </summary>
        public Func<InstanceDescriptor, bool> Is_ServiceDefinitions => Instances.InstanceDescriptorOperator.Get_Is_InstanceVarietyPredicate(
            Instances.InstanceVarietyNames.ServiceDefinitions);

        /// <summary>
        /// Determines if the instance is a <see cref="Z0037.IInstanceVarietyNames.ServiceDefinitionDrafts"/> ("<inheritdoc cref="Z0037.IInstanceVarietyNames.ServiceDefinitionDrafts" path="descendant::value"/>") instance variety.
        /// </summary>
        public Func<InstanceDescriptor, bool> Is_ServiceDefinitionDrafts => Instances.InstanceDescriptorOperator.Get_Is_InstanceVarietyPredicate(
            Instances.InstanceVarietyNames.ServiceDefinitionDrafts);

        /// <summary>
        /// Determines if the instance is a <see cref="Z0037.IInstanceVarietyNames.Markers"/> ("<inheritdoc cref="Z0037.IInstanceVarietyNames.Markers" path="descendant::value"/>") instance variety.
        /// </summary>
        public Func<InstanceDescriptor, bool> Is_Markers => instanceDescriptor => instanceDescriptor.InstanceVarietyName.Equals(Instances.InstanceVarietyNames.Markers);

        /// <summary>
        /// Determines if the instance is a <see cref="Z0037.IInstanceVarietyNames.MarkerDrafts"/> ("<inheritdoc cref="Z0037.IInstanceVarietyNames.MarkerDrafts" path="descendant::value"/>") instance variety.
        /// </summary>
        public Func<InstanceDescriptor, bool> Is_MarkerDrafts => instanceDescriptor => instanceDescriptor.InstanceVarietyName.Equals(Instances.InstanceVarietyNames.MarkerDrafts);

        /// <summary>
        /// Determines if the instance is a <see cref="Z0037.IInstanceVarietyNames.Values"/> ("<inheritdoc cref="Z0037.IInstanceVarietyNames.Values" path="descendant::value"/>") instance variety.
        /// </summary>
        public Func<InstanceDescriptor, bool> Is_Values => instanceDescriptor => instanceDescriptor.InstanceVarietyName.Equals(Instances.InstanceVarietyNames.Values);

        /// <summary>
        /// Determines if the instance is a <see cref="Z0037.IInstanceVarietyNames.ValueDrafts"/> ("<inheritdoc cref="Z0037.IInstanceVarietyNames.ValueDrafts" path="descendant::value"/>") instance variety.
        /// </summary>
        public Func<InstanceDescriptor, bool> Is_ValueDrafts => instanceDescriptor => instanceDescriptor.InstanceVarietyName.Equals(Instances.InstanceVarietyNames.ValueDrafts);

        public Func<InstanceDescriptor, bool> Not_Obsolete => instanceDescriptor => !instanceDescriptor.IsObsolete;
    }
}