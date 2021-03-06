﻿using Poetry.UI.PageEditingSupport;
using Poetry.UI.RoutingSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;

namespace Poetry.UI.AspNet.PageEditingSupport
{
    public static class HtmlHelperExtensions
    {
        static IModeProvider ModeProvider { get; set; }
        static IPropertyExpressionMetaDataProvider PropertyExpressionMetaDataProvider { get; set; }
        static IObjectIdentifier ObjectIdentifier { get; set; }

        public static MvcHtmlString PropertyFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression)
        {
            if(ModeProvider == null)
            {
                ModeProvider = DependencyResolver.Current.GetService<IModeProvider>();
            }

            var result = html.DisplayFor(expression);

            if(ModeProvider.GetIsPageEditing(html.ViewContext.HttpContext) != true)
            {
                return result;
            }

            if (ObjectIdentifier == null)
            {
                ObjectIdentifier = DependencyResolver.Current.GetService<IObjectIdentifier>();
            }

            if (PropertyExpressionMetaDataProvider == null)
            {
                PropertyExpressionMetaDataProvider = DependencyResolver.Current.GetService<IPropertyExpressionMetaDataProvider>();
            }

            var metaData = PropertyExpressionMetaDataProvider.GetFor(expression);

            return MvcHtmlString.Create($"<span class=\"poetry-page-editing-property\" property-name=\"{metaData.PropertyName}\" object-id=\"{ObjectIdentifier.GetId(metaData.OwnerObject ?? html.ViewData.Model)}\">{result}</span>");
        }

        static IBasePathProvider BasePathProvider { get; set; }

        public static MvcHtmlString AddPageEditing(this HtmlHelper html)
        {
            if (ModeProvider == null)
            {
                ModeProvider = DependencyResolver.Current.GetService<IModeProvider>();
            }

            if (ModeProvider.GetIsPageEditing(html.ViewContext.HttpContext) != true)
            {
                return null;
            }

            if(BasePathProvider == null)
            {
                BasePathProvider = DependencyResolver.Current.GetService<IBasePathProvider>();
            }

            return MvcHtmlString.Create($"<script src=\"/{BasePathProvider.BasePath}/PageEditing/Scripts/target-page-editor.js\" async></script>");
        }
    }
}
