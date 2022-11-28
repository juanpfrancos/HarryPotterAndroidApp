﻿using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using HarryPotter_App.Models;
using HarryPotter_App.Views;
using Xamarin.Forms;

namespace HarryPotter_App.ViewModel
{
    internal class RegisterViewModel : BaseViewModel
    {
        #region Atributos
        public string email;
        public string user;
        public string name;
        public string age;
        public string password;


        #endregion

        #region  Propiedades

        public string EmailTxt
        {
            get { return email; }
            set { SetValue(ref this.email, value); }
        }

        public string UserTxt
        {
            get { return user; }
            set { SetValue(ref this.user, value); }
        }

        public string NameTxt
        {
            get { return name; }
            set { SetValue(ref this.name, value); }
        }

        public string AgeTxt
        {
            get { return age; }
            set { SetValue(ref this.age, value); }
        }

        public string PasswordTxt
        {
            get { return password; }
            set { SetValue(ref this.password, value); }
        }

        #endregion

        #region  Commands
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
            }

        }

        #endregion

        #region Methods
        public async void RegisterMethod()
        {
            if (string.IsNullOrEmpty(this.email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Empty data",
                    "Ok");
            }

            else if (string.IsNullOrEmpty(this.user))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Cannot be null",
                    "Ok");
            }

            else if (string.IsNullOrEmpty(this.name))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Empty data",
                    "Ok");
            }

            else if (string.IsNullOrEmpty(this.age))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar la edad",
                    "Aceptar");
            }

            else if (string.IsNullOrEmpty(this.password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Debes ingresar una contrasena",
                    "Aceptar");
            }
            else
            {
                try
                {
                    UserModel user = new UserModel();

                    user.Nombre = NameTxt.ToString();
                    user.Email = EmailTxt.ToString();
                    user.UserName = UserTxt.ToString();
                    user.Edad = AgeTxt.ToString();
                    user.Password = PasswordTxt.ToString();

                    await App.Db.SaveUserModelAsync(user);

                    await Application.Current.MainPage.DisplayAlert("SignUp", "SignUp Sucessfully", "Ok");
                    await Application.Current.MainPage.Navigation.PushAsync(new Home());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }
        #endregion
    }
}