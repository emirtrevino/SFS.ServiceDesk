﻿// <Template>
//   <SolutionTemplate></SolutionTemplate>
//   <Version>20150126.0020</Version>
//   <Update>uiModel.ModuleNamespace</Update>
// </Template>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SFS.ServiceDesk.BR;
using System.Web.Script.Serialization;
using SFS.ServiceDesk.Web.Mvc.Models;
using SFS.ServiceDesk.Web.Mvc.Resources;
using BO = SFS.ServiceDesk.BusinessObjects;
using SFSdotNet.Framework.Web.Mvc.Security;
using SFSdotNet.Framework.Web.Mvc;
using SFSdotNet.Framework.Web.Mvc.Models;
using SFSdotNet.Framework.Web.Mvc.Resources;
using SFSdotNet.Framework.Web.Mvc.Controllers;
using MvcSiteMapProvider;
using System.Web.Routing;
using System.Collections;

using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using SFSdotNet.Framework.My;

using SFS.ServiceDesk.BusinessObjects;

namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
	using SFS.ServiceDesk.Web.Mvc.Models.SDAreas;

    public partial class SDAreasController : SFS.ServiceDesk.Web.Mvc.ControllerBase<Models.SDAreas.SDAreaModel>
    {

       


	#region partial methods
        ControllerEventArgs<Models.SDAreas.SDAreaModel> e = null;
        partial void OnValidating(object sender, ControllerEventArgs<Models.SDAreas.SDAreaModel> e);
        partial void OnGettingExtraData(object sender, MyEventArgs<UIModel<Models.SDAreas.SDAreaModel>> e);
        partial void OnCreating(object sender, ControllerEventArgs<Models.SDAreas.SDAreaModel> e);
        partial void OnCreated(object sender, ControllerEventArgs<Models.SDAreas.SDAreaModel> e);
        partial void OnEditing(object sender, ControllerEventArgs<Models.SDAreas.SDAreaModel> e);
        partial void OnEdited(object sender, ControllerEventArgs<Models.SDAreas.SDAreaModel> e);
        partial void OnDeleting(object sender, ControllerEventArgs<Models.SDAreas.SDAreaModel> e);
        partial void OnDeleted(object sender, ControllerEventArgs<Models.SDAreas.SDAreaModel> e);
    	partial void OnShowing(object sender, MyEventArgs<UIModel<Models.SDAreas.SDAreaModel>> e);
    	partial void OnGettingByKey(object sender, ControllerEventArgs<Models.SDAreas.SDAreaModel> e);
        partial void OnTaken(object sender, ControllerEventArgs<Models.SDAreas.SDAreaModel> e);
       	partial void OnCreateShowing(object sender, ControllerEventArgs<Models.SDAreas.SDAreaModel> e);
		partial void OnEditShowing(object sender, ControllerEventArgs<Models.SDAreas.SDAreaModel> e);
		partial void OnDetailsShowing(object sender, ControllerEventArgs<Models.SDAreas.SDAreaModel> e);
 		partial void OnActionsCreated(object sender, MyEventArgs<UIModel<Models.SDAreas.SDAreaModel >> e);
		partial void OnCustomActionExecuting(object sender, MyEventArgs<ContextActionModel<Models.SDAreas.SDAreaModel>> e);
		partial void OnCustomActionExecutingBackground(object sender, MyEventArgs<ContextActionModel<Models.SDAreas.SDAreaModel>> e);
        partial void OnDownloading(object sender, MyEventArgs<ContextActionModel<Models.SDAreas.SDAreaModel>> e);
      	partial void OnAuthorization(object sender, AuthorizationContext context);
		 partial void OnFilterShowing(object sender, MyEventArgs<UIModel<Models.SDAreas.SDAreaModel >> e);
         partial void OnSummaryOperationShowing(object sender, MyEventArgs<UIModel<Models.SDAreas.SDAreaModel>> e);

        partial void OnExportActionsCreated(object sender, MyEventArgs<UIModel<Models.SDAreas.SDAreaModel>> e);


		protected override void OnVirtualFilterShowing(object sender, MyEventArgs<UIModel<SDAreaModel>> e)
        {
            OnFilterShowing(sender, e);
        }
		 public override void OnVirtualExportActionsCreated(object sender, MyEventArgs<UIModel<SDAreaModel>> e)
        {
            OnExportActionsCreated(sender, e);
        }
        public override void OnVirtualDownloading(object sender, MyEventArgs<ContextActionModel<SDAreaModel>> e)
        {
            OnDownloading(sender, e);
        }
        public override void OnVirtualShowing(object sender, MyEventArgs<UIModel<SDAreaModel>> e)
        {
            OnShowing(sender, e);
        }

	#endregion
	#region API
	 public override ActionResult ApiCreateGen(SDAreaModel model, ContextRequest contextRequest)
        {
            return CreateGen(model, contextRequest);
        }

              public override ActionResult ApiGetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJson(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }
        public override ActionResult ApiGetByKeyJson(string id, ContextRequest contextRequest)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
            return  GetByKeyJson(id, contextRequest, true);
        }
      
		 public override ActionResult ApiGetByCount(string filter, ContextRequest contextRequest)
        {
            return GetByCount(filter, contextRequest);
        }
         protected override ActionResult ApiDeleteGen(List<SDAreaModel> models, ContextRequest contextRequest)
        {
            List<SDArea> objs = new List<SDArea>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                BR.SDAreasBR.Instance.DeleteBulk(objs, contextRequest);
                if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("success", null, null, null);

                }
                else
                {
                    return Content("ok");

                }
            }
            catch (Exception ex)
            {
               if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "error", reason = "error", message= ex.ToString() }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("error", "exception", ex.ToString(), null );

                }
                else
                {
                    return Json(ex.ToString(), JsonRequestBehavior.AllowGet);

                }
            }
        }
        protected override ActionResult ApiUpdateGen(List<SDAreaModel> models, ContextRequest contextRequest)
        {
            List<SDArea> objs = new List<SDArea>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                foreach (var obj in objs)
                {
                    BR.SDAreasBR.Instance.Update(obj, contextRequest);

                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }


	#endregion
#region Validation methods	
	    private void Validations(SDAreaModel model) { 
            #region Remote validations

            #endregion
		}

#endregion
		
 		public AuthorizationContext Authorization(AuthorizationContext context)
        {
            OnAuthorization(this,  context );
            return context ;
        }
		public List<SDAreaModel> GetAll() {
            			var bos = BR.SDAreasBR.Instance.GetBy("",
					new SFSdotNet.Framework.My.ContextRequest()
					{
						CustomQuery = new SFSdotNet.Framework.My.CustomQuery()
						{
							OrderBy = "Name",
							SortDirection = SFSdotNet.Framework.Data.SortDirection.Ascending
						}
					});
            			List<SDAreaModel> results = new List<SDAreaModel>();
            SDAreaModel model = null;
            foreach (var bo in bos)
            {
                model = new SDAreaModel();
                model.Bind(bo);
                results.Add(model);
            }
            return results;

        }
        //
        // GET: /SDAreas/
		[MyAuthorize("r", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
		public ActionResult Index()
        {
    		var uiModel = GetContextModel(UIModelContextTypes.ListForm, null);
			ViewBag.UIModel = uiModel;
			uiModel.FilterStart = (string)ViewData["startFilter"];
                    MyEventArgs<UIModel<SDAreaModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDAreaModel>>() { Object = uiModel });

			OnExportActionsCreated(this, (me != null ? me : me = new MyEventArgs<UIModel<SDAreaModel>>() { Object = uiModel }));

            if (me != null)
            {
                uiModel = me.Object;
            }
            if (me == null)
                me = new MyEventArgs<UIModel<SDAreaModel>>() { Object = uiModel };
           
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;


            //return View("ListGen");
			return ResolveView(uiModel);
        }
		[MyAuthorize("r", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
		public ActionResult ListViewGen(string idTab, string fk , string fkValue, string startFilter, ListModes  listmode  = ListModes.SimpleList, PropertyDefinition parentRelationProperty = null, object parentRelationPropertyValue = null )
        {
			ViewData["idTab"] = System.Web.HttpContext.Current.Request.QueryString["idTab"]; 
		 	ViewData["detpop"] = true; // details in popup
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"])) {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"]; 
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
            {
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["startFilter"]))
            {
                ViewData["startFilter"] = Request.QueryString["startFilter"];
            }
			
			UIModel<SDAreaModel> uiModel = GetContextModel(UIModelContextTypes.ListForm, null);

            MyEventArgs<UIModel<SDAreaModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDAreaModel>>() { Object = uiModel });
            if (me == null)
                me = new MyEventArgs<UIModel<SDAreaModel>>() { Object = uiModel };
            uiModel.Properties = GetProperties(uiModel);
            uiModel.ContextType = UIModelContextTypes.ListForm;
             uiModel.FilterStart = (string)ViewData["startFilter"];
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;
			 if (listmode == ListModes.SimpleList)
                return ResolveView(uiModel);
            else
            {
                ViewData["parentRelationProperty"] = parentRelationProperty;
                ViewData["parentRelationPropertyValue"] = parentRelationPropertyValue;
                return PartialView("ListForTagSelectView");
            }
            return ResolveView(uiModel);
        }
		List<PropertyDefinition> _properties = null;

		 protected override List<PropertyDefinition> GetProperties(UIModel uiModel,  params string[] specificProperties)
        { 
            return GetProperties(uiModel, false, null, specificProperties);
        }

		protected override List<PropertyDefinition> GetProperties(UIModel uiModel, bool decripted, Guid? id, params string[] specificProperties)
            {

			bool allProperties = true;    
                if (specificProperties != null && specificProperties.Length > 0)
                {
                    allProperties = false;
                }


			List<CustomProperty> customProperties = new List<CustomProperty>();
			if (_properties == null)
                {
                List<PropertyDefinition> results = new List<PropertyDefinition>();

			string idSDArea = GetRouteDataOrQueryParam("id");
			if (idSDArea != null)
			{
				if (!decripted)
                {
					idSDArea = SFSdotNet.Framework.Entities.Utils.GetPropertyKey(idSDArea.Replace("-","/"), "GuidArea");
				}else{
					if (id != null )
						idSDArea = id.Value.ToString();                

				}
			}

			bool visibleProperty = true;	
			 bool conditionalshow =false;
                if (uiModel.ContextType == UIModelContextTypes.EditForm || uiModel.ContextType == UIModelContextTypes.DisplayForm ||  uiModel.ContextType == UIModelContextTypes.GenericForm )
                    conditionalshow = true;
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidArea"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidArea")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 100,
																	
					CustomProperties = customProperties,

                    PropertyName = "GuidArea",

					 MaxLength = 0,
					IsRequired = true ,
					IsHidden = true,
                    SystemProperty =  SystemProperties.Identifier ,
					IsDefaultProperty = false,
                    SortBy = "GuidArea",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDAreaResources.GUIDAREA*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("Name"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "Name")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 101,
																	
					CustomProperties = customProperties,

                    PropertyName = "Name",

					 MaxLength = 255,
					 Nullable = true,
					IsDefaultProperty = true,
                    SortBy = "Name",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDAreaResources.NAME*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidAreaParent"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidAreaParent")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 102,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidAreaParent",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "GuidAreaParent",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDAreaResources.GUIDAREAPARENT*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidOrganization"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidOrganization")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 103,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidOrganization",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "GuidOrganization",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDAreaResources.GUIDORGANIZATION*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDArea1"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDArea2" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDArea1.GuidArea")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDArea1.GuidArea" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDAreas" });
			

	
	//fk_Area_Parent
		//if (this.Request.QueryString["fk"] != "SDArea1")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 104,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDAreas/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDArea1&fk=SDArea2&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDArea2.GuidArea = Guid(\"" + idSDArea +"\")")+ "&fkValue=" + idSDArea,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDArea",
					
					CustomProperties = customProperties,

                    PropertyName = "SDArea1",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDArea1.Name",
					
	
                    TypeName = "SFSServiceDeskModel.SDArea",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDAreas"
                    /*,PropertyDisplayName = Resources.SDAreaResources.SDAREA1*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDArea2"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDArea1" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDArea2.GuidArea")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDArea2.GuidArea" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDAreas" });
			

	
	//fk_Area_Parent
		//if (this.Request.QueryString["fk"] != "SDArea2")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 105,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDArea",
					PropertyNavigationKey = "GuidArea",
					PropertyNavigationText = "Name",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="Name",
					GetMethodDisplayValue = "GuidArea",
					
					CustomProperties = customProperties,

                    PropertyName = "SDArea2",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDArea2.Name",
					
	
                    TypeName = "SFSServiceDeskModel.SDArea",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDAreas"
                    /*,PropertyDisplayName = Resources.SDAreaResources.SDAREA2*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDOrganization"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDAreas" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDOrganization.GuidOrganization")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDOrganization.GuidOrganization" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDOrganizations" });
			

	
	//fk_SdArea_SdOrganization
		//if (this.Request.QueryString["fk"] != "SDOrganization")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 106,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDOrganization",
					PropertyNavigationKey = "GuidOrganization",
					PropertyNavigationText = "FullName",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="FullName",
					GetMethodDisplayValue = "GuidOrganization",
					
					CustomProperties = customProperties,

                    PropertyName = "SDOrganization",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDOrganization.FullName",
					
	
                    TypeName = "SFSServiceDeskModel.SDOrganization",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDOrganizations"
                    /*,PropertyDisplayName = Resources.SDAreaResources.SDORGANIZATION*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDAreaPersons"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDArea" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDAreaPersons.GuidAreaPerson")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDAreaPersons.GuidAreaPerson" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDAreaPersons" });
			

	
	//fk_SdAreaPerson_SdArea
		//if (this.Request.QueryString["fk"] != "SDAreaPersons")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 107,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDAreaPersons/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDAreaPersons&fk=SDArea&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDArea.GuidArea = Guid(\"" + idSDArea +"\")")+ "&fkValue=" + idSDArea,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDAreaPerson",
					
					CustomProperties = customProperties,

                    PropertyName = "SDAreaPersons",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDAreaPersons.GuidAreaPerson",
					
	
                    TypeName = "SFSServiceDeskModel.SDAreaPerson",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDAreaPersons"
                    /*,PropertyDisplayName = Resources.SDAreaResources.SDAREAPERSONS*/
                });
		//	}
	
	}
	
				
                    _properties = results;
                    return _properties;
                }
                else {
                    return _properties;
                }
            }

		protected override  UIModel<SDAreaModel> GetByForShow(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, params  object[] extraParams)
        {
			if (Request != null )
				if (!string.IsNullOrEmpty(Request.QueryString["q"]))
					filter = filter + HttpUtility.UrlDecode(Request.QueryString["q"]);
 if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
            }
            var bos = BR.SDAreasBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), contextRequest, extraParams);
			//var bos = BR.SDAreasBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), context, extraParams);
            SDAreaModel model = null;
            List<SDAreaModel> results = new List<SDAreaModel>();
            foreach (var item in bos)
            {
                model = new SDAreaModel();
				model.Bind(item);
				results.Add(model);
            }
            //return results;
			UIModel<SDAreaModel> uiModel = GetContextModel(UIModelContextTypes.Items, null);
            uiModel.Items = results;
			if (Request != null){
				if (SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(Request.RequestContext, "action") == "Download")
				{
					uiModel.ContextType = UIModelContextTypes.ExportDownload;
				}
			}
            Showing(ref uiModel);
            return uiModel;
		}			
		
		//public List<SDAreaModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params  object[] extraParams)
        //{
		//	var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, null, extraParams);
        public override List<SDAreaModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest,  params  object[] extraParams)
        {
            var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
           
            return uiModel.Items;
		
        }
		/*
        [MyAuthorize("r", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir)
        {
			 return GetByJsonBase(filter, pageSize, page, orderBy, orderDir);
        }*/

		  [MyAuthorize("r", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir,ContextRequest contextRequest,  object[] extraParams)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
			 
			 if (this.IsRESTRequest == false)
            {
                return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
            }else
            {
                try
                {
                    return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);

                }
            }
        }
/*		  [MyAuthorize("r", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
       public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }*/
		[MyAuthorize()]
		public ActionResult GetByCount(string filter, ContextRequest contextRequest) {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
           
			
             if (this.IsRESTRequest == true)
            {
                try
                {

                    var result = BR.SDAreasBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);

                   if (Request.QueryString["v"] == "2")
                    {
						return ResolveApiResponse("success", null, null, result);

                        //return Json(new { status = "success", data = result }, JsonRequestBehavior.AllowGet);
                    }else
                    {
                        return Content(result.ToString());

                    }
                }
                catch (Exception ex)
                {
                  //  return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
				  return ResolveApiResponse("error", "exception", ex.ToString(), null);

                }
            }
            else
            {
                var result = BR.SDAreasBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);
                return Content(result.ToString());
            }
		}
		

		[MyAuthorize("r", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
        public ActionResult GetByKeyJson(string id, ContextRequest contextRequest,  bool dec = false)
        {
            return Json(GetByKey(id, null, contextRequest, dec), JsonRequestBehavior.AllowGet);
        }
		public SDAreaModel GetByKey(string id) {
			return GetByKey(id, null,null, false);
       	}
		    public SDAreaModel GetByKey(string id, string includes)
        {
            return GetByKey(id, includes, false);
        }
		 public  SDAreaModel GetByKey(string id, string includes, ContextRequest contextRequest)
        {
            return GetByKey(id, includes, contextRequest, false);
        }
		/*
		  public ActionResult ShowField(string fieldName, string idField) {
		   string safePropertyName = fieldName;
              if (fieldName.StartsWith("Fk"))
              {
                  safePropertyName = fieldName.Substring(2, fieldName.Length - 2);
              }

             SDAreaModel model = new  SDAreaModel();

            UIModel uiModel = GetUIModel(model, new string[] { "NoField-" });
			
				uiModel.Properties = GetProperties(uiModel, safePropertyName);
		uiModel.Properties.ForEach(p=> p.ContextType = uiModel.ContextType );
            uiModel.ContextType = UIModelContextTypes.FilterFields;
            uiModel.OverrideApp = GetOverrideApp();
            uiModel.UseMode = GetUseMode();

            ViewData["uiModel"] = uiModel;
			var prop = uiModel.Properties.FirstOrDefault(p=>p.PropertyName == safePropertyName);
            //if (prop.IsNavigationProperty && prop.IsNavigationPropertyMany == false)
            //{
            //    ViewData["currentProperty"] = uiModel.Properties.FirstOrDefault(p => p.PropertyName != fieldName + "Text");
            //}else if (prop.IsNavigationProperty == false){
                ViewData["currentProperty"] = prop;
           // }
            ((PropertyDefinition)ViewData["currentProperty"]).RemoveLayout = true;
			ViewData["withContainer"] = false;


            return PartialView("GenericField", model);


        }
      */
	public SDAreaModel GetByKey(string id, ContextRequest contextRequest, bool dec)
        {
            return GetByKey(id, null, contextRequest, dec);
        }
        public SDAreaModel GetByKey(string id, string  includes, bool dec)
        {
            return GetByKey(id, includes, null, dec);
        }

        public SDAreaModel GetByKey(string id, string includes, ContextRequest contextRequest, bool dec) {
		             SDAreaModel model = null;
            ControllerEventArgs<SDAreaModel> e = null;
			string objectKey = id.Replace("-","/");
             OnGettingByKey(this, e=  new ControllerEventArgs<SDAreaModel>() { Id = objectKey  });
             bool cancel = false;
             SDAreaModel eItem = null;
             if (e != null)
             {
                 cancel = e.Cancel;
                 eItem = e.Item;
             }
			if (cancel == false && eItem == null)
             {
			Guid guidArea = Guid.Empty; //new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, "GuidArea"));
			if (dec)
                 {
                     guidArea = new Guid(id);
                 }
                 else
                 {
                     guidArea = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, null));
                 }
			
            
				model = new SDAreaModel();
                  if (contextRequest == null)
                {
                    contextRequest = GetContextRequest();
                }
				var bo = BR.SDAreasBR.Instance.GetByKey(guidArea, GetUseMode(), contextRequest,  includes);
				 if (bo != null)
                    model.Bind(bo);
                else
                    return null;
			}
             else {
                 model = eItem;
             }
			model.IsNew = false;

            return model;
        }
        // GET: /SDAreas/DetailsGen/5
		[MyAuthorize("r", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
        public ActionResult DetailsGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDAreaResources.ENTITY_PLURAL;
			 #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDAreaModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
            #endregion



			 bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
			//UIModel<SDAreaModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, decripted), decripted, guidId);
			var item = GetByKey(id, null, null, decripted);
			if (item == null)
            {
                 RouteValueDictionary rv = new RouteValueDictionary();
                string usemode = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"usemode");
                string overrideModule = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "overrideModule");
                string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");

                if(!string.IsNullOrEmpty(usemode)){
                    rv.Add("usemode", usemode);
                }
                if(!string.IsNullOrEmpty(overrideModule)){
                    rv.Add("overrideModule", overrideModule);
                }
                if (!string.IsNullOrEmpty(area))
                {
                    rv.Add("area", area);
                }

                return RedirectToAction("Index", rv);
            }
            //
            UIModel<SDAreaModel> uiModel = null;
                uiModel = GetContextModel(UIModelContextTypes.DisplayForm, item, decripted, guidId);



            MyEventArgs<UIModel<SDAreaModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDAreaModel>>() { Object = uiModel });

            if (me != null) {
                uiModel = me.Object;
            }
			
            Showing(ref uiModel);
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			
            //return View("DisplayGen", uiModel.Items[0]);
			return ResolveView(uiModel, uiModel.Items[0]);

        }
		[MyAuthorize("r", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
		public ActionResult DetailsViewGen(string id)
        {

		 bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDAreaModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
           
			if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
 			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
           
        	 //var uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id));
			 
            bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true")
                {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
            UIModel<SDAreaModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, null, decripted), decripted, guidId);
			

            MyEventArgs<UIModel<SDAreaModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDAreaModel>>() { Object = uiModel });

            if (me != null)
            {
                uiModel = me.Object;
            }
            
            Showing(ref uiModel);
            return ResolveView(uiModel, uiModel.Items[0]);
        
        }
        //
        // GET: /SDAreas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /SDAreas/CreateGen
		[MyAuthorize("c", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
        public ActionResult CreateGen()
        {
			SDAreaModel model = new SDAreaModel();
            model.IsNew = true;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model);

			OnCreateShowing(this, e = new ControllerEventArgs<SDAreaModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }

             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                 ViewData["ispopup"] = true;
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                 ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                 ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

            Showing(ref me);

			return ResolveView(me, me.Items[0]);
        } 
			
		protected override UIModel<SDAreaModel> GetContextModel(UIModelContextTypes formMode, SDAreaModel model)
        {
            return GetContextModel(formMode, model, false, null);
        }
			
		 private UIModel<SDAreaModel> GetContextModel(UIModelContextTypes formMode, SDAreaModel model, bool decript, Guid ? id) {
            UIModel<SDAreaModel> me = new UIModel<SDAreaModel>(true, "SDAreas");
			me.UseMode = GetUseMode();
			me.Controller = this;
			me.OverrideApp = GetOverrideApp();
			me.ContextType = formMode ;
			me.Id = "SDArea";
			
            me.ModuleKey = "SFSServiceDesk";

			me.ModuleNamespace = "SFS.ServiceDesk";
            me.EntityKey = "SDArea";
            me.EntitySetName = "SDAreas";

			me.AreaAction = "SFSServiceDesk";
            me.ControllerAction = "SDAreas";
            me.PropertyKeyName = "GuidArea";

            me.Properties = GetProperties(me, decript, id);
 			
			if (Request != null)
            {
                string actionName = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam( Request.RequestContext, "action");
                if(actionName != null && actionName.ToLower().Contains("create") ){
                    me.IsNew = true;
                }
            }
			 #region Buttons
			 if (Request != null ){
             if (formMode == UIModelContextTypes.DisplayForm || formMode == UIModelContextTypes.EditForm || formMode == UIModelContextTypes.ListForm)
				me.ActionButtons = GetActionButtons(formMode,model != null ?(Request.QueryString["dec"] == "true" ? model.Id : model.SafeKey)  : null, "SFSServiceDesk", "SDAreas", "SDArea", me.IsNew);

            //me.ActionButtons.Add(new ActionModel() { ActionKey = "return", Title = GlobalMessages.RETURN, Url = System.Web.VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDAreas" });
			if (this.HttpContext != null &&  !this.HttpContext.SkipAuthorization){
				//antes this.HttpContext
				me.SetAction("u", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("u", "SDArea", "SFSServiceDesk"));
				me.SetAction("c", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("c", "SDArea", "SFSServiceDesk"));
				me.SetAction("d", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("d", "SDArea", "SFSServiceDesk"));
			
			}else{
				me.SetAction("u", true);
				me.SetAction("c", true);
				me.SetAction("d", true);

			}
            #endregion              
         
            switch (formMode)
            {
                case UIModelContextTypes.DisplayForm:
					//me.TitleForm = SDAreaResources.SDAREAS_DETAILS;
                    me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.MODIFY_DATA;
					 me.Properties.Where(p=>p.PropertyName  != "Id" && p.IsForeignKey == false).ToList().ForEach(p => p.IsHidden = false);

					 me.Properties.Where(p => (p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier) ).ToList().ForEach(p=> me.SetHide(p.PropertyName));

                    break;
                case UIModelContextTypes.EditForm:
				  me.Properties.Where(p=>p.SystemProperty != SystemProperties.Identifier && p.IsForeignKey == false && p.PropertyName != "Id").ToList().ForEach(p => p.IsHidden = false);

					if (model != null)
                    {
						

                        me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.SAVE_DATA;                        
                        me.ActionButtons.First(p => p.ActionKey == "c").Title = GlobalMessages.SAVE_DATA;
						if (model.IsNew ){
							//me.TitleForm = SDAreaResources.SDAREAS_ADD_NEW;
							me.ActionName = "CreateGen";
							me.Properties.RemoveAll(p => p.SystemProperty != null || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));
						}else{
							
							me.ActionName = "EditGen";

							//me.TitleForm = SDAreaResources.SDAREAS_EDIT;
							me.Properties.RemoveAll(p => p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));	
						}
						//me.Properties.Remove(me.Properties.Find(p => p.PropertyName == "UpdatedDate"));
					
					}
                    break;
                case UIModelContextTypes.FilterFields:
                    break;
                case UIModelContextTypes.GenericForm:
                    break;
                case UIModelContextTypes.Items:
				//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "Name") != null){
						me.Properties.Find(p => p.PropertyName == "Name").IsHidden = false;
					 }
					 
                    
					

						 if (me.Properties.Find(p => p.PropertyName == "GuidArea") != null){
						me.Properties.Find(p => p.PropertyName == "GuidArea").IsHidden = false;
					 }
					 
                    
					


                  


					//}
                    break;
                case UIModelContextTypes.ListForm:
					PropertyDefinition propFinded = null;
					//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "Name") != null){
						me.Properties.Find(p => p.PropertyName == "Name").IsHidden = false;
					 }
					
					me.PrincipalActionName = "GetByJson";
					//}
					//me.TitleForm = SDAreaResources.SDAREAS_LIST;
                    break;
                default:
                    break;
            }
            	this.SetDefaultProperties(me);
			}
			if (model != null )
            	me.Items.Add(model);
            return me;
        }
		// GET: /SDAreas/CreateViewGen
		[MyAuthorize("c", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
        public ActionResult CreateViewGen()
        {
				SDAreaModel model = new SDAreaModel();
            model.IsNew = true;
			e= null;
			OnCreateShowing(this, e = new ControllerEventArgs<SDAreaModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }
			
            var me = GetContextModel(UIModelContextTypes.EditForm, model);

			me.IsPartialView = true;	
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
            {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                me.Properties.Find(p => p.PropertyName == ViewData["fk"].ToString()).IsReadOnly = true;
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
			
      
            //me.Items.Add(model);
            Showing(ref me);
            return ResolveView(me, me.Items[0]);
        }
		protected override  void GettingExtraData(ref UIModel<SDAreaModel> uiModel)
        {

            MyEventArgs<UIModel<SDAreaModel>> me = null;
            OnGettingExtraData(this, me = new MyEventArgs<UIModel<SDAreaModel>>() { Object = uiModel });
            //bool maybeAnyReplaced = false; 
            if (me != null)
            {
                uiModel = me.Object;
                //maybeAnyReplaced = true;
            }
           
			bool canFill = false;
			 string query = null ;
            bool isFK = false;
			PropertyDefinition prop =null;
			var contextRequest = this.GetContextRequest();
            contextRequest.CustomParams.Add(new CustomParam() { Name="ui", Value= SDArea.EntityName });

            			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDArea2");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidArea = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidArea = @GuidArea";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidArea = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidArea = @GuidArea";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDArea2")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidArea", new Nullable<Guid>(Guid.Parse( Request.QueryString["fkValue"])));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDAreasBR()).GetBy(query, contextRequest), "GuidArea", "Name", Request.QueryString["fkValue"]), PropertyName = "SDArea2" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDAreasBR()).GetBy(query, contextRequest), "GuidArea", "Name"), PropertyName = "SDArea2" });    

					}
    if (isFK)
                    {    
						var FkSDArea2 = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDArea2").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDArea2Text").SetValue(uiModel.Items[0], FkSDArea2.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDArea2").SetValue(uiModel.Items[0], Guid.Parse(FkSDArea2.Value));
                    
					}    
				}
			}
		 
			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDOrganization");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidOrganization = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidOrganization = @GuidOrganization";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidOrganization = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidOrganization = @GuidOrganization";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDOrganization")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidOrganization", new Nullable<Guid>(Guid.Parse( Request.QueryString["fkValue"])));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDOrganizationsBR()).GetBy(query, contextRequest), "GuidOrganization", "FullName", Request.QueryString["fkValue"]), PropertyName = "SDOrganization" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDOrganizationsBR()).GetBy(query, contextRequest), "GuidOrganization", "FullName"), PropertyName = "SDOrganization" });    

					}
    if (isFK)
                    {    
						var FkSDOrganization = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDOrganization").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDOrganizationText").SetValue(uiModel.Items[0], FkSDOrganization.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDOrganization").SetValue(uiModel.Items[0], Guid.Parse(FkSDOrganization.Value));
                    
					}    
				}
			}
		 
            

        }
		private void Showing(ref UIModel<SDAreaModel> uiModel) {
          	
			MyEventArgs<UIModel<SDAreaModel>> me = new MyEventArgs<UIModel<SDAreaModel>>() { Object = uiModel };
			 OnVirtualLayoutSettings(this, me);


            OnShowing(this, me);

			
			if ((Request != null && Request.QueryString["allFields"] == "1") || Request == null )
			{
				me.Object.Properties.ForEach(p=> p.IsHidden = false);
            }
            if (me != null)
            {
                uiModel = me.Object;
            }
          


			 if (uiModel.ContextType == UIModelContextTypes.EditForm)
			    GettingExtraData(ref uiModel);
            ViewData["UIModel"] = uiModel;

        }
        //
        // POST: /SDAreas/Create
		[MyAuthorize("c", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
        [HttpPost]
		[ValidateInput(false)] 
        public ActionResult CreateGen(SDAreaModel  model,  ContextRequest contextRequest)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
		 	e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDAreaModel>() { Item = model });
           
		  	if (!ModelState.IsValid) {
				model.IsNew = true;
				var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
                 if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                        ViewData["ispopup"] = true;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
                    return ResolveView(me, model);
            }
            try
            {
				if (model.GuidArea == null || model.GuidArea.ToString().Contains("000000000"))
				model.GuidArea = Guid.NewGuid();
	
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnCreating(this, e = new ControllerEventArgs<SDAreaModel>() { Item = model });
                if (e != null) {
                   if (e.Cancel && e.RedirectValues.Count > 0){
                        RouteValueDictionary rv = new RouteValueDictionary();
                        if (e.RedirectValues["area"] != null ){
                            rv.Add("area", e.RedirectValues["area"].ToString());
                        }
                        foreach (var item in e.RedirectValues.Where(p=>p.Key != "area" && p.Key != "controller" &&  p.Key != "action" ))
	                    {
		                    rv.Add(item.Key, item.Value);
	                    }

                        //if (e.RedirectValues["action"] != null && e.RedirectValues["controller"] != null && e.RedirectValues["area"] != null )
                        return RedirectToAction(e.RedirectValues["action"].ToString(), e.RedirectValues["controller"].ToString(), rv );


                        
                    }else if (e.Cancel && e.ActionResult != null )
                        return e.ActionResult;  
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				if (contextRequest == null || contextRequest.Company == null){
					contextRequest = GetContextRequest();
					
				}
                if (!cancel)
                	model.Bind(SDAreasBR.Instance.Create(model.GetBusinessObject(), contextRequest ));
				OnCreated(this, e = new ControllerEventArgs<SDAreaModel>() { Item = model });
                 if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                        return ResolveApiResponse("success", null, null, null);

                    }
                }
				 
				 if (e != null )
					if (e.ActionResult != null)
                    	replaceResult = true;		
				if (!replaceResult)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))
                    {
                        ViewData["__continue"] = true;
                    }
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"]) &&  string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
                        popupextra.Add("id", model.SafeKey);
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                       {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                            popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"area"));
                            popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                            popupextra.Add("action", actionDetails);
                       if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
                    {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))

                        {
                            var popupextra = GetRouteData();
                            popupextra.Add("id", model.SafeKey);
                            return RedirectToAction("EditViewGen", popupextra);
                        }
                        else
                        {
                            return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.ADD_DONE));
                        }
                    }        			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                        return Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]);
                    else{

							RouteValueDictionary popupextra = null; 
							if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"])){
                            popupextra = GetRouteData();
							 string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
                            if (!string.IsNullOrEmpty(area))
                                popupextra.Add("area", area);
                            
                            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"])) {
								popupextra.Add("id", model.SafeKey);
                                return RedirectToAction("EditGen", popupextra);

                            }else{
								
                            return RedirectToAction("Index", popupextra);
							}
							}else{
								return Content("ok");
							}
                        }
						 }
                else {
                    return e.ActionResult;
                    }
				}
            catch(Exception ex)
            {
					  SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        throw ex;
                    }
                    else
                    {
                       // return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
					   return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
                SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                model.IsNew = true;
                var me = GetContextModel(UIModelContextTypes.EditForm, model, true, model.GuidArea);
                Showing(ref me);
                if (isPopUp)
                {
                    
                        ViewData["ispopup"] = isPopUp;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
					if (Request != null)
						return ResolveView(me, model);
					else
						return Content("ok");
            }
        }        
        //
        // GET: /SDAreas/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }
			
		
		[MyAuthorize("u", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
		[MvcSiteMapNode(Area="SFSServiceDesk", Title="sss", Clickable=false, ParentKey = "SFSServiceDesk_SDArea_List")]
		public ActionResult EditGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDAreaResources.ENTITY_SINGLE;		 	
  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDAreaModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
            SDAreaModel model = null;
            // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
			bool dec = false;
            Guid ? idGuidDecripted = null ;
            if (Request != null && Request.QueryString["dec"] == "true")
            {
                dec = true;
                idGuidDecripted = Guid.Parse(id);
            }

            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model,dec,idGuidDecripted);
            Showing(ref me);


            if (!replaceResult)
            {
                 //return View("EditGen", me.Items[0]);
				 return ResolveView(me, me.Items[0]);
            }
            else {
                return e.ActionResult;
            }
        }
			[MyAuthorize("u", "SDArea","SFSServiceDesk", typeof(SDAreasController))]
		public ActionResult EditViewGen(string id)
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

					  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDAreaModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
			
            SDAreaModel model = null;
			 bool dec = false;
            Guid? guidId = null ;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                dec = true;
                guidId = Guid.Parse(id);
            }
            // si fue implementado el método parcial y no se ha decidido suspender la acción
            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
            var me = GetContextModel(UIModelContextTypes.EditForm, model, dec, guidId);
            Showing(ref me);

            return ResolveView(me, model);
        }
		[MyAuthorize("u", "SDArea",  "SFSServiceDesk", typeof(SDAreasController))]
		[HttpPost]
		[ValidateInput(false)] 
		        public ActionResult EditGen(SDAreaModel model)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
			e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDAreaModel>() { Item = model });
           
            if (!ModelState.IsValid)
            {
			   	var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
			
				if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"])){
                	ViewData["ispopup"] = true;
					return ResolveView(me, model);
				}
				else
					return ResolveView(me, model);
            }
            try
            {
			
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnEditing(this, e = new ControllerEventArgs<SDAreaModel>() { Item = model });
                if (e != null) {
                    if (e.Cancel && e.ActionResult != null)
                        return e.ActionResult;
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				ContextRequest context = new ContextRequest();
                context.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;

                SDArea resultObj = null;
			    if (!cancel)
                	resultObj = SDAreasBR.Instance.Update(model.GetBusinessObject(), GetContextRequest());
				
				OnEdited(this, e = new ControllerEventArgs<SDAreaModel>() { Item =   new SDAreaModel(resultObj) });
				if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                         return ResolveApiResponse("success", null, null, null);
                    }
                }
				
				if (e != null && e.ActionResult != null) replaceResult = true; 

                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Content("ok");
                }
                else
                {
				if (!replaceResult)
                {
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"])  && string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
						 if (Request != null && Request.QueryString["dec"] == "true")
                        {
                            popupextra.Add("id", model.Id);
                        }
                        else
                        {
							popupextra.Add("id", model.SafeKey);

							
                        }
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                        {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                        popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area"));
                        popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                        popupextra.Add("action", actionDetails);
                        if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
					if (isPopUp)
						return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.UPDATE_DONE));
        			    string returnUrl = null;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"])) {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.Form["ReturnAfter"];
                        else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"];
                    }
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else{
		RouteValueDictionary popupextra = null; 
						 if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"]))
                            {
							
							popupextra = GetRouteData();
							string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
							if (!string.IsNullOrEmpty(area))
								popupextra.Add("area", area);

							return RedirectToAction("Index", popupextra);
						}else{
							return Content("ok");
						}
						}
				 }
                else {
                    return e.ActionResult;
				}
                }		
            }
          catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content(ex.ToString());
                    }
                    else
                    {
                        //return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
						 return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
			    if (isPopUp)
                {
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(ex.Message));
                    
                }
                else
                {
                    SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                    
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else {
						  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
							ViewData["ispopup"] = true;
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
							ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
							ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

						var me = GetContextModel(UIModelContextTypes.EditForm, model);
						Showing(ref me);

						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
						{
							ViewData["ispopup"] = true;
							return ResolveView(me, model);
						}
						else
							return ResolveView(me, model);

						
					}
				}
            }
        }
        //
        // POST: /SDAreas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //  Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SDAreas/Delete/5
        
		[MyAuthorize("d", "SDArea", "SFSServiceDesk", typeof(SDAreasController))]
		[HttpDelete]
        public ActionResult DeleteGen(string objectKey, string extraParams)
        {
            try
            {
					
			
				Guid guidArea = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey.Replace("-", "/"), "GuidArea")); 
                BO.SDArea entity = new BO.SDArea() { GuidArea = guidArea };

                BR.SDAreasBR.Instance.Delete(entity, GetContextRequest());               
                return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.DELETE_DONE));

            }
            catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null)
                    {
                        message = ex.Data["usermessage"].ToString();
                    }

                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }
            }
        }
		/*[MyAuthorize()]
		public FileMediaResult Download(string query, bool? allSelected = false,  string selected = null , string orderBy = null , string direction = null , string format = null , string actionKey=null )
        {
			
            List<Guid> keysSelected1 = new List<Guid>();
            if (!string.IsNullOrEmpty(selected)) {
                foreach (var keyString in selected.Split(char.Parse("|")))
                {
				
                    keysSelected1.Add(Guid.Parse(keyString));
                }
            }
				
            query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(query, allSelected.Value, selected, "GuidArea");
            MyEventArgs<ContextActionModel<SDAreaModel>> eArgs = null;
            List<SDAreaModel> results = GetBy(query, null, null, orderBy, direction, GetContextRequest(), keysSelected1);
            OnDownloading(this, eArgs = new MyEventArgs<ContextActionModel<SDAreaModel>>() { Object = new ContextActionModel<SDAreaModel>() { Query = query, SelectedItems = results, Selected=selected, SelectAll = allSelected.Value, Direction = direction , OrderBy = orderBy, ActionKey=actionKey  } });

            if (eArgs != null)
            {
                if (eArgs.Object.Result != null)
                    return (FileMediaResult)eArgs.Object.Result;
            }
            

            return (new FeaturesController()).ExportDownload(typeof(SDAreaModel), results, format, this.GetUIPluralText("SFSServiceDesk", "SDArea"));
            
        }
			*/
		
		[HttpPost]
        public ActionResult CustomActionExecute(ContextActionModel model) {
		 try
            {
			//List<Guid> keysSelected1 = new List<Guid>();
			List<object> keysSelected1 = new List<object>();
            if (!string.IsNullOrEmpty(model.Selected))
            {
                foreach (var keyString in model.Selected.Split(char.Parse(",")))
                {
				
				keysSelected1.Add(Guid.Parse(keyString.Split(char.Parse("|"))[0]));
                        
                    

			
                }
            }
			DataAction dataAction = DataAction.GetDataAction(Request);
			 model.Selected = dataAction.Selected;

            model.Query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(dataAction.Query, dataAction.AllSelected, dataAction.Selected, "GuidArea");
           
            
			
			#region implementaci�n de m�todo parcial
            bool replaceResult = false;
            MyEventArgs<ContextActionModel<SDAreaModel>> actionEventArgs = null;
           
			if (model.ActionKey != "deletemany" && model.ActionKey != "deleterelmany" && model.ActionKey != "updateRel" &&  model.ActionKey != "delete-relation-fk" && model.ActionKey != "restore" )
			{
				ContextRequest context = SFSdotNet.Framework.My.Context.BuildContextRequestSafe(System.Web.HttpContext.Current);
				context.UseMode = dataAction.Usemode;

				if (model.IsBackground)
				{
					System.Threading.Tasks.Task.Run(() => 
						OnCustomActionExecutingBackground(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDAreaModel>>() { Object = new ContextActionModel<SDAreaModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } })
					);
				}
				else
				{
					OnCustomActionExecuting(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDAreaModel>>() {  Object = new ContextActionModel<SDAreaModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } });
				}
			}
            List<SDAreaModel> results = null;
	
			if (model.ActionKey == "deletemany") { 
				
				BR.SDAreasBR.Instance.Delete(model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());

            }
	
            else if (model.ActionKey == "updateRel" || model.ActionKey == "delete-relation-fk" || model.ActionKey == "updateRel-proxyMany")
            {
               try {
                   string valueForUpdate = null;
				   string propForUpdate = null;
				   if (!string.IsNullOrEmpty(Request.Params["propertyForUpdate"])){
						propForUpdate = Request.Params["propertyForUpdate"];
				   }
				    if (string.IsNullOrEmpty(propForUpdate) && !string.IsNullOrEmpty(Request.QueryString["propertyForUpdate"]))
                   {
                       propForUpdate = Request.QueryString["propertyForUpdate"];
                   }
                    if (model.ActionKey != "delete-relation-fk")
                    {
                        valueForUpdate = Request.QueryString["valueForUpdate"];
                    }
                    BR.SDAreasBR.Instance.UpdateAssociation(propForUpdate, valueForUpdate, model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());
					
                    if (model.ActionKey == "delete-relation-fk")
                    {
                        MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]);

                        return PartialView("ResultMessageView", message);
                    }
                    else
                    {
                        return Content("ok");
                    }
       
          
                }
                catch (Exception ex)
                {
				        SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
           
                }
            
            }
		
                if (actionEventArgs == null && !model.IsBackground)
                {
                    //if (model.ActionKey != "deletemany"  && model.ActionKey != "deleterelmany")
                    //{
                     //   throw new NotImplementedException("");
                    //}
                }
                else
                {
					if (model.IsBackground == false )
						 replaceResult = actionEventArgs.Object.Result is ActionResult /*actionEventArgs.Object.ReplaceResult*/;
                }
                #endregion
                if (!replaceResult)
                {
                    if (Request != null && Request.IsAjaxRequest())
                    {
						MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]) ;
                        if (model.IsBackground )
                            message.Message = GlobalMessages.THE_PROCESS_HAS_BEEN_STARTED;
                        
                        return PartialView("ResultMessageView", message);                    
					}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return (ActionResult)actionEventArgs.Object.Result;
                }
            }
            catch (Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null) {
                        message = ex.Data["usermessage"].ToString();
                    }
					 SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }

            }
        }
        //
        // POST: /SDAreas/Delete/5
        
			
	
    }
}
namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
	using SFS.ServiceDesk.Web.Mvc.Models.SDAreaPersons;

    public partial class SDAreaPersonsController : SFS.ServiceDesk.Web.Mvc.ControllerBase<Models.SDAreaPersons.SDAreaPersonModel>
    {

       


	#region partial methods
        ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e = null;
        partial void OnValidating(object sender, ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e);
        partial void OnGettingExtraData(object sender, MyEventArgs<UIModel<Models.SDAreaPersons.SDAreaPersonModel>> e);
        partial void OnCreating(object sender, ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e);
        partial void OnCreated(object sender, ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e);
        partial void OnEditing(object sender, ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e);
        partial void OnEdited(object sender, ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e);
        partial void OnDeleting(object sender, ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e);
        partial void OnDeleted(object sender, ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e);
    	partial void OnShowing(object sender, MyEventArgs<UIModel<Models.SDAreaPersons.SDAreaPersonModel>> e);
    	partial void OnGettingByKey(object sender, ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e);
        partial void OnTaken(object sender, ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e);
       	partial void OnCreateShowing(object sender, ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e);
		partial void OnEditShowing(object sender, ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e);
		partial void OnDetailsShowing(object sender, ControllerEventArgs<Models.SDAreaPersons.SDAreaPersonModel> e);
 		partial void OnActionsCreated(object sender, MyEventArgs<UIModel<Models.SDAreaPersons.SDAreaPersonModel >> e);
		partial void OnCustomActionExecuting(object sender, MyEventArgs<ContextActionModel<Models.SDAreaPersons.SDAreaPersonModel>> e);
		partial void OnCustomActionExecutingBackground(object sender, MyEventArgs<ContextActionModel<Models.SDAreaPersons.SDAreaPersonModel>> e);
        partial void OnDownloading(object sender, MyEventArgs<ContextActionModel<Models.SDAreaPersons.SDAreaPersonModel>> e);
      	partial void OnAuthorization(object sender, AuthorizationContext context);
		 partial void OnFilterShowing(object sender, MyEventArgs<UIModel<Models.SDAreaPersons.SDAreaPersonModel >> e);
         partial void OnSummaryOperationShowing(object sender, MyEventArgs<UIModel<Models.SDAreaPersons.SDAreaPersonModel>> e);

        partial void OnExportActionsCreated(object sender, MyEventArgs<UIModel<Models.SDAreaPersons.SDAreaPersonModel>> e);


		protected override void OnVirtualFilterShowing(object sender, MyEventArgs<UIModel<SDAreaPersonModel>> e)
        {
            OnFilterShowing(sender, e);
        }
		 public override void OnVirtualExportActionsCreated(object sender, MyEventArgs<UIModel<SDAreaPersonModel>> e)
        {
            OnExportActionsCreated(sender, e);
        }
        public override void OnVirtualDownloading(object sender, MyEventArgs<ContextActionModel<SDAreaPersonModel>> e)
        {
            OnDownloading(sender, e);
        }
        public override void OnVirtualShowing(object sender, MyEventArgs<UIModel<SDAreaPersonModel>> e)
        {
            OnShowing(sender, e);
        }

	#endregion
	#region API
	 public override ActionResult ApiCreateGen(SDAreaPersonModel model, ContextRequest contextRequest)
        {
            return CreateGen(model, contextRequest);
        }

              public override ActionResult ApiGetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJson(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }
        public override ActionResult ApiGetByKeyJson(string id, ContextRequest contextRequest)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
            return  GetByKeyJson(id, contextRequest, true);
        }
      
		 public override ActionResult ApiGetByCount(string filter, ContextRequest contextRequest)
        {
            return GetByCount(filter, contextRequest);
        }
         protected override ActionResult ApiDeleteGen(List<SDAreaPersonModel> models, ContextRequest contextRequest)
        {
            List<SDAreaPerson> objs = new List<SDAreaPerson>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                BR.SDAreaPersonsBR.Instance.DeleteBulk(objs, contextRequest);
                if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("success", null, null, null);

                }
                else
                {
                    return Content("ok");

                }
            }
            catch (Exception ex)
            {
               if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "error", reason = "error", message= ex.ToString() }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("error", "exception", ex.ToString(), null );

                }
                else
                {
                    return Json(ex.ToString(), JsonRequestBehavior.AllowGet);

                }
            }
        }
        protected override ActionResult ApiUpdateGen(List<SDAreaPersonModel> models, ContextRequest contextRequest)
        {
            List<SDAreaPerson> objs = new List<SDAreaPerson>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                foreach (var obj in objs)
                {
                    BR.SDAreaPersonsBR.Instance.Update(obj, contextRequest);

                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }


	#endregion
#region Validation methods	
	    private void Validations(SDAreaPersonModel model) { 
            #region Remote validations

            #endregion
		}

#endregion
		
 		public AuthorizationContext Authorization(AuthorizationContext context)
        {
            OnAuthorization(this,  context );
            return context ;
        }
		public List<SDAreaPersonModel> GetAll() {
            			var bos = BR.SDAreaPersonsBR.Instance.GetBy("",
					new SFSdotNet.Framework.My.ContextRequest()
					{
						CustomQuery = new SFSdotNet.Framework.My.CustomQuery()
						{
							OrderBy = "GuidAreaPerson",
							SortDirection = SFSdotNet.Framework.Data.SortDirection.Ascending
						}
					});
            			List<SDAreaPersonModel> results = new List<SDAreaPersonModel>();
            SDAreaPersonModel model = null;
            foreach (var bo in bos)
            {
                model = new SDAreaPersonModel();
                model.Bind(bo);
                results.Add(model);
            }
            return results;

        }
        //
        // GET: /SDAreaPersons/
		[MyAuthorize("r", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
		public ActionResult Index()
        {
    		var uiModel = GetContextModel(UIModelContextTypes.ListForm, null);
			ViewBag.UIModel = uiModel;
			uiModel.FilterStart = (string)ViewData["startFilter"];
                    MyEventArgs<UIModel<SDAreaPersonModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDAreaPersonModel>>() { Object = uiModel });

			OnExportActionsCreated(this, (me != null ? me : me = new MyEventArgs<UIModel<SDAreaPersonModel>>() { Object = uiModel }));

            if (me != null)
            {
                uiModel = me.Object;
            }
            if (me == null)
                me = new MyEventArgs<UIModel<SDAreaPersonModel>>() { Object = uiModel };
           
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;


            //return View("ListGen");
			return ResolveView(uiModel);
        }
		[MyAuthorize("r", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
		public ActionResult ListViewGen(string idTab, string fk , string fkValue, string startFilter, ListModes  listmode  = ListModes.SimpleList, PropertyDefinition parentRelationProperty = null, object parentRelationPropertyValue = null )
        {
			ViewData["idTab"] = System.Web.HttpContext.Current.Request.QueryString["idTab"]; 
		 	ViewData["detpop"] = true; // details in popup
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"])) {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"]; 
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
            {
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["startFilter"]))
            {
                ViewData["startFilter"] = Request.QueryString["startFilter"];
            }
			
			UIModel<SDAreaPersonModel> uiModel = GetContextModel(UIModelContextTypes.ListForm, null);

            MyEventArgs<UIModel<SDAreaPersonModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDAreaPersonModel>>() { Object = uiModel });
            if (me == null)
                me = new MyEventArgs<UIModel<SDAreaPersonModel>>() { Object = uiModel };
            uiModel.Properties = GetProperties(uiModel);
            uiModel.ContextType = UIModelContextTypes.ListForm;
             uiModel.FilterStart = (string)ViewData["startFilter"];
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;
			 if (listmode == ListModes.SimpleList)
                return ResolveView(uiModel);
            else
            {
                ViewData["parentRelationProperty"] = parentRelationProperty;
                ViewData["parentRelationPropertyValue"] = parentRelationPropertyValue;
                return PartialView("ListForTagSelectView");
            }
            return ResolveView(uiModel);
        }
		List<PropertyDefinition> _properties = null;

		 protected override List<PropertyDefinition> GetProperties(UIModel uiModel,  params string[] specificProperties)
        { 
            return GetProperties(uiModel, false, null, specificProperties);
        }

		protected override List<PropertyDefinition> GetProperties(UIModel uiModel, bool decripted, Guid? id, params string[] specificProperties)
            {

			bool allProperties = true;    
                if (specificProperties != null && specificProperties.Length > 0)
                {
                    allProperties = false;
                }


			List<CustomProperty> customProperties = new List<CustomProperty>();
			if (_properties == null)
                {
                List<PropertyDefinition> results = new List<PropertyDefinition>();

			string idSDAreaPerson = GetRouteDataOrQueryParam("id");
			if (idSDAreaPerson != null)
			{
				if (!decripted)
                {
					idSDAreaPerson = SFSdotNet.Framework.Entities.Utils.GetPropertyKey(idSDAreaPerson.Replace("-","/"), "GuidAreaPerson");
				}else{
					if (id != null )
						idSDAreaPerson = id.Value.ToString();                

				}
			}

			bool visibleProperty = true;	
			 bool conditionalshow =false;
                if (uiModel.ContextType == UIModelContextTypes.EditForm || uiModel.ContextType == UIModelContextTypes.DisplayForm ||  uiModel.ContextType == UIModelContextTypes.GenericForm )
                    conditionalshow = true;
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidAreaPerson"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidAreaPerson")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 100,
																	
					CustomProperties = customProperties,

                    PropertyName = "GuidAreaPerson",

					 MaxLength = 0,
					IsRequired = true ,
					IsHidden = true,
                    SystemProperty =  SystemProperties.Identifier ,
					IsDefaultProperty = true,
                    SortBy = "GuidAreaPerson",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDAreaPersonResources.GUIDAREAPERSON*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidArea"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidArea")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 101,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidArea",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "GuidArea",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDAreaPersonResources.GUIDAREA*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidPerson"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidPerson")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 102,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidPerson",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "GuidPerson",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDAreaPersonResources.GUIDPERSON*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDArea"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDAreaPersons" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDArea.GuidArea")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDArea.GuidArea" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDAreas" });
			

	
	//fk_SdAreaPerson_SdArea
		//if (this.Request.QueryString["fk"] != "SDArea")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 103,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDArea",
					PropertyNavigationKey = "GuidArea",
					PropertyNavigationText = "Name",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="Name",
					GetMethodDisplayValue = "GuidArea",
					
					CustomProperties = customProperties,

                    PropertyName = "SDArea",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDArea.Name",
					
	
                    TypeName = "SFSServiceDeskModel.SDArea",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDAreas"
                    /*,PropertyDisplayName = Resources.SDAreaPersonResources.SDAREA*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDPerson"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDAreaPersons" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDPerson.GuidPerson")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDPerson.GuidPerson" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDPersons" });
			

	
	//fk_SdAreaPerson_SdPerson
		//if (this.Request.QueryString["fk"] != "SDPerson")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 104,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDPerson",
					PropertyNavigationKey = "GuidPerson",
					PropertyNavigationText = "DisplayName",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="DisplayName",
					GetMethodDisplayValue = "GuidPerson",
					
					CustomProperties = customProperties,

                    PropertyName = "SDPerson",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDPerson.DisplayName",
					
	
                    TypeName = "SFSServiceDeskModel.SDPerson",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDPersons"
                    /*,PropertyDisplayName = Resources.SDAreaPersonResources.SDPERSON*/
                });
		//	}
	
	}
	
				
                    _properties = results;
                    return _properties;
                }
                else {
                    return _properties;
                }
            }

		protected override  UIModel<SDAreaPersonModel> GetByForShow(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, params  object[] extraParams)
        {
			if (Request != null )
				if (!string.IsNullOrEmpty(Request.QueryString["q"]))
					filter = filter + HttpUtility.UrlDecode(Request.QueryString["q"]);
 if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
            }
            var bos = BR.SDAreaPersonsBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), contextRequest, extraParams);
			//var bos = BR.SDAreaPersonsBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), context, extraParams);
            SDAreaPersonModel model = null;
            List<SDAreaPersonModel> results = new List<SDAreaPersonModel>();
            foreach (var item in bos)
            {
                model = new SDAreaPersonModel();
				model.Bind(item);
				results.Add(model);
            }
            //return results;
			UIModel<SDAreaPersonModel> uiModel = GetContextModel(UIModelContextTypes.Items, null);
            uiModel.Items = results;
			if (Request != null){
				if (SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(Request.RequestContext, "action") == "Download")
				{
					uiModel.ContextType = UIModelContextTypes.ExportDownload;
				}
			}
            Showing(ref uiModel);
            return uiModel;
		}			
		
		//public List<SDAreaPersonModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params  object[] extraParams)
        //{
		//	var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, null, extraParams);
        public override List<SDAreaPersonModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest,  params  object[] extraParams)
        {
            var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
           
            return uiModel.Items;
		
        }
		/*
        [MyAuthorize("r", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir)
        {
			 return GetByJsonBase(filter, pageSize, page, orderBy, orderDir);
        }*/

		  [MyAuthorize("r", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir,ContextRequest contextRequest,  object[] extraParams)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
			 
			 if (this.IsRESTRequest == false)
            {
                return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
            }else
            {
                try
                {
                    return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);

                }
            }
        }
/*		  [MyAuthorize("r", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
       public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }*/
		[MyAuthorize()]
		public ActionResult GetByCount(string filter, ContextRequest contextRequest) {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
           
			
             if (this.IsRESTRequest == true)
            {
                try
                {

                    var result = BR.SDAreaPersonsBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);

                   if (Request.QueryString["v"] == "2")
                    {
						return ResolveApiResponse("success", null, null, result);

                        //return Json(new { status = "success", data = result }, JsonRequestBehavior.AllowGet);
                    }else
                    {
                        return Content(result.ToString());

                    }
                }
                catch (Exception ex)
                {
                  //  return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
				  return ResolveApiResponse("error", "exception", ex.ToString(), null);

                }
            }
            else
            {
                var result = BR.SDAreaPersonsBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);
                return Content(result.ToString());
            }
		}
		

		[MyAuthorize("r", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
        public ActionResult GetByKeyJson(string id, ContextRequest contextRequest,  bool dec = false)
        {
            return Json(GetByKey(id, null, contextRequest, dec), JsonRequestBehavior.AllowGet);
        }
		public SDAreaPersonModel GetByKey(string id) {
			return GetByKey(id, null,null, false);
       	}
		    public SDAreaPersonModel GetByKey(string id, string includes)
        {
            return GetByKey(id, includes, false);
        }
		 public  SDAreaPersonModel GetByKey(string id, string includes, ContextRequest contextRequest)
        {
            return GetByKey(id, includes, contextRequest, false);
        }
		/*
		  public ActionResult ShowField(string fieldName, string idField) {
		   string safePropertyName = fieldName;
              if (fieldName.StartsWith("Fk"))
              {
                  safePropertyName = fieldName.Substring(2, fieldName.Length - 2);
              }

             SDAreaPersonModel model = new  SDAreaPersonModel();

            UIModel uiModel = GetUIModel(model, new string[] { "NoField-" });
			
				uiModel.Properties = GetProperties(uiModel, safePropertyName);
		uiModel.Properties.ForEach(p=> p.ContextType = uiModel.ContextType );
            uiModel.ContextType = UIModelContextTypes.FilterFields;
            uiModel.OverrideApp = GetOverrideApp();
            uiModel.UseMode = GetUseMode();

            ViewData["uiModel"] = uiModel;
			var prop = uiModel.Properties.FirstOrDefault(p=>p.PropertyName == safePropertyName);
            //if (prop.IsNavigationProperty && prop.IsNavigationPropertyMany == false)
            //{
            //    ViewData["currentProperty"] = uiModel.Properties.FirstOrDefault(p => p.PropertyName != fieldName + "Text");
            //}else if (prop.IsNavigationProperty == false){
                ViewData["currentProperty"] = prop;
           // }
            ((PropertyDefinition)ViewData["currentProperty"]).RemoveLayout = true;
			ViewData["withContainer"] = false;


            return PartialView("GenericField", model);


        }
      */
	public SDAreaPersonModel GetByKey(string id, ContextRequest contextRequest, bool dec)
        {
            return GetByKey(id, null, contextRequest, dec);
        }
        public SDAreaPersonModel GetByKey(string id, string  includes, bool dec)
        {
            return GetByKey(id, includes, null, dec);
        }

        public SDAreaPersonModel GetByKey(string id, string includes, ContextRequest contextRequest, bool dec) {
		             SDAreaPersonModel model = null;
            ControllerEventArgs<SDAreaPersonModel> e = null;
			string objectKey = id.Replace("-","/");
             OnGettingByKey(this, e=  new ControllerEventArgs<SDAreaPersonModel>() { Id = objectKey  });
             bool cancel = false;
             SDAreaPersonModel eItem = null;
             if (e != null)
             {
                 cancel = e.Cancel;
                 eItem = e.Item;
             }
			if (cancel == false && eItem == null)
             {
			Guid guidAreaPerson = Guid.Empty; //new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, "GuidAreaPerson"));
			if (dec)
                 {
                     guidAreaPerson = new Guid(id);
                 }
                 else
                 {
                     guidAreaPerson = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, null));
                 }
			
            
				model = new SDAreaPersonModel();
                  if (contextRequest == null)
                {
                    contextRequest = GetContextRequest();
                }
				var bo = BR.SDAreaPersonsBR.Instance.GetByKey(guidAreaPerson, GetUseMode(), contextRequest,  includes);
				 if (bo != null)
                    model.Bind(bo);
                else
                    return null;
			}
             else {
                 model = eItem;
             }
			model.IsNew = false;

            return model;
        }
        // GET: /SDAreaPersons/DetailsGen/5
		[MyAuthorize("r", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
        public ActionResult DetailsGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDAreaPersonResources.ENTITY_PLURAL;
			 #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDAreaPersonModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
            #endregion



			 bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
			//UIModel<SDAreaPersonModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, decripted), decripted, guidId);
			var item = GetByKey(id, null, null, decripted);
			if (item == null)
            {
                 RouteValueDictionary rv = new RouteValueDictionary();
                string usemode = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"usemode");
                string overrideModule = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "overrideModule");
                string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");

                if(!string.IsNullOrEmpty(usemode)){
                    rv.Add("usemode", usemode);
                }
                if(!string.IsNullOrEmpty(overrideModule)){
                    rv.Add("overrideModule", overrideModule);
                }
                if (!string.IsNullOrEmpty(area))
                {
                    rv.Add("area", area);
                }

                return RedirectToAction("Index", rv);
            }
            //
            UIModel<SDAreaPersonModel> uiModel = null;
                uiModel = GetContextModel(UIModelContextTypes.DisplayForm, item, decripted, guidId);



            MyEventArgs<UIModel<SDAreaPersonModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDAreaPersonModel>>() { Object = uiModel });

            if (me != null) {
                uiModel = me.Object;
            }
			
            Showing(ref uiModel);
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			
            //return View("DisplayGen", uiModel.Items[0]);
			return ResolveView(uiModel, uiModel.Items[0]);

        }
		[MyAuthorize("r", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
		public ActionResult DetailsViewGen(string id)
        {

		 bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDAreaPersonModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
           
			if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
 			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
           
        	 //var uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id));
			 
            bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true")
                {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
            UIModel<SDAreaPersonModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, null, decripted), decripted, guidId);
			

            MyEventArgs<UIModel<SDAreaPersonModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDAreaPersonModel>>() { Object = uiModel });

            if (me != null)
            {
                uiModel = me.Object;
            }
            
            Showing(ref uiModel);
            return ResolveView(uiModel, uiModel.Items[0]);
        
        }
        //
        // GET: /SDAreaPersons/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /SDAreaPersons/CreateGen
		[MyAuthorize("c", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
        public ActionResult CreateGen()
        {
			SDAreaPersonModel model = new SDAreaPersonModel();
            model.IsNew = true;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model);

			OnCreateShowing(this, e = new ControllerEventArgs<SDAreaPersonModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }

             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                 ViewData["ispopup"] = true;
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                 ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                 ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

            Showing(ref me);

			return ResolveView(me, me.Items[0]);
        } 
			
		protected override UIModel<SDAreaPersonModel> GetContextModel(UIModelContextTypes formMode, SDAreaPersonModel model)
        {
            return GetContextModel(formMode, model, false, null);
        }
			
		 private UIModel<SDAreaPersonModel> GetContextModel(UIModelContextTypes formMode, SDAreaPersonModel model, bool decript, Guid ? id) {
            UIModel<SDAreaPersonModel> me = new UIModel<SDAreaPersonModel>(true, "SDAreaPersons");
			me.UseMode = GetUseMode();
			me.Controller = this;
			me.OverrideApp = GetOverrideApp();
			me.ContextType = formMode ;
			me.Id = "SDAreaPerson";
			
            me.ModuleKey = "SFSServiceDesk";

			me.ModuleNamespace = "SFS.ServiceDesk";
            me.EntityKey = "SDAreaPerson";
            me.EntitySetName = "SDAreaPersons";

			me.AreaAction = "SFSServiceDesk";
            me.ControllerAction = "SDAreaPersons";
            me.PropertyKeyName = "GuidAreaPerson";

            me.Properties = GetProperties(me, decript, id);
 			
			if (Request != null)
            {
                string actionName = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam( Request.RequestContext, "action");
                if(actionName != null && actionName.ToLower().Contains("create") ){
                    me.IsNew = true;
                }
            }
			 #region Buttons
			 if (Request != null ){
             if (formMode == UIModelContextTypes.DisplayForm || formMode == UIModelContextTypes.EditForm || formMode == UIModelContextTypes.ListForm)
				me.ActionButtons = GetActionButtons(formMode,model != null ?(Request.QueryString["dec"] == "true" ? model.Id : model.SafeKey)  : null, "SFSServiceDesk", "SDAreaPersons", "SDAreaPerson", me.IsNew);

            //me.ActionButtons.Add(new ActionModel() { ActionKey = "return", Title = GlobalMessages.RETURN, Url = System.Web.VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDAreaPersons" });
			if (this.HttpContext != null &&  !this.HttpContext.SkipAuthorization){
				//antes this.HttpContext
				me.SetAction("u", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("u", "SDAreaPerson", "SFSServiceDesk"));
				me.SetAction("c", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("c", "SDAreaPerson", "SFSServiceDesk"));
				me.SetAction("d", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("d", "SDAreaPerson", "SFSServiceDesk"));
			
			}else{
				me.SetAction("u", true);
				me.SetAction("c", true);
				me.SetAction("d", true);

			}
            #endregion              
         
            switch (formMode)
            {
                case UIModelContextTypes.DisplayForm:
					//me.TitleForm = SDAreaPersonResources.SDAREAPERSONS_DETAILS;
                    me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.MODIFY_DATA;
					 me.Properties.Where(p=>p.PropertyName  != "Id" && p.IsForeignKey == false).ToList().ForEach(p => p.IsHidden = false);

					 me.Properties.Where(p => (p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier) ).ToList().ForEach(p=> me.SetHide(p.PropertyName));

                    break;
                case UIModelContextTypes.EditForm:
				  me.Properties.Where(p=>p.SystemProperty != SystemProperties.Identifier && p.IsForeignKey == false && p.PropertyName != "Id").ToList().ForEach(p => p.IsHidden = false);

					if (model != null)
                    {
						

                        me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.SAVE_DATA;                        
                        me.ActionButtons.First(p => p.ActionKey == "c").Title = GlobalMessages.SAVE_DATA;
						if (model.IsNew ){
							//me.TitleForm = SDAreaPersonResources.SDAREAPERSONS_ADD_NEW;
							me.ActionName = "CreateGen";
							me.Properties.RemoveAll(p => p.SystemProperty != null || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));
						}else{
							
							me.ActionName = "EditGen";

							//me.TitleForm = SDAreaPersonResources.SDAREAPERSONS_EDIT;
							me.Properties.RemoveAll(p => p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));	
						}
						//me.Properties.Remove(me.Properties.Find(p => p.PropertyName == "UpdatedDate"));
					
					}
                    break;
                case UIModelContextTypes.FilterFields:
                    break;
                case UIModelContextTypes.GenericForm:
                    break;
                case UIModelContextTypes.Items:
				//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "GuidAreaPerson") != null){
						me.Properties.Find(p => p.PropertyName == "GuidAreaPerson").IsHidden = false;
					 }
					 
                    
					

						 if (me.Properties.Find(p => p.PropertyName == "GuidAreaPerson") != null){
						me.Properties.Find(p => p.PropertyName == "GuidAreaPerson").IsHidden = false;
					 }
					 
                    
					


                  


					//}
                    break;
                case UIModelContextTypes.ListForm:
					PropertyDefinition propFinded = null;
					//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "GuidAreaPerson") != null){
						me.Properties.Find(p => p.PropertyName == "GuidAreaPerson").IsHidden = false;
					 }
					
					me.PrincipalActionName = "GetByJson";
					//}
					//me.TitleForm = SDAreaPersonResources.SDAREAPERSONS_LIST;
                    break;
                default:
                    break;
            }
            	this.SetDefaultProperties(me);
			}
			if (model != null )
            	me.Items.Add(model);
            return me;
        }
		// GET: /SDAreaPersons/CreateViewGen
		[MyAuthorize("c", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
        public ActionResult CreateViewGen()
        {
				SDAreaPersonModel model = new SDAreaPersonModel();
            model.IsNew = true;
			e= null;
			OnCreateShowing(this, e = new ControllerEventArgs<SDAreaPersonModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }
			
            var me = GetContextModel(UIModelContextTypes.EditForm, model);

			me.IsPartialView = true;	
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
            {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                me.Properties.Find(p => p.PropertyName == ViewData["fk"].ToString()).IsReadOnly = true;
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
			
      
            //me.Items.Add(model);
            Showing(ref me);
            return ResolveView(me, me.Items[0]);
        }
		protected override  void GettingExtraData(ref UIModel<SDAreaPersonModel> uiModel)
        {

            MyEventArgs<UIModel<SDAreaPersonModel>> me = null;
            OnGettingExtraData(this, me = new MyEventArgs<UIModel<SDAreaPersonModel>>() { Object = uiModel });
            //bool maybeAnyReplaced = false; 
            if (me != null)
            {
                uiModel = me.Object;
                //maybeAnyReplaced = true;
            }
           
			bool canFill = false;
			 string query = null ;
            bool isFK = false;
			PropertyDefinition prop =null;
			var contextRequest = this.GetContextRequest();
            contextRequest.CustomParams.Add(new CustomParam() { Name="ui", Value= SDAreaPerson.EntityName });

            			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDArea");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidArea = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidArea = @GuidArea";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidArea = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidArea = @GuidArea";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDArea")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidArea", new Nullable<Guid>(Guid.Parse( Request.QueryString["fkValue"])));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDAreasBR()).GetBy(query, contextRequest), "GuidArea", "Name", Request.QueryString["fkValue"]), PropertyName = "SDArea" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDAreasBR()).GetBy(query, contextRequest), "GuidArea", "Name"), PropertyName = "SDArea" });    

					}
    if (isFK)
                    {    
						var FkSDArea = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDArea").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDAreaText").SetValue(uiModel.Items[0], FkSDArea.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDArea").SetValue(uiModel.Items[0], Guid.Parse(FkSDArea.Value));
                    
					}    
				}
			}
		 
			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDPerson");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidPerson = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidPerson = @GuidPerson";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidPerson = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidPerson = @GuidPerson";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDPerson")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidPerson", new Nullable<Guid>(Guid.Parse( Request.QueryString["fkValue"])));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDPersonsBR()).GetBy(query, contextRequest), "GuidPerson", "DisplayName", Request.QueryString["fkValue"]), PropertyName = "SDPerson" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDPersonsBR()).GetBy(query, contextRequest), "GuidPerson", "DisplayName"), PropertyName = "SDPerson" });    

					}
    if (isFK)
                    {    
						var FkSDPerson = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDPerson").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDPersonText").SetValue(uiModel.Items[0], FkSDPerson.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDPerson").SetValue(uiModel.Items[0], Guid.Parse(FkSDPerson.Value));
                    
					}    
				}
			}
		 
            

        }
		private void Showing(ref UIModel<SDAreaPersonModel> uiModel) {
          	
			MyEventArgs<UIModel<SDAreaPersonModel>> me = new MyEventArgs<UIModel<SDAreaPersonModel>>() { Object = uiModel };
			 OnVirtualLayoutSettings(this, me);


            OnShowing(this, me);

			
			if ((Request != null && Request.QueryString["allFields"] == "1") || Request == null )
			{
				me.Object.Properties.ForEach(p=> p.IsHidden = false);
            }
            if (me != null)
            {
                uiModel = me.Object;
            }
          


			 if (uiModel.ContextType == UIModelContextTypes.EditForm)
			    GettingExtraData(ref uiModel);
            ViewData["UIModel"] = uiModel;

        }
        //
        // POST: /SDAreaPersons/Create
		[MyAuthorize("c", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
        [HttpPost]
		[ValidateInput(false)] 
        public ActionResult CreateGen(SDAreaPersonModel  model,  ContextRequest contextRequest)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
		 	e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDAreaPersonModel>() { Item = model });
           
		  	if (!ModelState.IsValid) {
				model.IsNew = true;
				var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
                 if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                        ViewData["ispopup"] = true;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
                    return ResolveView(me, model);
            }
            try
            {
				if (model.GuidAreaPerson == null || model.GuidAreaPerson.ToString().Contains("000000000"))
				model.GuidAreaPerson = Guid.NewGuid();
	
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnCreating(this, e = new ControllerEventArgs<SDAreaPersonModel>() { Item = model });
                if (e != null) {
                   if (e.Cancel && e.RedirectValues.Count > 0){
                        RouteValueDictionary rv = new RouteValueDictionary();
                        if (e.RedirectValues["area"] != null ){
                            rv.Add("area", e.RedirectValues["area"].ToString());
                        }
                        foreach (var item in e.RedirectValues.Where(p=>p.Key != "area" && p.Key != "controller" &&  p.Key != "action" ))
	                    {
		                    rv.Add(item.Key, item.Value);
	                    }

                        //if (e.RedirectValues["action"] != null && e.RedirectValues["controller"] != null && e.RedirectValues["area"] != null )
                        return RedirectToAction(e.RedirectValues["action"].ToString(), e.RedirectValues["controller"].ToString(), rv );


                        
                    }else if (e.Cancel && e.ActionResult != null )
                        return e.ActionResult;  
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				if (contextRequest == null || contextRequest.Company == null){
					contextRequest = GetContextRequest();
					
				}
                if (!cancel)
                	model.Bind(SDAreaPersonsBR.Instance.Create(model.GetBusinessObject(), contextRequest ));
				OnCreated(this, e = new ControllerEventArgs<SDAreaPersonModel>() { Item = model });
                 if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                        return ResolveApiResponse("success", null, null, null);

                    }
                }
				 
				 if (e != null )
					if (e.ActionResult != null)
                    	replaceResult = true;		
				if (!replaceResult)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))
                    {
                        ViewData["__continue"] = true;
                    }
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"]) &&  string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
                        popupextra.Add("id", model.SafeKey);
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                       {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                            popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"area"));
                            popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                            popupextra.Add("action", actionDetails);
                       if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
                    {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))

                        {
                            var popupextra = GetRouteData();
                            popupextra.Add("id", model.SafeKey);
                            return RedirectToAction("EditViewGen", popupextra);
                        }
                        else
                        {
                            return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.ADD_DONE));
                        }
                    }        			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                        return Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]);
                    else{

							RouteValueDictionary popupextra = null; 
							if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"])){
                            popupextra = GetRouteData();
							 string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
                            if (!string.IsNullOrEmpty(area))
                                popupextra.Add("area", area);
                            
                            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"])) {
								popupextra.Add("id", model.SafeKey);
                                return RedirectToAction("EditGen", popupextra);

                            }else{
								
                            return RedirectToAction("Index", popupextra);
							}
							}else{
								return Content("ok");
							}
                        }
						 }
                else {
                    return e.ActionResult;
                    }
				}
            catch(Exception ex)
            {
					  SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        throw ex;
                    }
                    else
                    {
                       // return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
					   return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
                SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                model.IsNew = true;
                var me = GetContextModel(UIModelContextTypes.EditForm, model, true, model.GuidAreaPerson);
                Showing(ref me);
                if (isPopUp)
                {
                    
                        ViewData["ispopup"] = isPopUp;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
					if (Request != null)
						return ResolveView(me, model);
					else
						return Content("ok");
            }
        }        
        //
        // GET: /SDAreaPersons/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }
			
		
		[MyAuthorize("u", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
		[MvcSiteMapNode(Area="SFSServiceDesk", Title="sss", Clickable=false, ParentKey = "SFSServiceDesk_SDAreaPerson_List")]
		public ActionResult EditGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDAreaPersonResources.ENTITY_SINGLE;		 	
  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDAreaPersonModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
            SDAreaPersonModel model = null;
            // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
			bool dec = false;
            Guid ? idGuidDecripted = null ;
            if (Request != null && Request.QueryString["dec"] == "true")
            {
                dec = true;
                idGuidDecripted = Guid.Parse(id);
            }

            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model,dec,idGuidDecripted);
            Showing(ref me);


            if (!replaceResult)
            {
                 //return View("EditGen", me.Items[0]);
				 return ResolveView(me, me.Items[0]);
            }
            else {
                return e.ActionResult;
            }
        }
			[MyAuthorize("u", "SDAreaPerson","SFSServiceDesk", typeof(SDAreaPersonsController))]
		public ActionResult EditViewGen(string id)
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

					  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDAreaPersonModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
			
            SDAreaPersonModel model = null;
			 bool dec = false;
            Guid? guidId = null ;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                dec = true;
                guidId = Guid.Parse(id);
            }
            // si fue implementado el método parcial y no se ha decidido suspender la acción
            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
            var me = GetContextModel(UIModelContextTypes.EditForm, model, dec, guidId);
            Showing(ref me);

            return ResolveView(me, model);
        }
		[MyAuthorize("u", "SDAreaPerson",  "SFSServiceDesk", typeof(SDAreaPersonsController))]
		[HttpPost]
		[ValidateInput(false)] 
		        public ActionResult EditGen(SDAreaPersonModel model)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
			e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDAreaPersonModel>() { Item = model });
           
            if (!ModelState.IsValid)
            {
			   	var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
			
				if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"])){
                	ViewData["ispopup"] = true;
					return ResolveView(me, model);
				}
				else
					return ResolveView(me, model);
            }
            try
            {
			
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnEditing(this, e = new ControllerEventArgs<SDAreaPersonModel>() { Item = model });
                if (e != null) {
                    if (e.Cancel && e.ActionResult != null)
                        return e.ActionResult;
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				ContextRequest context = new ContextRequest();
                context.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;

                SDAreaPerson resultObj = null;
			    if (!cancel)
                	resultObj = SDAreaPersonsBR.Instance.Update(model.GetBusinessObject(), GetContextRequest());
				
				OnEdited(this, e = new ControllerEventArgs<SDAreaPersonModel>() { Item =   new SDAreaPersonModel(resultObj) });
				if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                         return ResolveApiResponse("success", null, null, null);
                    }
                }
				
				if (e != null && e.ActionResult != null) replaceResult = true; 

                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Content("ok");
                }
                else
                {
				if (!replaceResult)
                {
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"])  && string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
						 if (Request != null && Request.QueryString["dec"] == "true")
                        {
                            popupextra.Add("id", model.Id);
                        }
                        else
                        {
							popupextra.Add("id", model.SafeKey);

							
                        }
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                        {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                        popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area"));
                        popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                        popupextra.Add("action", actionDetails);
                        if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
					if (isPopUp)
						return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.UPDATE_DONE));
        			    string returnUrl = null;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"])) {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.Form["ReturnAfter"];
                        else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"];
                    }
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else{
		RouteValueDictionary popupextra = null; 
						 if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"]))
                            {
							
							popupextra = GetRouteData();
							string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
							if (!string.IsNullOrEmpty(area))
								popupextra.Add("area", area);

							return RedirectToAction("Index", popupextra);
						}else{
							return Content("ok");
						}
						}
				 }
                else {
                    return e.ActionResult;
				}
                }		
            }
          catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content(ex.ToString());
                    }
                    else
                    {
                        //return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
						 return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
			    if (isPopUp)
                {
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(ex.Message));
                    
                }
                else
                {
                    SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                    
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else {
						  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
							ViewData["ispopup"] = true;
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
							ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
							ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

						var me = GetContextModel(UIModelContextTypes.EditForm, model);
						Showing(ref me);

						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
						{
							ViewData["ispopup"] = true;
							return ResolveView(me, model);
						}
						else
							return ResolveView(me, model);

						
					}
				}
            }
        }
        //
        // POST: /SDAreaPersons/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //  Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SDAreaPersons/Delete/5
        
		[MyAuthorize("d", "SDAreaPerson", "SFSServiceDesk", typeof(SDAreaPersonsController))]
		[HttpDelete]
        public ActionResult DeleteGen(string objectKey, string extraParams)
        {
            try
            {
					
			
				Guid guidAreaPerson = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey.Replace("-", "/"), "GuidAreaPerson")); 
                BO.SDAreaPerson entity = new BO.SDAreaPerson() { GuidAreaPerson = guidAreaPerson };

                BR.SDAreaPersonsBR.Instance.Delete(entity, GetContextRequest());               
                return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.DELETE_DONE));

            }
            catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null)
                    {
                        message = ex.Data["usermessage"].ToString();
                    }

                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }
            }
        }
		/*[MyAuthorize()]
		public FileMediaResult Download(string query, bool? allSelected = false,  string selected = null , string orderBy = null , string direction = null , string format = null , string actionKey=null )
        {
			
            List<Guid> keysSelected1 = new List<Guid>();
            if (!string.IsNullOrEmpty(selected)) {
                foreach (var keyString in selected.Split(char.Parse("|")))
                {
				
                    keysSelected1.Add(Guid.Parse(keyString));
                }
            }
				
            query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(query, allSelected.Value, selected, "GuidAreaPerson");
            MyEventArgs<ContextActionModel<SDAreaPersonModel>> eArgs = null;
            List<SDAreaPersonModel> results = GetBy(query, null, null, orderBy, direction, GetContextRequest(), keysSelected1);
            OnDownloading(this, eArgs = new MyEventArgs<ContextActionModel<SDAreaPersonModel>>() { Object = new ContextActionModel<SDAreaPersonModel>() { Query = query, SelectedItems = results, Selected=selected, SelectAll = allSelected.Value, Direction = direction , OrderBy = orderBy, ActionKey=actionKey  } });

            if (eArgs != null)
            {
                if (eArgs.Object.Result != null)
                    return (FileMediaResult)eArgs.Object.Result;
            }
            

            return (new FeaturesController()).ExportDownload(typeof(SDAreaPersonModel), results, format, this.GetUIPluralText("SFSServiceDesk", "SDAreaPerson"));
            
        }
			*/
		
		[HttpPost]
        public ActionResult CustomActionExecute(ContextActionModel model) {
		 try
            {
			//List<Guid> keysSelected1 = new List<Guid>();
			List<object> keysSelected1 = new List<object>();
            if (!string.IsNullOrEmpty(model.Selected))
            {
                foreach (var keyString in model.Selected.Split(char.Parse(",")))
                {
				
				keysSelected1.Add(Guid.Parse(keyString.Split(char.Parse("|"))[0]));
                        
                    

			
                }
            }
			DataAction dataAction = DataAction.GetDataAction(Request);
			 model.Selected = dataAction.Selected;

            model.Query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(dataAction.Query, dataAction.AllSelected, dataAction.Selected, "GuidAreaPerson");
           
            
			
			#region implementaci�n de m�todo parcial
            bool replaceResult = false;
            MyEventArgs<ContextActionModel<SDAreaPersonModel>> actionEventArgs = null;
           
			if (model.ActionKey != "deletemany" && model.ActionKey != "deleterelmany" && model.ActionKey != "updateRel" &&  model.ActionKey != "delete-relation-fk" && model.ActionKey != "restore" )
			{
				ContextRequest context = SFSdotNet.Framework.My.Context.BuildContextRequestSafe(System.Web.HttpContext.Current);
				context.UseMode = dataAction.Usemode;

				if (model.IsBackground)
				{
					System.Threading.Tasks.Task.Run(() => 
						OnCustomActionExecutingBackground(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDAreaPersonModel>>() { Object = new ContextActionModel<SDAreaPersonModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } })
					);
				}
				else
				{
					OnCustomActionExecuting(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDAreaPersonModel>>() {  Object = new ContextActionModel<SDAreaPersonModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } });
				}
			}
            List<SDAreaPersonModel> results = null;
	
			if (model.ActionKey == "deletemany") { 
				
				BR.SDAreaPersonsBR.Instance.Delete(model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());

            }
	
            else if (model.ActionKey == "updateRel" || model.ActionKey == "delete-relation-fk" || model.ActionKey == "updateRel-proxyMany")
            {
               try {
                   string valueForUpdate = null;
				   string propForUpdate = null;
				   if (!string.IsNullOrEmpty(Request.Params["propertyForUpdate"])){
						propForUpdate = Request.Params["propertyForUpdate"];
				   }
				    if (string.IsNullOrEmpty(propForUpdate) && !string.IsNullOrEmpty(Request.QueryString["propertyForUpdate"]))
                   {
                       propForUpdate = Request.QueryString["propertyForUpdate"];
                   }
                    if (model.ActionKey != "delete-relation-fk")
                    {
                        valueForUpdate = Request.QueryString["valueForUpdate"];
                    }
                    BR.SDAreaPersonsBR.Instance.UpdateAssociation(propForUpdate, valueForUpdate, model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());
					
                    if (model.ActionKey == "delete-relation-fk")
                    {
                        MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]);

                        return PartialView("ResultMessageView", message);
                    }
                    else
                    {
                        return Content("ok");
                    }
       
          
                }
                catch (Exception ex)
                {
				        SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
           
                }
            
            }
		
                if (actionEventArgs == null && !model.IsBackground)
                {
                    //if (model.ActionKey != "deletemany"  && model.ActionKey != "deleterelmany")
                    //{
                     //   throw new NotImplementedException("");
                    //}
                }
                else
                {
					if (model.IsBackground == false )
						 replaceResult = actionEventArgs.Object.Result is ActionResult /*actionEventArgs.Object.ReplaceResult*/;
                }
                #endregion
                if (!replaceResult)
                {
                    if (Request != null && Request.IsAjaxRequest())
                    {
						MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]) ;
                        if (model.IsBackground )
                            message.Message = GlobalMessages.THE_PROCESS_HAS_BEEN_STARTED;
                        
                        return PartialView("ResultMessageView", message);                    
					}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return (ActionResult)actionEventArgs.Object.Result;
                }
            }
            catch (Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null) {
                        message = ex.Data["usermessage"].ToString();
                    }
					 SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }

            }
        }
        //
        // POST: /SDAreaPersons/Delete/5
        
			
	
    }
}
namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
	using SFS.ServiceDesk.Web.Mvc.Models.SDCases;

    public partial class SDCasesController : SFS.ServiceDesk.Web.Mvc.ControllerBase<Models.SDCases.SDCaseModel>
    {

       


	#region partial methods
        ControllerEventArgs<Models.SDCases.SDCaseModel> e = null;
        partial void OnValidating(object sender, ControllerEventArgs<Models.SDCases.SDCaseModel> e);
        partial void OnGettingExtraData(object sender, MyEventArgs<UIModel<Models.SDCases.SDCaseModel>> e);
        partial void OnCreating(object sender, ControllerEventArgs<Models.SDCases.SDCaseModel> e);
        partial void OnCreated(object sender, ControllerEventArgs<Models.SDCases.SDCaseModel> e);
        partial void OnEditing(object sender, ControllerEventArgs<Models.SDCases.SDCaseModel> e);
        partial void OnEdited(object sender, ControllerEventArgs<Models.SDCases.SDCaseModel> e);
        partial void OnDeleting(object sender, ControllerEventArgs<Models.SDCases.SDCaseModel> e);
        partial void OnDeleted(object sender, ControllerEventArgs<Models.SDCases.SDCaseModel> e);
    	partial void OnShowing(object sender, MyEventArgs<UIModel<Models.SDCases.SDCaseModel>> e);
    	partial void OnGettingByKey(object sender, ControllerEventArgs<Models.SDCases.SDCaseModel> e);
        partial void OnTaken(object sender, ControllerEventArgs<Models.SDCases.SDCaseModel> e);
       	partial void OnCreateShowing(object sender, ControllerEventArgs<Models.SDCases.SDCaseModel> e);
		partial void OnEditShowing(object sender, ControllerEventArgs<Models.SDCases.SDCaseModel> e);
		partial void OnDetailsShowing(object sender, ControllerEventArgs<Models.SDCases.SDCaseModel> e);
 		partial void OnActionsCreated(object sender, MyEventArgs<UIModel<Models.SDCases.SDCaseModel >> e);
		partial void OnCustomActionExecuting(object sender, MyEventArgs<ContextActionModel<Models.SDCases.SDCaseModel>> e);
		partial void OnCustomActionExecutingBackground(object sender, MyEventArgs<ContextActionModel<Models.SDCases.SDCaseModel>> e);
        partial void OnDownloading(object sender, MyEventArgs<ContextActionModel<Models.SDCases.SDCaseModel>> e);
      	partial void OnAuthorization(object sender, AuthorizationContext context);
		 partial void OnFilterShowing(object sender, MyEventArgs<UIModel<Models.SDCases.SDCaseModel >> e);
         partial void OnSummaryOperationShowing(object sender, MyEventArgs<UIModel<Models.SDCases.SDCaseModel>> e);

        partial void OnExportActionsCreated(object sender, MyEventArgs<UIModel<Models.SDCases.SDCaseModel>> e);


		protected override void OnVirtualFilterShowing(object sender, MyEventArgs<UIModel<SDCaseModel>> e)
        {
            OnFilterShowing(sender, e);
        }
		 public override void OnVirtualExportActionsCreated(object sender, MyEventArgs<UIModel<SDCaseModel>> e)
        {
            OnExportActionsCreated(sender, e);
        }
        public override void OnVirtualDownloading(object sender, MyEventArgs<ContextActionModel<SDCaseModel>> e)
        {
            OnDownloading(sender, e);
        }
        public override void OnVirtualShowing(object sender, MyEventArgs<UIModel<SDCaseModel>> e)
        {
            OnShowing(sender, e);
        }

	#endregion
	#region API
	 public override ActionResult ApiCreateGen(SDCaseModel model, ContextRequest contextRequest)
        {
            return CreateGen(model, contextRequest);
        }

              public override ActionResult ApiGetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJson(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }
        public override ActionResult ApiGetByKeyJson(string id, ContextRequest contextRequest)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
            return  GetByKeyJson(id, contextRequest, true);
        }
      
		 public override ActionResult ApiGetByCount(string filter, ContextRequest contextRequest)
        {
            return GetByCount(filter, contextRequest);
        }
         protected override ActionResult ApiDeleteGen(List<SDCaseModel> models, ContextRequest contextRequest)
        {
            List<SDCase> objs = new List<SDCase>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                BR.SDCasesBR.Instance.DeleteBulk(objs, contextRequest);
                if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("success", null, null, null);

                }
                else
                {
                    return Content("ok");

                }
            }
            catch (Exception ex)
            {
               if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "error", reason = "error", message= ex.ToString() }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("error", "exception", ex.ToString(), null );

                }
                else
                {
                    return Json(ex.ToString(), JsonRequestBehavior.AllowGet);

                }
            }
        }
        protected override ActionResult ApiUpdateGen(List<SDCaseModel> models, ContextRequest contextRequest)
        {
            List<SDCase> objs = new List<SDCase>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                foreach (var obj in objs)
                {
                    BR.SDCasesBR.Instance.Update(obj, contextRequest);

                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }


	#endregion
#region Validation methods	
	    private void Validations(SDCaseModel model) { 
            #region Remote validations

            #endregion
		}

#endregion
		
 		public AuthorizationContext Authorization(AuthorizationContext context)
        {
            OnAuthorization(this,  context );
            return context ;
        }
		public List<SDCaseModel> GetAll() {
            			var bos = BR.SDCasesBR.Instance.GetBy("",
					new SFSdotNet.Framework.My.ContextRequest()
					{
						CustomQuery = new SFSdotNet.Framework.My.CustomQuery()
						{
							OrderBy = "BodyContent",
							SortDirection = SFSdotNet.Framework.Data.SortDirection.Ascending
						}
					});
            			List<SDCaseModel> results = new List<SDCaseModel>();
            SDCaseModel model = null;
            foreach (var bo in bos)
            {
                model = new SDCaseModel();
                model.Bind(bo);
                results.Add(model);
            }
            return results;

        }
        //
        // GET: /SDCases/
		[MyAuthorize("r", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
		public ActionResult Index()
        {
    		var uiModel = GetContextModel(UIModelContextTypes.ListForm, null);
			ViewBag.UIModel = uiModel;
			uiModel.FilterStart = (string)ViewData["startFilter"];
                    MyEventArgs<UIModel<SDCaseModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseModel>>() { Object = uiModel });

			OnExportActionsCreated(this, (me != null ? me : me = new MyEventArgs<UIModel<SDCaseModel>>() { Object = uiModel }));

            if (me != null)
            {
                uiModel = me.Object;
            }
            if (me == null)
                me = new MyEventArgs<UIModel<SDCaseModel>>() { Object = uiModel };
           
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;


            //return View("ListGen");
			return ResolveView(uiModel);
        }
		[MyAuthorize("r", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
		public ActionResult ListViewGen(string idTab, string fk , string fkValue, string startFilter, ListModes  listmode  = ListModes.SimpleList, PropertyDefinition parentRelationProperty = null, object parentRelationPropertyValue = null )
        {
			ViewData["idTab"] = System.Web.HttpContext.Current.Request.QueryString["idTab"]; 
		 	ViewData["detpop"] = true; // details in popup
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"])) {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"]; 
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
            {
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["startFilter"]))
            {
                ViewData["startFilter"] = Request.QueryString["startFilter"];
            }
			
			UIModel<SDCaseModel> uiModel = GetContextModel(UIModelContextTypes.ListForm, null);

            MyEventArgs<UIModel<SDCaseModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseModel>>() { Object = uiModel });
            if (me == null)
                me = new MyEventArgs<UIModel<SDCaseModel>>() { Object = uiModel };
            uiModel.Properties = GetProperties(uiModel);
            uiModel.ContextType = UIModelContextTypes.ListForm;
             uiModel.FilterStart = (string)ViewData["startFilter"];
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;
			 if (listmode == ListModes.SimpleList)
                return ResolveView(uiModel);
            else
            {
                ViewData["parentRelationProperty"] = parentRelationProperty;
                ViewData["parentRelationPropertyValue"] = parentRelationPropertyValue;
                return PartialView("ListForTagSelectView");
            }
            return ResolveView(uiModel);
        }
		List<PropertyDefinition> _properties = null;

		 protected override List<PropertyDefinition> GetProperties(UIModel uiModel,  params string[] specificProperties)
        { 
            return GetProperties(uiModel, false, null, specificProperties);
        }

		protected override List<PropertyDefinition> GetProperties(UIModel uiModel, bool decripted, Guid? id, params string[] specificProperties)
            {

			bool allProperties = true;    
                if (specificProperties != null && specificProperties.Length > 0)
                {
                    allProperties = false;
                }


			List<CustomProperty> customProperties = new List<CustomProperty>();
			if (_properties == null)
                {
                List<PropertyDefinition> results = new List<PropertyDefinition>();

			string idSDCase = GetRouteDataOrQueryParam("id");
			if (idSDCase != null)
			{
				if (!decripted)
                {
					idSDCase = SFSdotNet.Framework.Entities.Utils.GetPropertyKey(idSDCase.Replace("-","/"), "GuidCase");
				}else{
					if (id != null )
						idSDCase = id.Value.ToString();                

				}
			}

			bool visibleProperty = true;	
			 bool conditionalshow =false;
                if (uiModel.ContextType == UIModelContextTypes.EditForm || uiModel.ContextType == UIModelContextTypes.DisplayForm ||  uiModel.ContextType == UIModelContextTypes.GenericForm )
                    conditionalshow = true;
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidCase"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidCase")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 100,
																	
					CustomProperties = customProperties,

                    PropertyName = "GuidCase",

					 MaxLength = 0,
					IsRequired = true ,
					IsHidden = true,
                    SystemProperty =  SystemProperties.Identifier ,
					IsDefaultProperty = false,
                    SortBy = "GuidCase",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseResources.GUIDCASE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidCaseStatus"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidCaseStatus")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 101,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidCaseStatus",

					 MaxLength = 0,
					IsRequired = true ,
					IsDefaultProperty = false,
                    SortBy = "GuidCaseStatus",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseResources.GUIDCASESTATUS*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidPersonClient"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidPersonClient")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 102,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidPersonClient",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "GuidPersonClient",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseResources.GUIDPERSONCLIENT*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("ClosedDateTime"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "ClosedDateTime")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 103,
																	
					CustomProperties = customProperties,

                    PropertyName = "ClosedDateTime",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "ClosedDateTime",
					
	
                    TypeName = "DateTime",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseResources.CLOSEDDATETIME*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("BodyContent"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "BodyContent")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 104,
																	
					CustomProperties = customProperties,

                    PropertyName = "BodyContent",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = true,
                    SortBy = "BodyContent",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseResources.BODYCONTENT*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("PreviewContent"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "PreviewContent")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 105,
																	
					CustomProperties = customProperties,

                    PropertyName = "PreviewContent",

					 MaxLength = 3000,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "PreviewContent",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseResources.PREVIEWCONTENT*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidCasePriority"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidCasePriority")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 106,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidCasePriority",

					 MaxLength = 0,
					IsRequired = true ,
					IsDefaultProperty = false,
                    SortBy = "GuidCasePriority",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseResources.GUIDCASEPRIORITY*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDPerson"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCases" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDPerson.GuidPerson")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDPerson.GuidPerson" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDPersons" });
			

	
	//fk_Case_Person_Client
		//if (this.Request.QueryString["fk"] != "SDPerson")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 107,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDPerson",
					PropertyNavigationKey = "GuidPerson",
					PropertyNavigationText = "DisplayName",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="DisplayName",
					GetMethodDisplayValue = "GuidPerson",
					
					CustomProperties = customProperties,

                    PropertyName = "SDPerson",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDPerson.DisplayName",
					
	
                    TypeName = "SFSServiceDeskModel.SDPerson",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDPersons"
                    /*,PropertyDisplayName = Resources.SDCaseResources.SDPERSON*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCasePriority"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCases" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCasePriority.GuidCasePriority")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCasePriority.GuidCasePriority" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCasePriorities" });
			

	
	//fk_SdCase_SdCasePriority
		//if (this.Request.QueryString["fk"] != "SDCasePriority")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 108,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCasePriority",
					PropertyNavigationKey = "GuidCasePriority",
					PropertyNavigationText = "Title",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="Title",
					GetMethodDisplayValue = "GuidCasePriority",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCasePriority",

					 MaxLength = 0,
					IsRequired = true ,
					IsDefaultProperty = false,
                    SortBy = "SDCasePriority.Title",
					
	
                    TypeName = "SFSServiceDeskModel.SDCasePriority",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDCasePriorities"
                    /*,PropertyDisplayName = Resources.SDCaseResources.SDCASEPRIORITY*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCaseStatu"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCases" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCaseStatu.GuidCaseStatus")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCaseStatu.GuidCaseStatus" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCaseStatus" });
			

	
	//fk_SdCase_SdCaseStatus
		//if (this.Request.QueryString["fk"] != "SDCaseStatu")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 109,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCaseStatu",
					PropertyNavigationKey = "GuidCaseStatus",
					PropertyNavigationText = "Title",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="Title",
					GetMethodDisplayValue = "GuidCaseStatus",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCaseStatu",

					 MaxLength = 0,
					IsRequired = true ,
					IsDefaultProperty = false,
                    SortBy = "SDCaseStatu.Title",
					
	
                    TypeName = "SFSServiceDeskModel.SDCaseStatu",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDCaseStatus"
                    /*,PropertyDisplayName = Resources.SDCaseResources.SDCASESTATU*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCaseFiles"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCase" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCaseFiles.GuidCasefile")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCaseFiles.GuidCasefile" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCaseFiles" });
			

	
	//fk_SdCaseFile_SdCase
		//if (this.Request.QueryString["fk"] != "SDCaseFiles")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 110,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCaseFiles/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDCaseFiles&fk=SDCase&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDCase.GuidCase = Guid(\"" + idSDCase +"\")")+ "&fkValue=" + idSDCase,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCaseFile",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCaseFiles",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDCaseFiles.GuidCasefile",
					
	
                    TypeName = "SFSServiceDeskModel.SDCaseFile",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDCaseFiles"
                    /*,PropertyDisplayName = Resources.SDCaseResources.SDCASEFILES*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCaseHistories"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCase" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCaseHistories.GuidCaseHistory")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCaseHistories.GuidCaseHistory" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCaseHistories" });
			

	
	//fk_SdCaseHistory_SdCase
		//if (this.Request.QueryString["fk"] != "SDCaseHistories")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 111,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCaseHistories/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDCaseHistories&fk=SDCase&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDCase.GuidCase = Guid(\"" + idSDCase +"\")")+ "&fkValue=" + idSDCase,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCaseHistory",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCaseHistories",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDCaseHistories.BodyContent",
					
	
                    TypeName = "SFSServiceDeskModel.SDCaseHistory",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDCaseHistories"
                    /*,PropertyDisplayName = Resources.SDCaseResources.SDCASEHISTORIES*/
                });
		//	}
	
	}
	
				
                    _properties = results;
                    return _properties;
                }
                else {
                    return _properties;
                }
            }

		protected override  UIModel<SDCaseModel> GetByForShow(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, params  object[] extraParams)
        {
			if (Request != null )
				if (!string.IsNullOrEmpty(Request.QueryString["q"]))
					filter = filter + HttpUtility.UrlDecode(Request.QueryString["q"]);
 if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
            }
            var bos = BR.SDCasesBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), contextRequest, extraParams);
			//var bos = BR.SDCasesBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), context, extraParams);
            SDCaseModel model = null;
            List<SDCaseModel> results = new List<SDCaseModel>();
            foreach (var item in bos)
            {
                model = new SDCaseModel();
				model.Bind(item);
				results.Add(model);
            }
            //return results;
			UIModel<SDCaseModel> uiModel = GetContextModel(UIModelContextTypes.Items, null);
            uiModel.Items = results;
			if (Request != null){
				if (SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(Request.RequestContext, "action") == "Download")
				{
					uiModel.ContextType = UIModelContextTypes.ExportDownload;
				}
			}
            Showing(ref uiModel);
            return uiModel;
		}			
		
		//public List<SDCaseModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params  object[] extraParams)
        //{
		//	var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, null, extraParams);
        public override List<SDCaseModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest,  params  object[] extraParams)
        {
            var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
           
            return uiModel.Items;
		
        }
		/*
        [MyAuthorize("r", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir)
        {
			 return GetByJsonBase(filter, pageSize, page, orderBy, orderDir);
        }*/

		  [MyAuthorize("r", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir,ContextRequest contextRequest,  object[] extraParams)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
			 
			 if (this.IsRESTRequest == false)
            {
                return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
            }else
            {
                try
                {
                    return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);

                }
            }
        }
/*		  [MyAuthorize("r", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
       public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }*/
		[MyAuthorize()]
		public ActionResult GetByCount(string filter, ContextRequest contextRequest) {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
           
			
             if (this.IsRESTRequest == true)
            {
                try
                {

                    var result = BR.SDCasesBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);

                   if (Request.QueryString["v"] == "2")
                    {
						return ResolveApiResponse("success", null, null, result);

                        //return Json(new { status = "success", data = result }, JsonRequestBehavior.AllowGet);
                    }else
                    {
                        return Content(result.ToString());

                    }
                }
                catch (Exception ex)
                {
                  //  return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
				  return ResolveApiResponse("error", "exception", ex.ToString(), null);

                }
            }
            else
            {
                var result = BR.SDCasesBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);
                return Content(result.ToString());
            }
		}
		

		[MyAuthorize("r", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
        public ActionResult GetByKeyJson(string id, ContextRequest contextRequest,  bool dec = false)
        {
            return Json(GetByKey(id, null, contextRequest, dec), JsonRequestBehavior.AllowGet);
        }
		public SDCaseModel GetByKey(string id) {
			return GetByKey(id, null,null, false);
       	}
		    public SDCaseModel GetByKey(string id, string includes)
        {
            return GetByKey(id, includes, false);
        }
		 public  SDCaseModel GetByKey(string id, string includes, ContextRequest contextRequest)
        {
            return GetByKey(id, includes, contextRequest, false);
        }
		/*
		  public ActionResult ShowField(string fieldName, string idField) {
		   string safePropertyName = fieldName;
              if (fieldName.StartsWith("Fk"))
              {
                  safePropertyName = fieldName.Substring(2, fieldName.Length - 2);
              }

             SDCaseModel model = new  SDCaseModel();

            UIModel uiModel = GetUIModel(model, new string[] { "NoField-" });
			
				uiModel.Properties = GetProperties(uiModel, safePropertyName);
		uiModel.Properties.ForEach(p=> p.ContextType = uiModel.ContextType );
            uiModel.ContextType = UIModelContextTypes.FilterFields;
            uiModel.OverrideApp = GetOverrideApp();
            uiModel.UseMode = GetUseMode();

            ViewData["uiModel"] = uiModel;
			var prop = uiModel.Properties.FirstOrDefault(p=>p.PropertyName == safePropertyName);
            //if (prop.IsNavigationProperty && prop.IsNavigationPropertyMany == false)
            //{
            //    ViewData["currentProperty"] = uiModel.Properties.FirstOrDefault(p => p.PropertyName != fieldName + "Text");
            //}else if (prop.IsNavigationProperty == false){
                ViewData["currentProperty"] = prop;
           // }
            ((PropertyDefinition)ViewData["currentProperty"]).RemoveLayout = true;
			ViewData["withContainer"] = false;


            return PartialView("GenericField", model);


        }
      */
	public SDCaseModel GetByKey(string id, ContextRequest contextRequest, bool dec)
        {
            return GetByKey(id, null, contextRequest, dec);
        }
        public SDCaseModel GetByKey(string id, string  includes, bool dec)
        {
            return GetByKey(id, includes, null, dec);
        }

        public SDCaseModel GetByKey(string id, string includes, ContextRequest contextRequest, bool dec) {
		             SDCaseModel model = null;
            ControllerEventArgs<SDCaseModel> e = null;
			string objectKey = id.Replace("-","/");
             OnGettingByKey(this, e=  new ControllerEventArgs<SDCaseModel>() { Id = objectKey  });
             bool cancel = false;
             SDCaseModel eItem = null;
             if (e != null)
             {
                 cancel = e.Cancel;
                 eItem = e.Item;
             }
			if (cancel == false && eItem == null)
             {
			Guid guidCase = Guid.Empty; //new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, "GuidCase"));
			if (dec)
                 {
                     guidCase = new Guid(id);
                 }
                 else
                 {
                     guidCase = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, null));
                 }
			
            
				model = new SDCaseModel();
                  if (contextRequest == null)
                {
                    contextRequest = GetContextRequest();
                }
				var bo = BR.SDCasesBR.Instance.GetByKey(guidCase, GetUseMode(), contextRequest,  includes);
				 if (bo != null)
                    model.Bind(bo);
                else
                    return null;
			}
             else {
                 model = eItem;
             }
			model.IsNew = false;

            return model;
        }
        // GET: /SDCases/DetailsGen/5
		[MyAuthorize("r", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
        public ActionResult DetailsGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDCaseResources.ENTITY_PLURAL;
			 #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDCaseModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
            #endregion



			 bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
			//UIModel<SDCaseModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, decripted), decripted, guidId);
			var item = GetByKey(id, null, null, decripted);
			if (item == null)
            {
                 RouteValueDictionary rv = new RouteValueDictionary();
                string usemode = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"usemode");
                string overrideModule = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "overrideModule");
                string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");

                if(!string.IsNullOrEmpty(usemode)){
                    rv.Add("usemode", usemode);
                }
                if(!string.IsNullOrEmpty(overrideModule)){
                    rv.Add("overrideModule", overrideModule);
                }
                if (!string.IsNullOrEmpty(area))
                {
                    rv.Add("area", area);
                }

                return RedirectToAction("Index", rv);
            }
            //
            UIModel<SDCaseModel> uiModel = null;
                uiModel = GetContextModel(UIModelContextTypes.DisplayForm, item, decripted, guidId);



            MyEventArgs<UIModel<SDCaseModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseModel>>() { Object = uiModel });

            if (me != null) {
                uiModel = me.Object;
            }
			
            Showing(ref uiModel);
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			
            //return View("DisplayGen", uiModel.Items[0]);
			return ResolveView(uiModel, uiModel.Items[0]);

        }
		[MyAuthorize("r", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
		public ActionResult DetailsViewGen(string id)
        {

		 bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDCaseModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
           
			if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
 			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
           
        	 //var uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id));
			 
            bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true")
                {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
            UIModel<SDCaseModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, null, decripted), decripted, guidId);
			

            MyEventArgs<UIModel<SDCaseModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseModel>>() { Object = uiModel });

            if (me != null)
            {
                uiModel = me.Object;
            }
            
            Showing(ref uiModel);
            return ResolveView(uiModel, uiModel.Items[0]);
        
        }
        //
        // GET: /SDCases/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /SDCases/CreateGen
		[MyAuthorize("c", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
        public ActionResult CreateGen()
        {
			SDCaseModel model = new SDCaseModel();
            model.IsNew = true;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model);

			OnCreateShowing(this, e = new ControllerEventArgs<SDCaseModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }

             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                 ViewData["ispopup"] = true;
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                 ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                 ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

            Showing(ref me);

			return ResolveView(me, me.Items[0]);
        } 
			
		protected override UIModel<SDCaseModel> GetContextModel(UIModelContextTypes formMode, SDCaseModel model)
        {
            return GetContextModel(formMode, model, false, null);
        }
			
		 private UIModel<SDCaseModel> GetContextModel(UIModelContextTypes formMode, SDCaseModel model, bool decript, Guid ? id) {
            UIModel<SDCaseModel> me = new UIModel<SDCaseModel>(true, "SDCases");
			me.UseMode = GetUseMode();
			me.Controller = this;
			me.OverrideApp = GetOverrideApp();
			me.ContextType = formMode ;
			me.Id = "SDCase";
			
            me.ModuleKey = "SFSServiceDesk";

			me.ModuleNamespace = "SFS.ServiceDesk";
            me.EntityKey = "SDCase";
            me.EntitySetName = "SDCases";

			me.AreaAction = "SFSServiceDesk";
            me.ControllerAction = "SDCases";
            me.PropertyKeyName = "GuidCase";

            me.Properties = GetProperties(me, decript, id);
 			
			if (Request != null)
            {
                string actionName = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam( Request.RequestContext, "action");
                if(actionName != null && actionName.ToLower().Contains("create") ){
                    me.IsNew = true;
                }
            }
			 #region Buttons
			 if (Request != null ){
             if (formMode == UIModelContextTypes.DisplayForm || formMode == UIModelContextTypes.EditForm || formMode == UIModelContextTypes.ListForm)
				me.ActionButtons = GetActionButtons(formMode,model != null ?(Request.QueryString["dec"] == "true" ? model.Id : model.SafeKey)  : null, "SFSServiceDesk", "SDCases", "SDCase", me.IsNew);

            //me.ActionButtons.Add(new ActionModel() { ActionKey = "return", Title = GlobalMessages.RETURN, Url = System.Web.VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCases" });
			if (this.HttpContext != null &&  !this.HttpContext.SkipAuthorization){
				//antes this.HttpContext
				me.SetAction("u", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("u", "SDCase", "SFSServiceDesk"));
				me.SetAction("c", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("c", "SDCase", "SFSServiceDesk"));
				me.SetAction("d", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("d", "SDCase", "SFSServiceDesk"));
			
			}else{
				me.SetAction("u", true);
				me.SetAction("c", true);
				me.SetAction("d", true);

			}
            #endregion              
         
            switch (formMode)
            {
                case UIModelContextTypes.DisplayForm:
					//me.TitleForm = SDCaseResources.SDCASES_DETAILS;
                    me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.MODIFY_DATA;
					 me.Properties.Where(p=>p.PropertyName  != "Id" && p.IsForeignKey == false).ToList().ForEach(p => p.IsHidden = false);

					 me.Properties.Where(p => (p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier) ).ToList().ForEach(p=> me.SetHide(p.PropertyName));

                    break;
                case UIModelContextTypes.EditForm:
				  me.Properties.Where(p=>p.SystemProperty != SystemProperties.Identifier && p.IsForeignKey == false && p.PropertyName != "Id").ToList().ForEach(p => p.IsHidden = false);

					if (model != null)
                    {
						

                        me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.SAVE_DATA;                        
                        me.ActionButtons.First(p => p.ActionKey == "c").Title = GlobalMessages.SAVE_DATA;
						if (model.IsNew ){
							//me.TitleForm = SDCaseResources.SDCASES_ADD_NEW;
							me.ActionName = "CreateGen";
							me.Properties.RemoveAll(p => p.SystemProperty != null || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));
						}else{
							
							me.ActionName = "EditGen";

							//me.TitleForm = SDCaseResources.SDCASES_EDIT;
							me.Properties.RemoveAll(p => p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));	
						}
						//me.Properties.Remove(me.Properties.Find(p => p.PropertyName == "UpdatedDate"));
					
					}
                    break;
                case UIModelContextTypes.FilterFields:
                    break;
                case UIModelContextTypes.GenericForm:
                    break;
                case UIModelContextTypes.Items:
				//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "BodyContent") != null){
						me.Properties.Find(p => p.PropertyName == "BodyContent").IsHidden = false;
					 }
					 
                    
					

						 if (me.Properties.Find(p => p.PropertyName == "GuidCase") != null){
						me.Properties.Find(p => p.PropertyName == "GuidCase").IsHidden = false;
					 }
					 
                    
					


                  


					//}
                    break;
                case UIModelContextTypes.ListForm:
					PropertyDefinition propFinded = null;
					//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "BodyContent") != null){
						me.Properties.Find(p => p.PropertyName == "BodyContent").IsHidden = false;
					 }
					
					me.PrincipalActionName = "GetByJson";
					//}
					//me.TitleForm = SDCaseResources.SDCASES_LIST;
                    break;
                default:
                    break;
            }
            	this.SetDefaultProperties(me);
			}
			if (model != null )
            	me.Items.Add(model);
            return me;
        }
		// GET: /SDCases/CreateViewGen
		[MyAuthorize("c", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
        public ActionResult CreateViewGen()
        {
				SDCaseModel model = new SDCaseModel();
            model.IsNew = true;
			e= null;
			OnCreateShowing(this, e = new ControllerEventArgs<SDCaseModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }
			
            var me = GetContextModel(UIModelContextTypes.EditForm, model);

			me.IsPartialView = true;	
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
            {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                me.Properties.Find(p => p.PropertyName == ViewData["fk"].ToString()).IsReadOnly = true;
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
			
      
            //me.Items.Add(model);
            Showing(ref me);
            return ResolveView(me, me.Items[0]);
        }
		protected override  void GettingExtraData(ref UIModel<SDCaseModel> uiModel)
        {

            MyEventArgs<UIModel<SDCaseModel>> me = null;
            OnGettingExtraData(this, me = new MyEventArgs<UIModel<SDCaseModel>>() { Object = uiModel });
            //bool maybeAnyReplaced = false; 
            if (me != null)
            {
                uiModel = me.Object;
                //maybeAnyReplaced = true;
            }
           
			bool canFill = false;
			 string query = null ;
            bool isFK = false;
			PropertyDefinition prop =null;
			var contextRequest = this.GetContextRequest();
            contextRequest.CustomParams.Add(new CustomParam() { Name="ui", Value= SDCase.EntityName });

            			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDPerson");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidPerson = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidPerson = @GuidPerson";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidPerson = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidPerson = @GuidPerson";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDPerson")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidPerson", new Nullable<Guid>(Guid.Parse( Request.QueryString["fkValue"])));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDPersonsBR()).GetBy(query, contextRequest), "GuidPerson", "DisplayName", Request.QueryString["fkValue"]), PropertyName = "SDPerson" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDPersonsBR()).GetBy(query, contextRequest), "GuidPerson", "DisplayName"), PropertyName = "SDPerson" });    

					}
    if (isFK)
                    {    
						var FkSDPerson = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDPerson").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDPersonText").SetValue(uiModel.Items[0], FkSDPerson.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDPerson").SetValue(uiModel.Items[0], Guid.Parse(FkSDPerson.Value));
                    
					}    
				}
			}
		 
			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDCasePriority");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidCasePriority = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidCasePriority = @GuidCasePriority";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidCasePriority = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidCasePriority = @GuidCasePriority";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDCasePriority")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidCasePriority", Guid.Parse( Request.QueryString["fkValue"]));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDCasePrioritiesBR()).GetBy(query, contextRequest), "GuidCasePriority", "Title", Request.QueryString["fkValue"]), PropertyName = "SDCasePriority" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDCasePrioritiesBR()).GetBy(query, contextRequest), "GuidCasePriority", "Title"), PropertyName = "SDCasePriority" });    

					}
    if (isFK)
                    {    
						var FkSDCasePriority = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDCasePriority").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDCasePriorityText").SetValue(uiModel.Items[0], FkSDCasePriority.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDCasePriority").SetValue(uiModel.Items[0], Guid.Parse(FkSDCasePriority.Value));
                    
					}    
				}
			}
		 
			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDCaseStatu");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidCaseStatus = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidCaseStatus = @GuidCaseStatus";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidCaseStatus = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidCaseStatus = @GuidCaseStatus";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDCaseStatu")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidCaseStatus", Guid.Parse( Request.QueryString["fkValue"]));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDCaseStatusBR()).GetBy(query, contextRequest), "GuidCaseStatus", "Title", Request.QueryString["fkValue"]), PropertyName = "SDCaseStatu" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDCaseStatusBR()).GetBy(query, contextRequest), "GuidCaseStatus", "Title"), PropertyName = "SDCaseStatu" });    

					}
    if (isFK)
                    {    
						var FkSDCaseStatu = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDCaseStatu").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDCaseStatuText").SetValue(uiModel.Items[0], FkSDCaseStatu.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDCaseStatu").SetValue(uiModel.Items[0], Guid.Parse(FkSDCaseStatu.Value));
                    
					}    
				}
			}
		 
            

        }
		private void Showing(ref UIModel<SDCaseModel> uiModel) {
          	
			MyEventArgs<UIModel<SDCaseModel>> me = new MyEventArgs<UIModel<SDCaseModel>>() { Object = uiModel };
			 OnVirtualLayoutSettings(this, me);


            OnShowing(this, me);

			
			if ((Request != null && Request.QueryString["allFields"] == "1") || Request == null )
			{
				me.Object.Properties.ForEach(p=> p.IsHidden = false);
            }
            if (me != null)
            {
                uiModel = me.Object;
            }
          


			 if (uiModel.ContextType == UIModelContextTypes.EditForm)
			    GettingExtraData(ref uiModel);
            ViewData["UIModel"] = uiModel;

        }
        //
        // POST: /SDCases/Create
		[MyAuthorize("c", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
        [HttpPost]
		[ValidateInput(false)] 
        public ActionResult CreateGen(SDCaseModel  model,  ContextRequest contextRequest)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
		 	e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDCaseModel>() { Item = model });
           
		  	if (!ModelState.IsValid) {
				model.IsNew = true;
				var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
                 if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                        ViewData["ispopup"] = true;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
                    return ResolveView(me, model);
            }
            try
            {
				if (model.GuidCase == null || model.GuidCase.ToString().Contains("000000000"))
				model.GuidCase = Guid.NewGuid();
	
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnCreating(this, e = new ControllerEventArgs<SDCaseModel>() { Item = model });
                if (e != null) {
                   if (e.Cancel && e.RedirectValues.Count > 0){
                        RouteValueDictionary rv = new RouteValueDictionary();
                        if (e.RedirectValues["area"] != null ){
                            rv.Add("area", e.RedirectValues["area"].ToString());
                        }
                        foreach (var item in e.RedirectValues.Where(p=>p.Key != "area" && p.Key != "controller" &&  p.Key != "action" ))
	                    {
		                    rv.Add(item.Key, item.Value);
	                    }

                        //if (e.RedirectValues["action"] != null && e.RedirectValues["controller"] != null && e.RedirectValues["area"] != null )
                        return RedirectToAction(e.RedirectValues["action"].ToString(), e.RedirectValues["controller"].ToString(), rv );


                        
                    }else if (e.Cancel && e.ActionResult != null )
                        return e.ActionResult;  
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				if (contextRequest == null || contextRequest.Company == null){
					contextRequest = GetContextRequest();
					
				}
                if (!cancel)
                	model.Bind(SDCasesBR.Instance.Create(model.GetBusinessObject(), contextRequest ));
				OnCreated(this, e = new ControllerEventArgs<SDCaseModel>() { Item = model });
                 if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                        return ResolveApiResponse("success", null, null, null);

                    }
                }
				 
				 if (e != null )
					if (e.ActionResult != null)
                    	replaceResult = true;		
				if (!replaceResult)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))
                    {
                        ViewData["__continue"] = true;
                    }
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"]) &&  string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
                        popupextra.Add("id", model.SafeKey);
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                       {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                            popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"area"));
                            popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                            popupextra.Add("action", actionDetails);
                       if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
                    {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))

                        {
                            var popupextra = GetRouteData();
                            popupextra.Add("id", model.SafeKey);
                            return RedirectToAction("EditViewGen", popupextra);
                        }
                        else
                        {
                            return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.ADD_DONE));
                        }
                    }        			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                        return Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]);
                    else{

							RouteValueDictionary popupextra = null; 
							if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"])){
                            popupextra = GetRouteData();
							 string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
                            if (!string.IsNullOrEmpty(area))
                                popupextra.Add("area", area);
                            
                            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"])) {
								popupextra.Add("id", model.SafeKey);
                                return RedirectToAction("EditGen", popupextra);

                            }else{
								
                            return RedirectToAction("Index", popupextra);
							}
							}else{
								return Content("ok");
							}
                        }
						 }
                else {
                    return e.ActionResult;
                    }
				}
            catch(Exception ex)
            {
					  SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        throw ex;
                    }
                    else
                    {
                       // return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
					   return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
                SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                model.IsNew = true;
                var me = GetContextModel(UIModelContextTypes.EditForm, model, true, model.GuidCase);
                Showing(ref me);
                if (isPopUp)
                {
                    
                        ViewData["ispopup"] = isPopUp;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
					if (Request != null)
						return ResolveView(me, model);
					else
						return Content("ok");
            }
        }        
        //
        // GET: /SDCases/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }
			
		
		[MyAuthorize("u", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
		[MvcSiteMapNode(Area="SFSServiceDesk", Title="sss", Clickable=false, ParentKey = "SFSServiceDesk_SDCase_List")]
		public ActionResult EditGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDCaseResources.ENTITY_SINGLE;		 	
  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDCaseModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
            SDCaseModel model = null;
            // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
			bool dec = false;
            Guid ? idGuidDecripted = null ;
            if (Request != null && Request.QueryString["dec"] == "true")
            {
                dec = true;
                idGuidDecripted = Guid.Parse(id);
            }

            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model,dec,idGuidDecripted);
            Showing(ref me);


            if (!replaceResult)
            {
                 //return View("EditGen", me.Items[0]);
				 return ResolveView(me, me.Items[0]);
            }
            else {
                return e.ActionResult;
            }
        }
			[MyAuthorize("u", "SDCase","SFSServiceDesk", typeof(SDCasesController))]
		public ActionResult EditViewGen(string id)
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

					  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDCaseModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
			
            SDCaseModel model = null;
			 bool dec = false;
            Guid? guidId = null ;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                dec = true;
                guidId = Guid.Parse(id);
            }
            // si fue implementado el método parcial y no se ha decidido suspender la acción
            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
            var me = GetContextModel(UIModelContextTypes.EditForm, model, dec, guidId);
            Showing(ref me);

            return ResolveView(me, model);
        }
		[MyAuthorize("u", "SDCase",  "SFSServiceDesk", typeof(SDCasesController))]
		[HttpPost]
		[ValidateInput(false)] 
		        public ActionResult EditGen(SDCaseModel model)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
			e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDCaseModel>() { Item = model });
           
            if (!ModelState.IsValid)
            {
			   	var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
			
				if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"])){
                	ViewData["ispopup"] = true;
					return ResolveView(me, model);
				}
				else
					return ResolveView(me, model);
            }
            try
            {
			
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnEditing(this, e = new ControllerEventArgs<SDCaseModel>() { Item = model });
                if (e != null) {
                    if (e.Cancel && e.ActionResult != null)
                        return e.ActionResult;
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				ContextRequest context = new ContextRequest();
                context.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;

                SDCase resultObj = null;
			    if (!cancel)
                	resultObj = SDCasesBR.Instance.Update(model.GetBusinessObject(), GetContextRequest());
				
				OnEdited(this, e = new ControllerEventArgs<SDCaseModel>() { Item =   new SDCaseModel(resultObj) });
				if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                         return ResolveApiResponse("success", null, null, null);
                    }
                }
				
				if (e != null && e.ActionResult != null) replaceResult = true; 

                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Content("ok");
                }
                else
                {
				if (!replaceResult)
                {
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"])  && string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
						 if (Request != null && Request.QueryString["dec"] == "true")
                        {
                            popupextra.Add("id", model.Id);
                        }
                        else
                        {
							popupextra.Add("id", model.SafeKey);

							
                        }
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                        {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                        popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area"));
                        popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                        popupextra.Add("action", actionDetails);
                        if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
					if (isPopUp)
						return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.UPDATE_DONE));
        			    string returnUrl = null;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"])) {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.Form["ReturnAfter"];
                        else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"];
                    }
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else{
		RouteValueDictionary popupextra = null; 
						 if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"]))
                            {
							
							popupextra = GetRouteData();
							string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
							if (!string.IsNullOrEmpty(area))
								popupextra.Add("area", area);

							return RedirectToAction("Index", popupextra);
						}else{
							return Content("ok");
						}
						}
				 }
                else {
                    return e.ActionResult;
				}
                }		
            }
          catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content(ex.ToString());
                    }
                    else
                    {
                        //return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
						 return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
			    if (isPopUp)
                {
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(ex.Message));
                    
                }
                else
                {
                    SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                    
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else {
						  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
							ViewData["ispopup"] = true;
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
							ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
							ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

						var me = GetContextModel(UIModelContextTypes.EditForm, model);
						Showing(ref me);

						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
						{
							ViewData["ispopup"] = true;
							return ResolveView(me, model);
						}
						else
							return ResolveView(me, model);

						
					}
				}
            }
        }
        //
        // POST: /SDCases/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //  Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SDCases/Delete/5
        
		[MyAuthorize("d", "SDCase", "SFSServiceDesk", typeof(SDCasesController))]
		[HttpDelete]
        public ActionResult DeleteGen(string objectKey, string extraParams)
        {
            try
            {
					
			
				Guid guidCase = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey.Replace("-", "/"), "GuidCase")); 
                BO.SDCase entity = new BO.SDCase() { GuidCase = guidCase };

                BR.SDCasesBR.Instance.Delete(entity, GetContextRequest());               
                return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.DELETE_DONE));

            }
            catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null)
                    {
                        message = ex.Data["usermessage"].ToString();
                    }

                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }
            }
        }
		/*[MyAuthorize()]
		public FileMediaResult Download(string query, bool? allSelected = false,  string selected = null , string orderBy = null , string direction = null , string format = null , string actionKey=null )
        {
			
            List<Guid> keysSelected1 = new List<Guid>();
            if (!string.IsNullOrEmpty(selected)) {
                foreach (var keyString in selected.Split(char.Parse("|")))
                {
				
                    keysSelected1.Add(Guid.Parse(keyString));
                }
            }
				
            query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(query, allSelected.Value, selected, "GuidCase");
            MyEventArgs<ContextActionModel<SDCaseModel>> eArgs = null;
            List<SDCaseModel> results = GetBy(query, null, null, orderBy, direction, GetContextRequest(), keysSelected1);
            OnDownloading(this, eArgs = new MyEventArgs<ContextActionModel<SDCaseModel>>() { Object = new ContextActionModel<SDCaseModel>() { Query = query, SelectedItems = results, Selected=selected, SelectAll = allSelected.Value, Direction = direction , OrderBy = orderBy, ActionKey=actionKey  } });

            if (eArgs != null)
            {
                if (eArgs.Object.Result != null)
                    return (FileMediaResult)eArgs.Object.Result;
            }
            

            return (new FeaturesController()).ExportDownload(typeof(SDCaseModel), results, format, this.GetUIPluralText("SFSServiceDesk", "SDCase"));
            
        }
			*/
		
		[HttpPost]
        public ActionResult CustomActionExecute(ContextActionModel model) {
		 try
            {
			//List<Guid> keysSelected1 = new List<Guid>();
			List<object> keysSelected1 = new List<object>();
            if (!string.IsNullOrEmpty(model.Selected))
            {
                foreach (var keyString in model.Selected.Split(char.Parse(",")))
                {
				
				keysSelected1.Add(Guid.Parse(keyString.Split(char.Parse("|"))[0]));
                        
                    

			
                }
            }
			DataAction dataAction = DataAction.GetDataAction(Request);
			 model.Selected = dataAction.Selected;

            model.Query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(dataAction.Query, dataAction.AllSelected, dataAction.Selected, "GuidCase");
           
            
			
			#region implementaci�n de m�todo parcial
            bool replaceResult = false;
            MyEventArgs<ContextActionModel<SDCaseModel>> actionEventArgs = null;
           
			if (model.ActionKey != "deletemany" && model.ActionKey != "deleterelmany" && model.ActionKey != "updateRel" &&  model.ActionKey != "delete-relation-fk" && model.ActionKey != "restore" )
			{
				ContextRequest context = SFSdotNet.Framework.My.Context.BuildContextRequestSafe(System.Web.HttpContext.Current);
				context.UseMode = dataAction.Usemode;

				if (model.IsBackground)
				{
					System.Threading.Tasks.Task.Run(() => 
						OnCustomActionExecutingBackground(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDCaseModel>>() { Object = new ContextActionModel<SDCaseModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } })
					);
				}
				else
				{
					OnCustomActionExecuting(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDCaseModel>>() {  Object = new ContextActionModel<SDCaseModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } });
				}
			}
            List<SDCaseModel> results = null;
	
			if (model.ActionKey == "deletemany") { 
				
				BR.SDCasesBR.Instance.Delete(model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());

            }
	
            else if (model.ActionKey == "updateRel" || model.ActionKey == "delete-relation-fk" || model.ActionKey == "updateRel-proxyMany")
            {
               try {
                   string valueForUpdate = null;
				   string propForUpdate = null;
				   if (!string.IsNullOrEmpty(Request.Params["propertyForUpdate"])){
						propForUpdate = Request.Params["propertyForUpdate"];
				   }
				    if (string.IsNullOrEmpty(propForUpdate) && !string.IsNullOrEmpty(Request.QueryString["propertyForUpdate"]))
                   {
                       propForUpdate = Request.QueryString["propertyForUpdate"];
                   }
                    if (model.ActionKey != "delete-relation-fk")
                    {
                        valueForUpdate = Request.QueryString["valueForUpdate"];
                    }
                    BR.SDCasesBR.Instance.UpdateAssociation(propForUpdate, valueForUpdate, model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());
					
                    if (model.ActionKey == "delete-relation-fk")
                    {
                        MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]);

                        return PartialView("ResultMessageView", message);
                    }
                    else
                    {
                        return Content("ok");
                    }
       
          
                }
                catch (Exception ex)
                {
				        SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
           
                }
            
            }
		
                if (actionEventArgs == null && !model.IsBackground)
                {
                    //if (model.ActionKey != "deletemany"  && model.ActionKey != "deleterelmany")
                    //{
                     //   throw new NotImplementedException("");
                    //}
                }
                else
                {
					if (model.IsBackground == false )
						 replaceResult = actionEventArgs.Object.Result is ActionResult /*actionEventArgs.Object.ReplaceResult*/;
                }
                #endregion
                if (!replaceResult)
                {
                    if (Request != null && Request.IsAjaxRequest())
                    {
						MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]) ;
                        if (model.IsBackground )
                            message.Message = GlobalMessages.THE_PROCESS_HAS_BEEN_STARTED;
                        
                        return PartialView("ResultMessageView", message);                    
					}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return (ActionResult)actionEventArgs.Object.Result;
                }
            }
            catch (Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null) {
                        message = ex.Data["usermessage"].ToString();
                    }
					 SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }

            }
        }
        //
        // POST: /SDCases/Delete/5
        
			
	
    }
}
namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
	using SFS.ServiceDesk.Web.Mvc.Models.SDCaseFiles;

    public partial class SDCaseFilesController : SFS.ServiceDesk.Web.Mvc.ControllerBase<Models.SDCaseFiles.SDCaseFileModel>
    {

       


	#region partial methods
        ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e = null;
        partial void OnValidating(object sender, ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e);
        partial void OnGettingExtraData(object sender, MyEventArgs<UIModel<Models.SDCaseFiles.SDCaseFileModel>> e);
        partial void OnCreating(object sender, ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e);
        partial void OnCreated(object sender, ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e);
        partial void OnEditing(object sender, ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e);
        partial void OnEdited(object sender, ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e);
        partial void OnDeleting(object sender, ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e);
        partial void OnDeleted(object sender, ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e);
    	partial void OnShowing(object sender, MyEventArgs<UIModel<Models.SDCaseFiles.SDCaseFileModel>> e);
    	partial void OnGettingByKey(object sender, ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e);
        partial void OnTaken(object sender, ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e);
       	partial void OnCreateShowing(object sender, ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e);
		partial void OnEditShowing(object sender, ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e);
		partial void OnDetailsShowing(object sender, ControllerEventArgs<Models.SDCaseFiles.SDCaseFileModel> e);
 		partial void OnActionsCreated(object sender, MyEventArgs<UIModel<Models.SDCaseFiles.SDCaseFileModel >> e);
		partial void OnCustomActionExecuting(object sender, MyEventArgs<ContextActionModel<Models.SDCaseFiles.SDCaseFileModel>> e);
		partial void OnCustomActionExecutingBackground(object sender, MyEventArgs<ContextActionModel<Models.SDCaseFiles.SDCaseFileModel>> e);
        partial void OnDownloading(object sender, MyEventArgs<ContextActionModel<Models.SDCaseFiles.SDCaseFileModel>> e);
      	partial void OnAuthorization(object sender, AuthorizationContext context);
		 partial void OnFilterShowing(object sender, MyEventArgs<UIModel<Models.SDCaseFiles.SDCaseFileModel >> e);
         partial void OnSummaryOperationShowing(object sender, MyEventArgs<UIModel<Models.SDCaseFiles.SDCaseFileModel>> e);

        partial void OnExportActionsCreated(object sender, MyEventArgs<UIModel<Models.SDCaseFiles.SDCaseFileModel>> e);


		protected override void OnVirtualFilterShowing(object sender, MyEventArgs<UIModel<SDCaseFileModel>> e)
        {
            OnFilterShowing(sender, e);
        }
		 public override void OnVirtualExportActionsCreated(object sender, MyEventArgs<UIModel<SDCaseFileModel>> e)
        {
            OnExportActionsCreated(sender, e);
        }
        public override void OnVirtualDownloading(object sender, MyEventArgs<ContextActionModel<SDCaseFileModel>> e)
        {
            OnDownloading(sender, e);
        }
        public override void OnVirtualShowing(object sender, MyEventArgs<UIModel<SDCaseFileModel>> e)
        {
            OnShowing(sender, e);
        }

	#endregion
	#region API
	 public override ActionResult ApiCreateGen(SDCaseFileModel model, ContextRequest contextRequest)
        {
            return CreateGen(model, contextRequest);
        }

              public override ActionResult ApiGetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJson(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }
        public override ActionResult ApiGetByKeyJson(string id, ContextRequest contextRequest)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
            return  GetByKeyJson(id, contextRequest, true);
        }
      
		 public override ActionResult ApiGetByCount(string filter, ContextRequest contextRequest)
        {
            return GetByCount(filter, contextRequest);
        }
         protected override ActionResult ApiDeleteGen(List<SDCaseFileModel> models, ContextRequest contextRequest)
        {
            List<SDCaseFile> objs = new List<SDCaseFile>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                BR.SDCaseFilesBR.Instance.DeleteBulk(objs, contextRequest);
                if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("success", null, null, null);

                }
                else
                {
                    return Content("ok");

                }
            }
            catch (Exception ex)
            {
               if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "error", reason = "error", message= ex.ToString() }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("error", "exception", ex.ToString(), null );

                }
                else
                {
                    return Json(ex.ToString(), JsonRequestBehavior.AllowGet);

                }
            }
        }
        protected override ActionResult ApiUpdateGen(List<SDCaseFileModel> models, ContextRequest contextRequest)
        {
            List<SDCaseFile> objs = new List<SDCaseFile>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                foreach (var obj in objs)
                {
                    BR.SDCaseFilesBR.Instance.Update(obj, contextRequest);

                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }


	#endregion
#region Validation methods	
	    private void Validations(SDCaseFileModel model) { 
            #region Remote validations

            #endregion
		}

#endregion
		
 		public AuthorizationContext Authorization(AuthorizationContext context)
        {
            OnAuthorization(this,  context );
            return context ;
        }
		public List<SDCaseFileModel> GetAll() {
            			var bos = BR.SDCaseFilesBR.Instance.GetBy("",
					new SFSdotNet.Framework.My.ContextRequest()
					{
						CustomQuery = new SFSdotNet.Framework.My.CustomQuery()
						{
							OrderBy = "GuidCasefile",
							SortDirection = SFSdotNet.Framework.Data.SortDirection.Ascending
						}
					});
            			List<SDCaseFileModel> results = new List<SDCaseFileModel>();
            SDCaseFileModel model = null;
            foreach (var bo in bos)
            {
                model = new SDCaseFileModel();
                model.Bind(bo);
                results.Add(model);
            }
            return results;

        }
        //
        // GET: /SDCaseFiles/
		[MyAuthorize("r", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
		public ActionResult Index()
        {
    		var uiModel = GetContextModel(UIModelContextTypes.ListForm, null);
			ViewBag.UIModel = uiModel;
			uiModel.FilterStart = (string)ViewData["startFilter"];
                    MyEventArgs<UIModel<SDCaseFileModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseFileModel>>() { Object = uiModel });

			OnExportActionsCreated(this, (me != null ? me : me = new MyEventArgs<UIModel<SDCaseFileModel>>() { Object = uiModel }));

            if (me != null)
            {
                uiModel = me.Object;
            }
            if (me == null)
                me = new MyEventArgs<UIModel<SDCaseFileModel>>() { Object = uiModel };
           
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;


            //return View("ListGen");
			return ResolveView(uiModel);
        }
		[MyAuthorize("r", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
		public ActionResult ListViewGen(string idTab, string fk , string fkValue, string startFilter, ListModes  listmode  = ListModes.SimpleList, PropertyDefinition parentRelationProperty = null, object parentRelationPropertyValue = null )
        {
			ViewData["idTab"] = System.Web.HttpContext.Current.Request.QueryString["idTab"]; 
		 	ViewData["detpop"] = true; // details in popup
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"])) {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"]; 
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
            {
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["startFilter"]))
            {
                ViewData["startFilter"] = Request.QueryString["startFilter"];
            }
			
			UIModel<SDCaseFileModel> uiModel = GetContextModel(UIModelContextTypes.ListForm, null);

            MyEventArgs<UIModel<SDCaseFileModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseFileModel>>() { Object = uiModel });
            if (me == null)
                me = new MyEventArgs<UIModel<SDCaseFileModel>>() { Object = uiModel };
            uiModel.Properties = GetProperties(uiModel);
            uiModel.ContextType = UIModelContextTypes.ListForm;
             uiModel.FilterStart = (string)ViewData["startFilter"];
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;
			 if (listmode == ListModes.SimpleList)
                return ResolveView(uiModel);
            else
            {
                ViewData["parentRelationProperty"] = parentRelationProperty;
                ViewData["parentRelationPropertyValue"] = parentRelationPropertyValue;
                return PartialView("ListForTagSelectView");
            }
            return ResolveView(uiModel);
        }
		List<PropertyDefinition> _properties = null;

		 protected override List<PropertyDefinition> GetProperties(UIModel uiModel,  params string[] specificProperties)
        { 
            return GetProperties(uiModel, false, null, specificProperties);
        }

		protected override List<PropertyDefinition> GetProperties(UIModel uiModel, bool decripted, Guid? id, params string[] specificProperties)
            {

			bool allProperties = true;    
                if (specificProperties != null && specificProperties.Length > 0)
                {
                    allProperties = false;
                }


			List<CustomProperty> customProperties = new List<CustomProperty>();
			if (_properties == null)
                {
                List<PropertyDefinition> results = new List<PropertyDefinition>();

			string idSDCaseFile = GetRouteDataOrQueryParam("id");
			if (idSDCaseFile != null)
			{
				if (!decripted)
                {
					idSDCaseFile = SFSdotNet.Framework.Entities.Utils.GetPropertyKey(idSDCaseFile.Replace("-","/"), "GuidCasefile");
				}else{
					if (id != null )
						idSDCaseFile = id.Value.ToString();                

				}
			}

			bool visibleProperty = true;	
			 bool conditionalshow =false;
                if (uiModel.ContextType == UIModelContextTypes.EditForm || uiModel.ContextType == UIModelContextTypes.DisplayForm ||  uiModel.ContextType == UIModelContextTypes.GenericForm )
                    conditionalshow = true;
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidCasefile"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidCasefile")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 100,
																	
					CustomProperties = customProperties,

                    PropertyName = "GuidCasefile",

					 MaxLength = 0,
					IsRequired = true ,
					IsHidden = true,
                    SystemProperty =  SystemProperties.Identifier ,
					IsDefaultProperty = true,
                    SortBy = "GuidCasefile",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseFileResources.GUIDCASEFILE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidCase"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidCase")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 101,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidCase",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "GuidCase",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseFileResources.GUIDCASE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidFile"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidFile")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 102,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidFile",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "GuidFile",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseFileResources.GUIDFILE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCase"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCaseFiles" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCase.GuidCase")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCase.GuidCase" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCases" });
			

	
	//fk_SdCaseFile_SdCase
		//if (this.Request.QueryString["fk"] != "SDCase")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 103,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCase",
					PropertyNavigationKey = "GuidCase",
					PropertyNavigationText = "BodyContent",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="BodyContent",
					GetMethodDisplayValue = "GuidCase",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCase",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDCase.BodyContent",
					
	
                    TypeName = "SFSServiceDeskModel.SDCase",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDCases"
                    /*,PropertyDisplayName = Resources.SDCaseFileResources.SDCASE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDFile"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCaseFiles" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDFile.GuidFile")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDFile.GuidFile" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDFiles" });
			

	
	//fk_SdCaseFile_SdFile
		//if (this.Request.QueryString["fk"] != "SDFile")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 104,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDFile",
					PropertyNavigationKey = "GuidFile",
					PropertyNavigationText = "FileName",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="FileName",
					GetMethodDisplayValue = "GuidFile",
					
					CustomProperties = customProperties,

                    PropertyName = "SDFile",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDFile.FileName",
					
	
                    TypeName = "SFSServiceDeskModel.SDFile",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDFiles"
                    /*,PropertyDisplayName = Resources.SDCaseFileResources.SDFILE*/
                });
		//	}
	
	}
	
				
                    _properties = results;
                    return _properties;
                }
                else {
                    return _properties;
                }
            }

		protected override  UIModel<SDCaseFileModel> GetByForShow(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, params  object[] extraParams)
        {
			if (Request != null )
				if (!string.IsNullOrEmpty(Request.QueryString["q"]))
					filter = filter + HttpUtility.UrlDecode(Request.QueryString["q"]);
 if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
            }
            var bos = BR.SDCaseFilesBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), contextRequest, extraParams);
			//var bos = BR.SDCaseFilesBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), context, extraParams);
            SDCaseFileModel model = null;
            List<SDCaseFileModel> results = new List<SDCaseFileModel>();
            foreach (var item in bos)
            {
                model = new SDCaseFileModel();
				model.Bind(item);
				results.Add(model);
            }
            //return results;
			UIModel<SDCaseFileModel> uiModel = GetContextModel(UIModelContextTypes.Items, null);
            uiModel.Items = results;
			if (Request != null){
				if (SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(Request.RequestContext, "action") == "Download")
				{
					uiModel.ContextType = UIModelContextTypes.ExportDownload;
				}
			}
            Showing(ref uiModel);
            return uiModel;
		}			
		
		//public List<SDCaseFileModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params  object[] extraParams)
        //{
		//	var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, null, extraParams);
        public override List<SDCaseFileModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest,  params  object[] extraParams)
        {
            var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
           
            return uiModel.Items;
		
        }
		/*
        [MyAuthorize("r", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir)
        {
			 return GetByJsonBase(filter, pageSize, page, orderBy, orderDir);
        }*/

		  [MyAuthorize("r", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir,ContextRequest contextRequest,  object[] extraParams)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
			 
			 if (this.IsRESTRequest == false)
            {
                return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
            }else
            {
                try
                {
                    return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);

                }
            }
        }
/*		  [MyAuthorize("r", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
       public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }*/
		[MyAuthorize()]
		public ActionResult GetByCount(string filter, ContextRequest contextRequest) {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
           
			
             if (this.IsRESTRequest == true)
            {
                try
                {

                    var result = BR.SDCaseFilesBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);

                   if (Request.QueryString["v"] == "2")
                    {
						return ResolveApiResponse("success", null, null, result);

                        //return Json(new { status = "success", data = result }, JsonRequestBehavior.AllowGet);
                    }else
                    {
                        return Content(result.ToString());

                    }
                }
                catch (Exception ex)
                {
                  //  return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
				  return ResolveApiResponse("error", "exception", ex.ToString(), null);

                }
            }
            else
            {
                var result = BR.SDCaseFilesBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);
                return Content(result.ToString());
            }
		}
		

		[MyAuthorize("r", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
        public ActionResult GetByKeyJson(string id, ContextRequest contextRequest,  bool dec = false)
        {
            return Json(GetByKey(id, null, contextRequest, dec), JsonRequestBehavior.AllowGet);
        }
		public SDCaseFileModel GetByKey(string id) {
			return GetByKey(id, null,null, false);
       	}
		    public SDCaseFileModel GetByKey(string id, string includes)
        {
            return GetByKey(id, includes, false);
        }
		 public  SDCaseFileModel GetByKey(string id, string includes, ContextRequest contextRequest)
        {
            return GetByKey(id, includes, contextRequest, false);
        }
		/*
		  public ActionResult ShowField(string fieldName, string idField) {
		   string safePropertyName = fieldName;
              if (fieldName.StartsWith("Fk"))
              {
                  safePropertyName = fieldName.Substring(2, fieldName.Length - 2);
              }

             SDCaseFileModel model = new  SDCaseFileModel();

            UIModel uiModel = GetUIModel(model, new string[] { "NoField-" });
			
				uiModel.Properties = GetProperties(uiModel, safePropertyName);
		uiModel.Properties.ForEach(p=> p.ContextType = uiModel.ContextType );
            uiModel.ContextType = UIModelContextTypes.FilterFields;
            uiModel.OverrideApp = GetOverrideApp();
            uiModel.UseMode = GetUseMode();

            ViewData["uiModel"] = uiModel;
			var prop = uiModel.Properties.FirstOrDefault(p=>p.PropertyName == safePropertyName);
            //if (prop.IsNavigationProperty && prop.IsNavigationPropertyMany == false)
            //{
            //    ViewData["currentProperty"] = uiModel.Properties.FirstOrDefault(p => p.PropertyName != fieldName + "Text");
            //}else if (prop.IsNavigationProperty == false){
                ViewData["currentProperty"] = prop;
           // }
            ((PropertyDefinition)ViewData["currentProperty"]).RemoveLayout = true;
			ViewData["withContainer"] = false;


            return PartialView("GenericField", model);


        }
      */
	public SDCaseFileModel GetByKey(string id, ContextRequest contextRequest, bool dec)
        {
            return GetByKey(id, null, contextRequest, dec);
        }
        public SDCaseFileModel GetByKey(string id, string  includes, bool dec)
        {
            return GetByKey(id, includes, null, dec);
        }

        public SDCaseFileModel GetByKey(string id, string includes, ContextRequest contextRequest, bool dec) {
		             SDCaseFileModel model = null;
            ControllerEventArgs<SDCaseFileModel> e = null;
			string objectKey = id.Replace("-","/");
             OnGettingByKey(this, e=  new ControllerEventArgs<SDCaseFileModel>() { Id = objectKey  });
             bool cancel = false;
             SDCaseFileModel eItem = null;
             if (e != null)
             {
                 cancel = e.Cancel;
                 eItem = e.Item;
             }
			if (cancel == false && eItem == null)
             {
			Guid guidCasefile = Guid.Empty; //new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, "GuidCasefile"));
			if (dec)
                 {
                     guidCasefile = new Guid(id);
                 }
                 else
                 {
                     guidCasefile = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, null));
                 }
			
            
				model = new SDCaseFileModel();
                  if (contextRequest == null)
                {
                    contextRequest = GetContextRequest();
                }
				var bo = BR.SDCaseFilesBR.Instance.GetByKey(guidCasefile, GetUseMode(), contextRequest,  includes);
				 if (bo != null)
                    model.Bind(bo);
                else
                    return null;
			}
             else {
                 model = eItem;
             }
			model.IsNew = false;

            return model;
        }
        // GET: /SDCaseFiles/DetailsGen/5
		[MyAuthorize("r", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
        public ActionResult DetailsGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDCaseFileResources.ENTITY_PLURAL;
			 #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDCaseFileModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
            #endregion



			 bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
			//UIModel<SDCaseFileModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, decripted), decripted, guidId);
			var item = GetByKey(id, null, null, decripted);
			if (item == null)
            {
                 RouteValueDictionary rv = new RouteValueDictionary();
                string usemode = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"usemode");
                string overrideModule = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "overrideModule");
                string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");

                if(!string.IsNullOrEmpty(usemode)){
                    rv.Add("usemode", usemode);
                }
                if(!string.IsNullOrEmpty(overrideModule)){
                    rv.Add("overrideModule", overrideModule);
                }
                if (!string.IsNullOrEmpty(area))
                {
                    rv.Add("area", area);
                }

                return RedirectToAction("Index", rv);
            }
            //
            UIModel<SDCaseFileModel> uiModel = null;
                uiModel = GetContextModel(UIModelContextTypes.DisplayForm, item, decripted, guidId);



            MyEventArgs<UIModel<SDCaseFileModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseFileModel>>() { Object = uiModel });

            if (me != null) {
                uiModel = me.Object;
            }
			
            Showing(ref uiModel);
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			
            //return View("DisplayGen", uiModel.Items[0]);
			return ResolveView(uiModel, uiModel.Items[0]);

        }
		[MyAuthorize("r", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
		public ActionResult DetailsViewGen(string id)
        {

		 bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDCaseFileModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
           
			if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
 			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
           
        	 //var uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id));
			 
            bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true")
                {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
            UIModel<SDCaseFileModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, null, decripted), decripted, guidId);
			

            MyEventArgs<UIModel<SDCaseFileModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseFileModel>>() { Object = uiModel });

            if (me != null)
            {
                uiModel = me.Object;
            }
            
            Showing(ref uiModel);
            return ResolveView(uiModel, uiModel.Items[0]);
        
        }
        //
        // GET: /SDCaseFiles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /SDCaseFiles/CreateGen
		[MyAuthorize("c", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
        public ActionResult CreateGen()
        {
			SDCaseFileModel model = new SDCaseFileModel();
            model.IsNew = true;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model);

			OnCreateShowing(this, e = new ControllerEventArgs<SDCaseFileModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }

             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                 ViewData["ispopup"] = true;
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                 ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                 ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

            Showing(ref me);

			return ResolveView(me, me.Items[0]);
        } 
			
		protected override UIModel<SDCaseFileModel> GetContextModel(UIModelContextTypes formMode, SDCaseFileModel model)
        {
            return GetContextModel(formMode, model, false, null);
        }
			
		 private UIModel<SDCaseFileModel> GetContextModel(UIModelContextTypes formMode, SDCaseFileModel model, bool decript, Guid ? id) {
            UIModel<SDCaseFileModel> me = new UIModel<SDCaseFileModel>(true, "SDCaseFiles");
			me.UseMode = GetUseMode();
			me.Controller = this;
			me.OverrideApp = GetOverrideApp();
			me.ContextType = formMode ;
			me.Id = "SDCaseFile";
			
            me.ModuleKey = "SFSServiceDesk";

			me.ModuleNamespace = "SFS.ServiceDesk";
            me.EntityKey = "SDCaseFile";
            me.EntitySetName = "SDCaseFiles";

			me.AreaAction = "SFSServiceDesk";
            me.ControllerAction = "SDCaseFiles";
            me.PropertyKeyName = "GuidCasefile";

            me.Properties = GetProperties(me, decript, id);
 			
			if (Request != null)
            {
                string actionName = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam( Request.RequestContext, "action");
                if(actionName != null && actionName.ToLower().Contains("create") ){
                    me.IsNew = true;
                }
            }
			 #region Buttons
			 if (Request != null ){
             if (formMode == UIModelContextTypes.DisplayForm || formMode == UIModelContextTypes.EditForm || formMode == UIModelContextTypes.ListForm)
				me.ActionButtons = GetActionButtons(formMode,model != null ?(Request.QueryString["dec"] == "true" ? model.Id : model.SafeKey)  : null, "SFSServiceDesk", "SDCaseFiles", "SDCaseFile", me.IsNew);

            //me.ActionButtons.Add(new ActionModel() { ActionKey = "return", Title = GlobalMessages.RETURN, Url = System.Web.VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCaseFiles" });
			if (this.HttpContext != null &&  !this.HttpContext.SkipAuthorization){
				//antes this.HttpContext
				me.SetAction("u", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("u", "SDCaseFile", "SFSServiceDesk"));
				me.SetAction("c", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("c", "SDCaseFile", "SFSServiceDesk"));
				me.SetAction("d", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("d", "SDCaseFile", "SFSServiceDesk"));
			
			}else{
				me.SetAction("u", true);
				me.SetAction("c", true);
				me.SetAction("d", true);

			}
            #endregion              
         
            switch (formMode)
            {
                case UIModelContextTypes.DisplayForm:
					//me.TitleForm = SDCaseFileResources.SDCASEFILES_DETAILS;
                    me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.MODIFY_DATA;
					 me.Properties.Where(p=>p.PropertyName  != "Id" && p.IsForeignKey == false).ToList().ForEach(p => p.IsHidden = false);

					 me.Properties.Where(p => (p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier) ).ToList().ForEach(p=> me.SetHide(p.PropertyName));

                    break;
                case UIModelContextTypes.EditForm:
				  me.Properties.Where(p=>p.SystemProperty != SystemProperties.Identifier && p.IsForeignKey == false && p.PropertyName != "Id").ToList().ForEach(p => p.IsHidden = false);

					if (model != null)
                    {
						

                        me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.SAVE_DATA;                        
                        me.ActionButtons.First(p => p.ActionKey == "c").Title = GlobalMessages.SAVE_DATA;
						if (model.IsNew ){
							//me.TitleForm = SDCaseFileResources.SDCASEFILES_ADD_NEW;
							me.ActionName = "CreateGen";
							me.Properties.RemoveAll(p => p.SystemProperty != null || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));
						}else{
							
							me.ActionName = "EditGen";

							//me.TitleForm = SDCaseFileResources.SDCASEFILES_EDIT;
							me.Properties.RemoveAll(p => p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));	
						}
						//me.Properties.Remove(me.Properties.Find(p => p.PropertyName == "UpdatedDate"));
					
					}
                    break;
                case UIModelContextTypes.FilterFields:
                    break;
                case UIModelContextTypes.GenericForm:
                    break;
                case UIModelContextTypes.Items:
				//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "GuidCasefile") != null){
						me.Properties.Find(p => p.PropertyName == "GuidCasefile").IsHidden = false;
					 }
					 
                    
					

						 if (me.Properties.Find(p => p.PropertyName == "GuidCasefile") != null){
						me.Properties.Find(p => p.PropertyName == "GuidCasefile").IsHidden = false;
					 }
					 
                    
					


                  


					//}
                    break;
                case UIModelContextTypes.ListForm:
					PropertyDefinition propFinded = null;
					//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "GuidCasefile") != null){
						me.Properties.Find(p => p.PropertyName == "GuidCasefile").IsHidden = false;
					 }
					
					me.PrincipalActionName = "GetByJson";
					//}
					//me.TitleForm = SDCaseFileResources.SDCASEFILES_LIST;
                    break;
                default:
                    break;
            }
            	this.SetDefaultProperties(me);
			}
			if (model != null )
            	me.Items.Add(model);
            return me;
        }
		// GET: /SDCaseFiles/CreateViewGen
		[MyAuthorize("c", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
        public ActionResult CreateViewGen()
        {
				SDCaseFileModel model = new SDCaseFileModel();
            model.IsNew = true;
			e= null;
			OnCreateShowing(this, e = new ControllerEventArgs<SDCaseFileModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }
			
            var me = GetContextModel(UIModelContextTypes.EditForm, model);

			me.IsPartialView = true;	
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
            {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                me.Properties.Find(p => p.PropertyName == ViewData["fk"].ToString()).IsReadOnly = true;
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
			
      
            //me.Items.Add(model);
            Showing(ref me);
            return ResolveView(me, me.Items[0]);
        }
		protected override  void GettingExtraData(ref UIModel<SDCaseFileModel> uiModel)
        {

            MyEventArgs<UIModel<SDCaseFileModel>> me = null;
            OnGettingExtraData(this, me = new MyEventArgs<UIModel<SDCaseFileModel>>() { Object = uiModel });
            //bool maybeAnyReplaced = false; 
            if (me != null)
            {
                uiModel = me.Object;
                //maybeAnyReplaced = true;
            }
           
			bool canFill = false;
			 string query = null ;
            bool isFK = false;
			PropertyDefinition prop =null;
			var contextRequest = this.GetContextRequest();
            contextRequest.CustomParams.Add(new CustomParam() { Name="ui", Value= SDCaseFile.EntityName });

            			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDCase");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidCase = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidCase = @GuidCase";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidCase = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidCase = @GuidCase";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDCase")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidCase", new Nullable<Guid>(Guid.Parse( Request.QueryString["fkValue"])));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDCasesBR()).GetBy(query, contextRequest), "GuidCase", "BodyContent", Request.QueryString["fkValue"]), PropertyName = "SDCase" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDCasesBR()).GetBy(query, contextRequest), "GuidCase", "BodyContent"), PropertyName = "SDCase" });    

					}
    if (isFK)
                    {    
						var FkSDCase = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDCase").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDCaseText").SetValue(uiModel.Items[0], FkSDCase.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDCase").SetValue(uiModel.Items[0], Guid.Parse(FkSDCase.Value));
                    
					}    
				}
			}
		 
			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDFile");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidFile = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidFile = @GuidFile";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidFile = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidFile = @GuidFile";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDFile")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidFile", new Nullable<Guid>(Guid.Parse( Request.QueryString["fkValue"])));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDFilesBR()).GetBy(query, contextRequest), "GuidFile", "FileName", Request.QueryString["fkValue"]), PropertyName = "SDFile" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDFilesBR()).GetBy(query, contextRequest), "GuidFile", "FileName"), PropertyName = "SDFile" });    

					}
    if (isFK)
                    {    
						var FkSDFile = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDFile").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDFileText").SetValue(uiModel.Items[0], FkSDFile.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDFile").SetValue(uiModel.Items[0], Guid.Parse(FkSDFile.Value));
                    
					}    
				}
			}
		 
            

        }
		private void Showing(ref UIModel<SDCaseFileModel> uiModel) {
          	
			MyEventArgs<UIModel<SDCaseFileModel>> me = new MyEventArgs<UIModel<SDCaseFileModel>>() { Object = uiModel };
			 OnVirtualLayoutSettings(this, me);


            OnShowing(this, me);

			
			if ((Request != null && Request.QueryString["allFields"] == "1") || Request == null )
			{
				me.Object.Properties.ForEach(p=> p.IsHidden = false);
            }
            if (me != null)
            {
                uiModel = me.Object;
            }
          


			 if (uiModel.ContextType == UIModelContextTypes.EditForm)
			    GettingExtraData(ref uiModel);
            ViewData["UIModel"] = uiModel;

        }
        //
        // POST: /SDCaseFiles/Create
		[MyAuthorize("c", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
        [HttpPost]
		[ValidateInput(false)] 
        public ActionResult CreateGen(SDCaseFileModel  model,  ContextRequest contextRequest)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
		 	e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDCaseFileModel>() { Item = model });
           
		  	if (!ModelState.IsValid) {
				model.IsNew = true;
				var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
                 if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                        ViewData["ispopup"] = true;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
                    return ResolveView(me, model);
            }
            try
            {
				if (model.GuidCasefile == null || model.GuidCasefile.ToString().Contains("000000000"))
				model.GuidCasefile = Guid.NewGuid();
	
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnCreating(this, e = new ControllerEventArgs<SDCaseFileModel>() { Item = model });
                if (e != null) {
                   if (e.Cancel && e.RedirectValues.Count > 0){
                        RouteValueDictionary rv = new RouteValueDictionary();
                        if (e.RedirectValues["area"] != null ){
                            rv.Add("area", e.RedirectValues["area"].ToString());
                        }
                        foreach (var item in e.RedirectValues.Where(p=>p.Key != "area" && p.Key != "controller" &&  p.Key != "action" ))
	                    {
		                    rv.Add(item.Key, item.Value);
	                    }

                        //if (e.RedirectValues["action"] != null && e.RedirectValues["controller"] != null && e.RedirectValues["area"] != null )
                        return RedirectToAction(e.RedirectValues["action"].ToString(), e.RedirectValues["controller"].ToString(), rv );


                        
                    }else if (e.Cancel && e.ActionResult != null )
                        return e.ActionResult;  
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				if (contextRequest == null || contextRequest.Company == null){
					contextRequest = GetContextRequest();
					
				}
                if (!cancel)
                	model.Bind(SDCaseFilesBR.Instance.Create(model.GetBusinessObject(), contextRequest ));
				OnCreated(this, e = new ControllerEventArgs<SDCaseFileModel>() { Item = model });
                 if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                        return ResolveApiResponse("success", null, null, null);

                    }
                }
				 
				 if (e != null )
					if (e.ActionResult != null)
                    	replaceResult = true;		
				if (!replaceResult)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))
                    {
                        ViewData["__continue"] = true;
                    }
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"]) &&  string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
                        popupextra.Add("id", model.SafeKey);
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                       {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                            popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"area"));
                            popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                            popupextra.Add("action", actionDetails);
                       if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
                    {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))

                        {
                            var popupextra = GetRouteData();
                            popupextra.Add("id", model.SafeKey);
                            return RedirectToAction("EditViewGen", popupextra);
                        }
                        else
                        {
                            return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.ADD_DONE));
                        }
                    }        			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                        return Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]);
                    else{

							RouteValueDictionary popupextra = null; 
							if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"])){
                            popupextra = GetRouteData();
							 string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
                            if (!string.IsNullOrEmpty(area))
                                popupextra.Add("area", area);
                            
                            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"])) {
								popupextra.Add("id", model.SafeKey);
                                return RedirectToAction("EditGen", popupextra);

                            }else{
								
                            return RedirectToAction("Index", popupextra);
							}
							}else{
								return Content("ok");
							}
                        }
						 }
                else {
                    return e.ActionResult;
                    }
				}
            catch(Exception ex)
            {
					  SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        throw ex;
                    }
                    else
                    {
                       // return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
					   return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
                SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                model.IsNew = true;
                var me = GetContextModel(UIModelContextTypes.EditForm, model, true, model.GuidCasefile);
                Showing(ref me);
                if (isPopUp)
                {
                    
                        ViewData["ispopup"] = isPopUp;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
					if (Request != null)
						return ResolveView(me, model);
					else
						return Content("ok");
            }
        }        
        //
        // GET: /SDCaseFiles/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }
			
		
		[MyAuthorize("u", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
		[MvcSiteMapNode(Area="SFSServiceDesk", Title="sss", Clickable=false, ParentKey = "SFSServiceDesk_SDCaseFile_List")]
		public ActionResult EditGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDCaseFileResources.ENTITY_SINGLE;		 	
  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDCaseFileModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
            SDCaseFileModel model = null;
            // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
			bool dec = false;
            Guid ? idGuidDecripted = null ;
            if (Request != null && Request.QueryString["dec"] == "true")
            {
                dec = true;
                idGuidDecripted = Guid.Parse(id);
            }

            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model,dec,idGuidDecripted);
            Showing(ref me);


            if (!replaceResult)
            {
                 //return View("EditGen", me.Items[0]);
				 return ResolveView(me, me.Items[0]);
            }
            else {
                return e.ActionResult;
            }
        }
			[MyAuthorize("u", "SDCaseFile","SFSServiceDesk", typeof(SDCaseFilesController))]
		public ActionResult EditViewGen(string id)
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

					  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDCaseFileModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
			
            SDCaseFileModel model = null;
			 bool dec = false;
            Guid? guidId = null ;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                dec = true;
                guidId = Guid.Parse(id);
            }
            // si fue implementado el método parcial y no se ha decidido suspender la acción
            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
            var me = GetContextModel(UIModelContextTypes.EditForm, model, dec, guidId);
            Showing(ref me);

            return ResolveView(me, model);
        }
		[MyAuthorize("u", "SDCaseFile",  "SFSServiceDesk", typeof(SDCaseFilesController))]
		[HttpPost]
		[ValidateInput(false)] 
		        public ActionResult EditGen(SDCaseFileModel model)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
			e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDCaseFileModel>() { Item = model });
           
            if (!ModelState.IsValid)
            {
			   	var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
			
				if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"])){
                	ViewData["ispopup"] = true;
					return ResolveView(me, model);
				}
				else
					return ResolveView(me, model);
            }
            try
            {
			
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnEditing(this, e = new ControllerEventArgs<SDCaseFileModel>() { Item = model });
                if (e != null) {
                    if (e.Cancel && e.ActionResult != null)
                        return e.ActionResult;
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				ContextRequest context = new ContextRequest();
                context.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;

                SDCaseFile resultObj = null;
			    if (!cancel)
                	resultObj = SDCaseFilesBR.Instance.Update(model.GetBusinessObject(), GetContextRequest());
				
				OnEdited(this, e = new ControllerEventArgs<SDCaseFileModel>() { Item =   new SDCaseFileModel(resultObj) });
				if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                         return ResolveApiResponse("success", null, null, null);
                    }
                }
				
				if (e != null && e.ActionResult != null) replaceResult = true; 

                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Content("ok");
                }
                else
                {
				if (!replaceResult)
                {
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"])  && string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
						 if (Request != null && Request.QueryString["dec"] == "true")
                        {
                            popupextra.Add("id", model.Id);
                        }
                        else
                        {
							popupextra.Add("id", model.SafeKey);

							
                        }
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                        {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                        popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area"));
                        popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                        popupextra.Add("action", actionDetails);
                        if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
					if (isPopUp)
						return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.UPDATE_DONE));
        			    string returnUrl = null;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"])) {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.Form["ReturnAfter"];
                        else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"];
                    }
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else{
		RouteValueDictionary popupextra = null; 
						 if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"]))
                            {
							
							popupextra = GetRouteData();
							string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
							if (!string.IsNullOrEmpty(area))
								popupextra.Add("area", area);

							return RedirectToAction("Index", popupextra);
						}else{
							return Content("ok");
						}
						}
				 }
                else {
                    return e.ActionResult;
				}
                }		
            }
          catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content(ex.ToString());
                    }
                    else
                    {
                        //return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
						 return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
			    if (isPopUp)
                {
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(ex.Message));
                    
                }
                else
                {
                    SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                    
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else {
						  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
							ViewData["ispopup"] = true;
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
							ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
							ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

						var me = GetContextModel(UIModelContextTypes.EditForm, model);
						Showing(ref me);

						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
						{
							ViewData["ispopup"] = true;
							return ResolveView(me, model);
						}
						else
							return ResolveView(me, model);

						
					}
				}
            }
        }
        //
        // POST: /SDCaseFiles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //  Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SDCaseFiles/Delete/5
        
		[MyAuthorize("d", "SDCaseFile", "SFSServiceDesk", typeof(SDCaseFilesController))]
		[HttpDelete]
        public ActionResult DeleteGen(string objectKey, string extraParams)
        {
            try
            {
					
			
				Guid guidCasefile = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey.Replace("-", "/"), "GuidCasefile")); 
                BO.SDCaseFile entity = new BO.SDCaseFile() { GuidCasefile = guidCasefile };

                BR.SDCaseFilesBR.Instance.Delete(entity, GetContextRequest());               
                return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.DELETE_DONE));

            }
            catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null)
                    {
                        message = ex.Data["usermessage"].ToString();
                    }

                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }
            }
        }
		/*[MyAuthorize()]
		public FileMediaResult Download(string query, bool? allSelected = false,  string selected = null , string orderBy = null , string direction = null , string format = null , string actionKey=null )
        {
			
            List<Guid> keysSelected1 = new List<Guid>();
            if (!string.IsNullOrEmpty(selected)) {
                foreach (var keyString in selected.Split(char.Parse("|")))
                {
				
                    keysSelected1.Add(Guid.Parse(keyString));
                }
            }
				
            query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(query, allSelected.Value, selected, "GuidCasefile");
            MyEventArgs<ContextActionModel<SDCaseFileModel>> eArgs = null;
            List<SDCaseFileModel> results = GetBy(query, null, null, orderBy, direction, GetContextRequest(), keysSelected1);
            OnDownloading(this, eArgs = new MyEventArgs<ContextActionModel<SDCaseFileModel>>() { Object = new ContextActionModel<SDCaseFileModel>() { Query = query, SelectedItems = results, Selected=selected, SelectAll = allSelected.Value, Direction = direction , OrderBy = orderBy, ActionKey=actionKey  } });

            if (eArgs != null)
            {
                if (eArgs.Object.Result != null)
                    return (FileMediaResult)eArgs.Object.Result;
            }
            

            return (new FeaturesController()).ExportDownload(typeof(SDCaseFileModel), results, format, this.GetUIPluralText("SFSServiceDesk", "SDCaseFile"));
            
        }
			*/
		
		[HttpPost]
        public ActionResult CustomActionExecute(ContextActionModel model) {
		 try
            {
			//List<Guid> keysSelected1 = new List<Guid>();
			List<object> keysSelected1 = new List<object>();
            if (!string.IsNullOrEmpty(model.Selected))
            {
                foreach (var keyString in model.Selected.Split(char.Parse(",")))
                {
				
				keysSelected1.Add(Guid.Parse(keyString.Split(char.Parse("|"))[0]));
                        
                    

			
                }
            }
			DataAction dataAction = DataAction.GetDataAction(Request);
			 model.Selected = dataAction.Selected;

            model.Query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(dataAction.Query, dataAction.AllSelected, dataAction.Selected, "GuidCasefile");
           
            
			
			#region implementaci�n de m�todo parcial
            bool replaceResult = false;
            MyEventArgs<ContextActionModel<SDCaseFileModel>> actionEventArgs = null;
           
			if (model.ActionKey != "deletemany" && model.ActionKey != "deleterelmany" && model.ActionKey != "updateRel" &&  model.ActionKey != "delete-relation-fk" && model.ActionKey != "restore" )
			{
				ContextRequest context = SFSdotNet.Framework.My.Context.BuildContextRequestSafe(System.Web.HttpContext.Current);
				context.UseMode = dataAction.Usemode;

				if (model.IsBackground)
				{
					System.Threading.Tasks.Task.Run(() => 
						OnCustomActionExecutingBackground(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDCaseFileModel>>() { Object = new ContextActionModel<SDCaseFileModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } })
					);
				}
				else
				{
					OnCustomActionExecuting(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDCaseFileModel>>() {  Object = new ContextActionModel<SDCaseFileModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } });
				}
			}
            List<SDCaseFileModel> results = null;
	
			if (model.ActionKey == "deletemany") { 
				
				BR.SDCaseFilesBR.Instance.Delete(model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());

            }
	
            else if (model.ActionKey == "updateRel" || model.ActionKey == "delete-relation-fk" || model.ActionKey == "updateRel-proxyMany")
            {
               try {
                   string valueForUpdate = null;
				   string propForUpdate = null;
				   if (!string.IsNullOrEmpty(Request.Params["propertyForUpdate"])){
						propForUpdate = Request.Params["propertyForUpdate"];
				   }
				    if (string.IsNullOrEmpty(propForUpdate) && !string.IsNullOrEmpty(Request.QueryString["propertyForUpdate"]))
                   {
                       propForUpdate = Request.QueryString["propertyForUpdate"];
                   }
                    if (model.ActionKey != "delete-relation-fk")
                    {
                        valueForUpdate = Request.QueryString["valueForUpdate"];
                    }
                    BR.SDCaseFilesBR.Instance.UpdateAssociation(propForUpdate, valueForUpdate, model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());
					
                    if (model.ActionKey == "delete-relation-fk")
                    {
                        MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]);

                        return PartialView("ResultMessageView", message);
                    }
                    else
                    {
                        return Content("ok");
                    }
       
          
                }
                catch (Exception ex)
                {
				        SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
           
                }
            
            }
		
                if (actionEventArgs == null && !model.IsBackground)
                {
                    //if (model.ActionKey != "deletemany"  && model.ActionKey != "deleterelmany")
                    //{
                     //   throw new NotImplementedException("");
                    //}
                }
                else
                {
					if (model.IsBackground == false )
						 replaceResult = actionEventArgs.Object.Result is ActionResult /*actionEventArgs.Object.ReplaceResult*/;
                }
                #endregion
                if (!replaceResult)
                {
                    if (Request != null && Request.IsAjaxRequest())
                    {
						MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]) ;
                        if (model.IsBackground )
                            message.Message = GlobalMessages.THE_PROCESS_HAS_BEEN_STARTED;
                        
                        return PartialView("ResultMessageView", message);                    
					}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return (ActionResult)actionEventArgs.Object.Result;
                }
            }
            catch (Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null) {
                        message = ex.Data["usermessage"].ToString();
                    }
					 SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }

            }
        }
        //
        // POST: /SDCaseFiles/Delete/5
        
			
	
    }
}
namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
	using SFS.ServiceDesk.Web.Mvc.Models.SDCaseHistories;

    public partial class SDCaseHistoriesController : SFS.ServiceDesk.Web.Mvc.ControllerBase<Models.SDCaseHistories.SDCaseHistoryModel>
    {

       


	#region partial methods
        ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e = null;
        partial void OnValidating(object sender, ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e);
        partial void OnGettingExtraData(object sender, MyEventArgs<UIModel<Models.SDCaseHistories.SDCaseHistoryModel>> e);
        partial void OnCreating(object sender, ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e);
        partial void OnCreated(object sender, ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e);
        partial void OnEditing(object sender, ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e);
        partial void OnEdited(object sender, ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e);
        partial void OnDeleting(object sender, ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e);
        partial void OnDeleted(object sender, ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e);
    	partial void OnShowing(object sender, MyEventArgs<UIModel<Models.SDCaseHistories.SDCaseHistoryModel>> e);
    	partial void OnGettingByKey(object sender, ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e);
        partial void OnTaken(object sender, ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e);
       	partial void OnCreateShowing(object sender, ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e);
		partial void OnEditShowing(object sender, ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e);
		partial void OnDetailsShowing(object sender, ControllerEventArgs<Models.SDCaseHistories.SDCaseHistoryModel> e);
 		partial void OnActionsCreated(object sender, MyEventArgs<UIModel<Models.SDCaseHistories.SDCaseHistoryModel >> e);
		partial void OnCustomActionExecuting(object sender, MyEventArgs<ContextActionModel<Models.SDCaseHistories.SDCaseHistoryModel>> e);
		partial void OnCustomActionExecutingBackground(object sender, MyEventArgs<ContextActionModel<Models.SDCaseHistories.SDCaseHistoryModel>> e);
        partial void OnDownloading(object sender, MyEventArgs<ContextActionModel<Models.SDCaseHistories.SDCaseHistoryModel>> e);
      	partial void OnAuthorization(object sender, AuthorizationContext context);
		 partial void OnFilterShowing(object sender, MyEventArgs<UIModel<Models.SDCaseHistories.SDCaseHistoryModel >> e);
         partial void OnSummaryOperationShowing(object sender, MyEventArgs<UIModel<Models.SDCaseHistories.SDCaseHistoryModel>> e);

        partial void OnExportActionsCreated(object sender, MyEventArgs<UIModel<Models.SDCaseHistories.SDCaseHistoryModel>> e);


		protected override void OnVirtualFilterShowing(object sender, MyEventArgs<UIModel<SDCaseHistoryModel>> e)
        {
            OnFilterShowing(sender, e);
        }
		 public override void OnVirtualExportActionsCreated(object sender, MyEventArgs<UIModel<SDCaseHistoryModel>> e)
        {
            OnExportActionsCreated(sender, e);
        }
        public override void OnVirtualDownloading(object sender, MyEventArgs<ContextActionModel<SDCaseHistoryModel>> e)
        {
            OnDownloading(sender, e);
        }
        public override void OnVirtualShowing(object sender, MyEventArgs<UIModel<SDCaseHistoryModel>> e)
        {
            OnShowing(sender, e);
        }

	#endregion
	#region API
	 public override ActionResult ApiCreateGen(SDCaseHistoryModel model, ContextRequest contextRequest)
        {
            return CreateGen(model, contextRequest);
        }

              public override ActionResult ApiGetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJson(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }
        public override ActionResult ApiGetByKeyJson(string id, ContextRequest contextRequest)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
            return  GetByKeyJson(id, contextRequest, true);
        }
      
		 public override ActionResult ApiGetByCount(string filter, ContextRequest contextRequest)
        {
            return GetByCount(filter, contextRequest);
        }
         protected override ActionResult ApiDeleteGen(List<SDCaseHistoryModel> models, ContextRequest contextRequest)
        {
            List<SDCaseHistory> objs = new List<SDCaseHistory>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                BR.SDCaseHistoriesBR.Instance.DeleteBulk(objs, contextRequest);
                if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("success", null, null, null);

                }
                else
                {
                    return Content("ok");

                }
            }
            catch (Exception ex)
            {
               if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "error", reason = "error", message= ex.ToString() }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("error", "exception", ex.ToString(), null );

                }
                else
                {
                    return Json(ex.ToString(), JsonRequestBehavior.AllowGet);

                }
            }
        }
        protected override ActionResult ApiUpdateGen(List<SDCaseHistoryModel> models, ContextRequest contextRequest)
        {
            List<SDCaseHistory> objs = new List<SDCaseHistory>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                foreach (var obj in objs)
                {
                    BR.SDCaseHistoriesBR.Instance.Update(obj, contextRequest);

                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }


	#endregion
#region Validation methods	
	    private void Validations(SDCaseHistoryModel model) { 
            #region Remote validations

            #endregion
		}

#endregion
		
 		public AuthorizationContext Authorization(AuthorizationContext context)
        {
            OnAuthorization(this,  context );
            return context ;
        }
		public List<SDCaseHistoryModel> GetAll() {
            			var bos = BR.SDCaseHistoriesBR.Instance.GetBy("",
					new SFSdotNet.Framework.My.ContextRequest()
					{
						CustomQuery = new SFSdotNet.Framework.My.CustomQuery()
						{
							OrderBy = "BodyContent",
							SortDirection = SFSdotNet.Framework.Data.SortDirection.Ascending
						}
					});
            			List<SDCaseHistoryModel> results = new List<SDCaseHistoryModel>();
            SDCaseHistoryModel model = null;
            foreach (var bo in bos)
            {
                model = new SDCaseHistoryModel();
                model.Bind(bo);
                results.Add(model);
            }
            return results;

        }
        //
        // GET: /SDCaseHistories/
		[MyAuthorize("r", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
		public ActionResult Index()
        {
    		var uiModel = GetContextModel(UIModelContextTypes.ListForm, null);
			ViewBag.UIModel = uiModel;
			uiModel.FilterStart = (string)ViewData["startFilter"];
                    MyEventArgs<UIModel<SDCaseHistoryModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseHistoryModel>>() { Object = uiModel });

			OnExportActionsCreated(this, (me != null ? me : me = new MyEventArgs<UIModel<SDCaseHistoryModel>>() { Object = uiModel }));

            if (me != null)
            {
                uiModel = me.Object;
            }
            if (me == null)
                me = new MyEventArgs<UIModel<SDCaseHistoryModel>>() { Object = uiModel };
           
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;


            //return View("ListGen");
			return ResolveView(uiModel);
        }
		[MyAuthorize("r", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
		public ActionResult ListViewGen(string idTab, string fk , string fkValue, string startFilter, ListModes  listmode  = ListModes.SimpleList, PropertyDefinition parentRelationProperty = null, object parentRelationPropertyValue = null )
        {
			ViewData["idTab"] = System.Web.HttpContext.Current.Request.QueryString["idTab"]; 
		 	ViewData["detpop"] = true; // details in popup
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"])) {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"]; 
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
            {
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["startFilter"]))
            {
                ViewData["startFilter"] = Request.QueryString["startFilter"];
            }
			
			UIModel<SDCaseHistoryModel> uiModel = GetContextModel(UIModelContextTypes.ListForm, null);

            MyEventArgs<UIModel<SDCaseHistoryModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseHistoryModel>>() { Object = uiModel });
            if (me == null)
                me = new MyEventArgs<UIModel<SDCaseHistoryModel>>() { Object = uiModel };
            uiModel.Properties = GetProperties(uiModel);
            uiModel.ContextType = UIModelContextTypes.ListForm;
             uiModel.FilterStart = (string)ViewData["startFilter"];
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;
			 if (listmode == ListModes.SimpleList)
                return ResolveView(uiModel);
            else
            {
                ViewData["parentRelationProperty"] = parentRelationProperty;
                ViewData["parentRelationPropertyValue"] = parentRelationPropertyValue;
                return PartialView("ListForTagSelectView");
            }
            return ResolveView(uiModel);
        }
		List<PropertyDefinition> _properties = null;

		 protected override List<PropertyDefinition> GetProperties(UIModel uiModel,  params string[] specificProperties)
        { 
            return GetProperties(uiModel, false, null, specificProperties);
        }

		protected override List<PropertyDefinition> GetProperties(UIModel uiModel, bool decripted, Guid? id, params string[] specificProperties)
            {

			bool allProperties = true;    
                if (specificProperties != null && specificProperties.Length > 0)
                {
                    allProperties = false;
                }


			List<CustomProperty> customProperties = new List<CustomProperty>();
			if (_properties == null)
                {
                List<PropertyDefinition> results = new List<PropertyDefinition>();

			string idSDCaseHistory = GetRouteDataOrQueryParam("id");
			if (idSDCaseHistory != null)
			{
				if (!decripted)
                {
					idSDCaseHistory = SFSdotNet.Framework.Entities.Utils.GetPropertyKey(idSDCaseHistory.Replace("-","/"), "GuidCaseHistory");
				}else{
					if (id != null )
						idSDCaseHistory = id.Value.ToString();                

				}
			}

			bool visibleProperty = true;	
			 bool conditionalshow =false;
                if (uiModel.ContextType == UIModelContextTypes.EditForm || uiModel.ContextType == UIModelContextTypes.DisplayForm ||  uiModel.ContextType == UIModelContextTypes.GenericForm )
                    conditionalshow = true;
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidCaseHistory"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidCaseHistory")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 100,
																	
					CustomProperties = customProperties,

                    PropertyName = "GuidCaseHistory",

					 MaxLength = 0,
					IsRequired = true ,
					IsHidden = true,
                    SystemProperty =  SystemProperties.Identifier ,
					IsDefaultProperty = false,
                    SortBy = "GuidCaseHistory",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryResources.GUIDCASEHISTORY*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidCase"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidCase")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 101,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidCase",

					 MaxLength = 0,
					IsRequired = true ,
					IsDefaultProperty = false,
                    SortBy = "GuidCase",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryResources.GUIDCASE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidCaseStatus"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidCaseStatus")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 102,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidCaseStatus",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "GuidCaseStatus",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryResources.GUIDCASESTATUS*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("BodyContent"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "BodyContent")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 103,
																	
					CustomProperties = customProperties,

                    PropertyName = "BodyContent",

					 MaxLength = 255,
					 Nullable = true,
					IsDefaultProperty = true,
                    SortBy = "BodyContent",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryResources.BODYCONTENT*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("PreviewContent"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "PreviewContent")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 104,
																	
					CustomProperties = customProperties,

                    PropertyName = "PreviewContent",

					 MaxLength = 3000,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "PreviewContent",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryResources.PREVIEWCONTENT*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCase"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCaseHistories" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCase.GuidCase")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCase.GuidCase" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCases" });
			

	
	//fk_SdCaseHistory_SdCase
		//if (this.Request.QueryString["fk"] != "SDCase")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 105,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCase",
					PropertyNavigationKey = "GuidCase",
					PropertyNavigationText = "BodyContent",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="BodyContent",
					GetMethodDisplayValue = "GuidCase",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCase",

					 MaxLength = 0,
					IsRequired = true ,
					IsDefaultProperty = false,
                    SortBy = "SDCase.BodyContent",
					
	
                    TypeName = "SFSServiceDeskModel.SDCase",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDCases"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryResources.SDCASE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCaseStatu"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCaseHistories" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCaseStatu.GuidCaseStatus")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCaseStatu.GuidCaseStatus" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCaseStatus" });
			

	
	//fk_SdCaseHistory_SdCaseStatus
		//if (this.Request.QueryString["fk"] != "SDCaseStatu")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 106,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCaseStatu",
					PropertyNavigationKey = "GuidCaseStatus",
					PropertyNavigationText = "Title",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="Title",
					GetMethodDisplayValue = "GuidCaseStatus",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCaseStatu",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDCaseStatu.Title",
					
	
                    TypeName = "SFSServiceDeskModel.SDCaseStatu",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDCaseStatus"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryResources.SDCASESTATU*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCaseHistoryFiles"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCaseHistory" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCaseHistoryFiles.GuidCasehistoryFile")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCaseHistoryFiles.GuidCasehistoryFile" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCaseHistoryFiles" });
			

	
	//fk_SdCaseHistoryFile_SdCaseHistory
		//if (this.Request.QueryString["fk"] != "SDCaseHistoryFiles")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 107,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCaseHistoryFiles/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDCaseHistoryFiles&fk=SDCaseHistory&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDCaseHistory.GuidCaseHistory = Guid(\"" + idSDCaseHistory +"\")")+ "&fkValue=" + idSDCaseHistory,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCaseHistoryFile",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCaseHistoryFiles",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDCaseHistoryFiles.GuidCasehistoryFile",
					
	
                    TypeName = "SFSServiceDeskModel.SDCaseHistoryFile",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDCaseHistoryFiles"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryResources.SDCASEHISTORYFILES*/
                });
		//	}
	
	}
	
				
                    _properties = results;
                    return _properties;
                }
                else {
                    return _properties;
                }
            }

		protected override  UIModel<SDCaseHistoryModel> GetByForShow(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, params  object[] extraParams)
        {
			if (Request != null )
				if (!string.IsNullOrEmpty(Request.QueryString["q"]))
					filter = filter + HttpUtility.UrlDecode(Request.QueryString["q"]);
 if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
            }
            var bos = BR.SDCaseHistoriesBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), contextRequest, extraParams);
			//var bos = BR.SDCaseHistoriesBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), context, extraParams);
            SDCaseHistoryModel model = null;
            List<SDCaseHistoryModel> results = new List<SDCaseHistoryModel>();
            foreach (var item in bos)
            {
                model = new SDCaseHistoryModel();
				model.Bind(item);
				results.Add(model);
            }
            //return results;
			UIModel<SDCaseHistoryModel> uiModel = GetContextModel(UIModelContextTypes.Items, null);
            uiModel.Items = results;
			if (Request != null){
				if (SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(Request.RequestContext, "action") == "Download")
				{
					uiModel.ContextType = UIModelContextTypes.ExportDownload;
				}
			}
            Showing(ref uiModel);
            return uiModel;
		}			
		
		//public List<SDCaseHistoryModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params  object[] extraParams)
        //{
		//	var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, null, extraParams);
        public override List<SDCaseHistoryModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest,  params  object[] extraParams)
        {
            var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
           
            return uiModel.Items;
		
        }
		/*
        [MyAuthorize("r", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir)
        {
			 return GetByJsonBase(filter, pageSize, page, orderBy, orderDir);
        }*/

		  [MyAuthorize("r", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir,ContextRequest contextRequest,  object[] extraParams)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
			 
			 if (this.IsRESTRequest == false)
            {
                return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
            }else
            {
                try
                {
                    return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);

                }
            }
        }
/*		  [MyAuthorize("r", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
       public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }*/
		[MyAuthorize()]
		public ActionResult GetByCount(string filter, ContextRequest contextRequest) {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
           
			
             if (this.IsRESTRequest == true)
            {
                try
                {

                    var result = BR.SDCaseHistoriesBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);

                   if (Request.QueryString["v"] == "2")
                    {
						return ResolveApiResponse("success", null, null, result);

                        //return Json(new { status = "success", data = result }, JsonRequestBehavior.AllowGet);
                    }else
                    {
                        return Content(result.ToString());

                    }
                }
                catch (Exception ex)
                {
                  //  return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
				  return ResolveApiResponse("error", "exception", ex.ToString(), null);

                }
            }
            else
            {
                var result = BR.SDCaseHistoriesBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);
                return Content(result.ToString());
            }
		}
		

		[MyAuthorize("r", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
        public ActionResult GetByKeyJson(string id, ContextRequest contextRequest,  bool dec = false)
        {
            return Json(GetByKey(id, null, contextRequest, dec), JsonRequestBehavior.AllowGet);
        }
		public SDCaseHistoryModel GetByKey(string id) {
			return GetByKey(id, null,null, false);
       	}
		    public SDCaseHistoryModel GetByKey(string id, string includes)
        {
            return GetByKey(id, includes, false);
        }
		 public  SDCaseHistoryModel GetByKey(string id, string includes, ContextRequest contextRequest)
        {
            return GetByKey(id, includes, contextRequest, false);
        }
		/*
		  public ActionResult ShowField(string fieldName, string idField) {
		   string safePropertyName = fieldName;
              if (fieldName.StartsWith("Fk"))
              {
                  safePropertyName = fieldName.Substring(2, fieldName.Length - 2);
              }

             SDCaseHistoryModel model = new  SDCaseHistoryModel();

            UIModel uiModel = GetUIModel(model, new string[] { "NoField-" });
			
				uiModel.Properties = GetProperties(uiModel, safePropertyName);
		uiModel.Properties.ForEach(p=> p.ContextType = uiModel.ContextType );
            uiModel.ContextType = UIModelContextTypes.FilterFields;
            uiModel.OverrideApp = GetOverrideApp();
            uiModel.UseMode = GetUseMode();

            ViewData["uiModel"] = uiModel;
			var prop = uiModel.Properties.FirstOrDefault(p=>p.PropertyName == safePropertyName);
            //if (prop.IsNavigationProperty && prop.IsNavigationPropertyMany == false)
            //{
            //    ViewData["currentProperty"] = uiModel.Properties.FirstOrDefault(p => p.PropertyName != fieldName + "Text");
            //}else if (prop.IsNavigationProperty == false){
                ViewData["currentProperty"] = prop;
           // }
            ((PropertyDefinition)ViewData["currentProperty"]).RemoveLayout = true;
			ViewData["withContainer"] = false;


            return PartialView("GenericField", model);


        }
      */
	public SDCaseHistoryModel GetByKey(string id, ContextRequest contextRequest, bool dec)
        {
            return GetByKey(id, null, contextRequest, dec);
        }
        public SDCaseHistoryModel GetByKey(string id, string  includes, bool dec)
        {
            return GetByKey(id, includes, null, dec);
        }

        public SDCaseHistoryModel GetByKey(string id, string includes, ContextRequest contextRequest, bool dec) {
		             SDCaseHistoryModel model = null;
            ControllerEventArgs<SDCaseHistoryModel> e = null;
			string objectKey = id.Replace("-","/");
             OnGettingByKey(this, e=  new ControllerEventArgs<SDCaseHistoryModel>() { Id = objectKey  });
             bool cancel = false;
             SDCaseHistoryModel eItem = null;
             if (e != null)
             {
                 cancel = e.Cancel;
                 eItem = e.Item;
             }
			if (cancel == false && eItem == null)
             {
			Guid guidCaseHistory = Guid.Empty; //new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, "GuidCaseHistory"));
			if (dec)
                 {
                     guidCaseHistory = new Guid(id);
                 }
                 else
                 {
                     guidCaseHistory = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, null));
                 }
			
            
				model = new SDCaseHistoryModel();
                  if (contextRequest == null)
                {
                    contextRequest = GetContextRequest();
                }
				var bo = BR.SDCaseHistoriesBR.Instance.GetByKey(guidCaseHistory, GetUseMode(), contextRequest,  includes);
				 if (bo != null)
                    model.Bind(bo);
                else
                    return null;
			}
             else {
                 model = eItem;
             }
			model.IsNew = false;

            return model;
        }
        // GET: /SDCaseHistories/DetailsGen/5
		[MyAuthorize("r", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
        public ActionResult DetailsGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDCaseHistoryResources.ENTITY_PLURAL;
			 #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDCaseHistoryModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
            #endregion



			 bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
			//UIModel<SDCaseHistoryModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, decripted), decripted, guidId);
			var item = GetByKey(id, null, null, decripted);
			if (item == null)
            {
                 RouteValueDictionary rv = new RouteValueDictionary();
                string usemode = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"usemode");
                string overrideModule = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "overrideModule");
                string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");

                if(!string.IsNullOrEmpty(usemode)){
                    rv.Add("usemode", usemode);
                }
                if(!string.IsNullOrEmpty(overrideModule)){
                    rv.Add("overrideModule", overrideModule);
                }
                if (!string.IsNullOrEmpty(area))
                {
                    rv.Add("area", area);
                }

                return RedirectToAction("Index", rv);
            }
            //
            UIModel<SDCaseHistoryModel> uiModel = null;
                uiModel = GetContextModel(UIModelContextTypes.DisplayForm, item, decripted, guidId);



            MyEventArgs<UIModel<SDCaseHistoryModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseHistoryModel>>() { Object = uiModel });

            if (me != null) {
                uiModel = me.Object;
            }
			
            Showing(ref uiModel);
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			
            //return View("DisplayGen", uiModel.Items[0]);
			return ResolveView(uiModel, uiModel.Items[0]);

        }
		[MyAuthorize("r", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
		public ActionResult DetailsViewGen(string id)
        {

		 bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDCaseHistoryModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
           
			if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
 			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
           
        	 //var uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id));
			 
            bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true")
                {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
            UIModel<SDCaseHistoryModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, null, decripted), decripted, guidId);
			

            MyEventArgs<UIModel<SDCaseHistoryModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseHistoryModel>>() { Object = uiModel });

            if (me != null)
            {
                uiModel = me.Object;
            }
            
            Showing(ref uiModel);
            return ResolveView(uiModel, uiModel.Items[0]);
        
        }
        //
        // GET: /SDCaseHistories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /SDCaseHistories/CreateGen
		[MyAuthorize("c", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
        public ActionResult CreateGen()
        {
			SDCaseHistoryModel model = new SDCaseHistoryModel();
            model.IsNew = true;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model);

			OnCreateShowing(this, e = new ControllerEventArgs<SDCaseHistoryModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }

             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                 ViewData["ispopup"] = true;
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                 ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                 ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

            Showing(ref me);

			return ResolveView(me, me.Items[0]);
        } 
			
		protected override UIModel<SDCaseHistoryModel> GetContextModel(UIModelContextTypes formMode, SDCaseHistoryModel model)
        {
            return GetContextModel(formMode, model, false, null);
        }
			
		 private UIModel<SDCaseHistoryModel> GetContextModel(UIModelContextTypes formMode, SDCaseHistoryModel model, bool decript, Guid ? id) {
            UIModel<SDCaseHistoryModel> me = new UIModel<SDCaseHistoryModel>(true, "SDCaseHistories");
			me.UseMode = GetUseMode();
			me.Controller = this;
			me.OverrideApp = GetOverrideApp();
			me.ContextType = formMode ;
			me.Id = "SDCaseHistory";
			
            me.ModuleKey = "SFSServiceDesk";

			me.ModuleNamespace = "SFS.ServiceDesk";
            me.EntityKey = "SDCaseHistory";
            me.EntitySetName = "SDCaseHistories";

			me.AreaAction = "SFSServiceDesk";
            me.ControllerAction = "SDCaseHistories";
            me.PropertyKeyName = "GuidCaseHistory";

            me.Properties = GetProperties(me, decript, id);
 			
			if (Request != null)
            {
                string actionName = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam( Request.RequestContext, "action");
                if(actionName != null && actionName.ToLower().Contains("create") ){
                    me.IsNew = true;
                }
            }
			 #region Buttons
			 if (Request != null ){
             if (formMode == UIModelContextTypes.DisplayForm || formMode == UIModelContextTypes.EditForm || formMode == UIModelContextTypes.ListForm)
				me.ActionButtons = GetActionButtons(formMode,model != null ?(Request.QueryString["dec"] == "true" ? model.Id : model.SafeKey)  : null, "SFSServiceDesk", "SDCaseHistories", "SDCaseHistory", me.IsNew);

            //me.ActionButtons.Add(new ActionModel() { ActionKey = "return", Title = GlobalMessages.RETURN, Url = System.Web.VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCaseHistories" });
			if (this.HttpContext != null &&  !this.HttpContext.SkipAuthorization){
				//antes this.HttpContext
				me.SetAction("u", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("u", "SDCaseHistory", "SFSServiceDesk"));
				me.SetAction("c", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("c", "SDCaseHistory", "SFSServiceDesk"));
				me.SetAction("d", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("d", "SDCaseHistory", "SFSServiceDesk"));
			
			}else{
				me.SetAction("u", true);
				me.SetAction("c", true);
				me.SetAction("d", true);

			}
            #endregion              
         
            switch (formMode)
            {
                case UIModelContextTypes.DisplayForm:
					//me.TitleForm = SDCaseHistoryResources.SDCASEHISTORIES_DETAILS;
                    me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.MODIFY_DATA;
					 me.Properties.Where(p=>p.PropertyName  != "Id" && p.IsForeignKey == false).ToList().ForEach(p => p.IsHidden = false);

					 me.Properties.Where(p => (p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier) ).ToList().ForEach(p=> me.SetHide(p.PropertyName));

                    break;
                case UIModelContextTypes.EditForm:
				  me.Properties.Where(p=>p.SystemProperty != SystemProperties.Identifier && p.IsForeignKey == false && p.PropertyName != "Id").ToList().ForEach(p => p.IsHidden = false);

					if (model != null)
                    {
						

                        me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.SAVE_DATA;                        
                        me.ActionButtons.First(p => p.ActionKey == "c").Title = GlobalMessages.SAVE_DATA;
						if (model.IsNew ){
							//me.TitleForm = SDCaseHistoryResources.SDCASEHISTORIES_ADD_NEW;
							me.ActionName = "CreateGen";
							me.Properties.RemoveAll(p => p.SystemProperty != null || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));
						}else{
							
							me.ActionName = "EditGen";

							//me.TitleForm = SDCaseHistoryResources.SDCASEHISTORIES_EDIT;
							me.Properties.RemoveAll(p => p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));	
						}
						//me.Properties.Remove(me.Properties.Find(p => p.PropertyName == "UpdatedDate"));
					
					}
                    break;
                case UIModelContextTypes.FilterFields:
                    break;
                case UIModelContextTypes.GenericForm:
                    break;
                case UIModelContextTypes.Items:
				//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "BodyContent") != null){
						me.Properties.Find(p => p.PropertyName == "BodyContent").IsHidden = false;
					 }
					 
                    
					

						 if (me.Properties.Find(p => p.PropertyName == "GuidCaseHistory") != null){
						me.Properties.Find(p => p.PropertyName == "GuidCaseHistory").IsHidden = false;
					 }
					 
                    
					


                  


					//}
                    break;
                case UIModelContextTypes.ListForm:
					PropertyDefinition propFinded = null;
					//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "BodyContent") != null){
						me.Properties.Find(p => p.PropertyName == "BodyContent").IsHidden = false;
					 }
					
					me.PrincipalActionName = "GetByJson";
					//}
					//me.TitleForm = SDCaseHistoryResources.SDCASEHISTORIES_LIST;
                    break;
                default:
                    break;
            }
            	this.SetDefaultProperties(me);
			}
			if (model != null )
            	me.Items.Add(model);
            return me;
        }
		// GET: /SDCaseHistories/CreateViewGen
		[MyAuthorize("c", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
        public ActionResult CreateViewGen()
        {
				SDCaseHistoryModel model = new SDCaseHistoryModel();
            model.IsNew = true;
			e= null;
			OnCreateShowing(this, e = new ControllerEventArgs<SDCaseHistoryModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }
			
            var me = GetContextModel(UIModelContextTypes.EditForm, model);

			me.IsPartialView = true;	
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
            {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                me.Properties.Find(p => p.PropertyName == ViewData["fk"].ToString()).IsReadOnly = true;
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
			
      
            //me.Items.Add(model);
            Showing(ref me);
            return ResolveView(me, me.Items[0]);
        }
		protected override  void GettingExtraData(ref UIModel<SDCaseHistoryModel> uiModel)
        {

            MyEventArgs<UIModel<SDCaseHistoryModel>> me = null;
            OnGettingExtraData(this, me = new MyEventArgs<UIModel<SDCaseHistoryModel>>() { Object = uiModel });
            //bool maybeAnyReplaced = false; 
            if (me != null)
            {
                uiModel = me.Object;
                //maybeAnyReplaced = true;
            }
           
			bool canFill = false;
			 string query = null ;
            bool isFK = false;
			PropertyDefinition prop =null;
			var contextRequest = this.GetContextRequest();
            contextRequest.CustomParams.Add(new CustomParam() { Name="ui", Value= SDCaseHistory.EntityName });

            			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDCase");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidCase = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidCase = @GuidCase";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidCase = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidCase = @GuidCase";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDCase")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidCase", Guid.Parse( Request.QueryString["fkValue"]));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDCasesBR()).GetBy(query, contextRequest), "GuidCase", "BodyContent", Request.QueryString["fkValue"]), PropertyName = "SDCase" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDCasesBR()).GetBy(query, contextRequest), "GuidCase", "BodyContent"), PropertyName = "SDCase" });    

					}
    if (isFK)
                    {    
						var FkSDCase = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDCase").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDCaseText").SetValue(uiModel.Items[0], FkSDCase.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDCase").SetValue(uiModel.Items[0], Guid.Parse(FkSDCase.Value));
                    
					}    
				}
			}
		 
			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDCaseStatu");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidCaseStatus = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidCaseStatus = @GuidCaseStatus";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidCaseStatus = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidCaseStatus = @GuidCaseStatus";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDCaseStatu")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidCaseStatus", new Nullable<Guid>(Guid.Parse( Request.QueryString["fkValue"])));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDCaseStatusBR()).GetBy(query, contextRequest), "GuidCaseStatus", "Title", Request.QueryString["fkValue"]), PropertyName = "SDCaseStatu" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDCaseStatusBR()).GetBy(query, contextRequest), "GuidCaseStatus", "Title"), PropertyName = "SDCaseStatu" });    

					}
    if (isFK)
                    {    
						var FkSDCaseStatu = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDCaseStatu").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDCaseStatuText").SetValue(uiModel.Items[0], FkSDCaseStatu.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDCaseStatu").SetValue(uiModel.Items[0], Guid.Parse(FkSDCaseStatu.Value));
                    
					}    
				}
			}
		 
            

        }
		private void Showing(ref UIModel<SDCaseHistoryModel> uiModel) {
          	
			MyEventArgs<UIModel<SDCaseHistoryModel>> me = new MyEventArgs<UIModel<SDCaseHistoryModel>>() { Object = uiModel };
			 OnVirtualLayoutSettings(this, me);


            OnShowing(this, me);

			
			if ((Request != null && Request.QueryString["allFields"] == "1") || Request == null )
			{
				me.Object.Properties.ForEach(p=> p.IsHidden = false);
            }
            if (me != null)
            {
                uiModel = me.Object;
            }
          


			 if (uiModel.ContextType == UIModelContextTypes.EditForm)
			    GettingExtraData(ref uiModel);
            ViewData["UIModel"] = uiModel;

        }
        //
        // POST: /SDCaseHistories/Create
		[MyAuthorize("c", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
        [HttpPost]
		[ValidateInput(false)] 
        public ActionResult CreateGen(SDCaseHistoryModel  model,  ContextRequest contextRequest)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
		 	e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDCaseHistoryModel>() { Item = model });
           
		  	if (!ModelState.IsValid) {
				model.IsNew = true;
				var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
                 if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                        ViewData["ispopup"] = true;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
                    return ResolveView(me, model);
            }
            try
            {
				if (model.GuidCaseHistory == null || model.GuidCaseHistory.ToString().Contains("000000000"))
				model.GuidCaseHistory = Guid.NewGuid();
	
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnCreating(this, e = new ControllerEventArgs<SDCaseHistoryModel>() { Item = model });
                if (e != null) {
                   if (e.Cancel && e.RedirectValues.Count > 0){
                        RouteValueDictionary rv = new RouteValueDictionary();
                        if (e.RedirectValues["area"] != null ){
                            rv.Add("area", e.RedirectValues["area"].ToString());
                        }
                        foreach (var item in e.RedirectValues.Where(p=>p.Key != "area" && p.Key != "controller" &&  p.Key != "action" ))
	                    {
		                    rv.Add(item.Key, item.Value);
	                    }

                        //if (e.RedirectValues["action"] != null && e.RedirectValues["controller"] != null && e.RedirectValues["area"] != null )
                        return RedirectToAction(e.RedirectValues["action"].ToString(), e.RedirectValues["controller"].ToString(), rv );


                        
                    }else if (e.Cancel && e.ActionResult != null )
                        return e.ActionResult;  
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				if (contextRequest == null || contextRequest.Company == null){
					contextRequest = GetContextRequest();
					
				}
                if (!cancel)
                	model.Bind(SDCaseHistoriesBR.Instance.Create(model.GetBusinessObject(), contextRequest ));
				OnCreated(this, e = new ControllerEventArgs<SDCaseHistoryModel>() { Item = model });
                 if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                        return ResolveApiResponse("success", null, null, null);

                    }
                }
				 
				 if (e != null )
					if (e.ActionResult != null)
                    	replaceResult = true;		
				if (!replaceResult)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))
                    {
                        ViewData["__continue"] = true;
                    }
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"]) &&  string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
                        popupextra.Add("id", model.SafeKey);
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                       {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                            popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"area"));
                            popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                            popupextra.Add("action", actionDetails);
                       if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
                    {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))

                        {
                            var popupextra = GetRouteData();
                            popupextra.Add("id", model.SafeKey);
                            return RedirectToAction("EditViewGen", popupextra);
                        }
                        else
                        {
                            return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.ADD_DONE));
                        }
                    }        			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                        return Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]);
                    else{

							RouteValueDictionary popupextra = null; 
							if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"])){
                            popupextra = GetRouteData();
							 string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
                            if (!string.IsNullOrEmpty(area))
                                popupextra.Add("area", area);
                            
                            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"])) {
								popupextra.Add("id", model.SafeKey);
                                return RedirectToAction("EditGen", popupextra);

                            }else{
								
                            return RedirectToAction("Index", popupextra);
							}
							}else{
								return Content("ok");
							}
                        }
						 }
                else {
                    return e.ActionResult;
                    }
				}
            catch(Exception ex)
            {
					  SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        throw ex;
                    }
                    else
                    {
                       // return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
					   return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
                SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                model.IsNew = true;
                var me = GetContextModel(UIModelContextTypes.EditForm, model, true, model.GuidCaseHistory);
                Showing(ref me);
                if (isPopUp)
                {
                    
                        ViewData["ispopup"] = isPopUp;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
					if (Request != null)
						return ResolveView(me, model);
					else
						return Content("ok");
            }
        }        
        //
        // GET: /SDCaseHistories/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }
			
		
		[MyAuthorize("u", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
		[MvcSiteMapNode(Area="SFSServiceDesk", Title="sss", Clickable=false, ParentKey = "SFSServiceDesk_SDCaseHistory_List")]
		public ActionResult EditGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDCaseHistoryResources.ENTITY_SINGLE;		 	
  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDCaseHistoryModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
            SDCaseHistoryModel model = null;
            // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
			bool dec = false;
            Guid ? idGuidDecripted = null ;
            if (Request != null && Request.QueryString["dec"] == "true")
            {
                dec = true;
                idGuidDecripted = Guid.Parse(id);
            }

            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model,dec,idGuidDecripted);
            Showing(ref me);


            if (!replaceResult)
            {
                 //return View("EditGen", me.Items[0]);
				 return ResolveView(me, me.Items[0]);
            }
            else {
                return e.ActionResult;
            }
        }
			[MyAuthorize("u", "SDCaseHistory","SFSServiceDesk", typeof(SDCaseHistoriesController))]
		public ActionResult EditViewGen(string id)
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

					  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDCaseHistoryModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
			
            SDCaseHistoryModel model = null;
			 bool dec = false;
            Guid? guidId = null ;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                dec = true;
                guidId = Guid.Parse(id);
            }
            // si fue implementado el método parcial y no se ha decidido suspender la acción
            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
            var me = GetContextModel(UIModelContextTypes.EditForm, model, dec, guidId);
            Showing(ref me);

            return ResolveView(me, model);
        }
		[MyAuthorize("u", "SDCaseHistory",  "SFSServiceDesk", typeof(SDCaseHistoriesController))]
		[HttpPost]
		[ValidateInput(false)] 
		        public ActionResult EditGen(SDCaseHistoryModel model)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
			e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDCaseHistoryModel>() { Item = model });
           
            if (!ModelState.IsValid)
            {
			   	var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
			
				if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"])){
                	ViewData["ispopup"] = true;
					return ResolveView(me, model);
				}
				else
					return ResolveView(me, model);
            }
            try
            {
			
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnEditing(this, e = new ControllerEventArgs<SDCaseHistoryModel>() { Item = model });
                if (e != null) {
                    if (e.Cancel && e.ActionResult != null)
                        return e.ActionResult;
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				ContextRequest context = new ContextRequest();
                context.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;

                SDCaseHistory resultObj = null;
			    if (!cancel)
                	resultObj = SDCaseHistoriesBR.Instance.Update(model.GetBusinessObject(), GetContextRequest());
				
				OnEdited(this, e = new ControllerEventArgs<SDCaseHistoryModel>() { Item =   new SDCaseHistoryModel(resultObj) });
				if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                         return ResolveApiResponse("success", null, null, null);
                    }
                }
				
				if (e != null && e.ActionResult != null) replaceResult = true; 

                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Content("ok");
                }
                else
                {
				if (!replaceResult)
                {
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"])  && string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
						 if (Request != null && Request.QueryString["dec"] == "true")
                        {
                            popupextra.Add("id", model.Id);
                        }
                        else
                        {
							popupextra.Add("id", model.SafeKey);

							
                        }
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                        {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                        popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area"));
                        popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                        popupextra.Add("action", actionDetails);
                        if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
					if (isPopUp)
						return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.UPDATE_DONE));
        			    string returnUrl = null;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"])) {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.Form["ReturnAfter"];
                        else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"];
                    }
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else{
		RouteValueDictionary popupextra = null; 
						 if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"]))
                            {
							
							popupextra = GetRouteData();
							string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
							if (!string.IsNullOrEmpty(area))
								popupextra.Add("area", area);

							return RedirectToAction("Index", popupextra);
						}else{
							return Content("ok");
						}
						}
				 }
                else {
                    return e.ActionResult;
				}
                }		
            }
          catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content(ex.ToString());
                    }
                    else
                    {
                        //return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
						 return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
			    if (isPopUp)
                {
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(ex.Message));
                    
                }
                else
                {
                    SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                    
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else {
						  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
							ViewData["ispopup"] = true;
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
							ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
							ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

						var me = GetContextModel(UIModelContextTypes.EditForm, model);
						Showing(ref me);

						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
						{
							ViewData["ispopup"] = true;
							return ResolveView(me, model);
						}
						else
							return ResolveView(me, model);

						
					}
				}
            }
        }
        //
        // POST: /SDCaseHistories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //  Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SDCaseHistories/Delete/5
        
		[MyAuthorize("d", "SDCaseHistory", "SFSServiceDesk", typeof(SDCaseHistoriesController))]
		[HttpDelete]
        public ActionResult DeleteGen(string objectKey, string extraParams)
        {
            try
            {
					
			
				Guid guidCaseHistory = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey.Replace("-", "/"), "GuidCaseHistory")); 
                BO.SDCaseHistory entity = new BO.SDCaseHistory() { GuidCaseHistory = guidCaseHistory };

                BR.SDCaseHistoriesBR.Instance.Delete(entity, GetContextRequest());               
                return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.DELETE_DONE));

            }
            catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null)
                    {
                        message = ex.Data["usermessage"].ToString();
                    }

                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }
            }
        }
		/*[MyAuthorize()]
		public FileMediaResult Download(string query, bool? allSelected = false,  string selected = null , string orderBy = null , string direction = null , string format = null , string actionKey=null )
        {
			
            List<Guid> keysSelected1 = new List<Guid>();
            if (!string.IsNullOrEmpty(selected)) {
                foreach (var keyString in selected.Split(char.Parse("|")))
                {
				
                    keysSelected1.Add(Guid.Parse(keyString));
                }
            }
				
            query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(query, allSelected.Value, selected, "GuidCaseHistory");
            MyEventArgs<ContextActionModel<SDCaseHistoryModel>> eArgs = null;
            List<SDCaseHistoryModel> results = GetBy(query, null, null, orderBy, direction, GetContextRequest(), keysSelected1);
            OnDownloading(this, eArgs = new MyEventArgs<ContextActionModel<SDCaseHistoryModel>>() { Object = new ContextActionModel<SDCaseHistoryModel>() { Query = query, SelectedItems = results, Selected=selected, SelectAll = allSelected.Value, Direction = direction , OrderBy = orderBy, ActionKey=actionKey  } });

            if (eArgs != null)
            {
                if (eArgs.Object.Result != null)
                    return (FileMediaResult)eArgs.Object.Result;
            }
            

            return (new FeaturesController()).ExportDownload(typeof(SDCaseHistoryModel), results, format, this.GetUIPluralText("SFSServiceDesk", "SDCaseHistory"));
            
        }
			*/
		
		[HttpPost]
        public ActionResult CustomActionExecute(ContextActionModel model) {
		 try
            {
			//List<Guid> keysSelected1 = new List<Guid>();
			List<object> keysSelected1 = new List<object>();
            if (!string.IsNullOrEmpty(model.Selected))
            {
                foreach (var keyString in model.Selected.Split(char.Parse(",")))
                {
				
				keysSelected1.Add(Guid.Parse(keyString.Split(char.Parse("|"))[0]));
                        
                    

			
                }
            }
			DataAction dataAction = DataAction.GetDataAction(Request);
			 model.Selected = dataAction.Selected;

            model.Query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(dataAction.Query, dataAction.AllSelected, dataAction.Selected, "GuidCaseHistory");
           
            
			
			#region implementaci�n de m�todo parcial
            bool replaceResult = false;
            MyEventArgs<ContextActionModel<SDCaseHistoryModel>> actionEventArgs = null;
           
			if (model.ActionKey != "deletemany" && model.ActionKey != "deleterelmany" && model.ActionKey != "updateRel" &&  model.ActionKey != "delete-relation-fk" && model.ActionKey != "restore" )
			{
				ContextRequest context = SFSdotNet.Framework.My.Context.BuildContextRequestSafe(System.Web.HttpContext.Current);
				context.UseMode = dataAction.Usemode;

				if (model.IsBackground)
				{
					System.Threading.Tasks.Task.Run(() => 
						OnCustomActionExecutingBackground(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDCaseHistoryModel>>() { Object = new ContextActionModel<SDCaseHistoryModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } })
					);
				}
				else
				{
					OnCustomActionExecuting(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDCaseHistoryModel>>() {  Object = new ContextActionModel<SDCaseHistoryModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } });
				}
			}
            List<SDCaseHistoryModel> results = null;
	
			if (model.ActionKey == "deletemany") { 
				
				BR.SDCaseHistoriesBR.Instance.Delete(model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());

            }
	
            else if (model.ActionKey == "updateRel" || model.ActionKey == "delete-relation-fk" || model.ActionKey == "updateRel-proxyMany")
            {
               try {
                   string valueForUpdate = null;
				   string propForUpdate = null;
				   if (!string.IsNullOrEmpty(Request.Params["propertyForUpdate"])){
						propForUpdate = Request.Params["propertyForUpdate"];
				   }
				    if (string.IsNullOrEmpty(propForUpdate) && !string.IsNullOrEmpty(Request.QueryString["propertyForUpdate"]))
                   {
                       propForUpdate = Request.QueryString["propertyForUpdate"];
                   }
                    if (model.ActionKey != "delete-relation-fk")
                    {
                        valueForUpdate = Request.QueryString["valueForUpdate"];
                    }
                    BR.SDCaseHistoriesBR.Instance.UpdateAssociation(propForUpdate, valueForUpdate, model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());
					
                    if (model.ActionKey == "delete-relation-fk")
                    {
                        MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]);

                        return PartialView("ResultMessageView", message);
                    }
                    else
                    {
                        return Content("ok");
                    }
       
          
                }
                catch (Exception ex)
                {
				        SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
           
                }
            
            }
		
                if (actionEventArgs == null && !model.IsBackground)
                {
                    //if (model.ActionKey != "deletemany"  && model.ActionKey != "deleterelmany")
                    //{
                     //   throw new NotImplementedException("");
                    //}
                }
                else
                {
					if (model.IsBackground == false )
						 replaceResult = actionEventArgs.Object.Result is ActionResult /*actionEventArgs.Object.ReplaceResult*/;
                }
                #endregion
                if (!replaceResult)
                {
                    if (Request != null && Request.IsAjaxRequest())
                    {
						MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]) ;
                        if (model.IsBackground )
                            message.Message = GlobalMessages.THE_PROCESS_HAS_BEEN_STARTED;
                        
                        return PartialView("ResultMessageView", message);                    
					}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return (ActionResult)actionEventArgs.Object.Result;
                }
            }
            catch (Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null) {
                        message = ex.Data["usermessage"].ToString();
                    }
					 SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }

            }
        }
        //
        // POST: /SDCaseHistories/Delete/5
        
			
	
    }
}
namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
	using SFS.ServiceDesk.Web.Mvc.Models.SDCaseHistoryFiles;

    public partial class SDCaseHistoryFilesController : SFS.ServiceDesk.Web.Mvc.ControllerBase<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel>
    {

       


	#region partial methods
        ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e = null;
        partial void OnValidating(object sender, ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e);
        partial void OnGettingExtraData(object sender, MyEventArgs<UIModel<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel>> e);
        partial void OnCreating(object sender, ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e);
        partial void OnCreated(object sender, ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e);
        partial void OnEditing(object sender, ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e);
        partial void OnEdited(object sender, ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e);
        partial void OnDeleting(object sender, ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e);
        partial void OnDeleted(object sender, ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e);
    	partial void OnShowing(object sender, MyEventArgs<UIModel<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel>> e);
    	partial void OnGettingByKey(object sender, ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e);
        partial void OnTaken(object sender, ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e);
       	partial void OnCreateShowing(object sender, ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e);
		partial void OnEditShowing(object sender, ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e);
		partial void OnDetailsShowing(object sender, ControllerEventArgs<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel> e);
 		partial void OnActionsCreated(object sender, MyEventArgs<UIModel<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel >> e);
		partial void OnCustomActionExecuting(object sender, MyEventArgs<ContextActionModel<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel>> e);
		partial void OnCustomActionExecutingBackground(object sender, MyEventArgs<ContextActionModel<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel>> e);
        partial void OnDownloading(object sender, MyEventArgs<ContextActionModel<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel>> e);
      	partial void OnAuthorization(object sender, AuthorizationContext context);
		 partial void OnFilterShowing(object sender, MyEventArgs<UIModel<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel >> e);
         partial void OnSummaryOperationShowing(object sender, MyEventArgs<UIModel<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel>> e);

        partial void OnExportActionsCreated(object sender, MyEventArgs<UIModel<Models.SDCaseHistoryFiles.SDCaseHistoryFileModel>> e);


		protected override void OnVirtualFilterShowing(object sender, MyEventArgs<UIModel<SDCaseHistoryFileModel>> e)
        {
            OnFilterShowing(sender, e);
        }
		 public override void OnVirtualExportActionsCreated(object sender, MyEventArgs<UIModel<SDCaseHistoryFileModel>> e)
        {
            OnExportActionsCreated(sender, e);
        }
        public override void OnVirtualDownloading(object sender, MyEventArgs<ContextActionModel<SDCaseHistoryFileModel>> e)
        {
            OnDownloading(sender, e);
        }
        public override void OnVirtualShowing(object sender, MyEventArgs<UIModel<SDCaseHistoryFileModel>> e)
        {
            OnShowing(sender, e);
        }

	#endregion
	#region API
	 public override ActionResult ApiCreateGen(SDCaseHistoryFileModel model, ContextRequest contextRequest)
        {
            return CreateGen(model, contextRequest);
        }

              public override ActionResult ApiGetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJson(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }
        public override ActionResult ApiGetByKeyJson(string id, ContextRequest contextRequest)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
            return  GetByKeyJson(id, contextRequest, true);
        }
      
		 public override ActionResult ApiGetByCount(string filter, ContextRequest contextRequest)
        {
            return GetByCount(filter, contextRequest);
        }
         protected override ActionResult ApiDeleteGen(List<SDCaseHistoryFileModel> models, ContextRequest contextRequest)
        {
            List<SDCaseHistoryFile> objs = new List<SDCaseHistoryFile>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                BR.SDCaseHistoryFilesBR.Instance.DeleteBulk(objs, contextRequest);
                if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("success", null, null, null);

                }
                else
                {
                    return Content("ok");

                }
            }
            catch (Exception ex)
            {
               if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "error", reason = "error", message= ex.ToString() }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("error", "exception", ex.ToString(), null );

                }
                else
                {
                    return Json(ex.ToString(), JsonRequestBehavior.AllowGet);

                }
            }
        }
        protected override ActionResult ApiUpdateGen(List<SDCaseHistoryFileModel> models, ContextRequest contextRequest)
        {
            List<SDCaseHistoryFile> objs = new List<SDCaseHistoryFile>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                foreach (var obj in objs)
                {
                    BR.SDCaseHistoryFilesBR.Instance.Update(obj, contextRequest);

                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }


	#endregion
#region Validation methods	
	    private void Validations(SDCaseHistoryFileModel model) { 
            #region Remote validations

            #endregion
		}

#endregion
		
 		public AuthorizationContext Authorization(AuthorizationContext context)
        {
            OnAuthorization(this,  context );
            return context ;
        }
		public List<SDCaseHistoryFileModel> GetAll() {
            			var bos = BR.SDCaseHistoryFilesBR.Instance.GetBy("",
					new SFSdotNet.Framework.My.ContextRequest()
					{
						CustomQuery = new SFSdotNet.Framework.My.CustomQuery()
						{
							OrderBy = "GuidCasehistoryFile",
							SortDirection = SFSdotNet.Framework.Data.SortDirection.Ascending
						}
					});
            			List<SDCaseHistoryFileModel> results = new List<SDCaseHistoryFileModel>();
            SDCaseHistoryFileModel model = null;
            foreach (var bo in bos)
            {
                model = new SDCaseHistoryFileModel();
                model.Bind(bo);
                results.Add(model);
            }
            return results;

        }
        //
        // GET: /SDCaseHistoryFiles/
		[MyAuthorize("r", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
		public ActionResult Index()
        {
    		var uiModel = GetContextModel(UIModelContextTypes.ListForm, null);
			ViewBag.UIModel = uiModel;
			uiModel.FilterStart = (string)ViewData["startFilter"];
                    MyEventArgs<UIModel<SDCaseHistoryFileModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseHistoryFileModel>>() { Object = uiModel });

			OnExportActionsCreated(this, (me != null ? me : me = new MyEventArgs<UIModel<SDCaseHistoryFileModel>>() { Object = uiModel }));

            if (me != null)
            {
                uiModel = me.Object;
            }
            if (me == null)
                me = new MyEventArgs<UIModel<SDCaseHistoryFileModel>>() { Object = uiModel };
           
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;


            //return View("ListGen");
			return ResolveView(uiModel);
        }
		[MyAuthorize("r", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
		public ActionResult ListViewGen(string idTab, string fk , string fkValue, string startFilter, ListModes  listmode  = ListModes.SimpleList, PropertyDefinition parentRelationProperty = null, object parentRelationPropertyValue = null )
        {
			ViewData["idTab"] = System.Web.HttpContext.Current.Request.QueryString["idTab"]; 
		 	ViewData["detpop"] = true; // details in popup
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"])) {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"]; 
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
            {
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["startFilter"]))
            {
                ViewData["startFilter"] = Request.QueryString["startFilter"];
            }
			
			UIModel<SDCaseHistoryFileModel> uiModel = GetContextModel(UIModelContextTypes.ListForm, null);

            MyEventArgs<UIModel<SDCaseHistoryFileModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseHistoryFileModel>>() { Object = uiModel });
            if (me == null)
                me = new MyEventArgs<UIModel<SDCaseHistoryFileModel>>() { Object = uiModel };
            uiModel.Properties = GetProperties(uiModel);
            uiModel.ContextType = UIModelContextTypes.ListForm;
             uiModel.FilterStart = (string)ViewData["startFilter"];
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;
			 if (listmode == ListModes.SimpleList)
                return ResolveView(uiModel);
            else
            {
                ViewData["parentRelationProperty"] = parentRelationProperty;
                ViewData["parentRelationPropertyValue"] = parentRelationPropertyValue;
                return PartialView("ListForTagSelectView");
            }
            return ResolveView(uiModel);
        }
		List<PropertyDefinition> _properties = null;

		 protected override List<PropertyDefinition> GetProperties(UIModel uiModel,  params string[] specificProperties)
        { 
            return GetProperties(uiModel, false, null, specificProperties);
        }

		protected override List<PropertyDefinition> GetProperties(UIModel uiModel, bool decripted, Guid? id, params string[] specificProperties)
            {

			bool allProperties = true;    
                if (specificProperties != null && specificProperties.Length > 0)
                {
                    allProperties = false;
                }


			List<CustomProperty> customProperties = new List<CustomProperty>();
			if (_properties == null)
                {
                List<PropertyDefinition> results = new List<PropertyDefinition>();

			string idSDCaseHistoryFile = GetRouteDataOrQueryParam("id");
			if (idSDCaseHistoryFile != null)
			{
				if (!decripted)
                {
					idSDCaseHistoryFile = SFSdotNet.Framework.Entities.Utils.GetPropertyKey(idSDCaseHistoryFile.Replace("-","/"), "GuidCasehistoryFile");
				}else{
					if (id != null )
						idSDCaseHistoryFile = id.Value.ToString();                

				}
			}

			bool visibleProperty = true;	
			 bool conditionalshow =false;
                if (uiModel.ContextType == UIModelContextTypes.EditForm || uiModel.ContextType == UIModelContextTypes.DisplayForm ||  uiModel.ContextType == UIModelContextTypes.GenericForm )
                    conditionalshow = true;
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidCasehistoryFile"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidCasehistoryFile")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 100,
																	
					CustomProperties = customProperties,

                    PropertyName = "GuidCasehistoryFile",

					 MaxLength = 0,
					IsRequired = true ,
					IsHidden = true,
                    SystemProperty =  SystemProperties.Identifier ,
					IsDefaultProperty = true,
                    SortBy = "GuidCasehistoryFile",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryFileResources.GUIDCASEHISTORYFILE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidFile"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidFile")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 101,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidFile",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "GuidFile",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryFileResources.GUIDFILE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidCaseHistory"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidCaseHistory")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 102,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidCaseHistory",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "GuidCaseHistory",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryFileResources.GUIDCASEHISTORY*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCaseHistory"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCaseHistoryFiles" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCaseHistory.GuidCaseHistory")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCaseHistory.GuidCaseHistory" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCaseHistories" });
			

	
	//fk_SdCaseHistoryFile_SdCaseHistory
		//if (this.Request.QueryString["fk"] != "SDCaseHistory")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 103,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCaseHistory",
					PropertyNavigationKey = "GuidCaseHistory",
					PropertyNavigationText = "BodyContent",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="BodyContent",
					GetMethodDisplayValue = "GuidCaseHistory",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCaseHistory",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDCaseHistory.BodyContent",
					
	
                    TypeName = "SFSServiceDeskModel.SDCaseHistory",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDCaseHistories"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryFileResources.SDCASEHISTORY*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDFile"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCaseHistoryFiles" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDFile.GuidFile")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDFile.GuidFile" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDFiles" });
			

	
	//fk_SdCaseHistoryFile_SdFile
		//if (this.Request.QueryString["fk"] != "SDFile")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 104,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDFile",
					PropertyNavigationKey = "GuidFile",
					PropertyNavigationText = "FileName",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="FileName",
					GetMethodDisplayValue = "GuidFile",
					
					CustomProperties = customProperties,

                    PropertyName = "SDFile",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDFile.FileName",
					
	
                    TypeName = "SFSServiceDeskModel.SDFile",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDFiles"
                    /*,PropertyDisplayName = Resources.SDCaseHistoryFileResources.SDFILE*/
                });
		//	}
	
	}
	
				
                    _properties = results;
                    return _properties;
                }
                else {
                    return _properties;
                }
            }

		protected override  UIModel<SDCaseHistoryFileModel> GetByForShow(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, params  object[] extraParams)
        {
			if (Request != null )
				if (!string.IsNullOrEmpty(Request.QueryString["q"]))
					filter = filter + HttpUtility.UrlDecode(Request.QueryString["q"]);
 if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
            }
            var bos = BR.SDCaseHistoryFilesBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), contextRequest, extraParams);
			//var bos = BR.SDCaseHistoryFilesBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), context, extraParams);
            SDCaseHistoryFileModel model = null;
            List<SDCaseHistoryFileModel> results = new List<SDCaseHistoryFileModel>();
            foreach (var item in bos)
            {
                model = new SDCaseHistoryFileModel();
				model.Bind(item);
				results.Add(model);
            }
            //return results;
			UIModel<SDCaseHistoryFileModel> uiModel = GetContextModel(UIModelContextTypes.Items, null);
            uiModel.Items = results;
			if (Request != null){
				if (SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(Request.RequestContext, "action") == "Download")
				{
					uiModel.ContextType = UIModelContextTypes.ExportDownload;
				}
			}
            Showing(ref uiModel);
            return uiModel;
		}			
		
		//public List<SDCaseHistoryFileModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params  object[] extraParams)
        //{
		//	var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, null, extraParams);
        public override List<SDCaseHistoryFileModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest,  params  object[] extraParams)
        {
            var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
           
            return uiModel.Items;
		
        }
		/*
        [MyAuthorize("r", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir)
        {
			 return GetByJsonBase(filter, pageSize, page, orderBy, orderDir);
        }*/

		  [MyAuthorize("r", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir,ContextRequest contextRequest,  object[] extraParams)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
			 
			 if (this.IsRESTRequest == false)
            {
                return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
            }else
            {
                try
                {
                    return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);

                }
            }
        }
/*		  [MyAuthorize("r", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
       public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }*/
		[MyAuthorize()]
		public ActionResult GetByCount(string filter, ContextRequest contextRequest) {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
           
			
             if (this.IsRESTRequest == true)
            {
                try
                {

                    var result = BR.SDCaseHistoryFilesBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);

                   if (Request.QueryString["v"] == "2")
                    {
						return ResolveApiResponse("success", null, null, result);

                        //return Json(new { status = "success", data = result }, JsonRequestBehavior.AllowGet);
                    }else
                    {
                        return Content(result.ToString());

                    }
                }
                catch (Exception ex)
                {
                  //  return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
				  return ResolveApiResponse("error", "exception", ex.ToString(), null);

                }
            }
            else
            {
                var result = BR.SDCaseHistoryFilesBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);
                return Content(result.ToString());
            }
		}
		

		[MyAuthorize("r", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
        public ActionResult GetByKeyJson(string id, ContextRequest contextRequest,  bool dec = false)
        {
            return Json(GetByKey(id, null, contextRequest, dec), JsonRequestBehavior.AllowGet);
        }
		public SDCaseHistoryFileModel GetByKey(string id) {
			return GetByKey(id, null,null, false);
       	}
		    public SDCaseHistoryFileModel GetByKey(string id, string includes)
        {
            return GetByKey(id, includes, false);
        }
		 public  SDCaseHistoryFileModel GetByKey(string id, string includes, ContextRequest contextRequest)
        {
            return GetByKey(id, includes, contextRequest, false);
        }
		/*
		  public ActionResult ShowField(string fieldName, string idField) {
		   string safePropertyName = fieldName;
              if (fieldName.StartsWith("Fk"))
              {
                  safePropertyName = fieldName.Substring(2, fieldName.Length - 2);
              }

             SDCaseHistoryFileModel model = new  SDCaseHistoryFileModel();

            UIModel uiModel = GetUIModel(model, new string[] { "NoField-" });
			
				uiModel.Properties = GetProperties(uiModel, safePropertyName);
		uiModel.Properties.ForEach(p=> p.ContextType = uiModel.ContextType );
            uiModel.ContextType = UIModelContextTypes.FilterFields;
            uiModel.OverrideApp = GetOverrideApp();
            uiModel.UseMode = GetUseMode();

            ViewData["uiModel"] = uiModel;
			var prop = uiModel.Properties.FirstOrDefault(p=>p.PropertyName == safePropertyName);
            //if (prop.IsNavigationProperty && prop.IsNavigationPropertyMany == false)
            //{
            //    ViewData["currentProperty"] = uiModel.Properties.FirstOrDefault(p => p.PropertyName != fieldName + "Text");
            //}else if (prop.IsNavigationProperty == false){
                ViewData["currentProperty"] = prop;
           // }
            ((PropertyDefinition)ViewData["currentProperty"]).RemoveLayout = true;
			ViewData["withContainer"] = false;


            return PartialView("GenericField", model);


        }
      */
	public SDCaseHistoryFileModel GetByKey(string id, ContextRequest contextRequest, bool dec)
        {
            return GetByKey(id, null, contextRequest, dec);
        }
        public SDCaseHistoryFileModel GetByKey(string id, string  includes, bool dec)
        {
            return GetByKey(id, includes, null, dec);
        }

        public SDCaseHistoryFileModel GetByKey(string id, string includes, ContextRequest contextRequest, bool dec) {
		             SDCaseHistoryFileModel model = null;
            ControllerEventArgs<SDCaseHistoryFileModel> e = null;
			string objectKey = id.Replace("-","/");
             OnGettingByKey(this, e=  new ControllerEventArgs<SDCaseHistoryFileModel>() { Id = objectKey  });
             bool cancel = false;
             SDCaseHistoryFileModel eItem = null;
             if (e != null)
             {
                 cancel = e.Cancel;
                 eItem = e.Item;
             }
			if (cancel == false && eItem == null)
             {
			Guid guidCasehistoryFile = Guid.Empty; //new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, "GuidCasehistoryFile"));
			if (dec)
                 {
                     guidCasehistoryFile = new Guid(id);
                 }
                 else
                 {
                     guidCasehistoryFile = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, null));
                 }
			
            
				model = new SDCaseHistoryFileModel();
                  if (contextRequest == null)
                {
                    contextRequest = GetContextRequest();
                }
				var bo = BR.SDCaseHistoryFilesBR.Instance.GetByKey(guidCasehistoryFile, GetUseMode(), contextRequest,  includes);
				 if (bo != null)
                    model.Bind(bo);
                else
                    return null;
			}
             else {
                 model = eItem;
             }
			model.IsNew = false;

            return model;
        }
        // GET: /SDCaseHistoryFiles/DetailsGen/5
		[MyAuthorize("r", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
        public ActionResult DetailsGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDCaseHistoryFileResources.ENTITY_PLURAL;
			 #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDCaseHistoryFileModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
            #endregion



			 bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
			//UIModel<SDCaseHistoryFileModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, decripted), decripted, guidId);
			var item = GetByKey(id, null, null, decripted);
			if (item == null)
            {
                 RouteValueDictionary rv = new RouteValueDictionary();
                string usemode = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"usemode");
                string overrideModule = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "overrideModule");
                string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");

                if(!string.IsNullOrEmpty(usemode)){
                    rv.Add("usemode", usemode);
                }
                if(!string.IsNullOrEmpty(overrideModule)){
                    rv.Add("overrideModule", overrideModule);
                }
                if (!string.IsNullOrEmpty(area))
                {
                    rv.Add("area", area);
                }

                return RedirectToAction("Index", rv);
            }
            //
            UIModel<SDCaseHistoryFileModel> uiModel = null;
                uiModel = GetContextModel(UIModelContextTypes.DisplayForm, item, decripted, guidId);



            MyEventArgs<UIModel<SDCaseHistoryFileModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseHistoryFileModel>>() { Object = uiModel });

            if (me != null) {
                uiModel = me.Object;
            }
			
            Showing(ref uiModel);
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			
            //return View("DisplayGen", uiModel.Items[0]);
			return ResolveView(uiModel, uiModel.Items[0]);

        }
		[MyAuthorize("r", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
		public ActionResult DetailsViewGen(string id)
        {

		 bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDCaseHistoryFileModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
           
			if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
 			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
           
        	 //var uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id));
			 
            bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true")
                {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
            UIModel<SDCaseHistoryFileModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, null, decripted), decripted, guidId);
			

            MyEventArgs<UIModel<SDCaseHistoryFileModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseHistoryFileModel>>() { Object = uiModel });

            if (me != null)
            {
                uiModel = me.Object;
            }
            
            Showing(ref uiModel);
            return ResolveView(uiModel, uiModel.Items[0]);
        
        }
        //
        // GET: /SDCaseHistoryFiles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /SDCaseHistoryFiles/CreateGen
		[MyAuthorize("c", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
        public ActionResult CreateGen()
        {
			SDCaseHistoryFileModel model = new SDCaseHistoryFileModel();
            model.IsNew = true;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model);

			OnCreateShowing(this, e = new ControllerEventArgs<SDCaseHistoryFileModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }

             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                 ViewData["ispopup"] = true;
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                 ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                 ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

            Showing(ref me);

			return ResolveView(me, me.Items[0]);
        } 
			
		protected override UIModel<SDCaseHistoryFileModel> GetContextModel(UIModelContextTypes formMode, SDCaseHistoryFileModel model)
        {
            return GetContextModel(formMode, model, false, null);
        }
			
		 private UIModel<SDCaseHistoryFileModel> GetContextModel(UIModelContextTypes formMode, SDCaseHistoryFileModel model, bool decript, Guid ? id) {
            UIModel<SDCaseHistoryFileModel> me = new UIModel<SDCaseHistoryFileModel>(true, "SDCaseHistoryFiles");
			me.UseMode = GetUseMode();
			me.Controller = this;
			me.OverrideApp = GetOverrideApp();
			me.ContextType = formMode ;
			me.Id = "SDCaseHistoryFile";
			
            me.ModuleKey = "SFSServiceDesk";

			me.ModuleNamespace = "SFS.ServiceDesk";
            me.EntityKey = "SDCaseHistoryFile";
            me.EntitySetName = "SDCaseHistoryFiles";

			me.AreaAction = "SFSServiceDesk";
            me.ControllerAction = "SDCaseHistoryFiles";
            me.PropertyKeyName = "GuidCasehistoryFile";

            me.Properties = GetProperties(me, decript, id);
 			
			if (Request != null)
            {
                string actionName = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam( Request.RequestContext, "action");
                if(actionName != null && actionName.ToLower().Contains("create") ){
                    me.IsNew = true;
                }
            }
			 #region Buttons
			 if (Request != null ){
             if (formMode == UIModelContextTypes.DisplayForm || formMode == UIModelContextTypes.EditForm || formMode == UIModelContextTypes.ListForm)
				me.ActionButtons = GetActionButtons(formMode,model != null ?(Request.QueryString["dec"] == "true" ? model.Id : model.SafeKey)  : null, "SFSServiceDesk", "SDCaseHistoryFiles", "SDCaseHistoryFile", me.IsNew);

            //me.ActionButtons.Add(new ActionModel() { ActionKey = "return", Title = GlobalMessages.RETURN, Url = System.Web.VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCaseHistoryFiles" });
			if (this.HttpContext != null &&  !this.HttpContext.SkipAuthorization){
				//antes this.HttpContext
				me.SetAction("u", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("u", "SDCaseHistoryFile", "SFSServiceDesk"));
				me.SetAction("c", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("c", "SDCaseHistoryFile", "SFSServiceDesk"));
				me.SetAction("d", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("d", "SDCaseHistoryFile", "SFSServiceDesk"));
			
			}else{
				me.SetAction("u", true);
				me.SetAction("c", true);
				me.SetAction("d", true);

			}
            #endregion              
         
            switch (formMode)
            {
                case UIModelContextTypes.DisplayForm:
					//me.TitleForm = SDCaseHistoryFileResources.SDCASEHISTORYFILES_DETAILS;
                    me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.MODIFY_DATA;
					 me.Properties.Where(p=>p.PropertyName  != "Id" && p.IsForeignKey == false).ToList().ForEach(p => p.IsHidden = false);

					 me.Properties.Where(p => (p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier) ).ToList().ForEach(p=> me.SetHide(p.PropertyName));

                    break;
                case UIModelContextTypes.EditForm:
				  me.Properties.Where(p=>p.SystemProperty != SystemProperties.Identifier && p.IsForeignKey == false && p.PropertyName != "Id").ToList().ForEach(p => p.IsHidden = false);

					if (model != null)
                    {
						

                        me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.SAVE_DATA;                        
                        me.ActionButtons.First(p => p.ActionKey == "c").Title = GlobalMessages.SAVE_DATA;
						if (model.IsNew ){
							//me.TitleForm = SDCaseHistoryFileResources.SDCASEHISTORYFILES_ADD_NEW;
							me.ActionName = "CreateGen";
							me.Properties.RemoveAll(p => p.SystemProperty != null || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));
						}else{
							
							me.ActionName = "EditGen";

							//me.TitleForm = SDCaseHistoryFileResources.SDCASEHISTORYFILES_EDIT;
							me.Properties.RemoveAll(p => p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));	
						}
						//me.Properties.Remove(me.Properties.Find(p => p.PropertyName == "UpdatedDate"));
					
					}
                    break;
                case UIModelContextTypes.FilterFields:
                    break;
                case UIModelContextTypes.GenericForm:
                    break;
                case UIModelContextTypes.Items:
				//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "GuidCasehistoryFile") != null){
						me.Properties.Find(p => p.PropertyName == "GuidCasehistoryFile").IsHidden = false;
					 }
					 
                    
					

						 if (me.Properties.Find(p => p.PropertyName == "GuidCasehistoryFile") != null){
						me.Properties.Find(p => p.PropertyName == "GuidCasehistoryFile").IsHidden = false;
					 }
					 
                    
					


                  


					//}
                    break;
                case UIModelContextTypes.ListForm:
					PropertyDefinition propFinded = null;
					//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "GuidCasehistoryFile") != null){
						me.Properties.Find(p => p.PropertyName == "GuidCasehistoryFile").IsHidden = false;
					 }
					
					me.PrincipalActionName = "GetByJson";
					//}
					//me.TitleForm = SDCaseHistoryFileResources.SDCASEHISTORYFILES_LIST;
                    break;
                default:
                    break;
            }
            	this.SetDefaultProperties(me);
			}
			if (model != null )
            	me.Items.Add(model);
            return me;
        }
		// GET: /SDCaseHistoryFiles/CreateViewGen
		[MyAuthorize("c", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
        public ActionResult CreateViewGen()
        {
				SDCaseHistoryFileModel model = new SDCaseHistoryFileModel();
            model.IsNew = true;
			e= null;
			OnCreateShowing(this, e = new ControllerEventArgs<SDCaseHistoryFileModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }
			
            var me = GetContextModel(UIModelContextTypes.EditForm, model);

			me.IsPartialView = true;	
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
            {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                me.Properties.Find(p => p.PropertyName == ViewData["fk"].ToString()).IsReadOnly = true;
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
			
      
            //me.Items.Add(model);
            Showing(ref me);
            return ResolveView(me, me.Items[0]);
        }
		protected override  void GettingExtraData(ref UIModel<SDCaseHistoryFileModel> uiModel)
        {

            MyEventArgs<UIModel<SDCaseHistoryFileModel>> me = null;
            OnGettingExtraData(this, me = new MyEventArgs<UIModel<SDCaseHistoryFileModel>>() { Object = uiModel });
            //bool maybeAnyReplaced = false; 
            if (me != null)
            {
                uiModel = me.Object;
                //maybeAnyReplaced = true;
            }
           
			bool canFill = false;
			 string query = null ;
            bool isFK = false;
			PropertyDefinition prop =null;
			var contextRequest = this.GetContextRequest();
            contextRequest.CustomParams.Add(new CustomParam() { Name="ui", Value= SDCaseHistoryFile.EntityName });

            			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDCaseHistory");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidCaseHistory = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidCaseHistory = @GuidCaseHistory";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidCaseHistory = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidCaseHistory = @GuidCaseHistory";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDCaseHistory")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidCaseHistory", new Nullable<Guid>(Guid.Parse( Request.QueryString["fkValue"])));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDCaseHistoriesBR()).GetBy(query, contextRequest), "GuidCaseHistory", "BodyContent", Request.QueryString["fkValue"]), PropertyName = "SDCaseHistory" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDCaseHistoriesBR()).GetBy(query, contextRequest), "GuidCaseHistory", "BodyContent"), PropertyName = "SDCaseHistory" });    

					}
    if (isFK)
                    {    
						var FkSDCaseHistory = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDCaseHistory").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDCaseHistoryText").SetValue(uiModel.Items[0], FkSDCaseHistory.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDCaseHistory").SetValue(uiModel.Items[0], Guid.Parse(FkSDCaseHistory.Value));
                    
					}    
				}
			}
		 
			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDFile");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidFile = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidFile = @GuidFile";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidFile = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidFile = @GuidFile";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDFile")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidFile", new Nullable<Guid>(Guid.Parse( Request.QueryString["fkValue"])));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDFilesBR()).GetBy(query, contextRequest), "GuidFile", "FileName", Request.QueryString["fkValue"]), PropertyName = "SDFile" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDFilesBR()).GetBy(query, contextRequest), "GuidFile", "FileName"), PropertyName = "SDFile" });    

					}
    if (isFK)
                    {    
						var FkSDFile = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDFile").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDFileText").SetValue(uiModel.Items[0], FkSDFile.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDFile").SetValue(uiModel.Items[0], Guid.Parse(FkSDFile.Value));
                    
					}    
				}
			}
		 
            

        }
		private void Showing(ref UIModel<SDCaseHistoryFileModel> uiModel) {
          	
			MyEventArgs<UIModel<SDCaseHistoryFileModel>> me = new MyEventArgs<UIModel<SDCaseHistoryFileModel>>() { Object = uiModel };
			 OnVirtualLayoutSettings(this, me);


            OnShowing(this, me);

			
			if ((Request != null && Request.QueryString["allFields"] == "1") || Request == null )
			{
				me.Object.Properties.ForEach(p=> p.IsHidden = false);
            }
            if (me != null)
            {
                uiModel = me.Object;
            }
          


			 if (uiModel.ContextType == UIModelContextTypes.EditForm)
			    GettingExtraData(ref uiModel);
            ViewData["UIModel"] = uiModel;

        }
        //
        // POST: /SDCaseHistoryFiles/Create
		[MyAuthorize("c", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
        [HttpPost]
		[ValidateInput(false)] 
        public ActionResult CreateGen(SDCaseHistoryFileModel  model,  ContextRequest contextRequest)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
		 	e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDCaseHistoryFileModel>() { Item = model });
           
		  	if (!ModelState.IsValid) {
				model.IsNew = true;
				var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
                 if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                        ViewData["ispopup"] = true;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
                    return ResolveView(me, model);
            }
            try
            {
				if (model.GuidCasehistoryFile == null || model.GuidCasehistoryFile.ToString().Contains("000000000"))
				model.GuidCasehistoryFile = Guid.NewGuid();
	
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnCreating(this, e = new ControllerEventArgs<SDCaseHistoryFileModel>() { Item = model });
                if (e != null) {
                   if (e.Cancel && e.RedirectValues.Count > 0){
                        RouteValueDictionary rv = new RouteValueDictionary();
                        if (e.RedirectValues["area"] != null ){
                            rv.Add("area", e.RedirectValues["area"].ToString());
                        }
                        foreach (var item in e.RedirectValues.Where(p=>p.Key != "area" && p.Key != "controller" &&  p.Key != "action" ))
	                    {
		                    rv.Add(item.Key, item.Value);
	                    }

                        //if (e.RedirectValues["action"] != null && e.RedirectValues["controller"] != null && e.RedirectValues["area"] != null )
                        return RedirectToAction(e.RedirectValues["action"].ToString(), e.RedirectValues["controller"].ToString(), rv );


                        
                    }else if (e.Cancel && e.ActionResult != null )
                        return e.ActionResult;  
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				if (contextRequest == null || contextRequest.Company == null){
					contextRequest = GetContextRequest();
					
				}
                if (!cancel)
                	model.Bind(SDCaseHistoryFilesBR.Instance.Create(model.GetBusinessObject(), contextRequest ));
				OnCreated(this, e = new ControllerEventArgs<SDCaseHistoryFileModel>() { Item = model });
                 if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                        return ResolveApiResponse("success", null, null, null);

                    }
                }
				 
				 if (e != null )
					if (e.ActionResult != null)
                    	replaceResult = true;		
				if (!replaceResult)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))
                    {
                        ViewData["__continue"] = true;
                    }
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"]) &&  string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
                        popupextra.Add("id", model.SafeKey);
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                       {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                            popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"area"));
                            popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                            popupextra.Add("action", actionDetails);
                       if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
                    {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))

                        {
                            var popupextra = GetRouteData();
                            popupextra.Add("id", model.SafeKey);
                            return RedirectToAction("EditViewGen", popupextra);
                        }
                        else
                        {
                            return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.ADD_DONE));
                        }
                    }        			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                        return Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]);
                    else{

							RouteValueDictionary popupextra = null; 
							if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"])){
                            popupextra = GetRouteData();
							 string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
                            if (!string.IsNullOrEmpty(area))
                                popupextra.Add("area", area);
                            
                            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"])) {
								popupextra.Add("id", model.SafeKey);
                                return RedirectToAction("EditGen", popupextra);

                            }else{
								
                            return RedirectToAction("Index", popupextra);
							}
							}else{
								return Content("ok");
							}
                        }
						 }
                else {
                    return e.ActionResult;
                    }
				}
            catch(Exception ex)
            {
					  SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        throw ex;
                    }
                    else
                    {
                       // return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
					   return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
                SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                model.IsNew = true;
                var me = GetContextModel(UIModelContextTypes.EditForm, model, true, model.GuidCasehistoryFile);
                Showing(ref me);
                if (isPopUp)
                {
                    
                        ViewData["ispopup"] = isPopUp;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
					if (Request != null)
						return ResolveView(me, model);
					else
						return Content("ok");
            }
        }        
        //
        // GET: /SDCaseHistoryFiles/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }
			
		
		[MyAuthorize("u", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
		[MvcSiteMapNode(Area="SFSServiceDesk", Title="sss", Clickable=false, ParentKey = "SFSServiceDesk_SDCaseHistoryFile_List")]
		public ActionResult EditGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDCaseHistoryFileResources.ENTITY_SINGLE;		 	
  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDCaseHistoryFileModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
            SDCaseHistoryFileModel model = null;
            // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
			bool dec = false;
            Guid ? idGuidDecripted = null ;
            if (Request != null && Request.QueryString["dec"] == "true")
            {
                dec = true;
                idGuidDecripted = Guid.Parse(id);
            }

            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model,dec,idGuidDecripted);
            Showing(ref me);


            if (!replaceResult)
            {
                 //return View("EditGen", me.Items[0]);
				 return ResolveView(me, me.Items[0]);
            }
            else {
                return e.ActionResult;
            }
        }
			[MyAuthorize("u", "SDCaseHistoryFile","SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
		public ActionResult EditViewGen(string id)
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

					  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDCaseHistoryFileModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
			
            SDCaseHistoryFileModel model = null;
			 bool dec = false;
            Guid? guidId = null ;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                dec = true;
                guidId = Guid.Parse(id);
            }
            // si fue implementado el método parcial y no se ha decidido suspender la acción
            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
            var me = GetContextModel(UIModelContextTypes.EditForm, model, dec, guidId);
            Showing(ref me);

            return ResolveView(me, model);
        }
		[MyAuthorize("u", "SDCaseHistoryFile",  "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
		[HttpPost]
		[ValidateInput(false)] 
		        public ActionResult EditGen(SDCaseHistoryFileModel model)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
			e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDCaseHistoryFileModel>() { Item = model });
           
            if (!ModelState.IsValid)
            {
			   	var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
			
				if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"])){
                	ViewData["ispopup"] = true;
					return ResolveView(me, model);
				}
				else
					return ResolveView(me, model);
            }
            try
            {
			
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnEditing(this, e = new ControllerEventArgs<SDCaseHistoryFileModel>() { Item = model });
                if (e != null) {
                    if (e.Cancel && e.ActionResult != null)
                        return e.ActionResult;
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				ContextRequest context = new ContextRequest();
                context.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;

                SDCaseHistoryFile resultObj = null;
			    if (!cancel)
                	resultObj = SDCaseHistoryFilesBR.Instance.Update(model.GetBusinessObject(), GetContextRequest());
				
				OnEdited(this, e = new ControllerEventArgs<SDCaseHistoryFileModel>() { Item =   new SDCaseHistoryFileModel(resultObj) });
				if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                         return ResolveApiResponse("success", null, null, null);
                    }
                }
				
				if (e != null && e.ActionResult != null) replaceResult = true; 

                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Content("ok");
                }
                else
                {
				if (!replaceResult)
                {
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"])  && string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
						 if (Request != null && Request.QueryString["dec"] == "true")
                        {
                            popupextra.Add("id", model.Id);
                        }
                        else
                        {
							popupextra.Add("id", model.SafeKey);

							
                        }
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                        {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                        popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area"));
                        popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                        popupextra.Add("action", actionDetails);
                        if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
					if (isPopUp)
						return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.UPDATE_DONE));
        			    string returnUrl = null;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"])) {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.Form["ReturnAfter"];
                        else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"];
                    }
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else{
		RouteValueDictionary popupextra = null; 
						 if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"]))
                            {
							
							popupextra = GetRouteData();
							string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
							if (!string.IsNullOrEmpty(area))
								popupextra.Add("area", area);

							return RedirectToAction("Index", popupextra);
						}else{
							return Content("ok");
						}
						}
				 }
                else {
                    return e.ActionResult;
				}
                }		
            }
          catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content(ex.ToString());
                    }
                    else
                    {
                        //return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
						 return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
			    if (isPopUp)
                {
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(ex.Message));
                    
                }
                else
                {
                    SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                    
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else {
						  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
							ViewData["ispopup"] = true;
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
							ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
							ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

						var me = GetContextModel(UIModelContextTypes.EditForm, model);
						Showing(ref me);

						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
						{
							ViewData["ispopup"] = true;
							return ResolveView(me, model);
						}
						else
							return ResolveView(me, model);

						
					}
				}
            }
        }
        //
        // POST: /SDCaseHistoryFiles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //  Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SDCaseHistoryFiles/Delete/5
        
		[MyAuthorize("d", "SDCaseHistoryFile", "SFSServiceDesk", typeof(SDCaseHistoryFilesController))]
		[HttpDelete]
        public ActionResult DeleteGen(string objectKey, string extraParams)
        {
            try
            {
					
			
				Guid guidCasehistoryFile = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey.Replace("-", "/"), "GuidCasehistoryFile")); 
                BO.SDCaseHistoryFile entity = new BO.SDCaseHistoryFile() { GuidCasehistoryFile = guidCasehistoryFile };

                BR.SDCaseHistoryFilesBR.Instance.Delete(entity, GetContextRequest());               
                return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.DELETE_DONE));

            }
            catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null)
                    {
                        message = ex.Data["usermessage"].ToString();
                    }

                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }
            }
        }
		/*[MyAuthorize()]
		public FileMediaResult Download(string query, bool? allSelected = false,  string selected = null , string orderBy = null , string direction = null , string format = null , string actionKey=null )
        {
			
            List<Guid> keysSelected1 = new List<Guid>();
            if (!string.IsNullOrEmpty(selected)) {
                foreach (var keyString in selected.Split(char.Parse("|")))
                {
				
                    keysSelected1.Add(Guid.Parse(keyString));
                }
            }
				
            query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(query, allSelected.Value, selected, "GuidCasehistoryFile");
            MyEventArgs<ContextActionModel<SDCaseHistoryFileModel>> eArgs = null;
            List<SDCaseHistoryFileModel> results = GetBy(query, null, null, orderBy, direction, GetContextRequest(), keysSelected1);
            OnDownloading(this, eArgs = new MyEventArgs<ContextActionModel<SDCaseHistoryFileModel>>() { Object = new ContextActionModel<SDCaseHistoryFileModel>() { Query = query, SelectedItems = results, Selected=selected, SelectAll = allSelected.Value, Direction = direction , OrderBy = orderBy, ActionKey=actionKey  } });

            if (eArgs != null)
            {
                if (eArgs.Object.Result != null)
                    return (FileMediaResult)eArgs.Object.Result;
            }
            

            return (new FeaturesController()).ExportDownload(typeof(SDCaseHistoryFileModel), results, format, this.GetUIPluralText("SFSServiceDesk", "SDCaseHistoryFile"));
            
        }
			*/
		
		[HttpPost]
        public ActionResult CustomActionExecute(ContextActionModel model) {
		 try
            {
			//List<Guid> keysSelected1 = new List<Guid>();
			List<object> keysSelected1 = new List<object>();
            if (!string.IsNullOrEmpty(model.Selected))
            {
                foreach (var keyString in model.Selected.Split(char.Parse(",")))
                {
				
				keysSelected1.Add(Guid.Parse(keyString.Split(char.Parse("|"))[0]));
                        
                    

			
                }
            }
			DataAction dataAction = DataAction.GetDataAction(Request);
			 model.Selected = dataAction.Selected;

            model.Query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(dataAction.Query, dataAction.AllSelected, dataAction.Selected, "GuidCasehistoryFile");
           
            
			
			#region implementaci�n de m�todo parcial
            bool replaceResult = false;
            MyEventArgs<ContextActionModel<SDCaseHistoryFileModel>> actionEventArgs = null;
           
			if (model.ActionKey != "deletemany" && model.ActionKey != "deleterelmany" && model.ActionKey != "updateRel" &&  model.ActionKey != "delete-relation-fk" && model.ActionKey != "restore" )
			{
				ContextRequest context = SFSdotNet.Framework.My.Context.BuildContextRequestSafe(System.Web.HttpContext.Current);
				context.UseMode = dataAction.Usemode;

				if (model.IsBackground)
				{
					System.Threading.Tasks.Task.Run(() => 
						OnCustomActionExecutingBackground(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDCaseHistoryFileModel>>() { Object = new ContextActionModel<SDCaseHistoryFileModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } })
					);
				}
				else
				{
					OnCustomActionExecuting(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDCaseHistoryFileModel>>() {  Object = new ContextActionModel<SDCaseHistoryFileModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } });
				}
			}
            List<SDCaseHistoryFileModel> results = null;
	
			if (model.ActionKey == "deletemany") { 
				
				BR.SDCaseHistoryFilesBR.Instance.Delete(model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());

            }
	
            else if (model.ActionKey == "updateRel" || model.ActionKey == "delete-relation-fk" || model.ActionKey == "updateRel-proxyMany")
            {
               try {
                   string valueForUpdate = null;
				   string propForUpdate = null;
				   if (!string.IsNullOrEmpty(Request.Params["propertyForUpdate"])){
						propForUpdate = Request.Params["propertyForUpdate"];
				   }
				    if (string.IsNullOrEmpty(propForUpdate) && !string.IsNullOrEmpty(Request.QueryString["propertyForUpdate"]))
                   {
                       propForUpdate = Request.QueryString["propertyForUpdate"];
                   }
                    if (model.ActionKey != "delete-relation-fk")
                    {
                        valueForUpdate = Request.QueryString["valueForUpdate"];
                    }
                    BR.SDCaseHistoryFilesBR.Instance.UpdateAssociation(propForUpdate, valueForUpdate, model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());
					
                    if (model.ActionKey == "delete-relation-fk")
                    {
                        MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]);

                        return PartialView("ResultMessageView", message);
                    }
                    else
                    {
                        return Content("ok");
                    }
       
          
                }
                catch (Exception ex)
                {
				        SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
           
                }
            
            }
		
                if (actionEventArgs == null && !model.IsBackground)
                {
                    //if (model.ActionKey != "deletemany"  && model.ActionKey != "deleterelmany")
                    //{
                     //   throw new NotImplementedException("");
                    //}
                }
                else
                {
					if (model.IsBackground == false )
						 replaceResult = actionEventArgs.Object.Result is ActionResult /*actionEventArgs.Object.ReplaceResult*/;
                }
                #endregion
                if (!replaceResult)
                {
                    if (Request != null && Request.IsAjaxRequest())
                    {
						MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]) ;
                        if (model.IsBackground )
                            message.Message = GlobalMessages.THE_PROCESS_HAS_BEEN_STARTED;
                        
                        return PartialView("ResultMessageView", message);                    
					}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return (ActionResult)actionEventArgs.Object.Result;
                }
            }
            catch (Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null) {
                        message = ex.Data["usermessage"].ToString();
                    }
					 SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }

            }
        }
        //
        // POST: /SDCaseHistoryFiles/Delete/5
        
			
	
    }
}
namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
	using SFS.ServiceDesk.Web.Mvc.Models.SDCasePriorities;

    public partial class SDCasePrioritiesController : SFS.ServiceDesk.Web.Mvc.ControllerBase<Models.SDCasePriorities.SDCasePriorityModel>
    {

       


	#region partial methods
        ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e = null;
        partial void OnValidating(object sender, ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e);
        partial void OnGettingExtraData(object sender, MyEventArgs<UIModel<Models.SDCasePriorities.SDCasePriorityModel>> e);
        partial void OnCreating(object sender, ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e);
        partial void OnCreated(object sender, ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e);
        partial void OnEditing(object sender, ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e);
        partial void OnEdited(object sender, ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e);
        partial void OnDeleting(object sender, ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e);
        partial void OnDeleted(object sender, ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e);
    	partial void OnShowing(object sender, MyEventArgs<UIModel<Models.SDCasePriorities.SDCasePriorityModel>> e);
    	partial void OnGettingByKey(object sender, ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e);
        partial void OnTaken(object sender, ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e);
       	partial void OnCreateShowing(object sender, ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e);
		partial void OnEditShowing(object sender, ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e);
		partial void OnDetailsShowing(object sender, ControllerEventArgs<Models.SDCasePriorities.SDCasePriorityModel> e);
 		partial void OnActionsCreated(object sender, MyEventArgs<UIModel<Models.SDCasePriorities.SDCasePriorityModel >> e);
		partial void OnCustomActionExecuting(object sender, MyEventArgs<ContextActionModel<Models.SDCasePriorities.SDCasePriorityModel>> e);
		partial void OnCustomActionExecutingBackground(object sender, MyEventArgs<ContextActionModel<Models.SDCasePriorities.SDCasePriorityModel>> e);
        partial void OnDownloading(object sender, MyEventArgs<ContextActionModel<Models.SDCasePriorities.SDCasePriorityModel>> e);
      	partial void OnAuthorization(object sender, AuthorizationContext context);
		 partial void OnFilterShowing(object sender, MyEventArgs<UIModel<Models.SDCasePriorities.SDCasePriorityModel >> e);
         partial void OnSummaryOperationShowing(object sender, MyEventArgs<UIModel<Models.SDCasePriorities.SDCasePriorityModel>> e);

        partial void OnExportActionsCreated(object sender, MyEventArgs<UIModel<Models.SDCasePriorities.SDCasePriorityModel>> e);


		protected override void OnVirtualFilterShowing(object sender, MyEventArgs<UIModel<SDCasePriorityModel>> e)
        {
            OnFilterShowing(sender, e);
        }
		 public override void OnVirtualExportActionsCreated(object sender, MyEventArgs<UIModel<SDCasePriorityModel>> e)
        {
            OnExportActionsCreated(sender, e);
        }
        public override void OnVirtualDownloading(object sender, MyEventArgs<ContextActionModel<SDCasePriorityModel>> e)
        {
            OnDownloading(sender, e);
        }
        public override void OnVirtualShowing(object sender, MyEventArgs<UIModel<SDCasePriorityModel>> e)
        {
            OnShowing(sender, e);
        }

	#endregion
	#region API
	 public override ActionResult ApiCreateGen(SDCasePriorityModel model, ContextRequest contextRequest)
        {
            return CreateGen(model, contextRequest);
        }

              public override ActionResult ApiGetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJson(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }
        public override ActionResult ApiGetByKeyJson(string id, ContextRequest contextRequest)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
            return  GetByKeyJson(id, contextRequest, true);
        }
      
		 public override ActionResult ApiGetByCount(string filter, ContextRequest contextRequest)
        {
            return GetByCount(filter, contextRequest);
        }
         protected override ActionResult ApiDeleteGen(List<SDCasePriorityModel> models, ContextRequest contextRequest)
        {
            List<SDCasePriority> objs = new List<SDCasePriority>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                BR.SDCasePrioritiesBR.Instance.DeleteBulk(objs, contextRequest);
                if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("success", null, null, null);

                }
                else
                {
                    return Content("ok");

                }
            }
            catch (Exception ex)
            {
               if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "error", reason = "error", message= ex.ToString() }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("error", "exception", ex.ToString(), null );

                }
                else
                {
                    return Json(ex.ToString(), JsonRequestBehavior.AllowGet);

                }
            }
        }
        protected override ActionResult ApiUpdateGen(List<SDCasePriorityModel> models, ContextRequest contextRequest)
        {
            List<SDCasePriority> objs = new List<SDCasePriority>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                foreach (var obj in objs)
                {
                    BR.SDCasePrioritiesBR.Instance.Update(obj, contextRequest);

                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }


	#endregion
#region Validation methods	
	    private void Validations(SDCasePriorityModel model) { 
            #region Remote validations

            #endregion
		}

#endregion
		
 		public AuthorizationContext Authorization(AuthorizationContext context)
        {
            OnAuthorization(this,  context );
            return context ;
        }
		public List<SDCasePriorityModel> GetAll() {
            			var bos = BR.SDCasePrioritiesBR.Instance.GetBy("",
					new SFSdotNet.Framework.My.ContextRequest()
					{
						CustomQuery = new SFSdotNet.Framework.My.CustomQuery()
						{
							OrderBy = "Title",
							SortDirection = SFSdotNet.Framework.Data.SortDirection.Ascending
						}
					});
            			List<SDCasePriorityModel> results = new List<SDCasePriorityModel>();
            SDCasePriorityModel model = null;
            foreach (var bo in bos)
            {
                model = new SDCasePriorityModel();
                model.Bind(bo);
                results.Add(model);
            }
            return results;

        }
        //
        // GET: /SDCasePriorities/
		[MyAuthorize("r", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
		public ActionResult Index()
        {
    		var uiModel = GetContextModel(UIModelContextTypes.ListForm, null);
			ViewBag.UIModel = uiModel;
			uiModel.FilterStart = (string)ViewData["startFilter"];
                    MyEventArgs<UIModel<SDCasePriorityModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCasePriorityModel>>() { Object = uiModel });

			OnExportActionsCreated(this, (me != null ? me : me = new MyEventArgs<UIModel<SDCasePriorityModel>>() { Object = uiModel }));

            if (me != null)
            {
                uiModel = me.Object;
            }
            if (me == null)
                me = new MyEventArgs<UIModel<SDCasePriorityModel>>() { Object = uiModel };
           
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;


            //return View("ListGen");
			return ResolveView(uiModel);
        }
		[MyAuthorize("r", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
		public ActionResult ListViewGen(string idTab, string fk , string fkValue, string startFilter, ListModes  listmode  = ListModes.SimpleList, PropertyDefinition parentRelationProperty = null, object parentRelationPropertyValue = null )
        {
			ViewData["idTab"] = System.Web.HttpContext.Current.Request.QueryString["idTab"]; 
		 	ViewData["detpop"] = true; // details in popup
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"])) {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"]; 
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
            {
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["startFilter"]))
            {
                ViewData["startFilter"] = Request.QueryString["startFilter"];
            }
			
			UIModel<SDCasePriorityModel> uiModel = GetContextModel(UIModelContextTypes.ListForm, null);

            MyEventArgs<UIModel<SDCasePriorityModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCasePriorityModel>>() { Object = uiModel });
            if (me == null)
                me = new MyEventArgs<UIModel<SDCasePriorityModel>>() { Object = uiModel };
            uiModel.Properties = GetProperties(uiModel);
            uiModel.ContextType = UIModelContextTypes.ListForm;
             uiModel.FilterStart = (string)ViewData["startFilter"];
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;
			 if (listmode == ListModes.SimpleList)
                return ResolveView(uiModel);
            else
            {
                ViewData["parentRelationProperty"] = parentRelationProperty;
                ViewData["parentRelationPropertyValue"] = parentRelationPropertyValue;
                return PartialView("ListForTagSelectView");
            }
            return ResolveView(uiModel);
        }
		List<PropertyDefinition> _properties = null;

		 protected override List<PropertyDefinition> GetProperties(UIModel uiModel,  params string[] specificProperties)
        { 
            return GetProperties(uiModel, false, null, specificProperties);
        }

		protected override List<PropertyDefinition> GetProperties(UIModel uiModel, bool decripted, Guid? id, params string[] specificProperties)
            {

			bool allProperties = true;    
                if (specificProperties != null && specificProperties.Length > 0)
                {
                    allProperties = false;
                }


			List<CustomProperty> customProperties = new List<CustomProperty>();
			if (_properties == null)
                {
                List<PropertyDefinition> results = new List<PropertyDefinition>();

			string idSDCasePriority = GetRouteDataOrQueryParam("id");
			if (idSDCasePriority != null)
			{
				if (!decripted)
                {
					idSDCasePriority = SFSdotNet.Framework.Entities.Utils.GetPropertyKey(idSDCasePriority.Replace("-","/"), "GuidCasePriority");
				}else{
					if (id != null )
						idSDCasePriority = id.Value.ToString();                

				}
			}

			bool visibleProperty = true;	
			 bool conditionalshow =false;
                if (uiModel.ContextType == UIModelContextTypes.EditForm || uiModel.ContextType == UIModelContextTypes.DisplayForm ||  uiModel.ContextType == UIModelContextTypes.GenericForm )
                    conditionalshow = true;
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidCasePriority"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidCasePriority")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 100,
																	
					CustomProperties = customProperties,

                    PropertyName = "GuidCasePriority",

					 MaxLength = 0,
					IsRequired = true ,
					IsHidden = true,
                    SystemProperty =  SystemProperties.Identifier ,
					IsDefaultProperty = false,
                    SortBy = "GuidCasePriority",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCasePriorityResources.GUIDCASEPRIORITY*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("Title"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "Title")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 101,
																	
					CustomProperties = customProperties,

                    PropertyName = "Title",

					 MaxLength = 255,
					IsRequired = true ,
					IsDefaultProperty = true,
                    SortBy = "Title",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCasePriorityResources.TITLE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCases"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCasePriority" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCases.GuidCase")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCases.GuidCase" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCases" });
			

	
	//fk_SdCase_SdCasePriority
		//if (this.Request.QueryString["fk"] != "SDCases")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 102,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCases/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDCases&fk=SDCasePriority&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDCasePriority.GuidCasePriority = Guid(\"" + idSDCasePriority +"\")")+ "&fkValue=" + idSDCasePriority,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCase",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCases",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDCases.BodyContent",
					
	
                    TypeName = "SFSServiceDeskModel.SDCase",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDCases"
                    /*,PropertyDisplayName = Resources.SDCasePriorityResources.SDCASES*/
                });
		//	}
	
	}
	
				
                    _properties = results;
                    return _properties;
                }
                else {
                    return _properties;
                }
            }

		protected override  UIModel<SDCasePriorityModel> GetByForShow(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, params  object[] extraParams)
        {
			if (Request != null )
				if (!string.IsNullOrEmpty(Request.QueryString["q"]))
					filter = filter + HttpUtility.UrlDecode(Request.QueryString["q"]);
 if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
            }
            var bos = BR.SDCasePrioritiesBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), contextRequest, extraParams);
			//var bos = BR.SDCasePrioritiesBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), context, extraParams);
            SDCasePriorityModel model = null;
            List<SDCasePriorityModel> results = new List<SDCasePriorityModel>();
            foreach (var item in bos)
            {
                model = new SDCasePriorityModel();
				model.Bind(item);
				results.Add(model);
            }
            //return results;
			UIModel<SDCasePriorityModel> uiModel = GetContextModel(UIModelContextTypes.Items, null);
            uiModel.Items = results;
			if (Request != null){
				if (SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(Request.RequestContext, "action") == "Download")
				{
					uiModel.ContextType = UIModelContextTypes.ExportDownload;
				}
			}
            Showing(ref uiModel);
            return uiModel;
		}			
		
		//public List<SDCasePriorityModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params  object[] extraParams)
        //{
		//	var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, null, extraParams);
        public override List<SDCasePriorityModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest,  params  object[] extraParams)
        {
            var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
           
            return uiModel.Items;
		
        }
		/*
        [MyAuthorize("r", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir)
        {
			 return GetByJsonBase(filter, pageSize, page, orderBy, orderDir);
        }*/

		  [MyAuthorize("r", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir,ContextRequest contextRequest,  object[] extraParams)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
			 
			 if (this.IsRESTRequest == false)
            {
                return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
            }else
            {
                try
                {
                    return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);

                }
            }
        }
/*		  [MyAuthorize("r", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
       public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }*/
		[MyAuthorize()]
		public ActionResult GetByCount(string filter, ContextRequest contextRequest) {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
           
			
             if (this.IsRESTRequest == true)
            {
                try
                {

                    var result = BR.SDCasePrioritiesBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);

                   if (Request.QueryString["v"] == "2")
                    {
						return ResolveApiResponse("success", null, null, result);

                        //return Json(new { status = "success", data = result }, JsonRequestBehavior.AllowGet);
                    }else
                    {
                        return Content(result.ToString());

                    }
                }
                catch (Exception ex)
                {
                  //  return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
				  return ResolveApiResponse("error", "exception", ex.ToString(), null);

                }
            }
            else
            {
                var result = BR.SDCasePrioritiesBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);
                return Content(result.ToString());
            }
		}
		

		[MyAuthorize("r", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
        public ActionResult GetByKeyJson(string id, ContextRequest contextRequest,  bool dec = false)
        {
            return Json(GetByKey(id, null, contextRequest, dec), JsonRequestBehavior.AllowGet);
        }
		public SDCasePriorityModel GetByKey(string id) {
			return GetByKey(id, null,null, false);
       	}
		    public SDCasePriorityModel GetByKey(string id, string includes)
        {
            return GetByKey(id, includes, false);
        }
		 public  SDCasePriorityModel GetByKey(string id, string includes, ContextRequest contextRequest)
        {
            return GetByKey(id, includes, contextRequest, false);
        }
		/*
		  public ActionResult ShowField(string fieldName, string idField) {
		   string safePropertyName = fieldName;
              if (fieldName.StartsWith("Fk"))
              {
                  safePropertyName = fieldName.Substring(2, fieldName.Length - 2);
              }

             SDCasePriorityModel model = new  SDCasePriorityModel();

            UIModel uiModel = GetUIModel(model, new string[] { "NoField-" });
			
				uiModel.Properties = GetProperties(uiModel, safePropertyName);
		uiModel.Properties.ForEach(p=> p.ContextType = uiModel.ContextType );
            uiModel.ContextType = UIModelContextTypes.FilterFields;
            uiModel.OverrideApp = GetOverrideApp();
            uiModel.UseMode = GetUseMode();

            ViewData["uiModel"] = uiModel;
			var prop = uiModel.Properties.FirstOrDefault(p=>p.PropertyName == safePropertyName);
            //if (prop.IsNavigationProperty && prop.IsNavigationPropertyMany == false)
            //{
            //    ViewData["currentProperty"] = uiModel.Properties.FirstOrDefault(p => p.PropertyName != fieldName + "Text");
            //}else if (prop.IsNavigationProperty == false){
                ViewData["currentProperty"] = prop;
           // }
            ((PropertyDefinition)ViewData["currentProperty"]).RemoveLayout = true;
			ViewData["withContainer"] = false;


            return PartialView("GenericField", model);


        }
      */
	public SDCasePriorityModel GetByKey(string id, ContextRequest contextRequest, bool dec)
        {
            return GetByKey(id, null, contextRequest, dec);
        }
        public SDCasePriorityModel GetByKey(string id, string  includes, bool dec)
        {
            return GetByKey(id, includes, null, dec);
        }

        public SDCasePriorityModel GetByKey(string id, string includes, ContextRequest contextRequest, bool dec) {
		             SDCasePriorityModel model = null;
            ControllerEventArgs<SDCasePriorityModel> e = null;
			string objectKey = id.Replace("-","/");
             OnGettingByKey(this, e=  new ControllerEventArgs<SDCasePriorityModel>() { Id = objectKey  });
             bool cancel = false;
             SDCasePriorityModel eItem = null;
             if (e != null)
             {
                 cancel = e.Cancel;
                 eItem = e.Item;
             }
			if (cancel == false && eItem == null)
             {
			Guid guidCasePriority = Guid.Empty; //new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, "GuidCasePriority"));
			if (dec)
                 {
                     guidCasePriority = new Guid(id);
                 }
                 else
                 {
                     guidCasePriority = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, null));
                 }
			
            
				model = new SDCasePriorityModel();
                  if (contextRequest == null)
                {
                    contextRequest = GetContextRequest();
                }
				var bo = BR.SDCasePrioritiesBR.Instance.GetByKey(guidCasePriority, GetUseMode(), contextRequest,  includes);
				 if (bo != null)
                    model.Bind(bo);
                else
                    return null;
			}
             else {
                 model = eItem;
             }
			model.IsNew = false;

            return model;
        }
        // GET: /SDCasePriorities/DetailsGen/5
		[MyAuthorize("r", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
        public ActionResult DetailsGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDCasePriorityResources.ENTITY_PLURAL;
			 #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDCasePriorityModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
            #endregion



			 bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
			//UIModel<SDCasePriorityModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, decripted), decripted, guidId);
			var item = GetByKey(id, null, null, decripted);
			if (item == null)
            {
                 RouteValueDictionary rv = new RouteValueDictionary();
                string usemode = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"usemode");
                string overrideModule = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "overrideModule");
                string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");

                if(!string.IsNullOrEmpty(usemode)){
                    rv.Add("usemode", usemode);
                }
                if(!string.IsNullOrEmpty(overrideModule)){
                    rv.Add("overrideModule", overrideModule);
                }
                if (!string.IsNullOrEmpty(area))
                {
                    rv.Add("area", area);
                }

                return RedirectToAction("Index", rv);
            }
            //
            UIModel<SDCasePriorityModel> uiModel = null;
                uiModel = GetContextModel(UIModelContextTypes.DisplayForm, item, decripted, guidId);



            MyEventArgs<UIModel<SDCasePriorityModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCasePriorityModel>>() { Object = uiModel });

            if (me != null) {
                uiModel = me.Object;
            }
			
            Showing(ref uiModel);
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			
            //return View("DisplayGen", uiModel.Items[0]);
			return ResolveView(uiModel, uiModel.Items[0]);

        }
		[MyAuthorize("r", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
		public ActionResult DetailsViewGen(string id)
        {

		 bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDCasePriorityModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
           
			if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
 			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
           
        	 //var uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id));
			 
            bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true")
                {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
            UIModel<SDCasePriorityModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, null, decripted), decripted, guidId);
			

            MyEventArgs<UIModel<SDCasePriorityModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCasePriorityModel>>() { Object = uiModel });

            if (me != null)
            {
                uiModel = me.Object;
            }
            
            Showing(ref uiModel);
            return ResolveView(uiModel, uiModel.Items[0]);
        
        }
        //
        // GET: /SDCasePriorities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /SDCasePriorities/CreateGen
		[MyAuthorize("c", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
        public ActionResult CreateGen()
        {
			SDCasePriorityModel model = new SDCasePriorityModel();
            model.IsNew = true;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model);

			OnCreateShowing(this, e = new ControllerEventArgs<SDCasePriorityModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }

             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                 ViewData["ispopup"] = true;
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                 ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                 ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

            Showing(ref me);

			return ResolveView(me, me.Items[0]);
        } 
			
		protected override UIModel<SDCasePriorityModel> GetContextModel(UIModelContextTypes formMode, SDCasePriorityModel model)
        {
            return GetContextModel(formMode, model, false, null);
        }
			
		 private UIModel<SDCasePriorityModel> GetContextModel(UIModelContextTypes formMode, SDCasePriorityModel model, bool decript, Guid ? id) {
            UIModel<SDCasePriorityModel> me = new UIModel<SDCasePriorityModel>(true, "SDCasePriorities");
			me.UseMode = GetUseMode();
			me.Controller = this;
			me.OverrideApp = GetOverrideApp();
			me.ContextType = formMode ;
			me.Id = "SDCasePriority";
			
            me.ModuleKey = "SFSServiceDesk";

			me.ModuleNamespace = "SFS.ServiceDesk";
            me.EntityKey = "SDCasePriority";
            me.EntitySetName = "SDCasePriorities";

			me.AreaAction = "SFSServiceDesk";
            me.ControllerAction = "SDCasePriorities";
            me.PropertyKeyName = "GuidCasePriority";

            me.Properties = GetProperties(me, decript, id);
 			
			if (Request != null)
            {
                string actionName = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam( Request.RequestContext, "action");
                if(actionName != null && actionName.ToLower().Contains("create") ){
                    me.IsNew = true;
                }
            }
			 #region Buttons
			 if (Request != null ){
             if (formMode == UIModelContextTypes.DisplayForm || formMode == UIModelContextTypes.EditForm || formMode == UIModelContextTypes.ListForm)
				me.ActionButtons = GetActionButtons(formMode,model != null ?(Request.QueryString["dec"] == "true" ? model.Id : model.SafeKey)  : null, "SFSServiceDesk", "SDCasePriorities", "SDCasePriority", me.IsNew);

            //me.ActionButtons.Add(new ActionModel() { ActionKey = "return", Title = GlobalMessages.RETURN, Url = System.Web.VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCasePriorities" });
			if (this.HttpContext != null &&  !this.HttpContext.SkipAuthorization){
				//antes this.HttpContext
				me.SetAction("u", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("u", "SDCasePriority", "SFSServiceDesk"));
				me.SetAction("c", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("c", "SDCasePriority", "SFSServiceDesk"));
				me.SetAction("d", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("d", "SDCasePriority", "SFSServiceDesk"));
			
			}else{
				me.SetAction("u", true);
				me.SetAction("c", true);
				me.SetAction("d", true);

			}
            #endregion              
         
            switch (formMode)
            {
                case UIModelContextTypes.DisplayForm:
					//me.TitleForm = SDCasePriorityResources.SDCASEPRIORITIES_DETAILS;
                    me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.MODIFY_DATA;
					 me.Properties.Where(p=>p.PropertyName  != "Id" && p.IsForeignKey == false).ToList().ForEach(p => p.IsHidden = false);

					 me.Properties.Where(p => (p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier) ).ToList().ForEach(p=> me.SetHide(p.PropertyName));

                    break;
                case UIModelContextTypes.EditForm:
				  me.Properties.Where(p=>p.SystemProperty != SystemProperties.Identifier && p.IsForeignKey == false && p.PropertyName != "Id").ToList().ForEach(p => p.IsHidden = false);

					if (model != null)
                    {
						

                        me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.SAVE_DATA;                        
                        me.ActionButtons.First(p => p.ActionKey == "c").Title = GlobalMessages.SAVE_DATA;
						if (model.IsNew ){
							//me.TitleForm = SDCasePriorityResources.SDCASEPRIORITIES_ADD_NEW;
							me.ActionName = "CreateGen";
							me.Properties.RemoveAll(p => p.SystemProperty != null || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));
						}else{
							
							me.ActionName = "EditGen";

							//me.TitleForm = SDCasePriorityResources.SDCASEPRIORITIES_EDIT;
							me.Properties.RemoveAll(p => p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));	
						}
						//me.Properties.Remove(me.Properties.Find(p => p.PropertyName == "UpdatedDate"));
					
					}
                    break;
                case UIModelContextTypes.FilterFields:
                    break;
                case UIModelContextTypes.GenericForm:
                    break;
                case UIModelContextTypes.Items:
				//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "Title") != null){
						me.Properties.Find(p => p.PropertyName == "Title").IsHidden = false;
					 }
					 
                    
					

						 if (me.Properties.Find(p => p.PropertyName == "GuidCasePriority") != null){
						me.Properties.Find(p => p.PropertyName == "GuidCasePriority").IsHidden = false;
					 }
					 
                    
					


                  


					//}
                    break;
                case UIModelContextTypes.ListForm:
					PropertyDefinition propFinded = null;
					//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "Title") != null){
						me.Properties.Find(p => p.PropertyName == "Title").IsHidden = false;
					 }
					
					me.PrincipalActionName = "GetByJson";
					//}
					//me.TitleForm = SDCasePriorityResources.SDCASEPRIORITIES_LIST;
                    break;
                default:
                    break;
            }
            	this.SetDefaultProperties(me);
			}
			if (model != null )
            	me.Items.Add(model);
            return me;
        }
		// GET: /SDCasePriorities/CreateViewGen
		[MyAuthorize("c", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
        public ActionResult CreateViewGen()
        {
				SDCasePriorityModel model = new SDCasePriorityModel();
            model.IsNew = true;
			e= null;
			OnCreateShowing(this, e = new ControllerEventArgs<SDCasePriorityModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }
			
            var me = GetContextModel(UIModelContextTypes.EditForm, model);

			me.IsPartialView = true;	
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
            {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                me.Properties.Find(p => p.PropertyName == ViewData["fk"].ToString()).IsReadOnly = true;
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
			
      
            //me.Items.Add(model);
            Showing(ref me);
            return ResolveView(me, me.Items[0]);
        }
		protected override  void GettingExtraData(ref UIModel<SDCasePriorityModel> uiModel)
        {

            MyEventArgs<UIModel<SDCasePriorityModel>> me = null;
            OnGettingExtraData(this, me = new MyEventArgs<UIModel<SDCasePriorityModel>>() { Object = uiModel });
            //bool maybeAnyReplaced = false; 
            if (me != null)
            {
                uiModel = me.Object;
                //maybeAnyReplaced = true;
            }
           
			bool canFill = false;
			 string query = null ;
            bool isFK = false;
			PropertyDefinition prop =null;
			var contextRequest = this.GetContextRequest();
            contextRequest.CustomParams.Add(new CustomParam() { Name="ui", Value= SDCasePriority.EntityName });

                        

        }
		private void Showing(ref UIModel<SDCasePriorityModel> uiModel) {
          	
			MyEventArgs<UIModel<SDCasePriorityModel>> me = new MyEventArgs<UIModel<SDCasePriorityModel>>() { Object = uiModel };
			 OnVirtualLayoutSettings(this, me);


            OnShowing(this, me);

			
			if ((Request != null && Request.QueryString["allFields"] == "1") || Request == null )
			{
				me.Object.Properties.ForEach(p=> p.IsHidden = false);
            }
            if (me != null)
            {
                uiModel = me.Object;
            }
          


			 if (uiModel.ContextType == UIModelContextTypes.EditForm)
			    GettingExtraData(ref uiModel);
            ViewData["UIModel"] = uiModel;

        }
        //
        // POST: /SDCasePriorities/Create
		[MyAuthorize("c", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
        [HttpPost]
		[ValidateInput(false)] 
        public ActionResult CreateGen(SDCasePriorityModel  model,  ContextRequest contextRequest)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
		 	e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDCasePriorityModel>() { Item = model });
           
		  	if (!ModelState.IsValid) {
				model.IsNew = true;
				var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
                 if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                        ViewData["ispopup"] = true;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
                    return ResolveView(me, model);
            }
            try
            {
				if (model.GuidCasePriority == null || model.GuidCasePriority.ToString().Contains("000000000"))
				model.GuidCasePriority = Guid.NewGuid();
	
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnCreating(this, e = new ControllerEventArgs<SDCasePriorityModel>() { Item = model });
                if (e != null) {
                   if (e.Cancel && e.RedirectValues.Count > 0){
                        RouteValueDictionary rv = new RouteValueDictionary();
                        if (e.RedirectValues["area"] != null ){
                            rv.Add("area", e.RedirectValues["area"].ToString());
                        }
                        foreach (var item in e.RedirectValues.Where(p=>p.Key != "area" && p.Key != "controller" &&  p.Key != "action" ))
	                    {
		                    rv.Add(item.Key, item.Value);
	                    }

                        //if (e.RedirectValues["action"] != null && e.RedirectValues["controller"] != null && e.RedirectValues["area"] != null )
                        return RedirectToAction(e.RedirectValues["action"].ToString(), e.RedirectValues["controller"].ToString(), rv );


                        
                    }else if (e.Cancel && e.ActionResult != null )
                        return e.ActionResult;  
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				if (contextRequest == null || contextRequest.Company == null){
					contextRequest = GetContextRequest();
					
				}
                if (!cancel)
                	model.Bind(SDCasePrioritiesBR.Instance.Create(model.GetBusinessObject(), contextRequest ));
				OnCreated(this, e = new ControllerEventArgs<SDCasePriorityModel>() { Item = model });
                 if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                        return ResolveApiResponse("success", null, null, null);

                    }
                }
				 
				 if (e != null )
					if (e.ActionResult != null)
                    	replaceResult = true;		
				if (!replaceResult)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))
                    {
                        ViewData["__continue"] = true;
                    }
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"]) &&  string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
                        popupextra.Add("id", model.SafeKey);
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                       {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                            popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"area"));
                            popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                            popupextra.Add("action", actionDetails);
                       if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
                    {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))

                        {
                            var popupextra = GetRouteData();
                            popupextra.Add("id", model.SafeKey);
                            return RedirectToAction("EditViewGen", popupextra);
                        }
                        else
                        {
                            return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.ADD_DONE));
                        }
                    }        			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                        return Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]);
                    else{

							RouteValueDictionary popupextra = null; 
							if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"])){
                            popupextra = GetRouteData();
							 string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
                            if (!string.IsNullOrEmpty(area))
                                popupextra.Add("area", area);
                            
                            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"])) {
								popupextra.Add("id", model.SafeKey);
                                return RedirectToAction("EditGen", popupextra);

                            }else{
								
                            return RedirectToAction("Index", popupextra);
							}
							}else{
								return Content("ok");
							}
                        }
						 }
                else {
                    return e.ActionResult;
                    }
				}
            catch(Exception ex)
            {
					  SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        throw ex;
                    }
                    else
                    {
                       // return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
					   return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
                SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                model.IsNew = true;
                var me = GetContextModel(UIModelContextTypes.EditForm, model, true, model.GuidCasePriority);
                Showing(ref me);
                if (isPopUp)
                {
                    
                        ViewData["ispopup"] = isPopUp;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
					if (Request != null)
						return ResolveView(me, model);
					else
						return Content("ok");
            }
        }        
        //
        // GET: /SDCasePriorities/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }
			
		
		[MyAuthorize("u", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
		[MvcSiteMapNode(Area="SFSServiceDesk", Title="sss", Clickable=false, ParentKey = "SFSServiceDesk_SDCasePriority_List")]
		public ActionResult EditGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDCasePriorityResources.ENTITY_SINGLE;		 	
  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDCasePriorityModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
            SDCasePriorityModel model = null;
            // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
			bool dec = false;
            Guid ? idGuidDecripted = null ;
            if (Request != null && Request.QueryString["dec"] == "true")
            {
                dec = true;
                idGuidDecripted = Guid.Parse(id);
            }

            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model,dec,idGuidDecripted);
            Showing(ref me);


            if (!replaceResult)
            {
                 //return View("EditGen", me.Items[0]);
				 return ResolveView(me, me.Items[0]);
            }
            else {
                return e.ActionResult;
            }
        }
			[MyAuthorize("u", "SDCasePriority","SFSServiceDesk", typeof(SDCasePrioritiesController))]
		public ActionResult EditViewGen(string id)
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

					  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDCasePriorityModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
			
            SDCasePriorityModel model = null;
			 bool dec = false;
            Guid? guidId = null ;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                dec = true;
                guidId = Guid.Parse(id);
            }
            // si fue implementado el método parcial y no se ha decidido suspender la acción
            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
            var me = GetContextModel(UIModelContextTypes.EditForm, model, dec, guidId);
            Showing(ref me);

            return ResolveView(me, model);
        }
		[MyAuthorize("u", "SDCasePriority",  "SFSServiceDesk", typeof(SDCasePrioritiesController))]
		[HttpPost]
		[ValidateInput(false)] 
		        public ActionResult EditGen(SDCasePriorityModel model)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
			e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDCasePriorityModel>() { Item = model });
           
            if (!ModelState.IsValid)
            {
			   	var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
			
				if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"])){
                	ViewData["ispopup"] = true;
					return ResolveView(me, model);
				}
				else
					return ResolveView(me, model);
            }
            try
            {
			
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnEditing(this, e = new ControllerEventArgs<SDCasePriorityModel>() { Item = model });
                if (e != null) {
                    if (e.Cancel && e.ActionResult != null)
                        return e.ActionResult;
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				ContextRequest context = new ContextRequest();
                context.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;

                SDCasePriority resultObj = null;
			    if (!cancel)
                	resultObj = SDCasePrioritiesBR.Instance.Update(model.GetBusinessObject(), GetContextRequest());
				
				OnEdited(this, e = new ControllerEventArgs<SDCasePriorityModel>() { Item =   new SDCasePriorityModel(resultObj) });
				if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                         return ResolveApiResponse("success", null, null, null);
                    }
                }
				
				if (e != null && e.ActionResult != null) replaceResult = true; 

                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Content("ok");
                }
                else
                {
				if (!replaceResult)
                {
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"])  && string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
						 if (Request != null && Request.QueryString["dec"] == "true")
                        {
                            popupextra.Add("id", model.Id);
                        }
                        else
                        {
							popupextra.Add("id", model.SafeKey);

							
                        }
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                        {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                        popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area"));
                        popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                        popupextra.Add("action", actionDetails);
                        if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
					if (isPopUp)
						return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.UPDATE_DONE));
        			    string returnUrl = null;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"])) {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.Form["ReturnAfter"];
                        else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"];
                    }
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else{
		RouteValueDictionary popupextra = null; 
						 if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"]))
                            {
							
							popupextra = GetRouteData();
							string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
							if (!string.IsNullOrEmpty(area))
								popupextra.Add("area", area);

							return RedirectToAction("Index", popupextra);
						}else{
							return Content("ok");
						}
						}
				 }
                else {
                    return e.ActionResult;
				}
                }		
            }
          catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content(ex.ToString());
                    }
                    else
                    {
                        //return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
						 return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
			    if (isPopUp)
                {
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(ex.Message));
                    
                }
                else
                {
                    SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                    
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else {
						  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
							ViewData["ispopup"] = true;
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
							ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
							ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

						var me = GetContextModel(UIModelContextTypes.EditForm, model);
						Showing(ref me);

						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
						{
							ViewData["ispopup"] = true;
							return ResolveView(me, model);
						}
						else
							return ResolveView(me, model);

						
					}
				}
            }
        }
        //
        // POST: /SDCasePriorities/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //  Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SDCasePriorities/Delete/5
        
		[MyAuthorize("d", "SDCasePriority", "SFSServiceDesk", typeof(SDCasePrioritiesController))]
		[HttpDelete]
        public ActionResult DeleteGen(string objectKey, string extraParams)
        {
            try
            {
					
			
				Guid guidCasePriority = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey.Replace("-", "/"), "GuidCasePriority")); 
                BO.SDCasePriority entity = new BO.SDCasePriority() { GuidCasePriority = guidCasePriority };

                BR.SDCasePrioritiesBR.Instance.Delete(entity, GetContextRequest());               
                return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.DELETE_DONE));

            }
            catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null)
                    {
                        message = ex.Data["usermessage"].ToString();
                    }

                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }
            }
        }
		/*[MyAuthorize()]
		public FileMediaResult Download(string query, bool? allSelected = false,  string selected = null , string orderBy = null , string direction = null , string format = null , string actionKey=null )
        {
			
            List<Guid> keysSelected1 = new List<Guid>();
            if (!string.IsNullOrEmpty(selected)) {
                foreach (var keyString in selected.Split(char.Parse("|")))
                {
				
                    keysSelected1.Add(Guid.Parse(keyString));
                }
            }
				
            query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(query, allSelected.Value, selected, "GuidCasePriority");
            MyEventArgs<ContextActionModel<SDCasePriorityModel>> eArgs = null;
            List<SDCasePriorityModel> results = GetBy(query, null, null, orderBy, direction, GetContextRequest(), keysSelected1);
            OnDownloading(this, eArgs = new MyEventArgs<ContextActionModel<SDCasePriorityModel>>() { Object = new ContextActionModel<SDCasePriorityModel>() { Query = query, SelectedItems = results, Selected=selected, SelectAll = allSelected.Value, Direction = direction , OrderBy = orderBy, ActionKey=actionKey  } });

            if (eArgs != null)
            {
                if (eArgs.Object.Result != null)
                    return (FileMediaResult)eArgs.Object.Result;
            }
            

            return (new FeaturesController()).ExportDownload(typeof(SDCasePriorityModel), results, format, this.GetUIPluralText("SFSServiceDesk", "SDCasePriority"));
            
        }
			*/
		
		[HttpPost]
        public ActionResult CustomActionExecute(ContextActionModel model) {
		 try
            {
			//List<Guid> keysSelected1 = new List<Guid>();
			List<object> keysSelected1 = new List<object>();
            if (!string.IsNullOrEmpty(model.Selected))
            {
                foreach (var keyString in model.Selected.Split(char.Parse(",")))
                {
				
				keysSelected1.Add(Guid.Parse(keyString.Split(char.Parse("|"))[0]));
                        
                    

			
                }
            }
			DataAction dataAction = DataAction.GetDataAction(Request);
			 model.Selected = dataAction.Selected;

            model.Query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(dataAction.Query, dataAction.AllSelected, dataAction.Selected, "GuidCasePriority");
           
            
			
			#region implementaci�n de m�todo parcial
            bool replaceResult = false;
            MyEventArgs<ContextActionModel<SDCasePriorityModel>> actionEventArgs = null;
           
			if (model.ActionKey != "deletemany" && model.ActionKey != "deleterelmany" && model.ActionKey != "updateRel" &&  model.ActionKey != "delete-relation-fk" && model.ActionKey != "restore" )
			{
				ContextRequest context = SFSdotNet.Framework.My.Context.BuildContextRequestSafe(System.Web.HttpContext.Current);
				context.UseMode = dataAction.Usemode;

				if (model.IsBackground)
				{
					System.Threading.Tasks.Task.Run(() => 
						OnCustomActionExecutingBackground(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDCasePriorityModel>>() { Object = new ContextActionModel<SDCasePriorityModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } })
					);
				}
				else
				{
					OnCustomActionExecuting(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDCasePriorityModel>>() {  Object = new ContextActionModel<SDCasePriorityModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } });
				}
			}
            List<SDCasePriorityModel> results = null;
	
			if (model.ActionKey == "deletemany") { 
				
				BR.SDCasePrioritiesBR.Instance.Delete(model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());

            }
	
            else if (model.ActionKey == "updateRel" || model.ActionKey == "delete-relation-fk" || model.ActionKey == "updateRel-proxyMany")
            {
               try {
                   string valueForUpdate = null;
				   string propForUpdate = null;
				   if (!string.IsNullOrEmpty(Request.Params["propertyForUpdate"])){
						propForUpdate = Request.Params["propertyForUpdate"];
				   }
				    if (string.IsNullOrEmpty(propForUpdate) && !string.IsNullOrEmpty(Request.QueryString["propertyForUpdate"]))
                   {
                       propForUpdate = Request.QueryString["propertyForUpdate"];
                   }
                    if (model.ActionKey != "delete-relation-fk")
                    {
                        valueForUpdate = Request.QueryString["valueForUpdate"];
                    }
                    BR.SDCasePrioritiesBR.Instance.UpdateAssociation(propForUpdate, valueForUpdate, model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());
					
                    if (model.ActionKey == "delete-relation-fk")
                    {
                        MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]);

                        return PartialView("ResultMessageView", message);
                    }
                    else
                    {
                        return Content("ok");
                    }
       
          
                }
                catch (Exception ex)
                {
				        SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
           
                }
            
            }
		
                if (actionEventArgs == null && !model.IsBackground)
                {
                    //if (model.ActionKey != "deletemany"  && model.ActionKey != "deleterelmany")
                    //{
                     //   throw new NotImplementedException("");
                    //}
                }
                else
                {
					if (model.IsBackground == false )
						 replaceResult = actionEventArgs.Object.Result is ActionResult /*actionEventArgs.Object.ReplaceResult*/;
                }
                #endregion
                if (!replaceResult)
                {
                    if (Request != null && Request.IsAjaxRequest())
                    {
						MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]) ;
                        if (model.IsBackground )
                            message.Message = GlobalMessages.THE_PROCESS_HAS_BEEN_STARTED;
                        
                        return PartialView("ResultMessageView", message);                    
					}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return (ActionResult)actionEventArgs.Object.Result;
                }
            }
            catch (Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null) {
                        message = ex.Data["usermessage"].ToString();
                    }
					 SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }

            }
        }
        //
        // POST: /SDCasePriorities/Delete/5
        
			
	
    }
}
namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
	using SFS.ServiceDesk.Web.Mvc.Models.SDCaseStatus;

    public partial class SDCaseStatusController : SFS.ServiceDesk.Web.Mvc.ControllerBase<Models.SDCaseStatus.SDCaseStatuModel>
    {

       


	#region partial methods
        ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e = null;
        partial void OnValidating(object sender, ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e);
        partial void OnGettingExtraData(object sender, MyEventArgs<UIModel<Models.SDCaseStatus.SDCaseStatuModel>> e);
        partial void OnCreating(object sender, ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e);
        partial void OnCreated(object sender, ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e);
        partial void OnEditing(object sender, ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e);
        partial void OnEdited(object sender, ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e);
        partial void OnDeleting(object sender, ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e);
        partial void OnDeleted(object sender, ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e);
    	partial void OnShowing(object sender, MyEventArgs<UIModel<Models.SDCaseStatus.SDCaseStatuModel>> e);
    	partial void OnGettingByKey(object sender, ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e);
        partial void OnTaken(object sender, ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e);
       	partial void OnCreateShowing(object sender, ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e);
		partial void OnEditShowing(object sender, ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e);
		partial void OnDetailsShowing(object sender, ControllerEventArgs<Models.SDCaseStatus.SDCaseStatuModel> e);
 		partial void OnActionsCreated(object sender, MyEventArgs<UIModel<Models.SDCaseStatus.SDCaseStatuModel >> e);
		partial void OnCustomActionExecuting(object sender, MyEventArgs<ContextActionModel<Models.SDCaseStatus.SDCaseStatuModel>> e);
		partial void OnCustomActionExecutingBackground(object sender, MyEventArgs<ContextActionModel<Models.SDCaseStatus.SDCaseStatuModel>> e);
        partial void OnDownloading(object sender, MyEventArgs<ContextActionModel<Models.SDCaseStatus.SDCaseStatuModel>> e);
      	partial void OnAuthorization(object sender, AuthorizationContext context);
		 partial void OnFilterShowing(object sender, MyEventArgs<UIModel<Models.SDCaseStatus.SDCaseStatuModel >> e);
         partial void OnSummaryOperationShowing(object sender, MyEventArgs<UIModel<Models.SDCaseStatus.SDCaseStatuModel>> e);

        partial void OnExportActionsCreated(object sender, MyEventArgs<UIModel<Models.SDCaseStatus.SDCaseStatuModel>> e);


		protected override void OnVirtualFilterShowing(object sender, MyEventArgs<UIModel<SDCaseStatuModel>> e)
        {
            OnFilterShowing(sender, e);
        }
		 public override void OnVirtualExportActionsCreated(object sender, MyEventArgs<UIModel<SDCaseStatuModel>> e)
        {
            OnExportActionsCreated(sender, e);
        }
        public override void OnVirtualDownloading(object sender, MyEventArgs<ContextActionModel<SDCaseStatuModel>> e)
        {
            OnDownloading(sender, e);
        }
        public override void OnVirtualShowing(object sender, MyEventArgs<UIModel<SDCaseStatuModel>> e)
        {
            OnShowing(sender, e);
        }

	#endregion
	#region API
	 public override ActionResult ApiCreateGen(SDCaseStatuModel model, ContextRequest contextRequest)
        {
            return CreateGen(model, contextRequest);
        }

              public override ActionResult ApiGetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJson(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }
        public override ActionResult ApiGetByKeyJson(string id, ContextRequest contextRequest)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
            return  GetByKeyJson(id, contextRequest, true);
        }
      
		 public override ActionResult ApiGetByCount(string filter, ContextRequest contextRequest)
        {
            return GetByCount(filter, contextRequest);
        }
         protected override ActionResult ApiDeleteGen(List<SDCaseStatuModel> models, ContextRequest contextRequest)
        {
            List<SDCaseStatu> objs = new List<SDCaseStatu>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                BR.SDCaseStatusBR.Instance.DeleteBulk(objs, contextRequest);
                if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("success", null, null, null);

                }
                else
                {
                    return Content("ok");

                }
            }
            catch (Exception ex)
            {
               if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "error", reason = "error", message= ex.ToString() }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("error", "exception", ex.ToString(), null );

                }
                else
                {
                    return Json(ex.ToString(), JsonRequestBehavior.AllowGet);

                }
            }
        }
        protected override ActionResult ApiUpdateGen(List<SDCaseStatuModel> models, ContextRequest contextRequest)
        {
            List<SDCaseStatu> objs = new List<SDCaseStatu>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                foreach (var obj in objs)
                {
                    BR.SDCaseStatusBR.Instance.Update(obj, contextRequest);

                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }


	#endregion
#region Validation methods	
	    private void Validations(SDCaseStatuModel model) { 
            #region Remote validations

            #endregion
		}

#endregion
		
 		public AuthorizationContext Authorization(AuthorizationContext context)
        {
            OnAuthorization(this,  context );
            return context ;
        }
		public List<SDCaseStatuModel> GetAll() {
            			var bos = BR.SDCaseStatusBR.Instance.GetBy("",
					new SFSdotNet.Framework.My.ContextRequest()
					{
						CustomQuery = new SFSdotNet.Framework.My.CustomQuery()
						{
							OrderBy = "Title",
							SortDirection = SFSdotNet.Framework.Data.SortDirection.Ascending
						}
					});
            			List<SDCaseStatuModel> results = new List<SDCaseStatuModel>();
            SDCaseStatuModel model = null;
            foreach (var bo in bos)
            {
                model = new SDCaseStatuModel();
                model.Bind(bo);
                results.Add(model);
            }
            return results;

        }
        //
        // GET: /SDCaseStatus/
		[MyAuthorize("r", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
		public ActionResult Index()
        {
    		var uiModel = GetContextModel(UIModelContextTypes.ListForm, null);
			ViewBag.UIModel = uiModel;
			uiModel.FilterStart = (string)ViewData["startFilter"];
                    MyEventArgs<UIModel<SDCaseStatuModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseStatuModel>>() { Object = uiModel });

			OnExportActionsCreated(this, (me != null ? me : me = new MyEventArgs<UIModel<SDCaseStatuModel>>() { Object = uiModel }));

            if (me != null)
            {
                uiModel = me.Object;
            }
            if (me == null)
                me = new MyEventArgs<UIModel<SDCaseStatuModel>>() { Object = uiModel };
           
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;


            //return View("ListGen");
			return ResolveView(uiModel);
        }
		[MyAuthorize("r", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
		public ActionResult ListViewGen(string idTab, string fk , string fkValue, string startFilter, ListModes  listmode  = ListModes.SimpleList, PropertyDefinition parentRelationProperty = null, object parentRelationPropertyValue = null )
        {
			ViewData["idTab"] = System.Web.HttpContext.Current.Request.QueryString["idTab"]; 
		 	ViewData["detpop"] = true; // details in popup
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"])) {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"]; 
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
            {
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["startFilter"]))
            {
                ViewData["startFilter"] = Request.QueryString["startFilter"];
            }
			
			UIModel<SDCaseStatuModel> uiModel = GetContextModel(UIModelContextTypes.ListForm, null);

            MyEventArgs<UIModel<SDCaseStatuModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseStatuModel>>() { Object = uiModel });
            if (me == null)
                me = new MyEventArgs<UIModel<SDCaseStatuModel>>() { Object = uiModel };
            uiModel.Properties = GetProperties(uiModel);
            uiModel.ContextType = UIModelContextTypes.ListForm;
             uiModel.FilterStart = (string)ViewData["startFilter"];
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;
			 if (listmode == ListModes.SimpleList)
                return ResolveView(uiModel);
            else
            {
                ViewData["parentRelationProperty"] = parentRelationProperty;
                ViewData["parentRelationPropertyValue"] = parentRelationPropertyValue;
                return PartialView("ListForTagSelectView");
            }
            return ResolveView(uiModel);
        }
		List<PropertyDefinition> _properties = null;

		 protected override List<PropertyDefinition> GetProperties(UIModel uiModel,  params string[] specificProperties)
        { 
            return GetProperties(uiModel, false, null, specificProperties);
        }

		protected override List<PropertyDefinition> GetProperties(UIModel uiModel, bool decripted, Guid? id, params string[] specificProperties)
            {

			bool allProperties = true;    
                if (specificProperties != null && specificProperties.Length > 0)
                {
                    allProperties = false;
                }


			List<CustomProperty> customProperties = new List<CustomProperty>();
			if (_properties == null)
                {
                List<PropertyDefinition> results = new List<PropertyDefinition>();

			string idSDCaseStatu = GetRouteDataOrQueryParam("id");
			if (idSDCaseStatu != null)
			{
				if (!decripted)
                {
					idSDCaseStatu = SFSdotNet.Framework.Entities.Utils.GetPropertyKey(idSDCaseStatu.Replace("-","/"), "GuidCaseStatus");
				}else{
					if (id != null )
						idSDCaseStatu = id.Value.ToString();                

				}
			}

			bool visibleProperty = true;	
			 bool conditionalshow =false;
                if (uiModel.ContextType == UIModelContextTypes.EditForm || uiModel.ContextType == UIModelContextTypes.DisplayForm ||  uiModel.ContextType == UIModelContextTypes.GenericForm )
                    conditionalshow = true;
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidCaseStatus"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidCaseStatus")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 100,
																	
					CustomProperties = customProperties,

                    PropertyName = "GuidCaseStatus",

					 MaxLength = 0,
					IsRequired = true ,
					IsHidden = true,
                    SystemProperty =  SystemProperties.Identifier ,
					IsDefaultProperty = false,
                    SortBy = "GuidCaseStatus",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseStatuResources.GUIDCASESTATUS*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("Title"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "Title")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 101,
																	
					CustomProperties = customProperties,

                    PropertyName = "Title",

					 MaxLength = 255,
					IsRequired = true ,
					IsDefaultProperty = true,
                    SortBy = "Title",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDCaseStatuResources.TITLE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCases"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCaseStatu" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCases.GuidCase")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCases.GuidCase" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCases" });
			

	
	//fk_SdCase_SdCaseStatus
		//if (this.Request.QueryString["fk"] != "SDCases")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 102,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCases/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDCases&fk=SDCaseStatu&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDCaseStatu.GuidCaseStatus = Guid(\"" + idSDCaseStatu +"\")")+ "&fkValue=" + idSDCaseStatu,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCase",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCases",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDCases.BodyContent",
					
	
                    TypeName = "SFSServiceDeskModel.SDCase",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDCases"
                    /*,PropertyDisplayName = Resources.SDCaseStatuResources.SDCASES*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCaseHistories"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDCaseStatu" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCaseHistories.GuidCaseHistory")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCaseHistories.GuidCaseHistory" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCaseHistories" });
			

	
	//fk_SdCaseHistory_SdCaseStatus
		//if (this.Request.QueryString["fk"] != "SDCaseHistories")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 103,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCaseHistories/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDCaseHistories&fk=SDCaseStatu&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDCaseStatu.GuidCaseStatus = Guid(\"" + idSDCaseStatu +"\")")+ "&fkValue=" + idSDCaseStatu,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCaseHistory",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCaseHistories",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDCaseHistories.BodyContent",
					
	
                    TypeName = "SFSServiceDeskModel.SDCaseHistory",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDCaseHistories"
                    /*,PropertyDisplayName = Resources.SDCaseStatuResources.SDCASEHISTORIES*/
                });
		//	}
	
	}
	
				
                    _properties = results;
                    return _properties;
                }
                else {
                    return _properties;
                }
            }

		protected override  UIModel<SDCaseStatuModel> GetByForShow(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, params  object[] extraParams)
        {
			if (Request != null )
				if (!string.IsNullOrEmpty(Request.QueryString["q"]))
					filter = filter + HttpUtility.UrlDecode(Request.QueryString["q"]);
 if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
            }
            var bos = BR.SDCaseStatusBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), contextRequest, extraParams);
			//var bos = BR.SDCaseStatusBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), context, extraParams);
            SDCaseStatuModel model = null;
            List<SDCaseStatuModel> results = new List<SDCaseStatuModel>();
            foreach (var item in bos)
            {
                model = new SDCaseStatuModel();
				model.Bind(item);
				results.Add(model);
            }
            //return results;
			UIModel<SDCaseStatuModel> uiModel = GetContextModel(UIModelContextTypes.Items, null);
            uiModel.Items = results;
			if (Request != null){
				if (SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(Request.RequestContext, "action") == "Download")
				{
					uiModel.ContextType = UIModelContextTypes.ExportDownload;
				}
			}
            Showing(ref uiModel);
            return uiModel;
		}			
		
		//public List<SDCaseStatuModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params  object[] extraParams)
        //{
		//	var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, null, extraParams);
        public override List<SDCaseStatuModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest,  params  object[] extraParams)
        {
            var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
           
            return uiModel.Items;
		
        }
		/*
        [MyAuthorize("r", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir)
        {
			 return GetByJsonBase(filter, pageSize, page, orderBy, orderDir);
        }*/

		  [MyAuthorize("r", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir,ContextRequest contextRequest,  object[] extraParams)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
			 
			 if (this.IsRESTRequest == false)
            {
                return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
            }else
            {
                try
                {
                    return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);

                }
            }
        }
/*		  [MyAuthorize("r", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
       public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }*/
		[MyAuthorize()]
		public ActionResult GetByCount(string filter, ContextRequest contextRequest) {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
           
			
             if (this.IsRESTRequest == true)
            {
                try
                {

                    var result = BR.SDCaseStatusBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);

                   if (Request.QueryString["v"] == "2")
                    {
						return ResolveApiResponse("success", null, null, result);

                        //return Json(new { status = "success", data = result }, JsonRequestBehavior.AllowGet);
                    }else
                    {
                        return Content(result.ToString());

                    }
                }
                catch (Exception ex)
                {
                  //  return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
				  return ResolveApiResponse("error", "exception", ex.ToString(), null);

                }
            }
            else
            {
                var result = BR.SDCaseStatusBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);
                return Content(result.ToString());
            }
		}
		

		[MyAuthorize("r", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
        public ActionResult GetByKeyJson(string id, ContextRequest contextRequest,  bool dec = false)
        {
            return Json(GetByKey(id, null, contextRequest, dec), JsonRequestBehavior.AllowGet);
        }
		public SDCaseStatuModel GetByKey(string id) {
			return GetByKey(id, null,null, false);
       	}
		    public SDCaseStatuModel GetByKey(string id, string includes)
        {
            return GetByKey(id, includes, false);
        }
		 public  SDCaseStatuModel GetByKey(string id, string includes, ContextRequest contextRequest)
        {
            return GetByKey(id, includes, contextRequest, false);
        }
		/*
		  public ActionResult ShowField(string fieldName, string idField) {
		   string safePropertyName = fieldName;
              if (fieldName.StartsWith("Fk"))
              {
                  safePropertyName = fieldName.Substring(2, fieldName.Length - 2);
              }

             SDCaseStatuModel model = new  SDCaseStatuModel();

            UIModel uiModel = GetUIModel(model, new string[] { "NoField-" });
			
				uiModel.Properties = GetProperties(uiModel, safePropertyName);
		uiModel.Properties.ForEach(p=> p.ContextType = uiModel.ContextType );
            uiModel.ContextType = UIModelContextTypes.FilterFields;
            uiModel.OverrideApp = GetOverrideApp();
            uiModel.UseMode = GetUseMode();

            ViewData["uiModel"] = uiModel;
			var prop = uiModel.Properties.FirstOrDefault(p=>p.PropertyName == safePropertyName);
            //if (prop.IsNavigationProperty && prop.IsNavigationPropertyMany == false)
            //{
            //    ViewData["currentProperty"] = uiModel.Properties.FirstOrDefault(p => p.PropertyName != fieldName + "Text");
            //}else if (prop.IsNavigationProperty == false){
                ViewData["currentProperty"] = prop;
           // }
            ((PropertyDefinition)ViewData["currentProperty"]).RemoveLayout = true;
			ViewData["withContainer"] = false;


            return PartialView("GenericField", model);


        }
      */
	public SDCaseStatuModel GetByKey(string id, ContextRequest contextRequest, bool dec)
        {
            return GetByKey(id, null, contextRequest, dec);
        }
        public SDCaseStatuModel GetByKey(string id, string  includes, bool dec)
        {
            return GetByKey(id, includes, null, dec);
        }

        public SDCaseStatuModel GetByKey(string id, string includes, ContextRequest contextRequest, bool dec) {
		             SDCaseStatuModel model = null;
            ControllerEventArgs<SDCaseStatuModel> e = null;
			string objectKey = id.Replace("-","/");
             OnGettingByKey(this, e=  new ControllerEventArgs<SDCaseStatuModel>() { Id = objectKey  });
             bool cancel = false;
             SDCaseStatuModel eItem = null;
             if (e != null)
             {
                 cancel = e.Cancel;
                 eItem = e.Item;
             }
			if (cancel == false && eItem == null)
             {
			Guid guidCaseStatus = Guid.Empty; //new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, "GuidCaseStatus"));
			if (dec)
                 {
                     guidCaseStatus = new Guid(id);
                 }
                 else
                 {
                     guidCaseStatus = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, null));
                 }
			
            
				model = new SDCaseStatuModel();
                  if (contextRequest == null)
                {
                    contextRequest = GetContextRequest();
                }
				var bo = BR.SDCaseStatusBR.Instance.GetByKey(guidCaseStatus, GetUseMode(), contextRequest,  includes);
				 if (bo != null)
                    model.Bind(bo);
                else
                    return null;
			}
             else {
                 model = eItem;
             }
			model.IsNew = false;

            return model;
        }
        // GET: /SDCaseStatus/DetailsGen/5
		[MyAuthorize("r", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
        public ActionResult DetailsGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDCaseStatuResources.ENTITY_PLURAL;
			 #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDCaseStatuModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
            #endregion



			 bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
			//UIModel<SDCaseStatuModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, decripted), decripted, guidId);
			var item = GetByKey(id, null, null, decripted);
			if (item == null)
            {
                 RouteValueDictionary rv = new RouteValueDictionary();
                string usemode = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"usemode");
                string overrideModule = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "overrideModule");
                string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");

                if(!string.IsNullOrEmpty(usemode)){
                    rv.Add("usemode", usemode);
                }
                if(!string.IsNullOrEmpty(overrideModule)){
                    rv.Add("overrideModule", overrideModule);
                }
                if (!string.IsNullOrEmpty(area))
                {
                    rv.Add("area", area);
                }

                return RedirectToAction("Index", rv);
            }
            //
            UIModel<SDCaseStatuModel> uiModel = null;
                uiModel = GetContextModel(UIModelContextTypes.DisplayForm, item, decripted, guidId);



            MyEventArgs<UIModel<SDCaseStatuModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseStatuModel>>() { Object = uiModel });

            if (me != null) {
                uiModel = me.Object;
            }
			
            Showing(ref uiModel);
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			
            //return View("DisplayGen", uiModel.Items[0]);
			return ResolveView(uiModel, uiModel.Items[0]);

        }
		[MyAuthorize("r", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
		public ActionResult DetailsViewGen(string id)
        {

		 bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDCaseStatuModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
           
			if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
 			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
           
        	 //var uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id));
			 
            bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true")
                {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
            UIModel<SDCaseStatuModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, null, decripted), decripted, guidId);
			

            MyEventArgs<UIModel<SDCaseStatuModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDCaseStatuModel>>() { Object = uiModel });

            if (me != null)
            {
                uiModel = me.Object;
            }
            
            Showing(ref uiModel);
            return ResolveView(uiModel, uiModel.Items[0]);
        
        }
        //
        // GET: /SDCaseStatus/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /SDCaseStatus/CreateGen
		[MyAuthorize("c", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
        public ActionResult CreateGen()
        {
			SDCaseStatuModel model = new SDCaseStatuModel();
            model.IsNew = true;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model);

			OnCreateShowing(this, e = new ControllerEventArgs<SDCaseStatuModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }

             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                 ViewData["ispopup"] = true;
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                 ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                 ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

            Showing(ref me);

			return ResolveView(me, me.Items[0]);
        } 
			
		protected override UIModel<SDCaseStatuModel> GetContextModel(UIModelContextTypes formMode, SDCaseStatuModel model)
        {
            return GetContextModel(formMode, model, false, null);
        }
			
		 private UIModel<SDCaseStatuModel> GetContextModel(UIModelContextTypes formMode, SDCaseStatuModel model, bool decript, Guid ? id) {
            UIModel<SDCaseStatuModel> me = new UIModel<SDCaseStatuModel>(true, "SDCaseStatus");
			me.UseMode = GetUseMode();
			me.Controller = this;
			me.OverrideApp = GetOverrideApp();
			me.ContextType = formMode ;
			me.Id = "SDCaseStatu";
			
            me.ModuleKey = "SFSServiceDesk";

			me.ModuleNamespace = "SFS.ServiceDesk";
            me.EntityKey = "SDCaseStatu";
            me.EntitySetName = "SDCaseStatus";

			me.AreaAction = "SFSServiceDesk";
            me.ControllerAction = "SDCaseStatus";
            me.PropertyKeyName = "GuidCaseStatus";

            me.Properties = GetProperties(me, decript, id);
 			
			if (Request != null)
            {
                string actionName = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam( Request.RequestContext, "action");
                if(actionName != null && actionName.ToLower().Contains("create") ){
                    me.IsNew = true;
                }
            }
			 #region Buttons
			 if (Request != null ){
             if (formMode == UIModelContextTypes.DisplayForm || formMode == UIModelContextTypes.EditForm || formMode == UIModelContextTypes.ListForm)
				me.ActionButtons = GetActionButtons(formMode,model != null ?(Request.QueryString["dec"] == "true" ? model.Id : model.SafeKey)  : null, "SFSServiceDesk", "SDCaseStatus", "SDCaseStatu", me.IsNew);

            //me.ActionButtons.Add(new ActionModel() { ActionKey = "return", Title = GlobalMessages.RETURN, Url = System.Web.VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCaseStatus" });
			if (this.HttpContext != null &&  !this.HttpContext.SkipAuthorization){
				//antes this.HttpContext
				me.SetAction("u", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("u", "SDCaseStatu", "SFSServiceDesk"));
				me.SetAction("c", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("c", "SDCaseStatu", "SFSServiceDesk"));
				me.SetAction("d", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("d", "SDCaseStatu", "SFSServiceDesk"));
			
			}else{
				me.SetAction("u", true);
				me.SetAction("c", true);
				me.SetAction("d", true);

			}
            #endregion              
         
            switch (formMode)
            {
                case UIModelContextTypes.DisplayForm:
					//me.TitleForm = SDCaseStatuResources.SDCASESTATUS_DETAILS;
                    me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.MODIFY_DATA;
					 me.Properties.Where(p=>p.PropertyName  != "Id" && p.IsForeignKey == false).ToList().ForEach(p => p.IsHidden = false);

					 me.Properties.Where(p => (p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier) ).ToList().ForEach(p=> me.SetHide(p.PropertyName));

                    break;
                case UIModelContextTypes.EditForm:
				  me.Properties.Where(p=>p.SystemProperty != SystemProperties.Identifier && p.IsForeignKey == false && p.PropertyName != "Id").ToList().ForEach(p => p.IsHidden = false);

					if (model != null)
                    {
						

                        me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.SAVE_DATA;                        
                        me.ActionButtons.First(p => p.ActionKey == "c").Title = GlobalMessages.SAVE_DATA;
						if (model.IsNew ){
							//me.TitleForm = SDCaseStatuResources.SDCASESTATUS_ADD_NEW;
							me.ActionName = "CreateGen";
							me.Properties.RemoveAll(p => p.SystemProperty != null || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));
						}else{
							
							me.ActionName = "EditGen";

							//me.TitleForm = SDCaseStatuResources.SDCASESTATUS_EDIT;
							me.Properties.RemoveAll(p => p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));	
						}
						//me.Properties.Remove(me.Properties.Find(p => p.PropertyName == "UpdatedDate"));
					
					}
                    break;
                case UIModelContextTypes.FilterFields:
                    break;
                case UIModelContextTypes.GenericForm:
                    break;
                case UIModelContextTypes.Items:
				//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "Title") != null){
						me.Properties.Find(p => p.PropertyName == "Title").IsHidden = false;
					 }
					 
                    
					

						 if (me.Properties.Find(p => p.PropertyName == "GuidCaseStatus") != null){
						me.Properties.Find(p => p.PropertyName == "GuidCaseStatus").IsHidden = false;
					 }
					 
                    
					


                  


					//}
                    break;
                case UIModelContextTypes.ListForm:
					PropertyDefinition propFinded = null;
					//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "Title") != null){
						me.Properties.Find(p => p.PropertyName == "Title").IsHidden = false;
					 }
					
					me.PrincipalActionName = "GetByJson";
					//}
					//me.TitleForm = SDCaseStatuResources.SDCASESTATUS_LIST;
                    break;
                default:
                    break;
            }
            	this.SetDefaultProperties(me);
			}
			if (model != null )
            	me.Items.Add(model);
            return me;
        }
		// GET: /SDCaseStatus/CreateViewGen
		[MyAuthorize("c", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
        public ActionResult CreateViewGen()
        {
				SDCaseStatuModel model = new SDCaseStatuModel();
            model.IsNew = true;
			e= null;
			OnCreateShowing(this, e = new ControllerEventArgs<SDCaseStatuModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }
			
            var me = GetContextModel(UIModelContextTypes.EditForm, model);

			me.IsPartialView = true;	
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
            {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                me.Properties.Find(p => p.PropertyName == ViewData["fk"].ToString()).IsReadOnly = true;
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
			
      
            //me.Items.Add(model);
            Showing(ref me);
            return ResolveView(me, me.Items[0]);
        }
		protected override  void GettingExtraData(ref UIModel<SDCaseStatuModel> uiModel)
        {

            MyEventArgs<UIModel<SDCaseStatuModel>> me = null;
            OnGettingExtraData(this, me = new MyEventArgs<UIModel<SDCaseStatuModel>>() { Object = uiModel });
            //bool maybeAnyReplaced = false; 
            if (me != null)
            {
                uiModel = me.Object;
                //maybeAnyReplaced = true;
            }
           
			bool canFill = false;
			 string query = null ;
            bool isFK = false;
			PropertyDefinition prop =null;
			var contextRequest = this.GetContextRequest();
            contextRequest.CustomParams.Add(new CustomParam() { Name="ui", Value= SDCaseStatu.EntityName });

                        

        }
		private void Showing(ref UIModel<SDCaseStatuModel> uiModel) {
          	
			MyEventArgs<UIModel<SDCaseStatuModel>> me = new MyEventArgs<UIModel<SDCaseStatuModel>>() { Object = uiModel };
			 OnVirtualLayoutSettings(this, me);


            OnShowing(this, me);

			
			if ((Request != null && Request.QueryString["allFields"] == "1") || Request == null )
			{
				me.Object.Properties.ForEach(p=> p.IsHidden = false);
            }
            if (me != null)
            {
                uiModel = me.Object;
            }
          


			 if (uiModel.ContextType == UIModelContextTypes.EditForm)
			    GettingExtraData(ref uiModel);
            ViewData["UIModel"] = uiModel;

        }
        //
        // POST: /SDCaseStatus/Create
		[MyAuthorize("c", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
        [HttpPost]
		[ValidateInput(false)] 
        public ActionResult CreateGen(SDCaseStatuModel  model,  ContextRequest contextRequest)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
		 	e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDCaseStatuModel>() { Item = model });
           
		  	if (!ModelState.IsValid) {
				model.IsNew = true;
				var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
                 if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                        ViewData["ispopup"] = true;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
                    return ResolveView(me, model);
            }
            try
            {
				if (model.GuidCaseStatus == null || model.GuidCaseStatus.ToString().Contains("000000000"))
				model.GuidCaseStatus = Guid.NewGuid();
	
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnCreating(this, e = new ControllerEventArgs<SDCaseStatuModel>() { Item = model });
                if (e != null) {
                   if (e.Cancel && e.RedirectValues.Count > 0){
                        RouteValueDictionary rv = new RouteValueDictionary();
                        if (e.RedirectValues["area"] != null ){
                            rv.Add("area", e.RedirectValues["area"].ToString());
                        }
                        foreach (var item in e.RedirectValues.Where(p=>p.Key != "area" && p.Key != "controller" &&  p.Key != "action" ))
	                    {
		                    rv.Add(item.Key, item.Value);
	                    }

                        //if (e.RedirectValues["action"] != null && e.RedirectValues["controller"] != null && e.RedirectValues["area"] != null )
                        return RedirectToAction(e.RedirectValues["action"].ToString(), e.RedirectValues["controller"].ToString(), rv );


                        
                    }else if (e.Cancel && e.ActionResult != null )
                        return e.ActionResult;  
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				if (contextRequest == null || contextRequest.Company == null){
					contextRequest = GetContextRequest();
					
				}
                if (!cancel)
                	model.Bind(SDCaseStatusBR.Instance.Create(model.GetBusinessObject(), contextRequest ));
				OnCreated(this, e = new ControllerEventArgs<SDCaseStatuModel>() { Item = model });
                 if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                        return ResolveApiResponse("success", null, null, null);

                    }
                }
				 
				 if (e != null )
					if (e.ActionResult != null)
                    	replaceResult = true;		
				if (!replaceResult)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))
                    {
                        ViewData["__continue"] = true;
                    }
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"]) &&  string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
                        popupextra.Add("id", model.SafeKey);
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                       {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                            popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"area"));
                            popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                            popupextra.Add("action", actionDetails);
                       if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
                    {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))

                        {
                            var popupextra = GetRouteData();
                            popupextra.Add("id", model.SafeKey);
                            return RedirectToAction("EditViewGen", popupextra);
                        }
                        else
                        {
                            return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.ADD_DONE));
                        }
                    }        			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                        return Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]);
                    else{

							RouteValueDictionary popupextra = null; 
							if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"])){
                            popupextra = GetRouteData();
							 string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
                            if (!string.IsNullOrEmpty(area))
                                popupextra.Add("area", area);
                            
                            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"])) {
								popupextra.Add("id", model.SafeKey);
                                return RedirectToAction("EditGen", popupextra);

                            }else{
								
                            return RedirectToAction("Index", popupextra);
							}
							}else{
								return Content("ok");
							}
                        }
						 }
                else {
                    return e.ActionResult;
                    }
				}
            catch(Exception ex)
            {
					  SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        throw ex;
                    }
                    else
                    {
                       // return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
					   return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
                SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                model.IsNew = true;
                var me = GetContextModel(UIModelContextTypes.EditForm, model, true, model.GuidCaseStatus);
                Showing(ref me);
                if (isPopUp)
                {
                    
                        ViewData["ispopup"] = isPopUp;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
					if (Request != null)
						return ResolveView(me, model);
					else
						return Content("ok");
            }
        }        
        //
        // GET: /SDCaseStatus/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }
			
		
		[MyAuthorize("u", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
		[MvcSiteMapNode(Area="SFSServiceDesk", Title="sss", Clickable=false, ParentKey = "SFSServiceDesk_SDCaseStatu_List")]
		public ActionResult EditGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDCaseStatuResources.ENTITY_SINGLE;		 	
  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDCaseStatuModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
            SDCaseStatuModel model = null;
            // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
			bool dec = false;
            Guid ? idGuidDecripted = null ;
            if (Request != null && Request.QueryString["dec"] == "true")
            {
                dec = true;
                idGuidDecripted = Guid.Parse(id);
            }

            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model,dec,idGuidDecripted);
            Showing(ref me);


            if (!replaceResult)
            {
                 //return View("EditGen", me.Items[0]);
				 return ResolveView(me, me.Items[0]);
            }
            else {
                return e.ActionResult;
            }
        }
			[MyAuthorize("u", "SDCaseStatu","SFSServiceDesk", typeof(SDCaseStatusController))]
		public ActionResult EditViewGen(string id)
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

					  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDCaseStatuModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
			
            SDCaseStatuModel model = null;
			 bool dec = false;
            Guid? guidId = null ;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                dec = true;
                guidId = Guid.Parse(id);
            }
            // si fue implementado el método parcial y no se ha decidido suspender la acción
            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
            var me = GetContextModel(UIModelContextTypes.EditForm, model, dec, guidId);
            Showing(ref me);

            return ResolveView(me, model);
        }
		[MyAuthorize("u", "SDCaseStatu",  "SFSServiceDesk", typeof(SDCaseStatusController))]
		[HttpPost]
		[ValidateInput(false)] 
		        public ActionResult EditGen(SDCaseStatuModel model)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
			e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDCaseStatuModel>() { Item = model });
           
            if (!ModelState.IsValid)
            {
			   	var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
			
				if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"])){
                	ViewData["ispopup"] = true;
					return ResolveView(me, model);
				}
				else
					return ResolveView(me, model);
            }
            try
            {
			
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnEditing(this, e = new ControllerEventArgs<SDCaseStatuModel>() { Item = model });
                if (e != null) {
                    if (e.Cancel && e.ActionResult != null)
                        return e.ActionResult;
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				ContextRequest context = new ContextRequest();
                context.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;

                SDCaseStatu resultObj = null;
			    if (!cancel)
                	resultObj = SDCaseStatusBR.Instance.Update(model.GetBusinessObject(), GetContextRequest());
				
				OnEdited(this, e = new ControllerEventArgs<SDCaseStatuModel>() { Item =   new SDCaseStatuModel(resultObj) });
				if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                         return ResolveApiResponse("success", null, null, null);
                    }
                }
				
				if (e != null && e.ActionResult != null) replaceResult = true; 

                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Content("ok");
                }
                else
                {
				if (!replaceResult)
                {
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"])  && string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
						 if (Request != null && Request.QueryString["dec"] == "true")
                        {
                            popupextra.Add("id", model.Id);
                        }
                        else
                        {
							popupextra.Add("id", model.SafeKey);

							
                        }
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                        {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                        popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area"));
                        popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                        popupextra.Add("action", actionDetails);
                        if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
					if (isPopUp)
						return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.UPDATE_DONE));
        			    string returnUrl = null;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"])) {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.Form["ReturnAfter"];
                        else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"];
                    }
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else{
		RouteValueDictionary popupextra = null; 
						 if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"]))
                            {
							
							popupextra = GetRouteData();
							string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
							if (!string.IsNullOrEmpty(area))
								popupextra.Add("area", area);

							return RedirectToAction("Index", popupextra);
						}else{
							return Content("ok");
						}
						}
				 }
                else {
                    return e.ActionResult;
				}
                }		
            }
          catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content(ex.ToString());
                    }
                    else
                    {
                        //return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
						 return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
			    if (isPopUp)
                {
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(ex.Message));
                    
                }
                else
                {
                    SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                    
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else {
						  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
							ViewData["ispopup"] = true;
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
							ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
							ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

						var me = GetContextModel(UIModelContextTypes.EditForm, model);
						Showing(ref me);

						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
						{
							ViewData["ispopup"] = true;
							return ResolveView(me, model);
						}
						else
							return ResolveView(me, model);

						
					}
				}
            }
        }
        //
        // POST: /SDCaseStatus/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //  Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SDCaseStatus/Delete/5
        
		[MyAuthorize("d", "SDCaseStatu", "SFSServiceDesk", typeof(SDCaseStatusController))]
		[HttpDelete]
        public ActionResult DeleteGen(string objectKey, string extraParams)
        {
            try
            {
					
			
				Guid guidCaseStatus = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey.Replace("-", "/"), "GuidCaseStatus")); 
                BO.SDCaseStatu entity = new BO.SDCaseStatu() { GuidCaseStatus = guidCaseStatus };

                BR.SDCaseStatusBR.Instance.Delete(entity, GetContextRequest());               
                return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.DELETE_DONE));

            }
            catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null)
                    {
                        message = ex.Data["usermessage"].ToString();
                    }

                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }
            }
        }
		/*[MyAuthorize()]
		public FileMediaResult Download(string query, bool? allSelected = false,  string selected = null , string orderBy = null , string direction = null , string format = null , string actionKey=null )
        {
			
            List<Guid> keysSelected1 = new List<Guid>();
            if (!string.IsNullOrEmpty(selected)) {
                foreach (var keyString in selected.Split(char.Parse("|")))
                {
				
                    keysSelected1.Add(Guid.Parse(keyString));
                }
            }
				
            query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(query, allSelected.Value, selected, "GuidCaseStatus");
            MyEventArgs<ContextActionModel<SDCaseStatuModel>> eArgs = null;
            List<SDCaseStatuModel> results = GetBy(query, null, null, orderBy, direction, GetContextRequest(), keysSelected1);
            OnDownloading(this, eArgs = new MyEventArgs<ContextActionModel<SDCaseStatuModel>>() { Object = new ContextActionModel<SDCaseStatuModel>() { Query = query, SelectedItems = results, Selected=selected, SelectAll = allSelected.Value, Direction = direction , OrderBy = orderBy, ActionKey=actionKey  } });

            if (eArgs != null)
            {
                if (eArgs.Object.Result != null)
                    return (FileMediaResult)eArgs.Object.Result;
            }
            

            return (new FeaturesController()).ExportDownload(typeof(SDCaseStatuModel), results, format, this.GetUIPluralText("SFSServiceDesk", "SDCaseStatu"));
            
        }
			*/
		
		[HttpPost]
        public ActionResult CustomActionExecute(ContextActionModel model) {
		 try
            {
			//List<Guid> keysSelected1 = new List<Guid>();
			List<object> keysSelected1 = new List<object>();
            if (!string.IsNullOrEmpty(model.Selected))
            {
                foreach (var keyString in model.Selected.Split(char.Parse(",")))
                {
				
				keysSelected1.Add(Guid.Parse(keyString.Split(char.Parse("|"))[0]));
                        
                    

			
                }
            }
			DataAction dataAction = DataAction.GetDataAction(Request);
			 model.Selected = dataAction.Selected;

            model.Query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(dataAction.Query, dataAction.AllSelected, dataAction.Selected, "GuidCaseStatus");
           
            
			
			#region implementaci�n de m�todo parcial
            bool replaceResult = false;
            MyEventArgs<ContextActionModel<SDCaseStatuModel>> actionEventArgs = null;
           
			if (model.ActionKey != "deletemany" && model.ActionKey != "deleterelmany" && model.ActionKey != "updateRel" &&  model.ActionKey != "delete-relation-fk" && model.ActionKey != "restore" )
			{
				ContextRequest context = SFSdotNet.Framework.My.Context.BuildContextRequestSafe(System.Web.HttpContext.Current);
				context.UseMode = dataAction.Usemode;

				if (model.IsBackground)
				{
					System.Threading.Tasks.Task.Run(() => 
						OnCustomActionExecutingBackground(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDCaseStatuModel>>() { Object = new ContextActionModel<SDCaseStatuModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } })
					);
				}
				else
				{
					OnCustomActionExecuting(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDCaseStatuModel>>() {  Object = new ContextActionModel<SDCaseStatuModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } });
				}
			}
            List<SDCaseStatuModel> results = null;
	
			if (model.ActionKey == "deletemany") { 
				
				BR.SDCaseStatusBR.Instance.Delete(model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());

            }
	
            else if (model.ActionKey == "updateRel" || model.ActionKey == "delete-relation-fk" || model.ActionKey == "updateRel-proxyMany")
            {
               try {
                   string valueForUpdate = null;
				   string propForUpdate = null;
				   if (!string.IsNullOrEmpty(Request.Params["propertyForUpdate"])){
						propForUpdate = Request.Params["propertyForUpdate"];
				   }
				    if (string.IsNullOrEmpty(propForUpdate) && !string.IsNullOrEmpty(Request.QueryString["propertyForUpdate"]))
                   {
                       propForUpdate = Request.QueryString["propertyForUpdate"];
                   }
                    if (model.ActionKey != "delete-relation-fk")
                    {
                        valueForUpdate = Request.QueryString["valueForUpdate"];
                    }
                    BR.SDCaseStatusBR.Instance.UpdateAssociation(propForUpdate, valueForUpdate, model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());
					
                    if (model.ActionKey == "delete-relation-fk")
                    {
                        MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]);

                        return PartialView("ResultMessageView", message);
                    }
                    else
                    {
                        return Content("ok");
                    }
       
          
                }
                catch (Exception ex)
                {
				        SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
           
                }
            
            }
		
                if (actionEventArgs == null && !model.IsBackground)
                {
                    //if (model.ActionKey != "deletemany"  && model.ActionKey != "deleterelmany")
                    //{
                     //   throw new NotImplementedException("");
                    //}
                }
                else
                {
					if (model.IsBackground == false )
						 replaceResult = actionEventArgs.Object.Result is ActionResult /*actionEventArgs.Object.ReplaceResult*/;
                }
                #endregion
                if (!replaceResult)
                {
                    if (Request != null && Request.IsAjaxRequest())
                    {
						MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]) ;
                        if (model.IsBackground )
                            message.Message = GlobalMessages.THE_PROCESS_HAS_BEEN_STARTED;
                        
                        return PartialView("ResultMessageView", message);                    
					}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return (ActionResult)actionEventArgs.Object.Result;
                }
            }
            catch (Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null) {
                        message = ex.Data["usermessage"].ToString();
                    }
					 SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }

            }
        }
        //
        // POST: /SDCaseStatus/Delete/5
        
			
	
    }
}
namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
	using SFS.ServiceDesk.Web.Mvc.Models.SDFiles;

    public partial class SDFilesController : SFS.ServiceDesk.Web.Mvc.ControllerBase<Models.SDFiles.SDFileModel>
    {

       


	#region partial methods
        ControllerEventArgs<Models.SDFiles.SDFileModel> e = null;
        partial void OnValidating(object sender, ControllerEventArgs<Models.SDFiles.SDFileModel> e);
        partial void OnGettingExtraData(object sender, MyEventArgs<UIModel<Models.SDFiles.SDFileModel>> e);
        partial void OnCreating(object sender, ControllerEventArgs<Models.SDFiles.SDFileModel> e);
        partial void OnCreated(object sender, ControllerEventArgs<Models.SDFiles.SDFileModel> e);
        partial void OnEditing(object sender, ControllerEventArgs<Models.SDFiles.SDFileModel> e);
        partial void OnEdited(object sender, ControllerEventArgs<Models.SDFiles.SDFileModel> e);
        partial void OnDeleting(object sender, ControllerEventArgs<Models.SDFiles.SDFileModel> e);
        partial void OnDeleted(object sender, ControllerEventArgs<Models.SDFiles.SDFileModel> e);
    	partial void OnShowing(object sender, MyEventArgs<UIModel<Models.SDFiles.SDFileModel>> e);
    	partial void OnGettingByKey(object sender, ControllerEventArgs<Models.SDFiles.SDFileModel> e);
        partial void OnTaken(object sender, ControllerEventArgs<Models.SDFiles.SDFileModel> e);
       	partial void OnCreateShowing(object sender, ControllerEventArgs<Models.SDFiles.SDFileModel> e);
		partial void OnEditShowing(object sender, ControllerEventArgs<Models.SDFiles.SDFileModel> e);
		partial void OnDetailsShowing(object sender, ControllerEventArgs<Models.SDFiles.SDFileModel> e);
 		partial void OnActionsCreated(object sender, MyEventArgs<UIModel<Models.SDFiles.SDFileModel >> e);
		partial void OnCustomActionExecuting(object sender, MyEventArgs<ContextActionModel<Models.SDFiles.SDFileModel>> e);
		partial void OnCustomActionExecutingBackground(object sender, MyEventArgs<ContextActionModel<Models.SDFiles.SDFileModel>> e);
        partial void OnDownloading(object sender, MyEventArgs<ContextActionModel<Models.SDFiles.SDFileModel>> e);
      	partial void OnAuthorization(object sender, AuthorizationContext context);
		 partial void OnFilterShowing(object sender, MyEventArgs<UIModel<Models.SDFiles.SDFileModel >> e);
         partial void OnSummaryOperationShowing(object sender, MyEventArgs<UIModel<Models.SDFiles.SDFileModel>> e);

        partial void OnExportActionsCreated(object sender, MyEventArgs<UIModel<Models.SDFiles.SDFileModel>> e);


		protected override void OnVirtualFilterShowing(object sender, MyEventArgs<UIModel<SDFileModel>> e)
        {
            OnFilterShowing(sender, e);
        }
		 public override void OnVirtualExportActionsCreated(object sender, MyEventArgs<UIModel<SDFileModel>> e)
        {
            OnExportActionsCreated(sender, e);
        }
        public override void OnVirtualDownloading(object sender, MyEventArgs<ContextActionModel<SDFileModel>> e)
        {
            OnDownloading(sender, e);
        }
        public override void OnVirtualShowing(object sender, MyEventArgs<UIModel<SDFileModel>> e)
        {
            OnShowing(sender, e);
        }

	#endregion
	#region API
	 public override ActionResult ApiCreateGen(SDFileModel model, ContextRequest contextRequest)
        {
            return CreateGen(model, contextRequest);
        }

              public override ActionResult ApiGetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJson(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }
        public override ActionResult ApiGetByKeyJson(string id, ContextRequest contextRequest)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
            return  GetByKeyJson(id, contextRequest, true);
        }
      
		 public override ActionResult ApiGetByCount(string filter, ContextRequest contextRequest)
        {
            return GetByCount(filter, contextRequest);
        }
         protected override ActionResult ApiDeleteGen(List<SDFileModel> models, ContextRequest contextRequest)
        {
            List<SDFile> objs = new List<SDFile>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                BR.SDFilesBR.Instance.DeleteBulk(objs, contextRequest);
                if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("success", null, null, null);

                }
                else
                {
                    return Content("ok");

                }
            }
            catch (Exception ex)
            {
               if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "error", reason = "error", message= ex.ToString() }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("error", "exception", ex.ToString(), null );

                }
                else
                {
                    return Json(ex.ToString(), JsonRequestBehavior.AllowGet);

                }
            }
        }
        protected override ActionResult ApiUpdateGen(List<SDFileModel> models, ContextRequest contextRequest)
        {
            List<SDFile> objs = new List<SDFile>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                foreach (var obj in objs)
                {
                    BR.SDFilesBR.Instance.Update(obj, contextRequest);

                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }


	#endregion
#region Validation methods	
	    private void Validations(SDFileModel model) { 
            #region Remote validations

            #endregion
		}

#endregion
		
 		public AuthorizationContext Authorization(AuthorizationContext context)
        {
            OnAuthorization(this,  context );
            return context ;
        }
		public List<SDFileModel> GetAll() {
            			var bos = BR.SDFilesBR.Instance.GetBy("",
					new SFSdotNet.Framework.My.ContextRequest()
					{
						CustomQuery = new SFSdotNet.Framework.My.CustomQuery()
						{
							OrderBy = "FileName",
							SortDirection = SFSdotNet.Framework.Data.SortDirection.Ascending
						}
					});
            			List<SDFileModel> results = new List<SDFileModel>();
            SDFileModel model = null;
            foreach (var bo in bos)
            {
                model = new SDFileModel();
                model.Bind(bo);
                results.Add(model);
            }
            return results;

        }
        //
        // GET: /SDFiles/
		[MyAuthorize("r", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
		public ActionResult Index()
        {
    		var uiModel = GetContextModel(UIModelContextTypes.ListForm, null);
			ViewBag.UIModel = uiModel;
			uiModel.FilterStart = (string)ViewData["startFilter"];
                    MyEventArgs<UIModel<SDFileModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDFileModel>>() { Object = uiModel });

			OnExportActionsCreated(this, (me != null ? me : me = new MyEventArgs<UIModel<SDFileModel>>() { Object = uiModel }));

            if (me != null)
            {
                uiModel = me.Object;
            }
            if (me == null)
                me = new MyEventArgs<UIModel<SDFileModel>>() { Object = uiModel };
           
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;


            //return View("ListGen");
			return ResolveView(uiModel);
        }
		[MyAuthorize("r", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
		public ActionResult ListViewGen(string idTab, string fk , string fkValue, string startFilter, ListModes  listmode  = ListModes.SimpleList, PropertyDefinition parentRelationProperty = null, object parentRelationPropertyValue = null )
        {
			ViewData["idTab"] = System.Web.HttpContext.Current.Request.QueryString["idTab"]; 
		 	ViewData["detpop"] = true; // details in popup
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"])) {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"]; 
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
            {
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["startFilter"]))
            {
                ViewData["startFilter"] = Request.QueryString["startFilter"];
            }
			
			UIModel<SDFileModel> uiModel = GetContextModel(UIModelContextTypes.ListForm, null);

            MyEventArgs<UIModel<SDFileModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDFileModel>>() { Object = uiModel });
            if (me == null)
                me = new MyEventArgs<UIModel<SDFileModel>>() { Object = uiModel };
            uiModel.Properties = GetProperties(uiModel);
            uiModel.ContextType = UIModelContextTypes.ListForm;
             uiModel.FilterStart = (string)ViewData["startFilter"];
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;
			 if (listmode == ListModes.SimpleList)
                return ResolveView(uiModel);
            else
            {
                ViewData["parentRelationProperty"] = parentRelationProperty;
                ViewData["parentRelationPropertyValue"] = parentRelationPropertyValue;
                return PartialView("ListForTagSelectView");
            }
            return ResolveView(uiModel);
        }
		List<PropertyDefinition> _properties = null;

		 protected override List<PropertyDefinition> GetProperties(UIModel uiModel,  params string[] specificProperties)
        { 
            return GetProperties(uiModel, false, null, specificProperties);
        }

		protected override List<PropertyDefinition> GetProperties(UIModel uiModel, bool decripted, Guid? id, params string[] specificProperties)
            {

			bool allProperties = true;    
                if (specificProperties != null && specificProperties.Length > 0)
                {
                    allProperties = false;
                }


			List<CustomProperty> customProperties = new List<CustomProperty>();
			if (_properties == null)
                {
                List<PropertyDefinition> results = new List<PropertyDefinition>();

			string idSDFile = GetRouteDataOrQueryParam("id");
			if (idSDFile != null)
			{
				if (!decripted)
                {
					idSDFile = SFSdotNet.Framework.Entities.Utils.GetPropertyKey(idSDFile.Replace("-","/"), "GuidFile");
				}else{
					if (id != null )
						idSDFile = id.Value.ToString();                

				}
			}

			bool visibleProperty = true;	
			 bool conditionalshow =false;
                if (uiModel.ContextType == UIModelContextTypes.EditForm || uiModel.ContextType == UIModelContextTypes.DisplayForm ||  uiModel.ContextType == UIModelContextTypes.GenericForm )
                    conditionalshow = true;
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidFile"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidFile")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 100,
																	
					CustomProperties = customProperties,

                    PropertyName = "GuidFile",

					 MaxLength = 0,
					IsRequired = true ,
					IsHidden = true,
                    SystemProperty =  SystemProperties.Identifier ,
					IsDefaultProperty = false,
                    SortBy = "GuidFile",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDFileResources.GUIDFILE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("FileName"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "FileName")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 101,
																	
					CustomProperties = customProperties,

                    PropertyName = "FileName",

					 MaxLength = 255,
					IsRequired = true ,
					IsDefaultProperty = true,
                    SortBy = "FileName",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDFileResources.FILENAME*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("FileType"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "FileType")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 102,
																	
					CustomProperties = customProperties,

                    PropertyName = "FileType",

					 MaxLength = 255,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "FileType",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDFileResources.FILETYPE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("FileSize"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "FileSize")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 103,
																	
					CustomProperties = customProperties,

                    PropertyName = "FileSize",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "FileSize",
					
	
                    TypeName = "Int64",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDFileResources.FILESIZE*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("FileData"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "FileData")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 104,
																	
					CustomProperties = customProperties,

                    PropertyName = "FileData",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "FileData",
					
	
                    TypeName = "Binary",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDFileResources.FILEDATA*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("StorageLocation"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "StorageLocation")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 105,
																	
					CustomProperties = customProperties,

                    PropertyName = "StorageLocation",

					 MaxLength = 255,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "StorageLocation",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDFileResources.STORAGELOCATION*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCaseFiles"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDFile" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCaseFiles.GuidCasefile")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCaseFiles.GuidCasefile" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCaseFiles" });
			

	
	//fk_SdCaseFile_SdFile
		//if (this.Request.QueryString["fk"] != "SDCaseFiles")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 106,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCaseFiles/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDCaseFiles&fk=SDFile&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDFile.GuidFile = Guid(\"" + idSDFile +"\")")+ "&fkValue=" + idSDFile,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCaseFile",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCaseFiles",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDCaseFiles.GuidCasefile",
					
	
                    TypeName = "SFSServiceDeskModel.SDCaseFile",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDCaseFiles"
                    /*,PropertyDisplayName = Resources.SDFileResources.SDCASEFILES*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCaseHistoryFiles"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDFile" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCaseHistoryFiles.GuidCasehistoryFile")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCaseHistoryFiles.GuidCasehistoryFile" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCaseHistoryFiles" });
			

	
	//fk_SdCaseHistoryFile_SdFile
		//if (this.Request.QueryString["fk"] != "SDCaseHistoryFiles")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 107,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCaseHistoryFiles/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDCaseHistoryFiles&fk=SDFile&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDFile.GuidFile = Guid(\"" + idSDFile +"\")")+ "&fkValue=" + idSDFile,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCaseHistoryFile",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCaseHistoryFiles",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDCaseHistoryFiles.GuidCasehistoryFile",
					
	
                    TypeName = "SFSServiceDeskModel.SDCaseHistoryFile",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDCaseHistoryFiles"
                    /*,PropertyDisplayName = Resources.SDFileResources.SDCASEHISTORYFILES*/
                });
		//	}
	
	}
	
				
                    _properties = results;
                    return _properties;
                }
                else {
                    return _properties;
                }
            }

		protected override  UIModel<SDFileModel> GetByForShow(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, params  object[] extraParams)
        {
			if (Request != null )
				if (!string.IsNullOrEmpty(Request.QueryString["q"]))
					filter = filter + HttpUtility.UrlDecode(Request.QueryString["q"]);
 if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
            }
            var bos = BR.SDFilesBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), contextRequest, extraParams);
			//var bos = BR.SDFilesBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), context, extraParams);
            SDFileModel model = null;
            List<SDFileModel> results = new List<SDFileModel>();
            foreach (var item in bos)
            {
                model = new SDFileModel();
				model.Bind(item);
				results.Add(model);
            }
            //return results;
			UIModel<SDFileModel> uiModel = GetContextModel(UIModelContextTypes.Items, null);
            uiModel.Items = results;
			if (Request != null){
				if (SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(Request.RequestContext, "action") == "Download")
				{
					uiModel.ContextType = UIModelContextTypes.ExportDownload;
				}
			}
            Showing(ref uiModel);
            return uiModel;
		}			
		
		//public List<SDFileModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params  object[] extraParams)
        //{
		//	var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, null, extraParams);
        public override List<SDFileModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest,  params  object[] extraParams)
        {
            var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
           
            return uiModel.Items;
		
        }
		/*
        [MyAuthorize("r", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir)
        {
			 return GetByJsonBase(filter, pageSize, page, orderBy, orderDir);
        }*/

		  [MyAuthorize("r", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir,ContextRequest contextRequest,  object[] extraParams)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
			 
			 if (this.IsRESTRequest == false)
            {
                return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
            }else
            {
                try
                {
                    return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);

                }
            }
        }
/*		  [MyAuthorize("r", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
       public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }*/
		[MyAuthorize()]
		public ActionResult GetByCount(string filter, ContextRequest contextRequest) {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
           
			
             if (this.IsRESTRequest == true)
            {
                try
                {

                    var result = BR.SDFilesBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);

                   if (Request.QueryString["v"] == "2")
                    {
						return ResolveApiResponse("success", null, null, result);

                        //return Json(new { status = "success", data = result }, JsonRequestBehavior.AllowGet);
                    }else
                    {
                        return Content(result.ToString());

                    }
                }
                catch (Exception ex)
                {
                  //  return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
				  return ResolveApiResponse("error", "exception", ex.ToString(), null);

                }
            }
            else
            {
                var result = BR.SDFilesBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);
                return Content(result.ToString());
            }
		}
		

		[MyAuthorize("r", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
        public ActionResult GetByKeyJson(string id, ContextRequest contextRequest,  bool dec = false)
        {
            return Json(GetByKey(id, null, contextRequest, dec), JsonRequestBehavior.AllowGet);
        }
		public SDFileModel GetByKey(string id) {
			return GetByKey(id, null,null, false);
       	}
		    public SDFileModel GetByKey(string id, string includes)
        {
            return GetByKey(id, includes, false);
        }
		 public  SDFileModel GetByKey(string id, string includes, ContextRequest contextRequest)
        {
            return GetByKey(id, includes, contextRequest, false);
        }
		/*
		  public ActionResult ShowField(string fieldName, string idField) {
		   string safePropertyName = fieldName;
              if (fieldName.StartsWith("Fk"))
              {
                  safePropertyName = fieldName.Substring(2, fieldName.Length - 2);
              }

             SDFileModel model = new  SDFileModel();

            UIModel uiModel = GetUIModel(model, new string[] { "NoField-" });
			
				uiModel.Properties = GetProperties(uiModel, safePropertyName);
		uiModel.Properties.ForEach(p=> p.ContextType = uiModel.ContextType );
            uiModel.ContextType = UIModelContextTypes.FilterFields;
            uiModel.OverrideApp = GetOverrideApp();
            uiModel.UseMode = GetUseMode();

            ViewData["uiModel"] = uiModel;
			var prop = uiModel.Properties.FirstOrDefault(p=>p.PropertyName == safePropertyName);
            //if (prop.IsNavigationProperty && prop.IsNavigationPropertyMany == false)
            //{
            //    ViewData["currentProperty"] = uiModel.Properties.FirstOrDefault(p => p.PropertyName != fieldName + "Text");
            //}else if (prop.IsNavigationProperty == false){
                ViewData["currentProperty"] = prop;
           // }
            ((PropertyDefinition)ViewData["currentProperty"]).RemoveLayout = true;
			ViewData["withContainer"] = false;


            return PartialView("GenericField", model);


        }
      */
	public SDFileModel GetByKey(string id, ContextRequest contextRequest, bool dec)
        {
            return GetByKey(id, null, contextRequest, dec);
        }
        public SDFileModel GetByKey(string id, string  includes, bool dec)
        {
            return GetByKey(id, includes, null, dec);
        }

        public SDFileModel GetByKey(string id, string includes, ContextRequest contextRequest, bool dec) {
		             SDFileModel model = null;
            ControllerEventArgs<SDFileModel> e = null;
			string objectKey = id.Replace("-","/");
             OnGettingByKey(this, e=  new ControllerEventArgs<SDFileModel>() { Id = objectKey  });
             bool cancel = false;
             SDFileModel eItem = null;
             if (e != null)
             {
                 cancel = e.Cancel;
                 eItem = e.Item;
             }
			if (cancel == false && eItem == null)
             {
			Guid guidFile = Guid.Empty; //new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, "GuidFile"));
			if (dec)
                 {
                     guidFile = new Guid(id);
                 }
                 else
                 {
                     guidFile = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, null));
                 }
			
            
				model = new SDFileModel();
                  if (contextRequest == null)
                {
                    contextRequest = GetContextRequest();
                }
				var bo = BR.SDFilesBR.Instance.GetByKey(guidFile, GetUseMode(), contextRequest,  includes);
				 if (bo != null)
                    model.Bind(bo);
                else
                    return null;
			}
             else {
                 model = eItem;
             }
			model.IsNew = false;

            return model;
        }
        // GET: /SDFiles/DetailsGen/5
		[MyAuthorize("r", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
        public ActionResult DetailsGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDFileResources.ENTITY_PLURAL;
			 #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDFileModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
            #endregion



			 bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
			//UIModel<SDFileModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, decripted), decripted, guidId);
			var item = GetByKey(id, null, null, decripted);
			if (item == null)
            {
                 RouteValueDictionary rv = new RouteValueDictionary();
                string usemode = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"usemode");
                string overrideModule = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "overrideModule");
                string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");

                if(!string.IsNullOrEmpty(usemode)){
                    rv.Add("usemode", usemode);
                }
                if(!string.IsNullOrEmpty(overrideModule)){
                    rv.Add("overrideModule", overrideModule);
                }
                if (!string.IsNullOrEmpty(area))
                {
                    rv.Add("area", area);
                }

                return RedirectToAction("Index", rv);
            }
            //
            UIModel<SDFileModel> uiModel = null;
                uiModel = GetContextModel(UIModelContextTypes.DisplayForm, item, decripted, guidId);



            MyEventArgs<UIModel<SDFileModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDFileModel>>() { Object = uiModel });

            if (me != null) {
                uiModel = me.Object;
            }
			
            Showing(ref uiModel);
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			
            //return View("DisplayGen", uiModel.Items[0]);
			return ResolveView(uiModel, uiModel.Items[0]);

        }
		[MyAuthorize("r", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
		public ActionResult DetailsViewGen(string id)
        {

		 bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDFileModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
           
			if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
 			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
           
        	 //var uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id));
			 
            bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true")
                {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
            UIModel<SDFileModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, null, decripted), decripted, guidId);
			

            MyEventArgs<UIModel<SDFileModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDFileModel>>() { Object = uiModel });

            if (me != null)
            {
                uiModel = me.Object;
            }
            
            Showing(ref uiModel);
            return ResolveView(uiModel, uiModel.Items[0]);
        
        }
        //
        // GET: /SDFiles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /SDFiles/CreateGen
		[MyAuthorize("c", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
        public ActionResult CreateGen()
        {
			SDFileModel model = new SDFileModel();
            model.IsNew = true;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model);

			OnCreateShowing(this, e = new ControllerEventArgs<SDFileModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }

             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                 ViewData["ispopup"] = true;
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                 ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                 ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

            Showing(ref me);

			return ResolveView(me, me.Items[0]);
        } 
			
		protected override UIModel<SDFileModel> GetContextModel(UIModelContextTypes formMode, SDFileModel model)
        {
            return GetContextModel(formMode, model, false, null);
        }
			
		 private UIModel<SDFileModel> GetContextModel(UIModelContextTypes formMode, SDFileModel model, bool decript, Guid ? id) {
            UIModel<SDFileModel> me = new UIModel<SDFileModel>(true, "SDFiles");
			me.UseMode = GetUseMode();
			me.Controller = this;
			me.OverrideApp = GetOverrideApp();
			me.ContextType = formMode ;
			me.Id = "SDFile";
			
            me.ModuleKey = "SFSServiceDesk";

			me.ModuleNamespace = "SFS.ServiceDesk";
            me.EntityKey = "SDFile";
            me.EntitySetName = "SDFiles";

			me.AreaAction = "SFSServiceDesk";
            me.ControllerAction = "SDFiles";
            me.PropertyKeyName = "GuidFile";

            me.Properties = GetProperties(me, decript, id);
 			
			if (Request != null)
            {
                string actionName = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam( Request.RequestContext, "action");
                if(actionName != null && actionName.ToLower().Contains("create") ){
                    me.IsNew = true;
                }
            }
			 #region Buttons
			 if (Request != null ){
             if (formMode == UIModelContextTypes.DisplayForm || formMode == UIModelContextTypes.EditForm || formMode == UIModelContextTypes.ListForm)
				me.ActionButtons = GetActionButtons(formMode,model != null ?(Request.QueryString["dec"] == "true" ? model.Id : model.SafeKey)  : null, "SFSServiceDesk", "SDFiles", "SDFile", me.IsNew);

            //me.ActionButtons.Add(new ActionModel() { ActionKey = "return", Title = GlobalMessages.RETURN, Url = System.Web.VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDFiles" });
			if (this.HttpContext != null &&  !this.HttpContext.SkipAuthorization){
				//antes this.HttpContext
				me.SetAction("u", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("u", "SDFile", "SFSServiceDesk"));
				me.SetAction("c", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("c", "SDFile", "SFSServiceDesk"));
				me.SetAction("d", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("d", "SDFile", "SFSServiceDesk"));
			
			}else{
				me.SetAction("u", true);
				me.SetAction("c", true);
				me.SetAction("d", true);

			}
            #endregion              
         
            switch (formMode)
            {
                case UIModelContextTypes.DisplayForm:
					//me.TitleForm = SDFileResources.SDFILES_DETAILS;
                    me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.MODIFY_DATA;
					 me.Properties.Where(p=>p.PropertyName  != "Id" && p.IsForeignKey == false).ToList().ForEach(p => p.IsHidden = false);

					 me.Properties.Where(p => (p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier) ).ToList().ForEach(p=> me.SetHide(p.PropertyName));

                    break;
                case UIModelContextTypes.EditForm:
				  me.Properties.Where(p=>p.SystemProperty != SystemProperties.Identifier && p.IsForeignKey == false && p.PropertyName != "Id").ToList().ForEach(p => p.IsHidden = false);

					if (model != null)
                    {
						

                        me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.SAVE_DATA;                        
                        me.ActionButtons.First(p => p.ActionKey == "c").Title = GlobalMessages.SAVE_DATA;
						if (model.IsNew ){
							//me.TitleForm = SDFileResources.SDFILES_ADD_NEW;
							me.ActionName = "CreateGen";
							me.Properties.RemoveAll(p => p.SystemProperty != null || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));
						}else{
							
							me.ActionName = "EditGen";

							//me.TitleForm = SDFileResources.SDFILES_EDIT;
							me.Properties.RemoveAll(p => p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));	
						}
						//me.Properties.Remove(me.Properties.Find(p => p.PropertyName == "UpdatedDate"));
					
					}
                    break;
                case UIModelContextTypes.FilterFields:
                    break;
                case UIModelContextTypes.GenericForm:
                    break;
                case UIModelContextTypes.Items:
				//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "FileName") != null){
						me.Properties.Find(p => p.PropertyName == "FileName").IsHidden = false;
					 }
					 
                    
					

						 if (me.Properties.Find(p => p.PropertyName == "GuidFile") != null){
						me.Properties.Find(p => p.PropertyName == "GuidFile").IsHidden = false;
					 }
					 
                    
					


                  


					//}
                    break;
                case UIModelContextTypes.ListForm:
					PropertyDefinition propFinded = null;
					//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "FileName") != null){
						me.Properties.Find(p => p.PropertyName == "FileName").IsHidden = false;
					 }
					
					me.PrincipalActionName = "GetByJson";
					//}
					//me.TitleForm = SDFileResources.SDFILES_LIST;
                    break;
                default:
                    break;
            }
            	this.SetDefaultProperties(me);
			}
			if (model != null )
            	me.Items.Add(model);
            return me;
        }
		// GET: /SDFiles/CreateViewGen
		[MyAuthorize("c", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
        public ActionResult CreateViewGen()
        {
				SDFileModel model = new SDFileModel();
            model.IsNew = true;
			e= null;
			OnCreateShowing(this, e = new ControllerEventArgs<SDFileModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }
			
            var me = GetContextModel(UIModelContextTypes.EditForm, model);

			me.IsPartialView = true;	
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
            {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                me.Properties.Find(p => p.PropertyName == ViewData["fk"].ToString()).IsReadOnly = true;
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
			
      
            //me.Items.Add(model);
            Showing(ref me);
            return ResolveView(me, me.Items[0]);
        }
		protected override  void GettingExtraData(ref UIModel<SDFileModel> uiModel)
        {

            MyEventArgs<UIModel<SDFileModel>> me = null;
            OnGettingExtraData(this, me = new MyEventArgs<UIModel<SDFileModel>>() { Object = uiModel });
            //bool maybeAnyReplaced = false; 
            if (me != null)
            {
                uiModel = me.Object;
                //maybeAnyReplaced = true;
            }
           
			bool canFill = false;
			 string query = null ;
            bool isFK = false;
			PropertyDefinition prop =null;
			var contextRequest = this.GetContextRequest();
            contextRequest.CustomParams.Add(new CustomParam() { Name="ui", Value= SDFile.EntityName });

                        

        }
		private void Showing(ref UIModel<SDFileModel> uiModel) {
          	
			MyEventArgs<UIModel<SDFileModel>> me = new MyEventArgs<UIModel<SDFileModel>>() { Object = uiModel };
			 OnVirtualLayoutSettings(this, me);


            OnShowing(this, me);

			
			if ((Request != null && Request.QueryString["allFields"] == "1") || Request == null )
			{
				me.Object.Properties.ForEach(p=> p.IsHidden = false);
            }
            if (me != null)
            {
                uiModel = me.Object;
            }
          


			 if (uiModel.ContextType == UIModelContextTypes.EditForm)
			    GettingExtraData(ref uiModel);
            ViewData["UIModel"] = uiModel;

        }
        //
        // POST: /SDFiles/Create
		[MyAuthorize("c", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
        [HttpPost]
		[ValidateInput(false)] 
        public ActionResult CreateGen([Bind(Exclude = "FileData")]SDFileModel  model,  ContextRequest contextRequest)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
		 	e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDFileModel>() { Item = model });
           
		  	if (!ModelState.IsValid) {
				model.IsNew = true;
				var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
                 if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                        ViewData["ispopup"] = true;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
                    return ResolveView(me, model);
            }
            try
            {
				if (model.GuidFile == null || model.GuidFile.ToString().Contains("000000000"))
				model.GuidFile = Guid.NewGuid();
	
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnCreating(this, e = new ControllerEventArgs<SDFileModel>() { Item = model });
                if (e != null) {
                   if (e.Cancel && e.RedirectValues.Count > 0){
                        RouteValueDictionary rv = new RouteValueDictionary();
                        if (e.RedirectValues["area"] != null ){
                            rv.Add("area", e.RedirectValues["area"].ToString());
                        }
                        foreach (var item in e.RedirectValues.Where(p=>p.Key != "area" && p.Key != "controller" &&  p.Key != "action" ))
	                    {
		                    rv.Add(item.Key, item.Value);
	                    }

                        //if (e.RedirectValues["action"] != null && e.RedirectValues["controller"] != null && e.RedirectValues["area"] != null )
                        return RedirectToAction(e.RedirectValues["action"].ToString(), e.RedirectValues["controller"].ToString(), rv );


                        
                    }else if (e.Cancel && e.ActionResult != null )
                        return e.ActionResult;  
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				if (contextRequest == null || contextRequest.Company == null){
					contextRequest = GetContextRequest();
					
				}
                if (!cancel)
                	model.Bind(SDFilesBR.Instance.Create(model.GetBusinessObject(), contextRequest ));
				OnCreated(this, e = new ControllerEventArgs<SDFileModel>() { Item = model });
                 if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                        return ResolveApiResponse("success", null, null, null);

                    }
                }
				 
				 if (e != null )
					if (e.ActionResult != null)
                    	replaceResult = true;		
				if (!replaceResult)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))
                    {
                        ViewData["__continue"] = true;
                    }
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"]) &&  string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
                        popupextra.Add("id", model.SafeKey);
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                       {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                            popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"area"));
                            popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                            popupextra.Add("action", actionDetails);
                       if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
                    {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))

                        {
                            var popupextra = GetRouteData();
                            popupextra.Add("id", model.SafeKey);
                            return RedirectToAction("EditViewGen", popupextra);
                        }
                        else
                        {
                            return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.ADD_DONE));
                        }
                    }        			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                        return Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]);
                    else{

							RouteValueDictionary popupextra = null; 
							if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"])){
                            popupextra = GetRouteData();
							 string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
                            if (!string.IsNullOrEmpty(area))
                                popupextra.Add("area", area);
                            
                            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"])) {
								popupextra.Add("id", model.SafeKey);
                                return RedirectToAction("EditGen", popupextra);

                            }else{
								
                            return RedirectToAction("Index", popupextra);
							}
							}else{
								return Content("ok");
							}
                        }
						 }
                else {
                    return e.ActionResult;
                    }
				}
            catch(Exception ex)
            {
					  SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        throw ex;
                    }
                    else
                    {
                       // return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
					   return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
                SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                model.IsNew = true;
                var me = GetContextModel(UIModelContextTypes.EditForm, model, true, model.GuidFile);
                Showing(ref me);
                if (isPopUp)
                {
                    
                        ViewData["ispopup"] = isPopUp;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
					if (Request != null)
						return ResolveView(me, model);
					else
						return Content("ok");
            }
        }        
        //
        // GET: /SDFiles/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }
			
		
		[MyAuthorize("u", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
		[MvcSiteMapNode(Area="SFSServiceDesk", Title="sss", Clickable=false, ParentKey = "SFSServiceDesk_SDFile_List")]
		public ActionResult EditGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDFileResources.ENTITY_SINGLE;		 	
  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDFileModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
            SDFileModel model = null;
            // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
			bool dec = false;
            Guid ? idGuidDecripted = null ;
            if (Request != null && Request.QueryString["dec"] == "true")
            {
                dec = true;
                idGuidDecripted = Guid.Parse(id);
            }

            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model,dec,idGuidDecripted);
            Showing(ref me);


            if (!replaceResult)
            {
                 //return View("EditGen", me.Items[0]);
				 return ResolveView(me, me.Items[0]);
            }
            else {
                return e.ActionResult;
            }
        }
			[MyAuthorize("u", "SDFile","SFSServiceDesk", typeof(SDFilesController))]
		public ActionResult EditViewGen(string id)
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

					  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDFileModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
			
            SDFileModel model = null;
			 bool dec = false;
            Guid? guidId = null ;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                dec = true;
                guidId = Guid.Parse(id);
            }
            // si fue implementado el método parcial y no se ha decidido suspender la acción
            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
            var me = GetContextModel(UIModelContextTypes.EditForm, model, dec, guidId);
            Showing(ref me);

            return ResolveView(me, model);
        }
		[MyAuthorize("u", "SDFile",  "SFSServiceDesk", typeof(SDFilesController))]
		[HttpPost]
		[ValidateInput(false)] 
		        public ActionResult EditGen(SDFileModel model)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
			e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDFileModel>() { Item = model });
           
            if (!ModelState.IsValid)
            {
			   	var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
			
				if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"])){
                	ViewData["ispopup"] = true;
					return ResolveView(me, model);
				}
				else
					return ResolveView(me, model);
            }
            try
            {
			
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnEditing(this, e = new ControllerEventArgs<SDFileModel>() { Item = model });
                if (e != null) {
                    if (e.Cancel && e.ActionResult != null)
                        return e.ActionResult;
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				ContextRequest context = new ContextRequest();
                context.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;

                SDFile resultObj = null;
			    if (!cancel)
                	resultObj = SDFilesBR.Instance.Update(model.GetBusinessObject(), GetContextRequest());
				
				OnEdited(this, e = new ControllerEventArgs<SDFileModel>() { Item =   new SDFileModel(resultObj) });
				if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                         return ResolveApiResponse("success", null, null, null);
                    }
                }
				
				if (e != null && e.ActionResult != null) replaceResult = true; 

                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Content("ok");
                }
                else
                {
				if (!replaceResult)
                {
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"])  && string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
						 if (Request != null && Request.QueryString["dec"] == "true")
                        {
                            popupextra.Add("id", model.Id);
                        }
                        else
                        {
							popupextra.Add("id", model.SafeKey);

							
                        }
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                        {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                        popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area"));
                        popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                        popupextra.Add("action", actionDetails);
                        if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
					if (isPopUp)
						return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.UPDATE_DONE));
        			    string returnUrl = null;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"])) {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.Form["ReturnAfter"];
                        else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"];
                    }
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else{
		RouteValueDictionary popupextra = null; 
						 if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"]))
                            {
							
							popupextra = GetRouteData();
							string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
							if (!string.IsNullOrEmpty(area))
								popupextra.Add("area", area);

							return RedirectToAction("Index", popupextra);
						}else{
							return Content("ok");
						}
						}
				 }
                else {
                    return e.ActionResult;
				}
                }		
            }
          catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content(ex.ToString());
                    }
                    else
                    {
                        //return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
						 return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
			    if (isPopUp)
                {
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(ex.Message));
                    
                }
                else
                {
                    SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                    
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else {
						  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
							ViewData["ispopup"] = true;
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
							ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
							ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

						var me = GetContextModel(UIModelContextTypes.EditForm, model);
						Showing(ref me);

						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
						{
							ViewData["ispopup"] = true;
							return ResolveView(me, model);
						}
						else
							return ResolveView(me, model);

						
					}
				}
            }
        }
        //
        // POST: /SDFiles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //  Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SDFiles/Delete/5
        
		[MyAuthorize("d", "SDFile", "SFSServiceDesk", typeof(SDFilesController))]
		[HttpDelete]
        public ActionResult DeleteGen(string objectKey, string extraParams)
        {
            try
            {
					
			
				Guid guidFile = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey.Replace("-", "/"), "GuidFile")); 
                BO.SDFile entity = new BO.SDFile() { GuidFile = guidFile };

                BR.SDFilesBR.Instance.Delete(entity, GetContextRequest());               
                return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.DELETE_DONE));

            }
            catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null)
                    {
                        message = ex.Data["usermessage"].ToString();
                    }

                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }
            }
        }
		/*[MyAuthorize()]
		public FileMediaResult Download(string query, bool? allSelected = false,  string selected = null , string orderBy = null , string direction = null , string format = null , string actionKey=null )
        {
			
            List<Guid> keysSelected1 = new List<Guid>();
            if (!string.IsNullOrEmpty(selected)) {
                foreach (var keyString in selected.Split(char.Parse("|")))
                {
				
                    keysSelected1.Add(Guid.Parse(keyString));
                }
            }
				
            query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(query, allSelected.Value, selected, "GuidFile");
            MyEventArgs<ContextActionModel<SDFileModel>> eArgs = null;
            List<SDFileModel> results = GetBy(query, null, null, orderBy, direction, GetContextRequest(), keysSelected1);
            OnDownloading(this, eArgs = new MyEventArgs<ContextActionModel<SDFileModel>>() { Object = new ContextActionModel<SDFileModel>() { Query = query, SelectedItems = results, Selected=selected, SelectAll = allSelected.Value, Direction = direction , OrderBy = orderBy, ActionKey=actionKey  } });

            if (eArgs != null)
            {
                if (eArgs.Object.Result != null)
                    return (FileMediaResult)eArgs.Object.Result;
            }
            

            return (new FeaturesController()).ExportDownload(typeof(SDFileModel), results, format, this.GetUIPluralText("SFSServiceDesk", "SDFile"));
            
        }
			*/
		
		[HttpPost]
        public ActionResult CustomActionExecute(ContextActionModel model) {
		 try
            {
			//List<Guid> keysSelected1 = new List<Guid>();
			List<object> keysSelected1 = new List<object>();
            if (!string.IsNullOrEmpty(model.Selected))
            {
                foreach (var keyString in model.Selected.Split(char.Parse(",")))
                {
				
				keysSelected1.Add(Guid.Parse(keyString.Split(char.Parse("|"))[0]));
                        
                    

			
                }
            }
			DataAction dataAction = DataAction.GetDataAction(Request);
			 model.Selected = dataAction.Selected;

            model.Query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(dataAction.Query, dataAction.AllSelected, dataAction.Selected, "GuidFile");
           
            
			
			#region implementaci�n de m�todo parcial
            bool replaceResult = false;
            MyEventArgs<ContextActionModel<SDFileModel>> actionEventArgs = null;
           
			if (model.ActionKey != "deletemany" && model.ActionKey != "deleterelmany" && model.ActionKey != "updateRel" &&  model.ActionKey != "delete-relation-fk" && model.ActionKey != "restore" )
			{
				ContextRequest context = SFSdotNet.Framework.My.Context.BuildContextRequestSafe(System.Web.HttpContext.Current);
				context.UseMode = dataAction.Usemode;

				if (model.IsBackground)
				{
					System.Threading.Tasks.Task.Run(() => 
						OnCustomActionExecutingBackground(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDFileModel>>() { Object = new ContextActionModel<SDFileModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } })
					);
				}
				else
				{
					OnCustomActionExecuting(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDFileModel>>() {  Object = new ContextActionModel<SDFileModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } });
				}
			}
            List<SDFileModel> results = null;
	
			if (model.ActionKey == "deletemany") { 
				
				BR.SDFilesBR.Instance.Delete(model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());

            }
	
            else if (model.ActionKey == "updateRel" || model.ActionKey == "delete-relation-fk" || model.ActionKey == "updateRel-proxyMany")
            {
               try {
                   string valueForUpdate = null;
				   string propForUpdate = null;
				   if (!string.IsNullOrEmpty(Request.Params["propertyForUpdate"])){
						propForUpdate = Request.Params["propertyForUpdate"];
				   }
				    if (string.IsNullOrEmpty(propForUpdate) && !string.IsNullOrEmpty(Request.QueryString["propertyForUpdate"]))
                   {
                       propForUpdate = Request.QueryString["propertyForUpdate"];
                   }
                    if (model.ActionKey != "delete-relation-fk")
                    {
                        valueForUpdate = Request.QueryString["valueForUpdate"];
                    }
                    BR.SDFilesBR.Instance.UpdateAssociation(propForUpdate, valueForUpdate, model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());
					
                    if (model.ActionKey == "delete-relation-fk")
                    {
                        MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]);

                        return PartialView("ResultMessageView", message);
                    }
                    else
                    {
                        return Content("ok");
                    }
       
          
                }
                catch (Exception ex)
                {
				        SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
           
                }
            
            }
		
                if (actionEventArgs == null && !model.IsBackground)
                {
                    //if (model.ActionKey != "deletemany"  && model.ActionKey != "deleterelmany")
                    //{
                     //   throw new NotImplementedException("");
                    //}
                }
                else
                {
					if (model.IsBackground == false )
						 replaceResult = actionEventArgs.Object.Result is ActionResult /*actionEventArgs.Object.ReplaceResult*/;
                }
                #endregion
                if (!replaceResult)
                {
                    if (Request != null && Request.IsAjaxRequest())
                    {
						MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]) ;
                        if (model.IsBackground )
                            message.Message = GlobalMessages.THE_PROCESS_HAS_BEEN_STARTED;
                        
                        return PartialView("ResultMessageView", message);                    
					}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return (ActionResult)actionEventArgs.Object.Result;
                }
            }
            catch (Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null) {
                        message = ex.Data["usermessage"].ToString();
                    }
					 SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }

            }
        }
        //
        // POST: /SDFiles/Delete/5
        
			
	
    }
}
namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
	using SFS.ServiceDesk.Web.Mvc.Models.SDOrganizations;

    public partial class SDOrganizationsController : SFS.ServiceDesk.Web.Mvc.ControllerBase<Models.SDOrganizations.SDOrganizationModel>
    {

       


	#region partial methods
        ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e = null;
        partial void OnValidating(object sender, ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e);
        partial void OnGettingExtraData(object sender, MyEventArgs<UIModel<Models.SDOrganizations.SDOrganizationModel>> e);
        partial void OnCreating(object sender, ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e);
        partial void OnCreated(object sender, ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e);
        partial void OnEditing(object sender, ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e);
        partial void OnEdited(object sender, ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e);
        partial void OnDeleting(object sender, ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e);
        partial void OnDeleted(object sender, ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e);
    	partial void OnShowing(object sender, MyEventArgs<UIModel<Models.SDOrganizations.SDOrganizationModel>> e);
    	partial void OnGettingByKey(object sender, ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e);
        partial void OnTaken(object sender, ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e);
       	partial void OnCreateShowing(object sender, ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e);
		partial void OnEditShowing(object sender, ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e);
		partial void OnDetailsShowing(object sender, ControllerEventArgs<Models.SDOrganizations.SDOrganizationModel> e);
 		partial void OnActionsCreated(object sender, MyEventArgs<UIModel<Models.SDOrganizations.SDOrganizationModel >> e);
		partial void OnCustomActionExecuting(object sender, MyEventArgs<ContextActionModel<Models.SDOrganizations.SDOrganizationModel>> e);
		partial void OnCustomActionExecutingBackground(object sender, MyEventArgs<ContextActionModel<Models.SDOrganizations.SDOrganizationModel>> e);
        partial void OnDownloading(object sender, MyEventArgs<ContextActionModel<Models.SDOrganizations.SDOrganizationModel>> e);
      	partial void OnAuthorization(object sender, AuthorizationContext context);
		 partial void OnFilterShowing(object sender, MyEventArgs<UIModel<Models.SDOrganizations.SDOrganizationModel >> e);
         partial void OnSummaryOperationShowing(object sender, MyEventArgs<UIModel<Models.SDOrganizations.SDOrganizationModel>> e);

        partial void OnExportActionsCreated(object sender, MyEventArgs<UIModel<Models.SDOrganizations.SDOrganizationModel>> e);


		protected override void OnVirtualFilterShowing(object sender, MyEventArgs<UIModel<SDOrganizationModel>> e)
        {
            OnFilterShowing(sender, e);
        }
		 public override void OnVirtualExportActionsCreated(object sender, MyEventArgs<UIModel<SDOrganizationModel>> e)
        {
            OnExportActionsCreated(sender, e);
        }
        public override void OnVirtualDownloading(object sender, MyEventArgs<ContextActionModel<SDOrganizationModel>> e)
        {
            OnDownloading(sender, e);
        }
        public override void OnVirtualShowing(object sender, MyEventArgs<UIModel<SDOrganizationModel>> e)
        {
            OnShowing(sender, e);
        }

	#endregion
	#region API
	 public override ActionResult ApiCreateGen(SDOrganizationModel model, ContextRequest contextRequest)
        {
            return CreateGen(model, contextRequest);
        }

              public override ActionResult ApiGetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJson(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }
        public override ActionResult ApiGetByKeyJson(string id, ContextRequest contextRequest)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
            return  GetByKeyJson(id, contextRequest, true);
        }
      
		 public override ActionResult ApiGetByCount(string filter, ContextRequest contextRequest)
        {
            return GetByCount(filter, contextRequest);
        }
         protected override ActionResult ApiDeleteGen(List<SDOrganizationModel> models, ContextRequest contextRequest)
        {
            List<SDOrganization> objs = new List<SDOrganization>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                BR.SDOrganizationsBR.Instance.DeleteBulk(objs, contextRequest);
                if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("success", null, null, null);

                }
                else
                {
                    return Content("ok");

                }
            }
            catch (Exception ex)
            {
               if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "error", reason = "error", message= ex.ToString() }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("error", "exception", ex.ToString(), null );

                }
                else
                {
                    return Json(ex.ToString(), JsonRequestBehavior.AllowGet);

                }
            }
        }
        protected override ActionResult ApiUpdateGen(List<SDOrganizationModel> models, ContextRequest contextRequest)
        {
            List<SDOrganization> objs = new List<SDOrganization>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                foreach (var obj in objs)
                {
                    BR.SDOrganizationsBR.Instance.Update(obj, contextRequest);

                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }


	#endregion
#region Validation methods	
	    private void Validations(SDOrganizationModel model) { 
            #region Remote validations

            #endregion
		}

#endregion
		
 		public AuthorizationContext Authorization(AuthorizationContext context)
        {
            OnAuthorization(this,  context );
            return context ;
        }
		public List<SDOrganizationModel> GetAll() {
            			var bos = BR.SDOrganizationsBR.Instance.GetBy("",
					new SFSdotNet.Framework.My.ContextRequest()
					{
						CustomQuery = new SFSdotNet.Framework.My.CustomQuery()
						{
							OrderBy = "FullName",
							SortDirection = SFSdotNet.Framework.Data.SortDirection.Ascending
						}
					});
            			List<SDOrganizationModel> results = new List<SDOrganizationModel>();
            SDOrganizationModel model = null;
            foreach (var bo in bos)
            {
                model = new SDOrganizationModel();
                model.Bind(bo);
                results.Add(model);
            }
            return results;

        }
        //
        // GET: /SDOrganizations/
		[MyAuthorize("r", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
		public ActionResult Index()
        {
    		var uiModel = GetContextModel(UIModelContextTypes.ListForm, null);
			ViewBag.UIModel = uiModel;
			uiModel.FilterStart = (string)ViewData["startFilter"];
                    MyEventArgs<UIModel<SDOrganizationModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDOrganizationModel>>() { Object = uiModel });

			OnExportActionsCreated(this, (me != null ? me : me = new MyEventArgs<UIModel<SDOrganizationModel>>() { Object = uiModel }));

            if (me != null)
            {
                uiModel = me.Object;
            }
            if (me == null)
                me = new MyEventArgs<UIModel<SDOrganizationModel>>() { Object = uiModel };
           
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;


            //return View("ListGen");
			return ResolveView(uiModel);
        }
		[MyAuthorize("r", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
		public ActionResult ListViewGen(string idTab, string fk , string fkValue, string startFilter, ListModes  listmode  = ListModes.SimpleList, PropertyDefinition parentRelationProperty = null, object parentRelationPropertyValue = null )
        {
			ViewData["idTab"] = System.Web.HttpContext.Current.Request.QueryString["idTab"]; 
		 	ViewData["detpop"] = true; // details in popup
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"])) {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"]; 
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
            {
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["startFilter"]))
            {
                ViewData["startFilter"] = Request.QueryString["startFilter"];
            }
			
			UIModel<SDOrganizationModel> uiModel = GetContextModel(UIModelContextTypes.ListForm, null);

            MyEventArgs<UIModel<SDOrganizationModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDOrganizationModel>>() { Object = uiModel });
            if (me == null)
                me = new MyEventArgs<UIModel<SDOrganizationModel>>() { Object = uiModel };
            uiModel.Properties = GetProperties(uiModel);
            uiModel.ContextType = UIModelContextTypes.ListForm;
             uiModel.FilterStart = (string)ViewData["startFilter"];
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;
			 if (listmode == ListModes.SimpleList)
                return ResolveView(uiModel);
            else
            {
                ViewData["parentRelationProperty"] = parentRelationProperty;
                ViewData["parentRelationPropertyValue"] = parentRelationPropertyValue;
                return PartialView("ListForTagSelectView");
            }
            return ResolveView(uiModel);
        }
		List<PropertyDefinition> _properties = null;

		 protected override List<PropertyDefinition> GetProperties(UIModel uiModel,  params string[] specificProperties)
        { 
            return GetProperties(uiModel, false, null, specificProperties);
        }

		protected override List<PropertyDefinition> GetProperties(UIModel uiModel, bool decripted, Guid? id, params string[] specificProperties)
            {

			bool allProperties = true;    
                if (specificProperties != null && specificProperties.Length > 0)
                {
                    allProperties = false;
                }


			List<CustomProperty> customProperties = new List<CustomProperty>();
			if (_properties == null)
                {
                List<PropertyDefinition> results = new List<PropertyDefinition>();

			string idSDOrganization = GetRouteDataOrQueryParam("id");
			if (idSDOrganization != null)
			{
				if (!decripted)
                {
					idSDOrganization = SFSdotNet.Framework.Entities.Utils.GetPropertyKey(idSDOrganization.Replace("-","/"), "GuidOrganization");
				}else{
					if (id != null )
						idSDOrganization = id.Value.ToString();                

				}
			}

			bool visibleProperty = true;	
			 bool conditionalshow =false;
                if (uiModel.ContextType == UIModelContextTypes.EditForm || uiModel.ContextType == UIModelContextTypes.DisplayForm ||  uiModel.ContextType == UIModelContextTypes.GenericForm )
                    conditionalshow = true;
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidOrganization"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidOrganization")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 100,
																	
					CustomProperties = customProperties,

                    PropertyName = "GuidOrganization",

					 MaxLength = 0,
					IsRequired = true ,
					IsHidden = true,
                    SystemProperty =  SystemProperties.Identifier ,
					IsDefaultProperty = false,
                    SortBy = "GuidOrganization",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDOrganizationResources.GUIDORGANIZATION*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("FullName"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "FullName")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 101,
																	
					CustomProperties = customProperties,

                    PropertyName = "FullName",

					 MaxLength = 255,
					IsRequired = true ,
					IsDefaultProperty = true,
                    SortBy = "FullName",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDOrganizationResources.FULLNAME*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDAreas"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDOrganization" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDAreas.GuidArea")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDAreas.GuidArea" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDAreas" });
			

	
	//fk_SdArea_SdOrganization
		//if (this.Request.QueryString["fk"] != "SDAreas")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 102,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDAreas/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDAreas&fk=SDOrganization&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDOrganization.GuidOrganization = Guid(\"" + idSDOrganization +"\")")+ "&fkValue=" + idSDOrganization,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDArea",
					
					CustomProperties = customProperties,

                    PropertyName = "SDAreas",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDAreas.Name",
					
	
                    TypeName = "SFSServiceDeskModel.SDArea",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDAreas"
                    /*,PropertyDisplayName = Resources.SDOrganizationResources.SDAREAS*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDPersons"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDOrganization" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDPersons.GuidPerson")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDPersons.GuidPerson" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDPersons" });
			

	
	//fk_SdPerson_SdOrganization
		//if (this.Request.QueryString["fk"] != "SDPersons")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 103,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDPersons/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDPersons&fk=SDOrganization&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDOrganization.GuidOrganization = Guid(\"" + idSDOrganization +"\")")+ "&fkValue=" + idSDOrganization,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDPerson",
					
					CustomProperties = customProperties,

                    PropertyName = "SDPersons",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDPersons.DisplayName",
					
	
                    TypeName = "SFSServiceDeskModel.SDPerson",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDPersons"
                    /*,PropertyDisplayName = Resources.SDOrganizationResources.SDPERSONS*/
                });
		//	}
	
	}
	
				
                    _properties = results;
                    return _properties;
                }
                else {
                    return _properties;
                }
            }

		protected override  UIModel<SDOrganizationModel> GetByForShow(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, params  object[] extraParams)
        {
			if (Request != null )
				if (!string.IsNullOrEmpty(Request.QueryString["q"]))
					filter = filter + HttpUtility.UrlDecode(Request.QueryString["q"]);
 if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
            }
            var bos = BR.SDOrganizationsBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), contextRequest, extraParams);
			//var bos = BR.SDOrganizationsBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), context, extraParams);
            SDOrganizationModel model = null;
            List<SDOrganizationModel> results = new List<SDOrganizationModel>();
            foreach (var item in bos)
            {
                model = new SDOrganizationModel();
				model.Bind(item);
				results.Add(model);
            }
            //return results;
			UIModel<SDOrganizationModel> uiModel = GetContextModel(UIModelContextTypes.Items, null);
            uiModel.Items = results;
			if (Request != null){
				if (SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(Request.RequestContext, "action") == "Download")
				{
					uiModel.ContextType = UIModelContextTypes.ExportDownload;
				}
			}
            Showing(ref uiModel);
            return uiModel;
		}			
		
		//public List<SDOrganizationModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params  object[] extraParams)
        //{
		//	var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, null, extraParams);
        public override List<SDOrganizationModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest,  params  object[] extraParams)
        {
            var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
           
            return uiModel.Items;
		
        }
		/*
        [MyAuthorize("r", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir)
        {
			 return GetByJsonBase(filter, pageSize, page, orderBy, orderDir);
        }*/

		  [MyAuthorize("r", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir,ContextRequest contextRequest,  object[] extraParams)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
			 
			 if (this.IsRESTRequest == false)
            {
                return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
            }else
            {
                try
                {
                    return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);

                }
            }
        }
/*		  [MyAuthorize("r", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
       public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }*/
		[MyAuthorize()]
		public ActionResult GetByCount(string filter, ContextRequest contextRequest) {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
           
			
             if (this.IsRESTRequest == true)
            {
                try
                {

                    var result = BR.SDOrganizationsBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);

                   if (Request.QueryString["v"] == "2")
                    {
						return ResolveApiResponse("success", null, null, result);

                        //return Json(new { status = "success", data = result }, JsonRequestBehavior.AllowGet);
                    }else
                    {
                        return Content(result.ToString());

                    }
                }
                catch (Exception ex)
                {
                  //  return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
				  return ResolveApiResponse("error", "exception", ex.ToString(), null);

                }
            }
            else
            {
                var result = BR.SDOrganizationsBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);
                return Content(result.ToString());
            }
		}
		

		[MyAuthorize("r", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
        public ActionResult GetByKeyJson(string id, ContextRequest contextRequest,  bool dec = false)
        {
            return Json(GetByKey(id, null, contextRequest, dec), JsonRequestBehavior.AllowGet);
        }
		public SDOrganizationModel GetByKey(string id) {
			return GetByKey(id, null,null, false);
       	}
		    public SDOrganizationModel GetByKey(string id, string includes)
        {
            return GetByKey(id, includes, false);
        }
		 public  SDOrganizationModel GetByKey(string id, string includes, ContextRequest contextRequest)
        {
            return GetByKey(id, includes, contextRequest, false);
        }
		/*
		  public ActionResult ShowField(string fieldName, string idField) {
		   string safePropertyName = fieldName;
              if (fieldName.StartsWith("Fk"))
              {
                  safePropertyName = fieldName.Substring(2, fieldName.Length - 2);
              }

             SDOrganizationModel model = new  SDOrganizationModel();

            UIModel uiModel = GetUIModel(model, new string[] { "NoField-" });
			
				uiModel.Properties = GetProperties(uiModel, safePropertyName);
		uiModel.Properties.ForEach(p=> p.ContextType = uiModel.ContextType );
            uiModel.ContextType = UIModelContextTypes.FilterFields;
            uiModel.OverrideApp = GetOverrideApp();
            uiModel.UseMode = GetUseMode();

            ViewData["uiModel"] = uiModel;
			var prop = uiModel.Properties.FirstOrDefault(p=>p.PropertyName == safePropertyName);
            //if (prop.IsNavigationProperty && prop.IsNavigationPropertyMany == false)
            //{
            //    ViewData["currentProperty"] = uiModel.Properties.FirstOrDefault(p => p.PropertyName != fieldName + "Text");
            //}else if (prop.IsNavigationProperty == false){
                ViewData["currentProperty"] = prop;
           // }
            ((PropertyDefinition)ViewData["currentProperty"]).RemoveLayout = true;
			ViewData["withContainer"] = false;


            return PartialView("GenericField", model);


        }
      */
	public SDOrganizationModel GetByKey(string id, ContextRequest contextRequest, bool dec)
        {
            return GetByKey(id, null, contextRequest, dec);
        }
        public SDOrganizationModel GetByKey(string id, string  includes, bool dec)
        {
            return GetByKey(id, includes, null, dec);
        }

        public SDOrganizationModel GetByKey(string id, string includes, ContextRequest contextRequest, bool dec) {
		             SDOrganizationModel model = null;
            ControllerEventArgs<SDOrganizationModel> e = null;
			string objectKey = id.Replace("-","/");
             OnGettingByKey(this, e=  new ControllerEventArgs<SDOrganizationModel>() { Id = objectKey  });
             bool cancel = false;
             SDOrganizationModel eItem = null;
             if (e != null)
             {
                 cancel = e.Cancel;
                 eItem = e.Item;
             }
			if (cancel == false && eItem == null)
             {
			Guid guidOrganization = Guid.Empty; //new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, "GuidOrganization"));
			if (dec)
                 {
                     guidOrganization = new Guid(id);
                 }
                 else
                 {
                     guidOrganization = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, null));
                 }
			
            
				model = new SDOrganizationModel();
                  if (contextRequest == null)
                {
                    contextRequest = GetContextRequest();
                }
				var bo = BR.SDOrganizationsBR.Instance.GetByKey(guidOrganization, GetUseMode(), contextRequest,  includes);
				 if (bo != null)
                    model.Bind(bo);
                else
                    return null;
			}
             else {
                 model = eItem;
             }
			model.IsNew = false;

            return model;
        }
        // GET: /SDOrganizations/DetailsGen/5
		[MyAuthorize("r", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
        public ActionResult DetailsGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDOrganizationResources.ENTITY_PLURAL;
			 #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDOrganizationModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
            #endregion



			 bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
			//UIModel<SDOrganizationModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, decripted), decripted, guidId);
			var item = GetByKey(id, null, null, decripted);
			if (item == null)
            {
                 RouteValueDictionary rv = new RouteValueDictionary();
                string usemode = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"usemode");
                string overrideModule = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "overrideModule");
                string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");

                if(!string.IsNullOrEmpty(usemode)){
                    rv.Add("usemode", usemode);
                }
                if(!string.IsNullOrEmpty(overrideModule)){
                    rv.Add("overrideModule", overrideModule);
                }
                if (!string.IsNullOrEmpty(area))
                {
                    rv.Add("area", area);
                }

                return RedirectToAction("Index", rv);
            }
            //
            UIModel<SDOrganizationModel> uiModel = null;
                uiModel = GetContextModel(UIModelContextTypes.DisplayForm, item, decripted, guidId);



            MyEventArgs<UIModel<SDOrganizationModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDOrganizationModel>>() { Object = uiModel });

            if (me != null) {
                uiModel = me.Object;
            }
			
            Showing(ref uiModel);
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			
            //return View("DisplayGen", uiModel.Items[0]);
			return ResolveView(uiModel, uiModel.Items[0]);

        }
		[MyAuthorize("r", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
		public ActionResult DetailsViewGen(string id)
        {

		 bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDOrganizationModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
           
			if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
 			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
           
        	 //var uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id));
			 
            bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true")
                {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
            UIModel<SDOrganizationModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, null, decripted), decripted, guidId);
			

            MyEventArgs<UIModel<SDOrganizationModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDOrganizationModel>>() { Object = uiModel });

            if (me != null)
            {
                uiModel = me.Object;
            }
            
            Showing(ref uiModel);
            return ResolveView(uiModel, uiModel.Items[0]);
        
        }
        //
        // GET: /SDOrganizations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /SDOrganizations/CreateGen
		[MyAuthorize("c", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
        public ActionResult CreateGen()
        {
			SDOrganizationModel model = new SDOrganizationModel();
            model.IsNew = true;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model);

			OnCreateShowing(this, e = new ControllerEventArgs<SDOrganizationModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }

             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                 ViewData["ispopup"] = true;
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                 ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                 ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

            Showing(ref me);

			return ResolveView(me, me.Items[0]);
        } 
			
		protected override UIModel<SDOrganizationModel> GetContextModel(UIModelContextTypes formMode, SDOrganizationModel model)
        {
            return GetContextModel(formMode, model, false, null);
        }
			
		 private UIModel<SDOrganizationModel> GetContextModel(UIModelContextTypes formMode, SDOrganizationModel model, bool decript, Guid ? id) {
            UIModel<SDOrganizationModel> me = new UIModel<SDOrganizationModel>(true, "SDOrganizations");
			me.UseMode = GetUseMode();
			me.Controller = this;
			me.OverrideApp = GetOverrideApp();
			me.ContextType = formMode ;
			me.Id = "SDOrganization";
			
            me.ModuleKey = "SFSServiceDesk";

			me.ModuleNamespace = "SFS.ServiceDesk";
            me.EntityKey = "SDOrganization";
            me.EntitySetName = "SDOrganizations";

			me.AreaAction = "SFSServiceDesk";
            me.ControllerAction = "SDOrganizations";
            me.PropertyKeyName = "GuidOrganization";

            me.Properties = GetProperties(me, decript, id);
 			
			if (Request != null)
            {
                string actionName = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam( Request.RequestContext, "action");
                if(actionName != null && actionName.ToLower().Contains("create") ){
                    me.IsNew = true;
                }
            }
			 #region Buttons
			 if (Request != null ){
             if (formMode == UIModelContextTypes.DisplayForm || formMode == UIModelContextTypes.EditForm || formMode == UIModelContextTypes.ListForm)
				me.ActionButtons = GetActionButtons(formMode,model != null ?(Request.QueryString["dec"] == "true" ? model.Id : model.SafeKey)  : null, "SFSServiceDesk", "SDOrganizations", "SDOrganization", me.IsNew);

            //me.ActionButtons.Add(new ActionModel() { ActionKey = "return", Title = GlobalMessages.RETURN, Url = System.Web.VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDOrganizations" });
			if (this.HttpContext != null &&  !this.HttpContext.SkipAuthorization){
				//antes this.HttpContext
				me.SetAction("u", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("u", "SDOrganization", "SFSServiceDesk"));
				me.SetAction("c", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("c", "SDOrganization", "SFSServiceDesk"));
				me.SetAction("d", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("d", "SDOrganization", "SFSServiceDesk"));
			
			}else{
				me.SetAction("u", true);
				me.SetAction("c", true);
				me.SetAction("d", true);

			}
            #endregion              
         
            switch (formMode)
            {
                case UIModelContextTypes.DisplayForm:
					//me.TitleForm = SDOrganizationResources.SDORGANIZATIONS_DETAILS;
                    me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.MODIFY_DATA;
					 me.Properties.Where(p=>p.PropertyName  != "Id" && p.IsForeignKey == false).ToList().ForEach(p => p.IsHidden = false);

					 me.Properties.Where(p => (p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier) ).ToList().ForEach(p=> me.SetHide(p.PropertyName));

                    break;
                case UIModelContextTypes.EditForm:
				  me.Properties.Where(p=>p.SystemProperty != SystemProperties.Identifier && p.IsForeignKey == false && p.PropertyName != "Id").ToList().ForEach(p => p.IsHidden = false);

					if (model != null)
                    {
						

                        me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.SAVE_DATA;                        
                        me.ActionButtons.First(p => p.ActionKey == "c").Title = GlobalMessages.SAVE_DATA;
						if (model.IsNew ){
							//me.TitleForm = SDOrganizationResources.SDORGANIZATIONS_ADD_NEW;
							me.ActionName = "CreateGen";
							me.Properties.RemoveAll(p => p.SystemProperty != null || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));
						}else{
							
							me.ActionName = "EditGen";

							//me.TitleForm = SDOrganizationResources.SDORGANIZATIONS_EDIT;
							me.Properties.RemoveAll(p => p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));	
						}
						//me.Properties.Remove(me.Properties.Find(p => p.PropertyName == "UpdatedDate"));
					
					}
                    break;
                case UIModelContextTypes.FilterFields:
                    break;
                case UIModelContextTypes.GenericForm:
                    break;
                case UIModelContextTypes.Items:
				//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "FullName") != null){
						me.Properties.Find(p => p.PropertyName == "FullName").IsHidden = false;
					 }
					 
                    
					

						 if (me.Properties.Find(p => p.PropertyName == "GuidOrganization") != null){
						me.Properties.Find(p => p.PropertyName == "GuidOrganization").IsHidden = false;
					 }
					 
                    
					


                  


					//}
                    break;
                case UIModelContextTypes.ListForm:
					PropertyDefinition propFinded = null;
					//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "FullName") != null){
						me.Properties.Find(p => p.PropertyName == "FullName").IsHidden = false;
					 }
					
					me.PrincipalActionName = "GetByJson";
					//}
					//me.TitleForm = SDOrganizationResources.SDORGANIZATIONS_LIST;
                    break;
                default:
                    break;
            }
            	this.SetDefaultProperties(me);
			}
			if (model != null )
            	me.Items.Add(model);
            return me;
        }
		// GET: /SDOrganizations/CreateViewGen
		[MyAuthorize("c", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
        public ActionResult CreateViewGen()
        {
				SDOrganizationModel model = new SDOrganizationModel();
            model.IsNew = true;
			e= null;
			OnCreateShowing(this, e = new ControllerEventArgs<SDOrganizationModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }
			
            var me = GetContextModel(UIModelContextTypes.EditForm, model);

			me.IsPartialView = true;	
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
            {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                me.Properties.Find(p => p.PropertyName == ViewData["fk"].ToString()).IsReadOnly = true;
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
			
      
            //me.Items.Add(model);
            Showing(ref me);
            return ResolveView(me, me.Items[0]);
        }
		protected override  void GettingExtraData(ref UIModel<SDOrganizationModel> uiModel)
        {

            MyEventArgs<UIModel<SDOrganizationModel>> me = null;
            OnGettingExtraData(this, me = new MyEventArgs<UIModel<SDOrganizationModel>>() { Object = uiModel });
            //bool maybeAnyReplaced = false; 
            if (me != null)
            {
                uiModel = me.Object;
                //maybeAnyReplaced = true;
            }
           
			bool canFill = false;
			 string query = null ;
            bool isFK = false;
			PropertyDefinition prop =null;
			var contextRequest = this.GetContextRequest();
            contextRequest.CustomParams.Add(new CustomParam() { Name="ui", Value= SDOrganization.EntityName });

                        

        }
		private void Showing(ref UIModel<SDOrganizationModel> uiModel) {
          	
			MyEventArgs<UIModel<SDOrganizationModel>> me = new MyEventArgs<UIModel<SDOrganizationModel>>() { Object = uiModel };
			 OnVirtualLayoutSettings(this, me);


            OnShowing(this, me);

			
			if ((Request != null && Request.QueryString["allFields"] == "1") || Request == null )
			{
				me.Object.Properties.ForEach(p=> p.IsHidden = false);
            }
            if (me != null)
            {
                uiModel = me.Object;
            }
          


			 if (uiModel.ContextType == UIModelContextTypes.EditForm)
			    GettingExtraData(ref uiModel);
            ViewData["UIModel"] = uiModel;

        }
        //
        // POST: /SDOrganizations/Create
		[MyAuthorize("c", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
        [HttpPost]
		[ValidateInput(false)] 
        public ActionResult CreateGen(SDOrganizationModel  model,  ContextRequest contextRequest)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
		 	e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDOrganizationModel>() { Item = model });
           
		  	if (!ModelState.IsValid) {
				model.IsNew = true;
				var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
                 if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                        ViewData["ispopup"] = true;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
                    return ResolveView(me, model);
            }
            try
            {
				if (model.GuidOrganization == null || model.GuidOrganization.ToString().Contains("000000000"))
				model.GuidOrganization = Guid.NewGuid();
	
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnCreating(this, e = new ControllerEventArgs<SDOrganizationModel>() { Item = model });
                if (e != null) {
                   if (e.Cancel && e.RedirectValues.Count > 0){
                        RouteValueDictionary rv = new RouteValueDictionary();
                        if (e.RedirectValues["area"] != null ){
                            rv.Add("area", e.RedirectValues["area"].ToString());
                        }
                        foreach (var item in e.RedirectValues.Where(p=>p.Key != "area" && p.Key != "controller" &&  p.Key != "action" ))
	                    {
		                    rv.Add(item.Key, item.Value);
	                    }

                        //if (e.RedirectValues["action"] != null && e.RedirectValues["controller"] != null && e.RedirectValues["area"] != null )
                        return RedirectToAction(e.RedirectValues["action"].ToString(), e.RedirectValues["controller"].ToString(), rv );


                        
                    }else if (e.Cancel && e.ActionResult != null )
                        return e.ActionResult;  
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				if (contextRequest == null || contextRequest.Company == null){
					contextRequest = GetContextRequest();
					
				}
                if (!cancel)
                	model.Bind(SDOrganizationsBR.Instance.Create(model.GetBusinessObject(), contextRequest ));
				OnCreated(this, e = new ControllerEventArgs<SDOrganizationModel>() { Item = model });
                 if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                        return ResolveApiResponse("success", null, null, null);

                    }
                }
				 
				 if (e != null )
					if (e.ActionResult != null)
                    	replaceResult = true;		
				if (!replaceResult)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))
                    {
                        ViewData["__continue"] = true;
                    }
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"]) &&  string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
                        popupextra.Add("id", model.SafeKey);
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                       {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                            popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"area"));
                            popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                            popupextra.Add("action", actionDetails);
                       if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
                    {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))

                        {
                            var popupextra = GetRouteData();
                            popupextra.Add("id", model.SafeKey);
                            return RedirectToAction("EditViewGen", popupextra);
                        }
                        else
                        {
                            return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.ADD_DONE));
                        }
                    }        			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                        return Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]);
                    else{

							RouteValueDictionary popupextra = null; 
							if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"])){
                            popupextra = GetRouteData();
							 string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
                            if (!string.IsNullOrEmpty(area))
                                popupextra.Add("area", area);
                            
                            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"])) {
								popupextra.Add("id", model.SafeKey);
                                return RedirectToAction("EditGen", popupextra);

                            }else{
								
                            return RedirectToAction("Index", popupextra);
							}
							}else{
								return Content("ok");
							}
                        }
						 }
                else {
                    return e.ActionResult;
                    }
				}
            catch(Exception ex)
            {
					  SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        throw ex;
                    }
                    else
                    {
                       // return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
					   return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
                SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                model.IsNew = true;
                var me = GetContextModel(UIModelContextTypes.EditForm, model, true, model.GuidOrganization);
                Showing(ref me);
                if (isPopUp)
                {
                    
                        ViewData["ispopup"] = isPopUp;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
					if (Request != null)
						return ResolveView(me, model);
					else
						return Content("ok");
            }
        }        
        //
        // GET: /SDOrganizations/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }
			
		
		[MyAuthorize("u", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
		[MvcSiteMapNode(Area="SFSServiceDesk", Title="sss", Clickable=false, ParentKey = "SFSServiceDesk_SDOrganization_List")]
		public ActionResult EditGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDOrganizationResources.ENTITY_SINGLE;		 	
  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDOrganizationModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
            SDOrganizationModel model = null;
            // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
			bool dec = false;
            Guid ? idGuidDecripted = null ;
            if (Request != null && Request.QueryString["dec"] == "true")
            {
                dec = true;
                idGuidDecripted = Guid.Parse(id);
            }

            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model,dec,idGuidDecripted);
            Showing(ref me);


            if (!replaceResult)
            {
                 //return View("EditGen", me.Items[0]);
				 return ResolveView(me, me.Items[0]);
            }
            else {
                return e.ActionResult;
            }
        }
			[MyAuthorize("u", "SDOrganization","SFSServiceDesk", typeof(SDOrganizationsController))]
		public ActionResult EditViewGen(string id)
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

					  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDOrganizationModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
			
            SDOrganizationModel model = null;
			 bool dec = false;
            Guid? guidId = null ;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                dec = true;
                guidId = Guid.Parse(id);
            }
            // si fue implementado el método parcial y no se ha decidido suspender la acción
            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
            var me = GetContextModel(UIModelContextTypes.EditForm, model, dec, guidId);
            Showing(ref me);

            return ResolveView(me, model);
        }
		[MyAuthorize("u", "SDOrganization",  "SFSServiceDesk", typeof(SDOrganizationsController))]
		[HttpPost]
		[ValidateInput(false)] 
		        public ActionResult EditGen(SDOrganizationModel model)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
			e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDOrganizationModel>() { Item = model });
           
            if (!ModelState.IsValid)
            {
			   	var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
			
				if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"])){
                	ViewData["ispopup"] = true;
					return ResolveView(me, model);
				}
				else
					return ResolveView(me, model);
            }
            try
            {
			
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnEditing(this, e = new ControllerEventArgs<SDOrganizationModel>() { Item = model });
                if (e != null) {
                    if (e.Cancel && e.ActionResult != null)
                        return e.ActionResult;
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				ContextRequest context = new ContextRequest();
                context.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;

                SDOrganization resultObj = null;
			    if (!cancel)
                	resultObj = SDOrganizationsBR.Instance.Update(model.GetBusinessObject(), GetContextRequest());
				
				OnEdited(this, e = new ControllerEventArgs<SDOrganizationModel>() { Item =   new SDOrganizationModel(resultObj) });
				if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                         return ResolveApiResponse("success", null, null, null);
                    }
                }
				
				if (e != null && e.ActionResult != null) replaceResult = true; 

                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Content("ok");
                }
                else
                {
				if (!replaceResult)
                {
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"])  && string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
						 if (Request != null && Request.QueryString["dec"] == "true")
                        {
                            popupextra.Add("id", model.Id);
                        }
                        else
                        {
							popupextra.Add("id", model.SafeKey);

							
                        }
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                        {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                        popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area"));
                        popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                        popupextra.Add("action", actionDetails);
                        if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
					if (isPopUp)
						return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.UPDATE_DONE));
        			    string returnUrl = null;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"])) {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.Form["ReturnAfter"];
                        else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"];
                    }
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else{
		RouteValueDictionary popupextra = null; 
						 if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"]))
                            {
							
							popupextra = GetRouteData();
							string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
							if (!string.IsNullOrEmpty(area))
								popupextra.Add("area", area);

							return RedirectToAction("Index", popupextra);
						}else{
							return Content("ok");
						}
						}
				 }
                else {
                    return e.ActionResult;
				}
                }		
            }
          catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content(ex.ToString());
                    }
                    else
                    {
                        //return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
						 return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
			    if (isPopUp)
                {
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(ex.Message));
                    
                }
                else
                {
                    SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                    
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else {
						  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
							ViewData["ispopup"] = true;
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
							ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
							ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

						var me = GetContextModel(UIModelContextTypes.EditForm, model);
						Showing(ref me);

						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
						{
							ViewData["ispopup"] = true;
							return ResolveView(me, model);
						}
						else
							return ResolveView(me, model);

						
					}
				}
            }
        }
        //
        // POST: /SDOrganizations/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //  Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SDOrganizations/Delete/5
        
		[MyAuthorize("d", "SDOrganization", "SFSServiceDesk", typeof(SDOrganizationsController))]
		[HttpDelete]
        public ActionResult DeleteGen(string objectKey, string extraParams)
        {
            try
            {
					
			
				Guid guidOrganization = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey.Replace("-", "/"), "GuidOrganization")); 
                BO.SDOrganization entity = new BO.SDOrganization() { GuidOrganization = guidOrganization };

                BR.SDOrganizationsBR.Instance.Delete(entity, GetContextRequest());               
                return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.DELETE_DONE));

            }
            catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null)
                    {
                        message = ex.Data["usermessage"].ToString();
                    }

                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }
            }
        }
		/*[MyAuthorize()]
		public FileMediaResult Download(string query, bool? allSelected = false,  string selected = null , string orderBy = null , string direction = null , string format = null , string actionKey=null )
        {
			
            List<Guid> keysSelected1 = new List<Guid>();
            if (!string.IsNullOrEmpty(selected)) {
                foreach (var keyString in selected.Split(char.Parse("|")))
                {
				
                    keysSelected1.Add(Guid.Parse(keyString));
                }
            }
				
            query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(query, allSelected.Value, selected, "GuidOrganization");
            MyEventArgs<ContextActionModel<SDOrganizationModel>> eArgs = null;
            List<SDOrganizationModel> results = GetBy(query, null, null, orderBy, direction, GetContextRequest(), keysSelected1);
            OnDownloading(this, eArgs = new MyEventArgs<ContextActionModel<SDOrganizationModel>>() { Object = new ContextActionModel<SDOrganizationModel>() { Query = query, SelectedItems = results, Selected=selected, SelectAll = allSelected.Value, Direction = direction , OrderBy = orderBy, ActionKey=actionKey  } });

            if (eArgs != null)
            {
                if (eArgs.Object.Result != null)
                    return (FileMediaResult)eArgs.Object.Result;
            }
            

            return (new FeaturesController()).ExportDownload(typeof(SDOrganizationModel), results, format, this.GetUIPluralText("SFSServiceDesk", "SDOrganization"));
            
        }
			*/
		
		[HttpPost]
        public ActionResult CustomActionExecute(ContextActionModel model) {
		 try
            {
			//List<Guid> keysSelected1 = new List<Guid>();
			List<object> keysSelected1 = new List<object>();
            if (!string.IsNullOrEmpty(model.Selected))
            {
                foreach (var keyString in model.Selected.Split(char.Parse(",")))
                {
				
				keysSelected1.Add(Guid.Parse(keyString.Split(char.Parse("|"))[0]));
                        
                    

			
                }
            }
			DataAction dataAction = DataAction.GetDataAction(Request);
			 model.Selected = dataAction.Selected;

            model.Query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(dataAction.Query, dataAction.AllSelected, dataAction.Selected, "GuidOrganization");
           
            
			
			#region implementaci�n de m�todo parcial
            bool replaceResult = false;
            MyEventArgs<ContextActionModel<SDOrganizationModel>> actionEventArgs = null;
           
			if (model.ActionKey != "deletemany" && model.ActionKey != "deleterelmany" && model.ActionKey != "updateRel" &&  model.ActionKey != "delete-relation-fk" && model.ActionKey != "restore" )
			{
				ContextRequest context = SFSdotNet.Framework.My.Context.BuildContextRequestSafe(System.Web.HttpContext.Current);
				context.UseMode = dataAction.Usemode;

				if (model.IsBackground)
				{
					System.Threading.Tasks.Task.Run(() => 
						OnCustomActionExecutingBackground(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDOrganizationModel>>() { Object = new ContextActionModel<SDOrganizationModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } })
					);
				}
				else
				{
					OnCustomActionExecuting(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDOrganizationModel>>() {  Object = new ContextActionModel<SDOrganizationModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } });
				}
			}
            List<SDOrganizationModel> results = null;
	
			if (model.ActionKey == "deletemany") { 
				
				BR.SDOrganizationsBR.Instance.Delete(model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());

            }
	
            else if (model.ActionKey == "updateRel" || model.ActionKey == "delete-relation-fk" || model.ActionKey == "updateRel-proxyMany")
            {
               try {
                   string valueForUpdate = null;
				   string propForUpdate = null;
				   if (!string.IsNullOrEmpty(Request.Params["propertyForUpdate"])){
						propForUpdate = Request.Params["propertyForUpdate"];
				   }
				    if (string.IsNullOrEmpty(propForUpdate) && !string.IsNullOrEmpty(Request.QueryString["propertyForUpdate"]))
                   {
                       propForUpdate = Request.QueryString["propertyForUpdate"];
                   }
                    if (model.ActionKey != "delete-relation-fk")
                    {
                        valueForUpdate = Request.QueryString["valueForUpdate"];
                    }
                    BR.SDOrganizationsBR.Instance.UpdateAssociation(propForUpdate, valueForUpdate, model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());
					
                    if (model.ActionKey == "delete-relation-fk")
                    {
                        MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]);

                        return PartialView("ResultMessageView", message);
                    }
                    else
                    {
                        return Content("ok");
                    }
       
          
                }
                catch (Exception ex)
                {
				        SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
           
                }
            
            }
		
                if (actionEventArgs == null && !model.IsBackground)
                {
                    //if (model.ActionKey != "deletemany"  && model.ActionKey != "deleterelmany")
                    //{
                     //   throw new NotImplementedException("");
                    //}
                }
                else
                {
					if (model.IsBackground == false )
						 replaceResult = actionEventArgs.Object.Result is ActionResult /*actionEventArgs.Object.ReplaceResult*/;
                }
                #endregion
                if (!replaceResult)
                {
                    if (Request != null && Request.IsAjaxRequest())
                    {
						MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]) ;
                        if (model.IsBackground )
                            message.Message = GlobalMessages.THE_PROCESS_HAS_BEEN_STARTED;
                        
                        return PartialView("ResultMessageView", message);                    
					}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return (ActionResult)actionEventArgs.Object.Result;
                }
            }
            catch (Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null) {
                        message = ex.Data["usermessage"].ToString();
                    }
					 SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }

            }
        }
        //
        // POST: /SDOrganizations/Delete/5
        
			
	
    }
}
namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
	using SFS.ServiceDesk.Web.Mvc.Models.SDPersons;

    public partial class SDPersonsController : SFS.ServiceDesk.Web.Mvc.ControllerBase<Models.SDPersons.SDPersonModel>
    {

       


	#region partial methods
        ControllerEventArgs<Models.SDPersons.SDPersonModel> e = null;
        partial void OnValidating(object sender, ControllerEventArgs<Models.SDPersons.SDPersonModel> e);
        partial void OnGettingExtraData(object sender, MyEventArgs<UIModel<Models.SDPersons.SDPersonModel>> e);
        partial void OnCreating(object sender, ControllerEventArgs<Models.SDPersons.SDPersonModel> e);
        partial void OnCreated(object sender, ControllerEventArgs<Models.SDPersons.SDPersonModel> e);
        partial void OnEditing(object sender, ControllerEventArgs<Models.SDPersons.SDPersonModel> e);
        partial void OnEdited(object sender, ControllerEventArgs<Models.SDPersons.SDPersonModel> e);
        partial void OnDeleting(object sender, ControllerEventArgs<Models.SDPersons.SDPersonModel> e);
        partial void OnDeleted(object sender, ControllerEventArgs<Models.SDPersons.SDPersonModel> e);
    	partial void OnShowing(object sender, MyEventArgs<UIModel<Models.SDPersons.SDPersonModel>> e);
    	partial void OnGettingByKey(object sender, ControllerEventArgs<Models.SDPersons.SDPersonModel> e);
        partial void OnTaken(object sender, ControllerEventArgs<Models.SDPersons.SDPersonModel> e);
       	partial void OnCreateShowing(object sender, ControllerEventArgs<Models.SDPersons.SDPersonModel> e);
		partial void OnEditShowing(object sender, ControllerEventArgs<Models.SDPersons.SDPersonModel> e);
		partial void OnDetailsShowing(object sender, ControllerEventArgs<Models.SDPersons.SDPersonModel> e);
 		partial void OnActionsCreated(object sender, MyEventArgs<UIModel<Models.SDPersons.SDPersonModel >> e);
		partial void OnCustomActionExecuting(object sender, MyEventArgs<ContextActionModel<Models.SDPersons.SDPersonModel>> e);
		partial void OnCustomActionExecutingBackground(object sender, MyEventArgs<ContextActionModel<Models.SDPersons.SDPersonModel>> e);
        partial void OnDownloading(object sender, MyEventArgs<ContextActionModel<Models.SDPersons.SDPersonModel>> e);
      	partial void OnAuthorization(object sender, AuthorizationContext context);
		 partial void OnFilterShowing(object sender, MyEventArgs<UIModel<Models.SDPersons.SDPersonModel >> e);
         partial void OnSummaryOperationShowing(object sender, MyEventArgs<UIModel<Models.SDPersons.SDPersonModel>> e);

        partial void OnExportActionsCreated(object sender, MyEventArgs<UIModel<Models.SDPersons.SDPersonModel>> e);


		protected override void OnVirtualFilterShowing(object sender, MyEventArgs<UIModel<SDPersonModel>> e)
        {
            OnFilterShowing(sender, e);
        }
		 public override void OnVirtualExportActionsCreated(object sender, MyEventArgs<UIModel<SDPersonModel>> e)
        {
            OnExportActionsCreated(sender, e);
        }
        public override void OnVirtualDownloading(object sender, MyEventArgs<ContextActionModel<SDPersonModel>> e)
        {
            OnDownloading(sender, e);
        }
        public override void OnVirtualShowing(object sender, MyEventArgs<UIModel<SDPersonModel>> e)
        {
            OnShowing(sender, e);
        }

	#endregion
	#region API
	 public override ActionResult ApiCreateGen(SDPersonModel model, ContextRequest contextRequest)
        {
            return CreateGen(model, contextRequest);
        }

              public override ActionResult ApiGetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJson(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }
        public override ActionResult ApiGetByKeyJson(string id, ContextRequest contextRequest)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
            return  GetByKeyJson(id, contextRequest, true);
        }
      
		 public override ActionResult ApiGetByCount(string filter, ContextRequest contextRequest)
        {
            return GetByCount(filter, contextRequest);
        }
         protected override ActionResult ApiDeleteGen(List<SDPersonModel> models, ContextRequest contextRequest)
        {
            List<SDPerson> objs = new List<SDPerson>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                BR.SDPersonsBR.Instance.DeleteBulk(objs, contextRequest);
                if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("success", null, null, null);

                }
                else
                {
                    return Content("ok");

                }
            }
            catch (Exception ex)
            {
               if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "error", reason = "error", message= ex.ToString() }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("error", "exception", ex.ToString(), null );

                }
                else
                {
                    return Json(ex.ToString(), JsonRequestBehavior.AllowGet);

                }
            }
        }
        protected override ActionResult ApiUpdateGen(List<SDPersonModel> models, ContextRequest contextRequest)
        {
            List<SDPerson> objs = new List<SDPerson>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                foreach (var obj in objs)
                {
                    BR.SDPersonsBR.Instance.Update(obj, contextRequest);

                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }


	#endregion
#region Validation methods	
	    private void Validations(SDPersonModel model) { 
            #region Remote validations

            #endregion
		}

#endregion
		
 		public AuthorizationContext Authorization(AuthorizationContext context)
        {
            OnAuthorization(this,  context );
            return context ;
        }
		public List<SDPersonModel> GetAll() {
            			var bos = BR.SDPersonsBR.Instance.GetBy("",
					new SFSdotNet.Framework.My.ContextRequest()
					{
						CustomQuery = new SFSdotNet.Framework.My.CustomQuery()
						{
							OrderBy = "DisplayName",
							SortDirection = SFSdotNet.Framework.Data.SortDirection.Ascending
						}
					});
            			List<SDPersonModel> results = new List<SDPersonModel>();
            SDPersonModel model = null;
            foreach (var bo in bos)
            {
                model = new SDPersonModel();
                model.Bind(bo);
                results.Add(model);
            }
            return results;

        }
        //
        // GET: /SDPersons/
		[MyAuthorize("r", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
		public ActionResult Index()
        {
    		var uiModel = GetContextModel(UIModelContextTypes.ListForm, null);
			ViewBag.UIModel = uiModel;
			uiModel.FilterStart = (string)ViewData["startFilter"];
                    MyEventArgs<UIModel<SDPersonModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDPersonModel>>() { Object = uiModel });

			OnExportActionsCreated(this, (me != null ? me : me = new MyEventArgs<UIModel<SDPersonModel>>() { Object = uiModel }));

            if (me != null)
            {
                uiModel = me.Object;
            }
            if (me == null)
                me = new MyEventArgs<UIModel<SDPersonModel>>() { Object = uiModel };
           
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;


            //return View("ListGen");
			return ResolveView(uiModel);
        }
		[MyAuthorize("r", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
		public ActionResult ListViewGen(string idTab, string fk , string fkValue, string startFilter, ListModes  listmode  = ListModes.SimpleList, PropertyDefinition parentRelationProperty = null, object parentRelationPropertyValue = null )
        {
			ViewData["idTab"] = System.Web.HttpContext.Current.Request.QueryString["idTab"]; 
		 	ViewData["detpop"] = true; // details in popup
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"])) {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"]; 
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
            {
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["startFilter"]))
            {
                ViewData["startFilter"] = Request.QueryString["startFilter"];
            }
			
			UIModel<SDPersonModel> uiModel = GetContextModel(UIModelContextTypes.ListForm, null);

            MyEventArgs<UIModel<SDPersonModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDPersonModel>>() { Object = uiModel });
            if (me == null)
                me = new MyEventArgs<UIModel<SDPersonModel>>() { Object = uiModel };
            uiModel.Properties = GetProperties(uiModel);
            uiModel.ContextType = UIModelContextTypes.ListForm;
             uiModel.FilterStart = (string)ViewData["startFilter"];
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;
			 if (listmode == ListModes.SimpleList)
                return ResolveView(uiModel);
            else
            {
                ViewData["parentRelationProperty"] = parentRelationProperty;
                ViewData["parentRelationPropertyValue"] = parentRelationPropertyValue;
                return PartialView("ListForTagSelectView");
            }
            return ResolveView(uiModel);
        }
		List<PropertyDefinition> _properties = null;

		 protected override List<PropertyDefinition> GetProperties(UIModel uiModel,  params string[] specificProperties)
        { 
            return GetProperties(uiModel, false, null, specificProperties);
        }

		protected override List<PropertyDefinition> GetProperties(UIModel uiModel, bool decripted, Guid? id, params string[] specificProperties)
            {

			bool allProperties = true;    
                if (specificProperties != null && specificProperties.Length > 0)
                {
                    allProperties = false;
                }


			List<CustomProperty> customProperties = new List<CustomProperty>();
			if (_properties == null)
                {
                List<PropertyDefinition> results = new List<PropertyDefinition>();

			string idSDPerson = GetRouteDataOrQueryParam("id");
			if (idSDPerson != null)
			{
				if (!decripted)
                {
					idSDPerson = SFSdotNet.Framework.Entities.Utils.GetPropertyKey(idSDPerson.Replace("-","/"), "GuidPerson");
				}else{
					if (id != null )
						idSDPerson = id.Value.ToString();                

				}
			}

			bool visibleProperty = true;	
			 bool conditionalshow =false;
                if (uiModel.ContextType == UIModelContextTypes.EditForm || uiModel.ContextType == UIModelContextTypes.DisplayForm ||  uiModel.ContextType == UIModelContextTypes.GenericForm )
                    conditionalshow = true;
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidPerson"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidPerson")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 100,
																	
					CustomProperties = customProperties,

                    PropertyName = "GuidPerson",

					 MaxLength = 0,
					IsRequired = true ,
					IsHidden = true,
                    SystemProperty =  SystemProperties.Identifier ,
					IsDefaultProperty = false,
                    SortBy = "GuidPerson",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDPersonResources.GUIDPERSON*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("DisplayName"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "DisplayName")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 101,
																	
					CustomProperties = customProperties,

                    PropertyName = "DisplayName",

					 MaxLength = 255,
					 Nullable = true,
					IsDefaultProperty = true,
                    SortBy = "DisplayName",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDPersonResources.DISPLAYNAME*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidUser"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidUser")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 102,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidUser",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "GuidUser",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDPersonResources.GUIDUSER*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidOrganization"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidOrganization")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 103,
																	IsForeignKey = true,

									
					CustomProperties = customProperties,

                    PropertyName = "GuidOrganization",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "GuidOrganization",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDPersonResources.GUIDORGANIZATION*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDAreaPersons"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDPerson" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDAreaPersons.GuidAreaPerson")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDAreaPersons.GuidAreaPerson" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDAreaPersons" });
			

	
	//fk_SdAreaPerson_SdPerson
		//if (this.Request.QueryString["fk"] != "SDAreaPersons")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 104,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDAreaPersons/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDAreaPersons&fk=SDPerson&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDPerson.GuidPerson = Guid(\"" + idSDPerson +"\")")+ "&fkValue=" + idSDPerson,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDAreaPerson",
					
					CustomProperties = customProperties,

                    PropertyName = "SDAreaPersons",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDAreaPersons.GuidAreaPerson",
					
	
                    TypeName = "SFSServiceDeskModel.SDAreaPerson",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDAreaPersons"
                    /*,PropertyDisplayName = Resources.SDPersonResources.SDAREAPERSONS*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDCases"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDPerson" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDCases.GuidCase")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDCases.GuidCase" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDCases" });
			

	
	//fk_Case_Person_Client
		//if (this.Request.QueryString["fk"] != "SDCases")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 105,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDCases/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDCases&fk=SDPerson&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDPerson.GuidPerson = Guid(\"" + idSDPerson +"\")")+ "&fkValue=" + idSDPerson,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDCase",
					
					CustomProperties = customProperties,

                    PropertyName = "SDCases",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDCases.BodyContent",
					
	
                    TypeName = "SFSServiceDeskModel.SDCase",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDCases"
                    /*,PropertyDisplayName = Resources.SDPersonResources.SDCASES*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDOrganization"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDPersons" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDOrganization.GuidOrganization")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDOrganization.GuidOrganization" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDOrganizations" });
			

	
	//fk_SdPerson_SdOrganization
		//if (this.Request.QueryString["fk"] != "SDOrganization")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 106,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDOrganization",
					PropertyNavigationKey = "GuidOrganization",
					PropertyNavigationText = "FullName",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="FullName",
					GetMethodDisplayValue = "GuidOrganization",
					
					CustomProperties = customProperties,

                    PropertyName = "SDOrganization",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDOrganization.FullName",
					
	
                    TypeName = "SFSServiceDeskModel.SDOrganization",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDOrganizations"
                    /*,PropertyDisplayName = Resources.SDPersonResources.SDORGANIZATION*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDProxyUser"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDPersons" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDProxyUser.GuidUser")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDProxyUser.GuidUser" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDProxyUsers" });
			

	
	//fk_SdPerson_SdProxyUser
		//if (this.Request.QueryString["fk"] != "SDProxyUser")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 107,
																
					
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDProxyUser",
					PropertyNavigationKey = "GuidUser",
					PropertyNavigationText = "Email",
					NavigationPropertyType = NavigationPropertyTypes.SimpleDropDown,
					GetMethodName = "GetAll",
					GetMethodParameters = "",
					GetMethodDisplayText ="Email",
					GetMethodDisplayValue = "GuidUser",
					
					CustomProperties = customProperties,

                    PropertyName = "SDProxyUser",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDProxyUser.Email",
					
	
                    TypeName = "SFSServiceDeskModel.SDProxyUser",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/SDProxyUsers"
                    /*,PropertyDisplayName = Resources.SDPersonResources.SDPROXYUSER*/
                });
		//	}
	
	}
	
				
                    _properties = results;
                    return _properties;
                }
                else {
                    return _properties;
                }
            }

		protected override  UIModel<SDPersonModel> GetByForShow(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, params  object[] extraParams)
        {
			if (Request != null )
				if (!string.IsNullOrEmpty(Request.QueryString["q"]))
					filter = filter + HttpUtility.UrlDecode(Request.QueryString["q"]);
 if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
            }
            var bos = BR.SDPersonsBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), contextRequest, extraParams);
			//var bos = BR.SDPersonsBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), context, extraParams);
            SDPersonModel model = null;
            List<SDPersonModel> results = new List<SDPersonModel>();
            foreach (var item in bos)
            {
                model = new SDPersonModel();
				model.Bind(item);
				results.Add(model);
            }
            //return results;
			UIModel<SDPersonModel> uiModel = GetContextModel(UIModelContextTypes.Items, null);
            uiModel.Items = results;
			if (Request != null){
				if (SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(Request.RequestContext, "action") == "Download")
				{
					uiModel.ContextType = UIModelContextTypes.ExportDownload;
				}
			}
            Showing(ref uiModel);
            return uiModel;
		}			
		
		//public List<SDPersonModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params  object[] extraParams)
        //{
		//	var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, null, extraParams);
        public override List<SDPersonModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest,  params  object[] extraParams)
        {
            var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
           
            return uiModel.Items;
		
        }
		/*
        [MyAuthorize("r", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir)
        {
			 return GetByJsonBase(filter, pageSize, page, orderBy, orderDir);
        }*/

		  [MyAuthorize("r", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir,ContextRequest contextRequest,  object[] extraParams)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
			 
			 if (this.IsRESTRequest == false)
            {
                return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
            }else
            {
                try
                {
                    return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);

                }
            }
        }
/*		  [MyAuthorize("r", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
       public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }*/
		[MyAuthorize()]
		public ActionResult GetByCount(string filter, ContextRequest contextRequest) {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
           
			
             if (this.IsRESTRequest == true)
            {
                try
                {

                    var result = BR.SDPersonsBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);

                   if (Request.QueryString["v"] == "2")
                    {
						return ResolveApiResponse("success", null, null, result);

                        //return Json(new { status = "success", data = result }, JsonRequestBehavior.AllowGet);
                    }else
                    {
                        return Content(result.ToString());

                    }
                }
                catch (Exception ex)
                {
                  //  return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
				  return ResolveApiResponse("error", "exception", ex.ToString(), null);

                }
            }
            else
            {
                var result = BR.SDPersonsBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);
                return Content(result.ToString());
            }
		}
		

		[MyAuthorize("r", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
        public ActionResult GetByKeyJson(string id, ContextRequest contextRequest,  bool dec = false)
        {
            return Json(GetByKey(id, null, contextRequest, dec), JsonRequestBehavior.AllowGet);
        }
		public SDPersonModel GetByKey(string id) {
			return GetByKey(id, null,null, false);
       	}
		    public SDPersonModel GetByKey(string id, string includes)
        {
            return GetByKey(id, includes, false);
        }
		 public  SDPersonModel GetByKey(string id, string includes, ContextRequest contextRequest)
        {
            return GetByKey(id, includes, contextRequest, false);
        }
		/*
		  public ActionResult ShowField(string fieldName, string idField) {
		   string safePropertyName = fieldName;
              if (fieldName.StartsWith("Fk"))
              {
                  safePropertyName = fieldName.Substring(2, fieldName.Length - 2);
              }

             SDPersonModel model = new  SDPersonModel();

            UIModel uiModel = GetUIModel(model, new string[] { "NoField-" });
			
				uiModel.Properties = GetProperties(uiModel, safePropertyName);
		uiModel.Properties.ForEach(p=> p.ContextType = uiModel.ContextType );
            uiModel.ContextType = UIModelContextTypes.FilterFields;
            uiModel.OverrideApp = GetOverrideApp();
            uiModel.UseMode = GetUseMode();

            ViewData["uiModel"] = uiModel;
			var prop = uiModel.Properties.FirstOrDefault(p=>p.PropertyName == safePropertyName);
            //if (prop.IsNavigationProperty && prop.IsNavigationPropertyMany == false)
            //{
            //    ViewData["currentProperty"] = uiModel.Properties.FirstOrDefault(p => p.PropertyName != fieldName + "Text");
            //}else if (prop.IsNavigationProperty == false){
                ViewData["currentProperty"] = prop;
           // }
            ((PropertyDefinition)ViewData["currentProperty"]).RemoveLayout = true;
			ViewData["withContainer"] = false;


            return PartialView("GenericField", model);


        }
      */
	public SDPersonModel GetByKey(string id, ContextRequest contextRequest, bool dec)
        {
            return GetByKey(id, null, contextRequest, dec);
        }
        public SDPersonModel GetByKey(string id, string  includes, bool dec)
        {
            return GetByKey(id, includes, null, dec);
        }

        public SDPersonModel GetByKey(string id, string includes, ContextRequest contextRequest, bool dec) {
		             SDPersonModel model = null;
            ControllerEventArgs<SDPersonModel> e = null;
			string objectKey = id.Replace("-","/");
             OnGettingByKey(this, e=  new ControllerEventArgs<SDPersonModel>() { Id = objectKey  });
             bool cancel = false;
             SDPersonModel eItem = null;
             if (e != null)
             {
                 cancel = e.Cancel;
                 eItem = e.Item;
             }
			if (cancel == false && eItem == null)
             {
			Guid guidPerson = Guid.Empty; //new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, "GuidPerson"));
			if (dec)
                 {
                     guidPerson = new Guid(id);
                 }
                 else
                 {
                     guidPerson = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, null));
                 }
			
            
				model = new SDPersonModel();
                  if (contextRequest == null)
                {
                    contextRequest = GetContextRequest();
                }
				var bo = BR.SDPersonsBR.Instance.GetByKey(guidPerson, GetUseMode(), contextRequest,  includes);
				 if (bo != null)
                    model.Bind(bo);
                else
                    return null;
			}
             else {
                 model = eItem;
             }
			model.IsNew = false;

            return model;
        }
        // GET: /SDPersons/DetailsGen/5
		[MyAuthorize("r", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
        public ActionResult DetailsGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDPersonResources.ENTITY_PLURAL;
			 #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDPersonModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
            #endregion



			 bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
			//UIModel<SDPersonModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, decripted), decripted, guidId);
			var item = GetByKey(id, null, null, decripted);
			if (item == null)
            {
                 RouteValueDictionary rv = new RouteValueDictionary();
                string usemode = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"usemode");
                string overrideModule = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "overrideModule");
                string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");

                if(!string.IsNullOrEmpty(usemode)){
                    rv.Add("usemode", usemode);
                }
                if(!string.IsNullOrEmpty(overrideModule)){
                    rv.Add("overrideModule", overrideModule);
                }
                if (!string.IsNullOrEmpty(area))
                {
                    rv.Add("area", area);
                }

                return RedirectToAction("Index", rv);
            }
            //
            UIModel<SDPersonModel> uiModel = null;
                uiModel = GetContextModel(UIModelContextTypes.DisplayForm, item, decripted, guidId);



            MyEventArgs<UIModel<SDPersonModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDPersonModel>>() { Object = uiModel });

            if (me != null) {
                uiModel = me.Object;
            }
			
            Showing(ref uiModel);
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			
            //return View("DisplayGen", uiModel.Items[0]);
			return ResolveView(uiModel, uiModel.Items[0]);

        }
		[MyAuthorize("r", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
		public ActionResult DetailsViewGen(string id)
        {

		 bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDPersonModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
           
			if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
 			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
           
        	 //var uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id));
			 
            bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true")
                {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
            UIModel<SDPersonModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, null, decripted), decripted, guidId);
			

            MyEventArgs<UIModel<SDPersonModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDPersonModel>>() { Object = uiModel });

            if (me != null)
            {
                uiModel = me.Object;
            }
            
            Showing(ref uiModel);
            return ResolveView(uiModel, uiModel.Items[0]);
        
        }
        //
        // GET: /SDPersons/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /SDPersons/CreateGen
		[MyAuthorize("c", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
        public ActionResult CreateGen()
        {
			SDPersonModel model = new SDPersonModel();
            model.IsNew = true;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model);

			OnCreateShowing(this, e = new ControllerEventArgs<SDPersonModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }

             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                 ViewData["ispopup"] = true;
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                 ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                 ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

            Showing(ref me);

			return ResolveView(me, me.Items[0]);
        } 
			
		protected override UIModel<SDPersonModel> GetContextModel(UIModelContextTypes formMode, SDPersonModel model)
        {
            return GetContextModel(formMode, model, false, null);
        }
			
		 private UIModel<SDPersonModel> GetContextModel(UIModelContextTypes formMode, SDPersonModel model, bool decript, Guid ? id) {
            UIModel<SDPersonModel> me = new UIModel<SDPersonModel>(true, "SDPersons");
			me.UseMode = GetUseMode();
			me.Controller = this;
			me.OverrideApp = GetOverrideApp();
			me.ContextType = formMode ;
			me.Id = "SDPerson";
			
            me.ModuleKey = "SFSServiceDesk";

			me.ModuleNamespace = "SFS.ServiceDesk";
            me.EntityKey = "SDPerson";
            me.EntitySetName = "SDPersons";

			me.AreaAction = "SFSServiceDesk";
            me.ControllerAction = "SDPersons";
            me.PropertyKeyName = "GuidPerson";

            me.Properties = GetProperties(me, decript, id);
 			
			if (Request != null)
            {
                string actionName = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam( Request.RequestContext, "action");
                if(actionName != null && actionName.ToLower().Contains("create") ){
                    me.IsNew = true;
                }
            }
			 #region Buttons
			 if (Request != null ){
             if (formMode == UIModelContextTypes.DisplayForm || formMode == UIModelContextTypes.EditForm || formMode == UIModelContextTypes.ListForm)
				me.ActionButtons = GetActionButtons(formMode,model != null ?(Request.QueryString["dec"] == "true" ? model.Id : model.SafeKey)  : null, "SFSServiceDesk", "SDPersons", "SDPerson", me.IsNew);

            //me.ActionButtons.Add(new ActionModel() { ActionKey = "return", Title = GlobalMessages.RETURN, Url = System.Web.VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDPersons" });
			if (this.HttpContext != null &&  !this.HttpContext.SkipAuthorization){
				//antes this.HttpContext
				me.SetAction("u", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("u", "SDPerson", "SFSServiceDesk"));
				me.SetAction("c", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("c", "SDPerson", "SFSServiceDesk"));
				me.SetAction("d", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("d", "SDPerson", "SFSServiceDesk"));
			
			}else{
				me.SetAction("u", true);
				me.SetAction("c", true);
				me.SetAction("d", true);

			}
            #endregion              
         
            switch (formMode)
            {
                case UIModelContextTypes.DisplayForm:
					//me.TitleForm = SDPersonResources.SDPERSONS_DETAILS;
                    me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.MODIFY_DATA;
					 me.Properties.Where(p=>p.PropertyName  != "Id" && p.IsForeignKey == false).ToList().ForEach(p => p.IsHidden = false);

					 me.Properties.Where(p => (p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier) ).ToList().ForEach(p=> me.SetHide(p.PropertyName));

                    break;
                case UIModelContextTypes.EditForm:
				  me.Properties.Where(p=>p.SystemProperty != SystemProperties.Identifier && p.IsForeignKey == false && p.PropertyName != "Id").ToList().ForEach(p => p.IsHidden = false);

					if (model != null)
                    {
						

                        me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.SAVE_DATA;                        
                        me.ActionButtons.First(p => p.ActionKey == "c").Title = GlobalMessages.SAVE_DATA;
						if (model.IsNew ){
							//me.TitleForm = SDPersonResources.SDPERSONS_ADD_NEW;
							me.ActionName = "CreateGen";
							me.Properties.RemoveAll(p => p.SystemProperty != null || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));
						}else{
							
							me.ActionName = "EditGen";

							//me.TitleForm = SDPersonResources.SDPERSONS_EDIT;
							me.Properties.RemoveAll(p => p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));	
						}
						//me.Properties.Remove(me.Properties.Find(p => p.PropertyName == "UpdatedDate"));
					
					}
                    break;
                case UIModelContextTypes.FilterFields:
                    break;
                case UIModelContextTypes.GenericForm:
                    break;
                case UIModelContextTypes.Items:
				//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "DisplayName") != null){
						me.Properties.Find(p => p.PropertyName == "DisplayName").IsHidden = false;
					 }
					 
                    
					

						 if (me.Properties.Find(p => p.PropertyName == "GuidPerson") != null){
						me.Properties.Find(p => p.PropertyName == "GuidPerson").IsHidden = false;
					 }
					 
                    
					


                  


					//}
                    break;
                case UIModelContextTypes.ListForm:
					PropertyDefinition propFinded = null;
					//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "DisplayName") != null){
						me.Properties.Find(p => p.PropertyName == "DisplayName").IsHidden = false;
					 }
					
					me.PrincipalActionName = "GetByJson";
					//}
					//me.TitleForm = SDPersonResources.SDPERSONS_LIST;
                    break;
                default:
                    break;
            }
            	this.SetDefaultProperties(me);
			}
			if (model != null )
            	me.Items.Add(model);
            return me;
        }
		// GET: /SDPersons/CreateViewGen
		[MyAuthorize("c", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
        public ActionResult CreateViewGen()
        {
				SDPersonModel model = new SDPersonModel();
            model.IsNew = true;
			e= null;
			OnCreateShowing(this, e = new ControllerEventArgs<SDPersonModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }
			
            var me = GetContextModel(UIModelContextTypes.EditForm, model);

			me.IsPartialView = true;	
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
            {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                me.Properties.Find(p => p.PropertyName == ViewData["fk"].ToString()).IsReadOnly = true;
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
			
      
            //me.Items.Add(model);
            Showing(ref me);
            return ResolveView(me, me.Items[0]);
        }
		protected override  void GettingExtraData(ref UIModel<SDPersonModel> uiModel)
        {

            MyEventArgs<UIModel<SDPersonModel>> me = null;
            OnGettingExtraData(this, me = new MyEventArgs<UIModel<SDPersonModel>>() { Object = uiModel });
            //bool maybeAnyReplaced = false; 
            if (me != null)
            {
                uiModel = me.Object;
                //maybeAnyReplaced = true;
            }
           
			bool canFill = false;
			 string query = null ;
            bool isFK = false;
			PropertyDefinition prop =null;
			var contextRequest = this.GetContextRequest();
            contextRequest.CustomParams.Add(new CustomParam() { Name="ui", Value= SDPerson.EntityName });

            			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDOrganization");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidOrganization = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidOrganization = @GuidOrganization";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidOrganization = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidOrganization = @GuidOrganization";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDOrganization")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidOrganization", new Nullable<Guid>(Guid.Parse( Request.QueryString["fkValue"])));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDOrganizationsBR()).GetBy(query, contextRequest), "GuidOrganization", "FullName", Request.QueryString["fkValue"]), PropertyName = "SDOrganization" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDOrganizationsBR()).GetBy(query, contextRequest), "GuidOrganization", "FullName"), PropertyName = "SDOrganization" });    

					}
    if (isFK)
                    {    
						var FkSDOrganization = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDOrganization").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDOrganizationText").SetValue(uiModel.Items[0], FkSDOrganization.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDOrganization").SetValue(uiModel.Items[0], Guid.Parse(FkSDOrganization.Value));
                    
					}    
				}
			}
		 
			canFill = false;
			 query = "";
            isFK =false;
			prop = uiModel.Properties.FirstOrDefault(p => p.PropertyName == "SDProxyUser");
			if (prop != null)
				if (prop.IsHidden == false && (prop.ContextType == UIModelContextTypes.EditForm || prop.ContextType == UIModelContextTypes.FilterFields  || (prop.ContextType == null && uiModel.ContextType == UIModelContextTypes.EditForm)))
				{
					if (prop.NavigationPropertyType == NavigationPropertyTypes.SimpleDropDown )
						canFill = true;
				}
                else if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidUser = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidUser = @GuidUser";
					
					canFill = true;
                }
				if (prop.IsHidden == false && UsingFrom(prop.PropertyName) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))
                {
                    isFK = true;
                    // es prop FK y se ve
                    //query = "GuidUser = Guid(\"" + Request.QueryString["fkValue"] + "\")";
                    query = "GuidUser = @GuidUser";
					canFill = true;
                }
			if (canFill){
			                contextRequest.CustomQuery = new CustomQuery();

				if (!uiModel.ExtraData.Exists(p => p.PropertyName == "SDProxyUser")) {
					if (!string.IsNullOrEmpty(query) && !string.IsNullOrEmpty(Request.QueryString["fkValue"]))				  
						contextRequest.CustomQuery.SetParam("GuidUser", new Nullable<Guid>(Guid.Parse( Request.QueryString["fkValue"])));

					 if (isFK == true)
                    {
						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDProxyUsersBR()).GetBy(query, contextRequest), "GuidUser", "Email", Request.QueryString["fkValue"]), PropertyName = "SDProxyUser" });    
                    }
                    else
                    {

						uiModel.ExtraData.Add(new ExtraData() { Data = new SelectList((IEnumerable)(new SFS.ServiceDesk.BR.SDProxyUsersBR()).GetBy(query, contextRequest), "GuidUser", "Email"), PropertyName = "SDProxyUser" });    

					}
    if (isFK)
                    {    
						var FkSDProxyUser = ((SelectList)uiModel.ExtraData.First(p => p.PropertyName == "SDProxyUser").Data).First();
						uiModel.Items[0].GetType().GetProperty("FkSDProxyUserText").SetValue(uiModel.Items[0], FkSDProxyUser.Text);
						uiModel.Items[0].GetType().GetProperty("FkSDProxyUser").SetValue(uiModel.Items[0], Guid.Parse(FkSDProxyUser.Value));
                    
					}    
				}
			}
		 
            

        }
		private void Showing(ref UIModel<SDPersonModel> uiModel) {
          	
			MyEventArgs<UIModel<SDPersonModel>> me = new MyEventArgs<UIModel<SDPersonModel>>() { Object = uiModel };
			 OnVirtualLayoutSettings(this, me);


            OnShowing(this, me);

			
			if ((Request != null && Request.QueryString["allFields"] == "1") || Request == null )
			{
				me.Object.Properties.ForEach(p=> p.IsHidden = false);
            }
            if (me != null)
            {
                uiModel = me.Object;
            }
          


			 if (uiModel.ContextType == UIModelContextTypes.EditForm)
			    GettingExtraData(ref uiModel);
            ViewData["UIModel"] = uiModel;

        }
        //
        // POST: /SDPersons/Create
		[MyAuthorize("c", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
        [HttpPost]
		[ValidateInput(false)] 
        public ActionResult CreateGen(SDPersonModel  model,  ContextRequest contextRequest)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
		 	e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDPersonModel>() { Item = model });
           
		  	if (!ModelState.IsValid) {
				model.IsNew = true;
				var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
                 if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                        ViewData["ispopup"] = true;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
                    return ResolveView(me, model);
            }
            try
            {
				if (model.GuidPerson == null || model.GuidPerson.ToString().Contains("000000000"))
				model.GuidPerson = Guid.NewGuid();
	
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnCreating(this, e = new ControllerEventArgs<SDPersonModel>() { Item = model });
                if (e != null) {
                   if (e.Cancel && e.RedirectValues.Count > 0){
                        RouteValueDictionary rv = new RouteValueDictionary();
                        if (e.RedirectValues["area"] != null ){
                            rv.Add("area", e.RedirectValues["area"].ToString());
                        }
                        foreach (var item in e.RedirectValues.Where(p=>p.Key != "area" && p.Key != "controller" &&  p.Key != "action" ))
	                    {
		                    rv.Add(item.Key, item.Value);
	                    }

                        //if (e.RedirectValues["action"] != null && e.RedirectValues["controller"] != null && e.RedirectValues["area"] != null )
                        return RedirectToAction(e.RedirectValues["action"].ToString(), e.RedirectValues["controller"].ToString(), rv );


                        
                    }else if (e.Cancel && e.ActionResult != null )
                        return e.ActionResult;  
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				if (contextRequest == null || contextRequest.Company == null){
					contextRequest = GetContextRequest();
					
				}
                if (!cancel)
                	model.Bind(SDPersonsBR.Instance.Create(model.GetBusinessObject(), contextRequest ));
				OnCreated(this, e = new ControllerEventArgs<SDPersonModel>() { Item = model });
                 if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                        return ResolveApiResponse("success", null, null, null);

                    }
                }
				 
				 if (e != null )
					if (e.ActionResult != null)
                    	replaceResult = true;		
				if (!replaceResult)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))
                    {
                        ViewData["__continue"] = true;
                    }
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"]) &&  string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
                        popupextra.Add("id", model.SafeKey);
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                       {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                            popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"area"));
                            popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                            popupextra.Add("action", actionDetails);
                       if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
                    {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))

                        {
                            var popupextra = GetRouteData();
                            popupextra.Add("id", model.SafeKey);
                            return RedirectToAction("EditViewGen", popupextra);
                        }
                        else
                        {
                            return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.ADD_DONE));
                        }
                    }        			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                        return Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]);
                    else{

							RouteValueDictionary popupextra = null; 
							if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"])){
                            popupextra = GetRouteData();
							 string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
                            if (!string.IsNullOrEmpty(area))
                                popupextra.Add("area", area);
                            
                            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"])) {
								popupextra.Add("id", model.SafeKey);
                                return RedirectToAction("EditGen", popupextra);

                            }else{
								
                            return RedirectToAction("Index", popupextra);
							}
							}else{
								return Content("ok");
							}
                        }
						 }
                else {
                    return e.ActionResult;
                    }
				}
            catch(Exception ex)
            {
					  SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        throw ex;
                    }
                    else
                    {
                       // return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
					   return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
                SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                model.IsNew = true;
                var me = GetContextModel(UIModelContextTypes.EditForm, model, true, model.GuidPerson);
                Showing(ref me);
                if (isPopUp)
                {
                    
                        ViewData["ispopup"] = isPopUp;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
					if (Request != null)
						return ResolveView(me, model);
					else
						return Content("ok");
            }
        }        
        //
        // GET: /SDPersons/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }
			
		
		[MyAuthorize("u", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
		[MvcSiteMapNode(Area="SFSServiceDesk", Title="sss", Clickable=false, ParentKey = "SFSServiceDesk_SDPerson_List")]
		public ActionResult EditGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDPersonResources.ENTITY_SINGLE;		 	
  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDPersonModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
            SDPersonModel model = null;
            // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
			bool dec = false;
            Guid ? idGuidDecripted = null ;
            if (Request != null && Request.QueryString["dec"] == "true")
            {
                dec = true;
                idGuidDecripted = Guid.Parse(id);
            }

            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model,dec,idGuidDecripted);
            Showing(ref me);


            if (!replaceResult)
            {
                 //return View("EditGen", me.Items[0]);
				 return ResolveView(me, me.Items[0]);
            }
            else {
                return e.ActionResult;
            }
        }
			[MyAuthorize("u", "SDPerson","SFSServiceDesk", typeof(SDPersonsController))]
		public ActionResult EditViewGen(string id)
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

					  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDPersonModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
			
            SDPersonModel model = null;
			 bool dec = false;
            Guid? guidId = null ;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                dec = true;
                guidId = Guid.Parse(id);
            }
            // si fue implementado el método parcial y no se ha decidido suspender la acción
            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
            var me = GetContextModel(UIModelContextTypes.EditForm, model, dec, guidId);
            Showing(ref me);

            return ResolveView(me, model);
        }
		[MyAuthorize("u", "SDPerson",  "SFSServiceDesk", typeof(SDPersonsController))]
		[HttpPost]
		[ValidateInput(false)] 
		        public ActionResult EditGen(SDPersonModel model)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
			e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDPersonModel>() { Item = model });
           
            if (!ModelState.IsValid)
            {
			   	var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
			
				if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"])){
                	ViewData["ispopup"] = true;
					return ResolveView(me, model);
				}
				else
					return ResolveView(me, model);
            }
            try
            {
			
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnEditing(this, e = new ControllerEventArgs<SDPersonModel>() { Item = model });
                if (e != null) {
                    if (e.Cancel && e.ActionResult != null)
                        return e.ActionResult;
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				ContextRequest context = new ContextRequest();
                context.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;

                SDPerson resultObj = null;
			    if (!cancel)
                	resultObj = SDPersonsBR.Instance.Update(model.GetBusinessObject(), GetContextRequest());
				
				OnEdited(this, e = new ControllerEventArgs<SDPersonModel>() { Item =   new SDPersonModel(resultObj) });
				if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                         return ResolveApiResponse("success", null, null, null);
                    }
                }
				
				if (e != null && e.ActionResult != null) replaceResult = true; 

                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Content("ok");
                }
                else
                {
				if (!replaceResult)
                {
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"])  && string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
						 if (Request != null && Request.QueryString["dec"] == "true")
                        {
                            popupextra.Add("id", model.Id);
                        }
                        else
                        {
							popupextra.Add("id", model.SafeKey);

							
                        }
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                        {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                        popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area"));
                        popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                        popupextra.Add("action", actionDetails);
                        if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
					if (isPopUp)
						return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.UPDATE_DONE));
        			    string returnUrl = null;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"])) {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.Form["ReturnAfter"];
                        else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"];
                    }
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else{
		RouteValueDictionary popupextra = null; 
						 if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"]))
                            {
							
							popupextra = GetRouteData();
							string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
							if (!string.IsNullOrEmpty(area))
								popupextra.Add("area", area);

							return RedirectToAction("Index", popupextra);
						}else{
							return Content("ok");
						}
						}
				 }
                else {
                    return e.ActionResult;
				}
                }		
            }
          catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content(ex.ToString());
                    }
                    else
                    {
                        //return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
						 return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
			    if (isPopUp)
                {
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(ex.Message));
                    
                }
                else
                {
                    SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                    
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else {
						  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
							ViewData["ispopup"] = true;
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
							ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
							ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

						var me = GetContextModel(UIModelContextTypes.EditForm, model);
						Showing(ref me);

						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
						{
							ViewData["ispopup"] = true;
							return ResolveView(me, model);
						}
						else
							return ResolveView(me, model);

						
					}
				}
            }
        }
        //
        // POST: /SDPersons/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //  Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SDPersons/Delete/5
        
		[MyAuthorize("d", "SDPerson", "SFSServiceDesk", typeof(SDPersonsController))]
		[HttpDelete]
        public ActionResult DeleteGen(string objectKey, string extraParams)
        {
            try
            {
					
			
				Guid guidPerson = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey.Replace("-", "/"), "GuidPerson")); 
                BO.SDPerson entity = new BO.SDPerson() { GuidPerson = guidPerson };

                BR.SDPersonsBR.Instance.Delete(entity, GetContextRequest());               
                return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.DELETE_DONE));

            }
            catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null)
                    {
                        message = ex.Data["usermessage"].ToString();
                    }

                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }
            }
        }
		/*[MyAuthorize()]
		public FileMediaResult Download(string query, bool? allSelected = false,  string selected = null , string orderBy = null , string direction = null , string format = null , string actionKey=null )
        {
			
            List<Guid> keysSelected1 = new List<Guid>();
            if (!string.IsNullOrEmpty(selected)) {
                foreach (var keyString in selected.Split(char.Parse("|")))
                {
				
                    keysSelected1.Add(Guid.Parse(keyString));
                }
            }
				
            query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(query, allSelected.Value, selected, "GuidPerson");
            MyEventArgs<ContextActionModel<SDPersonModel>> eArgs = null;
            List<SDPersonModel> results = GetBy(query, null, null, orderBy, direction, GetContextRequest(), keysSelected1);
            OnDownloading(this, eArgs = new MyEventArgs<ContextActionModel<SDPersonModel>>() { Object = new ContextActionModel<SDPersonModel>() { Query = query, SelectedItems = results, Selected=selected, SelectAll = allSelected.Value, Direction = direction , OrderBy = orderBy, ActionKey=actionKey  } });

            if (eArgs != null)
            {
                if (eArgs.Object.Result != null)
                    return (FileMediaResult)eArgs.Object.Result;
            }
            

            return (new FeaturesController()).ExportDownload(typeof(SDPersonModel), results, format, this.GetUIPluralText("SFSServiceDesk", "SDPerson"));
            
        }
			*/
		
		[HttpPost]
        public ActionResult CustomActionExecute(ContextActionModel model) {
		 try
            {
			//List<Guid> keysSelected1 = new List<Guid>();
			List<object> keysSelected1 = new List<object>();
            if (!string.IsNullOrEmpty(model.Selected))
            {
                foreach (var keyString in model.Selected.Split(char.Parse(",")))
                {
				
				keysSelected1.Add(Guid.Parse(keyString.Split(char.Parse("|"))[0]));
                        
                    

			
                }
            }
			DataAction dataAction = DataAction.GetDataAction(Request);
			 model.Selected = dataAction.Selected;

            model.Query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(dataAction.Query, dataAction.AllSelected, dataAction.Selected, "GuidPerson");
           
            
			
			#region implementaci�n de m�todo parcial
            bool replaceResult = false;
            MyEventArgs<ContextActionModel<SDPersonModel>> actionEventArgs = null;
           
			if (model.ActionKey != "deletemany" && model.ActionKey != "deleterelmany" && model.ActionKey != "updateRel" &&  model.ActionKey != "delete-relation-fk" && model.ActionKey != "restore" )
			{
				ContextRequest context = SFSdotNet.Framework.My.Context.BuildContextRequestSafe(System.Web.HttpContext.Current);
				context.UseMode = dataAction.Usemode;

				if (model.IsBackground)
				{
					System.Threading.Tasks.Task.Run(() => 
						OnCustomActionExecutingBackground(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDPersonModel>>() { Object = new ContextActionModel<SDPersonModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } })
					);
				}
				else
				{
					OnCustomActionExecuting(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDPersonModel>>() {  Object = new ContextActionModel<SDPersonModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } });
				}
			}
            List<SDPersonModel> results = null;
	
			if (model.ActionKey == "deletemany") { 
				
				BR.SDPersonsBR.Instance.Delete(model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());

            }
	
            else if (model.ActionKey == "updateRel" || model.ActionKey == "delete-relation-fk" || model.ActionKey == "updateRel-proxyMany")
            {
               try {
                   string valueForUpdate = null;
				   string propForUpdate = null;
				   if (!string.IsNullOrEmpty(Request.Params["propertyForUpdate"])){
						propForUpdate = Request.Params["propertyForUpdate"];
				   }
				    if (string.IsNullOrEmpty(propForUpdate) && !string.IsNullOrEmpty(Request.QueryString["propertyForUpdate"]))
                   {
                       propForUpdate = Request.QueryString["propertyForUpdate"];
                   }
                    if (model.ActionKey != "delete-relation-fk")
                    {
                        valueForUpdate = Request.QueryString["valueForUpdate"];
                    }
                    BR.SDPersonsBR.Instance.UpdateAssociation(propForUpdate, valueForUpdate, model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());
					
                    if (model.ActionKey == "delete-relation-fk")
                    {
                        MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]);

                        return PartialView("ResultMessageView", message);
                    }
                    else
                    {
                        return Content("ok");
                    }
       
          
                }
                catch (Exception ex)
                {
				        SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
           
                }
            
            }
		
                if (actionEventArgs == null && !model.IsBackground)
                {
                    //if (model.ActionKey != "deletemany"  && model.ActionKey != "deleterelmany")
                    //{
                     //   throw new NotImplementedException("");
                    //}
                }
                else
                {
					if (model.IsBackground == false )
						 replaceResult = actionEventArgs.Object.Result is ActionResult /*actionEventArgs.Object.ReplaceResult*/;
                }
                #endregion
                if (!replaceResult)
                {
                    if (Request != null && Request.IsAjaxRequest())
                    {
						MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]) ;
                        if (model.IsBackground )
                            message.Message = GlobalMessages.THE_PROCESS_HAS_BEEN_STARTED;
                        
                        return PartialView("ResultMessageView", message);                    
					}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return (ActionResult)actionEventArgs.Object.Result;
                }
            }
            catch (Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null) {
                        message = ex.Data["usermessage"].ToString();
                    }
					 SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }

            }
        }
        //
        // POST: /SDPersons/Delete/5
        
			
	
    }
}
namespace SFS.ServiceDesk.Web.Mvc.Controllers
{
	using SFS.ServiceDesk.Web.Mvc.Models.SDProxyUsers;

    public partial class SDProxyUsersController : SFS.ServiceDesk.Web.Mvc.ControllerBase<Models.SDProxyUsers.SDProxyUserModel>
    {

       


	#region partial methods
        ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e = null;
        partial void OnValidating(object sender, ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e);
        partial void OnGettingExtraData(object sender, MyEventArgs<UIModel<Models.SDProxyUsers.SDProxyUserModel>> e);
        partial void OnCreating(object sender, ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e);
        partial void OnCreated(object sender, ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e);
        partial void OnEditing(object sender, ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e);
        partial void OnEdited(object sender, ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e);
        partial void OnDeleting(object sender, ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e);
        partial void OnDeleted(object sender, ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e);
    	partial void OnShowing(object sender, MyEventArgs<UIModel<Models.SDProxyUsers.SDProxyUserModel>> e);
    	partial void OnGettingByKey(object sender, ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e);
        partial void OnTaken(object sender, ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e);
       	partial void OnCreateShowing(object sender, ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e);
		partial void OnEditShowing(object sender, ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e);
		partial void OnDetailsShowing(object sender, ControllerEventArgs<Models.SDProxyUsers.SDProxyUserModel> e);
 		partial void OnActionsCreated(object sender, MyEventArgs<UIModel<Models.SDProxyUsers.SDProxyUserModel >> e);
		partial void OnCustomActionExecuting(object sender, MyEventArgs<ContextActionModel<Models.SDProxyUsers.SDProxyUserModel>> e);
		partial void OnCustomActionExecutingBackground(object sender, MyEventArgs<ContextActionModel<Models.SDProxyUsers.SDProxyUserModel>> e);
        partial void OnDownloading(object sender, MyEventArgs<ContextActionModel<Models.SDProxyUsers.SDProxyUserModel>> e);
      	partial void OnAuthorization(object sender, AuthorizationContext context);
		 partial void OnFilterShowing(object sender, MyEventArgs<UIModel<Models.SDProxyUsers.SDProxyUserModel >> e);
         partial void OnSummaryOperationShowing(object sender, MyEventArgs<UIModel<Models.SDProxyUsers.SDProxyUserModel>> e);

        partial void OnExportActionsCreated(object sender, MyEventArgs<UIModel<Models.SDProxyUsers.SDProxyUserModel>> e);


		protected override void OnVirtualFilterShowing(object sender, MyEventArgs<UIModel<SDProxyUserModel>> e)
        {
            OnFilterShowing(sender, e);
        }
		 public override void OnVirtualExportActionsCreated(object sender, MyEventArgs<UIModel<SDProxyUserModel>> e)
        {
            OnExportActionsCreated(sender, e);
        }
        public override void OnVirtualDownloading(object sender, MyEventArgs<ContextActionModel<SDProxyUserModel>> e)
        {
            OnDownloading(sender, e);
        }
        public override void OnVirtualShowing(object sender, MyEventArgs<UIModel<SDProxyUserModel>> e)
        {
            OnShowing(sender, e);
        }

	#endregion
	#region API
	 public override ActionResult ApiCreateGen(SDProxyUserModel model, ContextRequest contextRequest)
        {
            return CreateGen(model, contextRequest);
        }

              public override ActionResult ApiGetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJson(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }
        public override ActionResult ApiGetByKeyJson(string id, ContextRequest contextRequest)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
            return  GetByKeyJson(id, contextRequest, true);
        }
      
		 public override ActionResult ApiGetByCount(string filter, ContextRequest contextRequest)
        {
            return GetByCount(filter, contextRequest);
        }
         protected override ActionResult ApiDeleteGen(List<SDProxyUserModel> models, ContextRequest contextRequest)
        {
            List<SDProxyUser> objs = new List<SDProxyUser>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                BR.SDProxyUsersBR.Instance.DeleteBulk(objs, contextRequest);
                if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "success" }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("success", null, null, null);

                }
                else
                {
                    return Content("ok");

                }
            }
            catch (Exception ex)
            {
               if (this.IsRESTRequest == true)
                {
                    //return Json(new { status = "error", reason = "error", message= ex.ToString() }, JsonRequestBehavior.AllowGet);
					return ResolveApiResponse("error", "exception", ex.ToString(), null );

                }
                else
                {
                    return Json(ex.ToString(), JsonRequestBehavior.AllowGet);

                }
            }
        }
        protected override ActionResult ApiUpdateGen(List<SDProxyUserModel> models, ContextRequest contextRequest)
        {
            List<SDProxyUser> objs = new List<SDProxyUser>();
            foreach (var model in models)
            {
                objs.Add(model.GetBusinessObject());
            }
            try
            {
                foreach (var obj in objs)
                {
                    BR.SDProxyUsersBR.Instance.Update(obj, contextRequest);

                }
                return Content("ok");
            }
            catch (Exception ex)
            {
                return Json(ex.ToString(), JsonRequestBehavior.AllowGet);
            }
        }


	#endregion
#region Validation methods	
	    private void Validations(SDProxyUserModel model) { 
            #region Remote validations

            #endregion
		}

#endregion
		
 		public AuthorizationContext Authorization(AuthorizationContext context)
        {
            OnAuthorization(this,  context );
            return context ;
        }
		public List<SDProxyUserModel> GetAll() {
            			var bos = BR.SDProxyUsersBR.Instance.GetBy("",
					new SFSdotNet.Framework.My.ContextRequest()
					{
						CustomQuery = new SFSdotNet.Framework.My.CustomQuery()
						{
							OrderBy = "Email",
							SortDirection = SFSdotNet.Framework.Data.SortDirection.Ascending
						}
					});
            			List<SDProxyUserModel> results = new List<SDProxyUserModel>();
            SDProxyUserModel model = null;
            foreach (var bo in bos)
            {
                model = new SDProxyUserModel();
                model.Bind(bo);
                results.Add(model);
            }
            return results;

        }
        //
        // GET: /SDProxyUsers/
		[MyAuthorize("r", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
		public ActionResult Index()
        {
    		var uiModel = GetContextModel(UIModelContextTypes.ListForm, null);
			ViewBag.UIModel = uiModel;
			uiModel.FilterStart = (string)ViewData["startFilter"];
                    MyEventArgs<UIModel<SDProxyUserModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDProxyUserModel>>() { Object = uiModel });

			OnExportActionsCreated(this, (me != null ? me : me = new MyEventArgs<UIModel<SDProxyUserModel>>() { Object = uiModel }));

            if (me != null)
            {
                uiModel = me.Object;
            }
            if (me == null)
                me = new MyEventArgs<UIModel<SDProxyUserModel>>() { Object = uiModel };
           
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;


            //return View("ListGen");
			return ResolveView(uiModel);
        }
		[MyAuthorize("r", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
		public ActionResult ListViewGen(string idTab, string fk , string fkValue, string startFilter, ListModes  listmode  = ListModes.SimpleList, PropertyDefinition parentRelationProperty = null, object parentRelationPropertyValue = null )
        {
			ViewData["idTab"] = System.Web.HttpContext.Current.Request.QueryString["idTab"]; 
		 	ViewData["detpop"] = true; // details in popup
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"])) {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"]; 
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
            {
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["startFilter"]))
            {
                ViewData["startFilter"] = Request.QueryString["startFilter"];
            }
			
			UIModel<SDProxyUserModel> uiModel = GetContextModel(UIModelContextTypes.ListForm, null);

            MyEventArgs<UIModel<SDProxyUserModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDProxyUserModel>>() { Object = uiModel });
            if (me == null)
                me = new MyEventArgs<UIModel<SDProxyUserModel>>() { Object = uiModel };
            uiModel.Properties = GetProperties(uiModel);
            uiModel.ContextType = UIModelContextTypes.ListForm;
             uiModel.FilterStart = (string)ViewData["startFilter"];
            Showing(ref uiModel);
            ViewData["startFilter"] = uiModel.FilterStart;
			 if (listmode == ListModes.SimpleList)
                return ResolveView(uiModel);
            else
            {
                ViewData["parentRelationProperty"] = parentRelationProperty;
                ViewData["parentRelationPropertyValue"] = parentRelationPropertyValue;
                return PartialView("ListForTagSelectView");
            }
            return ResolveView(uiModel);
        }
		List<PropertyDefinition> _properties = null;

		 protected override List<PropertyDefinition> GetProperties(UIModel uiModel,  params string[] specificProperties)
        { 
            return GetProperties(uiModel, false, null, specificProperties);
        }

		protected override List<PropertyDefinition> GetProperties(UIModel uiModel, bool decripted, Guid? id, params string[] specificProperties)
            {

			bool allProperties = true;    
                if (specificProperties != null && specificProperties.Length > 0)
                {
                    allProperties = false;
                }


			List<CustomProperty> customProperties = new List<CustomProperty>();
			if (_properties == null)
                {
                List<PropertyDefinition> results = new List<PropertyDefinition>();

			string idSDProxyUser = GetRouteDataOrQueryParam("id");
			if (idSDProxyUser != null)
			{
				if (!decripted)
                {
					idSDProxyUser = SFSdotNet.Framework.Entities.Utils.GetPropertyKey(idSDProxyUser.Replace("-","/"), "GuidUser");
				}else{
					if (id != null )
						idSDProxyUser = id.Value.ToString();                

				}
			}

			bool visibleProperty = true;	
			 bool conditionalshow =false;
                if (uiModel.ContextType == UIModelContextTypes.EditForm || uiModel.ContextType == UIModelContextTypes.DisplayForm ||  uiModel.ContextType == UIModelContextTypes.GenericForm )
                    conditionalshow = true;
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("GuidUser"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "GuidUser")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 100,
																	
					CustomProperties = customProperties,

                    PropertyName = "GuidUser",

					 MaxLength = 0,
					IsRequired = true ,
					IsHidden = true,
                    SystemProperty =  SystemProperties.Identifier ,
					IsDefaultProperty = false,
                    SortBy = "GuidUser",
					
	
                    TypeName = "Guid",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDProxyUserResources.GUIDUSER*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("Email"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "Email")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 101,
																	
					CustomProperties = customProperties,

                    PropertyName = "Email",

					 MaxLength = 255,
					 Nullable = true,
					IsDefaultProperty = true,
                    SortBy = "Email",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDProxyUserResources.EMAIL*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("DisplayName"))
{				
    customProperties = new List<CustomProperty>();

        
	
	//Null
		//if (this.Request.QueryString["fk"] != "DisplayName")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 102,
																	
					CustomProperties = customProperties,

                    PropertyName = "DisplayName",

					 MaxLength = 255,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "DisplayName",
					
	
                    TypeName = "String",
                    IsNavigationProperty = false,
					IsNavigationPropertyMany = false,
                    PathName = "SFSServiceDesk/"
                    /*,PropertyDisplayName = Resources.SDProxyUserResources.DISPLAYNAME*/
                });
		//	}
	
	}
visibleProperty =allProperties;
if (visibleProperty || specificProperties.Contains("SDPersons"))
{				
    customProperties = new List<CustomProperty>();

        			customProperties.Add(new CustomProperty() { Name="Fk", Value=@"SDProxyUser" });
			//[RelationFilterable(DisableFilterableInSubfilter=true, FiltrablePropertyPathName="SDPersons.GuidPerson")]		
			customProperties.Add(new CustomProperty() { Name="FiltrablePropertyPathName", Value=@"SDPersons.GuidPerson" });
			customProperties.Add(new CustomProperty() { Name = "BusinessObjectSetName", Value = @"SDPersons" });
			

	
	//fk_SdPerson_SdProxyUser
		//if (this.Request.QueryString["fk"] != "SDPersons")
        //	{
				results.Add(new PropertyDefinition()
                {
					Order = 103,
																
					Link = VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDPersons/ListViewGen?overrideModule=" + GetOverrideApp()  + "&pal=False&es=False&pag=10&filterlinks=1&idTab=SDPersons&fk=SDProxyUser&startFilter="+ (new UrlHelper(System.Web.HttpContext.Current.Request.RequestContext)).Encode("it.SDProxyUser.GuidUser = Guid(\"" + idSDProxyUser +"\")")+ "&fkValue=" + idSDProxyUser,
					ModuleKey = "SFSServiceDesk",
					BusinessObjectKey = "SDPerson",
					
					CustomProperties = customProperties,

                    PropertyName = "SDPersons",

					 MaxLength = 0,
					 Nullable = true,
					IsDefaultProperty = false,
                    SortBy = "SDPersons.DisplayName",
					
	
                    TypeName = "SFSServiceDeskModel.SDPerson",
                    IsNavigationProperty = true,
					IsNavigationPropertyMany = true,
                    PathName = "SFSServiceDesk/SDPersons"
                    /*,PropertyDisplayName = Resources.SDProxyUserResources.SDPERSONS*/
                });
		//	}
	
	}
	
				
                    _properties = results;
                    return _properties;
                }
                else {
                    return _properties;
                }
            }

		protected override  UIModel<SDProxyUserModel> GetByForShow(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, params  object[] extraParams)
        {
			if (Request != null )
				if (!string.IsNullOrEmpty(Request.QueryString["q"]))
					filter = filter + HttpUtility.UrlDecode(Request.QueryString["q"]);
 if (contextRequest == null)
            {
                contextRequest = new ContextRequest();
                contextRequest.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;
            }
            var bos = BR.SDProxyUsersBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), contextRequest, extraParams);
			//var bos = BR.SDProxyUsersBR.Instance.GetBy(HttpUtility.UrlDecode(filter), pageSize, page, orderBy, orderDir, GetUseMode(), context, extraParams);
            SDProxyUserModel model = null;
            List<SDProxyUserModel> results = new List<SDProxyUserModel>();
            foreach (var item in bos)
            {
                model = new SDProxyUserModel();
				model.Bind(item);
				results.Add(model);
            }
            //return results;
			UIModel<SDProxyUserModel> uiModel = GetContextModel(UIModelContextTypes.Items, null);
            uiModel.Items = results;
			if (Request != null){
				if (SFSdotNet.Framework.Web.Utils.GetRouteDataOrQueryParam(Request.RequestContext, "action") == "Download")
				{
					uiModel.ContextType = UIModelContextTypes.ExportDownload;
				}
			}
            Showing(ref uiModel);
            return uiModel;
		}			
		
		//public List<SDProxyUserModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir,  params  object[] extraParams)
        //{
		//	var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, null, extraParams);
        public override List<SDProxyUserModel> GetBy(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest,  params  object[] extraParams)
        {
            var uiModel = GetByForShow(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
           
            return uiModel.Items;
		
        }
		/*
        [MyAuthorize("r", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir)
        {
			 return GetByJsonBase(filter, pageSize, page, orderBy, orderDir);
        }*/

		  [MyAuthorize("r", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
		public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir,ContextRequest contextRequest,  object[] extraParams)
        {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
			 
			 if (this.IsRESTRequest == false)
            {
                return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
            }else
            {
                try
                {
                    return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);

                }
                catch (Exception ex)
                {
                    return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);

                }
            }
        }
/*		  [MyAuthorize("r", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
       public ActionResult GetByJson(string filter, int? pageSize, int? page, string orderBy, string orderDir, ContextRequest contextRequest, object[] extraParams)
        {
            return GetByJsonBase(filter, pageSize, page, orderBy, orderDir, contextRequest, extraParams);
        }*/
		[MyAuthorize()]
		public ActionResult GetByCount(string filter, ContextRequest contextRequest) {
			if (contextRequest == null || contextRequest.Company == null || contextRequest.User == null )
            {
                contextRequest = GetContextRequest();
            }
           
			
             if (this.IsRESTRequest == true)
            {
                try
                {

                    var result = BR.SDProxyUsersBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);

                   if (Request.QueryString["v"] == "2")
                    {
						return ResolveApiResponse("success", null, null, result);

                        //return Json(new { status = "success", data = result }, JsonRequestBehavior.AllowGet);
                    }else
                    {
                        return Content(result.ToString());

                    }
                }
                catch (Exception ex)
                {
                  //  return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
				  return ResolveApiResponse("error", "exception", ex.ToString(), null);

                }
            }
            else
            {
                var result = BR.SDProxyUsersBR.Instance.GetCount(HttpUtility.UrlDecode(filter), GetUseMode(), contextRequest);
                return Content(result.ToString());
            }
		}
		

		[MyAuthorize("r", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
        public ActionResult GetByKeyJson(string id, ContextRequest contextRequest,  bool dec = false)
        {
            return Json(GetByKey(id, null, contextRequest, dec), JsonRequestBehavior.AllowGet);
        }
		public SDProxyUserModel GetByKey(string id) {
			return GetByKey(id, null,null, false);
       	}
		    public SDProxyUserModel GetByKey(string id, string includes)
        {
            return GetByKey(id, includes, false);
        }
		 public  SDProxyUserModel GetByKey(string id, string includes, ContextRequest contextRequest)
        {
            return GetByKey(id, includes, contextRequest, false);
        }
		/*
		  public ActionResult ShowField(string fieldName, string idField) {
		   string safePropertyName = fieldName;
              if (fieldName.StartsWith("Fk"))
              {
                  safePropertyName = fieldName.Substring(2, fieldName.Length - 2);
              }

             SDProxyUserModel model = new  SDProxyUserModel();

            UIModel uiModel = GetUIModel(model, new string[] { "NoField-" });
			
				uiModel.Properties = GetProperties(uiModel, safePropertyName);
		uiModel.Properties.ForEach(p=> p.ContextType = uiModel.ContextType );
            uiModel.ContextType = UIModelContextTypes.FilterFields;
            uiModel.OverrideApp = GetOverrideApp();
            uiModel.UseMode = GetUseMode();

            ViewData["uiModel"] = uiModel;
			var prop = uiModel.Properties.FirstOrDefault(p=>p.PropertyName == safePropertyName);
            //if (prop.IsNavigationProperty && prop.IsNavigationPropertyMany == false)
            //{
            //    ViewData["currentProperty"] = uiModel.Properties.FirstOrDefault(p => p.PropertyName != fieldName + "Text");
            //}else if (prop.IsNavigationProperty == false){
                ViewData["currentProperty"] = prop;
           // }
            ((PropertyDefinition)ViewData["currentProperty"]).RemoveLayout = true;
			ViewData["withContainer"] = false;


            return PartialView("GenericField", model);


        }
      */
	public SDProxyUserModel GetByKey(string id, ContextRequest contextRequest, bool dec)
        {
            return GetByKey(id, null, contextRequest, dec);
        }
        public SDProxyUserModel GetByKey(string id, string  includes, bool dec)
        {
            return GetByKey(id, includes, null, dec);
        }

        public SDProxyUserModel GetByKey(string id, string includes, ContextRequest contextRequest, bool dec) {
		             SDProxyUserModel model = null;
            ControllerEventArgs<SDProxyUserModel> e = null;
			string objectKey = id.Replace("-","/");
             OnGettingByKey(this, e=  new ControllerEventArgs<SDProxyUserModel>() { Id = objectKey  });
             bool cancel = false;
             SDProxyUserModel eItem = null;
             if (e != null)
             {
                 cancel = e.Cancel;
                 eItem = e.Item;
             }
			if (cancel == false && eItem == null)
             {
			Guid guidUser = Guid.Empty; //new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, "GuidUser"));
			if (dec)
                 {
                     guidUser = new Guid(id);
                 }
                 else
                 {
                     guidUser = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey, null));
                 }
			
            
				model = new SDProxyUserModel();
                  if (contextRequest == null)
                {
                    contextRequest = GetContextRequest();
                }
				var bo = BR.SDProxyUsersBR.Instance.GetByKey(guidUser, GetUseMode(), contextRequest,  includes);
				 if (bo != null)
                    model.Bind(bo);
                else
                    return null;
			}
             else {
                 model = eItem;
             }
			model.IsNew = false;

            return model;
        }
        // GET: /SDProxyUsers/DetailsGen/5
		[MyAuthorize("r", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
        public ActionResult DetailsGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDProxyUserResources.ENTITY_PLURAL;
			 #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDProxyUserModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
            #endregion



			 bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null) {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
			//UIModel<SDProxyUserModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, decripted), decripted, guidId);
			var item = GetByKey(id, null, null, decripted);
			if (item == null)
            {
                 RouteValueDictionary rv = new RouteValueDictionary();
                string usemode = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"usemode");
                string overrideModule = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "overrideModule");
                string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");

                if(!string.IsNullOrEmpty(usemode)){
                    rv.Add("usemode", usemode);
                }
                if(!string.IsNullOrEmpty(overrideModule)){
                    rv.Add("overrideModule", overrideModule);
                }
                if (!string.IsNullOrEmpty(area))
                {
                    rv.Add("area", area);
                }

                return RedirectToAction("Index", rv);
            }
            //
            UIModel<SDProxyUserModel> uiModel = null;
                uiModel = GetContextModel(UIModelContextTypes.DisplayForm, item, decripted, guidId);



            MyEventArgs<UIModel<SDProxyUserModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDProxyUserModel>>() { Object = uiModel });

            if (me != null) {
                uiModel = me.Object;
            }
			
            Showing(ref uiModel);
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			
            //return View("DisplayGen", uiModel.Items[0]);
			return ResolveView(uiModel, uiModel.Items[0]);

        }
		[MyAuthorize("r", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
		public ActionResult DetailsViewGen(string id)
        {

		 bool cancel = false; bool replaceResult = false;
            OnDetailsShowing(this, e = new ControllerEventArgs<SDProxyUserModel>() { Id = id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                   return e.ActionResult;
            }
           
			if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
 			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
           
        	 //var uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id));
			 
            bool decripted = false;
            Guid? guidId = null;
            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null)
            {
                if (System.Web.HttpContext.Current.Request.QueryString["dec"] == "true")
                {
                    decripted = true;
                    guidId = Guid.Parse(id);
                }
            }
            UIModel<SDProxyUserModel> uiModel = GetContextModel(UIModelContextTypes.DisplayForm, GetByKey(id, null, null, decripted), decripted, guidId);
			

            MyEventArgs<UIModel<SDProxyUserModel>> me = null;

            OnActionsCreated(this, me = new MyEventArgs<UIModel<SDProxyUserModel>>() { Object = uiModel });

            if (me != null)
            {
                uiModel = me.Object;
            }
            
            Showing(ref uiModel);
            return ResolveView(uiModel, uiModel.Items[0]);
        
        }
        //
        // GET: /SDProxyUsers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /SDProxyUsers/CreateGen
		[MyAuthorize("c", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
        public ActionResult CreateGen()
        {
			SDProxyUserModel model = new SDProxyUserModel();
            model.IsNew = true;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model);

			OnCreateShowing(this, e = new ControllerEventArgs<SDProxyUserModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }

             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                 ViewData["ispopup"] = true;
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                 ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
             if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                 ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

            Showing(ref me);

			return ResolveView(me, me.Items[0]);
        } 
			
		protected override UIModel<SDProxyUserModel> GetContextModel(UIModelContextTypes formMode, SDProxyUserModel model)
        {
            return GetContextModel(formMode, model, false, null);
        }
			
		 private UIModel<SDProxyUserModel> GetContextModel(UIModelContextTypes formMode, SDProxyUserModel model, bool decript, Guid ? id) {
            UIModel<SDProxyUserModel> me = new UIModel<SDProxyUserModel>(true, "SDProxyUsers");
			me.UseMode = GetUseMode();
			me.Controller = this;
			me.OverrideApp = GetOverrideApp();
			me.ContextType = formMode ;
			me.Id = "SDProxyUser";
			
            me.ModuleKey = "SFSServiceDesk";

			me.ModuleNamespace = "SFS.ServiceDesk";
            me.EntityKey = "SDProxyUser";
            me.EntitySetName = "SDProxyUsers";

			me.AreaAction = "SFSServiceDesk";
            me.ControllerAction = "SDProxyUsers";
            me.PropertyKeyName = "GuidUser";

            me.Properties = GetProperties(me, decript, id);
 			
			if (Request != null)
            {
                string actionName = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam( Request.RequestContext, "action");
                if(actionName != null && actionName.ToLower().Contains("create") ){
                    me.IsNew = true;
                }
            }
			 #region Buttons
			 if (Request != null ){
             if (formMode == UIModelContextTypes.DisplayForm || formMode == UIModelContextTypes.EditForm || formMode == UIModelContextTypes.ListForm)
				me.ActionButtons = GetActionButtons(formMode,model != null ?(Request.QueryString["dec"] == "true" ? model.Id : model.SafeKey)  : null, "SFSServiceDesk", "SDProxyUsers", "SDProxyUser", me.IsNew);

            //me.ActionButtons.Add(new ActionModel() { ActionKey = "return", Title = GlobalMessages.RETURN, Url = System.Web.VirtualPathUtility.ToAbsolute("~/") + "SFSServiceDesk/SDProxyUsers" });
			if (this.HttpContext != null &&  !this.HttpContext.SkipAuthorization){
				//antes this.HttpContext
				me.SetAction("u", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("u", "SDProxyUser", "SFSServiceDesk"));
				me.SetAction("c", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("c", "SDProxyUser", "SFSServiceDesk"));
				me.SetAction("d", (new SFSdotNet.Framework.Globals.Security.Permission()).IsAllowed("d", "SDProxyUser", "SFSServiceDesk"));
			
			}else{
				me.SetAction("u", true);
				me.SetAction("c", true);
				me.SetAction("d", true);

			}
            #endregion              
         
            switch (formMode)
            {
                case UIModelContextTypes.DisplayForm:
					//me.TitleForm = SDProxyUserResources.SDPROXYUSERS_DETAILS;
                    me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.MODIFY_DATA;
					 me.Properties.Where(p=>p.PropertyName  != "Id" && p.IsForeignKey == false).ToList().ForEach(p => p.IsHidden = false);

					 me.Properties.Where(p => (p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier) ).ToList().ForEach(p=> me.SetHide(p.PropertyName));

                    break;
                case UIModelContextTypes.EditForm:
				  me.Properties.Where(p=>p.SystemProperty != SystemProperties.Identifier && p.IsForeignKey == false && p.PropertyName != "Id").ToList().ForEach(p => p.IsHidden = false);

					if (model != null)
                    {
						

                        me.ActionButtons.First(p => p.ActionKey == "u").Title = GlobalMessages.SAVE_DATA;                        
                        me.ActionButtons.First(p => p.ActionKey == "c").Title = GlobalMessages.SAVE_DATA;
						if (model.IsNew ){
							//me.TitleForm = SDProxyUserResources.SDPROXYUSERS_ADD_NEW;
							me.ActionName = "CreateGen";
							me.Properties.RemoveAll(p => p.SystemProperty != null || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));
						}else{
							
							me.ActionName = "EditGen";

							//me.TitleForm = SDProxyUserResources.SDPROXYUSERS_EDIT;
							me.Properties.RemoveAll(p => p.SystemProperty != null && p.SystemProperty != SystemProperties.Identifier || (p.IsNavigationPropertyMany && p.NavigationPropertyType != NavigationPropertyTypes.Tags));	
						}
						//me.Properties.Remove(me.Properties.Find(p => p.PropertyName == "UpdatedDate"));
					
					}
                    break;
                case UIModelContextTypes.FilterFields:
                    break;
                case UIModelContextTypes.GenericForm:
                    break;
                case UIModelContextTypes.Items:
				//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "Email") != null){
						me.Properties.Find(p => p.PropertyName == "Email").IsHidden = false;
					 }
					 
                    
					

						 if (me.Properties.Find(p => p.PropertyName == "GuidUser") != null){
						me.Properties.Find(p => p.PropertyName == "GuidUser").IsHidden = false;
					 }
					 
                    
					


                  


					//}
                    break;
                case UIModelContextTypes.ListForm:
					PropertyDefinition propFinded = null;
					//if (Request.QueryString["allFields"] != "1"){
					 if (me.Properties.Find(p => p.PropertyName == "Email") != null){
						me.Properties.Find(p => p.PropertyName == "Email").IsHidden = false;
					 }
					
					me.PrincipalActionName = "GetByJson";
					//}
					//me.TitleForm = SDProxyUserResources.SDPROXYUSERS_LIST;
                    break;
                default:
                    break;
            }
            	this.SetDefaultProperties(me);
			}
			if (model != null )
            	me.Items.Add(model);
            return me;
        }
		// GET: /SDProxyUsers/CreateViewGen
		[MyAuthorize("c", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
        public ActionResult CreateViewGen()
        {
				SDProxyUserModel model = new SDProxyUserModel();
            model.IsNew = true;
			e= null;
			OnCreateShowing(this, e = new ControllerEventArgs<SDProxyUserModel>() { Item = model });
   			if (e != null)
            {
                model = e.Item;
                if (e.ActionResult != null)
                    return e.ActionResult;
            }
			
            var me = GetContextModel(UIModelContextTypes.EditForm, model);

			me.IsPartialView = true;	
            if(!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
            {
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                me.Properties.Find(p => p.PropertyName == ViewData["fk"].ToString()).IsReadOnly = true;
            }
			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];
			
      
            //me.Items.Add(model);
            Showing(ref me);
            return ResolveView(me, me.Items[0]);
        }
		protected override  void GettingExtraData(ref UIModel<SDProxyUserModel> uiModel)
        {

            MyEventArgs<UIModel<SDProxyUserModel>> me = null;
            OnGettingExtraData(this, me = new MyEventArgs<UIModel<SDProxyUserModel>>() { Object = uiModel });
            //bool maybeAnyReplaced = false; 
            if (me != null)
            {
                uiModel = me.Object;
                //maybeAnyReplaced = true;
            }
           
			bool canFill = false;
			 string query = null ;
            bool isFK = false;
			PropertyDefinition prop =null;
			var contextRequest = this.GetContextRequest();
            contextRequest.CustomParams.Add(new CustomParam() { Name="ui", Value= SDProxyUser.EntityName });

                        

        }
		private void Showing(ref UIModel<SDProxyUserModel> uiModel) {
          	
			MyEventArgs<UIModel<SDProxyUserModel>> me = new MyEventArgs<UIModel<SDProxyUserModel>>() { Object = uiModel };
			 OnVirtualLayoutSettings(this, me);


            OnShowing(this, me);

			
			if ((Request != null && Request.QueryString["allFields"] == "1") || Request == null )
			{
				me.Object.Properties.ForEach(p=> p.IsHidden = false);
            }
            if (me != null)
            {
                uiModel = me.Object;
            }
          


			 if (uiModel.ContextType == UIModelContextTypes.EditForm)
			    GettingExtraData(ref uiModel);
            ViewData["UIModel"] = uiModel;

        }
        //
        // POST: /SDProxyUsers/Create
		[MyAuthorize("c", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
        [HttpPost]
		[ValidateInput(false)] 
        public ActionResult CreateGen(SDProxyUserModel  model,  ContextRequest contextRequest)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
		 	e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDProxyUserModel>() { Item = model });
           
		  	if (!ModelState.IsValid) {
				model.IsNew = true;
				var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
                 if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                        ViewData["ispopup"] = true;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
                    return ResolveView(me, model);
            }
            try
            {
				if (model.GuidUser == null || model.GuidUser.ToString().Contains("000000000"))
				model.GuidUser = Guid.NewGuid();
	
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnCreating(this, e = new ControllerEventArgs<SDProxyUserModel>() { Item = model });
                if (e != null) {
                   if (e.Cancel && e.RedirectValues.Count > 0){
                        RouteValueDictionary rv = new RouteValueDictionary();
                        if (e.RedirectValues["area"] != null ){
                            rv.Add("area", e.RedirectValues["area"].ToString());
                        }
                        foreach (var item in e.RedirectValues.Where(p=>p.Key != "area" && p.Key != "controller" &&  p.Key != "action" ))
	                    {
		                    rv.Add(item.Key, item.Value);
	                    }

                        //if (e.RedirectValues["action"] != null && e.RedirectValues["controller"] != null && e.RedirectValues["area"] != null )
                        return RedirectToAction(e.RedirectValues["action"].ToString(), e.RedirectValues["controller"].ToString(), rv );


                        
                    }else if (e.Cancel && e.ActionResult != null )
                        return e.ActionResult;  
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				if (contextRequest == null || contextRequest.Company == null){
					contextRequest = GetContextRequest();
					
				}
                if (!cancel)
                	model.Bind(SDProxyUsersBR.Instance.Create(model.GetBusinessObject(), contextRequest ));
				OnCreated(this, e = new ControllerEventArgs<SDProxyUserModel>() { Item = model });
                 if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                        return ResolveApiResponse("success", null, null, null);

                    }
                }
				 
				 if (e != null )
					if (e.ActionResult != null)
                    	replaceResult = true;		
				if (!replaceResult)
                {
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))
                    {
                        ViewData["__continue"] = true;
                    }
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"]) &&  string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
                        popupextra.Add("id", model.SafeKey);
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                       {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                            popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext,"area"));
                            popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                            popupextra.Add("action", actionDetails);
                       if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
                    {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"]))

                        {
                            var popupextra = GetRouteData();
                            popupextra.Add("id", model.SafeKey);
                            return RedirectToAction("EditViewGen", popupextra);
                        }
                        else
                        {
                            return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.ADD_DONE));
                        }
                    }        			if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                        return Redirect(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]);
                    else{

							RouteValueDictionary popupextra = null; 
							if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"])){
                            popupextra = GetRouteData();
							 string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
                            if (!string.IsNullOrEmpty(area))
                                popupextra.Add("area", area);
                            
                            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue"])) {
								popupextra.Add("id", model.SafeKey);
                                return RedirectToAction("EditGen", popupextra);

                            }else{
								
                            return RedirectToAction("Index", popupextra);
							}
							}else{
								return Content("ok");
							}
                        }
						 }
                else {
                    return e.ActionResult;
                    }
				}
            catch(Exception ex)
            {
					  SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        throw ex;
                    }
                    else
                    {
                       // return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
					   return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
                SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                model.IsNew = true;
                var me = GetContextModel(UIModelContextTypes.EditForm, model, true, model.GuidUser);
                Showing(ref me);
                if (isPopUp)
                {
                    
                        ViewData["ispopup"] = isPopUp;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                        ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                        ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

                    return ResolveView(me, model);
                }
                else
					if (Request != null)
						return ResolveView(me, model);
					else
						return Content("ok");
            }
        }        
        //
        // GET: /SDProxyUsers/Edit/5 
        public ActionResult Edit(int id)
        {
            return View();
        }
			
		
		[MyAuthorize("u", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
		[MvcSiteMapNode(Area="SFSServiceDesk", Title="sss", Clickable=false, ParentKey = "SFSServiceDesk_SDProxyUser_List")]
		public ActionResult EditGen(string id)
        {
			//if (System.Web.SiteMap.CurrentNode != null)
			//	System.Web.SiteMap.CurrentNode.Title = SDProxyUserResources.ENTITY_SINGLE;		 	
  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDProxyUserModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
            SDProxyUserModel model = null;
            // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
			bool dec = false;
            Guid ? idGuidDecripted = null ;
            if (Request != null && Request.QueryString["dec"] == "true")
            {
                dec = true;
                idGuidDecripted = Guid.Parse(id);
            }

            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
			 var me = GetContextModel(UIModelContextTypes.EditForm, model,dec,idGuidDecripted);
            Showing(ref me);


            if (!replaceResult)
            {
                 //return View("EditGen", me.Items[0]);
				 return ResolveView(me, me.Items[0]);
            }
            else {
                return e.ActionResult;
            }
        }
			[MyAuthorize("u", "SDProxyUser","SFSServiceDesk", typeof(SDProxyUsersController))]
		public ActionResult EditViewGen(string id)
        {
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
                ViewData["ispopup"] = true;
			  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
                ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
                ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

					  // habilitando m�todo parcial
            #region implementaci�n de m�todo parcial

            bool cancel = false; bool replaceResult = false;
            OnEditShowing(this, e = new ControllerEventArgs<SDProxyUserModel>() { Id= id });
            if (e != null)
            {
                if (e.Cancel && e.ActionResult != null)
                    return e.ActionResult;
                else if (e.Cancel == true)
                    cancel = true;
                else if (e.ActionResult != null)
                    replaceResult = true;
            }
            #endregion
			
            SDProxyUserModel model = null;
			 bool dec = false;
            Guid? guidId = null ;

            if (System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.Request != null && System.Web.HttpContext.Current.Request.QueryString["dec"] == "true") {
                dec = true;
                guidId = Guid.Parse(id);
            }
            // si fue implementado el método parcial y no se ha decidido suspender la acción
            if (!cancel)
                model = GetByKey(id, null, null, dec);
            else
                model = e.Item;
            var me = GetContextModel(UIModelContextTypes.EditForm, model, dec, guidId);
            Showing(ref me);

            return ResolveView(me, model);
        }
		[MyAuthorize("u", "SDProxyUser",  "SFSServiceDesk", typeof(SDProxyUsersController))]
		[HttpPost]
		[ValidateInput(false)] 
		        public ActionResult EditGen(SDProxyUserModel model)
        {
			bool isPopUp = false;
            if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
            {
                isPopUp = true;
            }
			e = null;
			this.Validations(model);

            OnValidating(this, e = new ControllerEventArgs<SDProxyUserModel>() { Item = model });
           
            if (!ModelState.IsValid)
            {
			   	var me = GetContextModel(UIModelContextTypes.EditForm, model);
                Showing(ref me);
			
				if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"])){
                	ViewData["ispopup"] = true;
					return ResolveView(me, model);
				}
				else
					return ResolveView(me, model);
            }
            try
            {
			
				// habilitando m�todo parcial
                #region implementaci�n de m�todo parcial
               
                bool cancel = false; bool replaceResult = false;
                OnEditing(this, e = new ControllerEventArgs<SDProxyUserModel>() { Item = model });
                if (e != null) {
                    if (e.Cancel && e.ActionResult != null)
                        return e.ActionResult;
                    else if (e.Cancel == true)
                        cancel = true;
                    else if (e.ActionResult != null)
                        replaceResult = true;
                }
                #endregion
                // si fue implementado el m�todo parcial y no se ha decidido suspender la acci�n
				ContextRequest context = new ContextRequest();
                context.CurrentContext = SFSdotNet.Framework.My.Context.CurrentContext;

                SDProxyUser resultObj = null;
			    if (!cancel)
                	resultObj = SDProxyUsersBR.Instance.Update(model.GetBusinessObject(), GetContextRequest());
				
				OnEdited(this, e = new ControllerEventArgs<SDProxyUserModel>() { Item =   new SDProxyUserModel(resultObj) });
				if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content("ok");
                    }
                    else
                    {
                         return ResolveApiResponse("success", null, null, null);
                    }
                }
				
				if (e != null && e.ActionResult != null) replaceResult = true; 

                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Content("ok");
                }
                else
                {
				if (!replaceResult)
                {
					if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["__continue_details"])  && string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                    {
                        var popupextra = GetRouteData();
						 if (Request != null && Request.QueryString["dec"] == "true")
                        {
                            popupextra.Add("id", model.Id);
                        }
                        else
                        {
							popupextra.Add("id", model.SafeKey);

							
                        }
                        string actionDetails = "DetailsGen";
                        if (this.IsPopup())
                        {
                            popupextra.Add("saved", "true");
                            actionDetails = "DetailsViewGen";
                        }
                        popupextra.Add("area", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area"));
                        popupextra.Add("controller", SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "controller"));
                        popupextra.Add("action", actionDetails);
                        if (popupextra.ContainsKey("usemode"))
                        {

                            return RedirectToRoute("area_usemode", popupextra);
                        }
                        else
                        {
                            return RedirectToAction(actionDetails, popupextra);
                        }
                    }
					if (isPopUp)
						return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.UPDATE_DONE));
        			    string returnUrl = null;
                    if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]) || !string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"])) {
                        if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.Form["ReturnAfter"];
                        else if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"]))
                            returnUrl = System.Web.HttpContext.Current.Request.QueryString["ReturnAfter"];
                    }
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else{
		RouteValueDictionary popupextra = null; 
						 if (Request != null && string.IsNullOrEmpty(Request.QueryString["rok"]))
                            {
							
							popupextra = GetRouteData();
							string area = SFSdotNet.Framework.Web.Mvc.Utils.GetRouteDataOrQueryParam(this.Request.RequestContext, "area");
							if (!string.IsNullOrEmpty(area))
								popupextra.Add("area", area);

							return RedirectToAction("Index", popupextra);
						}else{
							return Content("ok");
						}
						}
				 }
                else {
                    return e.ActionResult;
				}
                }		
            }
          catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                if (this.IsRESTRequest == true)
                {
                    if (Request != null && !string.IsNullOrEmpty(Request.QueryString["rok"]))
                    {
                        return Content(ex.ToString());
                    }
                    else
                    {
                        //return Json(new { status = "error", reason = "exception", message = ex.ToString() }, JsonRequestBehavior.AllowGet);
						 return ResolveApiResponse("error", "exception", ex.ToString(), null);

                    }
                }
			    if (isPopUp)
                {
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(ex.Message));
                    
                }
                else
                {
                    SFSdotNet.Framework.My.Context.CurrentContext.AddMessage(ex.Message, SFSdotNet.Framework.My.MessageResultTypes.Error);
                    
                if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["autosave"]))
                {
                    return Json("error", JsonRequestBehavior.AllowGet);
                }
                else {
						  if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["popup"]))
							ViewData["ispopup"] = true;
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fk"]))
							ViewData["fk"] = System.Web.HttpContext.Current.Request.QueryString["fk"];
						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.QueryString["fkValue"]))
							ViewData["fkValue"] = System.Web.HttpContext.Current.Request.QueryString["fkValue"];

						var me = GetContextModel(UIModelContextTypes.EditForm, model);
						Showing(ref me);

						if (!string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Form["popup"]))
						{
							ViewData["ispopup"] = true;
							return ResolveView(me, model);
						}
						else
							return ResolveView(me, model);

						
					}
				}
            }
        }
        //
        // POST: /SDProxyUsers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //  Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SDProxyUsers/Delete/5
        
		[MyAuthorize("d", "SDProxyUser", "SFSServiceDesk", typeof(SDProxyUsersController))]
		[HttpDelete]
        public ActionResult DeleteGen(string objectKey, string extraParams)
        {
            try
            {
					
			
				Guid guidUser = new Guid(SFSdotNet.Framework.Entities.Utils.GetPropertyKey(objectKey.Replace("-", "/"), "GuidUser")); 
                BO.SDProxyUser entity = new BO.SDProxyUser() { GuidUser = guidUser };

                BR.SDProxyUsersBR.Instance.Delete(entity, GetContextRequest());               
                return PartialView("ResultMessageView", (new MessageModel()).GetDone(GlobalMessages.DELETE_DONE));

            }
            catch(Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null)
                    {
                        message = ex.Data["usermessage"].ToString();
                    }

                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }
            }
        }
		/*[MyAuthorize()]
		public FileMediaResult Download(string query, bool? allSelected = false,  string selected = null , string orderBy = null , string direction = null , string format = null , string actionKey=null )
        {
			
            List<Guid> keysSelected1 = new List<Guid>();
            if (!string.IsNullOrEmpty(selected)) {
                foreach (var keyString in selected.Split(char.Parse("|")))
                {
				
                    keysSelected1.Add(Guid.Parse(keyString));
                }
            }
				
            query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(query, allSelected.Value, selected, "GuidUser");
            MyEventArgs<ContextActionModel<SDProxyUserModel>> eArgs = null;
            List<SDProxyUserModel> results = GetBy(query, null, null, orderBy, direction, GetContextRequest(), keysSelected1);
            OnDownloading(this, eArgs = new MyEventArgs<ContextActionModel<SDProxyUserModel>>() { Object = new ContextActionModel<SDProxyUserModel>() { Query = query, SelectedItems = results, Selected=selected, SelectAll = allSelected.Value, Direction = direction , OrderBy = orderBy, ActionKey=actionKey  } });

            if (eArgs != null)
            {
                if (eArgs.Object.Result != null)
                    return (FileMediaResult)eArgs.Object.Result;
            }
            

            return (new FeaturesController()).ExportDownload(typeof(SDProxyUserModel), results, format, this.GetUIPluralText("SFSServiceDesk", "SDProxyUser"));
            
        }
			*/
		
		[HttpPost]
        public ActionResult CustomActionExecute(ContextActionModel model) {
		 try
            {
			//List<Guid> keysSelected1 = new List<Guid>();
			List<object> keysSelected1 = new List<object>();
            if (!string.IsNullOrEmpty(model.Selected))
            {
                foreach (var keyString in model.Selected.Split(char.Parse(",")))
                {
				
				keysSelected1.Add(Guid.Parse(keyString.Split(char.Parse("|"))[0]));
                        
                    

			
                }
            }
			DataAction dataAction = DataAction.GetDataAction(Request);
			 model.Selected = dataAction.Selected;

            model.Query = SFSdotNet.Framework.Web.Mvc.Lists.GetQuery(dataAction.Query, dataAction.AllSelected, dataAction.Selected, "GuidUser");
           
            
			
			#region implementaci�n de m�todo parcial
            bool replaceResult = false;
            MyEventArgs<ContextActionModel<SDProxyUserModel>> actionEventArgs = null;
           
			if (model.ActionKey != "deletemany" && model.ActionKey != "deleterelmany" && model.ActionKey != "updateRel" &&  model.ActionKey != "delete-relation-fk" && model.ActionKey != "restore" )
			{
				ContextRequest context = SFSdotNet.Framework.My.Context.BuildContextRequestSafe(System.Web.HttpContext.Current);
				context.UseMode = dataAction.Usemode;

				if (model.IsBackground)
				{
					System.Threading.Tasks.Task.Run(() => 
						OnCustomActionExecutingBackground(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDProxyUserModel>>() { Object = new ContextActionModel<SDProxyUserModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } })
					);
				}
				else
				{
					OnCustomActionExecuting(this, actionEventArgs = new MyEventArgs<ContextActionModel<SDProxyUserModel>>() {  Object = new ContextActionModel<SDProxyUserModel>() { DataAction = dataAction, ContextRequest = context, AllSelected = model.AllSelected, SelectAll = model.AllSelected, IsBackground = model.IsBackground, ActionKey = model.ActionKey, Direction = model.Direction, OrderBy = model.OrderBy, /*SelectedItems = results,*/ SelectedKeys = dataAction.SelectedGuids.Cast<Object>().ToList(), Query = model.Query } });
				}
			}
            List<SDProxyUserModel> results = null;
	
			if (model.ActionKey == "deletemany") { 
				
				BR.SDProxyUsersBR.Instance.Delete(model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());

            }
	
            else if (model.ActionKey == "updateRel" || model.ActionKey == "delete-relation-fk" || model.ActionKey == "updateRel-proxyMany")
            {
               try {
                   string valueForUpdate = null;
				   string propForUpdate = null;
				   if (!string.IsNullOrEmpty(Request.Params["propertyForUpdate"])){
						propForUpdate = Request.Params["propertyForUpdate"];
				   }
				    if (string.IsNullOrEmpty(propForUpdate) && !string.IsNullOrEmpty(Request.QueryString["propertyForUpdate"]))
                   {
                       propForUpdate = Request.QueryString["propertyForUpdate"];
                   }
                    if (model.ActionKey != "delete-relation-fk")
                    {
                        valueForUpdate = Request.QueryString["valueForUpdate"];
                    }
                    BR.SDProxyUsersBR.Instance.UpdateAssociation(propForUpdate, valueForUpdate, model.Query, dataAction.SelectedGuids.ToArray(), GetContextRequest());
					
                    if (model.ActionKey == "delete-relation-fk")
                    {
                        MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]);

                        return PartialView("ResultMessageView", message);
                    }
                    else
                    {
                        return Content("ok");
                    }
       
          
                }
                catch (Exception ex)
                {
				        SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
           
                }
            
            }
		
                if (actionEventArgs == null && !model.IsBackground)
                {
                    //if (model.ActionKey != "deletemany"  && model.ActionKey != "deleterelmany")
                    //{
                     //   throw new NotImplementedException("");
                    //}
                }
                else
                {
					if (model.IsBackground == false )
						 replaceResult = actionEventArgs.Object.Result is ActionResult /*actionEventArgs.Object.ReplaceResult*/;
                }
                #endregion
                if (!replaceResult)
                {
                    if (Request != null && Request.IsAjaxRequest())
                    {
						MessageModel message = (new MessageModel()).GetDone(GlobalMessages.DONE, Request.Form["lastActionName"]) ;
                        if (model.IsBackground )
                            message.Message = GlobalMessages.THE_PROCESS_HAS_BEEN_STARTED;
                        
                        return PartialView("ResultMessageView", message);                    
					}
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    return (ActionResult)actionEventArgs.Object.Result;
                }
            }
            catch (Exception ex)
            {
				SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
			    
                if (Request != null && Request.IsAjaxRequest())
                {
                    string message = GlobalMessages.ERROR_TRY_LATER;
                    if (ex.Data["usermessage"] != null) {
                        message = ex.Data["usermessage"].ToString();
                    }
					 SFSdotNet.Framework.My.EventLog.Exception(ex, GetContextRequest());
                    return PartialView("ResultMessageView", (new MessageModel()).GetException(message));
                }
                else
                {
                    return View();
                }

            }
        }
        //
        // POST: /SDProxyUsers/Delete/5
        
			
	
    }
}