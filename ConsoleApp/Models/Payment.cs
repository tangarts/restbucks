// <copyright file="InMemoryOrderDb.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Restbucks.Core.Models
{
    public class Payment
    {
        public double Amount { get; set; }

        public string CardHolder { get; set; }

        public string CardNumber { get; set; }

        public int ExpiryMonth { get; set; }

        public int ExpiryYear { get; set; }

        public DateTime Paid { get; set; }
    }
}