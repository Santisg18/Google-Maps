using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMaps
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.ShowCenter = false;
            gMapControl1.Position = new PointLatLng(6.2518401,-75.563591);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 100;
            gMapControl1.Zoom = 10;
            //gMapControl1.CanDragMap = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            double lat = Convert.ToDouble(textBox1.Text);
            double lon = Convert.ToDouble(textBox2.Text);
            gMapControl1.Position = new PointLatLng(lat, lon);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 1000;
            gMapControl1.Zoom = 10;

            PointLatLng puntoLatLong = new PointLatLng(lat, lon);
            GMapMarker marcador = new GMarkerGoogle(puntoLatLong,GMarkerGoogleType.red_dot);

            GMapOverlay Marcadores = new GMapOverlay("Marcadores");
            Marcadores.Markers.Add(marcador);
            marcador.ToolTipMode = MarkerTooltipMode.Always;
            marcador.ToolTipText = string.Format("\n Mensajero:{0} \n Ubicación: \n Latitud:{1} \n Longitud:{2}",textBox3.Text, lat, lon);

            gMapControl1.Overlays.Add(Marcadores);

        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var puntos = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                double lat1 = puntos.Lat;
                double lng1 = puntos.Lng;
                gMapControl1.Position = puntos;
                var Marcadores = new GMapOverlay("Marcadores");
                var Marcador= new GMarkerGoogle(puntos, GMarkerGoogleType.red_dot);
                Marcadores.Markers.Add(Marcador);
                Marcador.ToolTipMode = MarkerTooltipMode.Always;
                Marcador.ToolTipText = string.Format("\n Ubicación: \n Latitud:{0} \n Longitud:{1}", lat1, lng1);

                gMapControl1.Overlays.Add(Marcadores);
            }
        }
    }
}
