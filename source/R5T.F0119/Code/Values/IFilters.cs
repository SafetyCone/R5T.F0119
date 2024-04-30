using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0131;
using R5T.T0170;


namespace R5T.F0119
{
    [ValuesMarker]
    public partial interface IFilters : IValuesMarker
    {
        public IEnumerable<InstanceDescriptor> For_InstanceVariety(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            T0171.IInstanceVarietyName instanceVarietyName,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var markersPredicate = Instances.SearchOperator.Get_InstanceVarietyPredicate(
                instanceVarietyName,
                includeObsolete,
                includeDrafts);

            var markerInstances = instanceDescriptors
                .Where(markersPredicate)
                ;

            return markerInstances;
        }

        public IEnumerable<InstanceDescriptor> For_InstanceVariety(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            T0171.IInstanceVarietyName instanceVarietyName,
            T0171.IInstanceVarietyName instanceVarietyName_Draft,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var markersPredicate = Instances.SearchOperator.Get_InstanceVarietyPredicate(
                instanceVarietyName,
                instanceVarietyName_Draft,
                includeObsolete,
                includeDrafts);

            var markerInstances = instanceDescriptors
                .Where(markersPredicate)
                ;

            return markerInstances;
        }

        public IEnumerable<InstanceDescriptor> For_Markers(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var markersPredicate = Instances.SearchOperator.Get_MarkersPredicate(
               includeObsolete,
               includeDrafts);

            var markerInstances = instanceDescriptors
                .Where(markersPredicate)
                ;

            return markerInstances;
        }

        public IEnumerable<InstanceDescriptor> For_Values(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            bool includeObsolete = true,
            bool includeDrafts = true)
        {
            var valuesPredicate = Instances.SearchOperator.Get_ValuesPredicate(
               includeObsolete,
               includeDrafts);

            var valueInstances = instanceDescriptors
                .Where(valuesPredicate)
                ;

            return valueInstances;
        }
    }
}
