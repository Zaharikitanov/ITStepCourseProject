﻿
namespace CourseProject.Controllers
{
    using CourseProject.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public abstract class BaseController : Controller
    {
        public BaseController()
            :this(new CourseProjectData())
        {

        }
        public BaseController(ICourseProjectData data)
        {
            this.Data = data;
        }
        protected ICourseProjectData Data { get; private set; }
    }
}