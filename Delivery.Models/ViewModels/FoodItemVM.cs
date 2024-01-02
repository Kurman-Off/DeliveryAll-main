﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryAll.Models.ViewModels
{
	public class FoodItemVM
	{
		public FoodItem FoodItem { get; set; }

		[ValidateNever]
		public IEnumerable<SelectListItem> CategoryList { get; set; }


	}
}
