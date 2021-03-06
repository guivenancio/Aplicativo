﻿using Aplicativo.View.Controls;
using Aplicativo.View.Helpers;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Aplicativo.View.Layout.Component.ListView.Controls
{

    public partial class ListViewBtnFiltroComponent : ComponentBase
    {

        [Parameter] public string Text { get; set; } = "Filtro";

        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public ViewFiltro ViewFiltro { get; set; }

        public async Task ButtonFiltro_Click()
        {
            try
            {
                ViewFiltro.ViewModal.Show();
            }
            catch (Exception ex)
            {
                await HelpErro.Show(new Error(ex));
            }
        }

    }
}