

using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

public class Product : SkinetBaseModel
{
    public string Desciption { get; set; } = string.Empty;
    public string PictureUrl { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public ProductType? ProductType { get; set; }
    public ProductBrand? ProductBrand { get; set; }

    [ForeignKey("ProductType")]
    public int ProductTypeId { get; set; }
    [ForeignKey("ProductBrand")]
    public int ProductBrandId { get; set; }
}

 