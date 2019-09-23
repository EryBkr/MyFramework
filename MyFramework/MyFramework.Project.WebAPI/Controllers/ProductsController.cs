﻿using MyFramework.Project.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFramework.Project.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        IProductManager _productManager;
        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_productManager.GetAll().ToList());
        }

    }
}
