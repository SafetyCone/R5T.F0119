using System;

using R5T.T0132;


namespace R5T.F0119
{
    [FunctionalityMarker]
    public partial interface IPredicateOperator : IFunctionalityMarker
    {
        public Func<T, bool> And<T>(
            Func<T, bool> predicate1,
            Func<T, bool> predicate2)
        {
            return value =>
            {
                var predicate1Result = predicate1(value);
                if (!predicate1Result)
                {
                    return false;
                }

                var predicate2Result = predicate2(value);
                return predicate2Result;
            };
        }

        public Func<T, bool> Or<T>(
            Func<T, bool> predicate1,
            Func<T, bool> predicate2)
        {
            return value =>
            {
                var predicate1Result = predicate1(value);
                if (predicate1Result)
                {
                    return true;
                }

                var predicate2Result = predicate2(value);
                return predicate2Result;
            };
        }
    }
}
