using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;


namespace LaunchesAPI
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public class Core
        {
            public string core_serial { get; set; }
            public int flight { get; set; }
            public object block { get; set; }
            public bool gridfins { get; set; }
            public bool legs { get; set; }
            public bool reused { get; set; }
            public object land_success { get; set; }
            public bool landing_intent { get; set; }
            public object landing_type { get; set; }
            public object landing_vehicle { get; set; }
            public override string ToString()
            {
                return core_serial + "\n" + flight + "\n" + block + "\n" + gridfins + "\n" + legs + "\n" + reused + "\n" + land_success + "\n" + landing_intent + "\n" + landing_type + "\n" + landing_vehicle+"\n";
            }
        }

        public class FirstStage
        {
            public List<Core> cores { get { return cores; } set { if (value == null)cores=null; else cores = value; } }
            public override string ToString()
            {
                return cores.ToString()+"\n";
            }
        }

        public class OrbitParams
        {
            public string reference_system { get; set; }
            public string regime { get; set; }
            public object longitude { get; set; }
            public object semi_major_axis_km { get; set; }
            public object eccentricity { get; set; }
            public string periapsis_km { get; set; }
            public string apoapsis_km { get; set; }
            public string inclination_deg { get; set; }
            public object period_min { get; set; }
            public object lifespan_years { get; set; }
            public object epoch { get; set; }
            public object mean_motion { get; set; }
            public object raan { get; set; }
            public object arg_of_pericenter { get; set; }
            public object mean_anomaly { get; set; }
            public override string ToString()
            {
                return reference_system + "\n" + regime + "\n" + longitude + "\n" + semi_major_axis_km + "\n" + eccentricity + "\n" + periapsis_km + "\n" + apoapsis_km + "\n" + inclination_deg + "\n" + period_min + "\n" + lifespan_years + "\n" + epoch + "\n" + mean_motion + "\n" + raan + "\n" + arg_of_pericenter + "\n" + mean_anomaly+"\n";
            }

        }

        public class Payload
        {
            public string payload_id { get; set; }
            public List<object> norad_id { get; set; }
            public bool reused { get; set; }
            public List<string> customers { get; set; }
            public string nationality { get; set; }
            public string manufacturer { get; set; }
            public string payload_type { get; set; }
            public string payload_mass_kg { get; set; }
            public string payload_mass_lbs { get; set; }
            public string orbit { get; set; }
            public OrbitParams orbit_params { get; set; }
            public override string ToString()
            {
                return payload_id + "\n" + norad_id + "\n" + reused + "\n" + customers + "\n" + nationality + "\n" + manufacturer + "\n" + payload_type + "\n" + payload_mass_kg + "\n" + payload_mass_lbs + "\n" + orbit + "\n" + orbit_params.ToString() + "\n";
            }
        }

        public class SecondStage
        {
            public int block { get; set; }
            public List<Payload> payloads { get; set; }
            public override string ToString()
            {
                return block.ToString() + "\n" + payloads.ToString()+"\n";
            }
        }

        public class Fairings
        {
            public bool reused { get; set; }
            public bool recovery_attempt { get; set; }
            public bool recovered { get; set; }
            public object ship { get; set; }
            public override string ToString()
            {
                return reused.ToString() + "\n" + recovery_attempt + "\n" + recovered + "\n" + ship + "\n";
            }
        }

        public class Rocket
        {
            public string rocket_id { get; set; }
            public string rocket_name { get; set; }
            public string rocket_type { get; set; }
            public FirstStage first_stage { get; set; }
            public SecondStage second_stage { get; set; }
            public Fairings fairings { get; set; }
            public override string ToString()
            {
                return "Rocket: \n" + rocket_id + "\n" + rocket_name + "\n" + rocket_type + "\n" + first_stage.ToString() + "\n" + second_stage.ToString() + "\n" + fairings.ToString();
            }
        }

        public class Telemetry
        {
            public object flight_club { get; set; }
            public override string ToString()
            {
                return flight_club.ToString() + "\n";
            }
        }

        public class LaunchSite
        {
            public string site_id { get; set; }
            public string site_name { get; set; }
            public string site_name_long { get; set; }
            public override string ToString()
            {
                return "Launch site" + site_id + "\n" + site_name + "\n" + site_name_long + "\n";
            }
        }

        public class LaunchFailureDetails
        {
            public int time { get; set; }
            public object altitude { get; set; }
            public string reason { get; set; }
            public override string ToString()
            {
                return time.ToString() + "\n" + altitude + "\n" + reason + "\n";
            }
        }

        public class Links
        {
            public string mission_patch { get; set; }
            public string mission_patch_small { get; set; }
            public object reddit_campaign { get; set; }
            public object reddit_launch { get; set; }
            public object reddit_recovery { get; set; }
            public object reddit_media { get; set; }
            public object presskit { get; set; }
            public string article_link { get; set; }
            public string wikipedia { get; set; }
            public string video_link { get; set; }
            public string youtube_id { get; set; }
            public List<object> flickr_images { get; set; }
        }

        public class Timeline
        {
            public int webcast_liftoff { get; set; }
            public override string ToString()
            {
                return webcast_liftoff.ToString()+"\n";
            }
        }

        public class SpaceX
        {
            public int flight_number { get; set; }
            public string mission_name { get; set; }
            public List<object> mission_id { get; set; }
            public bool upcoming { get; set; }
            public string launch_year { get; set; }
            public int launch_date_unix { get; set; }
            public DateTime launch_date_utc { get; set; }
            public DateTime launch_date_local { get; set; }
            public bool is_tentative { get; set; }
            public string tentative_max_precision { get; set; }
            public bool tbd { get; set; }
            public string launch_window { get; set; }
            public Rocket rocket { get; set; }
            public List<object> ships { get; set; }
            public Telemetry telemetry { get; set; }
            public LaunchSite launch_site { get; set; }
            public string launch_success { get; set; }
            public LaunchFailureDetails launch_failure_details { get; set; }
            public Links links { get; set; }
            public string details { get; set; }
            public string static_fire_date_utc { get; set;  }
            public string static_fire_date_unix { get; set; }
            public Timeline timeline { get; set; }
            public override string ToString()
            {
                string s = flight_number.ToString() + "\n" + mission_name + "\n" + mission_id + "\n" + upcoming + "\n" + launch_year + "\n" + launch_date_unix + "\n" + launch_date_utc + "\n" + launch_date_local + "\n" + is_tentative + "\n" + tentative_max_precision + "\n";
                s += tbd.ToString() + "\n" + launch_window + "\n" + rocket.ToString() + "\n" + ships.ToString() + "\n" + telemetry.ToString() + "\n" + launch_site.ToString() + "\n" + launch_success + "\n";
                s += launch_failure_details.ToString() + "\n" + details + "\n" + static_fire_date_utc + "\n" + static_fire_date_unix +"\n"+ timeline.ToString();
                return s;
            }
        }
        private StackLayout _mainLayout;
        public MainPage()
        {
            InitializeComponent();
            
        }
        public List<SpaceX> Items { get; private set; }
        private async Task<List<SpaceX>> handleLogin()
        {
            Items = new List<SpaceX>();
            var chatAppClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "https://api.spacexdata.com/v3/launches/upcoming");
            var response = await chatAppClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var text = await response.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<List<SpaceX>>(text);
                return Items;
            }
            else
            {
                var text = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(text);
                return null;
            }
        }
        private async void Button1_Click(object sender, EventArgs e)
        {
            List<SpaceX> userdata = await handleLogin();
            Label[] labels = new Label[3];
            int i = 0;
            _mainLayout = new StackLayout();
            if (userdata != null)
            {
                foreach (var dat in userdata)
                {
                    labels[i].Text = dat.ToString();
                    _mainLayout.Children.Add(labels[i]);
                    i++;
                }

            }
            else
            {
                Label label2 = new Label();
                label2.Text = "Error";
                _mainLayout.Children.Add(label2);
            }
            Content = _mainLayout;
        }
    }
}
