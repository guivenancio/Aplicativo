﻿using Aplicativo.Utils.Helpers;
using Aplicativo.Utils.Models;
using Aplicativo.View.Controls;
using Aplicativo.View.Helpers;
using Aplicativo.View.Helpers.Exceptions;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicativo.View.Pages.Login.Entrar
{
    public partial class IndexPage : ComponentBase
    {

        #region Elements
        public TextBox TxtName { get; set; }

        public DropDownList DplEmpresa { get; set; }
        public TextBox TxtUsuario { get; set; }
        public TextBox TxtSenha { get; set; }

        public CheckBox ChkManterConectado { get; set; }
        #endregion

        protected async Task Page_Load()
        {
            try
            {

                await HelpLoading.Show("Carregando...");

                TxtName.Text = HelpConexao.Dominio.Name;

                await DplEmpresa.LoadDropDownList<Empresa>("EmpresaID", "NomeFantasia", new DropDownListItem(null, "[Selecione]"));

                TxtUsuario.Focus();

            }
            catch (Exception ex)
            {
                await HelpErro.Show(new Error(ex));
            }
            finally
            {
                await HelpLoading.Hide();
            }
        }

        protected async Task BtnAlterarDominio_Click()
        {
            await HelpConexao.SetName(null);
            App.NavigationManager.NavigateTo("Login");
        }

        protected async Task BtnEntrar_Click()
        {
            try
            {

                if (DplEmpresa.SelectedValue == null)
                {
                    throw new EmptyException("Informe a empresa!", DplEmpresa.Element);
                }

                if (string.IsNullOrEmpty(TxtUsuario.Text))
                {
                    throw new EmptyException("Informe o login!", TxtUsuario.Element);
                }

                if (string.IsNullOrEmpty(TxtSenha.Text))
                {
                    throw new EmptyException("Informe a senha!", TxtSenha.Element);
                }

                await HelpLoading.Show("Entrando...");

                var QueryUsuario = new HelpQuery<Usuario>();

                QueryUsuario.AddInclude("Funcionario");
                QueryUsuario.AddWhere("Login == @0", TxtUsuario.Text);
                QueryUsuario.AddWhere("Ativo == @0", true);

                var Usuario = await QueryUsuario.FirstOrDefault();

                if (Usuario == null)
                {
                    TxtUsuario.Text = null;
                    TxtSenha.Text = null;
                    throw new EmptyException("Usuário não encontrado!", TxtUsuario.Element);
                }

                if (Usuario.Senha != TxtSenha.Text)
                {
                    TxtSenha.Text = null;
                    throw new EmptyException("Senha incorreta!", TxtSenha.Element);
                }


                var UsuarioID = Usuario.UsuarioID.ToString();
                var EmpresaID = DplEmpresa.SelectedValue;


                await HelpParametros.CarregarParametros(UsuarioID.ToIntOrNull(), EmpresaID.ToIntOrNull());

                if (ChkManterConectado.Checked)
                {
                    await HelpCookie.Set("ManterConectado", UsuarioID + "§" + EmpresaID, 0);
                }

                App.NavigationManager.NavigateTo("");

            }
            catch (EmptyException)
            {

            }
            catch (Exception ex)
            {
                await HelpErro.Show(new Error(ex));
            }
            finally
            {
                await HelpLoading.Hide();
            }
        }

        protected void BtnRecuperar_Click()
        {
            App.NavigationManager.NavigateTo("Login/Recuperar");
        }

    }
}