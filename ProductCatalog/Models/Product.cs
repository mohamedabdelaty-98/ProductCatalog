using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace ProductCatalog.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string? CreatedByUserId { get; set; }
        [Column(TypeName ="date")]
        public DateTime CreationDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        [Column(TypeName = "money")]
        public decimal price { get; set; }
        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public virtual Category? category { get; set; }
    }
}
