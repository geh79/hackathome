﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace HackAtHomeClient
{
    [Activity(Label = "Hack@Home", Icon = "@drawable/iconAndroid", Theme = "@android:style/Theme.Holo")]
    public class EvidencesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Evidences);            
        }
    }
}