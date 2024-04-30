using System;


namespace R5T.F0119.N000
{
    public class Predicates<T> : IPredicates<T>
    {
        #region Infrastructure

        public static IPredicates<T> Instance { get; } = new Predicates<T>();


        private Predicates()
        {
        }

        #endregion
    }
}
