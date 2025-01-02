﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.ViewModels.CalculationViewModels;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class PutRecommendationsAvailabilityActionFilterAttribute : ActionFilterAttribute
	{
		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var controller = (Controller)context.Controller;
			var model = (CalculateViewModel?)controller.ViewData.Model;
			if (model != null)
			{
				if (!model.IsRecommendationsAvailability)
				{
					model.IsCableRouteRunOutdoors = false;
					model.IsConsiderFireSafetyRequirements = false;
					model.IsCableShieldingNecessity = false;
					model.HasTenBase_T = false;
					model.HasFastEthernet = false;
					model.HasGigabitBASE_T = false;
					model.HasGigabitBASE_TX = false;
					model.HasTwoPointFiveGBASE_T = false;
					model.HasFiveGBASE_T = false;
					model.HasTenGE = false;
					context.ModelState.SetModelValue(nameof(model.IsCableRouteRunOutdoors), model.IsCableRouteRunOutdoors, default);
					context.ModelState.SetModelValue(nameof(model.IsConsiderFireSafetyRequirements), model.IsConsiderFireSafetyRequirements, default);
					context.ModelState.SetModelValue(nameof(model.IsCableShieldingNecessity), model.IsCableShieldingNecessity, default);
					context.ModelState.SetModelValue(nameof(model.HasTenBase_T), model.HasTenBase_T, default);
					context.ModelState.SetModelValue(nameof(model.HasFastEthernet), model.HasFastEthernet, default);
					context.ModelState.SetModelValue(nameof(model.HasGigabitBASE_T), model.HasGigabitBASE_T, default);
					context.ModelState.SetModelValue(nameof(model.HasGigabitBASE_TX), model.HasGigabitBASE_TX, default);
					context.ModelState.SetModelValue(nameof(model.HasTwoPointFiveGBASE_T), model.HasTwoPointFiveGBASE_T, default);
					context.ModelState.SetModelValue(nameof(model.HasFiveGBASE_T), model.HasFiveGBASE_T, default);
					context.ModelState.SetModelValue(nameof(model.HasTenGE), model.HasTenGE, default);
				}
			}

			await next();
		}
	}
}
