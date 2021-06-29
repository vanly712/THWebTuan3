namespace THWebTuan3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "ID không được rỗng")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Title không được rỗng")]
        [StringLength(100, ErrorMessage ="Title không quá 100")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description không được rỗng")]
        [StringLength(255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Author không được rỗng")]
        [StringLength(30, ErrorMessage ="Author không quả 30")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Image không được rỗng")]
        [StringLength(255)]
        public string Image { get; set; }

        [Required(ErrorMessage = "Price không được rỗng")]
        [Range(1000, 1000000, ErrorMessage = "Price không quá 1000 đến 1000000")]
        public int Price { get; set; }
    }
}
