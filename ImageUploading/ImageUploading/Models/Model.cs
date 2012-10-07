using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace ImageUploading.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }

        public virtual Collection<Photo> ProductPhotos { get; set; }
    }

    public class Photo
    {
        public int PhotoId { get; set; }
        public string PhotoUrl { get; set; }

        public int ProductId { get; set; }
    }
}