﻿using jcordovat5.Models;

namespace jcordovat5
{
    public partial class App : Application
    {
        public static PersonRepository personRepo {  get; set; }
        public App(PersonRepository personRepository)
        {
            InitializeComponent();

            MainPage = new Views.vPersona();
            personRepo = personRepository;
        }
    }
}
