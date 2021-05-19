﻿using Aplicativo.View.Helpers;
using Aplicativo.View.Layout.Component.ListView;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Aplicativo.View.Layout.Component.ViewPage.Controls
{
    public class ViewPageBtnExcluirComponent : ComponentBase
    {

        //[CascadingParameter] public ListItemViewLayout ListItemViewLayout { get; set; }
        //[CascadingParameter] public EditItemViewLayout EditItemViewLayout { get; set; }


        [Parameter] public string Text { get; set; } = "Excluir";

        [Parameter] public string Width { get; set; } = "110px";

        [Parameter] public bool Visible { get; set; } = true;

        [Parameter] public EventCallback OnClick { get; set; }

        protected async Task BtnExcluir_Click()
        {
            try
            {

                var confirm = await App.JSRuntime.InvokeAsync<bool>("confirm", "Tem certeza que deseja excluir ?");

                if (!confirm) return;

                await OnClick.InvokeAsync(null);


                //if (ListItemViewLayout?.ListViewBtnPesquisa != null)
                //{
                //    await ListItemViewLayout.ListViewBtnPesquisa.BtnPesquisar_Click();
                //}

                //if (ListItemViewLayout?.GridViewItem?.GridViewItem != null)
                //{
                //    ListItemViewLayout.GridViewItem.GridViewItem.Refresh();
                //}


            }
            catch (Exception ex)
            {
                await HelpErro.Show(new Error(ex));
            }
        }

    }
}