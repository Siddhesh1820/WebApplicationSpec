using System;
using System.Collections.Generic;

namespace WebApplicationSpec.Models;

public partial class PaymentMethod
{
    public int PaymentMethodId { get; set; }

    public int? UserId { get; set; }

    public string? CardNumber { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public string? Cvv { get; set; }

    public string? BillingAddress { get; set; }

    public string? PaymentType { get; set; }

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; }
}
