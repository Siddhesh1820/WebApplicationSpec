using System;
using System.Collections.Generic;

namespace WebApplicationSpec.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? UserId { get; set; }

    public int? OrderId { get; set; }

    public int? PaymentMethodId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? TransactionDate { get; set; }

    public string? Status { get; set; }

    public virtual Order? Order { get; set; }

    public virtual PaymentMethod? PaymentMethod { get; set; }

    public virtual User? User { get; set; }
}
