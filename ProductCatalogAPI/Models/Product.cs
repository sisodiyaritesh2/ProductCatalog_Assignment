using System;
using System.Collections.Generic;

namespace ProductCatalogAPI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? Category { get; set; }

    public string? ImageUrl { get; set; }

    public int? StockQuantity { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdatedDate { get; set; }
}
