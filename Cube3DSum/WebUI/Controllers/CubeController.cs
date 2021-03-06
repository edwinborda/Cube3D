﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cube3D.Entity;
using Cube3D.BusinessRules;

namespace WebUI.Controllers
{
    public class CubeController : Controller
    {
        private Cube3DSum _cubeBussines = new Cube3DSum();
        // GET: Cube
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SizingMatrix(Matriz entity)
        {
            _cubeBussines.InsertMatriz(entity);
            Session["Cube3D"] = _cubeBussines.SizingCube(entity.TamMatriz);
            return View("Index",entity);
        }

        [HttpPost]
        public ActionResult EnterQuery(string query,int matrixId)
        {
            var result=-1;
            if (query.Contains(Cube3DSum.key.QUERY.ToString()))
            {
                Session["Cube3D"] = new Cube3DSum().SetValuesMatrix(matrixId, (int[,,])Session["Cube3D"]);
                result = new Cube3DSum().CubeSum3(query, (int[,,])Session["Cube3D"]);
            }
            else if (query.Contains(Cube3DSum.key.UPDATE.ToString()))
            {
                new Cube3DSum().SetValues(query, matrixId);
            }
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult GetMatrix(int length)
        {
            var a = new Cube3DSum().GetMatriz(length);
            return Json(a, JsonRequestBehavior.AllowGet);
        }
    }
}