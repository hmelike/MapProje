using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GMap.NET.Entity.OpenStreetMapRouteEntity;


namespace Map_Proje
{
    public partial class Form1 : Form
    {
        private  List <PointLatLng> _points;
        Repositories.KoordinatlarRepositorie koordinatlarRepositorie;
        
        public Form1()
        {
            InitializeComponent();
            _points = new List<PointLatLng>();
            koordinatlarRepositorie = new Repositories.KoordinatlarRepositorie();

           // dataGridView1.Columns.Add("koordinat", "lat");
          //  dataGridView1.Columns.Add("koordinat", "long");
            //dataGridView1.Columns.Add("koordinat", "datetime");





        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnmap_Click(object sender, EventArgs e)
        {



          






        }
        int delay = 0;
        private void map_MouseMove(object sender, MouseEventArgs e)
        {
            //mouse haritanın üzerindeyken koordinatları gösterir
            {
                try
                {

                    delay++;
                    if (delay == 10)
                    {
                        int x = e.X;
                        int y = e.Y;
                        double lat = map.FromLocalToLatLng(e.X, e.Y).Lat;
                        double Long= map.FromLocalToLatLng(e.X, e.Y).Lng;
                        //mouse haritanın üzerindeyken koordinatları gösterir
                        label3.Text = Convert.ToString(lat + .1000);
                        label4.Text = Convert.ToString(Long);
                 
                      delay = 0;

                    }
                }
                catch(Exception )
                {
                    MessageBox.Show("Hatalı Değerler");
                }
            }
        }
       

        private void btnaddpoint_Click(object sender, EventArgs e)
        {
            _points.Add(new PointLatLng(Convert.ToDouble(lattxtbx.Text),
                Convert.ToDouble(longtxtbx.Text)));

        


        }
        DateTime dt = DateTime.Now;
        private void map_MouseClick(object sender, MouseEventArgs e)
        {


            {
                try
                {

                    delay++;
                    if (delay == 10)
                    {
                        int x = e.X;
                        int y = e.Y;
                        double lat = map.FromLocalToLatLng(e.X, e.Y).Lat;
                        double Long = map.FromLocalToLatLng(e.X, e.Y).Lng;
                        lattxtbx.Text = Convert.ToString(lat + .1000);
                        longtxtbx.Text = Convert.ToString(Long);
                        maskedTextBox1.Text = dt.ToString();


                        delay = 0;

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hatalı Değerler");
                }

            }


            PointLatLng point = new PointLatLng();

            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);

            GMapOverlay markers = new GMapOverlay("markers");

            markers.Markers.Add(marker);

            map.Overlays.Add(markers);



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //harita zoom
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            map.MaxZoom = 50;
            map.MinZoom = 5;
            map.Zoom = 10;


            PointLatLng point = new PointLatLng();

            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot);

            GMapOverlay markers = new GMapOverlay("markers");

            markers.Markers.Add(marker);

            map.Overlays.Add(markers);

            map.MapProvider = GMapProviders.GoogleMap;
            double lat = Convert.ToDouble(lattxtbx.Text);
            double Long = Convert.ToDouble(longtxtbx.Text);
            map.Position = new GMap.NET.PointLatLng(lat, Long);

            //XmlTextWriter dosya = new XmlTextWriter(@"veri.xml", Encoding.UTF8);
            //dosya.Formatting = Formatting.Indented;
            //dosya.WriteStartDocument();
            //dosya.WriteStartElement("Koordinatlar");
            //dosya.WriteStartElement("Koordinat");
            //dosya.WriteElementString("lag", "36,421555");
            //dosya.WriteElementString("long", "42,421555");
            //dosya.WriteElementString("datetime", "18.08.2022 01:03");
            //dosya.WriteEndElement();
            //dosya.WriteEndElement();
            //dosya.Close();

          

           





        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            lattxtbx.Text = " ";
            longtxtbx.Text = " ";
            maskedTextBox1.Text = " ";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("'lang:'" + lattxtbx.Text +"  " +   "'long: '" + longtxtbx.Text + " "+ " ' datetime '"+ maskedTextBox1.Text );
            
           
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int secim = listBox1.SelectedIndex;
            if(secim!=-1)
            {
                listBox1.Items.RemoveAt(secim);

            }
            else
            {
                MessageBox.Show("Lütfen Seçim Yapınız!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           // if (dataGridView1.CurrentRow.Cells[0].Value != null)
           // { 
           // lattxtbx.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
           // longtxtbx.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
          //  maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           // }
           // else
         //   {
              //  MessageBox.Show("yanlış girdi");
           // }
        }
    }
}
