using System;
using System.Collections.Generic;
using System.Linq;

using R5T.F0119.Extensions;
using R5T.T0132;
using R5T.T0161;
using R5T.T0161.Extensions;
using R5T.T0170;


namespace R5T.F0119
{
    public partial interface ISearchOperations
    {
        /// <summary>
        /// Find all values with names containing a search term.
        /// </summary>
        public InstanceDescriptor[] List_Values_OfTypeWithNameContaining(
            IEnumerable<InstanceDescriptor> instanceDescriptors,
            string typeNameSearchText)
        {
            var propertyAndMethodKinds = new[]
            {
                Instances.KindMarkers.Method,
                Instances.KindMarkers.Property,
            };

            var output = instanceDescriptors
                //// For debugging.
                //.Where(x => x.ProjectFilePath.Value == @"C:\Code\DEV\Git\GitHub\SafetyCone\R5T.W0002.Private\source\R5T.W0002.Z001\R5T.W0002.Z001.csproj")
                .WhereIsValue()
                .Where(x =>
                {
                    // Values might be either methods or properties (used to just be properties, but with operations values, values can also be methods).
                    var kindMarkedFullMemberName = x.KindMarkedFullMemberName;

                    // Error if the kind is not a method or property.
                    Instances.MemberNameOperator.Verify_Is_KindOneOf(
                        kindMarkedFullMemberName,
                        propertyAndMethodKinds);

                    // We know that both methods and properties have output types, so conversion is ok.
                    var outputTypeNamed = kindMarkedFullMemberName.Value.ToOutputTypeNamed();

                    // Get the output type.
                    var outputTypeName = Instances.MemberNameOperator.Get_OutputTypeName(
                        outputTypeNamed,
                        x => x.ToNamespacedTypeName());

                    // Finally, do the search on the output type name.
                    var output = outputTypeName.Value.Contains(typeNameSearchText);
                    return output;
                })
                .Now();

            return output;
        }
    }
}
