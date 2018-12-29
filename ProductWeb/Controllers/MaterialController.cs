using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Product.DomainObjects.Models;
using Product.DomainObjects.ViewModels;
using Product.Services;

namespace ProductWeb.Controllers
{
    public class MaterialController : Controller
    {
        private readonly IMaterialService _materialService;

        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        // GET
        public ActionResult Index()
        {
            return View(_materialService.GetAll());
        }

        // GET
        public ActionResult View(Int32 id)
        {
            //creating object of materialViewModel
            MaterialViewModel materialViewModel = new MaterialViewModel();

            try
            {
                //getting material details by id
                materialViewModel.MaterialModel = _materialService.GetById(id);

                //initializing list
                materialViewModel.MergeMaterialList = new List<SelectListItem>();

                //set default 0
                materialViewModel.MergeMaterialList.Add(new SelectListItem()
                {
                    Text = "Please select material to merge",
                    Value = "0"
                });



                //if there is long list of materials we can either give lazy load or search filter 
                foreach (MaterialModel m in _materialService.GetAll())
                {
                    //skip the current selected material
                    if(m.MaterialId==id)
                    {
                        continue;
                    }

                    //adding materials to list

                    materialViewModel.MergeMaterialList.Add(new SelectListItem()
                    {
                        Text = m.Name.ToString(),
                        Value = m.MaterialId.ToString()
                    });
                }


            }
            catch (Exception ex)
            {

                //log ex
                //redirect to error page
            }
            return View(materialViewModel);
        }

        /// <summary>
        /// method to return  MergeMaterial result
        /// </summary>
        /// <param name="materialToKeep"></param>
        /// <param name="materialToDelete"></param>
        /// <returns></returns>
        public JsonResult MergeMaterial(int materialToKeep, int materialToDelete)
        {
            bool result = false;
            try
            {

                // calling merge service

               if(_materialService.Merge(materialToKeep,materialToDelete))
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

                
            }
            catch (Exception ex)
            {
                
                //log ex
            }
            return Json(result,JsonRequestBehavior.AllowGet);

        }
    }
}