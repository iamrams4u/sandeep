using System.Collections.Generic;
using AlaskaXC.Models;
using AlaskaXC.Services.Implementation;
using AlaskaXC.Services.Interface;
using AlaskaXC.ViewModels;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Android.Content;
using System.Threading.Tasks;

namespace AlaskaXC.Droid.Views
{
    [Activity(Label = "SecondActivity")]
    public class SecondActivity : Activity
    {
        private readonly SecondViewModel secondViewModel;
        private readonly IFlightService flightService;
        private ListView flightsListView;
        private List<FlightModel> flightsList;

        public SecondActivity()
        {
            flightService = new FlightService();
            secondViewModel = new SecondViewModel(flightService);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_second);
            flightsList = GetFlightList().Result;
            flightsListView = FindViewById<ListView>(Resource.Id.flightsListView);
            //var adapter = new FlightAdapter(flightsList);
            //flightsListView.Adapter = adapter;
        }

        private async Task<List<FlightModel>> GetFlightList()
        {
            return await secondViewModel.GetFlights();
        }
    }

    public class FlightAdapter : BaseAdapter<FlightModel>
    {
        private readonly List<FlightModel> flightsList;

        public FlightAdapter(List<FlightModel> flightsList)
        {
            this.flightsList = flightsList;
        }

        public override FlightModel this[int position] => flightsList[position];

        public override int Count => flightsList.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            ViewHolder holder;
            var view = convertView;

            if (convertView == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.list_view_item, parent, false);
                holder = new ViewHolder();
                holder.flightIdTextView = (TextView)convertView.FindViewById<TextView>(Resource.Id.flightIdTextView);
                holder.arrivalTimeTextView = (TextView)convertView.FindViewById<TextView>(Resource.Id.arrivalTimeTextView);
                view.Tag = holder;
            }
            else
            {
                holder = view.Tag as ViewHolder;
            }

            holder.flightIdTextView.Text = flightsList[position].FltId.ToString();
            holder.arrivalTimeTextView.Text = flightsList[position].EstArrTime.ToString();

            return convertView;
        }
    }

    public class ViewHolder : Object
    {
        public TextView flightIdTextView;
        public TextView arrivalTimeTextView;
    }
}