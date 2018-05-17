using System;
using System.Data;
using System.Web;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Text;
using System.Web.UI.WebControls;

namespace DBS.SitesInfosUteis.Layouts.DBS.SitesInfosUteis
{
    public partial class DBS : LayoutsPageBase
    {
        SPWeb web = SPContext.Current.Site.RootWeb;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack == false)
                {
                    MontaCboBusca();

                    MontaGridConteudo("");
                }
            }
            catch (Exception ex)
            {
                lblErro.Text = ex.ToString();
            }
        }

        public void MontaGridConteudo(string varParamBusca)
        {
            string varLinha = "";

            //Acessando a lista
            SPList lstLista = web.Lists["SitesInfo"];

            //Construindo a Query CAML
            SPQuery oQuery = new SPQuery();

            if (varParamBusca.ToString() == "" || varParamBusca.ToString() == "Todas")
            {
                oQuery.Query =  "<OrderBy>" +
                                "   <FieldRef Name='Title' Ascending='True' />" +
                                "</OrderBy>";
            }
            else 
            {
                oQuery.Query =  "<Where>" +
                                "   <Eq>" +
                                "        <FieldRef Name='_x00c1_rea_x0020_de_x0020_Intere' /><Value Type='Choice'>" + varParamBusca.ToString() + "</Value>" +
                                "    </Eq>" +
                                "</Where>" +
                                "<OrderBy>" +
                                "   <FieldRef Name='Title' Ascending='True' />" +
                                "</OrderBy>";
            }


            //Criando uma coleção de itens, utilizando a Query CAML
            SPListItemCollection collListItems = lstLista.GetItems(oQuery);

            //Recupera o item
            foreach (SPListItem oListItem in collListItems)
            {
                StringBuilder sbLinha = new StringBuilder();

                ////Monta linha da grid com os resultados
                sbLinha.Append("<tr class='grid_conteudo'>");
                sbLinha.Append("<td>&nbsp;" + AjustaCampo(oListItem["Title"].ToString()) + "</td>");

                if (oListItem["Telefone"] != null)
                {
                    sbLinha.Append("<td align='center'>" + AjustaCampo(oListItem["Telefone"].ToString()) + "</td>");
                }
                else
                {
                    sbLinha.Append("<td></td>");
                }
                sbLinha.Append("<td>&nbsp;<a href='" + AjustaCampo(oListItem["Conteudo"].ToString()) + "' target='blank'>" + AjustaCampo(oListItem["Conteudo"].ToString()) + "</a></td>");
                sbLinha.Append("</tr>");

                varLinha += sbLinha.ToString();
            }
            
            ltrConteudo.Text = varLinha.ToString();
        }

        public void MontaCboBusca()
        {
            //Acessando a lista
            SPList lstLista = web.Lists["SitesInfo"];

            //Construindo a Query CAML
            SPQuery oQuery = new SPQuery();

            oQuery.ViewFields = "<FieldRef Name='_x00c1_rea_x0020_de_x0020_Intere'/>";
            oQuery.Query =  "<OrderBy>" +
                            "   <FieldRef Name='_x00c1_rea_x0020_de_x0020_Intere' Ascending='True' />" +
                            "</OrderBy>";

            //Criando uma coleção de itens, utilizando a Query CAML
            //Criadas datatables e dataview para utilizar o distinct nos resultados, a Query CAML por si só não possui esse comando.
            DataTable dtItemsColl = lstLista.GetItems(oQuery).GetDataTable();
            DataView dvView = new DataView(dtItemsColl);
            DataTable dtItemsList = dvView.ToTable(true, "_x00c1_rea_x0020_de_x0020_Intere"); //define que os resultados são distinct

            //Limpa combo antes de popular os resultados
            cboBusca.Items.Clear();
            
            cboBusca.Items.Add("Todas");

            foreach (DataRow rowItems in dtItemsList.Rows)
            {
                ////Monta combo com os resultados
                ListItem ItemCbo = new ListItem();
                ItemCbo.Value = AjustaCampo(rowItems["_x00c1_rea_x0020_de_x0020_Intere"].ToString());
                ItemCbo.Text = AjustaCampo(rowItems["_x00c1_rea_x0020_de_x0020_Intere"].ToString());

                cboBusca.Items.Add(ItemCbo);
            }
        }

        public string AjustaCampo(string vCampo)
        {
            if (vCampo.IndexOf(";#") > 0)
            {
                vCampo = vCampo.Substring(vCampo.IndexOf("#") + 1);
            }
            return vCampo;
        }

        protected void btnBusca_OnClick(object sender, EventArgs e)
        {
            MontaGridConteudo(cboBusca.SelectedValue.ToString());
        }

    }
}
