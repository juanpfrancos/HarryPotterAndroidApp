﻿using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Windows.Input;
using Unidad_2.Models;
using Unidad_2.Views;
using Xamarin.Forms;

namespace Unidad_2.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        #region Atributos
        public string user;
        public string password;
        #endregion

        #region  Propiedades

        //Son las comunicadoras entre el view y viewmodel
        public string UserTxt
        {
            get { return user; }
            set { SetValue(ref this.user, value); }
        }

        public string PasswordTxt
        {
            get { return password; }
            set { SetValue(ref this.password, value); }
        }

        #endregion

        #region  Commands

        //enlazan una accion en la viewmodel con un evento en la vista
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod);
            }

        }

        #endregion

        #region Methods

        //Aqui viene la logica
        public async void LoginMethod()
        {
            if (string.IsNullOrEmpty(this.user) || string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes diligenciar ambos campos",
                    "Aceptar");
            }
            else
            {
                string _query = "SELECT * FROM UserModel WHERE UserName = '" + UserTxt.ToString() + "' AND Password = '" + PasswordTxt.ToString() + "' ";
                List<UserModel> ListUser = App.Db.QueryUserModel(_query).Result;

                if (ListUser.Count > 0)
                {
                    await Application.Current.MainPage.DisplayAlert(UserTxt.ToString(), "Welcome to HP App ⚡", "Ok");
                    await Application.Current.MainPage.Navigation.PushAsync(new HomeUser());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Dato(s) incorrecto(s)", "Ok");
                }
            }

        }
        #endregion

    }
}
