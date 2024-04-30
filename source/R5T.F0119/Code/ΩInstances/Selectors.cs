using System;


namespace R5T.F0119
{
    public class Selectors : ISelectors
    {
        #region Infrastructure

        public static ISelectors Instance { get; } = new Selectors();


        private Selectors()
        {
        }

        #endregion
    }
}
