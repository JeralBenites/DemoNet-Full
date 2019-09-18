using SolIntermedio.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SolIntermedio.ClienteMVC.Models
{
    public static class UtilHelper
    {
        /// <summary>
        /// Helper personalizado que genera un HREF
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="url">Url a linkear</param>
        /// <param name="estilo">CSS a presentar</param>
        /// <param name="texto">Contenido</param>
        /// <returns></returns>
        public static MvcHtmlString CustomHRef(
            this HtmlHelper htmlHelper, string url, 
            string estilo, string texto) {

            //<a href="" class="btn btn-primary">Texto</a>
            var aBuilder = new TagBuilder("a");
            aBuilder.AddCssClass(estilo);
            aBuilder.Attributes.Add("href", url);
            aBuilder.InnerHtml = texto;

            return new MvcHtmlString(aBuilder.ToString());
        }

        public static MvcHtmlString CustomMenu(
            this HtmlHelper htmlHelper, List<Opcion> listaOpcion) {
           
            var ulPrincipal = new TagBuilder("ul");
            ulPrincipal.AddCssClass("sidebar-menu");
            ulPrincipal.Attributes.Add("data-widget", "tree");

            #region headerPrincipal
            var liHeaderPrincipal = new TagBuilder("li");
            liHeaderPrincipal.AddCssClass("header");
            liHeaderPrincipal.InnerHtml = "MENU PRINCIPAL";

            ulPrincipal.InnerHtml += liHeaderPrincipal.ToString();
            #endregion
           
            foreach (Opcion itemCero in 
                (listaOpcion.Where(t => t.IdOpcionRef == 0).ToList()))
            {
                var liCero = new TagBuilder("li");
                liCero.AddCssClass("treeview");
                #region aCero
                var aCero = new TagBuilder("a");
                aCero.Attributes.Add("href", "#");

                #region iCero
                var iCero = new TagBuilder("i");
                iCero.AddCssClass(itemCero.Titulo);
                aCero.InnerHtml += iCero.ToString();

                var spanTextoCero = new TagBuilder("span");
                spanTextoCero.InnerHtml = itemCero.Nombre;
                aCero.InnerHtml += spanTextoCero.ToString();


                #endregion

                #region spanCero
                var spanCero = new TagBuilder("span");
                spanCero.AddCssClass("pull-right-container");

                var iSpanCero = new TagBuilder("i");
                iSpanCero.AddCssClass("fa fa-angle-left pull-right");

                spanCero.InnerHtml += iSpanCero.ToString();

                aCero.InnerHtml += spanCero.ToString();

                #endregion
                liCero.InnerHtml += aCero.ToString();
                #endregion
                UrlHelper urlHelper = 
                    new UrlHelper(htmlHelper.ViewContext.RequestContext);
                LlenarSubMenu(liCero, itemCero, listaOpcion, urlHelper);

                ulPrincipal.InnerHtml += liCero.ToString();
            }

            return new MvcHtmlString(ulPrincipal.ToString());
        }


        private static void LlenarSubMenu(TagBuilder itemLista, 
            Opcion itemOpcion, List<Opcion> listaOpcion, UrlHelper urlHelper)
        {

            var ulSubMenu = new TagBuilder("ul");
            ulSubMenu.AddCssClass("treeview-menu");
            //ulSubMenu.Attributes.Add("style", "display: block;");

            foreach (Opcion itemSubMenu in (from x in listaOpcion
                                            where x.IdOpcionRef == itemOpcion.IdOpcion
                                            //orderby x.eNroOrden
                                            select x).ToList())
            {
                bool tieneHijos = listaOpcion.Count(t => t.IdOpcionRef == itemSubMenu.IdOpcion) > 0;
                var liSubMenu = new TagBuilder("li");

                if (!tieneHijos)
                {
                    var aSubMenuSH = new TagBuilder("a");
                    aSubMenuSH.Attributes.Add("href", itemSubMenu.Url);

                    var iSubMenuSH = new TagBuilder("i");
                    iSubMenuSH.AddCssClass(itemSubMenu.Titulo);
                    aSubMenuSH.InnerHtml += iSubMenuSH.ToString();

                    aSubMenuSH.InnerHtml += itemSubMenu.Nombre;
                    liSubMenu.InnerHtml += aSubMenuSH.ToString();
                }
                else
                {
                    liSubMenu.AddCssClass("treeview");

                    var aSubMenuSH = new TagBuilder("a");
                    aSubMenuSH.Attributes.Add("href", itemSubMenu.Url);

                    var iSubMenuSH = new TagBuilder("i");
                    iSubMenuSH.AddCssClass(itemSubMenu.Titulo);
                    aSubMenuSH.InnerHtml += iSubMenuSH.ToString();

                    aSubMenuSH.InnerHtml += itemSubMenu.Nombre;

                    var spanSubmenuSH = new TagBuilder("span");
                    spanSubmenuSH.AddCssClass("pull-right-container");

                    var ispanSubMenuSH = new TagBuilder("i");
                    ispanSubMenuSH.AddCssClass("fa fa-angle-left pull-right");
                    spanSubmenuSH.InnerHtml += ispanSubMenuSH.ToString();

                    aSubMenuSH.InnerHtml += spanSubmenuSH.ToString();

                    liSubMenu.InnerHtml += aSubMenuSH.ToString();

                    LlenarSubMenu(liSubMenu, itemSubMenu, listaOpcion, urlHelper);
                }

                ulSubMenu.InnerHtml += liSubMenu.ToString();
            }
            itemLista.InnerHtml += ulSubMenu.ToString();
        }

    }

    
}