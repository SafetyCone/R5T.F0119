using System;

using R5T.L0065.T000;
using R5T.T0131;
using R5T.T0170;


namespace R5T.F0119
{
    [ValuesMarker]
    public partial interface ISelectors : IValuesMarker
    {
        public (Signature Signature, InstanceDescriptor InstanceDescriptor) SignatureAndInstanceDescriptor_ForValues(InstanceDescriptor instanceDescriptor)
        {
            var signature = Instances.SignatureStringOperator.Get_Signature(instanceDescriptor.SignatureString);

            Signature signature_Output = signature switch
            {
                PropertySignature propertySignature => propertySignature,
                MethodSignature methodSignature => methodSignature,
                _ => throw Instances.SwitchOperator.Get_UnrecognizedSwitchTypeExpression(signature)
            };

            return (signature_Output, instanceDescriptor);
        }

        public (MethodSignature MethodSignature, InstanceDescriptor InstanceDescriptor) MethodSignatureAndInstanceDescriptor_ForFunctions(InstanceDescriptor instanceDescriptor)
        {
            var signature = Instances.SignatureStringOperator.Get_Signature(instanceDescriptor.SignatureString);

            var methodSignature = signature switch
            {
                MethodSignature methodSignature_Typed => methodSignature_Typed,
                _ => throw Instances.SwitchOperator.Get_UnrecognizedSwitchTypeExpression(signature)
            };

            return (methodSignature, instanceDescriptor);
        }

        public (TypeSignature TypeSignature, InstanceDescriptor InstanceDescriptor) DeclaringTypeSignatureAndInstanceSelector_ForValues((Signature Signature, InstanceDescriptor InstanceDescriptor) tuple)
        {
            var declaringTypeSignature = tuple.Signature switch
            {
                PropertySignature propertySignature => propertySignature.DeclaringType,
                MethodSignature methodSignature => methodSignature.DeclaringType,
                _ => throw Instances.SwitchOperator.Get_UnrecognizedSwitchTypeExpression(tuple.Signature)
            };

            return (declaringTypeSignature, tuple.InstanceDescriptor);
        }

        public TypeSignature DeclaringTypeSignatureSelector_ForValues(Signature signature)
        {
            var declaringTypeSignature = signature switch
            {
                PropertySignature propertySignature => propertySignature.DeclaringType,
                MethodSignature methodSignature => methodSignature.DeclaringType,
                _ => throw Instances.SwitchOperator.Get_UnrecognizedSwitchTypeExpression(signature)
            };

            return declaringTypeSignature;
        }

        public (TypeSignature TypeSignature, InstanceDescriptor InstanceDescriptor) ImplementationTypeSignatureAndInstanceSelector_ForValues((Signature Signature, InstanceDescriptor InstanceDescriptor) tuple)
        {
            var implementationTypeSignature = tuple.Signature switch
            {
                PropertySignature propertySignature => propertySignature.PropertyType,
                MethodSignature methodSignature => methodSignature.ReturnType,
                _ => throw Instances.SwitchOperator.Get_UnrecognizedSwitchTypeExpression(tuple.Signature)
            };

            return (implementationTypeSignature, tuple.InstanceDescriptor);
        }

        public TypeSignature ImplementationTypeSignatureSelector_ForValues(Signature signature)
        {
            var implementationTypeSignature = signature switch
            {
                PropertySignature propertySignature => propertySignature.PropertyType,
                MethodSignature methodSignature => methodSignature.ReturnType,
                _ => throw Instances.SwitchOperator.Get_UnrecognizedSwitchTypeExpression(signature)
            };

            return implementationTypeSignature;
        }

        public string NamespacedTypeNameSelector(TypeSignature typeSignature) =>
            Instances.SignatureOperator.Get_SignatureStringValue(typeSignature);

        public Signature SignatureSelector_ForValues(InstanceDescriptor instanceDescriptor)
        {
            var signature = Instances.SignatureStringOperator.Get_Signature(instanceDescriptor.SignatureString);

            var output = Instances.Operations.CheckSignatureType_ForValues(signature);
            return output;
        }

        public (Signature Signature, InstanceDescriptor InstanceDescriptor) SignatureAndInstanceSelector_ForValues(InstanceDescriptor instanceDescriptor)
        {
            var signature = Instances.SignatureStringOperator.Get_Signature(instanceDescriptor.SignatureString);

            var output = Instances.Operations.CheckSignatureType_ForValues(signature);

            return (output, instanceDescriptor);
        }
    }
}
