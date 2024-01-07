<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
>>>>>>> 08c37c47e8ee476df2228b135d7d7a33a96f5a3b
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAll.Models
{
    public class Cart
    {
        public int Id { get; set; }
<<<<<<< HEAD
        public int FoodItemId { get; set; }
        [ValidateNever]
        public FoodItem FoodItem { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("AplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
        [Range(1,100,ErrorMessage = "Pleace enter a value between 1 and 100")]
        public int Count { get; set; }
        [NotMapped]
        public double Price {  get; set; }
=======
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [Required, MaxLength(1)]
        public int Count { get; set; }
>>>>>>> 08c37c47e8ee476df2228b135d7d7a33a96f5a3b
    }
}
