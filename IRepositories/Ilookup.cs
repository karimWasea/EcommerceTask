﻿using Microsoft.AspNetCore.Mvc.Rendering;

namespace IRepositories
{
    public interface Ilookup
    {
        //IQueryable<SelectListItem> Selectallshiofts();

        //IQueryable<SelectListItem> AllTrinng();
        //public List<SelectListItem> AllDevices();
        //IQueryable<SelectListItem> EmployeeAll();
        //IQueryable<SelectListItem> DepartmitAll();
        //List<SelectListItem> GEnder();
        //List<SelectListItem> GetAlltransaction();
        IQueryable<SelectListItem> AllParentcatagory();
        IQueryable<SelectListItem> AllPakages();




    }
}