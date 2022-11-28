﻿using System;
using System.IO;
using HarryPotter_App.DataBase;
using HarryPotter_App.Views;
using Xamarin.Forms;

namespace HarryPotter_App
{
    public partial class App : Application
    {
        static DataBaseQuery database;


        public static DataBaseQuery Db
        {
            get
            {
                if (database == null)
                {
                    database = new DataBaseQuery(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DBAPP.db"));
                }
                return database;

            }

        }

        public App()
        {
            InitializeComponent();

            //el navigation/customnav crea la pila de navegacion
            MainPage = new CustomNav(new Home());

        }

        protected override void OnStart()
        {

            /*
            UserModel user = new UserModel();
            user.Nombre = "Pepe Perez";
            user.Email = "pepe@gmail.com";
            user.UserName = "pepe";
            user.Edad = "31";
            user.Password = "123456";

            var resul = App.Db.SaveUserModelAsync(user);
            */

            //aqui es para consultar en la base de datos
            //List<UserModel> Listusers = new List<UserModel>();
            //Listusers = App.Db.GetUserModel().Result;

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
