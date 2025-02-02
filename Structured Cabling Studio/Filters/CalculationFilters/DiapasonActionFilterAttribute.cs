﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StructuredCablingStudio.DTOs.CalculationDTOs;
using StructuredCablingStudio.Models.CalculationModels;
using StructuredCablingStudio.ViewModels.CalculationViewModels;

namespace StructuredCablingStudio.Filters.CalculationFilters
{
	public class DiapasonActionFilterAttribute : ActionFilterAttribute
	{
		private static readonly string _structuredCablingStudioParametersKey = "structuredCablingStudioParametersKey";
		private static readonly string _configurationCalculateParametersKey = "configurationCalculateParameters";
		private static readonly string _calculateModelKey = "calculateModel";

		public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			await next();

			var controller = (Controller)context.Controller;
			var model = (CalculateViewModel)controller.ViewData.Model!;

			var structuredCablingStudioParameters = (StructuredCablingStudioParameters)context.HttpContext.Items[_structuredCablingStudioParametersKey]!;
			var configurationCalculateParameters = (ConfigurationCalculateParameters)context.HttpContext.Items[_configurationCalculateParametersKey]!;
			var calculateDTO = (CalculateDTO)context.HttpContext.Items[_calculateModelKey]!;

			if (model.MinPermanentLink > (double)structuredCablingStudioParameters.Diapasons.MinPermanentLinkDiapason.Max)
			{
				model.MinPermanentLink = (double)structuredCablingStudioParameters.Diapasons.MinPermanentLinkDiapason.Max;
				calculateDTO.MinPermanentLink = model.MinPermanentLink;
				context.ModelState.SetModelValue(nameof(model.MinPermanentLink), model.MinPermanentLink, default);
			}
			if (model.MinPermanentLink < (double)structuredCablingStudioParameters.Diapasons.MinPermanentLinkDiapason.Min)
			{
				model.MinPermanentLink = (double)structuredCablingStudioParameters.Diapasons.MinPermanentLinkDiapason.Min;
				calculateDTO.MinPermanentLink = model.MinPermanentLink;
				context.ModelState.SetModelValue(nameof(model.MinPermanentLink), model.MinPermanentLink, default);
			}
			if (model.MaxPermanentLink > (double)structuredCablingStudioParameters.Diapasons.MaxPermanentLinkDiapason.Max)
			{
				model.MaxPermanentLink = (double)structuredCablingStudioParameters.Diapasons.MaxPermanentLinkDiapason.Max;
				calculateDTO.MaxPermanentLink = model.MaxPermanentLink;
				context.ModelState.SetModelValue(nameof(model.MaxPermanentLink), model.MaxPermanentLink, default);
			}
			if (model.MaxPermanentLink < (double)structuredCablingStudioParameters.Diapasons.MaxPermanentLinkDiapason.Min)
			{
				model.MaxPermanentLink = (double)structuredCablingStudioParameters.Diapasons.MaxPermanentLinkDiapason.Min;
				calculateDTO.MaxPermanentLink = model.MaxPermanentLink;
				context.ModelState.SetModelValue(nameof(model.MaxPermanentLink), model.MaxPermanentLink, default);
			}
			if (model.NumberOfWorkplaces > (int)structuredCablingStudioParameters.Diapasons.NumberOfWorkplacesDiapason.Max)
			{
				model.NumberOfWorkplaces = (int)structuredCablingStudioParameters.Diapasons.NumberOfWorkplacesDiapason.Max;
				calculateDTO.NumberOfWorkplaces = model.NumberOfWorkplaces;
				context.ModelState.SetModelValue(nameof(model.NumberOfWorkplaces), model.NumberOfWorkplaces, default);
			}
			if (model.NumberOfWorkplaces < (int)structuredCablingStudioParameters.Diapasons.NumberOfWorkplacesDiapason.Min)
			{
				model.NumberOfWorkplaces = (int)structuredCablingStudioParameters.Diapasons.NumberOfWorkplacesDiapason.Min;
				calculateDTO.NumberOfWorkplaces = model.NumberOfWorkplaces;
				context.ModelState.SetModelValue(nameof(model.NumberOfWorkplaces), model.NumberOfWorkplaces, default);
			}
			if (model.NumberOfPorts > (int)structuredCablingStudioParameters.Diapasons.NumberOfPortsDiapason.Max)
			{
				model.NumberOfPorts = (int)structuredCablingStudioParameters.Diapasons.NumberOfPortsDiapason.Max;
				calculateDTO.NumberOfPorts = model.NumberOfPorts;
				context.ModelState.SetModelValue(nameof(model.NumberOfPorts), model.NumberOfPorts, default);
			}
			if (model.NumberOfPorts < (int)structuredCablingStudioParameters.Diapasons.NumberOfPortsDiapason.Min)
			{
				model.NumberOfPorts = (int)structuredCablingStudioParameters.Diapasons.NumberOfPortsDiapason.Min;
				calculateDTO.NumberOfPorts = model.NumberOfPorts;
				context.ModelState.SetModelValue(nameof(model.NumberOfPorts), model.NumberOfPorts, default);
			}
			if (model.CableHankMeterage != null)
			{
				if (model.CableHankMeterage.Value > (int)structuredCablingStudioParameters.Diapasons.CableHankMeterageDiapason.Max)
				{
					model.CableHankMeterage = (int)structuredCablingStudioParameters.Diapasons.CableHankMeterageDiapason.Max;
					configurationCalculateParameters.CableHankMeterage = model.CableHankMeterage;
					context.ModelState.SetModelValue(nameof(model.CableHankMeterage), model.CableHankMeterage, default);
				}
				if (model.CableHankMeterage.Value < (int)structuredCablingStudioParameters.Diapasons.CableHankMeterageDiapason.Min)
				{
					model.CableHankMeterage = (int)structuredCablingStudioParameters.Diapasons.CableHankMeterageDiapason.Min;
					configurationCalculateParameters.CableHankMeterage = model.CableHankMeterage;
					context.ModelState.SetModelValue(nameof(model.CableHankMeterage), model.CableHankMeterage, default);
				}
			}
			if (model.TechnologicalReserve > (int)structuredCablingStudioParameters.Diapasons.TechnologicalReserveDiapason.Max)
			{
				model.TechnologicalReserve = (int)structuredCablingStudioParameters.Diapasons.TechnologicalReserveDiapason.Max;
				structuredCablingStudioParameters.TechnologicalReserve = model.TechnologicalReserve;
				context.ModelState.SetModelValue(nameof(model.TechnologicalReserve), model.TechnologicalReserve, default);
			}
			if (model.TechnologicalReserve < (int)structuredCablingStudioParameters.Diapasons.TechnologicalReserveDiapason.Min)
			{
				model.TechnologicalReserve = (int)structuredCablingStudioParameters.Diapasons.TechnologicalReserveDiapason.Min;
				structuredCablingStudioParameters.TechnologicalReserve = model.TechnologicalReserve;
				context.ModelState.SetModelValue(nameof(model.TechnologicalReserve), model.TechnologicalReserve, default);
			}
		}
	}
}