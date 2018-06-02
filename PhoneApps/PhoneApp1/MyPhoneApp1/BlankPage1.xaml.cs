using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.Media.SpeechSynthesis;

namespace MyPhoneApp1
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        SqlConnection con = new SqlConnection();
        private MediaElement media;
        SpeechSynthesisStream stream = null;
        public BlankPage1()
        {
            this.InitializeComponent();
            con.ConnectionString = "Data Source=DESKTOP-JTCS65F;Initial Catalog=EcoBusDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        SpeechSynthesizer   ss = new SpeechSynthesizer();
        private async void BtnADD(object sender, RoutedEventArgs e)
        {

            // string test = "hallo, world";
            // ss.Dispose();
            // ss = new SpeechSynthesizer();
            //await ss.SynthesizeSsmlToStreamAsync(test);




            // try
            // {



            //     //// The media object for controlling and playing audio.
            //     //MediaElement mediaElement = this.media;

            //     //// The object for controlling the speech synthesis engine (voice).
            //     //var synth = new Windows.Media.SpeechSynthesis.SpeechSynthesizer();

            //     //// Generate the audio stream from plain text.
            //     //stream = await synth.SynthesizeTextToStreamAsync("Laura");

            //     //// Send the stream to the media object.

            //     //mediaElement.SetSource(stream, stream.ContentType);
            //     //mediaElement.Play();

            // }
            // catch (Exception)
            // {

            // }




            try
            {
                con.Open();


                //SqlCommand cmd = new SqlCommand();
                //// alles anzeigen
                //string query = " select * from TableEcoB ";
                //cmd.Connection = con;
                //cmd.CommandText = query;
                //cmd.ExecuteNonQuery();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable();
                //DataSet ds = new DataSet();
                //da.Fill(ds, " TableEcoB ");

                if (con.State == ConnectionState.Open)
                {
                    dataGrid.DataContext = con.State.ToString();
                    //MessageBox.Show("Verbindung OK");
                }


                //dataGrid.DataContext = ds.Tables["TableEcoB "].DefaultView;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog("could not open the folder? " + ex, "Information");
                await dialog.ShowAsync();

                con.Close();
            }
        }
    }
}
