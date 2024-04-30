using System;

using R5T.T0131;


namespace R5T.F0119.N000
{
    /// <summary>
    /// General predicates.
    /// (Should be put into a base library.)
    /// </summary>
    [ValuesMarker]
    public partial interface IPredicates<T> : IValuesMarker
    {
        public Func<T, bool> False => _ => false;
        public Func<T, bool> True => _ => true;
    }
}
