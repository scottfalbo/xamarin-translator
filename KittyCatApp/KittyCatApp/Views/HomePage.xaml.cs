﻿using KittyCatApp.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KittyCatApp.Models;

namespace KittyCatApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {

        readonly HomeViewModel _vm;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = _vm = new HomeViewModel();
        }

        public async void Spanish(object sender, EventArgs e)
        {
            await TranslatePhrase(EntryText.Text, "es");
        }
        public async void French(object sender, EventArgs e)
        {
            await TranslatePhrase(EntryText.Text, "fr");
        }
        public async void German(object sender, EventArgs e)
        {
            await TranslatePhrase(EntryText.Text, "de");
        }

        public async Task TranslatePhrase(string phrase, string lang)
        {
            var translatedText = await _vm.TranslateTextAsync(phrase, lang);
            string[] results = _vm.DeserializeObject(translatedText);


            var locales = await TextToSpeech.GetLocalesAsync();
            var locale = locales.ToList();

            await TextToSpeech.SpeakAsync(results[0], new SpeechOptions
            {
                Volume = (float)SliderVolume.Value,
                Locale = locale[22]
            });
            
        }

    }

}