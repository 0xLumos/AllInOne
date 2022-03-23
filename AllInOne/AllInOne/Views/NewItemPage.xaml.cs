using AllInOne.Models;
using AllInOne.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Firebase.Storage;
using Xamarin.Forms.Xaml;

namespace AllInOne.Views
{
    public partial class NewItemPage : ContentPage
    {
        // Youtube tutorial:https://www.youtube.com/watch?v=IsbhleYMpsw&t=798s
        private async void Photo_Uploaded(System.Object sender, System.EventArgs e)
            //Check if photo is uploaded and push to Firebase storage 
        {
            var photo = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();

            if (photo == null)
                return;

            var task = new FirebaseStorage("allinone-342601.appspot.com",
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                })
                // Firebase node name 
                .Child("Images")
                .Child(photo.FileName)
                .PutAsync(await photo.OpenReadAsync());


        }
    }

}