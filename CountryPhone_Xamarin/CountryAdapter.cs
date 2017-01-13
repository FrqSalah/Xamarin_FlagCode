﻿using System;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using Android.App;
using Android;
using System.IO;
using Android.Graphics.Drawables;

namespace CountryPhone_Xamarin
{
    public class CountryAdapter : BaseAdapter<Country>
    {
        Activity context;
        List<Country> countries;
        public CountryAdapter(Activity s_context, List<Country> s_countries)
        {
            this.context = s_context;
            this.countries = s_countries;
        }

        public override Country this[int position]
        {
            get
            {
                return countries[position];
            }
        }

        public override int Count
        {
            get
            {
                return countries.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = context.LayoutInflater.Inflate(Resource.Layout.CountryRow, parent, false);

            var flagPhoto = view.FindViewById<ImageView>(Resource.Id.Photoflag);
            var countryName = view.FindViewById<TextView>(Resource.Id.CoutryName);
            var countryCode = view.FindViewById<TextView>(Resource.Id.CoutryCode);

            // Gérer les photos des drapeaux
            Stream stream;
            if (position < 10)
                 stream = context.Assets.Open("flagPhotos/f00" + position+".png");
            else if (position > 9 && position < 100)
                stream = context.Assets.Open("flagPhotos/f0" + position + ".png");
            else
                 stream = context.Assets.Open("flagPhotos/f" + position + ".png");

            Drawable drawable = Drawable.CreateFromStream(stream, null);
            flagPhoto.SetImageDrawable(drawable);
            countryName.Text = countries[position].cName;
            countryCode.Text = countries[position].cCodeStr;

            return view;
        }
    }
}