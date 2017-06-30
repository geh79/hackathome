using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using HackAtHome.SAL;
using HackAtHome.Entities;

namespace HackAtHomeClient
{
    [Activity(Label = "Hack@Home", Icon = "@drawable/iconAndroid", Theme = "@android:style/Theme.Holo")]
    public class DetailEvidenceActivity : Activity
    {
        TextView TextViewUserFullName;
        ImageView imagen;
        WebView detailDescription;
        String FullName;
        String Token;
        int EvidenceID;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.DetailEvidence);

            imagen = FindViewById<ImageView>(Resource.Id.imageView1);
            detailDescription = FindViewById<WebView>(Resource.Id.detailDescription);
            TextViewUserFullName = FindViewById<TextView>(Resource.Id.userFullNameDetail);

            FullName = Intent.GetStringExtra("FullName") ?? "---";            
            EvidenceID = Convert.ToInt32(Intent.GetStringExtra("EvidenceID"));
            Token = Intent.GetStringExtra("Token");

            TextViewUserFullName.Text = FullName;

            DetalleEvidenciasAsync();
        }
        
        public async void DetalleEvidenciasAsync()
        {
            ServiceClient data = new ServiceClient();
            EvidenceDetail info = await data.GetEvidenceByIDAsync(Token, EvidenceID);

            detailDescription.LoadDataWithBaseURL(null, info.Description, "text/html", "utf-8", null);

            Koush.UrlImageViewHelper.SetUrlDrawable(imagen, info.Url);
        }
        
    }
}