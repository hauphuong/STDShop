using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using STDShop.Model.Models;
using STDShop.Service;
using STDShop.Web.Infrastructure.Core;
using STDShop.Web.Models;
using STDShop.Web.Infrastructure.Extensions;
using System.Web.Script.Serialization;

namespace STDShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    [Authorize]
    public class PostCategoryController : ApiControllerBase
    {
        #region Initialize
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService)
            : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        #endregion

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _postCategoryService.GetAll();

                var responseData = Mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _postCategoryService.GetById(id);

                var responseData = Mapper.Map<PostCategory, PostCategoryViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _postCategoryService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<PostCategory>, IEnumerable<PostCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<PostCategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newPostCategory = new PostCategory();
                    newPostCategory.UpdatePostCategory(postCategoryVm);
                    newPostCategory.CreatedDate = DateTime.Now;
                    _postCategoryService.Add(newPostCategory);
                    _postCategoryService.Save();

                    var responseData = Mapper.Map<PostCategory, PostCategoryViewModel>(newPostCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbpostCategory = _postCategoryService.GetById(postCategoryVm.ID);

                    dbpostCategory.UpdatePostCategory(postCategoryVm);
                    dbpostCategory.UpdatedDate = DateTime.Now;

                    _postCategoryService.Update(dbpostCategory);
                    _postCategoryService.Save();

                    var responseData = Mapper.Map<PostCategory, PostCategoryViewModel>(dbpostCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldpostCategory = _postCategoryService.Delete(id);
                    _postCategoryService.Save();

                    var responseData = Mapper.Map<PostCategory, PostCategoryViewModel>(oldpostCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedpostCategories)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listpostCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedpostCategories);
                    foreach (var item in listpostCategory)
                    {
                        _postCategoryService.Delete(item);
                    }

                    _postCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listpostCategory.Count);
                }

                return response;
            });
        }
    }
}