using CommunityToolkit.Mvvm.Input;
using HarryPotter_App.Models;
using HarryPotter_App.Views;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace HarryPotter_App.ViewModel
{
    internal class LoginViewModel : BaseViewModel
    {
        #region Atributos
        public string user;
        public string password;
        #endregion

        #region  Propiedades

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

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginMethod);
            }

        }

        #endregion

        #region Methods

        public async void LoginMethod()
        {
            if (string.IsNullOrEmpty(this.user) || string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Campos incompletos",
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
