﻿using Aplicativo.Utils.Helpers;
using Aplicativo.Utils.Models;
using Aplicativo.View.Helpers;
using Aplicativo.View.Layout.Component.ListView;
using Microsoft.AspNetCore.Components;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicativo.View.Pages.Cadastros.Produtos
{
    public partial class IndexPage : ComponentBase
    {

        protected ListItemViewLayout<Produto> ListView { get; set; }
        protected ViewProduto View { get; set; }

        protected async Task Page_Load()
        {
            await BtnPesquisar_Click();
        }

        protected async Task BtnPesquisar_Click()
        {

            var Query = new HelpQuery<Produto>();

            Query.AddWhere("Ativo == @0", true);

            ListView.Items = await Query.ToList();

        }

        protected async Task BtnItemView_Click(object args)
        {
            await View.EditItemViewLayout.Show(args);
        }

        protected async Task BtnExcluir_Click(object args)
        {
            await View.Excluir(((IEnumerable)args).Cast<Produto>().Select(c => (int)c.ProdutoID).ToList());
        }

    }
}