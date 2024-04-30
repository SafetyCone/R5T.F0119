using System;
using System.Collections.Generic;
using System.Linq;

using R5T.L0065.T000;
using R5T.T0132;
using R5T.T0161;
using R5T.T0161.Extensions;
using R5T.T0170;


namespace R5T.F0119
{
    [FunctionalityMarker]
    public partial interface IOperations : IFunctionalityMarker
    {
        public Signature CheckSignatureType_ForValues(Signature signature) => signature switch
        {
            PropertySignature propertySignature => propertySignature,
            MethodSignature methodSignature => methodSignature,
            _ => throw Instances.SwitchOperator.Get_UnrecognizedSwitchTypeExpression(signature)
        };

        public IKindMarkedFullMemberName GetInstanceName(InstanceDescriptor instance)
        {
            var name = instance.IdentityString.Value.ToKindMarkedFullMemberName();
            return name;
        }

        public bool InstanceNameContainsText(IKindMarkedFullMemberName instanceName, string searchTerm, StringComparison stringComparison)
        {
            var output = instanceName.Value.Contains(searchTerm, stringComparison);
            return output;
        }

        public bool InstanceNameContainsText(IKindMarkedFullMemberName instanceName, string searchTerm)
        {
            var output = instanceName.Value.ToLowerInvariant().Contains(searchTerm.ToLowerInvariant());
            return output;
        }

        public bool InstanceNameContainsText(InstanceDescriptor instance, string searchTerm, StringComparison stringComparison)
        {
            var instanceName = this.GetInstanceName(instance);

            var containsSearchTerm = this.InstanceNameContainsText(instanceName, searchTerm, stringComparison);
            return containsSearchTerm;
        }

        public bool InstanceNameContainsText(InstanceDescriptor instance, string searchTerm)
        {
            var instanceName = this.GetInstanceName(instance);

            var containsSearchTerm = this.InstanceNameContainsText(instanceName, searchTerm);
            return containsSearchTerm;
        }

        public IEnumerable<InstanceDescriptor> InstanceNameContainsText(IEnumerable<InstanceDescriptor> instances, string searchTerm, StringComparison stringComparison)
        {
            var output = instances
                .Where(instance => this.InstanceNameContainsText(instance, searchTerm, stringComparison))
                ;

            return output;
        }

        public IEnumerable<InstanceDescriptor> InstanceNameContainsText(IEnumerable<InstanceDescriptor> instances, string searchTerm)
        {
            var output = instances
                .Where(instance => this.InstanceNameContainsText(instance, searchTerm))
                ;

            return output;
        }
    }
}
