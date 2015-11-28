using System;
using System.Collections.Generic;

namespace KataPotter.Test.Domain
{
    public class DiscountCatalog
    {
        private readonly Dictionary<int, decimal> _catalog = new Dictionary<int, decimal>
            {
                {1, 0},
                {2, 0.05m},
                {3, 0.10m},
                {4, 0.20m},
                {5, 0.25m},
            };

        public decimal GetDiscount(int numberOfDifferentArticles)
        {
            if (_catalog.ContainsKey(numberOfDifferentArticles) == false) {
                throw new Exception("No discount found for this number of different articles.");
            }
            return _catalog[numberOfDifferentArticles];
        }
    }
}