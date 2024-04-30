using System;


namespace R5T.F0119
{
    public class InstanceDescriptorPredicates : IInstanceDescriptorPredicates
    {
        #region Infrastructure

        public static IInstanceDescriptorPredicates Instance { get; } = new InstanceDescriptorPredicates();


        private InstanceDescriptorPredicates()
        {
        }

        #endregion
    }
}
